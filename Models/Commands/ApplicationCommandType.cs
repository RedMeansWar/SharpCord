namespace SharpCord.Models;

/// <summary>
/// Defines the different types of application commands that can be used.
/// </summary>
public enum ApplicationCommandType
{
    /// <summary>
    /// Represents a slash command type specifically for chat input commands.
    /// These commands are triggered by slash "/" followed by user-defined or pre-defined command keywords.
    /// </summary>
    ChatInput = 1,

    /// <summary>
    /// Represents a user command type, allowing interactions directly with a specific user.
    /// These commands are typically context menu options available for user entities.
    /// </summary>
    User = 2,

    /// <summary>
    /// Represents a command type associated with messages.
    /// These commands are typically contextual, operating directly on messages within the application.
    /// </summary>
    Message = 3,

    /// <summary>
    /// 
    /// </summary>
    PrimaryEntryPoint = 4,
}