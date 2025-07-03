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

using SharpCord.Types;

namespace SharpCord.Models;

/// <summary>
/// Represents a text-based channel within a guild in the Discord environment.
/// Extends the functionality of the base channel to provide additional properties
/// specific to text channels in guilds.
/// </summary>
/// <remarks>
/// Includes properties for managing text channels such as their parent category,
/// rate limits on user message sending, and whether the channel is a news channel.
/// </remarks>
public class BaseGuildTextChannel : BaseChannel
{
    /// <summary>
    /// Gets or sets the Snowflake identifier of the parent category for the text channel.
    /// </summary>
    /// <remarks>
    /// This property holds the ID of the parent category that the text channel belongs to,
    /// or <c>null</c> if the channel does not belong to any category.
    /// </remarks>
    public Snowflake? ParentId { get; set; }

    /// <summary>
    /// Gets or sets the rate limit per user for the text channel in seconds.
    /// </summary>
    /// <remarks>
    /// This property specifies the time a user must wait before sending another message
    /// in the channel. It is measured in seconds and is used to enforce a per-user cooldown.
    /// A value of <c>0</c> indicates that no rate limit is imposed on users.
    /// </remarks>
    public int RateLimitPerUser { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the text channel is a news channel.
    /// </summary>
    /// <remarks>
    /// A value of <c>true</c> means the channel is set as a news channel, allowing members
    /// to follow it to receive updates in their own servers. A value of <c>false</c> or
    /// <c>null</c> indicates it is not configured as a news channel.
    /// </remarks>
    public bool? IsNews { get; set; }
}