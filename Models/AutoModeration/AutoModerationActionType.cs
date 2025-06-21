namespace SharpCord.Models;

/// <summary>
/// Defines the types of actions that can be taken automatically in response to moderation triggers.
/// These actions are used to enforce server rules and maintain compliance with community guidelines.
/// See also: https://discord.com/developers/docs/resources/auto-moderation#auto-moderation-action-object-action-types
/// </summary>
public enum AutoModerationActionType
{
    /// <summary>
    /// Represents an action type in auto-moderation where a message is blocked from being posted.
    /// This action is commonly used to prevent rule-violating content from being displayed in the channel.
    /// </summary>
    BlockMessage = 1,

    /// <summary>
    /// Represents an action type in auto-moderation where an alert message is sent to a specified channel.
    /// This action is typically used to notify moderators or a specific audience
    /// about the details of a detected rule violation or event.
    /// </summary>
    SendAlertMessage = 2,

    /// <summary>
    /// Represents an action type in auto-moderation where a user is temporarily restricted from interacting.
    /// This action is typically used to enforce time-bound restrictions for violating specific rules or guidelines.
    /// </summary>
    Timeout = 3,

    /// <summary>
    /// Represents an action type in auto-moderation where interactions initiated by a member are blocked.
    /// This is typically used to restrict specific members from interacting with others or performing certain actions.
    /// </summary>
    BlockMemberInteraction = 4
}