namespace SharpCord.Errors;

public class InvalidSnowflakeException : FormatException
{
    public InvalidSnowflakeException(string input) : base($"The input '{input}' is not a valid Discord snowflake.") { }
}