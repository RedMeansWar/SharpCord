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
/// Represents a client in the SharpCord library.
/// </summary>
/// <remarks>
/// The BaseClient class encapsulates the identification, metadata, and attributes of a client entity.
/// It inherits from the Base class and provides additional properties such as the client's name,
/// discriminator, avatar, and whether the client is a bot.
/// </remarks>
public class BaseClient : Base
{
    /// <summary>
    /// Gets or sets the name associated with the client instance.
    /// </summary>
    /// <remarks>
    /// This property represents the name of the client instance as a string. It is used to
    /// identify or describe the client in a human-readable way.
    /// </remarks>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the unique identifier for the entity, represented as a <see cref="SharpCord.Types.Snowflake"/>.
    /// </summary>
    /// <remarks>
    /// The identifier is represented using a Snowflake, which is a 64-bit unsigned integer
    /// encoding information such as a timestamp and worker ID for uniqueness.
    /// </remarks>
    public Snowflake Id { get; set; }

    /// <summary>
    /// Gets or sets the discriminator associated with the client, usually used to distinguish entities with the same name.
    /// </summary>
    /// <remarks>
    /// The discriminator is often represented as a four-digit string appended to the name (e.g., "1234") and is primarily used
    /// to differentiate users or entities with identical display names in the system.
    /// </remarks>
    public string Discriminator { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the URL or hash representing the avatar of the client, if available.
    /// </summary>
    /// <remarks>
    /// The property contains a nullable string value, which represents the URL or unique hash of the client's avatar.
    /// If no avatar is set, this property will be <c>null</c>.
    /// </remarks>
    public string? Avatar { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the client represents a bot account.
    /// </summary>
    /// <remarks>
    /// This property determines if the client is a bot, as opposed to a regular user.
    /// Bots typically interact with the application programmatically and may have different permissions
    /// or functionality compared to user accounts.
    /// </remarks>
    public bool IsBot { get; set; }
}