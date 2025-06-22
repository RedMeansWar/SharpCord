using System.Net;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using SharpCord.Models;
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
    /// The token used for authenticating the Discord client with the Discord API.
    /// </summary>
    public static string Token { get; private set; } = string.Empty;

    /// <summary>
    /// The unique identifier for the Discord client, derived from the application's token.
    /// </summary>
    public static string Id { get; private set; } = string.Empty;

    /// <summary>
    /// Provides functionality to interact with the Discord API via a WebSocket connection.
    /// Enables developers to manage and communicate with Discord servers and users in real-time.
    /// </summary>
    public DiscordClient(string token, GatewayIntent intents = GatewayIntent.All)
    {
        Token = token;
        _intents = intents;
        _socket = new();
    }
    
    /// <summary>
    /// Asynchronously logs the client into the Discord API by establishing a WebSocket connection
    /// and sending the appropriate identification payload, allowing interaction with Discord's gateway.
    /// </summary>
    /// <returns>
    /// A task representing the asynchronous login operation.
    /// </returns>
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
    }

    /// <summary>
    /// Authenticates and establishes a WebSocket connection to the Discord API, identifying the client with the provided token.
    /// </summary>
    /// <param name="token">The authentication token used to identify the client with the Discord API.</param>
    /// <returns>A task that represents the asynchronous login operation.</returns>
    public async Task LoginAsync(string token)
    {
        var gatewayUrl = "wss://gateway.discord.gg/?v=10&encoding=json";
        
        await _socket.ConnectAsync(new Uri(gatewayUrl), CancellationToken.None);

        var identifyPayload = new
        {
            op = 2,
            d = new
            {
                token = token,
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
    }

    /// <summary>
    /// Retrieves the current user's ID from the Discord API.
    /// </summary>
    /// <returns>The user ID of the currently authenticated Discord user.</returns>
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