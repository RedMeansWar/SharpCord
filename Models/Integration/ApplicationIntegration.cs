using SharpCord.Types;

namespace SharpCord.Models;

public class ApplicationIntegration
{
    public Snowflake Id { get; set; }
    public string Name { get; set; }
    public string? Icon { get; set; }
    public string Description { get; set; }
    public BaseUser? Bot { get; set; }
}