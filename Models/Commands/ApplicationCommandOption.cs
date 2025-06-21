using System.Text.Json.Serialization;

namespace SharpCord.Models;

/// <summary>
/// Represents an option for an application command in a Discord interaction.
/// </summary>
public class ApplicationCommandOption
{
    /// <summary>
    /// Gets or sets the type of the application command option.
    /// Determines the kind of input this option represents, such as chat input, user, or message.
    /// </summary>
    [JsonPropertyName("type")]
    public ApplicationCommandType Type { get; set; }

    /// <summary>
    /// Gets or sets the name of the application command option.
    /// Represents the unique identifier for the option used in interactions.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the application command option.
    /// Provides a clear and concise explanation of what this command option does or represents.
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether this option is required.
    /// Specifies if the user must provide a value for this option when invoking the application command.
    /// </summary>
    [JsonPropertyName("required")]
    public bool? Required { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("choices")]
    public List<ApplicationCommandOptionChoice>? Choices { get; set; }

    /// <summary>
    /// Gets or sets a collection of additional options for this application command option.
    /// Enables nested sub-commands or sub-options, allowing for more complex command structures.
    /// </summary>
    [JsonPropertyName("options")]
    public List<ApplicationCommandOption>? Options { get; set; }

    /// <summary>
    /// Gets or sets the list of channel types that can be used with the application command option.
    /// Specifies the allowable types of channels, such as text, voice, or other types, for this option.
    /// </summary>
    [JsonPropertyName("channel_types")]
    public List<ChannelType>? ChannelTypes { get; set; }

    /// <summary>
    /// Gets or sets the minimum value for a numeric option in an application command.
    /// Defines the smallest acceptable value a user can provide for this input.
    /// </summary>
    [JsonPropertyName("min_value")]
    public double? MinValue { get; set; }

    /// <summary>
    /// Gets or sets the maximum value for the application command option.
    /// Specifies an upper limit for numeric input when applicable.
    /// </summary>
    [JsonPropertyName("max_value")]
    public double? MaxValue { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the option supports autocomplete functionality.
    /// If set to true, the application command option can provide dynamic suggestions
    /// depending on the user's input.
    /// </summary>
    [JsonPropertyName("autocomplete")]
    public bool? Autocomplete { get; set; }
}