namespace SharpCord.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IBanOptions
{
    /// <summary>
    /// 
    /// </summary>
    int DeleteMessagesAfter { get; }
    
    /// <summary>
    /// 
    /// </summary>
    string? Reason { get; }
}