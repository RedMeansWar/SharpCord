namespace SharpCord.Models;

/// <summary>
/// Represents a communication channel within a guild or independent of it.
/// Channels can be of different types such as text or voice.
/// </summary>
public class Channel
{
    /// <summary>
    /// Gets or sets the unique identifier of the channel.
    /// This property serves as a primary identifier for the channel within the system.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the unique identifier of the guild to which the channel belongs.
    /// This property is used to associate the channel with its respective guild structure.
    /// </summary>
    public string? GuildId { get; set; }

    /// <summary>
    /// Gets or sets the type of the channel. This property indicates the functional
    /// category of the channel, such as text or voice, represented by specific numeric values.
    /// </summary>
    public int Type { get; set; } // 0 = text, 2 = voice, etc

    /// <summary>
    /// Gets or sets the name of the channel. This property represents
    /// the display name used to identify the channel within the context
    /// of its parent guild or system.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the position of the channel within its parent structure, such as
    /// a category or channel list. This property determines the visual and logical
    /// order of the channel relative to others within the same grouping.
    /// </summary>
    public int? Position { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the channel is marked as
    /// Not Safe For Work (NSFW).
    /// This property is used to signify that the channel contains content
    /// intended for mature audiences.
    /// </summary>
    public bool? Nsfw { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the parent channel, if applicable.
    /// This property represents the ID of the parent category or channel
    /// to which the current channel is linked.
    /// </summary>
    public int? ParentId { get; set; }
}