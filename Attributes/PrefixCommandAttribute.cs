namespace SharpCord.Attributes;

/// <summary>
/// An attribute used to designate a method as a prefix-based command.
/// </summary>
/// <remarks>
/// This attribute is applied to methods to indicate that they can be invoked as commands
/// with a specific prefix. The <see cref="Name"/> property represents the unique identifier
/// for the command.
/// </remarks>
[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public class PrefixCommandAttribute : Attribute
{
    /// <summary>
    /// Gets the name associated with the command attribute.
    /// Represents the name of the command that will be matched for invocation
    /// when the command processor identifies a valid prefix.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// An attribute used to designate a method as a command that can be invoked via a specific prefix.
    /// </summary>
    public PrefixCommandAttribute(string name) => Name = name;
}