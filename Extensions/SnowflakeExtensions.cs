using SharpCord.Types;

namespace SharpCord.Extensions;

/// <summary>
/// Provides extension methods for working with Snowflake identifiers in the context of object mentions.
/// </summary>
public static class SnowflakeExtensions
{
    internal const long DiscordEpoch = 1420070400000;
    
    /// <summary>
    /// Creates a mention string for a user using their unique identifier.
    /// </summary>
    /// <param name="snowflake">The current instance of the Snowflake struct.</param>
    /// <param name="userId">The unique identifier of the user to be mentioned.</param>
    /// <returns>A string that mentions the user in the format supported by Discord.</returns>
    public static string MentionUser(this Snowflake snowflake, int userId) => $"<@{userId}>";

    /// <summary>
    /// Creates a mention string for a user using their unique identifier.
    /// </summary>
    /// <param name="snowflake">The current instance of the Snowflake struct.</param>
    /// <param name="userId">The unique identifier of the user to be mentioned.</param>
    /// <returns>A string that mentions the user in the format supported by Discord.</returns>
    public static string MentionUser(this Snowflake snowflake, ulong userId) => $"<@{userId}>";

    /// <summary>
    /// Creates a mention string for a user using their unique identifier.
    /// </summary>
    /// <param name="snowflake">The current instance of the Snowflake struct.</param>
    /// <param name="userId">The unique identifier of the user to be mentioned.</param>
    /// <returns>A string that mentions the user in the format supported by Discord.</returns>
    public static string MentionUser(this Snowflake snowflake, string userId) => $"<@{int.Parse(userId)}>";

    /// <summary>
    /// Creates a mention string for a channel using its unique identifier.
    /// </summary>
    /// <param name="snowflake">The current instance of the Snowflake struct.</param>
    /// <param name="channelId">The unique identifier of the channel to be mentioned.</param>
    /// <returns>A string that mentions the channel in the format supported by Discord.</returns>
    public static string MentionChannel(this Snowflake snowflake, int channelId) => $"<#{channelId}>";

    /// <summary>
    /// Creates a mention string for a channel using its unique identifier.
    /// </summary>
    /// <param name="snowflake">The current instance of the Snowflake struct.</param>
    /// <param name="channelId">The unique identifier of the channel to be mentioned.</param>
    /// <returns>A string that mentions the channel in the format supported by Discord.</returns>
    public static string MentionChannel(this Snowflake snowflake, ulong channelId) => $"<#{channelId}>";

    /// <summary>
    /// Creates a mention string for a channel using its unique identifier.
    /// </summary>
    /// <param name="snowflake">The current instance of the Snowflake struct.</param>
    /// <param name="channelId">The unique identifier of the channel to be mentioned.</param>
    /// <returns>A string that mentions the channel in the format supported by Discord.</returns>
    public static string MentionChannel(this Snowflake snowflake, string channelId) => $"<#{ulong.Parse(channelId)}>";

    /// <summary>
    /// Converts the Snowflake instance to a DateTime representing the timestamp encoded within the Snowflake.
    /// </summary>
    /// <param name="snowflake">The current instance of the Snowflake struct to be converted.</param>
    /// <returns>A DateTime object corresponding to the timestamp encoded within the Snowflake in UTC.</returns>
    public static DateTime ToDateTime(this Snowflake snowflake)
    {
        var timestamp = (long)((snowflake.Value >> 22) + DiscordEpoch);
        return DateTimeOffset.FromUnixTimeMilliseconds(timestamp).UtcDateTime;
    }

    /// <summary>
    /// Converts a Snowflake identifier to its corresponding Unix timestamp.
    /// </summary>
    /// <param name="snowflake">The instance of the Snowflake struct to convert.</param>
    /// <returns>The Unix timestamp representation of the Snowflake, in milliseconds.</returns>
    public static long ToUnixTime(this Snowflake snowflake) => (long)((snowflake.Value >> 22) + DiscordEpoch);

    /// <summary>
    /// Converts a Snowflake's creation time to a Unix timestamp (in milliseconds).
    /// </summary>
    public static long ToUnixTimeMilliseconds(this Snowflake snowflake) => snowflake.CreatedAt.ToUnixTimeMilliseconds();

    /// <summary>
    /// Gets the age of the Snowflake (i.e., time since creation).
    /// </summary>
    /// <param name="snowflake">The Snowflake instance.</param>
    /// <returns>The elapsed time since the Snowflake's creation.</returns>
    public static TimeSpan Age(this Snowflake snowflake) => DateTimeOffset.UtcNow - snowflake.CreatedAt;

    /// <summary>
    /// Determines if the Snowflake was created within the specified time span from now.
    /// </summary>
    /// <param name="snowflake">The Snowflake to check.</param>
    /// <param name="timeSpan">The time span to compare against.</param>
    /// <returns>True if the Snowflake is recent; otherwise, false.</returns>
    public static bool IsRecent(this Snowflake snowflake, TimeSpan timeSpan) => snowflake.Age() <= timeSpan;
    
    // <summary>
    /// Formats the creation date of the Snowflake as a readable string.
    /// </summary>
    /// <param name="snowflake">The Snowflake instance.</param>
    /// <param name="format">Optional date format string. Defaults to 'yyyy-MM-dd HH:mm:ss UTC'.</param>
    /// <returns>The formatted creation timestamp.</returns>
    public static string ToFormattedDate(this Snowflake snowflake, string format = "yyyy-MM-dd HH:mm:ss 'UTC'") => snowflake.CreatedAt.UtcDateTime.ToString(format);
    
    /// <summary>
    /// Determines whether this Snowflake was created before another Snowflake.
    /// </summary>
    /// <param name="snowflake">The first Snowflake.</param>
    /// <param name="other">The second Snowflake.</param>
    /// <returns>True if snowflake is before other; otherwise, false.</returns>
    public static bool IsBefore(this Snowflake snowflake, Snowflake other) => snowflake.Value < other.Value;
    
    /// <summary>
    /// Determines whether this Snowflake was created after another Snowflake.
    /// </summary>
    /// <param name="snowflake">The first Snowflake.</param>
    /// <param name="other">The second Snowflake.</param>
    /// <returns>True if snowflake is after other; otherwise, false.</returns>
    public static bool IsAfter(this Snowflake snowflake, Snowflake other) => snowflake.Value > other.Value;
    
    /// <summary>
    /// Extracts the internal Discord worker ID from the Snowflake.
    /// </summary>
    /// <param name="snowflake">The Snowflake instance.</param>
    /// <returns>The worker ID portion of the Snowflake.</returns>
    public static int GetWorkerId(this Snowflake snowflake) => (int)((snowflake.Value & 0x3E0000) >> 17);
    
    /// <summary>
    /// Extracts the internal process ID from the Snowflake.
    /// </summary>
    /// <param name="snowflake">The Snowflake instance.</param>
    /// <returns>The process ID portion of the Snowflake.</returns>
    public static int GetProcessId(this Snowflake snowflake) => (int)((snowflake.Value & 0x1F000) >> 12);
    
    /// <summary>
    /// Extracts the sequence/increment portion from the Snowflake.
    /// </summary>
    /// <param name="snowflake">The Snowflake instance.</param>
    /// <returns>The increment value from the Snowflake.</returns>
    public static int GetIncrement(this Snowflake snowflake) => (int)(snowflake.Value & 0xFFF);
    
    /// <summary>
    /// Returns a detailed breakdown of the Snowflake's components (timestamp, worker, process, increment).
    /// </summary>
    /// <param name="snowflake">The Snowflake to describe.</param>
    /// <returns>A formatted string containing detailed metadata about the Snowflake.</returns>
    public static string Describe(this Snowflake snowflake)
        => $"""
            Snowflake: {snowflake.Value}
            Timestamp: {snowflake.CreatedAt:O}
            Worker ID: {snowflake.GetWorkerId()}
            Process ID: {snowflake.GetProcessId()}
            Increment: {snowflake.GetIncrement()}
            """;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="snowflake"></param>
    /// <returns></returns>
    public static string ToBase62(this Snowflake snowflake)
    {
        const string alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        ulong num = snowflake.Value;
        var sb = new System.Text.StringBuilder();

        while (num > 0)
        {
            sb.Insert(0, alphabet[(int)(num % 62)]);
            num /= 62;
        }

        return sb.Length > 0 ? sb.ToString() : "0";
    }

}