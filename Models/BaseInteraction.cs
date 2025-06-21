using System.Text.Json.Serialization;

namespace SharpCord.Models;

/// <summary>
/// 
/// </summary>
public class BaseInteraction
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;
    
    [JsonPropertyName("application_id")]
    public string ApplicationId { get; set; } = string.Empty;
    
    [JsonPropertyName("type")]
    public BaseInteractionType Type { get; set; }
    
    [JsonPropertyName("data")]
    public BaseInteractionData? Data { get; set; }
    
    [JsonPropertyName("guild_id")]
    public string? GuildId { get; set; }
    
    [JsonPropertyName("channel_id")]
    public string? ChannelId { get; set; }
    
    
}