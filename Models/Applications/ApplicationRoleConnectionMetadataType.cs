namespace SharpCord.Models;

/// <summary>
/// Specifies types of metadata comparisons that can be used within an application role connection.
/// <remarks>
/// This enumeration defines various options to assess compatibility between metadata values and predefined conditions.
/// </remarks>
/// </summary>
public enum ApplicationRoleConnectionMetadataType
{
    /// <summary>
    /// Represents an integration type where the comparison checks if a boolean value is equal to another boolean value.
    /// <remarks>
    /// The metadata value (boolean) must match the guild's configured value (boolean).
    /// </remarks>
    /// </summary>
    BooleanEqual = 7,

    /// <summary>
    /// Represents an integration type where the comparison checks if a boolean value is not equal to another boolean value.
    /// <remarks>
    /// The metadata value (boolean) must differ from the guild's configured value (boolean).
    /// </remarks>
    /// </summary>
    BooleanNotEqual = 8,

    /// <summary>
    /// Represents an integration type where the comparison checks if a datetime value is greater than or equal to another datetime value.
    /// <remarks>
    /// The metadata value (datetime) must be greater than or exactly equal to the guild's configured value (datetime).
    /// </remarks>
    /// </summary>
    DatetimeGreaterThanOrEqual = 6,

    /// <summary>
    /// Represents an integration type where the comparison checks if a datetime value is less than or equal to another datetime value.
    /// <remarks>
    /// The metadata value (datetime) must be less than or exactly equal to the guild's configured value (datetime).
    /// </remarks>
    /// </summary>
    DatetimeLessThanOrEqual = 5,

    /// <summary>
    /// Represents an integration type where the comparison checks if an integer value is equal to another integer value.
    /// <remarks>
    /// The metadata value (integer) must be exactly equal to the guild's configured value (integer).
    /// </remarks>
    /// </summary>
    IntegerEqual = 3,

    /// <summary>
    /// Represents an integration type where the comparison checks if an integer value is greater than or equal to another integer value.
    /// <remarks>
    /// The metadata value (integer) is greater than or equal to the guild's configured value (integer).
    /// </remarks>
    /// </summary>
    IntegerGreaterThanOrEqual = 2,

    /// <summary>
    /// Represents an integration type where the comparison checks if an integer value is less than or equal to another integer value.
    /// <remarks>
    /// The metadata value (integer) is less than or equal to the guild's configured value (integer).
    /// </remarks>
    /// </summary>
    IntegerLessThanOrEqual = 1,

    /// <summary>
    /// Represents an integration type where the comparison checks if two integer values are not equal.
    /// <remarks>
    /// The metadata value (integer) is not equal to the guild's configured value (integer)
    /// </remarks>
    /// </summary>
    IntegerNotEqual = 4,
}