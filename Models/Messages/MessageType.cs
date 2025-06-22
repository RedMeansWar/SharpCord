namespace SharpCord.Models;

/// <summary>
/// Enumerates the types of messages that can occur within the system,
/// defining various behaviors or contextual metadata assigned to messages.
/// Each value represents a specific kind of system or user-generated event.
/// </summary>
public enum MessageType
{
    /// <summary>
    /// Represents the default message flag with no additional behavior or metadata applied.
    /// This flag indicates the absence of any special state or context for the message.
    /// </summary>
    Default = 0,

    /// <summary>
    /// Represents a message flag indicating that a recipient has been added.
    /// This flag is typically used to denote the addition of a new user to a group
    /// or a similar action involving recipient inclusion.
    /// </summary>
    RecipientAdd = 1,

    /// <summary>
    /// Denotes the removal of a recipient from a group message.
    /// This flag indicates that a user has been removed from the message recipient list.
    /// </summary>
    RecipientRemove = 2,

    /// <summary>
    /// Represents a message flag that indicates the associated message is related to a voice or video call activity.
    /// This flag is used to signify messages generated as part of initiating, maintaining, or ending calls.
    /// </summary>
    Call = 3,

    /// <summary>
    /// Represents a message flag indicating that the channel's name has been changed.
    /// This flag is used to denote metadata or an event associated with a channel name update.
    /// </summary>
    ChannelNameChange = 4,

    /// <summary>
    /// Indicates a change to the icon of the channel. This flag is used to represent
    /// messages that inform about updates to the channel's visual representation.
    /// </summary>
    ChannelIconChange = 5,

    /// <summary>
    /// Indicates that a message has been pinned in a channel.
    /// This flag signifies the message's elevated importance or relevance within the channel.
    /// </summary>
    ChannelPinnedMessage = 6,

    /// <summary>
    /// Represents a message flag that indicates a user has joined.
    /// This flag is used to identify events or messages related to user join activities.
    /// </summary>
    UserJoin = 7,

    /// <summary>
    /// Indicates that the message is related to a guild boost action, such as a user boosting a guild.
    /// This flag provides context about actions tied to guild enhancements.
    /// </summary>
    GuildBoost = 8,

    /// <summary>
    /// Represents a message flag indicating the achievement of Guild Boost Tier 1.
    /// This flag signifies that the guild has reached the first level of server boosting benefits.
    /// </summary>
    GuildBoostTier1 = 9,

    /// <summary>
    /// Represents the message flag indicating that a guild has reached Boost Tier 2 level.
    /// This flag is used to signify an upgrade in the guild's boost tier, unlocking additional features for the guild.
    /// </summary>
    GuildBoostTier2 = 10,

    /// <summary>
    /// Represents a message flag indicating the guild has achieved Tier 3 boost level.
    /// This flag is typically associated with notifications or events triggered by reaching the highest boost tier.
    /// </summary>
    GuildBoostTier3 = 11,

    /// <summary>
    /// Represents a message flag associated with a disqualification from Discord's Guild Discovery.
    /// This flag indicates that the guild no longer meets the criteria for participating in the discovery program.
    /// </summary>
    GuildDiscoveryDisqualified = 14,

    /// <summary>
    /// Represents the message flag indicating that a guild has requalified for Discovery.
    /// This flag is used to signify that the guild has met the necessary requirements
    /// to regain Discovery status after being previously disqualified.
    /// </summary>
    GuildDiscoveryRequalified = 15,

    /// <summary>
    /// Represents an initial warning state for a guild in the discovery grace period.
    /// This flag signifies a notification to the guild about potential disqualification from server discovery
    /// if the necessary adjustments or improvements are not made.
    /// </summary>
    GuildDiscoveryGracePeriodInitialWarning = 16,

    /// <summary>
    /// Indicates the final warning issued during the guild discovery grace period.
    /// This flag is used to denote messages specifically tied to the last notification
    /// before a guild is removed from the discovery listing.
    /// </summary>
    GuildDiscoveryGracePeriodFinalWarning = 17,

    /// <summary>
    /// Represents a message flag that indicates a thread was created.
    /// This flag is used to signify messages that are associated with the creation of a new thread.
    /// </summary>
    ThreadCreated = 18,

    /// <summary>
    /// Represents a message flag indicating that a given message is a reply to another message.
    /// This flag is used to denote contextual relationships between messages in a thread or channel.
    /// </summary>
    Reply = 19,

    /// <summary>
    /// Represents a message flag indicating the execution of a chat input command.
    /// This flag identifies messages associated with interactions triggered
    /// by user-initiated commands within the chat interface.
    /// </summary>
    ChatInputCommand = 20,

    /// <summary>
    /// Indicates the message that initiates a thread. This flag is used to mark the original
    /// message associated with the creation of a thread, providing context and linkage between
    /// the thread and its starting point.
    /// </summary>
    ThreadStarterMessage = 21,

    /// <summary>
    /// Indicates a reminder to invite users to a guild.
    /// This flag is typically used to prompt members or administrators
    /// to share guild invitations and increase membership within the community.
    /// </summary>
    GuildInviteReminder = 22,

    /// <summary>
    /// Represents a message flag indicating the execution of a context menu command.
    /// This flag is used to denote interactions initiated through a context menu within the message context.
    /// </summary>
    ContextMenuCommand = 23,

    /// <summary>
    /// Represents an automated moderation action within a channel or guild,
    /// typically triggered by predefined rules to enforce community guidelines
    /// or server-specific moderation policies.
    /// </summary>
    AutoModerationAction = 24,

    /// <summary>
    /// Represents a message type indicating a role subscription purchase.
    /// This message type is used to signify when a user has purchased a role subscription.
    /// </summary>
    RoleSubscriptionPurchase = 25,

    /// <summary>
    /// Indicates a message related to an interaction premium upsell.
    /// This type is used to represent prompts or notifications suggesting premium features
    /// within a user interaction context.
    /// </summary>
    InteractionPremiumUpsell = 26,

    /// <summary>
    /// Indicates the starting of a stage event within a communication platform.
    /// This message type is used to signify the initiation of a real-time stage interaction
    /// where participants can join and engage in discussions.
    /// </summary>
    StageStart = 27,

    /// <summary>
    /// Represents the conclusion of a stage event within a server's stage channel.
    /// This type signifies the end of a structured, broadcast-style conversation or presentation.
    /// </summary>
    StageEnd = 28,

    /// <summary>
    /// Represents an event where a user is designated as a speaker on a stage channel.
    /// This message type signifies a role change- or interaction-specific to stage channels in Discord.
    /// </summary>
    StageSpeaker = 29,

    /// <summary>
    /// Represents the "raise hand" state in a Stage channel interaction.
    /// This flag is used to indicate that a user has raised their hand in a live Stage event,
    /// typically signaling a request to speak or participate.
    /// <remarks>https://github.com/discord/discord-api-docs/pull/5927#discussion_r1107678548</remarks>
    /// </summary>
    StageRaiseHand = 30,

    /// <summary>
    /// Represents a message type that conveys a change or update to the topic of a Stage channel.
    /// This message indicates that the content or subject of the Stage is being modified or announced.
    /// </summary>
    StageTopic = 31,

    /// <summary>
    /// Represents a message type associated with a premium subscription within a guild application.
    /// This message type typically indicates a premium-related action or status relevant to the guild's application context.
    /// </summary>
    GuildApplicationPremiumSubscription = 32,
}