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