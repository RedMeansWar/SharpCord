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
/// Represents the set of permissions available in Discord. These permissions control various
/// actions and features that users or roles may perform within a Discord server or channel.
/// The enum values support bitwise combinations for flexible permission assignments.
/// </summary>
[Flags]
public enum DiscordPermission : ulong
{
    /// <summary>
    /// Grants the ability to create instant invites to a server, channel, or voice channel.
    /// </summary>
    CreateInstantInvite = 1UL << 0,

    /// <summary>
    /// Grants the ability to kick members from the server.
    /// </summary>
    KickMembers = 1UL << 1,

    /// <summary>
    /// Grants the ability to ban members from the server.
    /// </summary>
    BanMembers = 1UL << 2,

    /// <summary>
    /// Grants all permissions within a server, bypassing all channel-specific permissions and restrictions.
    /// </summary>
    Administrator = 1UL << 3,

    /// <summary>
    /// Grants the ability to manage and edit channels within a server, including modifying channel settings, roles, and permissions.
    /// </summary>
    ManageChannels = 1UL << 4,

    /// <summary>
    /// Grants the ability to manage and edit the server, including roles, channels, and settings.
    /// </summary>
    ManageGuild = 1UL << 5,

    /// <summary>
    /// Grants the ability to add reactions to messages in a channel.
    /// </summary>
    AddReactions = 1UL << 6,

    /// <summary>
    /// Grants the ability to view the audit log for a server, providing access to a record of administrative actions taken within the server.
    /// </summary>
    ViewAuditLog = 1UL << 7,

    /// <summary>
    /// Grants the ability to use the "Priority Speaker" feature in a voice channel, allowing the user's voice activity to take precedence over others.
    /// </summary>
    PrioritySpeaker = 1UL << 8,

    /// <summary>
    /// Grants the ability to stream video to a voice channel.
    /// </summary>
    Stream = 1UL << 9,

    /// <summary>
    /// Allows viewing a specific channel, including reading messages in text channels or accessing voice channels.
    /// </summary>
    ViewChannel = 1UL << 10,

    /// <summary>
    /// Grants the ability to send messages in text channels within a Discord server.
    /// </summary>
    SendMessages = 1UL << 11,

    /// <summary>
    /// Grants the ability to send text-to-speech (TTS) messages in a channel.
    /// </summary>
    SendTTSMessages = 1UL << 12,

    /// <summary>
    /// Grants the ability to delete and manage messages sent by other users, as well as to pin or unpin messages in a channel.
    /// </summary>
    ManageMessages = 1UL << 13,

    /// <summary>
    /// Grants the ability to embed hyperlinks in messages sent within a text channel.
    /// </summary>
    EmbedLinks = 1UL << 14,

    /// <summary>
    /// Grants the ability to upload and attach files to messages in a channel.
    /// </summary>
    AttachFiles = 1UL << 15,

    /// <summary>
    /// Allows the ability to view the message history in a text channel.
    /// </summary>
    ReadMessageHistory = 1UL << 16,

    /// <summary>
    /// Grants the ability to mention @everyone, @here, and all roles in a server.
    /// </summary>
    MentionEveryone = 1UL << 17,

    /// <summary>
    /// Allows the use of custom emojis from other servers.
    /// </summary>
    UseExternalEmojis = 1UL << 18,

    /// <summary>
    /// Grants the ability to view detailed server insights and analytics, such as metrics related to member activity and growth.
    /// </summary>
    ViewGuildInsights = 1UL << 19,

    /// <summary>
    /// Allows a user to connect to a voice channel.
    /// </summary>
    Connect = 1UL << 20,

    /// <summary>
    /// Grants the ability to speak in a voice channel.
    /// </summary>
    Speak = 1UL << 21,

    /// <summary>
    /// Grants the ability to mute members in voice channels.
    /// </summary>
    MuteMembers = 1UL << 22,

    /// <summary>
    /// Grants the ability to deafen other members in a voice channel, preventing them from hearing anything in the channel.
    /// </summary>
    DeafenMembers = 1UL << 23,

    /// <summary>
    /// Grants the ability to move members between voice channels.
    /// </summary>
    MoveMembers = 1UL << 24,

    /// <summary>
    /// Grants the ability to use voice activity detection instead-of-push-to-talk in voice channels.
    /// </summary>
    UseVAD = 1UL << 25,

    /// <summary>
    /// Allows a user to change their own nickname within a server.
    /// </summary>
    ChangeNickname = 1UL << 26,

    /// <summary>
    /// Grants the ability to modify the nicknames of other members in the server.
    /// </summary>
    ManageNicknames = 1UL << 27,

    /// <summary>
    /// Grants the ability to manage roles within a guild, including creating, editing, or deleting roles, as well as assigning them to members.
    /// </summary>
    ManageRoles = 1UL << 28,

    /// <summary>
    /// Grants the ability to manage webhooks, including creating, editing, and deleting webhooks for a channel.
    /// </summary>
    ManageWebhooks = 1UL << 29,

    /// <summary>
    /// Grants the ability to manage emojis and stickers within a server. This includes adding, removing, and editing custom emojis and stickers.
    /// </summary>
    ManageEmojisAndStickers = 1UL << 30,

    /// <summary>
    /// Grants the ability to use application-generated slash commands and interactions within the server.
    /// </summary>
    UseApplicationCommands = 1UL << 31,

    /// <summary>
    /// Grants the ability to request to speak in a stage channel.
    /// </summary>
    RequestToSpeak = 1UL << 32,

    /// <summary>
    /// Grants the ability to manage, create, edit, and delete events in a Discord server.
    /// </summary>
    ManageEvents = 1UL << 33,

    /// <summary>
    /// Grants the ability to manage threads, including renaming, deleting, archiving, and unarchiving threads.
    /// </summary>
    ManageThreads = 1UL << 34,

    /// <summary>
    /// Grants the ability to create public threads within a channel.
    /// </summary>
    CreatePublicThreads = 1UL << 35,

    /// <summary>
    /// Grants the ability to create private threads within a server.
    /// </summary>
    CreatePrivateThreads = 1UL << 36,

    /// <summary>
    /// Grants the ability to use external stickers in messages within the server.
    /// </summary>
    UseExternalStickers = 1UL << 37,

    /// <summary>
    /// Allows the ability to send messages within threads.
    /// </summary>
    SendMessagesInThreads = 1UL << 38,

    /// <summary>
    /// Grants the ability to start embedded activities within voice channels, allowing users to interact with integrated applications such as games or watch parties.
    /// </summary>
    StartEmbeddedActivities = 1UL << 39,

    /// <summary>
    /// Grants the ability to time out members, temporarily restricting them from sending messages, reacting, or speaking.
    /// </summary>
    ModerateMembers = 1UL << 40
}