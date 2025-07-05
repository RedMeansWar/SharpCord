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
    public class SocketHelper
    {
        private static ClientWebSocket? _socket;

        public static bool IsConnected => _socket.State == WebSocketState.Open;

        public static void InitalizeHelper()
        {
            if (_socket is null)
            {
                _socket = new();
            }
        }

        public static async Task ConnectAsync()
        {
            if (IsConnected)
            {
                return;
            }

            await _socket.ConnectAsync(new("wss://gateway.discord.gg/?v=10&encoding=json"), CancellationToken.None);
        }

        public static async Task SendMessageAsync(string json)
        {
            if (!IsConnected)
            {
                return;
            }

            byte[] bytes = Encoding.UTF8.GetBytes(json);

            await _socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public static async Task ListenForEvents()
        {
            byte[] buffer = new byte[4096];
            StringBuilder messagBuilder = new();

            while (IsConnected)
            {
                try
                {
                    WebSocketReceiveResult res;

                    do
                    {
                        res = await _socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                        if (res.MessageType == WebSocketMessageType.Close)
                        {
                            await _socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by server", CancellationToken.None);

                            return;
                        }

                        messagBuilder.Append(Encoding.UTF8.GetString(buffer, 0, res.Count));
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
