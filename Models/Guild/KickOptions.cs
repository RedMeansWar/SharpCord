namespace SharpCord.Models;

/// <summary>
/// 
/// </summary>
public class KickOptions
{
    /// <summary>
    /// 
    /// </summary>
    public string? Reason { get; }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="reason"></param>
    public KickOptions(string? reason = null) => Reason = reason;
}