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