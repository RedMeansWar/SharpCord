using SharpCord.Users;

namespace SharpCord.Attributes;

/// <summary>
/// Represents an attribute used to assign a specific role to a Discord user.
/// </summary>
/// <remarks>
/// This attribute is used to decorate methods, marking them as responsible for handling role assignment operations.
/// It can only be applied to methods and cannot be applied multiple times to the same method.
/// </remarks>
[AttributeUsage(AttributeTargets.Method)]
public class AssignRoleAttribute : Attribute
{
    /// <summary>
    /// Gets or sets the identifier of the Discord guild where the role assignment operation is to take place.
    /// </summary>
    /// <remarks>
    /// The <c>GuildId</c> property is crucial in specifying the target Discord guild
    /// for operations such as role assignment, channel creation, or permission management within that guild.
    /// </remarks>
    public string GuildId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the Discord user to whom the role is to be assigned.
    /// </summary>
    /// <remarks>
    /// The <c>UserId</c> property is used in role management processes
    /// to specify the user in a particular Discord guild targeted for role assignment operations.
    /// </remarks>
    public string UserId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the role to be assigned to a user in a specific Discord guild.
    /// </summary>
    /// <remarks>
    /// The <c>RoleId</c> property is used in the context of role management operations,
    /// specifically to identify the role to be associated with a given user.
    /// </remarks>
    public string RoleId { get; set; }

    /// <summary>
    /// Represents an attribute used to assign a role to a user in a specific Discord guild.
    /// </summary>
    /// <remarks>
    /// This attribute is intended for use on methods responsible for role assignment,
    /// providing the necessary guild, user, and role identifiers.
    /// </remarks>
    public AssignRoleAttribute(string guildId, string userId, string roleId)
    {
        GuildId = guildId;
        UserId = userId;
        RoleId = roleId;
    }

    /// <summary>
    /// Executes the asynchronous operation to assign a role to a Discord user in a specific guild.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation of assigning a role.
    /// </returns>
    public async Task ExecuteAsync() => await Roles.GiveRoleAsync(GuildId, UserId, RoleId);
}