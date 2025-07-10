using SharpCord.Types;

namespace SharpCord.Extensions;

/// <summary>
/// 
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Gets the smallest (oldest) Snowflake from the collection.
    /// </summary>
    /// <param name="snowflakes">The collection of Snowflakes.</param>
    /// <returns>The minimum Snowflake.</returns>
    public static Snowflake MinSnowflake(this IEnumerable<Snowflake> snowflakes) => snowflakes.MinBy(s => s.Value);
    
    /// <summary>
    /// Gets the largest (most recent) Snowflake from the collection.
    /// </summary>
    /// <param name="snowflakes">The collection of Snowflakes.</param>
    /// <returns>The maximum Snowflake.</returns>
    public static Snowflake MaxSnowflake(this IEnumerable<Snowflake> snowflakes) => snowflakes.MaxBy(s => s.Value);
    
    /// <summary>
    /// Finds the most recent Snowflake that was created before a given timestamp.
    /// </summary>
    /// <param name="snowflakes">The Snowflake collection.</param>
    /// <param name="timestamp">The cutoff timestamp.</param>
    /// <returns>The first Snowflake before the given time, or null.</returns>
    public static Snowflake? FirstBefore(this IEnumerable<Snowflake> snowflakes, DateTimeOffset timestamp)
    {
        var cutoff = timestamp.ToSnowflake();
        return snowflakes.Where(s => s < cutoff).OrderByDescending(s => s.Value).FirstOrDefault();
    }

    /// <summary>
    /// Finds the first Snowflake created after a given timestamp.
    /// </summary>
    /// <param name="snowflakes">The Snowflake collection.</param>
    /// <param name="timestamp">The cutoff timestamp.</param>
    /// <returns>The first Snowflake after the given time, or null.</returns>
    public static Snowflake? FirstAfter(this IEnumerable<Snowflake> snowflakes, DateTimeOffset timestamp)
    {
        var cutoff = timestamp.ToSnowflake();
        return snowflakes.Where(s => s > cutoff).OrderBy(s => s.Value).FirstOrDefault();
    }

    /// <summary>
    /// Filters Snowflakes that were created between the specified start and end timestamps.
    /// </summary>
    /// <param name="snowflakes">The collection of Snowflakes.</param>
    /// <param name="start">The start timestamp.</param>
    /// <param name="end">The end timestamp.</param>
    /// <returns>An enumerable of Snowflakes in the time range.</returns>
    public static IEnumerable<Snowflake> WhereCreatedBetween(this IEnumerable<Snowflake> snowflakes, DateTimeOffset start, DateTimeOffset end)
    {
        var from = start.ToSnowflake();
        var to = end.ToSnowflake();
        return snowflakes.Where(s => s >= from && s <= to);
    }
}