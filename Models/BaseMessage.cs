using SharpCord.Types;

namespace SharpCord.Models;

/// <summary>
/// Represents a base message within a guild or other location in a Discord environment.
/// Provides common properties shared across various channel types.
/// </summary>
public class BaseMessage : Base
{
    /// <summary>
    /// The Message Id.
    /// </summary>
    public Snowflake Id { get; set; }
    
    /// <summary>
    /// The contents of the message.
    /// </summary>
    public string? Content { get; set; }
    
    /// <summary>
    /// Then Channel ID that the message was sent in.
    /// </summary>
    public Snowflake ChannelId { get; set; }
    
    /// <summary>
    /// The Author ID of the person who sent the message.
    /// </summary>
    public Snowflake AuthorId { get; set; }
    
    /// <summary>
    /// The timestamp of the message.
    /// </summary>
    public DateTimeOffset Timestamp { get; set; }
}