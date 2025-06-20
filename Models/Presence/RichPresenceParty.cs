namespace SharpCord.Models;

/// <summary>
/// Represents a party associated with a rich presence in an application.
/// </summary>
public class RichPresenceParty
{
    /// <summary>
    /// Gets or sets the unique identifier for the party associated with the rich presence.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the size of the party, including the current and maximum member count.
    /// </summary>
    public int[] Size { get; set; } = [];
}