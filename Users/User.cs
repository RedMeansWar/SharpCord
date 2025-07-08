using System.Text.Json;
using System.Text.Json.Serialization;
using SharpCord.Helpers;
using SharpCord.Interactions;
using SharpCord.Models;
using SharpCord.Types;
using SharpCord.Utils;

namespace SharpCord.Users;

/// <summary>
/// Represents a user in Discord, providing methods to manage user-related operations.
/// </summary>
public class User : BaseUser
{
    /// <summary>
    /// 
    /// </summary>
    public string Tag => $"{Username}#{Discriminator}";
    
    /// <summary>
    /// 
    /// </summary>
    public string AvatarUrl => Avatar is not null ?
        $"https://cdn.discordapp.com/avatars/{Id}/{Avatar}.png"
        : $"https://cdn.discordapp.com/embed/avatars/{Id.Value % 5}.png";
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString() => Tag;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="guildId"></param>
    /// <param name="userId"></param>
    /// <param name="reason"></param>
    /// <param name="logging"></param>
    /// <returns>If kick was successful or not.</returns>
    public static async Task<bool> KickAsync(string guildId, string userId, string reason, bool logging = false)
    {
        string url = $"/guilds/{guildId}/members/{userId}";

        HttpHelper.SetHeader("X-Audit-Log-Reason", reason);
        HttpResponseMessage res = await HttpHelper.SendRequestAsync(url, "DELETE");

        if (!res.IsSuccessStatusCode)
        {
            Log.Error($"Failed to kick user from guild: {res.StatusCode}\n{res.Content.ReadAsStringAsync()}");

            return false;
        }

        if (logging)
            Log.Warning($"Successfully kicked {userId} from {guildId}");

        return true;
    }

    /// <summary>
    /// Checks if a user has the specified permission for a given guild.
    /// </summary>
    /// <param name="guildId">The identifier of the guild where the permission will be checked.</param>
    /// <param name="userId">The identifier of the user whose permissions need to be verified.</param>
    /// <param name="requiredPermission">The specific permission to check for the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the user has the specified permission.</returns>
    public static async Task<bool> HasPermissionsAsync(string guildId, string userId, string requiredPermission, bool logging = false)
    {
        var url = $"/guilds/{guildId}/members/{userId}";

        var response = await HttpHelper.SendRequestAsync(url);
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            Log.Error($"❌ Failed to fetch member permissions: {response.StatusCode}\n{body}");
            return false;
        }
        
        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        var roles = doc.RootElement.GetProperty("roles").EnumerateArray().Select(r => r.GetString()!).ToList();
        
        var rolesUrl = $"/guilds/{guildId}/roles";
        
        var rolesResponse = await HttpHelper.SendRequestAsync(rolesUrl);
        if (!rolesResponse.IsSuccessStatusCode)
        {
            var body = await rolesResponse.Content.ReadAsStringAsync();
            Log.Error($"❌ Failed to fetch guild roles: {rolesResponse.StatusCode}\n{body}");
            return false;
        }
        
        var rolesJson = await rolesResponse.Content.ReadAsStringAsync();
        using var rolesDoc = JsonDocument.Parse(rolesJson);

        ulong combinePerms = 0;
        foreach (var role in rolesDoc.RootElement.EnumerateArray())
        {
            var roleId = role.GetProperty("id").GetString();
            if (roleId is null || !roles.Contains(roleId)) continue;
            
            if (role.TryGetProperty("permissions", out var permsProp) && ulong.TryParse(permsProp.GetString(), out var perms))
                combinePerms |= perms;
        }

        var permsEnum = Enum.TryParse(requiredPermission, ignoreCase: true, out DiscordPermission parsedPerm);
        if (!permsEnum)
        {
            Log.Error($"❌ Unknown permission: {requiredPermission}");
            return false;
        }
        
        bool hasPermission = (combinePerms & (ulong)parsedPerm) == (ulong)parsedPerm;
        
        if (logging) Log.Info($"User {(hasPermission ? "has" : "does not have")} permission: {requiredPermission}");
        return hasPermission;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="guildId"></param>
    /// <param name="userId"></param>
    /// <param name="roleId"></param>
    /// <param name="logging"></param>
    public static async Task AssignRoleAsync(string guildId, string userId, string roleId, bool logging = false)
    {
        var url = $"/guilds/{guildId}/members/{userId}/roles/{roleId}";
        var response = await HttpHelper.SendRequestAsync(url, "PUT");

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            Log.Error($"❌ Failed to assign role: {response.StatusCode}\n{body}");
        }
        
        if (logging) Log.Info($"✅ Assigned role {roleId} to user {userId} in guild {guildId}.");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="interaction"></param>
    /// <param name="roleId"></param>
    /// <param name="logging"></param>
    public static async Task AssignRoleAsync(Interaction interaction, string roleId, bool logging = false)
    {
        var url = $"/guilds/{interaction.GuildId}/members/{interaction.User?.Id}/roles/{roleId}";
        var response = await HttpHelper.SendRequestAsync(url, "PUT");

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            Log.Error($"❌ Failed to assign role: {response.StatusCode}\n{body}");
        }
        
        if (logging) Log.Info($"✅ Assigned role {roleId} to user {interaction.User?.Id} in guild {interaction.User?.Id}.");
    }
}