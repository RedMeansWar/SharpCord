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
/// Represents various flags associated with a message.
/// </summary>
public enum MessageFlags
{
    /// <summary>
    /// Indicates that no specific flags are associated with the message.
    /// </summary>
    None = 0,

    /// <summary>
    /// This message has been published to subscribe channels (via Channel Following)
    /// </summary>
    Crossposted = 1,

    /// <summary>
    /// This message originated from a message in another channel (via Channel Following)
    /// </summary>
    IsCrosspost = 2,

    /// <summary>
    /// Indicates that the message contains embeds that are suppressed.
    /// </summary>
    SuppressEmbeds = 4,

    /// <summary>
    /// Indicates that the source message of this message was deleted.
    /// </summary>
    SourceMessageDeleted = 8,

    /// <summary>
    /// This message came from the urgent message system
    /// </summary>
    Urgent = 16,

    /// <summary>
    /// Indicates that the message is associated with an active thread.
    /// </summary>
    HasThread = 32,

    /// <summary>
    /// This message is temporary and will automatically be removed after a certain period of time.
    /// </summary>
    Ephemeral = 64,

    /// <summary>
    /// Indicates that the message is in a loading state, often used when its content or metadata is being fetched or processed.
    /// </summary>
    Loading = 128,

    /// <summary>
    /// Indicates that the message failed to mention certain roles within a thread.
    /// </summary>
    FailedToMentionSomeRolesInThread = 256,

    /// <summary>
    /// Indicates that a warning should be shown for a non-Discord link in the message.
    /// </summary>
    ShouldShowLinkNotDiscordWarning = 1024,

    /// <summary>
    /// This message is configured to suppress notifications from being sent.
    /// </summary>
    SuppressNotifications = 4096,

    /// <summary>
    /// Indicates that the message is a voice message.
    /// </summary>
    IsVoiceMessage = 8192,

    /// <summary>
    /// Indicates that the message contains a snapshot of the referenced content.
    /// </summary>
    HasSnapshot = 16384,

    /// <summary>
    /// Indicates that the message contains components using the updated "Components V2" system.
    /// </summary>
    IsComponentsV2 = 32768
}