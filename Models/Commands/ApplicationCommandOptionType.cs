namespace SharpCord.Models;

/// <summary>
/// Represents the type of application command option.
/// Specifies the type of data expected by the option.
/// </summary>
public enum ApplicationCommandOptionType
{
    /// <summary>
    /// Represents an option type for a sub-command in an application command.
    /// This allows the definition of a single executable sub-command within
    /// the context of a top-level application command.
    /// </summary>
    SubCommand = 1,

    /// <summary>
    /// Represents an option type for a group of sub-commands in an application command.
    /// This allows the organization of multiple sub-commands into a hierarchical group
    /// within the context of a top-level application command.
    /// </summary>
    SubCommandGroup = 2,

    /// <summary>
    /// Represents an option type for a string input in an application command.
    /// This option allows the command to accept text-based user input.
    /// </summary>
    String = 3,

    /// <summary>
    /// Represents an option type for integer input in an application command.
    /// This is used to define options that accept a whole number of values.
    /// </summary>
    Integer = 4,

    /// <summary>
    /// Represents an option type for a boolean in an application command.
    /// This allows the inclusion of a true or false value as input for the option.
    /// </summary>
    Boolean = 5,

    /// <summary>
    /// Represents an option type for a user in an application command.
    /// This allows the selection of a specific user as input for the command.
    /// </summary>
    User = 6,

    /// <summary>
    /// Represents an option type for a channel selection in an application command.
    /// This allows the user to specify a Discord channel as the value for the command option.
    /// </summary>
    Channel = 7,

    /// <summary>
    /// Represents an option type for a role in an application command.
    /// This is used to allow users to select a role within the context of a command.
    /// </summary>
    Role = 8,

    /// <summary>
    /// Represents an option type for a mentionable entity in an application command.
    /// This includes users and roles that can be mentioned within the context of a command.
    /// </summary>
    Mentionable = 9,

    /// <summary>
    /// Represents an option type for a numeric value in an application command.
    /// This allows input of a number, including floating-point values,
    /// to be passed as an argument to the command.
    /// <remarks>This can be any number between -2^53 and 2^53</remarks>
    /// </summary>
    Number = 10,

    /// <summary>
    /// Represents an option type for an attachment in an application command.
    /// This allows the inclusion of a file or media as an option for the command.
    /// </summary>
    Attachment = 11,
}