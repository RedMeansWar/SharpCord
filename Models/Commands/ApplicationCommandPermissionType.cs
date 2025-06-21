namespace SharpCord.Models;

/// <summary>
/// Represents the type of permission for an application command.
/// </summary>
public enum ApplicationCommandPermissionType
{
    /// <summary>
    /// Represents a permission type that applies to a specific channel.
    /// </summary>
    Channel = 3,

    /// <summary>
    /// Represents a permission type that applies to a specific role.
    /// </summary>
    Role = 1,

    /// <summary>
    /// Represents a permission type that applies to a specific user.
    /// </summary>
    User = 2,
}