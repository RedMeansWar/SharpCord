namespace SharpCord.Errors;

public class ThreadOperationException : Exception
{
    public ThreadOperationException(string operation, string reason) : base($"Thread operation '{operation}' failed: {reason}") { }
}