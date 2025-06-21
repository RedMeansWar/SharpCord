using System.Text.Json.Serialization;

namespace SharpCord.Models;

/// <summary>
/// Represents media content within an embed object, such as images, thumbnails, and videos.
/// </summary>
public class EmbedMedia
{
    /// <summary>
    /// Gets or sets the direct URL for the embed media. This URL points to the source location of the media content.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Gets or sets the proxied URL for the embed media. This value provides an alternative URL, which may be used for bypassing restrictions or improving accessibility.
    /// </summary>
    [JsonPropertyName("proxy_url")]
    public string? ProxyUrl { get; set; }

    /// <summary>
    /// Gets or sets the height of the embed media. This value is optional and represents the height dimension in pixels.
    /// </summary>
    [JsonPropertyName("height")]
    public int? Height { get; set; }

    /// <summary>
    /// Gets or sets the width of the embed media. This value is optional and represents the width dimension in pixels.
    /// </summary>
    [JsonPropertyName("width")]
    public int? Width { get; set; }
}