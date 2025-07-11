using SharpCord.Types;

namespace SharpCord.Models;

public class AvatarDecorationData
{
    public Snowflake SkuId { get; set; }
    public string Asset { get; set; } // decoration hash
}