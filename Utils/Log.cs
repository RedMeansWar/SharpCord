namespace SharpCord.Utils;

/// <summary>
/// A static class providing logging utilities for various message levels including information, debug, warning, and error.
/// </summary>
public static class Log
{
    /// <summary>
    /// Logs an informational message to the console.
    /// </summary>
    /// <param name="message">The informational message to log.</param>
    public static void Info(string message) => Console.WriteLine($"[DISCORD INFO] {message}");

    /// <summary>
    /// Logs a debug message to the console.
    /// </summary>
    /// <param name="message">The debug message to log.</param>
    public static void Debug(string message) => Console.WriteLine($"[DISCORD DEBUG] {message}");

    /// <summary>
    /// Logs a warning message to the console.
    /// </summary>
    /// <param name="message">The warning message to log.</param>
    public static void Warning(string message) => Console.WriteLine($"[DISCORD WARNING] {message}");

    /// <summary>
    /// Logs an error message to the console.
    /// </summary>
    /// <param name="message">The error message to log.</param>
    public static void Error(string message) => Console.WriteLine($"[DISCORD ERROR] {message}");

    /// <summary>
    /// Logs an error message to the console.
    /// </summary>
    /// <param name="e">The exception containing the error details to log.</param>
    public static void Error(Exception e) => Console.WriteLine($"[DISCORD EXCEPTION ERROR] {e}\n{e.StackTrace}");
}
