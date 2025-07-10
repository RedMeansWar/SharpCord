using SharpCord.Types;

namespace SharpCord.Errors;

public class GuildNotFoundException : Exception
{
    public GuildNotFoundException(Snowflake guildId) : base($"Guild {guildId} not found or inaccessible.") { }
}