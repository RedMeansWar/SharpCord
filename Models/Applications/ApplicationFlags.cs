namespace SharpCord.Models.Applications;

public enum ApplicationFlags
{
    ApplicationAutoModerationRuleCreateBadge = 64,
    ApplicationCommandBadge = 8388608,
    Embedded = 131072,
    EmbeddedFirstParty = 1048576,
    EmbeddedIAP = 8,
    EmbeddedReleased = 2,
    GatewayGuildMembers = 16384,
    GatewayGuildMembersLimited = 32768,
    GatewayMessageContent = 262144,
    GatewayMessageContentLimited = 524288,
    GatewayPresence = 4096,
    GatewayPresenceLimited = 8192,
    GroupDMCreate = 16,
    ManagedEmoji = 4,
    RPCHasConnected = 2048,
    VerificationPendingGuildLimit = 65536
}