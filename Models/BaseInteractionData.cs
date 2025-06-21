using System.Text.Json.Serialization;

namespace SharpCord.Models;

/// <summary>
/// Represents the data associated with an interaction in the Discord API.
/// </summary>
public class BaseInteractionData
{
    /// <summary>
    /// Gets or sets the unique identifier for the interaction.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the interaction.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the type of the application command associated with the interaction.
    /// </summary>
    [JsonPropertyName("type")]
    public ApplicationCommandType Type { get; set; }

    /// <summary>
    /// Gets or sets the list of options for the interaction command,
    /// which may include nested options or choices for the command.
    /// </summary>
    [JsonPropertyName("options")]
    public List<ApplicationCommandOption>? Options { get; set; }

    /// <summary>
    /// Gets or sets the custom identifier for the interaction, primarily used to differentiate specific components within the interaction context.
    /// </summary>
    [JsonPropertyName("custom_id")]
    public string? CustomId { get; set; }

    /// <summary>
    /// Gets or sets the type of component associated with the interaction.
    /// </summary>
    [JsonPropertyName("component_type")]
    public ComponentType? ComponentType { get; set; }

    /// <summary>
    /// Gets or sets the list of selected values for the interaction component.
    /// </summary>
    [JsonPropertyName("values")]
    public List<string>? Values { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the target entity for the interaction.
    /// </summary>
    [JsonPropertyName("target_id")]
    public string? TargetId { get; set; }
}