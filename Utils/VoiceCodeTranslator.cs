using SharpCord.Errors;

namespace SharpCord.Utils;

/// <summary>
/// 
/// </summary>
public static class VoiceCodeTranslator
{
    public static readonly Dictionary<int, (string message, bool shouldReconnect)> VoiceCloseCodes = new()
    {
        [4001] = ("Unknown opcode — you sent an invalid opcode.", true),
        [4002] = ("Failed to decode payload — invalid payload while identifying.", true),
        [4003] = ("Not authenticated — you sent data before identifying.", true),
        [4004] = ("Authentication failed — your bot token was invalid.", false),
        [4005] = ("Already authenticated — you sent multiple identify payloads.", false),
        [4006] = ("Session no longer valid — start a new session.", true),
        [4009] = ("Session timeout — reconnect and resume.", true),
        [4011] = ("Server not found — the server you're trying to join was not found.", false),
        [4012] = ("Unknown protocol — the protocol sent was not recognized.", false),
        [4014] = ("Disconnected — client was kicked or main session dropped. Do not reconnect.", false),
        [4015] = ("Voice server crashed — our bad! Try reconnecting.", true),
        [4016] = ("Unknown encryption mode — the encryption sent was not supported.", false),
        [4020] = ("Bad request — you sent a malformed voice packet.", false),
        [4021] = ("Disconnected due to rate limit — you've exceeded the rate limit. Do not reconnect.", false),
        [4022] = ("Disconnected: Call Terminated — voice channel deleted or server changed. Do not reconnect.", false)
    };
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static string Translate(int code)
    {
        return VoiceCloseCodes.TryGetValue(code, out var result) 
            ? $"[Voice Close {code}] {result.message} (Reconnecting: {(result.shouldReconnect ? "Yes" : "No")})" 
            : $"[Voice Close {code}] Unknown voice disconnect reason.";
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static bool ShouldReconnect(int code)
    {
        return VoiceCloseCodes.TryGetValue(code, out var result) && result.shouldReconnect;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <exception cref="VoiceDisconnectException"></exception>
    public static void ThrowVoiceDisconnectException(int code)
    {
        if (VoiceCloseCodes.TryGetValue(code, out var result))
            throw new VoiceDisconnectException(code, result.message, result.shouldReconnect);

        throw new VoiceDisconnectException(code, $"Unknown voice disconnect reason (Code: {code})", false);
    }
    
    public static bool TryGetValue(int code, out (string message, bool shouldReconnect) message) => VoiceCloseCodes.TryGetValue(code, out message);
}