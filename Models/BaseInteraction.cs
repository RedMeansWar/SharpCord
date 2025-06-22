using System.Text.Json.Serialization;

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
    public string Id { get; set; } = null!;

    /// <summary>
    /// Gets or sets the unique identifier of the application associated with the interaction.
    /// </summary>
    /// <remarks>
    /// This property specifies the ID of the application that the interaction is related to.
    /// It is used to correlate the interaction with its originating application.
    /// </remarks>
    [JsonPropertyName("application_id")]
    public string ApplicationId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the interaction token.
    /// </summary>
    /// <remarks>
    /// This property represents a token used to continue an interaction or securely respond to a user's event in Discord.
    /// It is unique per interaction and should be kept confidential.
    /// </remarks>
    [JsonPropertyName("token")]
    public string Token { get; set; } = null!;

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
    public string? GuildId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the channel associated with the interaction.
    /// </summary>
    /// <remarks>
    /// This property represents the optional ID of the channel where the interaction occurred.
    /// It is used to provide contextual information about the interaction's origin channel.
    /// </remarks>
    [JsonPropertyName("channel_id")]
    public string? ChannelId { get; set; }
}