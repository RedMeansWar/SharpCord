namespace SharpCord.Models;

/// <summary>
/// Represents a set of distinct close codes that indicate the reasons for the closure of a WebSocket connection.
/// </summary>
public enum CloseCodes
{
    /// <summary>
    /// Indicates a standard closure of the connection, signifying that the process was completed successfully
    /// without any unexpected interruptions or errors.
    /// </summary>
    Normal = 1000,

    /// <summary>
    /// Indicates that the connection is being closed with the intent to resume it, allowing continuation
    /// without starting a new session or losing the current state.
    /// </summary>
    Resuming = 4200
}