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

using System.Text.Json.Serialization;
using SharpCord.Types;

namespace SharpCord.Models;

/// <summary>
/// Represents the base structure of an interaction within the Discord API.
/// </summary>
public class BaseInteraction
{
    /// <summary>
    /// Gets or sets the unique identifier for the interaction.
    /// </summary>
    /// <remarks>
    /// This property represents the ID of the interaction and is a key attribute
    /// used to distinguish it from other interactions within Discord.
    /// </remarks>
    [JsonPropertyName("id")]
    public Snowflake Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the application associated with the interaction.
    /// </summary>
    /// <remarks>
    /// This property specifies the ID of the application that the interaction is related to.
    /// It is used to correlate the interaction with its originating application.
    /// </remarks>
    [JsonPropertyName("application_id")]
    public Snowflake ApplicationId { get; set; }

    /// <summary>
    /// Gets or sets the interaction token.
    /// </summary>
    /// <remarks>
    /// This property represents a token used to continue an interaction or securely respond to a user's event in Discord.
    /// It is unique per interaction and should be kept confidential.
    /// </remarks>
    [JsonPropertyName("token")]
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the type of the interaction.
    /// </summary>
    /// <remarks>
    /// This property defines the category or nature of the interaction, represented by the <see cref="BaseInteractionType"/> enum.
    /// It specifies the context in which the interaction has occurred, such as commands, message components, or modal submissions.
    /// </remarks>
    [JsonPropertyName("type")]
    public BaseInteractionType Type { get; set; }

    /// <summary>
    /// Gets or sets the data associated with the interaction.
    /// </summary>
    /// <remarks>
    /// This property contains details specific to the interaction, such as commands or component information.
    /// It provides a structured way to access interaction-specific parameters.
    /// </remarks>
    [JsonPropertyName("data")]
    public BaseInteractionData? Data { get; set; } = null!;

    /// <summary>
    /// Gets or sets the identifier of the guild associated with the interaction.
    /// </summary>
    /// <remarks>
    /// This property represents the optional ID of the guild where the interaction took place.
    /// It is used to provide contextual information about the originating guild for the interaction.
    /// </remarks>
    [JsonPropertyName("guild_id")]
    public Snowflake? GuildId { get; set; }

    /// <summary>
    /// Gets or sets the identifier for the channel associated with the interaction.
    /// </summary>
    /// <remarks>
    /// This property represents the unique ID of the channel where the interaction occurred.
    /// It may be null if the interaction is not associated with a specific channel.
    /// </remarks>
    [JsonPropertyName("channel_id")]
    public Snowflake? ChannelId { get; set; }

    /// <summary>
    /// Gets or sets the guild member associated with the interaction.
    /// </summary>
    /// <remarks>
    /// This property represents a member of the guild (server) in the context of the interaction.
    /// It provides details such as the user's nickname, roles, join date, and other guild-specific attributes.
    /// This property is typically available when the interaction occurs within a guild context.
    /// </remarks>
    [JsonPropertyName("member")]
    public BaseGuildMember? Member { get; set; }

    /// <summary>
    /// Gets or sets the user information associated with the interaction.
    /// </summary>
    /// <remarks>
    /// This property holds a reference to a <c>BaseUser</c> object, representing
    /// the user who initiated or is involved in the interaction. It may contain
    /// details such as the user's ID, username, and other metadata.
    /// </remarks>
    [JsonPropertyName("user")]
    public BaseUser? User { get; set; }
}