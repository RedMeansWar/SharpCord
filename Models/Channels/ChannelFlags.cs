namespace SharpCord.Models;

/// <summary>
/// Defines a set of flags that represent various metadata or state indicators for a channel.
/// This enumeration is typically used to determine specific attributes or behaviors associated with a channel.
/// See also: https://discord.com/developers/docs/resources/channel#channel-object-channel-flags
/// </summary>
public enum ChannelFlags
{
    /// <summary>
    /// Indicates that the guild feed has been removed from the channel.
    /// This flag is used to represent the state where a guild's feed-related functionality
    /// is no longer active or applicable on the given channel.
    /// </summary>
    GuildFeedRemove = 1,

    /// <summary>
    /// Indicates that the channel has pinned messages.
    /// This flag is used to represent that the associated channel contains messages
    /// that have been marked as important or noteworthy by users.
    /// </summary>
    Pinned = 2,

    /// <summary>
    /// Indicates that active channels have been removed.
    /// This flag represents the state where previously active or accessible channels
    /// are no longer available or operational.
    /// </summary>
    ActiveChannelsRemoved = 4,

    /// <summary>
    /// Indicates that a tag is required for interactions within the channel.
    /// This flag enforces the use of specific tags to categorize or identify
    /// certain activities or messages in the channel.
    /// </summary>
    RequireTag = 16,

    /// <summary>
    /// Indicates that the channel is flagged as spam.
    /// This flag is used to mark channels that have been identified to contain
    /// content or behavior violating spam policies.
    /// </summary>
    IsSpam = 32,

    /// <summary>
    /// Indicates that the channel is a guild resource channel.
    /// This flag specifies that the channel is associated with guild resource-related functionality,
    /// providing dedicated features or behaviors for resource management within the guild.
    /// </summary>
    IsGuildResourceChannel = 128,

    /// <summary>
    /// Indicates that the channel is associated with ClydeAI-specific functionality or features.
    /// This flag designates channels that are identified as being connected to AI-driven interactions
    /// or services provided through ClydeAI within the application.
    /// </summary>
    ClydeAI = 256,

    /// <summary>
    /// Indicates that the channel is scheduled for deletion.
    /// This flag is used to mark a channel that is pending removal and may not be usable or visible after a certain period.
    /// </summary>
    IsScheduledForDeletion = 512,

    /// <summary>
    /// Represents a flag indicating that the channel has media download options hidden.
    /// This flag is used to signify that certain media-related download settings or options
    /// are not visible or accessible within the channel.
    /// </summary>
    HideMediaDownloadOptions = 32768
}