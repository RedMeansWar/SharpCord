namespace SharpCord.Errors
{
    public class VoiceRateLimitException : VoiceException
    {
        public VoiceRateLimitException(string message) : base(message) { }
    }
}