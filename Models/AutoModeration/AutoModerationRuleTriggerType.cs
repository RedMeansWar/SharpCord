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
/// Defines the various types of triggers for auto-moderation rules.
/// These triggers determine the conditions under which an auto-moderation rule is activated.
/// </summary>
public enum AutoModerationRuleTriggerType
{
    /// <summary>
    /// Represents a trigger type for an auto-moderation rule based on specific keywords.
    /// This trigger activates when a message contains specified keywords.
    /// <remarks>Check if content contains words from a user-defined list of keywords (Maximum of 6 per guild)</remarks>
    /// </summary>
    Keyword = 1,

    /// <summary>
    /// Represents a trigger type for an auto-moderation rule that detects spam.
    /// This trigger activates when a message is identified as spam based on predefined moderation criteria.
    /// <remarks>Check if content represents generic spam (Maximum of 1 per guild)</remarks>
    /// </summary>
    Spam = 3,

    /// <summary>
    /// Represents a trigger type for an auto-moderation rule that uses predefined sets of keywords.
    /// This trigger activates when a message matches conditions defined by these preset keyword sets.
    /// <remarks>Check if content contains words from internal pre-defined wordsets (Maximum of 1 per guild)</remarks>
    /// </summary>
    KeywordPreset = 4,

    /// <summary>
    /// Represents a trigger type for an auto-moderation rule that targets excessive mentions in a message.
    /// This trigger activates when a message includes a high number of users, role, or everyone mentions that are considered spam.
    /// <remarks>Check if content contains more mentions than allowed (Maximum of 1 per guild)</remarks>
    /// </summary>
    MentionSpam = 5,

    /// <summary>
    /// Represents a trigger type for an auto-moderation rule based on the profile of a member.
    /// This trigger activates when specific conditions related to a member's profile are met.
    /// <remarks>Check if a member profile contains words from a user-defined list of keywords (Maximum of 1 per guild)</remarks>
    /// </summary>
    MemberProfile = 6
}