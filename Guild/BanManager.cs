using System.Text.Json;
using SharpCord.Helpers;
using SharpCord.Interfaces;
using SharpCord.Models;
using SharpCord.Types;
using SharpCord.Utils;

namespace SharpCord.Guild;

public class BanManager
{
    /// <summary>
    /// 
    /// </summary>
    public DiscordClient Client { get; }
    
    /// <summary>
    /// 
    /// </summary>
    public BaseGuild Guild { get; }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="client"></param>
    /// <param name="guild"></param>
    public BanManager(DiscordClient client, BaseGuild guild)
    {
        Client = client;
        Guild = guild;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="options"></param>
    /// <exception cref="Exception"></exception>
    public async Task BanAsync(Snowflake userId, IBanOptions? options = null)
    {
        var url = $"/guilds/{Guild.Id}/bans/{userId}";
        var payload = new Dictionary<string, object?>();

        if (options is not null)
        {
            if (options.DeleteMessagesAfter is int seconds and >= 0 and <= 604800)
                payload["delete_message_seconds"] = seconds;
            
            if (!string.IsNullOrWhiteSpace(options.Reason))
                payload["reason"] = options.Reason;
        }

        var headers = new Dictionary<string, string>();
        if (options?.Reason is { } reason && !string.IsNullOrWhiteSpace(reason))
            headers["X-Audit-Log-Reason"] = reason;
        
        var json = JsonSerializer.Serialize(payload);
        var response = await HttpHelper.SendRequestAsync(url, "PUT", json, headers: headers);

        if (!response.IsSuccessStatusCode)
        {
            string error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to ban user: {response.StatusCode}\n{error}");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userIds"></param>
    /// <param name="options"></param>
    /// <param name="delayMs"></param>
    public async Task BanInBulkAsync(IEnumerable<Snowflake> userIds, IBanOptions? options = null, int delayMs = 0)
    {
        foreach (var userId in userIds)
        {
            await BanAsync(userId, options);
            if (delayMs > 0)
            {
                await Task.Delay(delayMs);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="reason"></param>
    /// <exception cref="Exception"></exception>
    public async Task UnbanAsync(Snowflake userId, string? reason = null)
    {
        var url = $"/guilds/{Guild.Id}/bans/{userId}";
        var headers = new Dictionary<string, string>();
        
        if (!string.IsNullOrWhiteSpace(reason))
            headers["X-Audit-Log-Reason"] = reason;
        
        var response = await HttpHelper.SendRequestAsync(url, "DELETE", headers: headers);
        if (!response.IsSuccessStatusCode)
        {
            string error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to unban user: {response.StatusCode}\n{error}");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<BanInfo?> GetBanAsync(Snowflake userId)
    {
        var url = $"/guilds/{Guild.Id}/bans/{userId}";
        var response = await HttpHelper.SendRequestAsync(url);
        if (!response.IsSuccessStatusCode)
            return null;
        
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<BanInfo>(json);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<List<BanInfo>> GetBansAsync()
    {
        var path = $"/guilds/{Guild.Id}/bans";
        var response = await HttpHelper.SendRequestAsync(path);
        
        if (!response.IsSuccessStatusCode)
            return new();
        
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<BanInfo>>(json) ?? new();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public async Task<BanInfo?> FindBanByNameAsync(string username)
    {
        var bans = await GetBansAsync();
        return bans.FirstOrDefault(x => 
            string.Equals(x.User.Username, username, StringComparison.OrdinalIgnoreCase) ||
            string.Equals($"{x.User.Username}#{x.User.Discriminator}", username, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// 
    /// </summary>
    public async Task PurgeAllBansAsync()
    {
        var bans = await GetBansAsync();
        foreach (var ban in bans)
        {
            await UnbanAsync(ban.User.Id);
            await Task.Delay(250); // avoid rate limits
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filePath"></param>
    public async Task GetBanCountAsync(string filePath = "bans.json")
    {
        var bans = await GetBansAsync();
        var json = JsonSerializer.Serialize(bans, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(filePath, json);
        Log.Info($"Exported {bans.Count} bans to {filePath}.");
    }
}