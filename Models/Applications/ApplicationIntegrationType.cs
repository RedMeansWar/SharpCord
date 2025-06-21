namespace SharpCord.Models;

/// <summary>
/// Enumerates the different types of application integrations.
/// See also:
/// https://discord.com/developers/docs/resources/application#application-object-application-integration-types
/// </summary>
public enum ApplicationIntegrationType
{
    /// <summary>
    /// Represents an integration type where the application is installed for an entire guild.
    /// </summary>
    GuildInstall,

    /// <summary>
    /// Represents an integration type where the application is installed by an individual user.
    /// </summary>
    UserInstall
}