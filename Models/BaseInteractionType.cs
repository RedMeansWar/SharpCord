namespace SharpCord.Models;

/// <summary>
/// Represents the types of base interactions that can occur in the context of the application.
/// </summary>
public enum BaseInteractionType
{
    /// <summary>
    /// Denotes a ping interaction, commonly used to test connectivity
    /// or evaluate the application's responsiveness in real time.
    /// </summary>
    Ping = 1,

    /// <summary>
    /// Represents an interaction triggered by the execution of an application command,
    /// such as slash commands or context menu actions within the application.
    /// </summary>
    ApplicationCommand = 2,

    /// <summary>
    /// Represents an interaction triggered by a message component, such as buttons, select menus, or other interactive elements within a message.
    /// Typically used to handle user interactions with UI elements embedded in messages.
    /// </summary>
    MessageComponent = 3,

    /// <summary>
    /// Specifies a specialized attribute interaction type associated with
    /// application commands, used to define additional metadata or behavior
    /// for such commands within the application's interaction handling framework.
    /// </summary>
    ApplicationCommandAttribute = 4,

    /// <summary>
    /// Represents a modal submission interaction, typically triggered when
    /// a user submits data through a modal interface within the application.
    /// </summary>
    ModalSubmit = 5,
}