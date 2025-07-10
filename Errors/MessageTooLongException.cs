namespace SharpCord.Errors;

public class MessageTooLongException : Exception
{
    public int ActualLength { get; }
    
    public MessageTooLongException(int length) : base($"Message content exceeds the 2000 character limit. Length: {length}") => ActualLength = length;
}