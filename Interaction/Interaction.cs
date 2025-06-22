using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using SharpCord.Models;
using SharpCord.Utils;

namespace SharpCord.Interaction;

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
        
        var json = JsonSerializer.Serialize(payload, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
        var contentBody = new StringContent(json, Encoding.UTF8, "application/json");
        var url = $"https://discord.com/api/v10/interactions/{Id}/{Token}/callback";
        
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new("Bot", DiscordClient.Token);
        
        var response = await client.PostAsync(url, contentBody);
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Discord API returned error: {response.StatusCode}\n{error}");
        }
    }
}