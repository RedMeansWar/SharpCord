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

using SharpCord.Models;
using SharpCord.Types;

namespace SharpCord.Interfaces;

/// <summary>
/// Represents the options for configuring message mentions.
/// </summary>
/// <remarks>
/// This interface defines properties that allow the specification of which entities are mentioned in a message,
/// including users, roles, and related settings. It is typically used in sending or handling messages within the application.
/// </remarks>
public interface IMessageMentionOptions
{
    /// <summary>
    /// Specifies the mention types that should be included in a message.
    /// </summary>
    /// <remarks>
    /// This property defines which components, such as users, roles, or everyone, will be parsed for mentions in the message.
    /// It enables selective mention behavior when constructing or sending messages.
    /// </remarks>
    IReadOnlyList<string>? Parse { get; }

    /// <summary>
    /// Determines whether the replied message should be mentioned in the message.
    /// </summary>
    /// <remarks>
    /// This property specifies if a message reply should trigger a mention notification to the original message's author.
    /// When set to true, the author of the replied message will be notified.
    /// </remarks>
    bool? Replied { get; }

    /// <summary>
    /// Gets a collection of role identifiers to be mentioned in the message.
    /// </summary>
    /// <remarks>
    /// Each identifier is represented as a Snowflake, which is a 64-bit unique identifier.
    /// This property allows an optional list of roles to be directly mentioned in the message.
    /// </remarks>
    IReadOnlyList<Snowflake>? Roles { get; }

    /// <summary>
    /// Gets a collection of user identifiers to be mentioned in the message.
    /// </summary>
    /// <remarks>
    /// Each identifier is represented as a Snowflake, which is a 64-bit unique identifier.
    /// This property allows an optional list of users to be directly mentioned in the message.
    /// </remarks>
    IReadOnlyList<Snowflake>? Users { get; }
}