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
/// Represents the type of event that can trigger an auto-moderation rule in a system.
/// See also: https://discord.com/developers/docs/resources/auto-moderation#auto-moderation-rule-object-event-types
/// </summary>
public enum AutoModerationRuleEventType
{
    /// <summary>
    /// Represents an event type triggered when a user sends a message.
    /// This event type is used for defining auto-moderation rules that
    /// react to messages sent in Discord.
    /// </summary>
    MessageSend = 1,

    /// <summary>
    /// Represents an event type triggered when a member's details are updated.
    /// This event type is used for defining auto-moderation rules that
    /// respond to changes in member information within Discord.
    /// </summary>
    MemberUpdate = 2
}