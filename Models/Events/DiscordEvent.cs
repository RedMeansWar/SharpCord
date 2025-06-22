namespace SharpCord.Models;

/// <summary>
/// Represents various events in Discord that can be triggered and handled within a connected bot or application.
/// </summary>
/// <remarks>
/// This enum encapsulates all noteworthy events occurring within the Discord environment, such as actions related to channels, guilds, members, interactions, and more.
/// Each event corresponds to specific activities or changes, enabling event-driven programming and facilitating interaction with Discord's API.
/// </remarks>
public enum DiscordEvents
{
    ApplicationCommandPermissionsUpdate,
    AutoModerationActionExecution,
    AutoModerationRuleCreate,
    AutoModerationRuleDelete,
    AutoModerationRuleUpdate,
    CacheSweep,
    ChannelCreate,
    ChannelDelete,
    ChannelPinsUpdate,
    ChannelUpdate,
    Debug,
    EmojiCreate,
    EmojiDelete,
    EmojiUpdate,
    EntitlementCreate,
    EntitlementDelete,
    EntitlementUpdate,
    Error,
    GuildAuditLogEntryCreate,
    GuildAvailable,
    GuildBanAdd,
    GuildBanRemove,
    GuildCreate,
    GuildDelete,
    GuildIntegrationsUpdate,
    GuildMemberAdd,
    GuildMemberAvailable,
    GuildMemberRemove,
    GuildMembersChunk,
    GuildMemberUpdate,
    GuildScheduledEventCreate,
    GuildScheduledEventDelete,
    GuildScheduledEventUpdate,
    GuildScheduledEventUserAdd,
    GuildScheduledEventUserRemove,
    GuildSoundboardSoundCreate,
    GuildSoundboardSoundDelete,
    GuildSoundboardSoundUpdate,
    GuildUnavailable,
    GuildUpdate,
    InteractionCreate,
    Invalidated,
    InviteCreate,
    InviteDelete,
    MessageCreate,
    MessageDelete,
    MessageDeleteBulk,
    MessagePollVoteAdd,
    MessagePollVoteRemove,
    MessageReactionAdd,
    MessageReactionRemove,
    MessageReactionRemoveAll,
    MessageReactionRemoveEmoji,
    MessageUpdate,
    PresenceUpdate,
    Ready,
    RoleCreate,
    RoleDelete,
    RoleUpdate,
    ShardDisconnect,
    ShardError,
    ShardReady,
    ShardReconnecting,
    ShardResume,
    SoundboardSounds,
    StageInstanceCreate,
    StageInstanceDelete,
    StageInstanceUpdate,
    StickerCreate,
    StickerDelete,
    StickerUpdate,
    SubscriptionCreate,
    SubscriptionDelete,
    SubscriptionUpdate,
    ThreadCreate,
    ThreadDelete,
    ThreadListSync,
    ThreadMembersUpdate,
    ThreadMemberUpdate,
    ThreadUpdate,
    TypingStart,

    /// <summary>
    /// Represents an event triggered when a user's account information is updated.
    /// </summary>
    /// <remarks>
    /// This event occurs when changes are made to a user's details, such as their username, avatar, or other account-related attributes.
    /// Applications monitoring this event can use it to respond to updates concerning user modifications in real-time.
    /// </remarks>
    UserUpdate,

    /// <summary>
    /// Represents an event triggered when an audio effect is sent to a user participating in a voice channel.
    /// </summary>
    /// <remarks>
    /// This event is typically invoked to indicate the transmission of specific voice effects or enhancements
    /// applied within a voice channel, often involving external soundboard features or audio modifications.
    /// </remarks>
    VoiceChannelEffectSend,

    /// <summary>
    /// Represents an event that triggers when a user's voice state is updated within a guild.
    /// </summary>
    /// <remarks>
    /// This event is typically invoked when changes occur in a user's voice connection such as joining, leaving, or switching voice channels, muting, deafening, or updating other voice-related states.
    /// </remarks>
    VoiceStateUpdate,

    /// <summary>
    /// Represents an event that provides warnings or alerts regarding specific occurrences or issues.
    /// </summary>
    /// <remarks>
    /// This event is typically used for issuing non-critical warnings to notify users or developers about potential issues or noteworthy situations that require attention.
    /// </remarks>
    Warn,

    /// <summary>
    /// Represents an event triggered when one or more webhooks in a Discord guild are updated.
    /// </summary>
    /// <remarks>
    /// This event provides information regarding updates to webhooks, such as configuration or metadata changes.
    /// </remarks>
    WebhooksUpdate,

    /// <summary>
    /// Represents an event triggered when a webhook in a Discord guild is updated.
    /// </summary>
    /// <remarks>
    /// This event provides information about changes to a webhook, such as updates to its configuration
    /// or metadata. This event is deprecated and the <c>WebhookUpdate</c> event should be used instead.
    /// </remarks>
    [Obsolete("This event is deprecated, use WebhooksUpdate instead.")]
    WebhookUpdate
}