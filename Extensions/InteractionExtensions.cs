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

using SharpCord.Interactions;
using SharpCord.Models;

namespace SharpCord.Extensions;

/// <summary>
/// Provides extension methods for interacting with Discord interactions, enabling enhanced functionality
/// such as sending replies with customizable content, embeds, and visibility options.
/// </summary>
public static class InteractionExtensions
{
    /// <summary>
    /// Sends a reply to the specified interaction with the provided content, optional embeds, and visibility settings.
    /// </summary>
    /// <param name="interaction">The interaction to which the reply will be sent.</param>
    /// <param name="content">The text content for the reply.</param>
    /// <param name="embeds">A list of embeds to include in the reply. This parameter is optional and defaults to null.</param>
    /// <param name="ephemeral">A boolean value indicating whether the reply should be ephemeral (visible only to the user). Defaults to false.</param>
    /// <returns>A task that represents the asynchronous operation of sending the reply.</returns>
    public static async Task Reply(this Interaction interaction, string content, List<Embed>? embeds = null, bool ephemeral = false)
        => await interaction.ReplyAsync(content, embeds, ephemeral);

    /// <summary>
    /// Defers a reply to an interaction, allowing for asynchronous operations to take place
    /// before sending a final response. Optionally, the deferred reply can be ephemeral.
    /// </summary>
    /// <param name="interaction">The interaction objects to defer the reply for.</param>
    /// <param name="ephemeral">A boolean value indicating whether the deferred reply should be ephemeral (visible only to the user). Defaults to false.</param>
    /// <returns>A task that represents the asynchronous operation of deferring the reply.</returns>
    public static async Task DeferReply(this Interaction interaction, bool ephemeral = false)
        => await interaction.DeferReplyAsync(interaction, ephemeral);

    /// <summary>
    /// Sends an embed response to the specified interaction with the provided content, optional embed list, and visibility settings.
    /// </summary>
    /// <param name="interaction">The interaction to which the embed response will be sent.</param>
    /// <param name="content">The text content to accompany the embed response.</param>
    /// <param name="embeds">A list of embeds to include in the response. This parameter is optional and defaults to null.</param>
    /// <param name="ephemeral">A boolean value indicating whether the response should be ephemeral (visible only to the user). Defaults to false.</param>
    /// <returns>A task that represents the asynchronous operation of sending the embed response.</returns>
    public static async Task SendEmbed(this Interaction interaction, string content, List<Embed>? embeds = null, bool ephemeral = false)
        => await interaction.SendEmbedAsync(content, embeds, ephemeral);

    /// <summary>
    /// Sends a follow-up message to the specified interaction with the given content, optional embeds, and visibility settings.
    /// </summary>
    /// <param name="interaction">The interaction to which the follow-up message will be sent.</param>
    /// <param name="content">The text content for the follow-up message.</param>
    /// <param name="embeds">A list of embeds to include in the follow-up message. This parameter is optional and defaults to null.</param>
    /// <param name="ephemeral">A boolean value indicating whether the follow-up message should be ephemeral (visible only to the user). Defaults to false.</param>
    /// <returns>A task that represents the asynchronous operation of sending the follow-up message.</returns>
    public static async Task Followup(this Interaction interaction, string content, List<Embed>? embeds = null, bool ephemeral = false)
        => await interaction.SendFollowupAsync(content, embeds, ephemeral);
    
    
}