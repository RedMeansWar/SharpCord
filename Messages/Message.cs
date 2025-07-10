using System.Net;
using System.Net.Http.Json;
using SharpCord.Guilds;
using SharpCord.Helpers;
using SharpCord.Models;
using SharpCord.Utils;
using SharpCord.Interactions;
using SharpCord.Types;
using SharpCord.Users;

namespace SharpCord.Messages;

public class Message : BaseMessage
{
    public Guild Guild { get; set; }
    public User User { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="content"></param>
    /// <param name="logging"></param>
    /// <param name="embeds"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Message> SendMessageAsync(string content, List<Embed>? embeds = null, bool logging = false)
    {
        var payload = new { content };
        var response = await HttpHelper.SendRequestAsync($"/channels/{ChannelId}/messages", "POST", payload);
        
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to send message: {response.StatusCode}\n{body}");
        }
        
        if (logging)
            Log.Info("✅ Successfully sent message.");
        
        return await response.Content.ReadFromJsonAsync<Message>();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="emoji"></param>
    /// <exception cref="Exception"></exception>
    public async Task AddReactionAsync(string emoji, bool logging = false)
    {
        var encodedEmoji = Uri.EscapeDataString(emoji);
        var url = $"/channels/{ChannelId}/messages/{Id}/reactions/{encodedEmoji}/@me";
        var response = await HttpHelper.SendRequestAsync(url, "PUT");

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to add reaction: {response.StatusCode}\n{body}");
        }
        
        if (logging)
            Log.Info("✅ Successfully added reaction to message.");
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="emoji"></param>
    /// <param name="logging"></param>
    /// <exception cref="Exception"></exception>
    public async Task RemoveReactionAsync(string emoji, bool logging = false)
    {
        var encodedEmoji = Uri.EscapeDataString(emoji);
        var url = $"/channels/{ChannelId}/messages/{Id}/reactions/{encodedEmoji}/@me";
        
        var response = await HttpHelper.SendRequestAsync(url, "DELETE");
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to remove reaction: {response.StatusCode}\n{body}");
        }
        
        if (logging)
            Log.Info("✅ Successfully removed reaction to message.");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="logging"></param>
    /// <exception cref="Exception"></exception>

    public async Task DeleteAsync(bool logging = false)
    {
        var url = $"/channels/{ChannelId}/messages/{Id}";
        var response = await HttpHelper.SendRequestAsync(url, "DELETE");

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to delete channel: {response.StatusCode}\n{body}");
        }
        
        if (logging)
            Log.Info("✅ Successfully deleted channel.");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="newContent"></param>
    /// <param name="logging"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Message> EditAsync(string newContent, bool logging = false)
    {
        var payload = new { content = newContent };
        var url = $"/channels/{ChannelId}/messages/{Id}";
        
        var response = await HttpHelper.SendRequestAsync(url, "PATCH", payload);
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to edit message: {response.StatusCode}\n{body}");
        }
        
        if (logging)
            Log.Info("✅ Successfully edited message.");

        return await response.Content.ReadFromJsonAsync<Message>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="content"></param>
    /// <param name="logging"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Message> ReplyAsync(string content, bool logging = false)
    {
        var payload = new
        {
            content,
            message_reference = new
            {
                message_id = Id,
                channel_id = ChannelId
            }
        };
        
        var url = $"/channels/{ChannelId}/messages";
        var response = await HttpHelper.SendRequestAsync(url, "PATCH", payload);
        
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to edit message: {response.StatusCode}\n{body}");
        }
        
        if (logging)
            Log.Info("✅ Successfully edited message.");
        
        return await response.Content.ReadFromJsonAsync<Message>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logging"></param>
    /// <exception cref="Exception"></exception>
    public async Task CrosspostAsync(bool logging = false)
    {
        var response = await HttpHelper.SendRequestAsync($"/channels/{ChannelId}/messages/{Id}/crosspost");
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to crosspost message: {response.StatusCode}\n{body}");
        }
        
        if (logging)
            Log.Info("✅ Successfully crossposted message.");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="suppress"></param>
    /// <param name="logging"></param>
    /// <exception cref="Exception"></exception>
    public async Task SuppressEmbedsAsync(bool suppress = true, bool logging = false)
    {
        var flags = suppress ? 4 : 0;
        var payload = new { flags };
        
        var response = await HttpHelper.SendRequestAsync($"/channels/{ChannelId}/messages/{Id}", "PATCH", payload);
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to suppress embeds: {response.StatusCode}\n{body}");
        }
        
        if (logging)
            Log.Info("✅ Successfully suppressed embeds.");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logging"></param>
    /// <exception cref="Exception"></exception>
    public async Task PinAsync(bool logging = false)
    {
        var response = await HttpHelper.SendRequestAsync($"/channels/{ChannelId}/pins/{Id}", "PUT");
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to pin message: {response.StatusCode}\n{body}");
        }
        
        if (logging)
            Log.Info("✅ Successfully pinned message.");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logging"></param>
    /// <exception cref="Exception"></exception>
    public async Task UnpinAsync(bool logging = false)
    {
        var response = await HttpHelper.SendRequestAsync($"/channels/{ChannelId}/pins/{Id}", "PUT");
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to unpin message: {response.StatusCode}\n{body}");
        }
        
        if (logging)
            Log.Info("✅ Successfully pinned message.");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="content"></param>
    /// <param name="sendAt"></param>
    /// <returns></returns>
    public async Task<Message> ScheduleSendMessage(string content, DateTimeOffset sendAt)
    {
        var delay = sendAt - DateTimeOffset.UtcNow;
        return await Task.Delay(delay).ContinueWith(_ => SendMessageAsync(content)).Unwrap();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ttl"></param>
    public async Task DeleteMessageAfterAsync(TimeSpan ttl) => await Task.Delay(ttl).ContinueWith(_ => DeleteAsync()).Unwrap();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="seconds"></param>
    public async Task DeleteMessageAfterAsync(int seconds) => await Task.Delay(seconds * 1000).ContinueWith(_ => DeleteAsync()).Unwrap();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ttl"></param>
    public async Task DeleteAfterAsync(TimeSpan ttl) => await DeleteMessageAfterAsync(ttl);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="seconds"></param>
    public async Task DeleteAfterAsync(int seconds) => await Task.Delay(seconds * 1000).ContinueWith(_ => DeleteAsync()).Unwrap();
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GetJumpUrl() => $"https://discord.com/channels/{Guild?.Id ?? "@me"}/{ChannelId}/{Id}";

    #region Static Methods
    /// <summary>
    /// 
    /// </summary>
    /// <param name="channelId"></param>
    /// <param name="messageId"></param>
    /// <param name="logging"></param>
    /// <exception cref="Exception"></exception>
    public static async Task PinMessageAsync(string channelId, string messageId, bool logging = false)
    {
        var response = await HttpHelper.SendRequestAsync($"/channels/{channelId}/pins/{messageId}", "PUT");
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to pin message: {response.StatusCode}\n{body}");
        }
        
        if (logging)
            Log.Info("✅ Successfully pinned message.");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="channelId"></param>
    /// <param name="messageId"></param>
    /// <param name="logging"></param>
    /// <exception cref="Exception"></exception>
    public static async Task UnpinMessageAsync(string channelId, string messageId, bool logging = false)
    {
        var response = await HttpHelper.SendRequestAsync($"/channels/{channelId}/pins/{messageId}", "PUT");
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to unpin message: {response.StatusCode}\n{body}");
        }
        
        if (logging)
            Log.Info("✅ Successfully pinned message.");
    }
    #endregion
    
}