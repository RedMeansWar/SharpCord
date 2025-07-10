namespace SharpCord.Errors;

public class InvalidGuildStateException : Exception
{
    public InvalidGuildStateException(string reason) : base($"Invalid guild state: {reason}") { }
}