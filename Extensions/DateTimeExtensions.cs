using SharpCord.Types;

namespace SharpCord.Extensions;

/// <summary>
/// Provides a set of extension methods for the <see cref="System.DateTime"/> type
/// adding additional functionality not included in the standard library.
/// </summary>
public static class DateTimeExtensions
{
    internal const long DiscordEpoch = 1420070400000;
    
    
    /// <summary>
    /// Creates a Snowflake from a given UTC timestamp based on the Discord epoch.
    /// </summary>
    /// <param name="timestamp">The UTC DateTimeOffset to convert.</param>
    /// <returns>The corresponding Snowflake.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the timestamp is before Discord's epoch.</exception>
    public static Snowflake ToSnowflake(this DateTimeOffset timestamp)
    {
        long msSinceEpoch = timestamp.ToUnixTimeMilliseconds() - DiscordEpoch;
        if (msSinceEpoch < 0)
            throw new ArgumentOutOfRangeException(nameof(timestamp), "Timestamp must be after the Discord epoch (2015-01-01T00:00:00Z).");
        
        ulong snowflake = (ulong)msSinceEpoch << 22;
        return new Snowflake(snowflake);
    }
}