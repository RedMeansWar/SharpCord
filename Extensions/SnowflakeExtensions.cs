#region LICENSE
// Copyright (c) 2025 RedMeansWar
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using SharpCord.Types;

namespace SharpCord.Extensions;

/// <summary>
/// Provides extension methods for working with Snowflake identifiers in the context of object mentions.
/// </summary>
public static class SnowflakeExtensions
{
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
    public static string MentionChannel(this Snowflake snowflake, string channelId) => $"<#{int.Parse(channelId)}>";

    /// <summary>
    /// Converts the Snowflake instance to a DateTime representing the timestamp encoded within the Snowflake.
    /// </summary>
    /// <param name="snowflake">The current instance of the Snowflake struct to be converted.</param>
    /// <returns>A DateTime object corresponding to the timestamp encoded within the Snowflake in UTC.</returns>
    public static DateTime ToDateTime(this Snowflake snowflake)
    {
        var timestamp = (long)((snowflake.Value >> 22) + 1420070400000);
        return DateTimeOffset.FromUnixTimeMilliseconds(timestamp).UtcDateTime;
    }

    /// <summary>
    /// Converts a Snowflake identifier to its corresponding Unix timestamp.
    /// </summary>
    /// <param name="snowflake">The instance of the Snowflake struct to convert.</param>
    /// <returns>The Unix timestamp representation of the Snowflake, in milliseconds.</returns>
    public static long ToUnixTime(this Snowflake snowflake) => (long)((snowflake.Value >> 22) + 1420070400000);
}