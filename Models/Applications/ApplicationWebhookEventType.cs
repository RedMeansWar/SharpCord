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