namespace SharpCord.Errors;

public class InvalidImageSupportException : Exception
{
    public InvalidImageSupportException() : base("Discord does not support this image format for the type.") { }
}