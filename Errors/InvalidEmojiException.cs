namespace SharpCord.Errors;

public class InvalidEmojiException : FormatException
{
    public InvalidEmojiException(string emoji) : base($"Invalid emoji format: '{emoji}'") { }
}