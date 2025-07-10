using SharpCord.Types;

namespace SharpCord.Errors;

public class InvalidChannelException : DiscordException
{
    public InvalidChannelException(Snowflake channelId) : base(4004, $"Channel with ID {channelId} not found or not accessible.") {}
}