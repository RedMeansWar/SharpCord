namespace SharpCord.Models;

/// <summary>
/// Represents various types of activities that a user can be engaged in.
/// </summary>
public enum ActivityType
{
    /// <summary>
    /// Represents the activity type where the user is engaged in playing a game or interactive activity.
    /// </summary>
    Playing,

    /// <summary>
    /// Represents the activity type where the user is streaming content, such as a live broadcast or video stream.
    /// </summary>
    Streaming,

    /// <summary>
    /// Represents the activity type where the user is listening to something, such as music or a podcast.
    /// </summary>
    Listening,

    /// <summary>
    /// Represents the activity type where the user is watching something, such as a video or stream.
    /// </summary>
    Watching,

    /// <summary>
    /// Represents a custom activity type, which allows users to define their own unique activity.
    /// </summary>
    Custom,

    /// <summary>
    /// Represents the "Competing" activity type, which indicates that a user is engaged in a competitive activity.
    /// </summary>
    Competing
}