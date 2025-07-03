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
/// An attribute that specifies whether a method should be accessible based
/// on the permissions assigned to a user. This attribute is typically used
/// to determine if a specific action or functionality should be executed
/// only for users with the required permissions.
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class IfUserHasPermissionAttribute : Attribute
{
    /// <summary>
    /// Gets or sets the unique identifier of the guild.
    /// This property is used to represent the context within which a user's
    /// permissions are evaluated for specific actions or operations.
    /// </summary>
    public string GuildId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the user.
    /// This property is used to specify the user whose permissions need to
    /// be validated within the context of a particular guild or operation.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the required permission.
    /// This property determines the specific permission required to execute
    /// the associated method or functionality. Typically used in conjunction
    /// with the <c>IfUserHasPermissionAttribute</c>.
    /// </summary>
    public string Permission { get; set; }

    /// <summary>
    /// An attribute used to specify that a method should only be executed if
    /// the user has the required permission within a specified guild context.
    /// </summary>
    public IfUserHasPermissionAttribute(string guildId, string userId, string permission)
    {
        GuildId = guildId;
        UserId = userId;
        Permission = permission;
    }

    /// <summary>
    /// Asynchronously checks whether the user has the specified permission within the context
    /// of a specified guild.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The result contains a boolean indicating whether the user has the specified permission.</returns>
    public async Task<bool> HasPermissionAsync()
    {
        return await User.HasPermissions(GuildId, UserId, Permission);
    }
}