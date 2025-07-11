﻿using System.Net;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using SharpCord.Models;
using SharpCord.Registry;
using SharpCord.Utils;

namespace SharpCord;

/// <summary>
/// Represents a client for connecting to the Discord API.
/// Provides mechanisms to authenticate and interact with Discord servers and users.
/// </summary>
public class DiscordClient
{
    internal readonly GatewayIntent _intents;
    internal ClientWebSocket _socket;

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
    /// A string containing the unique identifier of the Discord bot application. This value is
    /// assigned once the authentication process successfully establishes a connection to the Discord API.
    /// </value>
    public static string Id { get; private set; } = string.Empty;

    /// <summary>
    /// Represents a client for connecting to the Discord Gateway API, allowing interaction
    /// with Discord's services such as sending messages and listening to events.
    /// </summary>
    public DiscordClient(string token, GatewayIntent intents = GatewayIntent.All)
    {
        Token = token;
        _intents = intents;
        _socket = new();
    }

    /// <summary>
    /// Authenticates the client and connects it to the Discord Gateway API.
    /// Establishes a WebSocket connection, identifies the bot, and begins listening
    /// for incoming events from Discord.
    /// </summary>
    /// <returns>Returns a task representing the asynchronous login operation.</returns>
    public async Task LoginAsync()
    {
        var gatewayUrl = "wss://gateway.discord.gg/?v=10&encoding=json";

        Id = await GetCurrentIdAsync(Token);
        await _socket.ConnectAsync(new Uri(gatewayUrl), CancellationToken.None);

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
        var bytes = Encoding.UTF8.GetBytes(json);
        
        await _socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
        Log.Info("Successfully logging in.");

        await ListenForEvents();
    }

    private async Task ListenForEvents()
    {
        var buffer = new byte[1024];
        var messageBuffer = new StringBuilder();

        while (_socket.State == WebSocketState.Open)
        {
            var result = await _socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            // Check if we are receiving a text message
            if (result.MessageType != WebSocketMessageType.Text) continue;
            
            // Append the received data to the message buffer
            messageBuffer.Append(Encoding.UTF8.GetString(buffer, 0, result.Count));

            // Check if we have received the full message
            if (!result.EndOfMessage) continue;
                
            try
            {
                // Now that we have the full message, parse it as JSON
                var message = messageBuffer.ToString();
                var json = JsonDocument.Parse(message);

                // Process the event
                var opCode = json.RootElement.GetProperty("op").GetInt32();
                var eventName = json.RootElement.GetProperty("t").GetString();
                var payload = json.RootElement.GetProperty("d");

                // Log the event name and payload (for debugging)
                if (string.IsNullOrEmpty(eventName))
                    Console.WriteLine("");
                else
                    Log.Info($"Received event: {eventName} @ {DateTime.UtcNow}");

                if (eventName == "INTERACTION_CREATE")
                {
                    await EventRegistry.DispatchAsync(eventName, payload);
                }

                messageBuffer.Clear();
            }
            catch (JsonException ex)
            {
                Log.Error($"Error parsing JSON: {ex.Message}");
            }
        }
    }

    internal static async Task<string> GetCurrentIdAsync(string token)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bot", token);

        var response = await client.GetAsync("https://discord.com/api/v10/users/@me");

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
}