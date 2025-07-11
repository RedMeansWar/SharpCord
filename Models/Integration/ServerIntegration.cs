using SharpCord.Types;

namespace SharpCord.Models;

public class ServerIntegration
{
    public Snowflake Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public bool Enabled { get; set; }
    public bool? Syncing { get; set; }
    public Snowflake? RoleId { get; set; }
    public bool? EnableEmoticons { get; set; }
    public bool? ExpireBehavior { get; set; }
}