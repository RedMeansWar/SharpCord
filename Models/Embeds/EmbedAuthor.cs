using System.Text.Json.Serialization;

namespace SharpCord.Models;

/// <summary>
/// Represents the author of an embed object, providing display information such as the author's name,
/// an optional URL, and icon data for custom author representation.
/// </summary>
public class EmbedAuthor
{
    /// <summary>
    /// Gets or sets the name of the embed author.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the URL associated with the author.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Gets or sets the direct URL of the author's icon.
    /// </summary>
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; set; }

    /// <summary>
    /// Gets or sets the proxied URL for the author's icon.
    /// </summary>
    [JsonPropertyName("proxy_icon_url")]
    public string? ProxyIconUrl { get; set; }
}