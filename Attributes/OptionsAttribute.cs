using SharpCord.Models;

namespace SharpCord.Attributes;

/// <summary>
/// An attribute used to define options for an application command parameter.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter)]
public class OptionsAttribute : Attribute
{
    /// <summary>
    /// Gets the name of the parameter this attribute is associated with.
    /// This name is used to identify the parameter when defining application command options.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets or sets the description of the parameter this attribute is associated with.
    /// This description is used to provide additional details or context about the parameter within application commands.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Determines whether the parameter associated with this attribute is required.
    /// A required parameter must be specified when using the application command.
    /// </summary>
    public bool Required { get; set; } = true;

    /// <summary>
    /// Gets or sets the type of the application command option.
    /// This type specifies the format of input data expected for the associated parameter,
    /// such as string, integer, user, channel, etc., as defined in
    /// <see cref="SharpCord.Models.ApplicationCommandOptionType"/>.
    /// </summary>
    public ApplicationCommandOptionType Type { get; set; } = ApplicationCommandOptionType.String;

    /// <summary>
    /// An attribute used to define options for an application command parameter.
    /// </summary>
    public OptionsAttribute(string name) => Name = name;
}