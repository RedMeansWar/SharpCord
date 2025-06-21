using System.Text.Json.Serialization;
using SharpCord.Interfaces;

namespace SharpCord.Models;

/// <summary>
/// Represents a Discord Action Row, a container for interactive components such as buttons.
/// </summary>
public class ActionRow
{
    /// <summary>
    /// Gets or sets the type of the component. This property indicates the kind of component
    /// being represented, such as an Action Row or Button. Its value helps the Discord API
    /// identify and process the component accordingly.
    /// </summary>
    [JsonPropertyName("type")]
    public ComponentType Type { get; set; }

    /// <summary>
    /// Gets or sets the collection of interactive components contained within the action row. These components
    /// can include buttons, allowing for user interaction within a Discord message context. Each component
    /// is represented as a button or other compatible element.
    /// </summary>
    [JsonPropertyName("components")]
    public List<IComponent> Components { get; set; } = new();
}