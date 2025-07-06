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

using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using SharpCord.Helpers;
using SharpCord.Models;
using SharpCord.Types;
using SharpCord.Utils;

namespace SharpCord.Voice;

/// <summary>
/// 
/// </summary>
public class VoiceClient : BaseInteraction
{
    private string _token;
    private readonly Snowflake _guildId;
    private readonly Snowflake _channelId;
    
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
    public async Task ConnectAsync() => await SocketHelper.ConnectAsync();

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
        await SocketHelper.SendMessageAsync(json);
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
        await SocketHelper.SendMessageAsync(json);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filePath"></param>
    public async Task PlayAsync(string filePath)
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="audioStream"></param>
    public async Task PlayAsync(Stream audioStream)
    {
        
    }
}