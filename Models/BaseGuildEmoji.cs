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
/// Represents a base model for guild-specific emoji.
/// </summary>
/// <remarks>
/// The <c>BaseGuildEmoji</c> class provides core properties and attributes for emojis specific to a guild in the system.
/// It includes information such as unique identifiers, names, animation status, and availability within the guild.
/// </remarks>
public class BaseGuildEmoji : Base
{
    /// <summary>
    /// Gets or sets the unique identifier for the guild-specific emoji.
    /// </summary>
    /// <remarks>
    /// This property represents a Snowflake identifier, which ensures unique identification
    /// of the emoji within the context of a guild. It can be utilized for performing
    /// operations involving the emoji, such as retrieval or management.
    /// </remarks>
    public Snowflake Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the guild-specific emoji.
    /// </summary>
    /// <remarks>
    /// This property represents the display name for the emoji as defined within the guild context.
    /// It is used for identification, searching, and referencing the emoji in various operations.
    /// </remarks>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the emoji is animated.
    /// </summary>
    /// <remarks>
    /// This property determines if the guild-specific emoji has animation capabilities.
    /// An emoji marked as animated typically has dynamic visual elements, differentiating
    /// it from static emojis within the system.
    /// </remarks>
    public bool? Animated { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the emoji is available for use within the guild.
    /// </summary>
    /// <remarks>
    /// This property reflects the availability status of the guild-specific emoji. An emoji may
    /// be marked as unavailable if, for example, its associated external pack has been removed
    /// or permissions have been altered, impacting its usability within the guild context.
    /// </remarks>
    public bool? Available { get; set; }
}