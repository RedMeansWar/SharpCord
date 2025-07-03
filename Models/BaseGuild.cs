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

using System.Text.Json.Serialization;
using SharpCord.Types;

namespace SharpCord.Models;

/// <summary>
/// Represents a basic guild structure containing the core properties of a Discord guild.
/// </summary>
public class BaseGuild : Base
{
    /// <summary>
    /// Gets or sets the unique identifier of the guild.
    /// </summary>
    [JsonPropertyName("id")]
    public Snowflake Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the guild.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the hash of the guild's icon. This can be used to construct
    /// a URL to retrieve the guild's icon image.
    /// </summary>
    [JsonPropertyName("icon")]
    public string? Icon { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the guild owner.
    /// </summary>
    [JsonPropertyName("owner_id")]
    public Snowflake OwnerId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the permissions assigned to the guild.
    /// </summary>
    [JsonPropertyName("permissions")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DiscordPermission? Permissions { get; set; }

    /// <summary>
    /// Gets or sets the list of features enabled for the guild.
    /// </summary>
    [JsonPropertyName("features")]
    public List<string>? Features { get; set; }

    /// <summary>
    /// Gets or sets the multi-factor authentication (MFA) level required for the guild.
    /// </summary>
    [JsonPropertyName("mfa_level")]
    public int MfaLevel { get; set; }

    /// <summary>
    /// Gets or sets the verification level of the guild, indicating the required level of verification
    /// for members before they can engage in the guild's communication channels.
    /// </summary>
    [JsonPropertyName("verification_level")]
    public int VerificationLevel { get; set; }

    /// <summary>
    /// Gets or sets the NSFW (Not Safe For Work) level of the guild, representing the content sensitivity rating applied to the guild.
    /// </summary>
    [JsonPropertyName("nsfw_level")]
    public int NsfwLevel { get; set; }

    /// <summary>
    /// Gets or sets the premium tier level of the guild, indicating the level of Nitro boost benefits.
    /// </summary>
    [JsonPropertyName("premium_tier")]
    public int PremiumTier { get; set; }

    /// <summary>
    /// Gets or sets the preferred locale of the guild, typically used for regional or language-specific settings.
    /// </summary>
    [JsonPropertyName("preferred_locale")]
    public string? PreferredLocale { get; set; }

    /// <summary>
    /// Gets or sets the description of the guild, typically providing additional details about the guild.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets an approximate count of members in the guild. This value may not be exact.
    /// </summary>
    [JsonPropertyName("approximate_member_count")]
    public int? ApproximateMemberCount { get; set; }

    /// <summary>
    /// Gets or sets the approximate count of active presences in the guild.
    /// </summary>
    [JsonPropertyName("approximate_presence_count")]
    public int? ApproximatePresenceCount { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the guild was joined.
    /// </summary>
    [JsonPropertyName("joined_at")]
    public DateTime? JoinedAt { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the guild is considered large, typically based on its member count.
    /// </summary>
    [JsonPropertyName("large")]
    public bool? Large { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the guild is unavailable.
    /// This typically occurs during server outages or maintenance.
    /// </summary>
    [JsonPropertyName("unavailable")]
    public bool? Unavailable { get; set; }
}