namespace SharpCord.Errors;

/// <summary>
/// 
/// </summary>
public class VoiceDisconnectException : VoiceException
{
    public VoiceDisconnectException(int code, string message, bool shouldReconnect) : base(message, code, shouldReconnect) { }
}