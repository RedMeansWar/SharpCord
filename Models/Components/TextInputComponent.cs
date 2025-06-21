using System.Text.Json.Serialization;
using SharpCord.Interfaces;

namespace SharpCord.Models;

/// <summary>
/// Represents a text input component in a user interface. This component is primarily used
/// for collecting text-based input from users. It supports customization options such as
/// defining the input style, maximum and minimum character length, and placeholder text.
/// </summary>
public class TextInputComponent : IComponent
{
    /// Gets or sets the type of the component.
    /// This property indicates the type of the component and is set to ComponentType.TextInput (4) by default.
    [JsonPropertyName("type")]
    public ComponentType Type { get; set; } = ComponentType.TextInput;

    /// Gets or sets the custom identifier for the component.
    /// This property is used to uniquely identify the component in the context of interactions.
    [JsonPropertyName("custom_id")]
    public string CustomId { get; set; } = string.Empty;

    /// Gets or sets the style of the text input component.
    /// This property determines the visual presentation and behavior of the text input, and can
    /// take values such as `Short` for a single-line input or `Paragraph` for a multi-line input.
    /// The default value is `Short`.
    [JsonPropertyName("style")]
    public TextInputStyle Style { get; set; } = TextInputStyle.Short;

    /// Gets or sets the label of the text input component.
    /// This property defines the visible text displayed alongside the input box,
    /// providing context or instructions to users about the expected input.
    /// <remarks>Maximum characters for a title are 45 characters.</remarks>
    [JsonPropertyName("label")]
    public string Label { get; set; } = string.Empty;

    /// Gets or sets the minimum number of characters that the user must enter in the text input.
    /// This property is used to enforce a lower character limit for the input field. If not specified,
    /// there is no minimum character constraint.
    [JsonPropertyName("min_length")]
    public int? MinLength { get; set; }

    /// Gets or sets the maximum number of characters that can be input in the text field.
    /// This property allows you to define the upper limit for the character count of the user's input.
    /// If not set, there is no restriction on the maximum input length.
    [JsonPropertyName("max_length")]
    public int? MaxLength { get; set; }

    /// Gets or sets a value indicating whether the input field is required.
    /// This property determines if the user must complete the text input
    /// before submission. If set to true, the input will be marked as mandatory.
    [JsonPropertyName("required")]
    public bool? Required { get; set; }

    /// Gets or sets the pre-filled text value of the input field.
    /// This property represents the default text that will be displayed
    /// in the text input component when it is initially rendered.
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    /// Gets or sets the placeholder text for the text input component.
    /// This property defines a short hint that describes the expected input
    /// or provides a sample value to guide the user before they enter text.
    [JsonPropertyName("placeholder")]
    public string? Placeholder { get; set; }
}