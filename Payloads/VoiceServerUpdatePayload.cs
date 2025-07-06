using System.Text.Json.Serialization;
using SharpCord.Types;

namespace SharpCord.Payloads;

/// <summary>
/// 
/// </summary>
public class VoiceServerUpdatePayload
{
    [JsonPropertyName("")]
    public string Token { get; set; } = string.Empty;
    
    [JsonPropertyName("")]
    public Snowflake GuildId { get; set; }
    
    [JsonPropertyName("")]
    public string Endpoint { get; set; } = string.Empty;
}