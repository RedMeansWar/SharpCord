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