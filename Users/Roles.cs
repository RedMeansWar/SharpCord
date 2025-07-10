using System.Net.Http.Headers;
using SharpCord.Helpers;
using SharpCord.Utils;

namespace SharpCord.Users;

public class Roles
{
    public static async Task GiveRoleAsync(string guildId, string userId, string roleId)
    {
        var url = $"/guilds/{guildId}/members/{userId}/roles/{roleId}";
        var response = await HttpHelper.SendRequestAsync(url, "PUT", null);

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            Log.Error($"❌ Failed to assign role: {response.StatusCode}\n{body}");
        }
        
        Log.Info($"✅ Assigned role {roleId} to user {userId} in guild {guildId}.");
    }
}