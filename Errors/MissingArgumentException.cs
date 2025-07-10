namespace SharpCord.Errors;

public class MissingArgumentException : Exception
{
    public string ArgumentName { get; }
    
    public MissingArgumentException(string argumentName) : base($"Missing argument: {argumentName}") => ArgumentName = argumentName; 
}