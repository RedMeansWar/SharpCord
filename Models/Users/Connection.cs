namespace SharpCord.Models;

public class Connection
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public bool? Revoked { get; set; }
    public List<object>? Integrations { get; set; }
    public bool Verified { get; set; }
    public bool FriendSync { get; set; }
    public bool ShowActivity { get; set; }
    public bool TwoWayLink { get; set; }
    public int Visibility { get; set; }
}