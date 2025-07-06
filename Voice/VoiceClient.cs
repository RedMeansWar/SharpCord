#region LICENSE
// Copyright (c) 2025 RedMeansWar
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System.Buffers.Binary;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Concentus;
using Concentus.Enums;
using Concentus.Structs;
using SharpCord.Helpers;
using SharpCord.Models;
using SharpCord.Payloads;
using SharpCord.Types;
using SharpCord.Utils;
using Sodium;

namespace SharpCord.Voice;

/// <summary>
/// 
/// </summary>
public class VoiceClient : BaseInteraction
{
    private string _token;
    private readonly Snowflake _guildId;
    private readonly Snowflake _channelId;

    private string? _voiceEndpoint;
    private string? _sessionId;
    private string? _voiceToken;
    private string? _voiceIp;

    private int _voicePort;
    private int _ssrc;

    private byte[] _secretKey = Array.Empty<byte>();

    private UdpClient _udpClient;
    private OpusEncoder _encoder;
    private SocketHelper _socketHelper = new();
    
    /// <summary>
    /// 
    /// </summary>
    public bool IsConnected = SocketHelper.IsConnected;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="guildId"></param>
    /// <param name="channelId"></param>
    public VoiceClient(Snowflake guildId, Snowflake channelId)
    {
        _guildId = guildId;
        _channelId = channelId;
        _token = DiscordClient.Token;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="payload"></param>
    public void HandleVoiceStateUpdate(VoiceStateUpdatePayload payload) => _sessionId = payload.SessionId;// not sure where this and "HandleVoiceServerUpdate" is supposed to go so im just leaving it unused atm

    /// <summary>
    /// 
    /// </summary>
    public async Task ConnectAsync() => await _socketHelper.ConnectAsync($"wss://{_voiceEndpoint}?v=4");

    /// <summary>
    /// 
    /// </summary>
    /// <param name="selfMute"></param>
    /// <param name="selfDeaf"></param>
    public async Task JoinChannel(bool selfMute = false, bool selfDeaf = false)
    {
        if (!IsConnected)
        {
            Log.Warning("Not connected to the WebSocket");
            return;
        }

        var payload = new
        {
            op = 4,
            d = new
            {
                guild_id = _guildId,
                channel_id = _channelId,
                self_mute = selfMute,
                self_deaf = selfDeaf
            }
        };

        var json = JsonSerializer.Serialize(payload);
        await _socketHelper.SendMessageAsync(json);
    }

    /// <summary>
    /// 
    /// </summary>
    public async Task LeaveChannel()
    {
        if (!IsConnected)
        {
            Log.Warning("Not connected to the WebSocket");
            return;
        }

        var payload = new
        {
            op = 4,
            d = new
            {
                guild_id = _guildId.ToString(),
                channel_id = (string?)null,
                self_mute = false,
            }
        };
        
        var json = JsonSerializer.Serialize(payload);
        await _socketHelper.SendMessageAsync(json);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="payload"></param>
    /// <returns></returns>
    public async Task HandleVoiceServerUpdate(VoiceServerUpdatePayload payload)
    {
        _voiceToken = payload.Token;
        _voiceEndpoint = payload.Endpoint;

        if (_voiceEndpoint is not null && _sessionId is not null && _voiceToken is not null)
        {
            await StartConnectionAsync();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filePath"></param>
    public async Task PlayAsync(string filePath)
    {
        using FileStream fs = File.OpenRead(filePath);

        await PlayAsync(fs);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="audioStream"></param>
    public async Task PlayAsync(Stream audioStream)
    {
        if (_udpClient is null || _encoder is null || _secretKey.Length == 0)
        {
            return;
        }

        byte[] buffer = new byte[3840];
        byte[] encoded = new byte[4000];
        byte[] nonce = new byte[24];

        short[] pcm = new short[960 * 2];

        int seqence = 0;
        uint timestamp = 0;

        while (true)
        {
            int read = await audioStream.ReadAsync(buffer);

            if (read == 0)
            {
                break;
            }

            Buffer.BlockCopy(buffer, 0, pcm, 0, read);

            int encodedLen = _encoder.Encode(pcm, 0, 960, encoded, 0, encoded.Length);

            var header = new RtpHeaderPayload
            {
                Version = 2,
                Padding = false,
                Extension = false,
                CsrcCount = 0,
                Marker = false,
                PayloadType = 0,
                Timestamp = timestamp += 960,
                SequenceNumber = (ushort)seqence++,
                Ssrc = (uint)_ssrc,
                Csrc = Array.Empty<uint>()
            };

            byte[] rtpHeader = BuildRtpHeader(header);
            byte[] nonceFull = new byte[24];

            Array.Copy(rtpHeader, nonceFull, 12);

            byte[] encrypted = SecretBox.Create(encoded[..encodedLen], nonceFull, _secretKey);

            byte[] packet = new byte[12 + encrypted.Length];

            Array.Copy(rtpHeader, packet, 12);
            Array.Copy(encrypted, 0, packet, 12, encrypted.Length);

            await _udpClient.SendAsync(packet);
            await Task.Delay(20);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private async Task StartConnectionAsync()
    {
        await ConnectAsync();

        var identity = new
        {
            op = 0,
            d = new
            {
                server_id = _guildId,
                user_id = DiscordClient.Id,
                session_id = _sessionId,
                token = _voiceToken
            }
        };

        await _socketHelper.SendMessageAsync(JsonSerializer.Serialize(identity));

        JsonElement json = await _socketHelper.ReceiveMessageAsync();

        _ssrc = json.GetProperty("d").GetProperty("ssrc").GetInt32();
        _voicePort = json.GetProperty("d").GetProperty("port").GetInt32();
        _voiceIp = json.GetProperty("d").GetProperty("ip").GetString();

        await PerformUdpDiscovery();

        var selectProtocol = new
        {
            op = 1,
            d = new
            {
                protocol = "udp",
                data = new
                {
                    address = _voiceIp,
                    port = _voicePort,
                    mode = "xsalsa20_poly1305"
                }
            }
        };

        await _socketHelper.SendMessageAsync(JsonSerializer.Serialize(selectProtocol));

        JsonElement secret = await _socketHelper.ReceiveMessageAsync();

        _secretKey = secret.GetProperty("d").GetProperty("secret_key").EnumerateArray().Select(x => (byte)x.GetInt32()).ToArray();

        _encoder = (OpusEncoder)OpusCodecFactory.CreateEncoder(48000, 2, OpusApplication.OPUS_APPLICATION_AUDIO);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private async Task PerformUdpDiscovery()
    {
        _udpClient = new();
        _udpClient.Connect(_voiceIp, _voicePort);

        byte[] packet = new byte[70];

        BinaryPrimitives.WriteUInt32BigEndian(packet.AsSpan(0, 4), (uint)_ssrc);
        await _udpClient.SendAsync(packet);

        UdpReceiveResult res = await _udpClient.ReceiveAsync();

        string externalIp = Encoding.UTF8.GetString(res.Buffer, 4, 64).TrimEnd('\0');
        int port = BinaryPrimitives.ReadUInt16BigEndian(res.Buffer.AsSpan(68, 2));

        _voiceIp = externalIp;
        _voicePort = port;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="headerPayload"></param>
    /// <returns></returns>
    private byte[] BuildRtpHeader(RtpHeaderPayload headerPayload)
    {
        int headerSize = 12 + headerPayload.Csrc.Length * 4;
        byte[] rtpHeaderBytes = new byte[headerSize];

        rtpHeaderBytes[0] = (byte)((headerPayload.Version << 6) |
            (headerPayload.Padding ? 1 << 5 : 0) |
            (headerPayload.Extension ? 1 << 4 : 0) |
            headerPayload.CsrcCount);

        rtpHeaderBytes[1] = (byte)((headerPayload.Marker ? 1 << 7 : 0) |
        headerPayload.PayloadType);

        BinaryPrimitives.WriteUInt16BigEndian(rtpHeaderBytes.AsSpan(2), headerPayload.SequenceNumber);
        BinaryPrimitives.WriteUInt32BigEndian(rtpHeaderBytes.AsSpan(4), headerPayload.Timestamp);
        BinaryPrimitives.WriteUInt32BigEndian(rtpHeaderBytes.AsSpan(8), headerPayload.Ssrc);

        for (int i = 0; i < headerPayload.Csrc.Length; i++)
        {
            BinaryPrimitives.WriteUInt32BigEndian(rtpHeaderBytes.AsSpan(12 + i * 4), headerPayload.Csrc[i]);
        }

        return rtpHeaderBytes;
    }
}