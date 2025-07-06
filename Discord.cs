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

using System.Drawing;
using System.Net;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using SharpCord.Helpers;
using SharpCord.Models;
using SharpCord.Registry;
using SharpCord.Types;
using SharpCord.Utils;

namespace SharpCord;

/// <summary>
/// Represents a client for connecting to the Discord API.
/// Provides mechanisms to authenticate and interact with Discord servers and users.
/// </summary>
public class DiscordClient
{
    internal readonly GatewayIntent _intents;

    /// <summary>
    /// Represents the authentication token used to connect and authenticate with the Discord API.
    /// This static property is fundamental for establishing a connection and performing actions
    /// on behalf of the bot programmatically.
    /// </summary>
    /// <remarks>
    /// The token is set during the initialization of the DiscordClient and is immutable after being defined.
    /// It must be kept secure, as it allows full access to the Discord bot account. Unauthorized use or exposure
    /// can lead to potential misuse and security vulnerabilities.
    /// </remarks>
    /// <value>
    /// A string containing the authentication token used for Discord API authentication. This value
    /// is required for all API operations and is statically accessible across the application once set.
    /// </value>
    public static string Token { get; private set; } = string.Empty;

    /// <summary>
    /// Represents the unique identifier of the Discord bot application linked to the current token.
    /// This static property is assigned and updated upon successful authentication with the Discord API.
    /// </summary>
    /// <remarks>
    /// The identifier serves as an essential reference point for identifying the bot application during
    /// interactions with Discord services. It is automatically retrieved during the login process and
    /// remains constant throughout the application's runtime. Proper handling of the ID is necessary
    /// for executing API operations that rely on application identity.
    /// </remarks>
    /// <value>
    /// A snowflake containing the unique identifier of the Discord bot application. This value is
    /// assigned once the authentication process successfully establishes a connection to the Discord API.
    /// </value>
    public static Snowflake Id { get; private set; }

    /// <summary>
    /// Represents a client for connecting to the Discord Gateway API, allowing interaction
    /// with Discord's services such as sending messages and listening to events.
    /// </summary>
    public DiscordClient(string token, GatewayIntent intents = GatewayIntent.All)
    {
        Token = token;
        _intents = intents;
    }

    /// <summary>
    /// Authenticates the client and connects it to the Discord Gateway API.
    /// Establishes a WebSocket connection, identifies the bot, and begins listening
    /// for incoming events from Discord.
    /// </summary>
    /// <returns>Returns a task representing the asynchronous login operation.</returns>
    public async Task LoginAsync()
    {
        HttpHelper.InitializeHelper(new());
        //SocketHelper.InitalizeHelper();
        SocketHelper socket = new();

        Id = await GetCurrentIdAsync(Token);

        await socket.ConnectAsync("wss://gateway.discord.gg/?v=10&encoding=json");

        var identifyPayload = new
        {
            op = 2,
            d = new
            {
                token = Token,
                intents = (int)_intents,
                properties = new
                {
                    os = Environment.OSVersion.Platform.ToString(),
                    browser = "SharpCord",
                    device = "SharpCord"
                }
            }
        };

        var json = JsonSerializer.Serialize(identifyPayload);

        await socket.SendMessageAsync(json);
        
        Log.Info("Successfully Logged in.");
        Log.Info($"Found {CommandRegistry.SlashCommands.Count} application (/) commands.");

        await CommandRegistry.RegisterAllSlashCommandsAsync();
        await socket.ListenForEvents();
    }

    #region Private Methods
    internal static async Task<string> GetCurrentIdAsync(string token)
    {
        var response = await HttpHelper.SendRequestAsync("/users/@me", "GET");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Discord API returned error: {response.StatusCode}");
        }

        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);

        return doc.RootElement.GetProperty("id").GetString()!;
    }

    internal static string GetApplicationIdFromToken()
    {
        var parts = Token.Split('.');
        if (parts.Length < 3)
            throw new ArgumentException("Invalid bot token format.");

        var idBytes = Convert.FromBase64String(PadBase64(parts[0]));
        return Encoding.UTF8.GetString(idBytes);
    }

    internal static string PadBase64(string base64)
    {
        int padding = 4 - base64.Length % 4;
        return base64 + new string('=', padding % 4);
    }
    #endregion
}