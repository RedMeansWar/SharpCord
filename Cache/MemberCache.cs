using SharpCord.Guilds;
using SharpCord.Types;

namespace SharpCord.Cache;

/// <summary>
/// 
/// </summary>
public class MemberCache : MemoryCache<Member>
{
    /// <summary>
    /// 
    /// </summary>
    internal readonly Dictionary<Snowflake, Dictionary<Snowflake, Member>> _guildMembers = new();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="guildId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public Member? Get(Snowflake guildId, Snowflake userId)
    {
        if (_guildMembers.TryGetValue(guildId, out var users))
            return users.TryGetValue(userId, out var member) ? member : null;

        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="guildId"></param>
    /// <param name="userId"></param>
    /// <param name="member"></param>
    public void Set(Snowflake guildId, Snowflake userId, Member member)
    {
        if (!_guildMembers.ContainsKey(guildId))
            _guildMembers[guildId] = new Dictionary<Snowflake, Member>();

        _guildMembers[guildId][userId] = member;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="guildId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public bool Remove(Snowflake guildId, Snowflake userId) =>
        _guildMembers.TryGetValue(guildId, out var users) && users.Remove(userId);
}