using System.Text.Json.Serialization;

namespace SharpCord.Models;

/// <summary>
/// Represents an embed object commonly used in rich media messages or content.
/// </summary>
public class Embed
{
    /// Gets or sets the title of the embed.
    /// Represents the main title section of the embed, commonly used as the primary heading or descriptor.
    /// This property is optional and may be null if a title is not provided.
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// Gets or sets the description of the embed.
    /// Represents the main body text or content section of the embed.
    /// This property provides additional context or details associated with the embed.
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// Gets or sets the URL of the embed.
    /// Represents a hyperlink associated with the embed, typically pointing to a relevant resource or web page.
    /// This property is optional and can be omitted if no URL is needed for the embed.
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// Gets or sets the color of the embed.
    /// Represents the color of the embed as an integer value, which is usually used to define the embed's visual accent or theme.
    /// This property is optional and can be omitted if a specific embed color is not required.
    [JsonPropertyName("color")]
    public int? Color { get; set; }

    /// Gets or sets the timestamp of the embed.
    /// Represents a point in time associated with the embed message, typically used to indicate when the message or event occurred.
    /// This property is optional and can be omitted if a timestamp is not required.
    [JsonPropertyName("timestamp")]
    public DateTimeOffset? Timestamp { get; set; }

    /// Gets or sets the footer of the embed.
    /// Represents additional information displayed at the bottom of the embed.
    /// This property is optional and may be null if no footer information is provided.
    [JsonPropertyName("footer")]
    public EmbedFooter? Footer { get; set; }

    /// Gets or sets the image of the embed.
    /// Represents an optional media object, typically used to display visual content
    /// as part of the embed. This property may contain metadata for images such as URLs
    /// and dimensions or be null if no image is provided.
    [JsonPropertyName("image")]
    public EmbedMedia? Image { get; set; }

    /// Gets or sets the thumbnail of the embed.
    /// Represents a media object containing data for the thumbnail associated with the embed.
    /// Commonly used to provide a smaller associated image for the embed message.
    [JsonPropertyName("thumbnail")]
    public EmbedMedia? Thumbnail { get; set; }

    /// Gets or sets the video associated with the embed.
    /// Represents a video element that can be displayed within the embed, often associated with multimedia content.
    /// This property is optional and may be null if no video is provided.
    [JsonPropertyName("video")]
    public EmbedMedia? Video { get; set; }

    /// Gets or sets the provider information of the embed.
    /// Represents the source or origin associated with the embed, often used to display attribution or contextual details.
    /// This property is optional and may be null if no provider details are specified.
    [JsonPropertyName("provider")]
    public EmbedProvider? Provider { get; set; }

    /// Gets or sets the author of the embed.
    /// Represents the author section of the embed, typically used to include attribution or contextual details.
    /// This property is optional and may be null if an author is not specified.
    [JsonPropertyName("author")]
    public EmbedAuthor? Author { get; set; }

    /// Gets or sets the list of fields for the embed.
    /// Represents a collection of additional information or data points displayed within the embed.
    /// Each field consists of a name, value, and an optional inline property.
    /// This property is optional and may be null if no fields are provided.
    [JsonPropertyName("fields")]
    public List<EmbedField>? Fields { get; set; }
}