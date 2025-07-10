namespace SharpCord.Errors;

public class InteractionException : Exception
{
    public InteractionException(string message) : base($"Interaction failed: {message}") { }
}