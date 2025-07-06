using SharpCord.Registry;
using SharpCord.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SharpCord.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class SocketHelper
    {
        private byte[] _buffer = new byte[4096];

        private static ClientWebSocket? _socket;

        /// <summary>
        /// 
        /// </summary>
        public static bool IsConnected => _socket.State == WebSocketState.Open;
        
        /// <summary>
        /// 
        /// </summary>
        public SocketHelper()
        {
            if (_socket is null)
            {
                _socket = new();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public  async Task ConnectAsync(string url)
        {
            if (IsConnected)
            {
                return;
            }

            await _socket.ConnectAsync(new(url), CancellationToken.None);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        public async Task SendMessageAsync(string json)
        {
            if (!IsConnected)
            {
                return;
            }

            byte[] bytes = Encoding.UTF8.GetBytes(json);

            await _socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<JsonElement> ReceiveMessageAsync()
        {
            WebSocketReceiveResult res = await _socket.ReceiveAsync(_buffer, CancellationToken.None);

            return JsonSerializer.Deserialize<JsonElement>(_buffer[..res.Count])!;
        }

        /// <summary>
        /// 
        /// </summary>
        public  async Task ListenForEvents()
        {
            StringBuilder messagBuilder = new();

            while (IsConnected)
            {
                try
                {
                    WebSocketReceiveResult res;

                    do
                    {
                        res = await _socket.ReceiveAsync(new ArraySegment<byte>(_buffer), CancellationToken.None);

                        if (res.MessageType == WebSocketMessageType.Close)
                        {
                            await _socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by server", CancellationToken.None);

                            return;
                        }

                        messagBuilder.Append(Encoding.UTF8.GetString(_buffer, 0, res.Count));
                    }
                    while (!res.EndOfMessage);

                    string message = messagBuilder.ToString();

                    messagBuilder.Clear();

                    try
                    {
                        var json = JsonDocument.Parse(message);

                        var opCode = json.RootElement.GetProperty("op").GetInt32();
                        var eventName = json.RootElement.GetProperty("t").GetString();
                        var payload = json.RootElement.GetProperty("d");

                        if (!string.IsNullOrWhiteSpace(eventName) || eventName is not null)
                            await EventRegistry.DispatchAsync(eventName, payload);
                    }
                    catch
                    {
                        //
                    }
                }
                catch
                {
                    //
                }
            }
        }
    }
}
