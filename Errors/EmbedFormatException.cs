namespace SharpCord.Errors;

public class EmbedFormatException : Exception
{
    public EmbedFormatException(string reason) : base($"Invalid embed format: {reason}") { }
}