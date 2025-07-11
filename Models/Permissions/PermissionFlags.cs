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

using System.Text.Json.Serialization;

namespace SharpCord.Models;

/// <summary>
/// Represents the set of permissions available in Discord. These permissions control various
/// actions and features that users or roles may perform within a Discord server or channel.
/// The enum values support bitwise combinations for flexible permission assignments.
/// </summary>
[Flags]
public enum PermissionFlags : ulong
{
    /// <summary>
    /// Empty Permissions.
    /// </summary>
    None = 0,
    
    /// <summary>
    /// Grants the ability to create instant invites to a server, channel, or voice channel.
    /// </summary>
    [JsonPropertyName("CREATE_INSTANT_INVITE")]
    CreateInstantInvite = 1UL << 0,

    /// <summary>
    /// Grants the ability to kick members from the server.
    /// </summary>
    [JsonPropertyName("KICK_MEMBERS")]
    KickMembers = 1UL << 1,

    /// <summary>
    /// Grants the ability to ban members from the server.
    /// </summary>
    [JsonPropertyName("BAN_MEMBERS")]
    BanMembers = 1UL << 2,

    /// <summary>
    /// Grants all permissions within a server, bypassing all channel-specific permissions and restrictions.
    /// </summary>
    [JsonPropertyName("ADMINISTRATOR")]
    Administrator = 1UL << 3,

    /// <summary>
    /// Grants the ability to manage and edit channels within a server, including modifying channel settings, roles, and permissions.
    /// </summary>
    [JsonPropertyName("MANAGE_CHANNELS")]
    ManageChannels = 1UL << 4,

    /// <summary>
    /// Grants the ability to manage and edit the server, including roles, channels, and settings.
    /// </summary>
    [JsonPropertyName("MANAGE_GUILD")]
    ManageGuild = 1UL << 5,

    /// <summary>
    /// Grants the ability to add reactions to messages in a channel.
    /// </summary>
    [JsonPropertyName("ADD_REACTIONS")]
    AddReactions = 1UL << 6,

    /// <summary>
    /// Grants the ability to view the audit log for a server, providing access to a record of administrative actions taken within the server.
    /// </summary>
    [JsonPropertyName("VIEW_AUDIT_LOG")]
    ViewAuditLog = 1UL << 7,

    /// <summary>
    /// Grants the ability to use the "Priority Speaker" feature in a voice channel, allowing the user's voice activity to take precedence over others.
    /// </summary>
    [JsonPropertyName("PRIORITY_SPEAKER")]
    PrioritySpeaker = 1UL << 8,

    /// <summary>
    /// Grants the ability to stream video to a voice channel.
    /// </summary>
    [JsonPropertyName("STREAM")]
    Stream = 1UL << 9,

    /// <summary>
    /// Allows viewing a specific channel, including reading messages in text channels or accessing voice channels.
    /// </summary>
    [JsonPropertyName("VIEW_CHANNEL")]
    ViewChannel = 1UL << 10,

    /// <summary>
    /// Grants the ability to send messages in text channels within a Discord server.
    /// </summary>
    [JsonPropertyName("SEND_MESSAGES")]
    SendMessages = 1UL << 11,

    /// <summary>
    /// Grants the ability to send text-to-speech (TTS) messages in a channel.
    /// </summary>
    [JsonPropertyName("SEND_TTS_MESSAGES")]
    SendTTSMessages = 1UL << 12,

    /// <summary>
    /// Grants the ability to delete and manage messages sent by other users, as well as to pin or unpin messages in a channel.
    /// </summary>
    [JsonPropertyName("MANAGE_MESSAGES")]
    ManageMessages = 1UL << 13,

    /// <summary>
    /// Grants the ability to embed hyperlinks in messages sent within a text channel.
    /// </summary>
    [JsonPropertyName("EMBED_LINKS")]
    EmbedLinks = 1UL << 14,

    /// <summary>
    /// Grants the ability to upload and attach files to messages in a channel.
    /// </summary>
    [JsonPropertyName("ATTACH_FILES")]
    AttachFiles = 1UL << 15,

    /// <summary>
    /// Allows the ability to view the message history in a text channel.
    /// </summary>
    [JsonPropertyName("READ_MESSAGE_HISTORY")]
    ReadMessageHistory = 1UL << 16,

    /// <summary>
    /// Grants the ability to mention @everyone, @here, and all roles in a server.
    /// </summary>
    [JsonPropertyName("MENTION_EVERYONE")]
    MentionEveryone = 1UL << 17,

    /// <summary>
    /// Allows the use of custom emojis from other servers.
    /// </summary>
    [JsonPropertyName("USE_EXTERNAL_EMOJIS")]
    UseExternalEmojis = 1UL << 18,

    /// <summary>
    /// Grants the ability to view detailed server insights and analytics, such as metrics related to member activity and growth.
    /// </summary>
    [JsonPropertyName("VIEW_GUILD_INSIGHTS")]
    ViewGuildInsights = 1UL << 19,

    /// <summary>
    /// Allows a user to connect to a voice channel.
    /// </summary>
    [JsonPropertyName("CONNECT")]
    Connect = 1UL << 20,

    /// <summary>
    /// Grants the ability to speak in a voice channel.
    /// </summary>
    [JsonPropertyName("SPEAK")]
    Speak = 1UL << 21,

    /// <summary>
    /// Grants the ability to mute members in voice channels.
    /// </summary>
    [JsonPropertyName("MUTE_MEMBERS")]
    MuteMembers = 1UL << 22,

    /// <summary>
    /// Grants the ability to deafen other members in a voice channel, preventing them from hearing anything in the channel.
    /// </summary>
    [JsonPropertyName("DEAFEN_MEMBERS")]
    DeafenMembers = 1UL << 23,

    /// <summary>
    /// Grants the ability to move members between voice channels.
    /// </summary>
    [JsonPropertyName("MOVE_MEMBERS")]
    MoveMembers = 1UL << 24,

    /// <summary>
    /// Grants the ability to use voice activity detection instead-of-push-to-talk in voice channels.
    /// </summary>
    [JsonPropertyName("USE_VAD")]
    UseVAD = 1UL << 25,

    /// <summary>
    /// Allows a user to change their own nickname within a server.
    /// </summary>
    [JsonPropertyName("CHANGE_NICKNAME")]
    ChangeNickname = 1UL << 26,

    /// <summary>
    /// Grants the ability to modify the nicknames of other members in the server.
    /// </summary>
    [JsonPropertyName("MANAGE_NICKNAMES")]
    ManageNicknames = 1UL << 27,

    /// <summary>
    /// Grants the ability to manage roles within a guild, including creating, editing, or deleting roles, as well as assigning them to members.
    /// </summary>
    [JsonPropertyName("MANAGE_ROLES")]
    ManageRoles = 1UL << 28,

    /// <summary>
    /// Grants the ability to manage webhooks, including creating, editing, and deleting webhooks for a channel.
    /// </summary>
    [JsonPropertyName("MANAGE_WEBHOOKS")]
    ManageWebhooks = 1UL << 29,

    /// <summary>
    /// Grants the ability to manage emojis and stickers within a server. This includes adding, removing, and editing custom emojis and stickers.
    /// </summary>
    [JsonPropertyName("MANAGE_GUILD_EXPRESSIONS")]
    ManageEmojisAndStickers = 1UL << 30,

    /// <summary>
    /// Grants the ability to use application-generated slash commands and interactions within the server.
    /// </summary>
    [JsonPropertyName("USE_APPLICATION_COMMANDS")]
    UseApplicationCommands = 1UL << 31,

    /// <summary>
    /// Grants the ability to request to speak in a stage channel.
    /// </summary>
    [JsonPropertyName("REQUEST_TO_SPEAK")]
    RequestToSpeak = 1UL << 32,

    /// <summary>
    /// Grants the ability to manage, create, edit, and delete events in a Discord server.
    /// </summary>
    [JsonPropertyName("MANAGE_EVENTS")]
    ManageEvents = 1UL << 33,

    /// <summary>
    /// Grants the ability to manage threads, including renaming, deleting, archiving, and unarchiving threads.
    /// </summary>
    [JsonPropertyName("MANAGE_THREADS")]
    ManageThreads = 1UL << 34,

    /// <summary>
    /// Grants the ability to create public threads within a channel.
    /// </summary>
    [JsonPropertyName("CREATE_PUBLIC_THREADS")]
    CreatePublicThreads = 1UL << 35,

    /// <summary>
    /// Grants the ability to create private threads within a server.
    /// </summary>
    [JsonPropertyName("CREATE_PRIVATE_THREADS")]
    CreatePrivateThreads = 1UL << 36,

    /// <summary>
    /// Grants the ability to use external stickers in messages within the server.
    /// </summary>
    [JsonPropertyName("USE_EXTERNAL_STICKERS")]
    UseExternalStickers = 1UL << 37,

    /// <summary>
    /// Allows the ability to send messages within threads.
    /// </summary>
    [JsonPropertyName("SEND_MESSAGES_IN_THREADS")]
    SendMessagesInThreads = 1UL << 38,

    /// <summary>
    /// Grants the ability to start embedded activities within voice channels, allowing users to interact with integrated applications such as games or watch parties.
    /// </summary>
    [JsonPropertyName("USE_EMBEDDED_ACTIVITIES")]
    useEmbeddedActivities = 1UL << 39,

    /// <summary>
    /// Grants the ability to time out members, temporarily restricting them from sending messages, reacting, or speaking.
    /// </summary>
    [JsonPropertyName("MODERATE_MEMBERS")]
    ModerateMembers = 1UL << 40,
        
    /// <summary>
    /// Allows for viewing role subscription insights
    /// </summary>
    [JsonPropertyName("VIEW_CREATOR_MONETIZATION_ANALYTICS")]
    ViewCreatorMonetizationAnalytics = 1UL << 40,
    
    /// <summary>
    /// Allows for using soundboard in a voice channel
    /// </summary>
    [JsonPropertyName("USE_SOUNDBOARD")]
    UseSoundboard = 1UL << 40,
    
    /// <summary>
    /// Allows for creating emojis, stickers, and soundboard sounds, and editing and deleting those created by the current user. Not yet available to developers.
    /// </summary>
    [JsonPropertyName("CREATE_GUILD_EXPRESSIONS")]
    CreateGuildExpressions = 1UL << 40,
    
    /// <summary>
    /// Allows for creating scheduled events, and editing and deleting those created by the current user. Not yet available to developers.
    /// </summary>
    [JsonPropertyName("CREATE_EVENTS")]
    CreateEvents = 1UL << 40,
    
    /// <summary>
    /// Allows the usage of custom soundboard sounds from other servers
    /// </summary>
    [JsonPropertyName("USE_EXTERNAL_SOUNDS")]
    UseExternalSounds = 1UL << 40,
        
    /// <summary>
    /// Allows sending voice messages
    /// </summary>
    [JsonPropertyName("SEND_VOICE_MESSAGES")]
    SendVoiceMessages = 1UL << 40,
    
    /// <summary>
    /// Allows sending polls
    /// </summary>
    [JsonPropertyName("SEND_POLLS")]
    SendPolls = 1UL << 40,
    
    /// <summary>
    /// Allows user-installed apps to send public responses. When disabled, users will still be allowed to use their apps but the responses will be ephemeral.
    /// This only applies to apps not also installed to the server.
    /// </summary>
    [JsonPropertyName("USE_EXTERNAL_APPS")]
    UseExternalApps = 1UL << 40,
    
}