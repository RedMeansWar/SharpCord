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
/// Represents the base builder class for constructing select menu components.
/// </summary>
/// <remarks>
/// This class provides core properties required to define the behavior and appearance of a select menu component,
/// such as identifiers, placeholders, value limits, and enabled/disabled state. It serves as a foundation
/// for more specific select menu implementations within the application.
/// </remarks>
public class BaseSelectMenuBuilder : Base
{
    /// <summary>
    /// Gets or sets the custom identifier associated with this select menu component.
    /// </summary>
    /// <remarks>
    /// This property uniquely identifies the select menu within the application or user interface, allowing
    /// developers to handle interaction events tied to this specific component. A value must be provided for
    /// proper functioning, and it is typically assigned during the construction of the menu.
    /// </remarks>
    public string CustomId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the placeholder text displayed in the select menu component when no option is selected.
    /// </summary>
    /// <remarks>
    /// This property defines the text shown to users as a hint or guide when the menu is in its default unselected state.
    /// It helps provide context or instructions, enhancing the user experience.
    /// The placeholder is typically a short, descriptive message or prompt.
    /// </remarks>
    public string Placeholder { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the minimum number of selectable options for this select menu component.
    /// </summary>
    /// <remarks>
    /// This property defines the lowest number of options that must be selected during interaction with the select menu.
    /// It is used to enforce selection rules by restricting interactions that do not meet the minimum requirement.
    /// The value must be a non-negative integer, and it is set to 1 by default.
    /// </remarks>
    public int MinValues { get; set; } = 1;

    /// <summary>
    /// Gets or sets the maximum number of values that can be selected in this select menu component.
    /// </summary>
    /// <remarks>
    /// This property defines the upper limit for the number of selectable options in the select menu.
    /// It ensures that users cannot choose more options than permitted. The default value is typically set to 1,
    /// but it can be adjusted based on the desired behavior for the menu functionality.
    /// </remarks>
    public int MaxValues { get; set; } = 1;

    /// <summary>
    /// Gets or sets a value indicating whether the select menu component is disabled.
    /// </summary>
    /// <remarks>
    /// When set to true, the select menu will be rendered as unavailable or non-interactive in the user interface.
    /// This property can be used to prevent user interaction with the component under certain conditions,
    /// such as when the menu is not applicable or awaiting a specific action.
    /// </remarks>
    public bool Disabled { get; set; } = false;
}