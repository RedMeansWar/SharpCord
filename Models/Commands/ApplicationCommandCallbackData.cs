using System.Text.Json.Serialization;

namespace SharpCord.Models;

/// <summary>
/// Represents the callback data sent in response to an application command interaction.
/// </summary>
public class ApplicationCommandCallbackData
{
    /// <summary>
    /// Gets or sets the main content of the response sent in an application command interaction.
    /// </summary>
    /// <remarks>
    /// This property contains the textual content to be displayed in the interaction response.
    /// </remarks>
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    /// <summary>
    /// Gets or sets a collection of embed objects included in the response sent in an application command interaction.
    /// </summary>
    /// <remarks>
    /// This property contains a list of embeds used to provide rich visual or textual content in the interaction response.
    /// </remarks>
    [JsonPropertyName("embeds")]
    public List<Embed>? Embeds { get; set; }

    /// <summary>
    /// Gets or sets a list of action rows containing interactive components.
    /// </summary>
    /// <remarks>
    /// This property is used to include interactive components such as buttons or select menus
    /// within the response of an application command interaction.
    /// </remarks>
    [JsonPropertyName("components")]
    public List<ActionRow>? Components { get; set; }

    /// <summary>
    /// Gets or sets the flags associated with the response message in an application command interaction.
    /// </summary>
    /// <remarks>
    /// This property specifies various attributes or states that can be applied to the message,
    /// such as whether it is ephemeral, suppresses embeds, or has other specific behaviors.
    /// </remarks>
    [JsonPropertyName("flags")]
    public MessageFlags? Flags { get; set; }
}