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

using System;

namespace SharpCord.Models;

/// <summary>
/// Defines the intents that the Discord gateway can use to specify
/// the types of events the application is interested in receiving.
/// Intents are a way to optimize the event stream and control the flow of data
/// between the application and the Discord gateway. Each intent corresponds
/// to different categories of events, enabling applications to request only the
/// event types they require.
/// </summary>
[Flags]
public enum GatewayIntent
{
    /// <summary>
    /// Represents the absence of any gateway intent. When this value is used,
    /// no specific intent is enabled, and the application does not subscribe to any event streams.
    /// Typically used as a default or fallback value.
    /// </summary>
    None = 0,

    /// <summary>
    /// Represents the intent to receive events related to guilds.
    /// This includes high-level information about the guilds the bot is connected to,
    /// such as creation, updates, or deletion events.
    /// </summary>
    Guilds = 1 << 0,

    /// <summary>
    /// Enables the subscription to events related to guild members, such as member addition,
    /// removal, and updates. This intent is required for applications that need to access
    /// or track detailed information about guild members.
    /// </summary>
    GuildMembers = 1 << 1, // Privileged

    /// <summary>
    /// Represents the intent to receive events related to guild moderation activities,
    /// such as administrative actions taken by moderators or updates to moderation settings.
    /// Enabling this intent allows the application to process events related to guild moderation functionality.
    /// </summary>
    GuildModeration = 1 << 2,

    /// <summary>
    /// Represents an intent to receive events related to guild expressions, such as emojis,
    /// stickers, and other custom expressions within a guild. Enables the application
    /// to interact with or respond to expression updates or changes.
    /// </summary>
    GuildExpressions = 1 << 3,

    /// <summary>
    /// Enables the application to receive events related to integrations within the guild.
    /// This includes notifications about integration creation, updates, or deletions,
    /// allowing the application to manage or respond to changes in external integrations.
    /// </summary>
    GuildIntegrations = 1 << 4,

    /// <summary>
    /// Represents the intent to receive updates related to guild webhooks. This includes events
    /// that notify about the creation, updating, or deletion of webhooks within a guild.
    /// Enables the application to stay informed of webhook configuration changes in a guild.
    /// </summary>
    GuildWebhooks = 1 << 5,

    /// <summary>
    /// Enables the application to receive events related to guild invite creation and deletion.
    /// When subscribed to this intent, the application can track invite management
    /// within the guilds it is a member of.
    /// </summary>
    GuildInvites = 1 << 6,

    /// <summary>
    /// Represents the intent to receive events related to changes in guild voice states, such as users joining, leaving, or muting within voice channels.
    /// This intent allows the application to subscribe to guild-level voice state updates.
    /// </summary>
    GuildVoiceStates = 1 << 7,

    /// <summary>
    /// Enables the subscription to presence updates for guild members.
    /// When this intent is enabled, the application can receive events related
    /// to the online status and activity of users in a guild.
    /// </summary>
    GuildPresences = 1 << 8, // Privileged

    /// <summary>
    /// Represents an intent that enables the application to subscribe to events
    /// related to messages within guilds. This includes events for messages
    /// that are sent, edited, or deleted in text channels of guilds the bot is part of.
    /// </summary>
    GuildMessages = 1 << 9,

    /// <summary>
    /// Enables the application to receive events related to reactions added or removed
    /// from messages in guild channels. Useful for tracking user interactions with
    /// guild messages or implementing reaction-based features.
    /// </summary>
    GuildMessageReactions = 1 << 10,

    /// <summary>
    /// Represents the intent to subscribe to typing events in guilds.
    /// This allows receiving events when a user starts typing a message in guild text channels.
    /// Commonly used to track user activity within text channels.
    /// </summary>
    GuildMessageTyping = 1 << 11,

    /// <summary>
    /// Represents the intent to receive events related to direct messages.
    /// When enabled, the application can listen to and handle communication
    /// occurring through private messages sent between individual users.
    /// </summary>
    DirectMessages = 1 << 12,

    /// <summary>
    /// Represents the intent to receive events related to reactions added or removed
    /// in direct messages. Enables the application to track user interactions with
    /// messages in private conversations by monitoring reaction events.
    /// </summary>
    DirectMessageReactions = 1 << 13,

    /// <summary>
    /// Represents the intent for receiving typing indicator events in direct messages.
    /// Enabling this allows the application to subscribe to notification events
    /// when users are actively typing in direct message conversations.
    /// </summary>
    DirectMessageTyping = 1 << 14,

    /// <summary>
    /// Enables access to the full content of messages, including text and attachments.
    /// This intent is privileged and requires additional approval from the platform
    /// to ensure proper use and compliance with privacy policies.
    /// </summary>
    MessageContent = 1 << 15, // Privileged

    /// <summary>
    /// Enables the application to receive events related to scheduled events within guilds.
    /// This intent allows the subscription to notifications for the creation, update, and deletion
    /// of scheduled events in any guild the application has access to.
    /// </summary>
    GuildScheduledEvents = 1 << 16,

    /// <summary>
    /// Enables the application to receive events related to auto-moderation rule configurations within guilds.
    /// This includes events triggered when auto-moderation rules are created, updated, or deleted.
    /// Useful for tracking and managing moderation rule settings in a guild context.
    /// </summary>
    AutoModerationConfiguration = 1 << 20,

    /// <summary>
    /// Enables the application to receive events related to the execution of AutoModeration rules.
    /// This intent allows the application to be notified when automated moderation actions
    /// (such as message deletions, timeouts, or other moderation triggers) are executed in a guild.
    /// </summary>
    AutoModerationExecution = 1 << 21,

    /// <summary>
    /// Represents the intent to subscribe to events related to polls conducted within guild messages.
    /// When this intent is enabled, the application can receive and handle events associated
    /// with the creation, update, or deletion of polls in guild-specific messages.
    /// </summary>
    GuildMessagePolls = 1 << 24,

    /// <summary>
    /// Represents the intent to receive events related to polls conducted within direct messages.
    /// When this intent is enabled, the application can listen to and process events specifically
    /// associated with polling activities in one-on-one or group direct message channels.
    /// </summary>
    DirectMessagePolls = 1 << 25,

    /// <summary>
    /// Represents a combination of all non-privileged gateway intents.
    /// This includes intents that do not require additional permissions,
    /// providing access to general events such as guild moderation, messages, reactions,
    /// invites, voice states, and others.
    /// </summary>
    AllUnprivileged = Guilds | GuildModeration | GuildExpressions |
                      GuildIntegrations | GuildWebhooks | GuildInvites |
                      GuildVoiceStates | GuildMessages | GuildMessageReactions |
                      GuildMessageTyping | DirectMessages | DirectMessageReactions |
                      DirectMessageTyping | GuildScheduledEvents |
                      AutoModerationConfiguration | AutoModerationExecution |
                      GuildMessagePolls | DirectMessagePolls,

    /// <summary>
    /// Represents the combination of all available gateway intents, both privileged and unprivileged.
    /// This value enables listening to all types of events supported by the application.
    /// </summary>
    All = AllUnprivileged | GuildMembers | GuildPresences | MessageContent
}