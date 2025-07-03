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
/// Represents the callback data sent in response to an application command interaction.
/// </summary>
public class ApplicationCommandCallbackData
{
    /// <summary>
    /// Gets or sets the main content of the response sent in an application command interaction.
    /// </summary>
    /// <remarks>
    /// This property contains the textual content to be displayed in the interaction response.
    /// </remarks>
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    /// <summary>
    /// Gets or sets a collection of embed objects included in the response sent in an application command interaction.
    /// </summary>
    /// <remarks>
    /// This property contains a list of embeds used to provide rich visual or textual content in the interaction response.
    /// </remarks>
    [JsonPropertyName("embeds")]
    public List<Embed>? Embeds { get; set; }

    /// <summary>
    /// Gets or sets a list of action rows containing interactive components.
    /// </summary>
    /// <remarks>
    /// This property is used to include interactive components such as buttons or select menus
    /// within the response of an application command interaction.
    /// </remarks>
    [JsonPropertyName("components")]
    public List<ActionRow>? Components { get; set; }

    /// <summary>
    /// Gets or sets the flags associated with the response message in an application command interaction.
    /// </summary>
    /// <remarks>
    /// This property specifies various attributes or states that can be applied to the message,
    /// such as whether it is ephemeral, suppresses embeds, or has other specific behaviors.
    /// </remarks>
    [JsonPropertyName("flags")]
    public MessageFlags? Flags { get; set; }
}