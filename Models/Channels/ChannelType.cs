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
/// Defines the type of channel in the context of a messaging or communication platform.
/// Each value corresponds to a specific category or functionality of a channel.
/// </summary>
public enum ChannelType
{
    /// <summary>
    /// Represents a text channel within a guild (server).
    /// Guild text channels are used for sending messages, sharing files, and interacting with bots in a specific guild context.
    /// </summary>
    GuildText = 0,

    /// <summary>
    /// Represents a direct message (DM) channel between two users.
    /// DM channels are private communication channels that are not associated with any guild.
    /// </summary>
    DM = 1,

    /// <summary>
    /// Represents a voice channel within a guild.
    /// GuildVoice channels allow members of a guild to communicate with each other using voice.
    /// </summary>
    GuildVoice = 2,

    /// <summary>
    /// Represents a group direct message channel.
    /// GroupDM channels allow multiple users to communicate in a private channel
    /// without being part of a larger guild.
    /// </summary>
    GroupDM = 3,

    /// <summary>
    /// Represents a category in a guild used for organizing channels.
    /// Categories can group related channels to improve navigation and structure within a guild.
    /// </summary>
    GuildCategory = 4,

    /// <summary>
    /// Represents an announcement channel in a guild.
    /// This channel type is used for posting and managing official updates or announcements.
    /// </summary>
    GuildAnnouncement = 5,

    /// <summary>
    /// Represents an announcement channel in a guild.
    /// This member is marked obsolete and replaced by GuildAnnouncement.
    /// It exists for backward compatibility.
    /// </summary>
    [Obsolete("This the old name for GuildAnnouncement, please use GuildAnnouncement instead.")]
    GuildNews = 5,

    /// <summary>
    /// Represents a thread created within an announcement channel in a guild.
    /// This enum member is used for threads associated with announcement-type channels.
    /// </summary>
    AnnouncementThread = 10,

    /// <summary>
    /// Represents a thread created within a guild announcement channel (formerly known as GuildNews).
    /// This enum member is deprecated and retained for backward compatibility.
    /// It is recommended to use the `AnnouncementThread` member instead.
    /// </summary>
    [Obsolete("This the old name for AnnouncementThread, please use AnnouncementThread instead.")]
    GuildNewsThread = 10,

    /// <summary>
    /// Represents a public thread within a text-based channel in a guild.
    /// Public threads can be joined and viewed by all members with access to the parent channel,
    /// facilitating open and organized discussions.
    /// </summary>
    PublicThread = 11,

    /// <summary>
    /// Represents a public thread within a guild.
    /// Public threads are accessible to all members with view permissions in the
    /// parent channel or category, enabling group discussions within that scope.
    /// </summary>
    [Obsolete("This the old name for PublicThread, please use PublicThread instead.")]
    GuildPublicThread = 11,

    /// <summary>
    /// Represents a private thread within a channel, typically used for limited, invite-only discussions.
    /// Private threads are only accessible to users with explicit access or an invitation.
    /// </summary>
    PrivateThread = 12,

    /// <summary>
    /// Represents a private thread within a guild.
    /// Private threads are invite-only and are used for more focused or restricted discussions among a smaller group of members.
    /// </summary>
    [Obsolete("This the old name for PrivateThread, please use PrivateThread instead.")]
    GuildPrivateThread = 12,

    /// <summary>
    /// Represents a stage channel in a guild where users can participate in or listen to live audio discussions.
    /// Stage channels are optimized for events such as conferences, Questions and Answers sessions, and similar organized conversations.
    /// </summary>
    GuildStageVoice = 13,

    /// <summary>
    /// Represents a directory channel within a guild (server).
    /// Guild directory channels are used for organizing and showcasing guild-specific content or resources in a centralized manner.
    /// </summary>
    GuildDirectory = 14,

    /// <summary>
    /// Represents a forum channel within a guild (server).
    /// Guild forum channels allow for organized discussions using posts and threads on specific topics.
    /// </summary>
    GuildForum = 15,

    /// <summary>
    /// Represents a media channel within a guild (server).
    /// Guild media channels are used for sharing and interacting with multimedia content such as videos, images, or streams in a guild context.
    /// </summary>
    GuildMedia = 16,
}