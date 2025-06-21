namespace SharpCord.Models;

/// <summary>
/// Defines the types of components that can be used within an interactive message or UI layout in a Discord context.
/// Each type represents a specific kind of UI element or grouping, enabling rich and dynamic interactions.
/// </summary>
public enum ComponentType
{
    /// <summary>
    /// Represents a container for grouping interactive components within a single row in a Discord message.
    /// Typically used to organize multiple components, such as buttons or select menus, into a single horizontal arrangement.
    /// </summary>
    ActionRow = 1,

    /// <summary>
    /// Represents an interactive clickable button component in a Discord message.
    /// Buttons can be used to trigger specific actions or interact with users directly within the message interface.
    /// </summary>
    Button = 2,

    /// <summary>
    /// Represents a drop-down menu in a Discord message where users can select one or more predefined string options.
    /// Commonly used for creating interactive and customizable message components.
    /// </summary>
    StringSelect = 3,

    /// <summary>
    /// Represents a deprecated name for the StringSelect component in Discord.
    /// Use StringSelect instead of defining dropdown-style selection menus within messages.
    /// </summary>
    [Obsolete("This the old name for StringSelect, please use StringSelect instead.")]
    SelectMenu = 3,

    /// <summary>
    /// Represents a component designed for accepting user input through text fields within a Discord message.
    /// Commonly used for collecting information, such as forms or dialogue boxes, in interactive workflows.
    /// </summary>
    TextInput = 4,

    /// <summary>
    /// Represents a component type that allows users to select one or more users from a predefined input, such as a dropdown menu.
    /// Typically used in Discord interactions to facilitate user selection in a structured and interactive manner.
    /// </summary>
    UserSelect = 5,

    /// <summary>
    /// Represents a dropdown component used to allow selection of one or more roles in a Discord message.
    /// Commonly used in scenarios where assigning or managing roles is required.
    /// </summary>
    RoleSelect = 6,

    /// <summary>
    /// Represents a select menu component within Discord that allows users to choose one or more mentionable entities,
    /// such as users or roles. Commonly used for creating interactive experiences that involve selecting specific
    /// mentionable objects.
    /// </summary>
    MentionableSelect = 7,

    /// <summary>
    /// Represents a select menu component specifically designed to allow users to choose from available Discord channels.
    /// Commonly used in interactive messages where functionality requires interaction with channels, such as selecting a text, voice, or other channel types.
    /// </summary>
    ChannelSelect = 8,

    /// <summary>
    /// Represents a distinct section or divider within a layout or component arrangement.
    /// Typically used to structure content into clear, organized segments for better readability and separation.
    /// </summary>
    Section = 9,

    /// <summary>
    /// Represents a component used to display static text content in a structured format within a Discord message.
    /// Typically used for presenting descriptive or informational text without interactivity.
    /// </summary>
    TextDisplay = 10,

    /// <summary>
    /// Represents a visual component designed to display a small,
    /// compact image or icon, often associated with a specific entity or content.
    /// Typically used to provide a clear, concise visual representation.
    /// </summary>
    Thumbnail = 11,

    /// <summary>
    /// Represents a media gallery component used for displaying a collection of media items, such as images or videos,
    /// in a structured layout. Commonly used in scenarios where multiple media elements need to be showcased together.
    /// </summary>
    MediaGallary = 12,

    /// <summary>
    /// Represents a component type used to handle files in a structured format.
    /// Commonly associated with the management, display, or interaction of file-related content within a system.
    /// </summary>
    File = 13,

    /// <summary>
    /// Represents a visual or organizational divider within a layout or component structure.
    /// Often used to separate or delineate sections in a user interface for better readability and structure.
    /// </summary>
    Separator = 14,

    /// <summary>
    /// Represents an entry in a content inventory that is used to organize or manage specific content components.
    /// This type is typically involved in categorizing or structuring layered or grouped content.
    /// </summary>
    ContentInventoryEntry = 16,

    /// <summary>
    /// Represents a component type that serves as a container for grouping other subcomponents.
    /// Typically used to encapsulate and manage the layout or arrangement of related interactive elements within a larger structure.
    /// </summary>
    Container = 17,
}