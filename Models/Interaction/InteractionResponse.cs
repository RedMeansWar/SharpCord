using System.Text.Json.Serialization;

namespace SharpCord.Models;

/// <summary>
/// Represents the response to an interaction, such as a command or an event, received by the Discord API.
/// It specifies the type of response and optional data associated with the response.
/// </summary>
public class InteractionResponse
{
    /// <summary>
    /// Gets or sets the type of the interaction response.
    /// This property determines the specific response behavior, which is represented by the <see cref="InteractionResponseType"/> enum.
    /// </summary>
    [JsonPropertyName("type")]
    public InteractionResponseType Type { get; set; }

    /// <summary>
    /// Represents the optional callback data included in an interaction response.
    /// This property contains information such as content or embeds to be sent as part of the interaction's reply.
    /// </summary>
    [JsonPropertyName("data")]
    public ApplicationCommandCallbackData? Data { get; set; }
}