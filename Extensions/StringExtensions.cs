using SharpCord.Types;

namespace SharpCord.Extensions;

/// <summary>
/// Provides extension methods for formatting and escaping strings with special markdown syntax,
/// commonly used in text-based applications or platforms.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Formats the specified string as bold using markdown syntax.
    /// </summary>
    /// <param name="str">The input string to format as bold.</param>
    /// <returns>A string formatted as bold using double asterisks (**).</returns>
    public static string ToBold(this string str) => $"**{str}**";

    /// <summary>
    /// Formats the specified string as bold using markdown syntax.
    /// </summary>
    /// <param name="str">The input string to format as bold.</param>
    /// <returns>A string formatted as bold using double asterisks (**).</returns>
    public static string Bold(this string str) => ToBold(str);

    /// <summary>
    /// Escapes bold Markdown syntax in the specified string by replacing asterisks (*) with escaped asterisks (\*).
    /// </summary>
    /// <param name="str">The input string from which bold Markdown syntax will be escaped.</param>
    /// <returns>A string with all asterisks replaced by escaped asterisks.</returns>
    public static string EscapeBold(this string str) => str.Replace("*", "\\*");

    /// <summary>
    /// Formats the specified string as italic using markdown syntax.
    /// </summary>
    /// <param name="str">The input string to format as italic.</param>
    /// <returns>A string formatted as italic using single asterisks (*).</returns>
    public static string ToItalic(this string str) => $"*{str}*";

    /// <summary>
    /// Formats the specified string as italic using markdown syntax.
    /// </summary>
    /// <param name="str">The input string to format as italic.</param>
    /// <returns>A string formatted as italic using single asterisks (*).</returns>
    public static string Italic(this string str) => ToItalic(str);

    /// <summary>
    /// Escapes italic Markdown syntax in the specified string by replacing asterisks (*) with escaped asterisks (\*).
    /// </summary>
    /// <param name="str">The input string from which italic Markdown syntax will be escaped.</param>
    /// <returns>A string with all asterisks replaced by escaped asterisks.</returns>
    public static string EscapeItalic(this string str) => str.Replace("*", "\\*");

    /// <summary>
    /// Formats the specified string with strikethrough using Markdown syntax.
    /// </summary>
    /// <param name="str">The input string to format with strikethrough.</param>
    /// <returns>A string formatted with strikethrough using double tildes (~~).</returns>
    public static string ToStrikethrough(this string str) => $"~~{str}~~";

    /// <summary>
    /// Formats the specified string with strikethrough using Markdown syntax.
    /// </summary>
    /// <param name="str">The input string to format with strikethrough.</param>
    /// <returns>A string formatted with strikethrough using double tildes (~~).</returns>
    public static string Strikethrough(this string str) => ToStrikethrough(str);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToUnderline(this string str) => $"__{str}__";
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string Underline(this string str) => ToUnderline(str);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToUnderscore(this string str) => $"__{str}__";
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string Underscore(this string str) => ToUnderscore(str);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToCodeBlock(this string str) => $@"\`\`\`\n{str}\n\`\`\`";
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string CodeBlock(this string str) => ToCodeBlock(str);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToQuote(this string str) => $"> {str}";
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string Quote(this string str) => ToQuote(str);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToSpoiler(this string str) => $"||{str}||";
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string Spoiler(this string str) => ToSpoiler(str);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToSubtext(this string str) => $"-# {str}";
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string Subtext(this string str) => ToSubtext(str);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <param name="url"></param>
    /// <returns></returns>
    public static string ToHyperlink(this string str, string url) => $"[{str}]({url})";
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <param name="url"></param>
    /// <returns></returns>
    public static string Hyperlink(this string str, string url) => ToHyperlink(str, url);

    /// <summary>
    /// Formats the specified string as a timestamp using Discord Markdown syntax.
    /// </summary>
    /// <param name="str">The input string representing a valid Unix timestamp.</param>
    /// <returns>A string formatted as a timestamp using Discord specific syntax.</returns>
    public static string ToTimestamp(this string str) => $"<t:{str}:R>";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string Timestamp(this string str) => ToTimestamp(str);

    /// <summary>
    /// Converts the string into a Snowflake instance.
    /// </summary>
    /// <param name="str">The string to convert.</param>
    /// <returns>The resulting Snowflake.</returns>
    /// <exception cref="FormatException">Thrown if the string is not a valid ulong.</exception>
    public static Snowflake ToSnowflake(this string str)
    {
        if (string.IsNullOrWhiteSpace(str))
            throw new ArgumentException("Input cannot be null or whitespace.", nameof(str));

        if (!ulong.TryParse(str, out var snowflake))
            throw new ArgumentException("Input is not a valid Snowflake.", nameof(str));

        return new Snowflake(str);
    }
    
    /// <summary>
    /// Attempts to convert the string into a Snowflake.
    /// </summary>
    /// <param name="str">The input string.</param>
    /// <param name="snowflake">The resulting Snowflake if successful; otherwise, default.</param>
    /// <returns>True if conversion succeeded; false otherwise.</returns>
    public static bool TryToSnowflake(this string str, out Snowflake snowflake)
    {
        snowflake = default;
        if (string.IsNullOrWhiteSpace(str))
            return false;
        
        if (!ulong.TryParse(str, out var snowflakeValue)) 
            return false;
        
        snowflake = new Snowflake(snowflakeValue);
        return true;

    }
}