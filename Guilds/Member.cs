using System.Net.Http.Json;
using SharpCord.Helpers;
using SharpCord.Models;

namespace SharpCord.Guilds;

public class Member : BaseGuildMember
{
    public Guild Guild { get; set; }
    
    /// <summary>
    /// The member's display name (nickname or username).
    /// </summary>
    public string DisplayName => 
        !string.IsNullOrEmpty(Nickname) ? Nickname :
        !string.IsNullOrEmpty(User.GlobalName) ? User.GlobalName : User.Username;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="permission"></param>
    /// <returns></returns>
    public bool HasPermission(PermissionFlags permission) => (ComputedPermissions & permission) == permission;
    
    /// <summary>
    /// 
    /// </summary>
    public bool IsOwner => User.Id == Guild.OwnerId;
    
    /// <summary>
    /// 
    /// </summary>
    public bool IsAdmin => HasPermission(PermissionFlags.Administrator);
    
    /// <summary>
    /// 
    /// </summary>
    public string Mention => $"<@{User.Id}>";
    
    /// <summary>
    /// 
    /// </summary>
    public string DisplayTag => $"{DisplayName}#{User.Discriminator}";

    /// <summary>
    /// 
    /// </summary>
    public TimeSpan? TimeInGuild => JoinedAt.HasValue
        ? DateTimeOffset.UtcNow - JoinedAt.Value
        : null;

    /// <summary>
    /// /
    /// </summary>
    /// <returns></returns>
    public IEnumerable<string> GetRoleMentions => Roles.Select(r => $"<@&{r}>");

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IEnumerable<string> GetReadablePermissions()
    {
        return Enum.GetValues(typeof(PermissionFlags))
            .Cast<PermissionFlags>()
            .Where(flag => flag is not PermissionFlags.None && HasPermission(flag))
            .Select(flag => flag.ToString());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Channel> CreateDMAsync()
    {
        var payload = new { recipient_id = User.Id };
        
        var response = await HttpHelper.SendRequestAsync("/users/@me/channels", "POST", payload);
        if (!response.IsSuccessStatusCode)
        {
            string error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to create DM: {response.StatusCode}\n{error}");
        }

        return await response.Content.ReadFromJsonAsync<Channel>();
    }
}