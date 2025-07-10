namespace SharpCord.Errors;

public class ChannelTypeMismatchException : InvalidOperationException
{
    public ChannelTypeMismatchException(string expected, string actual) : base($"Invalid channel type. Expected: {expected}, but got: {actual}.") { }
}