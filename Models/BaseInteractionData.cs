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