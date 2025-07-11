using System.Text.Json.Serialization;

namespace SharpCord.Models;

/// <summary>
/// 
/// </summary>
[Flags]
public enum UserFlags
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("STAFF")]
    DiscordStaff = 1 << 0,
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("PARTNER")]
    DiscordPartner = 1 << 1,
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("HYPESQUAD")]
    DiscordHypeSquad = 1 << 2,
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("BUG_HUNTER_LEVEL_1")]
    BugHunterLevel1 = 1 << 3,
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("HYPESQUAD_ONLINE_HOUSE_1")]
    HypeSquadOnlineHouse1 = 1 << 6,
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("HYPESQUAD_ONLINE_HOUSE_2")]
    HypeSquadOnlineHouse2 = 1 << 7,
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("HYPESQUAD_ONLINE_HOUSE_3")]
    HypeSquadOnlineHouse3 = 1 << 8,
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("PREMIUM_EARLY_SUPPORTER")]
    PremiumEarlySupporter = 1 << 9,
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("TEAM_PSEUDO_USER")]
    TeamPseudoUser = 1 << 10,
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("BUG_HUNTER_LEVEL_2")]
    BugHunterLevel2 = 1 << 14,
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("VERIFIED_BOT")]
    VerifiedBot = 1 << 16,
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("VERIFIED_DEVELOPER")]
    VerifiedDeveloper = 1 << 17,
    
    /// <summary>
    /// /
    /// </summary>
    [JsonPropertyName("CERTIFIED_MODERATOR")]
    CertifiedModerator = 1 << 18,
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("BOT_HTTP_INTERACTIONS")]
    BotHttpInteractions = 1 << 19,
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("ACTIVE_DEVELOPER")]
    ActiveDeveloper = 1 << 22
}