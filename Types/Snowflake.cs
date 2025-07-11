using System.Text.Json;
using System.Text.Json.Serialization;

namespace SharpCord.Types;

/// <summary>
/// Represents a Snowflake identifier used for unique identification.
/// </summary>
/// <remarks>
/// A Snowflake encapsulates a 64-bit unsigned integer and encodes information such as timestamp and worker ID.
/// Implements interfaces for querying and comparison logic.
/// </remarks>
[JsonConverter((typeof(SnowflakeConverter)))]
public readonly struct Snowflake : IEquatable<Snowflake>, IComparable<Snowflake>
{
    /// <summary>
    /// Gets or sets the underlying 64-bit unsigned integer value of the Snowflake identifier.
    /// </summary>
    /// <remarks>
    /// This property represents the raw Snowflake value, which is a unique identifier commonly used
    /// in Discord. The value can provide timestamp and other embedded data when decoded.
    /// </remarks>
    public ulong Value { get; }

    /// <summary>
    /// Represents a Snowflake identifier, often used in unique identification in Discord.
    /// </summary>
    /// <remarks>
    /// A Snowflake is a 64-bit identifier that includes information such as timestamp and worker ID.
    /// Provides implicit conversions, comparison logic, and timestamp extraction from the identifier.
    /// </remarks>
    public Snowflake(ulong value) => Value = value;

    /// <summary>
    /// Represents a unique identifier based on the Snowflake format.
    /// </summary>
    /// <remarks>
    /// A Snowflake is a 64-bit integer that encodes metadata such as timestamp and worker ID.
    /// This implementation allows operations such as comparison and string conversion.
    /// </remarks>
    public Snowflake(string value) => Value = ulong.Parse(value);

    /// <summary>
    /// Defines an implicit conversion operator from a Snowflake to a 64-bit unsigned integer.
    /// </summary>
    /// <param name="s">The Snowflake instance to be converted.</param>
    /// <returns>The 64-bit unsigned integer value contained within the Snowflake.</returns>
    public static implicit operator ulong(Snowflake s) => s.Value;

    /// <summary>
    /// Defines an implicit conversion operator to create a Snowflake from a 64-bit unsigned integer.
    /// </summary>
    /// <remarks>
    /// This operator allows seamless conversion of a 64-bit unsigned integer (ulong) into a Snowflake identifier.
    /// It is useful for simplifying the creation of new Snowflake instances when only the raw identifier is available.
    /// </remarks>
    /// <param name="value">The 64-bit unsigned integer value to be converted.</param>
    /// <returns>An instance of the Snowflake struct that represents the specified value.</returns>
    public static implicit operator Snowflake(ulong value) => new(value);

    /// <summary>
    /// Defines an implicit conversion operator from a string to a Snowflake.
    /// </summary>
    /// <param name="value">The string representation of the Snowflake to be converted.</param>
    /// <returns>A Snowflake instance initialized from the provided string value.</returns>
    public static implicit operator Snowflake(string value) => new(value);

    /// <summary>
    /// Gets the creation timestamp of the Snowflake.
    /// </summary>
    /// <remarks>
    /// The <c>CreatedAt</c> property derives the creation time of the Snowflake identifier
    /// by decoding the timestamp embedded within its value. The timestamp is calculated using
    /// Discord's epoch (January 1, 2015, at 00:00:00 UTC) and the high-order bits of the Snowflake.
    /// </remarks>
    public DateTimeOffset CreatedAt
    {
        get
        {
            const long discordEpoch = 1420070400000;
            var timestamp = (long)(Value >> 22) + discordEpoch;
            return DateTimeOffset.FromUnixTimeMilliseconds(timestamp);
        }
    }

    /// <summary>
    /// Returns the string representation of the Snowflake value.
    /// </summary>
    /// <returns>
    /// A string that represents the underlying 64-bit unsigned integer value of the Snowflake.
    /// </returns>
    public override string ToString() => Value.ToString();

    /// <summary>
    /// Determines whether the specified Snowflake instance is equal to the current Snowflake instance.
    /// </summary>
    /// <param name="other">The Snowflake instance to compare with the current instance.</param>
    /// <returns>True if the specified Snowflake instance is equal to the current instance; otherwise, false.</returns>
    public bool Equals(Snowflake other) => Value == other.Value;

    /// <summary>
    /// Compares the current Snowflake instance with another Snowflake to determine their relative ordering.
    /// </summary>
    /// <param name="other">The Snowflake instance to compare with the current instance.</param>
    /// <returns>
    /// A signed integer indicating the relative order of the Snowflake instances:
    /// Zero if the instances are equal,
    /// a negative number if the current instance is less than the other instance,
    /// and a positive number if the current instance is greater than the other instance.
    /// </returns>
    public int CompareTo(Snowflake other) => Value.CompareTo(other.Value);

    /// <summary>
    /// Returns a hash code for this instance of a Snowflake.
    /// </summary>
    /// <returns>
    /// A 32-bit signed integer hash code that uniquely identifies the Snowflake.
    /// The hash code is derived from the Snowflake's underlying 64-bit unsigned integer value.
    /// </returns>
    public override int GetHashCode() => Value.GetHashCode();
}

/// <summary>
/// Provides functionality to convert Snowflake objects to and from JSON representation.
/// </summary>
/// <remarks>
/// Used to serialize and deserialize <see cref="Snowflake"/> identifiers when working with JSON data.
/// Enables flexible handling of Snowflake values represented as numbers or strings.
/// </remarks>
public class SnowflakeConverter : JsonConverter<Snowflake>
{
    /// <summary>
    /// Reads and converts the JSON representation of a Snowflake identifier.
    /// </summary>
    /// <param name="reader">The <see cref="Utf8JsonReader"/> used to read the JSON data.</param>
    /// <param name="typeToConvert">The type of the object to convert to, which is <see cref="Snowflake"/>.</param>
    /// <param name="options">An object containing options for the deserialization process.</param>
    /// <returns>Returns the deserialized <see cref="Snowflake"/> value from the JSON data.</returns>
    /// <exception cref="JsonException">Thrown when the JSON value cannot be converted to a valid <see cref="Snowflake"/>.</exception>
    public override Snowflake Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String && ulong.TryParse(reader.GetString(), out var value) ||
            reader.TokenType == JsonTokenType.Number && reader.TryGetUInt64(out value))
            return new Snowflake(value);

        throw new JsonException("Invalid snowflake format");
    }

    /// <summary>
    /// Writes a <see cref="Snowflake"/> object to its JSON string representation.
    /// </summary>
    /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write the JSON data to.</param>
    /// <param name="value">The <see cref="Snowflake"/> object to be serialized.</param>
    /// <param name="options">The <see cref="JsonSerializerOptions"/> to configure the serialization process.</param>
    public override void Write(Utf8JsonWriter writer, Snowflake value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.Value.ToString());
}