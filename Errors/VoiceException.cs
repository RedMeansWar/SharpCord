namespace SharpCord.Errors
{
    public class VoiceException : Exception
    {
        public int? Code { get; }
        public bool ShouldReconnect { get; }

        public VoiceException(string message, int? code = null, bool shouldReconnect = false) : base(message)
        {
            Code = code;
            ShouldReconnect = shouldReconnect;
        }

        public override string ToString() => $"[{GetType().Name}] Code: {Code}, Message: {Message}, Reconnect: {ShouldReconnect}";
    }
}