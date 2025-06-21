using System.Text.Json.Serialization;
using SharpCord.Interfaces;

namespace SharpCord.Models;

/// <summary>
/// Represents a modal structure used in interactions for user input or actions.
/// </summary>
public class Modal
{
    /// <summary>
    /// Gets or sets the title of the modal. The title is displayed as the heading of the modal window
    /// and provides context or describes the purpose of the modal.
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the custom identifier for the modal. This identifier is used to
    /// uniquely associate the modal with specific interactions or responses.
    /// </summary>
    [JsonPropertyName("custom_id")]
    public string CustomId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the collection of action rows within the modal. Each action row contains interactive components such as buttons or input fields that allow user interaction.
    /// </summary>
    [JsonPropertyName("components")]
    public List<IComponent> Components { get; set; } = new();

    /// <summary>
    /// Gets or sets the type of the component in the modal. This indicates the category or role
    /// of the component within the user interface structure.
    /// </summary>
    [JsonPropertyName("type")]
    public ComponentType Type { get; set; } = ComponentType.Section;
}