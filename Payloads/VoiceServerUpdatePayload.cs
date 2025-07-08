using System.Text.Json.Serialization;
using SharpCord.Types;

namespace SharpCord.Payloads;

/// <summary>
/// 
/// </summary>
public class VoiceServerUpdatePayload
{
    [JsonPropertyName("token")]
    public string Token { get; set; } = string.Empty;
    
    [JsonPropertyName("guild_id")]
    public Snowflake GuildId { get; set; }
    
    [JsonPropertyName("endpoint")]
    public string Endpoint { get; set; } = string.Empty;
}