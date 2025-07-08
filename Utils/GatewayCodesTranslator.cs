namespace SharpCord.Utils;

/// <summary>
/// 
/// </summary>
public static class GatewayCodesTranslator
{
    private static readonly Dictionary<int, string> GatewayCloseCodes = new()
    {
        [4000] = "Unknown error — try reconnecting?",
        [4001] = "Unknown opcode — invalid payload sent.",
        [4002] = "Decode error — check payload encoding.",
        [4003] = "Not authenticated — you didn't identify properly.",
        [4004] = "Authentication failed — invalid token.",
        [4005] = "Already authenticated — you can't identify twice.",
        [4007] = "Invalid sequence — your sequence number is wrong.",
        [4008] = "Rate limited — you're sending too fast.",
        [4009] = "Session timeout — re-identify again.",
        [4010] = "Invalid shard — your shard ID is wrong.",
        [4011] = "Sharding required — large bot needs sharding.",
        [4012] = "Invalid API version.",
        [4013] = "Invalid intent — not enabled in dev portal.",
        [4014] = "Disallowed intent — you’re not allowed to use this intent.",
        [4015] = "Voice server crashed or unavailable.",
        [4016] = "Voice channel disconnection.",
        [4017] = "Voice server not found.",
        [4018] = "Voice protocol unsupported.",
        [4019] = "Connection replaced by another session.",
        [4020] = "Voice token expired — rejoin required.",
        [4021] = "Voice session timeout — reconnect required."
    };

    public static string Translate(int code)
        => GatewayCloseCodes.TryGetValue(code, out var message)
            ? $"[Gateway Code {code}] {message}"
            : $"[Gateway Code {code}] Unknown gateway error code.";
    
    public static bool TryGetValue(int code, out string message) => GatewayCloseCodes.TryGetValue(code, out message);
}