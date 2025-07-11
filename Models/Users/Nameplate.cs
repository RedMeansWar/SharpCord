using SharpCord.Types;

namespace SharpCord.Models;

/// <summary>
/// 
/// </summary>
public class Nameplate
{
    /// <summary>
    /// 
    /// </summary>
    public Snowflake SkuId { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string Asset { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string Label { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string Palette { get; set; }
}