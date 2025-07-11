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

using SharpCord.Types;

namespace SharpCord.Models;

/// <summary>
/// Represents a guild member in the context of a Discord server.
/// </summary>
/// <remarks>
/// This class holds data related to a member of a Discord guild (server),
/// including their nickname, roles, join date, premium status, and voice state information.
/// </remarks>
public class BaseGuildMember : BaseUser
{
    /// <summary>
    /// Gets or sets the user associated with the guild member.
    /// </summary>
    /// <remarks>
    /// Represents the user object linked to the guild member, providing details such as
    /// the user's identifier, username, and other account-specific information.
    /// This property serves to tie a guild member to their corresponding user entity.
    /// </remarks>
    public BaseUser User { get; set; } // sometimes present in member payloads
    
    /// <summary>
    /// Gets or sets the nickname of the guild member.
    /// </summary>
    /// <remarks>
    /// The nickname is a user-defined alias for the member within the specific guild.
    /// It can be used to differentiate the member's identity from their global username.
    /// If no nickname is set, this property may return null.
    /// </remarks>
    public string? Nickname { get; set; }

    /// <summary>
    /// Gets or sets the collection of role identifiers associated with the member.
    /// </summary>
    /// <remarks>
    /// Each identifier represents a role that the member has within the guild. Roles are used to assign
    /// permissions, organize members, and apply hierarchy within a guild.
    /// </remarks>
    public List<Snowflake> Roles { get; set; }

    /// <summary>
    /// Gets or sets the timestamp indicating when the member joined the guild.
    /// </summary>
    /// <remarks>
    /// This property represents the exact date and time the guild member joined. It is useful
    /// for tracking membership duration and is typically provided in UTC format.
    /// </remarks>
    public DateTimeOffset? JoinedAt { get; set; }

    /// <summary>
    /// Gets or sets the timestamp indicating when the member began their premium subscription.
    /// </summary>
    /// <remarks>
    /// This property tracks the start time of the user's premium status, such as Nitro, within the guild.
    /// A null value indicates that the member does not have any active premium status.
    /// </remarks>
    public DateTimeOffset? PremiumSince { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the member is deafened in a voice channel.
    /// </summary>
    /// <remarks>
    /// If set to true, the member cannot hear audio in a voice channel. This is often used
    /// to enforce server-wide deafening or during administrative actions.
    /// </remarks>
    public bool? Deaf { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the member is muted in a voice channel.
    /// </summary>
    /// <remarks>
    /// If set to true, the member's audio is suppressed in the voice channel. This is typically
    /// used to enforce administrative actions or for moderation purposes in voice communications.
    /// </remarks>
    public bool? Mute { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public bool? Pending { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string? Avatar { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public Snowflake GuildId { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public PermissionFlags? ComputedPermissions { get; set; }
}