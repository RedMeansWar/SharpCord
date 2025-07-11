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
/// Represents a basic user entity in the Discord API.
/// </summary>
/// <remarks>
/// A <c>BaseUser</c> provides properties that define the fundamental attributes
/// of a user, such as their identifier, username, and optional metadata about their
/// account status or visibility. It serves as a foundational model for handling user-related
/// data within the system.
/// </remarks>
public class BaseUser : Base
{
    /// <summary>
    /// Gets or sets the unique identifier for the user.
    /// </summary>
    /// <remarks>
    /// The identifier is a Snowflake, which is a 64-bit integer used for unique identification.
    /// It encapsulates information such as the creation of timestamp and worker ID.
    /// </remarks>
    public Snowflake Id { get; set; }

    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    /// <remarks>
    /// The username is a string representing the display name chosen by the user.
    /// This property does not include any discriminator or identifier suffix.
    /// It must comply with the platform's username policies and restrictions.
    /// </remarks>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the discriminator associated with the user.
    /// </summary>
    /// <remarks>
    /// The discriminator is a four-digit string used to differentiate users with the same username.
    /// It often appears in the format "username#1234".
    /// </remarks>
    public string Discriminator { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string GlobalName { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the avatar hash associated with the user.
    /// </summary>
    /// <remarks>
    /// The avatar represents the image associated with the user profile.
    /// The value is typically a string containing the hash of the avatar image, which can be used to construct the URL for the image.
    /// If the user does not have a custom avatar, this may be null or empty.
    /// </remarks>
    public string? Avatar { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the user is a bot.
    /// </summary>
    /// <remarks>
    /// This property is true if the user is an automated bot account, false if it is a regular user account,
    /// and null if the information is unavailable or not provided.
    /// </remarks>
    public bool? IsBot { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user is a system user.
    /// </summary>
    /// <remarks>
    /// The value is a nullable boolean, where true indicates the user is a system user,
    /// false indicates they are not, and null means the system status is unknown.
    /// </remarks>
    public bool? IsSystem { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether multifactor authentication (MFA) is enabled for the user.
    /// </summary>
    /// <remarks>
    /// The value is a nullable boolean, where true indicates that MFA is enabled for the user,
    /// false indicates that it is not enabled, and null represents an unknown state.
    /// </remarks>
    public bool? MfaEnabled { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Banner { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public int? AccentColor { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string? Locale { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public bool? Verified { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public UserFlags? Flags { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public PremiumType? PremiumType { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public UserFlags? PublicFlags { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public AvatarDecorationData? AvatarDecoration { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public Collectables? Collectables { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public PrimaryGuild? PrimaryGuild { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public List<Snowflake> MutualGuilds { get; set; } = new();
}