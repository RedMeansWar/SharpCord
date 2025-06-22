namespace SharpCord.Models;

/// <summary>
/// Represents the various types of responses that can be sent in reaction to an interaction.
/// Each response type defines how the client or API should process the interaction and respond accordingly.
/// </summary>
public enum InteractionResponseType
{
    /// <summary>
    /// Represents an acknowledgment response to a ping interaction.
    /// The `Pong` response is typically used to confirm the application's availability.
    /// </summary>
    Pong = 1,

    /// <summary>
    /// Indicates a response that sends a message in the channel where the interaction was triggered.
    /// This response is used to provide immediate feedback to the user.
    /// </summary>
    ChannelMessageWithSource = 4,

    /// <summary>
    /// Represents a deferred acknowledgment response to an interaction with the intent to send a
    /// channel message later. This response is commonly used to indicate processing of the
    /// interaction while allowing additional time to prepare a later message.
    /// </summary>
    DeferredChannelMessageWithSource = 5,

    /// <summary>
    /// Indicates a response type used to acknowledge an interaction and defer updating the message.
    /// This allows for processing or updates to occur asynchronously without an immediate visible change.
    /// </summary>
    DeferredUpdateMessage = 6,

    /// <summary>
    /// Represents a response indicating the message update has been acknowledged,
    /// but the update operation is deferred. This allows the application to perform
    /// partial updates or confirm receipt without immediately updating the message content.
    /// </summary>
    DeferredMessageUpdate = 6,

    /// <summary>
    /// Represents a response type used to update an interaction message.
    /// The `UpdateMessage` response updates the content of an existing message without sending a new one.
    /// </summary>
    UpdateMessage = 7,

    /// <summary>
    /// Represents a response type that triggers a modal interaction.
    /// This is used to display a modal dialog in response to an interaction.
    /// </summary>
    Modal = 9,

    /// <summary>
    /// Represents an interaction response indicating that a premium subscription
    /// is required to proceed. This type of response may be shown when a feature or
    /// action is gated behind a premium membership.
    /// </summary>
    [Obsolete("Send a button with Premium Type instead.")]
    PremiumRequired = 10,

    /// <summary>
    /// Represents a response type that initiates the launch of a specified activity.
    /// The `LaunchActivity` response is used to trigger and interact with platform-supported activities.
    /// </summary>
    LaunchActivity = 12
}