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