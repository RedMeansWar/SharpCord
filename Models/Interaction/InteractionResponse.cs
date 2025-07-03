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
/// Represents the response to an interaction, such as a command or an event, received by the Discord API.
/// It specifies the type of response and optional data associated with the response.
/// </summary>
public class InteractionResponse
{
    /// <summary>
    /// Gets or sets the type of the interaction response.
    /// This property determines the specific response behavior, which is represented by the <see cref="InteractionResponseType"/> enum.
    /// </summary>
    [JsonPropertyName("type")]
    public InteractionResponseType Type { get; set; }

    /// <summary>
    /// Represents the optional callback data included in an interaction response.
    /// This property contains information such as content or embeds to be sent as part of the interaction's reply.
    /// </summary>
    [JsonPropertyName("data")]
    public ApplicationCommandCallbackData? Data { get; set; }
}