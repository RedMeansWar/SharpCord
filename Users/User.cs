using SharpCord.Interactions;

namespace SharpCord.Users;

/// <summary>
/// Represents a user in Discord, providing methods to manage user-related operations.
/// </summary>
public class User
{
    /// <summary>
    /// Determines whether a user has the specified permission within a guild.
    /// </summary>
    /// <param name="guildId">The unique identifier of the guild.</param>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <param name="permissionId">The unique identifier of the permission to check.</param>
    /// <returns>A boolean indicating whether the user has the specified permission.</returns>
    public static async Task<bool> HasPermissions(string guildId, string userId, string permissionId)
    {
        return false;
    }

    public static async Task AssignRole(Interaction interaction, string roleId)
    {
        
    }
}