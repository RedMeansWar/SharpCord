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

using SharpCord.Interfaces;
using SharpCord.Models;

namespace SharpCord.Builders;

/// <summary>
/// Represents a builder for creating Discord modals, enabling customization of
/// the modal's title, custom identifier, and contained interactive components.
/// </summary>
public class ModalBuilder
{
    internal readonly List<IComponent> _components = new();

    /// <summary>
    /// Gets or sets the title of the modal. This value represents the header text displayed at the top of the modal.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the unique identifier for the modal. This value is used to distinguish the modal in interaction events.
    /// </summary>
    public string CustomId { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="label"></param>
    /// <param name="customId"></param>
    /// <param name="style"></param>
    /// <param name="placeholder"></param>
    /// <param name="required"></param>
    /// <returns></returns>
    public ModalBuilder AddInput(string label, string customId, TextInputStyle style = TextInputStyle.Short, string? placeholder = null, bool required = true)
    {
        _components.Add(new TextInputComponent
        {
            Label = label,
            CustomId = customId,
            Style = style,
            Placeholder = placeholder,
            Required = required
        });

        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Modal Build() => new() { Components = _components };
}