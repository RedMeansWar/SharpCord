using System.Text.Json.Serialization;

namespace SharpCord.Models;

/// <summary>
/// Represents the type of event triggered for an application webhook.
/// See also: https://discord.com/developers/docs/events/webhook-events#event-types
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApplicationWebhookEventType
{
    /// <summary>
    /// Represents an event where an application has been successfully authorized.
    /// This event is typically triggered when a user completes the process of granting permissions to the application.
    /// </summary>
    [JsonPropertyName("APPLICATION_AUTHORIZED")]
    ApplicationAuthorized,

    /// <summary>
    /// Represents an event where a new entitlement has been created.
    /// This event is typically triggered when a user receives a new entitlement, such as a subscription or a digital good.
    /// </summary>
    [JsonPropertyName("ENTITLEMENT_CREATE")]
    EntitlementCreate,

    /// <summary>
    /// Represents an event where a user has been enrolled in a quest.
    /// This event is generally triggered when a user begins participation in a specific quest-related activity or process.
    /// </summary>
    [JsonPropertyName("QUEST_USER_ENROLLMENT")]
    QuestUserEnrollment
}