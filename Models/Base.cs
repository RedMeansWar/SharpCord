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
/// Represents the base class for models.
/// </summary>
/// <remarks>
/// This abstract class provides common properties and functionality for derived models, such as an identifier,
/// creation timestamp, and raw JSON representation. It serves as a foundation for other model entities.
/// </remarks>
public class Base
{
    /// <summary>
    /// Gets or sets the unique identifier for this object.
    /// </summary>
    /// <remarks>
    /// This property represents a Snowflake identifier, which is a globally unique 64-bit value. It encapsulates
    /// metadata such as the creation timestamp. The identifier can be used for comparison, serialization, and
    /// referencing this object.
    /// </remarks>
    public Snowflake Id { get; set; }

    /// <summary>
    /// Gets or sets the raw JSON representation of this object.
    /// </summary>
    /// <remarks>
    /// This property typically contains the unprocessed JSON string representation of the object. It may be used for debugging, logging, or serialization purposes.
    /// Custom processing or modifications of this value can impact deserialization or later operations.
    /// </remarks>
    public virtual string? RawJson { get; set; }

    /// <summary>
    /// Gets the timestamp indicating when the Discord entity was created.
    /// </summary>
    /// <remarks>
    /// This property retrieves the creation date and time based on the Snowflake identifier's embedded timestamp.
    /// The timestamp is derived using Discord's epoch and the Snowflake's unique value.
    /// </remarks>
    public virtual DateTimeOffset CreatedAt => Id.CreatedAt;

    /// <summary>
    /// Returns a string representation of the current instance.
    /// </summary>
    /// <returns>
    /// A string that represents this instance, including the type name and its unique identifier.
    /// </returns>
    public override string ToString() => $"{GetType().Name} ({Id})";
}