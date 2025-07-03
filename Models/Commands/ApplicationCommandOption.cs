#region LICENSE
// Copyright (c) 2025 RedMeansWar
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System.Text.Json.Serialization;

namespace SharpCord.Models;

/// <summary>
/// Represents an option for an application command in a Discord interaction.
/// </summary>
public class ApplicationCommandOption
{
    /// <summary>
    /// Gets or sets the type of the application command option.
    /// Specifies the kind of data that the option represents, such as string, integer, boolean, user, etc.
    /// </summary>
    [JsonPropertyName("type")]
    public ApplicationCommandOptionType Type { get; set; }

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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Required { get; set; } = false;
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("choices")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ApplicationCommandOptionChoice>? Choices { get; set; }

    /// <summary>
    /// Gets or sets a collection of additional options for this application command option.
    /// Enables nested sub-commands or sub-options, allowing for more complex command structures.
    /// </summary>
    [JsonPropertyName("options")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ApplicationCommandOption>? Options { get; set; }

    /// <summary>
    /// Gets or sets the list of channel types that can be used with the application command option.
    /// Specifies the allowable types of channels, such as text, voice, or other types, for this option.
    /// </summary>
    [JsonPropertyName("channel_types")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ChannelType>? ChannelTypes { get; set; }

    /// <summary>
    /// Gets or sets the minimum value for a numeric option in an application command.
    /// Defines the smallest acceptable value a user can provide for this input.
    /// </summary>
    [JsonPropertyName("min_value")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinValue { get; set; }

    /// <summary>
    /// Gets or sets the maximum value for the application command option.
    /// Specifies an upper limit for numeric input when applicable.
    /// </summary>
    [JsonPropertyName("max_value")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxValue { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the option supports autocomplete functionality.
    /// If set to true, the application command option can provide dynamic suggestions
    /// depending on the user's input.
    /// </summary>
    [JsonPropertyName("autocomplete")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Autocomplete { get; set; } = false;
}