namespace SharpCord.Models;

/// <summary>
/// Represents the types of mentions that can be included in a message.
/// </summary>
public static class MessageMentionTypes
{
    /// <summary>
    /// Represents a constant value used to indicate mentions for roles in the context of messages.
    /// </summary>
    public const string Roles = "roles";

    /// <summary>
    /// Represents a constant value used to indicate mentions for users in the context of messages.
    /// </summary>
    public const string Users = "users";

    /// <summary>
    /// Represents a constant value used to indicate mentions for everyone in the context of messages.
    /// </summary>
    public const string Everyone = "everyone";
}