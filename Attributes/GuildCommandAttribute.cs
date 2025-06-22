namespace SharpCord.Attributes;

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public class GuildCommandAttribute : CommandAttribute
{
    /// <summary>
    /// 
    /// </summary>
    public string GuildId { get; }

    /// <summary>
    /// /
    /// </summary>
    /// <param name="name"></param>
    /// <param name="guildId"></param>
    public GuildCommandAttribute(string name, string guildId) : base(name) => GuildId = guildId;
}