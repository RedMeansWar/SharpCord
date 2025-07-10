namespace SharpCord.Errors;

public class InvalidTokenException : UnauthorizedAccessException
{
    public InvalidTokenException() : base("Invalid or missing Discord authentication token.") { }
}