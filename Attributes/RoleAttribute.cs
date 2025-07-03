#region LICENSE
// Copyright (c) 2025 RedMeansWar
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

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