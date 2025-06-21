namespace SharpCord.Models;

/// <summary>
/// Represents the type of event that can trigger an auto-moderation rule in a system.
/// See also: https://discord.com/developers/docs/resources/auto-moderation#auto-moderation-rule-object-event-types
/// </summary>
public enum AutoModerationRuleEventType
{
    /// <summary>
    /// Represents an event type triggered when a user sends a message.
    /// This event type is used for defining auto-moderation rules that
    /// react to messages sent in Discord.
    /// </summary>
    MessageSend = 1,

    /// <summary>
    /// Represents an event type triggered when a member's details are updated.
    /// This event type is used for defining auto-moderation rules that
    /// respond to changes in member information within Discord.
    /// </summary>
    MemberUpdate = 2
}