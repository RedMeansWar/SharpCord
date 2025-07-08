using System.Text.Json.Serialization;

namespace SharpCord.Models;

/// <summary>
/// 
/// </summary>
public class BanInfo
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("user")] 
    public BaseUser User { get; set; } = default!;
}