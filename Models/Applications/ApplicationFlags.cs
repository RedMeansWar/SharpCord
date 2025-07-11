namespace SharpCord.Models;

/// <summary>
/// Represents flags that define specific characteristics, features, or permissions related to an application.
/// See also: https://discord.com/developers/docs/resources/application#application-object-application-flags
/// </summary>
public enum ApplicationFlags
{
    /// <summary>
    /// Represents a flag indicating that the application has the auto-moderation rule create badge feature enabled.
    /// </summary>
    ApplicationAutoModerationRuleCreateBadge = 64,

    /// <summary>
    /// Represents a flag indicating that the application has the command badge feature enabled.
    /// </summary>
    ApplicationCommandBadge = 8388608,
    
    /// <summary>
    /// 
    /// </summary>
    Embedded = 131072,

    /// <summary>
    /// Represents a flag indicating that the application is considered a first-party embedded application.
    /// </summary>
    EmbeddedFirstParty = 1048576,

    /// <summary>
    /// Represents a flag indicating that the application supports or uses Embedded In-App Purchases (IAP).
    /// </summary>
    EmbeddedIAP = 8,

    /// <summary>
    /// Represents a flag indicating that the application has been officially released in an embedded context.
    /// </summary>
    EmbeddedReleased = 2,

    /// <summary>
    /// Represents a flag indicating that the application has access to the full list of members in guilds via Gateway.
    /// </summary>
    GatewayGuildMembers = 16384,

    /// <summary>
    /// Represents a flag indicating that the application has limited access to the Gateway "Guild Members" feature.
    /// </summary>
    GatewayGuildMembersLimited = 32768,

    /// <summary>
    /// Represents a flag indicating that the application has access to the Gateway for Message Content.
    /// </summary>
    GatewayMessageContent = 262144,

    /// <summary>
    /// Represents a flag indicating that the application has limited access to message content via the Gateway API.
    /// </summary>
    GatewayMessageContentLimited = 524288,

    /// <summary>
    /// Denotes that the application has access to the Gateway Presence feature, allowing it to track and update user presence information via the Gateway.
    /// </summary>
    GatewayPresence = 4096,

    /// <summary>
    /// Represents a flag indicating that the application's presence-related operations are restricted or limited on the gateway.
    /// </summary>
    GatewayPresenceLimited = 8192,

    /// <summary>
    /// Represents a flag indicating that the application supports or can create group direct messages (Group DMs).
    /// </summary>
    GroupDMCreate = 16,

    /// <summary>
    /// Represents a flag indicating that the application has access to and manages custom emojis.
    /// </summary>
    ManagedEmoji = 4,

    /// <summary>
    /// Indicates that the application has successfully established a connection via RPC (Remote Procedure Call).
    /// </summary>
    RPCHasConnected = 2048,

    /// <summary>
    /// Represents a flag indicating that the application is subject to a verification-gated limit on creating or managing guilds.
    /// </summary>
    VerificationPendingGuildLimit = 65536
}