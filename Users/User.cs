using System.Text.Json;
using System.Text.Json.Serialization;
using SharpCord.Guilds;
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
    public string Mention => $"<@{Id}>";
    
    /// <summary>
    /// 
    /// </summary>
    public string Tag => $"{Username}#{Discriminator}";
    
    /// <summary>
    /// 
    /// </summary>
    public bool HasDefaultAvatar => string.IsNullOrEmpty(Avatar);

    /// <summary>
    /// 
    /// </summary>
    public DateTimeOffset CreatedAt => Id.CreatedAt;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="format"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public string GetAvatarUrl(ImageFormat format = ImageFormat.PNG, int size = 1024) => !string.IsNullOrWhiteSpace(Avatar)
        ? $"https://cdn.discordapp.com/avatars/{Id}/{Avatar}.{format.ToString().ToLower()}?size={size}"
        : $"https://cdn.discordapp.com/embed/avatars/{(int)(Id.Value % 5)}.png";
    
    /// <summary>
    /// 
    /// </summary>
    public string AvatarUrl => GetAvatarUrl(ImageFormat.PNG);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="format"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public string? GetBannerUrl(ImageFormat format = ImageFormat.PNG, int size = 1024) => !string.IsNullOrWhiteSpace(Banner)
        ? $"https://cdn.discordapp.com/banners/{Id}/{Banner}.{format.ToString().ToLower()}?size={size}"
        : null;
    
    /// <summary>
    /// 
    /// </summary>
    public string? BannerUrl => GetBannerUrl();

    public List<UserFlags> GetBadges()
    {
        if (PublicFlags is null)
            return new();

        return Enum.GetValues(typeof(UserFlags))
            .Cast<UserFlags>()
            .Where(flag => flag is not UserFlags.None && PublicFlags.Value.HasFlag(flag))
            .ToList();
    }

    /// <summary>
    /// 
    /// </summary>
    public bool HasAnimatedAvatar => Avatar?.StartsWith("a_") == true;
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GetAvatarFormat() => HasAnimatedAvatar ? "gif" : "png";
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public string GetAvatarUrl(int size = 1024) => $"https://cdn.discordapp.com/avatars/{Id}/{Avatar}.{GetAvatarFormat()}?size={size}";

    public TimeSpan AccountAge => DateTimeOffset.UtcNow - CreatedAt;
}