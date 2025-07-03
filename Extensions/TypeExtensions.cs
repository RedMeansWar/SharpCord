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
/// Provides extension methods for type conversion in the SharpCord library.
/// </summary>
public static class TypeExtensions
{
    /// <summary>
    /// Converts a raw value to the specified target type.
    /// </summary>
    /// <param name="rawValue">The raw value to be converted. Can be null.</param>
    /// <param name="targetType">The target type to which the raw value should be converted.</param>
    /// <returns>An object representing the value converted to the target type, or null if the raw value is null.</returns>
    /// <exception cref="Exception">Thrown when the conversion fails due to an incompatible type or invalid value.</exception>
    public static object? ConvertToExpectedType(object? rawValue, Type targetType)
    {
        if (rawValue is null) return null;

        try
        {
            if (targetType == typeof(Snowflake)) return new Snowflake(Convert.ToUInt64(rawValue));
            if (targetType == typeof(ulong)) return Convert.ToUInt64(rawValue);
            if (targetType == typeof(string)) return rawValue.ToString();

            // fallback: basic type conversions (int, bool, etc)
            return Convert.ChangeType(rawValue, targetType);
        }
        catch
        {
            throw new Exception($"Failed to convert '{rawValue}' to {targetType.Name}");
        }
    }
}