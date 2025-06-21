using System.Text.Json.Serialization;

namespace SharpCord.Models;

/// <summary>
/// Represents a field in an embed, consisting of a name, value, and an optional
/// flag indicating whether the field should be displayed inline.
/// </summary>
public class EmbedField
{
    /// <summary>
    /// Gets or sets the name of the embed field.
    /// This is typically a string representing the field's title or heading.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the value of the embed field.
    /// This is typically a string containing the main content or information of the field.
    /// </summary>
    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the embed field is displayed inline
    /// with other fields. When set to true, the field will be aligned horizontally
    /// with other inline fields.
    /// </summary>
    [JsonPropertyName("inline")]
    public bool Inline { get; set; }
}