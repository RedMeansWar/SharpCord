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
using System.Text.RegularExpressions;
using SharpCord.Models;
using SharpCord.Types;
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

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var url = $"/interactions/{Id}/{Token}/callback";
        var response = await HttpHelper.SendRequestAsync(url, "POST", payload, options);
        
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
        
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var url = $"interactions/{Id}/{Token}/callback";
        var response = await HttpHelper.SendRequestAsync(url, "POST", payload, options);
        
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

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var url = $"/webhooks/{ApplicationId}/{Token}/messages/@original";
        var response = await HttpHelper.SendRequestAsync(url, "PATCH", payload, options);

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
        var url = $"/webhooks/{ApplicationId}/{Token}/messages/@original";
        var response = await HttpHelper.SendRequestAsync(url, "DELETE");
        
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

        var url = $"/interactions/{Id}/{Token}/callback";
        var response = await HttpHelper.SendRequestAsync(url, "POST", multipart);
        
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Discord API returned error: {response.StatusCode}\n{error}");
        }
    }

    /// <summary>
    /// Sends a follow-up message with a file to a Discord interaction asynchronously.
    /// </summary>
    /// <param name="content">The text content of the follow-up message.</param>
    /// <param name="fileStream">The stream containing the file to be uploaded.</param>
    /// <param name="fileName">The name of the file to be uploaded.</param>
    /// <param name="ephemeral">Indicates if the follow-up message should be ephemeral (visible only to the interaction user).</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="Exception">Thrown when the Discord API returns an error response.</exception>
    public async Task FollowupWithFileAsync(string content, Stream fileStream, string fileName, bool ephemeral = false)
    {
        var payload = new ApplicationCommandCallbackData
        {
            Content = content,
            Flags = ephemeral ? MessageFlags.Ephemeral : MessageFlags.None
        };

        var json = JsonSerializer.Serialize(payload, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        
        var multipart = new MultipartFormDataContent();
        multipart.Add(new StringContent(json, Encoding.UTF8, "application/json"), "payload_json");
        multipart.Add(new StreamContent(fileStream), "files[0]", fileName);

        var url = $"/webhooks/{ApplicationId}/{Token}";
        var response = await HttpHelper.SendRequestAsync(url, "POST", multipart);
        
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Discord API returned error: {response.StatusCode}\n{error}");
        }
    }
    
    /// <summary>
    /// Defers the reply to a Discord interaction asynchronously,
    /// indicating that the interaction is acknowledged but a reply will follow later.
    /// </summary>
    /// <param name="interaction">The interaction instance for which the reply is being deferred.</param>
    /// <param name="ephemeral">Indicates if the deferred reply should be ephemeral
    /// (visible only to the interaction user).</param>
    /// <returns>A task representing the asynchronous defer operation.</returns>
    /// <exception cref="Exception">Thrown when the Discord API returns an error response.</exception>
    public async Task DeferReplyAsync(Interaction interaction, bool ephemeral = false)
    {
        var payload = new InteractionResponse
        {
            Type = InteractionResponseType.DeferredChannelMessageWithSource,
            Data = new ApplicationCommandCallbackData
            {
                Flags = ephemeral ? MessageFlags.Ephemeral : MessageFlags.None
            },
        };

        var json = JsonSerializer.Serialize(payload, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        var url = $"/interactions/{Id}/{Token}/callback";
        var response = await HttpHelper.SendRequestAsync(url, "POST", json);
        
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Discord API returned error: {response.StatusCode}\n{error}");
        }
    }

    /// <summary>
    /// Sends an embed message as a response to a Discord interaction asynchronously.
    /// </summary>
    /// <param name="content">The text content to accompany the embed message.</param>
    /// <param name="embeds">An optional list of embed objects to include in the response.</param>
    /// <param name="ephemeral">Indicates whether the response should be ephemeral, making it visible only to the interaction user.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="Exception">Thrown when the Discord API returns an error response.</exception>
    public async Task SendEmbedAsync(string content, List<Embed>? embeds = null, bool ephemeral = false)
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

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var url = $"/interactions/{Id}/{Token}/callback";
        var response = await HttpHelper.SendRequestAsync(url, "POST", payload, options);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Discord API returned error: {response.StatusCode}\n{error}");
        }
    }

    /*public async Task SendEmbedWithComponentsAsync(string content, List<Embed>? embeds = null, List<ActionRow>? components = null, bool ephemeral = false)
    {
        var payload = new InteractionResponse
        {
            Type = InteractionResponseType.ChannelMessageWithSource,
            Data = new ApplicationCommandCallbackData
            {
                Content = content,
                Embeds = embeds,
                Components = components?.Select(c => c.E()).ToList(),
                Flags = ephemeral ? MessageFlags.Ephemeral : MessageFlags.None
            },
        };
        
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        
        var url = $"/interactions/{Id}/{Token}/callback";
        var response = await HttpHelper.SendRequestAsync(url, "POST", payload, options);
        
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Discord API returned error: {response.StatusCode}\n{error}");
        }
    }*/

    /// <summary>
    /// Retrieves the user associated with the current interaction.
    /// </summary>
    /// <returns>
    /// A <c>BaseUser</c> object representing the user associated with the interaction,
    /// or <c>null</c> if no user is available.
    /// </returns>
    public BaseUser? GetUser()
    {
        return Member?.User ?? User;
    }
    
    /// <summary>
    /// Retrieves the unique identifier of the user associated with the current interaction.
    /// </summary>
    /// <returns>The Snowflake identifier of the user, or null if no user is associated.</returns>
    public Snowflake? GetUserId()
    {
        return GetUser()?.Id;
    }

    /// <summary>
    /// Retrieves the Snowflake identifier of the guild associated with the interaction, if available.
    /// <remarks>You can also use <c>interaction.GuildId</c>. This is an alternative.</remarks>
    /// </summary>
    /// <returns>A Snowflake object representing the guild ID, or null if the guild ID is not present.</returns>
    public Snowflake? GetGuildId()
    {
        return GuildId;
    }

    /// <summary>
    /// Processes a string to correctly format user and role mentions in Discord.
    /// </summary>
    /// <param name="content">The input string containing potential mentions.</param>
    /// <returns>The processed string with mentions properly formatted.</returns>
    public string ParseMentions(string content)
    {
        content = Regex.Replace(content, @"<@(\d+)>", m => $"<@{m.Groups[1].Value}>"); // parsing user mentions like @user
        content = Regex.Replace(content, @"<@&(\d+)>", m => $"<@&{m.Groups[1].Value}>"); // parsing role mentions like @role
        return content;
    }

    /// <summary>
    /// Generates a mention string for a user based on their user ID.
    /// </summary>
    /// <param name="userId">The ID of the user to mention.</param>
    /// <returns>A string formatted to mention the user in a Discord message.</returns>
    public string MentionUser(string userId)
    {
        return $"<@&{userId}>";
    }

    /// <summary>
    /// Formats a role ID as a mentionable role string for Discord.
    /// </summary>
    /// <param name="roleId">The ID of the role to mention.</param>
    /// <returns>A string that mentions the role in Discord.</returns>
    public string MentionRole(string roleId)
    {
        return $"<@&{roleId}>";
    }

    /// <summary>
    /// Generates a Discord mention string for a specified channel ID.
    /// </summary>
    /// <param name="channelId">The ID of the channel to mention.</param>
    /// <returns>A string formatted as a channel mention.</returns>
    public string MentionChannel(string channelId)
    {
        return $"<#{channelId}>";
    }
}