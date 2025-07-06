using System.Text.Json.Serialization;
using SharpCord.Types;

namespace SharpCord.Payloads;

/// <summary>
/// 
/// </summary>
public class VoiceStateUpdatePayload
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("guild_id")]
    public Snowflake GuildId { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("channel_id")]
    public Snowflake? ChannelId { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("self_mute")]
    public bool SelfMute { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("self_deaf")]
    public bool SelfDeaf { get; set; }
}