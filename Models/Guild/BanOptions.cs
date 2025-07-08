using SharpCord.Interfaces;

namespace SharpCord.Models;

/// <summary>
/// 
/// </summary>
public class BanOptions : IBanOptions
{
    public int DeleteMessagesAfter { get; }
    public string? Reason { get; }

    public BanOptions(int seconds = 0, string? reason = null)
    {
        DeleteMessagesAfter = seconds;
        Reason = reason;
    }
}
