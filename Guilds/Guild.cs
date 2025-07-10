using System.Text.Json;
using SharpCord.Helpers;
using SharpCord.Messages;
using SharpCord.Models;
using SharpCord.Types;
using SharpCord.Utils;

namespace SharpCord.Guilds;

/// <summary>
/// 
/// </summary>
public class Guild : BaseGuild
{
    public Message Message { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<BaseGuildMember?> GetMemberAsync(Snowflake userId)
    {
        var url = $"/guilds/{Id}/members/{userId}";
        var response = await HttpHelper.SendRequestAsync(url);
        
        if (!response.IsSuccessStatusCode)
            return null;

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<BaseGuildMember>(json);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public async Task<List<BaseGuildMember>> GetMembersWithRoleAsync(Snowflake roleId)
    {
        var members = new List<BaseGuildMember>();
        var url = $"/guilds/{Id}/members?limit=1000";
        
        var response = await HttpHelper.SendRequestAsync(url);
        if (!response.IsSuccessStatusCode)
        {
            Log.Error($"Failed to fetch members: {response.StatusCode}");
            return members;
        }
        
        var json = await response.Content.ReadAsStringAsync();
        var allMembers = JsonSerializer.Deserialize<List<BaseGuildMember>>(json) ?? [];
        
        foreach (var member in allMembers)
        {
            if (member.Roles.Contains(roleId))
                members.Add(member);
        }
        
        return members;
    }
}