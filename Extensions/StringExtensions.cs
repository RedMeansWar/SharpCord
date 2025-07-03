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
}