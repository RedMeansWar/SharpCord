using SharpCord.Types;

namespace SharpCord.Models;

/// <summary>
/// Represents the assets of a rich presence activity in Discord.
/// </summary>
/// <remarks>
/// This class encapsulates visual assets related to a user's rich presence activity,
/// including large and small images and their associated text descriptions.
/// </remarks>
public class RichPresenseAssets
{
    /// <summary>
    /// Gets or sets the activity associated with the rich presence assets.
    /// </summary>
    /// <remarks>
    /// This property represents the activity instance linked to the rich presence assets. It provides details
    /// about what the user is currently doing, such as playing a game, listening to music, or engaging in any
    /// activity tracked by Discord.
    /// </remarks>
    public Activity Activity { get; set; }

    /// <summary>
    /// Gets or sets the identifier for the large image associated with the rich presence assets.
    /// </summary>
    /// <remarks>
    /// This property represents the unique Snowflake identifier for the large image displayed in a user's
    /// rich presence activity. It allows Discord to retrieve and display the relevant image resource.
    /// </remarks>
    public Snowflake? LargeImage { get; set; }

    /// <summary>
    /// Gets or sets the text description associated with the large image in the rich presence assets.
    /// </summary>
    /// <remarks>
    /// This property represents the text displayed when a user hovers over the large image in the rich presence overlay.
    /// It often provides additional context or descriptive information about the activity or image.
    /// </remarks>
    public string? LargeText { get; set; }

    /// <summary>
    /// Gets or sets the small image associated with the rich presence assets.
    /// </summary>
    /// <remarks>
    /// This property represents the small image used in the rich presence UI, typically displayed alongside the user's status or activity.
    /// It provides a visual cue or additional context about the current activity, such as a game icon or related content.
    /// </remarks>
    public Snowflake? SmallImage { get; set; }

    /// <summary>
    /// Gets or sets the small text description associated with the rich presence small image.
    /// </summary>
    /// <remarks>
    /// This property provides a textual description that appears alongside the small image in the rich presence display,
    /// offering additional context or information about the user's current activity.
    /// </remarks>
    public string? SmallText { get; set; }
}