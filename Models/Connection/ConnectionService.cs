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

namespace SharpCord.Models;

/// <summary>
/// Represents a collection of connection services that support integration and interaction with various external platforms or networks.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ConnectionService
{
    /// <summary>
    /// Represents the connection service for Amazon Music, enabling integration with Amazon Music accounts.
    /// </summary>
    [JsonPropertyName("amazon-music")]
    AmazonMusic,

    /// <summary>
    /// Represents the connection service for Battle.net, enabling integration with Battle.net accounts and services.
    /// </summary>
    [JsonPropertyName("battlenet")] 
    BattleNet,

    /// <summary>
    /// Represents the connection service for BlueSky, enabling integration with BlueSky accounts.
    /// </summary>
    [JsonPropertyName("bluesky")] 
    BlueSky,

    /// <summary>
    /// Represents the connection service for Bungie.net, facilitating integration with Bungie.net accounts.
    /// </summary>
    [JsonPropertyName("bungie")] 
    BungieNet,

    /// <summary>
    /// Represents the connection service for Crunchyroll, enabling integration with Crunchyroll accounts.
    /// </summary>
    [JsonPropertyName("crunchyroll")]
    Crunchyroll,

    /// <summary>
    /// Represents the connection service for domain-specific integrations, enabling connectivity with custom or less common service domains.
    /// </summary>
    [JsonPropertyName("domain")] 
    Domain,

    /// <summary>
    /// Represents the connection service for eBay, enabling integration with eBay accounts.
    /// </summary>
    [JsonPropertyName("ebay")] 
    eBay,

    /// <summary>
    /// Represents the connection service for Epic Games, allowing integration with Epic Games accounts.
    /// </summary>/// <summary>
    /// Represents the connection service for Epic Games, enabling integration with Epic Games accounts.
    /// </summary>
    [JsonPropertyName("epicgames")] 
    EpicGames,

    /// <summary>
    /// Represents the connection service for Facebook, allowing integration with Facebook accounts.
    /// </summary>
    [JsonPropertyName("facebook")]
    Facebook,

    /// <summary>
    /// Represents the connection service for GitHub, enabling integration with GitHub accounts.
    /// </summary>
    [JsonPropertyName("github")]
    GitHub,

    /// <summary>
    /// Represents the connection service for Instagram, enabling integration with Instagram accounts.
    /// </summary>
    [JsonPropertyName("instagram")]
    Instagram,

    /// <summary>
    /// Represents the connection service for League of Legends, enabling integration with League of Legends accounts.
    /// </summary>
    [JsonPropertyName("leagueoflegends")]
    LeagueOfLegends,

    /// <summary>
    /// Represents the connection service for Mastodon, enabling integration with Mastodon accounts.
    /// </summary>
    [JsonPropertyName("mastodon")]
    Mastodon,

    /// <summary>
    /// Represents the connection service for PayPal, enabling integration with PayPal accounts.
    /// </summary>
    [JsonPropertyName("paypal")] 
    PayPal,

    /// <summary>
    /// Represents the connection service for PlayStation Network, enabling integration with PlayStation Network accounts.
    /// </summary>
    [JsonPropertyName("playstation")]
    PlayStationNetwork,

    /// <summary>
    /// Represents the connection service for Reddit, enabling integration with Reddit accounts.
    /// </summary>
    [JsonPropertyName("reddit")]
    Reddit,

    /// <summary>
    /// Represents the connection service for Riot Games, enabling integration with Riot Games accounts.
    /// </summary>
    [JsonPropertyName("riotgames")]
    RiotGames,

    /// <summary>
    /// Represents the connection service for Roblox, enabling integration with Roblox accounts.
    /// </summary>
    [JsonPropertyName("roblox")]
    Roblox,

    /// <summary>
    /// Represents the connection service for Skype, enabling integration with Skype accounts.
    /// </summary>
    [JsonPropertyName("skype")]
    Skype,

    /// <summary>
    /// Represents the connection service for Spotify, enabling integration with Spotify accounts.
    /// </summary>
    [JsonPropertyName("spotify")]
    Spotify,
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("steam")]
    Steam,

    /// <summary>
    /// Represents the connection service for TikTok, enabling integration with TikTok accounts.
    /// </summary>
    [JsonPropertyName("tiktok")]
    Tiktok,

    /// <summary>
    /// Represents the connection service for X, supporting integration with X accounts.
    /// </summary>
    [JsonPropertyName("twitter")] 
    X,

    /// <summary>
    /// Represents the legacy connection service for Twitter, allowing integration with accounts from the platform previously known as Twitter.
    /// This member is marked as obsolete, and the preferred alternative is the `X` member.
    /// </summary>
    [JsonPropertyName("twitter")]
    [Obsolete("This the old name for X, please use X instead.")]
    Twitter,

    /// <summary>
    /// Represents the connection service for Xbox, enabling integration with Xbox user accounts and services.
    /// </summary>
    [JsonPropertyName("xbox")]
    Xbox,

    /// <summary>
    /// Represents the connection service for YouTube, enabling integration with YouTube accounts.
    /// </summary>
    [JsonPropertyName("youtube")]
    YouTube,
}