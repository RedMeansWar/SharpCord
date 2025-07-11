using SharpCord.Types;

namespace SharpCord.Models;

/// <summary>
/// 
/// </summary>
public class PrimaryGuild
{
    /// <summary>
    /// 
    /// </summary>
    public Snowflake Id { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public bool? IsEnabled { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string? Tag { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string? Badge { get; set; }
}