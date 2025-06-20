namespace SharpCord.Models;

/// <summary>
/// Defines the various flags that can be associated with an activity to indicate its properties or behaviors.
/// </summary>
public enum ActivityFlags
{
    /// <summary>
    /// Denotes that the activity is embedded as part of the application interface.
    /// Typically used to reflect activities that are directly integrated into
    /// the core structure or functionality of the application.
    /// </summary>
    Embedded = 256,

    /// <summary>
    /// Signifies that the activity represents a specific instance or occurrence of
    /// the activity within the application. Often used to distinguish individual
    /// runtime instances of an activity.
    /// </summary>
    Instance = 1,

    /// <summary>
    /// Represents a flag indicating that the activity supports joining.
    /// Typically used to denote that users can join the activity directly,
    /// such as through an invite or a shared link.
    /// </summary>
    Join = 2,

    /// <summary>
    /// Indicates that the activity supports join requests, allowing users
    /// to request to join an ongoing activity. Typically used to manage
    /// access control for participation in shared activities.
    /// </summary>
    JoinRequest = 8,

    /// <summary>
    /// Indicates that the activity is visible to friends within the party settings.
    /// This flag allows friends to join or interact with the activity
    /// based on established privacy rules and connections.
    /// </summary>
    PartyPrivacyFriends = 64,

    /// <summary>
    /// Indicates that the activity is linked to a party within a voice channel.
    /// Commonly used to signify activities that are associated with real-time communication
    /// or social interaction in a shared audio environment.
    /// </summary>
    PartyPrivacyVoiceChannel = 128,

    /// <summary>
    /// Indicates that the activity involves gameplay interaction.
    /// This flag is used to signify that the associated activity
    /// pertains to playing a game or a related activity mode.
    /// </summary>
    Play = 32,

    /// <summary>
    /// Signifies that the activity allows spectators to observe or watch the ongoing session.
    /// Typically used to indicate that users can spectate the activity without direct participation.
    /// </summary>
    Spectate = 4,

    /// <summary>
    /// Indicates that the activity is synchronized with other components
    /// or systems. Commonly used to represent activities that require
    /// consistency across multiple instances or platforms.
    /// </summary>
    Sync = 16,
}