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
/// Represents a button component used in building interactive Discord message components.
/// </summary>
public class ButtonComponent : IComponent
{
    /// <summary>
    /// Gets or sets the type of the component.
    /// </summary>
    /// <value>
    /// An integer representing the type of the component, usually corresponding
    /// to values defined in the <see cref="ComponentType"/> enumeration.
    /// This property helps identify the nature or purpose of the component,
    /// such as whether it is a button, select a menu, or another type.
    /// </value>
    [JsonPropertyName("type")]
    public ComponentType Type { get; set; }

    /// <summary>
    /// Gets or sets the style of the button component.
    /// </summary>
    /// <value>
    /// A value of the <see cref="ButtonStyle"/> enumeration that determines the visual style and behavior of the button.
    /// The style can represent various predefined button types such as Primary, Secondary, Success, Danger, Link, or Premium.
    /// </value>
    [JsonPropertyName("style")]
    public ButtonStyle Style { get; set; }

    /// <summary>
    /// Gets or sets the label text displayed on this button component.
    /// </summary>
    /// <value>
    /// A string representing the text to be displayed on the button. This text is visible to users and typically provides context
    /// to the button's function. An empty string or <c>null</c> value indicates the button does not have a label.
    /// </value>
    [JsonPropertyName("label")]
    public string Label { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the custom identifier associated with this button component.
    /// </summary>
    /// <value>
    /// A string representing a unique ID for the button interaction. This identifier is used to differentiate between button interactions and
    /// can be passed back in events or callbacks to handle specific user actions.
    /// A <c>null</c> or empty string value indicates the button lacks an associated custom identifier.
    /// </value>
    [JsonPropertyName("custom_id")]
    public string CustomId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the emoji associated with this button component.
    /// </summary>
    /// <value>
    /// An object representing the emoji displayed on the button component.
    /// It could include properties such as emoji name or ID, supporting both standard Unicode emojis and custom server emojis.
    /// A <c>null</c> value indicates no emoji is set for the button.
    /// </value>
    [JsonPropertyName("emoji")]
    public object? Emoji { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this button component is disabled.
    /// </summary>
    /// <value>
    /// A boolean value indicating the disabled state of the button component.
    /// If set to <c>true</c>, the button is disabled and cannot be interacted with.
    /// If set to <c>false</c>, the button is enabled and interactive.
    /// This property is nullable, where a <c>null</c> value implies no specific disabled state is assigned.
    /// </value>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}