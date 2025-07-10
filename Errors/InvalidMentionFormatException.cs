namespace SharpCord.Errors;

public class InvalidMentionFormatException : FormatException
{
    public InvalidMentionFormatException(string input) : base($"Invalid mention format: '{input}'") { }
}