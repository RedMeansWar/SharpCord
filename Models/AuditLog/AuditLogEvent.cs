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
/// Defines the types of events that can appear in an audit log.
/// See also: https://discord.com/developers/docs/resources/audit-log#audit-log-entry-object-audit-log-events
/// </summary>
public enum AuditLogEvent
{
    /// <summary>
    /// Represents an audit log event for when an application command's permissions are updated.
    /// </summary>
    ApplicationCommandPermissionUpdate = 121,

    /// <summary>
    /// Represents an audit log event for when a message is blocked by an auto-moderation rule.
    /// </summary>
    AutoModerationBlockMessage = 143,

    /// <summary>
    /// Represents an audit log event for when a message is flagged by AutoModeration and sent to a designated channel.
    /// </summary>
    AutoModerationFlagToChannel = 144,

    /// <summary>
    /// Represents an audit log event for the creation of an auto-moderation rule.
    /// </summary>
    AutoModerationRuleCreate = 140,

    /// <summary>
    /// Represents an audit log event for when an auto-moderation rule is deleted.
    /// </summary>
    AutoModerationRuleDelete = 142,

    /// <summary>
    /// Represents an audit log event for when an auto-moderation rule is updated.
    /// </summary>
    AutoModerationRuleUpdate = 141,

    /// <summary>
    /// Represents an audit log event for when auto-moderation disables a user's communication privileges.
    /// </summary>
    AutoModerationUserCommunicationDisabled = 145,

    /// <summary>
    /// Represents an audit log event for when a bot is added to a guild.
    /// </summary>
    BotAdd = 28,

    /// <summary>
    /// Represents an audit log event for when a new channel is created.
    /// </summary>
    ChannelCreate = 10,

    /// <summary>
    /// Represents an audit log event for when a channel is deleted.
    /// </summary>
    ChannelDelete = 12,

    /// <summary>
    /// Represents an audit log event for when a channel overwrite is created.
    /// </summary>
    ChannelOverwriteCreate = 13,

    /// <summary>
    /// Represents an audit log event for when a channel overwrite is deleted.
    /// </summary>
    ChannelOverwriteDelete = 15,

    /// <summary>
    /// Represents an audit log event for when a channel permission overwrite is updated.
    /// </summary>
    ChannelOverwriteUpdate = 14,

    /// <summary>
    /// Represents an audit log event for when a channel is updated.
    /// </summary>
    ChannelUpdate = 11,

    /// <summary>
    /// Represents an audit log event for when a creator monetization request is created.
    /// </summary>
    CreatorMonetizationRequestCreated = 150,

    /// <summary>
    /// Represents an audit log event for when a creator's monetization terms are accepted.
    /// </summary>
    CreatorMonetizationTermsAccepted = 151,

    /// <summary>
    /// Represents an audit log event for the creation of a new emoji.
    /// </summary>
    EmojiCreate = 60,

    /// <summary>
    /// Represents an audit log event for when an emoji is deleted.
    /// </summary>
    EmojiDelete = 62,

    /// <summary>
    /// Represents an audit log event for when an emoji is updated.
    /// </summary>
    EmojiUpdate = 61,

    /// <summary>
    /// Represents an audit log event for the creation of a scheduled event in a guild.
    /// </summary>
    GuildScheduledEventCreate = 100,

    /// <summary>
    /// Represents an audit log event for when a guild scheduled event is deleted.
    /// </summary>
    GUildScheduledEventDelete = 102,

    /// <summary>
    /// Represents an audit log event for when a scheduled event in a guild is updated.
    /// </summary>
    GuildScheduledEventUpdate = 101,

    /// <summary>
    /// Represents an audit log event for when a guild's settings are updated.
    /// </summary>
    GuildUpdate = 1,

    /// <summary>
    /// Represents an audit log event for when home settings are created.
    /// </summary>
    HomeSettingsCreate = 190,

    /// <summary>
    /// Represents an audit log event for when home settings are updated.
    /// </summary>
    HomeSettingsUpdate = 191,

    /// <summary>
    /// Represents an audit log event for when an integration is created.
    /// </summary>
    IntegrationCreate = 80,

    /// <summary>
    /// Represents an audit log event for when an integration is deleted.
    /// </summary>
    IntegrationDelete = 82,

    /// <summary>
    /// Represents an audit log event for when an integration is updated.
    /// </summary>
    IntegrationUpdate = 81,

    /// <summary>
    /// Represents an audit log event for when an invite is created.
    /// </summary>
    InviteCreate = 40,

    /// <summary>
    /// Represents an audit log event for when an invite is deleted.
    /// </summary>
    InviteDelete = 42,

    /// <summary>
    /// Represents an audit log event for when an existing invite is updated.
    /// </summary>
    InviteUpdate = 41,

    /// <summary>
    /// Represents an audit log event for when a member is banned from the server.
    /// </summary>
    MemberBanAdd = 22,

    /// <summary>
    /// Represents an audit log event for when a member's ban is removed.
    /// </summary>
    MemberBanRemove = 23,

    /// <summary>
    /// Represents an audit log event for when a member is disconnected from a voice channel.
    /// </summary>
    MemberDisconnect = 27,

    /// <summary>
    /// Represents an audit log event for when a member is moved between voice channels.
    /// </summary>
    MemberMove = 26,

    /// <summary>
    /// Represents an audit log event for when members are pruned from the guild.
    /// </summary>
    MemberPrune = 21,

    /// <summary>
    /// Represents an audit log event for when a member's roles are updated.
    /// </summary>
    MemberRoleUpdate = 25,

    /// <summary>
    /// Represents an audit log event for when a member's details are updated.
    /// </summary>
    MemberUpdate = 24,

    /// <summary>
    /// Represents an audit log event for when multiple messages are deleted in bulk.
    /// </summary>
    MessageBulkDelete = 73,

    /// <summary>
    /// Represents an audit log event for when a message is deleted.
    /// </summary>
    MessageDelete = 72,

    /// <summary>
    /// Represents an audit log event for when a message is pinned.
    /// </summary>
    MessagePin = 74,

    /// <summary>
    /// Represents an audit log event for when a message is unpinned.
    /// </summary>
    MessageUnpin = 75,

    /// <summary>
    /// Represents an audit log event for when an onboarding instance is created.
    /// </summary>
    OnboardingCreate = 166,

    /// <summary>
    /// Represents an audit log event for the creation of an onboarding prompt.
    /// </summary>
    OnboardingPromptCreate = 163,

    /// <summary>
    /// Represents an audit log event for when an onboarding prompt is deleted.
    /// </summary>
    OnboardingPromptDelete = 165,

    /// <summary>
    /// Represents an audit log event for when an onboarding prompt is updated.
    /// </summary>
    OnboardingPromptUpdate = 164,

    /// <summary>
    /// Represents an audit log event for when an onboarding configuration is updated.
    /// </summary>
    OnboardingUpdate = 167,

    /// <summary>
    /// Represents an audit log event for when a role is created.
    /// </summary>
    RoleCreate = 30,

    /// <summary>
    /// Represents an audit log event for when a role is deleted.
    /// </summary>
    RoleDelete = 32,

    /// <summary>
    /// Represents an audit log event for when a role is updated.
    /// </summary>
    RoleUpdate = 31,

    /// <summary>
    /// Represents an audit log event for when a sound is created for the soundboard.
    /// </summary>
    SoundboardSoundCreate = 130,

    /// <summary>
    /// Represents an audit log event for when a soundboard sound is deleted.
    /// </summary>
    SoundboardSoundDelete = 132,

    /// <summary>
    /// Represents an audit log event for when a soundboard sound is updated.
    /// </summary>
    SoundboardSoundUpdate = 131,

    /// <summary>
    /// Represents an audit log event for when a stage instance is created.
    /// </summary>
    StageInstanceCreate = 83,

    /// <summary>
    /// Represents an audit log event for when a stage instance is deleted.
    /// </summary>
    StageInstanceDelete = 85,

    /// <summary>
    /// Represents an audit log event for when a stage instance is updated.
    /// </summary>
    StageInstanceUpdate = 84,

    /// <summary>
    /// Represents an audit log event for the creation of a sticker.
    /// </summary>
    StickerCreate = 90,

    /// <summary>
    /// Represents an audit log event for when a sticker is deleted.
    /// </summary>
    StickerDelete = 92,

    /// <summary>
    /// Represents an audit log event for when a sticker is updated.
    /// </summary>
    StickerUpdate = 91,

    /// <summary>
    /// Represents an audit log event triggered when a thread is created.
    /// </summary>
    ThreadCreate = 110,

    /// <summary>
    /// Represents an audit log event for when a thread is deleted.
    /// </summary>
    ThreadDelete = 112,

    /// <summary>
    /// Represents an audit log event for when a thread's settings or details are updated.
    /// </summary>
    ThreadUpdate = 111,

    /// <summary>
    /// Represents an audit log event for the creation of a webhook.
    /// </summary>
    WebhookCreate = 50,

    /// <summary>
    /// Represents an audit log event for when a webhook is deleted.
    /// </summary>
    WebhookDelete = 52,

    /// <summary>
    /// Represents an audit log event for when a webhook is updated.
    /// </summary>
    WebhookUpdate = 51,
}