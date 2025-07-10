using SharpCord.Types;

namespace SharpCord.Models;

/// <summary>
/// 
/// </summary>
public class PermissionOverwrite
{
    /// <summary>
    /// 
    /// </summary>
    public Snowflake Id { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public int Type { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string Allow { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string Deny { get; set; }
}