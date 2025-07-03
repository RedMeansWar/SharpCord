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

using SharpCord.Models;
using SharpCord.Utils;

namespace SharpCord.Builders;

/// <summary>
/// A static builder class that provides methods to create and configure pagination components for UI interactions.
/// </summary>
public static class PaginationComponentBuilder
{
    /// <summary>
    /// Builds a row of pagination buttons, including "previous", "next", and "home" buttons.
    /// </summary>
    /// <param name="hasPrevious">Indicates whether the "previous" button should be enabled.</param>
    /// <param name="hasNext">Indicates whether the "next" button should be enabled.</param>
    /// <returns>
    /// An <see cref="ActionRow"/> containing the pagination buttons with appropriate configurations.
    /// </returns>
    public static ActionRow BuildPaginationButtons(bool hasPrevious, bool hasNext)
    {
        var row = new ActionRow();
        Pagination pages = new();

        row.Components.Add(new ButtonComponent
        {
            Style = ButtonStyle.Primary,
            Label = "⏪",
            CustomId = "pagination:start",
            Disabled = !hasPrevious && !hasNext
        });
        
        row.Components.Add(new ButtonComponent
        {
            Style = ButtonStyle.Primary,
            Label = "◀️",
            CustomId = "pagination:prev",
            Disabled = !hasPrevious
        });
        
        row.Components.Add(new ButtonComponent
        {
           Style = ButtonStyle.Link,
           Label = $"{pages.CurrentPage}/{pages.Pages.Count}",
           CustomId = "pagination:page",
           Disabled = true
        });
        
        row.Components.Add(new ButtonComponent
        {
            Style = ButtonStyle.Secondary,
            Label = "▶️",
            CustomId = "pagination:next",
            Disabled = !hasNext
        });
        
        row.Components.Add(new ButtonComponent
        {
            Style = ButtonStyle.Primary,
            Label = "⏩",
            CustomId = "pagination:end",
            Disabled = !hasPrevious && !hasNext
        });

        return row;
    }
}