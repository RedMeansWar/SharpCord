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

namespace SharpCord.Models;

/// <summary>
/// Represents the base functionality for a select menu component in an interactive system.
/// </summary>
public class BaseSelectMenuComponent
{
    /// <summary>
    /// Gets or sets the display text for the select menu component.
    /// This property determines the visible label that users interact with in the menu.
    /// </summary>
    public string Label { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the value associated with the select menu component.
    /// This property signifies the internal identifier used to process the user's selection when the component is interacted with.
    /// </summary>
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the descriptive text for the select menu component.
    /// This property provides additional context or explanation about the menu's purpose or options.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the emoji displayed alongside the select menu's label.
    /// This property defines a visual icon that enhances context or user recognition.
    /// </summary>
    public string? Emoji { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this select menu component is set as the default option.
    /// This property determines if the option is pre-selected when the menu is displayed to the user.
    /// </summary>
    public bool Default { get; set; }
}