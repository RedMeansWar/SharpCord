namespace SharpCord.Attributes;

[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public class GuildCommandAttribute : CommandAttribute
{
    public string GuildId { get; }

    public GuildCommandAttribute(string name, string guildId) : base(name) => GuildId = guildId;
}