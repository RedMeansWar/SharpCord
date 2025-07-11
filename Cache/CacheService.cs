namespace SharpCord.Cache;

/// <summary>
/// 
/// </summary>
public class CacheService
{
    /// <summary>
    /// 
    /// </summary>
    public UserCache UserCache { get; } = new();
    
    /// <summary>
    /// 
    /// </summary>
    public GuildCache GuildCache { get; } = new();
    
    /// <summary>
    /// 
    /// </summary>
    public MemberCache MemberCache { get; } = new();
    
    /// <summary>
    /// 
    /// </summary>
    public static CacheService Instance { get; } = new(); // Singleton
}