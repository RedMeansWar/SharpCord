namespace SharpCord.Models;

/// <summary>
/// Defines the various types of triggers for auto-moderation rules.
/// These triggers determine the conditions under which an auto-moderation rule is activated.
/// </summary>
public enum AutoModerationRuleTriggerType
{
    /// <summary>
    /// Represents a trigger type for an auto-moderation rule based on specific keywords.
    /// This trigger activates when a message contains specified keywords.
    /// <remarks>Check if content contains words from a user-defined list of keywords (Maximum of 6 per guild)</remarks>
    /// </summary>
    Keyword = 1,

    /// <summary>
    /// Represents a trigger type for an auto-moderation rule that detects spam.
    /// This trigger activates when a message is identified as spam based on predefined moderation criteria.
    /// <remarks>Check if content represents generic spam (Maximum of 1 per guild)</remarks>
    /// </summary>
    Spam = 3,

    /// <summary>
    /// Represents a trigger type for an auto-moderation rule that uses predefined sets of keywords.
    /// This trigger activates when a message matches conditions defined by these preset keyword sets.
    /// <remarks>Check if content contains words from internal pre-defined wordsets (Maximum of 1 per guild)</remarks>
    /// </summary>
    KeywordPreset = 4,

    /// <summary>
    /// Represents a trigger type for an auto-moderation rule that targets excessive mentions in a message.
    /// This trigger activates when a message includes a high number of users, role, or everyone mentions that are considered spam.
    /// <remarks>Check if content contains more mentions than allowed (Maximum of 1 per guild)</remarks>
    /// </summary>
    MentionSpam = 5,

    /// <summary>
    /// Represents a trigger type for an auto-moderation rule based on the profile of a member.
    /// This trigger activates when specific conditions related to a member's profile are met.
    /// <remarks>Check if a member profile contains words from a user-defined list of keywords (Maximum of 1 per guild)</remarks>
    /// </summary>
    MemberProfile = 6
}