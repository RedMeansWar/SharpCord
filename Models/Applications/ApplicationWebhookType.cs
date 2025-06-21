namespace SharpCord.Models;

/// <summary>
/// Defines the type of application webhook.
/// See also: https://discord.com/developers/docs/events/webhook-events#webhook-types
/// </summary>
public enum ApplicationWebhookType
{
    /// <summary>
    /// Represents a webhook type used to indicate a ping action.
    /// </summary>
    Ping,

    /// <summary>
    /// Represents a webhook type used to handle specific events.
    /// </summary>
    Event
}