using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;
using System.Runtime.CompilerServices;
using SharpCord.Extensions;
using SharpCord.Types;
using SharpCord.Models;
using SharpCord.Utils;
using SharpCord.Interactions;
using SharpCord.Helpers;
using SharpCord.Messages;

namespace SharpCord.Guilds;

/// <summary>
/// Represents a channel entity with methods to manage and interact with channels.
/// </summary>
public class Channel : BaseChannel
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="content"></param>
    /// <param name="embeds"></param>
    /// <param name="logging"></param>
    /// <exception cref="Exception"></exception>
    public async Task SendMessageAsync(string content, List<Embed>? embeds = null, bool logging = false)
    {
        var payload = new { content };
        
        var response = await HttpHelper.SendRequestAsync($"/channels/{Id}/messages", "POST", payload);
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to send message: {response.StatusCode}\n{body}");
        }

        string withComponents = embeds is not null ? $"With components: {embeds}" : "Without components";
        
        if (logging)
            Log.Info($"✅ Successfully sent message: '{content}' in {Name} (#{Id}) {withComponents}.");
    }

    /// <summary>
    /// Asynchronously creates a new channel with the specified parameters in a guild.
    /// </summary>
    /// <param name="interaction">The interaction context used to create the channel.</param>
    /// <param name="name">The name of the channel to be created.</param>
    /// <param name="type">The type of channel to be created. Defaults to GuildText.</param>
    /// <param name="parentId">Optional ID of the parent category under which the channel will be created.</param>
    /// <param name="position">Optional position of the channel in relation to other channels in the same category.</param>
    /// <param name="logging">Optional logging to show if the channel was created or not.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the newly created channel.</returns>
    public async Task CreateChannelAsync(Interaction interaction, string name, ChannelType type, string? parentId = null, int? position = null, bool logging = false)
    {
        var payload = new
        {
            name,
            type = (int)type,
            parentId = parentId ?? "",
            position = position ?? 0,
        };

        var url = $"/guilds/{interaction.GuildId}/channels";
        var response = await HttpHelper.SendRequestAsync(url, "POST", payload);

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to create channel: {response.StatusCode}\n{body}");
        }
        
        if (logging)
            Log.Info($"✅ Created channel '{name}' in guild {interaction.GuildId}");
    }


    /// <summary>
    /// Gets the last number of messages from the channel.
    /// </summary>
    /// <param name="channelId">The unique identifier of the channel to grab messages from.</param>
    /// <param name="limit">Number of messages to fetch (1–100).</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<List<Message>> GetMessagesAsync(string channelId, int limit = 50)
    {
        var response = await HttpHelper.SendRequestAsync($"/channels/{channelId}/messages?limit={limit}");
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to get messages inside of channel: {response.StatusCode}\n{body}");
        }
        
        var messages = await response.Content.ReadFromJsonAsync<List<Message>>();
        return messages!;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="channelId"></param>
    /// <param name="logging"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Message> GetChannelAsync(string channelId, bool logging = false)
    {
        var response = await HttpHelper.SendRequestAsync($"/channels/{channelId}");
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to grab channel: {response.StatusCode}\n{body}");
        }
        
        if (logging)
            Log.Info($"✅ Found channel: {channelId}.");

        return await response.Content.ReadFromJsonAsync<Message>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="channelId"></param>
    /// <returns></returns>
    public async Task<Message> GetChannelAsync(Snowflake channelId)
        => await GetChannelAsync(channelId.ToString());

    /// <summary>
    /// 
    /// </summary>
    /// <param name="interaction"></param>
    /// <param name="messageId"></param>
    /// <param name="logging"></param>
    /// <returns></returns>
    public async Task<Message> GetMessageAsync(Interaction interaction, Snowflake messageId, bool logging = false)
    {
        var response = await HttpHelper.SendRequestAsync($"/channels/{interaction.ChannelId}/messages/{messageId}");
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to message: {response.StatusCode}\n{body}");
        }
        
        if (logging)
            Log.Info($"✅ Message channel: {interaction.Channel.Id}, Contents: {interaction.Message.Content}.");
        
        return await response.Content.ReadFromJsonAsync<Message>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="messageId"></param>
    /// <param name="type"></param>
    /// <param name="logging"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Message> CreateThreadAsync(string name, Snowflake messageId, int type = 11, bool logging = false)
    {
        var payload = new
        {
            name,
            type,
            message_id = messageId
        };
        
        var response = await HttpHelper.SendRequestAsync($"/channels/{Id}/threads", "POST", payload);
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to create thread: {response.StatusCode}\n{body}");
        }
        
        if (logging)
            Log.Info($"✅ Successfully created thread: {name}.");
        
        return await response.Content.ReadFromJsonAsync<Message>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="channelId"></param>
    /// <param name="logging"></param>
    /// <exception cref="Exception"></exception>
    public async Task SendTypingAsync(Snowflake channelId, bool logging = false)
    {
        var response = await HttpHelper.SendRequestAsync($"/channels/{channelId}/typing", "POST");
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to send typing state: {response.StatusCode}\n{body}");
        }
        
        if (logging)
            Log.Info($"✅ Successfully set typing state.");
    }

    #region Static Methods
    
    /// <summary>
    /// Asynchronously deletes a channel with the specified channel ID.
    /// </summary>
    /// <param name="channelId">The unique identifier of the channel to be deleted.</param>
    /// <param name="logging">Optional logging to show if the channel was created or not.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="Exception">Thrown if the deletion operation fails, including details about the failure.</exception>
    public static async Task DeleteChannelAsync(string channelId, bool logging = false)
    {
        var payload = new
        {
            channel_id = channelId
        };

        var url = $"/channels/{channelId}";
        
        var response = await HttpHelper.SendRequestAsync(url, "DELETE", payload);
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to delete channel: {response.StatusCode}\n{body}");
        }
        
        if (logging)
            Log.Info($"✅ Deleted channel '{channelId}' in.");
    }
    
    /// <summary>
    /// Asynchronously sends a specified message in a specified channel.
    /// </summary>
    /// <param name="channelId"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static async Task SendMessageAsync(string channelId, string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            return;

        var payload = new { content = message };

        var res = await HttpHelper.SendRequestAsync($"/channels/{channelId}/messages", "POST", payload);
        if (!res.IsSuccessStatusCode)
        {
            Log.Error($"Failed to send message in channel: {res.StatusCode}\n{await res.Content.ReadAsStringAsync()}");
        }
    }
    
    /// <summary>
    /// Asynchronously creates a new channel with the specified parameters in a guild.
    /// </summary>
    /// <param name="guildId">The ID of the guild where the channel will be created.</param>
    /// <param name="name">The name of the channel to be created.</param>
    /// <param name="type">The type of channel to be created. Defaults to GuildText.</param>
    /// <param name="parentId">Optional ID of the parent category under which the channel will be created.</param>
    /// <param name="position">Optional position of the channel in relation to other channels in the same category.</param>
    /// <param name="logging">Optional logging to show if the channel was created or not.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the newly created channel.</returns>
    public static async Task CreateChannelAsync(string guildId, string name, ChannelType type = ChannelType.GuildText, string? parentId = null, int? position = null, bool logging = false)
    {
        var payload = new
        {
            name,
            type = (int)type,
            parentId = parentId ?? "",
            position = position ?? 0,
        };

        var url = $"/guilds/{guildId}/channels";

        var response = await HttpHelper.SendRequestAsync(url, "POST", payload);
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to create channel: {response.StatusCode}\n{body}");
        }

        if (logging)
            Log.Info($"✅ Created channel '{name}' in guild {guildId}");
    }
    #endregion
}