using SharpCord.Helpers;
using SharpCord.Interfaces;
using SharpCord.Models;
using SharpCord.Types;
using SharpCord.Utils;

namespace SharpCord.Guilds;

/// <summary>
/// 
/// </summary>
public class KickManager : BaseUser
{
    /// <summary>
    /// 
    /// </summary>
    public DiscordClient Client { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public Guild Guild { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="client"></param>
    /// <param name="guild"></param>
    public KickManager(DiscordClient client, Guild guild)
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
    public async Task KickAsync(Snowflake userId, IKickOptions? options = null, bool logging = false)
    {
        var url = $"/guilds/{Guild.Id}/members/{userId}";
        var headers = new Dictionary<string, string>();

        if (!string.IsNullOrWhiteSpace(options?.Reason))
            headers["X-Audit-Log-Reason"] = options.Reason;
        
        var response = await HttpHelper.SendRequestAsync(url, "DELETE", headers: headers);
        if (!response.IsSuccessStatusCode)
        {
            string error = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to kick user: {response.StatusCode}\n{error}");
        }
        
        if (logging)
            Log.Info($"✅ Successfully kicked {Username} (#{Id})");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userIds"></param>
    /// <param name="options"></param>
    /// <param name="delayMs"></param>
    public async Task KickInBulkAsync(IEnumerable<Snowflake> userIds, IKickOptions? options = null, int delayMs = 0)
    {
        foreach (var userId in userIds)
        {
            await KickAsync(userId, options);
            if (delayMs > 0)
            {
                await Task.Delay(delayMs);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roleId"></param>
    /// <param name="options"></param>
    /// <param name="delayMil"></param>
    public async Task KickAllWithRoleAsync(Snowflake roleId, IKickOptions? options = null, int delayMs = 0)
    {
        var members =  await Guild.GetMembersWithRoleAsync(roleId);
        foreach (var member in members)
        {
            await KickAsync(member.Id, options);
            if (delayMs > 0)
                await Task.Delay(delayMs);
        }
    }
}