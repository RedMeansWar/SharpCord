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
    public string GuildId { get; set; }
    
    public string UserId { get; set; }
    
    public string RoleId { get; set; }

    public AssignRoleAttribute(string guildId, string userId, string roleId)
    {
        GuildId = guildId;
        UserId = userId;
        RoleId = roleId;
    }
    
    public async Task ExecuteAsync() => await Roles.GiveRoleAsync(GuildId, UserId, RoleId);
}