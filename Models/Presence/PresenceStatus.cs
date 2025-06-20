using System.Text.Json.Serialization;

namespace SharpCord.Models;

/// <summary>
/// Specifies the presence status of the Discord user.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PresenceStatus
{
    /// <summary>
    /// Represents the state where the user is active and connected.
    /// </summary>
    [JsonPropertyName("online")]
    Online,

    /// <summary>
    /// Represents the state where the user is connected but currently inactive or away.
    /// </summary>
    [JsonPropertyName("idle")]
    Idle,

    /// <summary>
    /// Represents the state where the user does not want to be disturbed.
    /// </summary>
    [JsonPropertyName("dnd")]
    Dnd,

    /// <summary>
    /// Represents the state where the user is not active or connected.
    /// </summary>
    [JsonPropertyName("offline")]
    Offline,

    /// <summary>
    /// Represents the state where the user is online but appears offline to others.
    /// </summary>
    [JsonPropertyName("invisible")]
    Invisible
}

/// <summary>
/// Provides a collection of string constants representing various Discord user presence statuses.
/// These statuses indicate the current availability or activity state of a user on the Discord platform.
/// </summary>
public static class PresenceStatuses
{
    /// <summary>
    /// Represents a constant string value "online" used to indicate an "Online" presence status for a Discord user.
    /// This status signifies that a user is currently active and available on the platform.
    /// </summary>
    public const string Online = "online";

    /// <summary>
    /// Represents a constant string value "idle" used to indicate an "Idle" presence status for a Discord user.
    /// This status signifies that a user is temporarily away or inactive on the platform.
    /// </summary>
    public const string Idle = "idle";

    /// <summary>
    /// Represents a constant string value "dnd" used to indicate a "Do Not Disturb" presence status for a Discord user.
    /// This status signifies that a user does not wish to be disturbed and disables notification alerts.
    /// </summary>
    public const string Dnd = "dnd";

    /// <summary>
    /// Represents a constant string value "offline" used to indicate an "Offline" presence status for a Discord user.
    /// This status signifies that a user is disconnected from Discord and appears offline to others.
    /// </summary>
    public const string Offline = "offline";

    /// <summary>
    /// Represents a constant string value "invisible" used to indicate an "Invisible" presence status for a Discord user.
    /// This status signifies that a user appears offline to others but can still use Discord and access its features.
    /// </summary>
    public const string Invisible = "invisible";

    /// <summary>
    /// Represents a constant string value "online" used to indicate an "Online" presence status for a Discord user.
    /// This status signifies that a user is currently active and available on Discord.
    /// </summary>
    public const string ONLINE = "online";

    /// <summary>
    /// Represents a constant string value "idle" used to indicate an "Idle" presence status for a Discord user.
    /// This status signifies that a user is away or inactive but still logged into Discord.
    /// </summary>
    public const string IDLE = "idle";

    /// <summary>
    /// Represents a constant string value "dnd" used to indicate a "Do Not Disturb" presence status for a Discord user.
    /// This status is used to signify that a user prefers not to be disturbed and may suppress push notifications.
    /// </summary>
    public const string DND = "dnd";

    /// <summary>
    /// Represents a constant string value "offline" used to indicate an offline presence status for a Discord user.
    /// This constant is used to signify that a user is not currently online and appears offline to others on Discord.
    /// </summary>
    public const string OFFLINE = "offline";

    /// <summary>
    /// Represents a constant string value "invisible" used to indicate an invisible presence status for a Discord user.
    /// This constant is typically used to signify that a user is invisible, appearing offline to others while still being active.
    /// </summary>
    public const string INVISIBLE = "invisible";
}