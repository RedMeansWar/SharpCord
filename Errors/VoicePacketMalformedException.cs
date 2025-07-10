namespace SharpCord.Errors;

/// <summary>
/// 
/// </summary>
public class VoicePacketMalformedException : VoiceException
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    public VoicePacketMalformedException(string message) : base(message, code: 4020, shouldReconnect: false) { }
}