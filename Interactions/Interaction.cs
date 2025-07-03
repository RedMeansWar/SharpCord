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

using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using SharpCord.Models;
using SharpCord.Utils;

namespace SharpCord.Interactions;

/// <summary>
/// Represents an interaction module used for managing responses to Discord interactions.
/// </summary>
public class Interaction : BaseInteraction
{
    /// <summary>
    /// Sends a response to a Discord interaction asynchronously.
    /// </summary>
    /// <param name="content">The text content of the response.</param>
    /// <param name="embeds">Optional list of embeds to include in the response.</param>
    /// <param name="ephemeral">Indicates if the response should be ephemeral (visible only to the interaction user).</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task ReplyAsync(string content, List<Embed>? embeds = null, bool ephemeral = false)
    {
        var payload = new InteractionResponse
        {
            Type = InteractionResponseType.ChannelMessageWithSource,
            Data = new ApplicationCommandCallbackData
            {
                Content = content,
                Embeds = embeds,
                Flags = ephemeral ? MessageFlags.Ephemeral : MessageFlags.None
            },
        };

        var json = JsonSerializer.Serialize(payload, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        var contentBody = new StringContent(json, Encoding.UTF8, "application/json");
        var url = $"https://discord.com/api/v10/interactions/{Id}/{Token}/callback";
        
        using var client = new HttpClient();
        var response = await client.PostAsync(url, contentBody);
        
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Discord API returned error: {response.StatusCode}\n{error}");
        }
    }

    /// <summary>
    /// Sends a follow-up message to a Discord interaction asynchronously.
    /// </summary>
    /// <param name="content">The text content of the follow-up message.</param>
    /// <param name="embeds">Optional list of embeds to include in the follow-up message.</param>
    /// <param name="ephemeral">Indicates if the follow-up message should be ephemeral (visible only to the interaction user).</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="Exception">Thrown when the Discord API returns an error response.</exception>
    public async Task SendFollowupAsync(string content, List<Embed>? embeds = null, bool ephemeral = false)
    {
        var payload = new ApplicationCommandCallbackData
        {
            Content = content,
            Embeds = embeds,
            Flags = ephemeral ? MessageFlags.Ephemeral : MessageFlags.None
        };
        
        var json = JsonSerializer.Serialize(payload, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        
        var contentBody = new StringContent(json, Encoding.UTF8, "application/json");
        var url = $"https://discord.com/api/v10/interactions/{Id}/{Token}/callback";
        
        using var client = new HttpClient();
        var response = await client.PostAsync(url, contentBody);
        
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Discord API returned error: {response.StatusCode}\n{error}");
        }
    }

    /// <summary>
    /// Edits the original response of a Discord interaction asynchronously.
    /// </summary>
    /// <param name="content">The updated text content for the original response.</param>
    /// <param name="embeds">Optional list of updated embeds to include in the response.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="Exception">Thrown if the Discord API returns an error while editing the response.</exception>
    public async Task EditOriginalResponseAsync(string content, List<Embed>? embeds = null)
    {
        var payload = new ApplicationCommandCallbackData
        {
            Content = content,
            Embeds = embeds
        };

        var json = JsonSerializer.Serialize(payload, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        
        var url = $"https://discord.com/api/v10/webhooks/{ApplicationId}/{Token}/messages/@original";
        using var client = new HttpClient();
        var response = await client.PatchAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to edit original response, Discord API returned error: {response.StatusCode}\n{error}");
        }
    }

    /// <summary>
    /// Deletes the original response to a Discord interaction asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="Exception">Thrown when the Discord API returns an error response.</exception>
    public async Task DeleteOriginalResponseAsync()
    {
        var url = $"https://discord.com/api/v10/webhooks/{ApplicationId}/{Token}/messages/@original";
        using var client = new HttpClient();
        var response = await client.DeleteAsync(url);
        
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Discord API returned error: {response.StatusCode}\n{error}");
        }
    }

    /// <summary>
    /// Sends a response to a Discord interaction with an attached file asynchronously.
    /// </summary>
    /// <param name="content">The text content of the response.</param>
    /// <param name="fileStream">The stream containing the file to be attached.</param>
    /// <param name="fileName">The name of the file to be attached.</param>
    /// <param name="ephemeral">Indicates if the response should be ephemeral (visible only to the interaction user).</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="Exception">Thrown when the Discord API returns an error response.</exception>
    public async Task ReplyWithFileAsync(string content, Stream fileStream, string fileName, bool ephemeral = false)
    {
        var payload = new InteractionResponse
        {
            Type = InteractionResponseType.ChannelMessageWithSource,
            Data = new ApplicationCommandCallbackData
            {
                Content = content,
                Flags = ephemeral ? MessageFlags.Ephemeral : MessageFlags.None
            },
        };

        var json = JsonSerializer.Serialize(payload, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        var multipart = new MultipartFormDataContent();
        multipart.Add(new StringContent(json, Encoding.UTF8, "application/json"), "payload_json");
        multipart.Add(new StreamContent(fileStream), "files[0]", fileName);

        var url = $"https://discord.com/api/v10/interactions/{Id}/{Token}/callback";
        using var client = new HttpClient();
        var response = await client.PostAsync(url, multipart);
        
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Discord API returned error: {response.StatusCode}\n{error}");
        }
    }
}