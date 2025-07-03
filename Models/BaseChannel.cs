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
/// Represents a base channel within a guild or other location in a Discord environment.
/// Provides common properties shared across various channel types.
/// </summary>
public class BaseChannel : Base
{
    /// <summary>
    /// Gets or sets the unique identifier for the channel, represented as a Snowflake.
    /// </summary>
    /// <remarks>
    /// This property uniquely identifies a channel within the Discord-like environment.
    /// Snowflake identifiers are guaranteed to be unique across all entities.
    /// </remarks>
    public Snowflake Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the channel.
    /// </summary>
    /// <remarks>
    /// This property represents the display name of the channel,
    /// which is used to identify it within the Discord-like environment.
    /// The name is typically unique within a guild but not guaranteed globally unique.
    /// </remarks>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the type of the channel, represented by the ChannelType enumeration.
    /// </summary>
    /// <remarks>
    /// This property indicates the functional or structural category of the channel,
    /// such as text, voice, or other specific types defined in the ChannelType enumeration.
    /// </remarks>
    public ChannelType Type { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the guild associated with this channel, represented as a Snowflake.
    /// </summary>
    /// <remarks>
    /// This property links the channel to its parent guild in a Discord-like environment.
    /// Snowflake identifiers ensure uniqueness across all guilds.
    /// </remarks>
    public Snowflake GuildId { get; set; }

    /// <summary>
    /// Gets or sets the position of the channel relative to other channels in the same category or guild.
    /// </summary>
    /// <remarks>
    /// This property determines the order of the channel when displayed in a client.
    /// A lower value indicates a higher placement in the channel list hierarchy.
    /// </remarks>
    public int Position { get; set; }

    /// <summary>
    /// Gets or sets the topic of the channel, providing a brief description or purpose.
    /// </summary>
    /// <remarks>
    /// The topic is typically used to inform users about the primary focus or rules of the channel.
    /// It can be null if no topic is assigned.
    /// </remarks>
    public string? Topic { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the channel is marked as Not Safe for Work (NSFW).
    /// </summary>
    /// <remarks>
    /// This property determines if the channel contains content considered inappropriate for younger audiences
    /// and is intended for mature discussions or media.
    /// </remarks>
    public bool? Nsfw { get; set; }
}