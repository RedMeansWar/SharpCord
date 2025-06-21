using SharpCord.Models;

namespace SharpCord.Utils;

/// <summary>
/// Represents a utility class for managing and navigating a collection of embed pages with pagination functionalities.
/// </summary>
public class Pagination
{
    /// <summary>
    /// Gets or sets the current page index in the pagination system.
    /// The index represents the position of the page currently being viewed,
    /// starting at 0, and is used to access the relevant page from the collection of pages.
    /// </summary>
    public int CurrentPage { get; private set; }

    /// <summary>
    /// Gets the collection of pages represented as a list of <see cref="Embed"/> objects.
    /// Each page contains content encapsulated within the embed structure.
    /// This property is initialized during the instantiation of the <see cref="Pagination"/> class
    /// and cannot be modified externally.
    /// </summary>
    public List<Embed> Pages { get; private set; }

    /// <summary>
    /// Provides pagination functionality for managing a collection of embed pages.
    /// </summary>
    public Pagination(IEnumerable<Embed> pages) => Pages = pages.ToList();

    /// <summary>
    /// Retrieves the currently selected embed page based on the current page index.
    /// </summary>
    /// <returns>The embed page corresponding to the current page index.</returns>
    public Embed GetCurrentPage() => Pages[CurrentPage];

    /// <summary>
    /// Gets a value indicating whether there is a next page available in the pagination system.
    /// This property checks if the current page index is less than the total number of pages minus one,
    /// enabling forward navigation within the collection of pages.
    /// </summary>
    public bool HasNextPage => CurrentPage < Pages.Count - 1;

    /// <summary>
    /// Indicates whether there is a previous page available in the pagination sequence.
    /// Returns true if the current page index is greater than 0, meaning prior pages exist.
    /// </summary>
    public bool HasPreviousPage => CurrentPage > 0;

    /// <summary>
    /// Provides pagination functionality to handle a collection of pages represented by embeds.
    /// </summary>
    public Pagination()
    {
    }

    /// <summary>
    /// Advances to the next embed page if available and updates the current page index.
    /// </summary>
    /// <returns>The embed page corresponding to the updated current page index.</returns>
    public Embed NextPage()
    {
        if (HasNextPage)
            CurrentPage++;

        return GetCurrentPage();
    }

    /// <summary>
    /// Moves to the previous embed page if available and updates the current page index.
    /// </summary>
    /// <returns>The embed page corresponding to the updated current page index.</returns>
    public Embed PreviousPage()
    {
        if (HasPreviousPage)
            CurrentPage--;
        
        return GetCurrentPage();
    }

    /// <summary>
    /// Resets the current page index to the initial state (first page).
    /// </summary>
    public void Reset() => CurrentPage = 0;
}