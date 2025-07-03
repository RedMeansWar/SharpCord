#region LICENSE
// Copyright (c) 2025 RedMeansWar
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

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
    /// <summary>
    /// Represents an event triggered when the permissions for an application command are updated.
    /// </summary>
    ApplicationCommandPermissionsUpdate,

    /// <summary>
    /// Represents an event triggered when an action is executed by an auto-moderation rule in a Discord server.
    /// </summary>
    AutoModerationActionExecution,

    /// <summary>
    /// Represents an event triggered when a new auto-moderation rule is created in a Discord guild.
    /// </summary>
    AutoModerationRuleCreate,

    /// <summary>
    /// Represents an event triggered when an auto-moderation rule is deleted in the guild.
    /// </summary>
    AutoModerationRuleDelete,

    /// <summary>
    /// Represents an event triggered when an auto moderation rule is updated.
    /// </summary>
    AutoModerationRuleUpdate,

    /// <summary>
    /// Represents an event triggered when the cache is swept to free up memory or remove stale data.
    /// </summary>
    CacheSweep,

    /// <summary>
    /// Represents an event triggered when a new channel is created in a guild.
    /// </summary>
    ChannelCreate,

    /// <summary>
    /// Represents an event triggered when a channel is deleted in a guild.
    /// </summary>
    ChannelDelete,

    /// <summary>
    /// Represents an event triggered when a channel's pins are updated.
    /// </summary>
    ChannelPinsUpdate,

    /// <summary>
    /// Represents an event triggered when a channel is updated.
    /// </summary>
    ChannelUpdate,

    /// <summary>
    /// Represents an event used for logging or debugging purposes during application behavior analysis.
    /// </summary>
    Debug,

    /// <summary>
    /// Represents an event triggered when a new emoji is created in a Discord guild.
    /// </summary>
    EmojiCreate,

    /// <summary>
    /// Represents an event triggered when an emoji is deleted from a guild.
    /// </summary>
    EmojiDelete,

    /// <summary>
    /// Represents an event triggered when an emoji in a Discord guild is updated.
    /// </summary>
    EmojiUpdate,

    /// <summary>
    /// Represents an event triggered when a new entitlement is created.
    /// </summary>
    EntitlementCreate,

    /// <summary>
    /// Represents an event triggered when an entitlement is deleted.
    /// </summary>
    EntitlementDelete,

    /// <summary>
    /// Represents an event triggered when an entitlement is updated.
    /// </summary>
    EntitlementUpdate,

    /// <summary>
    /// Represents an event triggered when an error occurs within the application.
    /// </summary>
    Error,

    /// <summary>
    /// Represents an event triggered when a new entry is added to a guild's audit log.
    /// </summary>
    GuildAuditLogEntryCreate,

    /// <summary>
    /// Represents an event triggered when a guild becomes available to the client.
    /// </summary>
    GuildAvailable,

    /// <summary>
    /// Represents an event triggered when a user is banned from a guild.
    /// </summary>
    GuildBanAdd,

    /// <summary>
    /// Represents an event triggered when a ban is removed from a user in a guild.
    /// </summary>
    GuildBanRemove,

    /// <summary>
    /// Represents an event triggered when a guild becomes available to the client, typically when the client joins a new guild or a guild becomes accessible.
    /// </summary>
    GuildCreate,

    /// <summary>
    /// Represents an event triggered when a guild is deleted or becomes unavailable.
    /// </summary>
    GuildDelete,

    /// <summary>
    /// Represents an event triggered when a guild's integrations are updated.
    /// </summary>
    GuildIntegrationsUpdate,

    /// <summary>
    /// Represents an event triggered when a new member joins a guild.
    /// </summary>
    GuildMemberAdd,

    /// <summary>
    /// Represents an event triggered when a guild member becomes available, typically due to the member being loaded into the member cache.
    /// </summary>
    GuildMemberAvailable,

    /// <summary>
    /// Represents an event triggered when a member is removed from a guild.
    /// </summary>
    GuildMemberRemove,

    /// <summary>
    /// Represents an event triggered when a chunk of members is received for a guild.
    /// </summary>
    GuildMembersChunk,

    /// <summary>
    /// Represents an event triggered when a member's information within a guild is updated.
    /// </summary>
    GuildMemberUpdate,

    /// <summary>
    /// Represents an event triggered when a scheduled event in a guild is created.
    /// </summary>
    GuildScheduledEventCreate,

    /// <summary>
    /// Represents an event triggered when a scheduled event for a guild is deleted.
    /// </summary>
    GuildScheduledEventDelete,

    /// <summary>
    /// Represents an event triggered when a scheduled event for a guild is updated.
    /// </summary>
    GuildScheduledEventUpdate,

    /// <summary>
    /// Represents an event triggered when a user subscribes to a scheduled event in a guild.
    /// </summary>
    GuildScheduledEventUserAdd,

    /// <summary>
    /// Represents an event triggered when a user is removed from a scheduled guild event.
    /// </summary>
    GuildScheduledEventUserRemove,

    /// <summary>
    /// Represents an event triggered when a new sound is added to a guild's soundboard.
    /// </summary>
    GuildSoundboardSoundCreate,

    /// <summary>
    /// Represents an event triggered when a soundboard sound is deleted in a guild.
    /// </summary>
    GuildSoundboardSoundDelete,

    /// <summary>
    /// Represents an event triggered when a soundboard sound is updated in a guild.
    /// </summary>
    GuildSoundboardSoundUpdate,

    /// <summary>
    /// Represents an event indicating that a guild is temporarily unavailable.
    /// </summary>
    GuildUnavailable,

    /// <summary>
    /// Represents an event triggered when a guild (server) is updated.
    /// </summary>
    GuildUpdate,

    /// <summary>
    /// Represents an event triggered when an interaction is created, such as a slash command, button press, or other user interaction.
    /// </summary>
    InteractionCreate,

    /// <summary>
    /// Represents an event triggered when the client is invalidated, typically requiring a re-login or reconnection.
    /// </summary>
    Invalidated,

    /// <summary>
    /// Represents an event triggered when a new invite is created in a Discord server.
    /// </summary>
    InviteCreate,

    /// <summary>
    /// Represents an event triggered when an invite is deleted.
    /// </summary>
    InviteDelete,

    /// <summary>
    /// Represents an event triggered when a new message is created in a text channel.
    /// </summary>
    MessageCreate,

    /// <summary>
    /// Represents an event triggered when a message is deleted in a text channel.
    /// </summary>
    MessageDelete,

    /// <summary>
    /// Represents an event triggered when multiple messages are deleted in bulk within a channel.
    /// </summary>
    MessageDeleteBulk,

    /// <summary>
    /// Represents an event triggered when a vote is added to a message poll.
    /// </summary>
    MessagePollVoteAdd,

    /// <summary>
    /// Represents an event triggered when a user removes their vote from a message poll.
    /// </summary>
    MessagePollVoteRemove,

    /// <summary>
    /// Represents an event triggered when a reaction is added to a message.
    /// </summary>
    MessageReactionAdd,

    /// <summary>
    /// Represents an event triggered when a reaction is removed from a message in a Discord channel.
    /// </summary>
    MessageReactionRemove,

    /// <summary>
    /// Represents an event triggered when all reactions are removed from a message in a Discord channel.
    /// </summary>
    MessageReactionRemoveAll,

    /// <summary>
    /// Represents an event triggered when a specific emoji is removed from all reactions on a message.
    /// </summary>
    MessageReactionRemoveEmoji,

    /// <summary>
    /// Represents an event triggered when a message is updated in a channel.
    /// </summary>
    MessageUpdate,

    /// <summary>
    /// Represents an event triggered when a user's presence information is updated.
    /// </summary>
    PresenceUpdate,

    /// <summary>
    /// Represents an event triggered when the client is ready to start interacting with the Discord gateway.
    /// </summary>
    Ready,

    /// <summary>
    /// Represents an event triggered when a new role is created in a guild.
    /// </summary>
    RoleCreate,

    /// <summary>
    /// Represents an event triggered when a role is deleted in a guild.
    /// </summary>
    RoleDelete,

    /// <summary>
    /// Represents an event triggered when an existing role within a guild is updated.
    /// </summary>
    RoleUpdate,

    /// <summary>
    /// 
    /// </summary>
    ShardDisconnect,
    
    /// <summary>
    /// 
    /// </summary>
    ShardError,
    
    /// <summary>
    /// 
    /// </summary>
    ShardReady,
    
    /// <summary>
    /// 
    /// </summary>
    ShardReconnecting,
    
    /// <summary>
    /// 
    /// </summary>
    ShardResume,
    
    /// <summary>
    /// 
    /// </summary>
    SoundboardSounds,
    
    /// <summary>
    /// 
    /// </summary>
    StageInstanceCreate,
    
    /// <summary>
    /// 
    /// </summary>
    StageInstanceDelete,
    
    /// <summary>
    /// 
    /// </summary>
    StageInstanceUpdate,
    
    /// <summary>
    /// 
    /// </summary>
    StickerCreate,
    
    /// <summary>
    /// 
    /// </summary>
    StickerDelete,
    
    /// <summary>
    /// 
    /// </summary>
    StickerUpdate,

    /// <summary>
    /// Represents an event triggered when a new subscription is created in Discord.
    /// </summary>
    SubscriptionCreate,

    /// <summary>
    /// Represents an event triggered when a subscription is deleted in Discord.
    /// </summary>
    SubscriptionDelete,

    /// <summary>
    /// Represents an event triggered when a subscription is updated in Discord.
    /// </summary>
    SubscriptionUpdate,

    /// <summary>
    /// Represents an event triggered when a new thread is created in Discord.
    /// </summary>
    ThreadCreate,

    /// <summary>
    /// Represents an event triggered when a thread is deleted in Discord.
    /// </summary>
    ThreadDelete,

    /// <summary>
    /// Represents an event triggered when the current list of active threads is synchronized in a Discord guild.
    /// </summary>
    ThreadListSync,

    /// <summary>
    /// Represents an event triggered when the members of a thread are updated in Discord.
    /// </summary>
    ThreadMembersUpdate,

    /// <summary>
    /// Represents an event triggered when a thread member's details are updated in a Discord thread.
    /// </summary>
    ThreadMemberUpdate,

    /// <summary>
    /// Represents an event triggered when a thread in Discord is updated.
    /// </summary>
    ThreadUpdate,

    /// <summary>
    /// Represents an event triggered when a user starts typing in a text channel in Discord.
    /// </summary>
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