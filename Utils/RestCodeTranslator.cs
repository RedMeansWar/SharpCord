namespace SharpCord.Utils
{
    public static class RestCodeTranslator
    {
        public static Dictionary<int, string> RestCodes = new()
        {
            [0] = "Unknown error — no further information.",
            [10003] = "Unknown channel — the channel ID is invalid.",
            [10004] = "Unknown guild — the guild ID is invalid.",
            [10013] = "Unknown user — the user ID is invalid.",
            [30007] = "Maximum number of pins reached in this channel.",
            [50013] = "Missing permissions to perform this action.",
            [50035] = "Invalid form body — one or more fields are wrong."
        };
        
        public static string Translate(int code)
            => RestCodes.TryGetValue(code, out var message)
                ? $"[REST Code {code}] {message}"
                : $"[REST Code {code}] Unknown REST error code.";
        
        public static bool TryGetValue(int code, out string message) => RestCodes.TryGetValue(code, out message);
    }
}