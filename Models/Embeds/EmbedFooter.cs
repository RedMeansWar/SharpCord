using System.Text.Json.Serialization;

namespace SharpCord.Models;

/// <summary>
/// Represents the footer of an embed, allowing you to specify additional
/// information such as text and optional icons.
/// </summary>
public class EmbedFooter
{
    /// <summary>
    /// Gets or sets the footer text of the embed.
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the URL of the icon displayed in the footer of the embed.
    /// </summary>
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; set; }

    /// <summary>
    /// Gets or sets the proxied URL of the embed footer's icon.
    /// </summary>
    [JsonPropertyName("proxy_icon_url")]
    public string? ProxyIconUrl { get; set;}
}