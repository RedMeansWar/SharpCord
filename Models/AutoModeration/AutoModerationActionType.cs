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
/// Defines the types of actions that can be taken automatically in response to moderation triggers.
/// These actions are used to enforce server rules and maintain compliance with community guidelines.
/// See also: https://discord.com/developers/docs/resources/auto-moderation#auto-moderation-action-object-action-types
/// </summary>
public enum AutoModerationActionType
{
    /// <summary>
    /// Represents an action type in auto-moderation where a message is blocked from being posted.
    /// This action is commonly used to prevent rule-violating content from being displayed in the channel.
    /// </summary>
    BlockMessage = 1,

    /// <summary>
    /// Represents an action type in auto-moderation where an alert message is sent to a specified channel.
    /// This action is typically used to notify moderators or a specific audience
    /// about the details of a detected rule violation or event.
    /// </summary>
    SendAlertMessage = 2,

    /// <summary>
    /// Represents an action type in auto-moderation where a user is temporarily restricted from interacting.
    /// This action is typically used to enforce time-bound restrictions for violating specific rules or guidelines.
    /// </summary>
    Timeout = 3,

    /// <summary>
    /// Represents an action type in auto-moderation where interactions initiated by a member are blocked.
    /// This is typically used to restrict specific members from interacting with others or performing certain actions.
    /// </summary>
    BlockMemberInteraction = 4
}