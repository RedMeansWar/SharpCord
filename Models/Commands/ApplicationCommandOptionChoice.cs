using System.Text.Json.Serialization;

namespace SharpCord.Models;

/// <summary>
/// Represents a choice for an application command option.
/// </summary>
public class ApplicationCommandOptionChoice
{
    /// <summary>
    /// Gets or sets the name of the application command option choice.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("value")] 
    public object Value { get; set; } = null!;
}