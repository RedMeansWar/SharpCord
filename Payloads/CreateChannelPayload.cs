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

namespace SharpCord.Payloads;

/// <summary>
/// Represents the payload required to create a new channel.
/// </summary>
public class CreateChannelPayload
{
    /// <summary>
    /// Gets or sets the name of the channel to be created.
    /// </summary>
    /// <remarks>
    /// The name is a mandatory property that identifies the channel.
    /// It should be a non-empty string, typically following the naming conventions of the platform.
    /// </remarks>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the type of channel to be created.
    /// </summary>
    /// <remarks>
    /// Specifies the channel type, which determines the behavior and functionality of the channel.
    /// This property is optional and defaults to a text channel for guilds if not explicitly set.
    /// </remarks>
    public ChannelType? Type { get; set; } = ChannelType.GuildText;

    /// <summary>
    /// Gets or sets the topic of the channel to be created.
    /// </summary>
    /// <remarks>
    /// The topic provides a brief description of the channel's purpose or content.
    /// It is typically a string that can be displayed in the channel header and should
    /// adhere to the platform's character and formatting guidelines.
    /// </remarks>
    public string? Topic { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the channel is marked as not safe for work (NSFW).
    /// </summary>
    /// <remarks>
    /// This property allows you to specify if the channel is intended for adult content or sensitive material.
    /// The default value is <c>false</c>, meaning the channel is not considered NSFW.
    /// </remarks>
    public bool? Nsfw { get; set; } = false;

    /// <summary>
    /// Gets or sets the bitrate for the voice channel to be created.
    /// </summary>
    /// <remarks>
    /// The bitrate determines the audio quality of the voice channel. It is typically measured in bits per second (bps).
    /// This property is applicable only to voice channels and should comply with the limits set by the platform or server.
    /// A valid range of bitrate must be ensured to avoid errors during channel creation.
    /// </remarks>
    public int? Bitrate { get; set; } = 0;

    /// <summary>
    /// Gets or sets the maximum number of users allowed in the channel.
    /// </summary>
    /// <remarks>
    /// This property determines the upper limit of users that can join the channel concurrently.
    /// A value of 0 indicates no user limit is imposed, allowing unlimited users to join.
    /// Define this property appropriately based on the channel's intended capacity.
    /// </remarks>
    public int? UserLimit { get; set; } = 0;

    /// <summary>
    /// Gets or sets the identifier of the parent channel or category.
    /// </summary>
    /// <remarks>
    /// This property determines the parent under which the new channel is organized.
    /// It should be set to a valid channel or category ID if the channel is intended to
    /// exist within a specific grouping or hierarchy.
    /// </remarks>
    public string? ParentId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the position of the channel within its category or list.
    /// </summary>
    /// <remarks>
    /// The position determines the visual order of the channel relative to others in the same category or collection.
    /// A lower value generally means the channel appears higher in the list.
    /// </remarks>
    public int? Position { get; set; } = 0;
}