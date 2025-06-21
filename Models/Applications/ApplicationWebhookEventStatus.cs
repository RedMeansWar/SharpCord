namespace SharpCord.Models;

/// <summary>
/// Represents the status of an application webhook event, describing whether
/// the event is currently active and able to trigger associated webhook actions.
/// See also: https://discord.com/developers/docs/resources/application#application-object-application-event-webhook-status
/// </summary>
public enum ApplicationWebhookEventStatus
{
    /// <summary>
    /// Represents a status where the developer disables the application webhook event.
    /// This status indicates that the event will not trigger any webhook actions.
    /// </summary>
    Disabled = 1,

    /// <summary>
    /// Indicates that the application webhook event is enabled by the developer,
    /// allowing the event to trigger the associated webhook actions.
    /// </summary>
    Enabled = 2,

    /// <summary>
    /// Indicates that Discord has disabled the application webhook event.
    /// This status suggests the event is non-operational due to external intervention or restrictions.
    /// <remarks>
    /// Discord disables Webhook events, usually due to inactivity
    /// </remarks>
    /// </summary>
    DisabledByDiscord = 3,
}