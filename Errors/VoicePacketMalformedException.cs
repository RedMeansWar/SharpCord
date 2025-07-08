namespace SharpCord.Errors;

public class VoicePacketMalformedException : VoiceException
{
    public VoicePacketMalformedException(string message) : base(message, code: 4020, shouldReconnect: false) { }
}