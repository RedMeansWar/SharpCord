using System.Text.Json.Serialization;
using SharpCord.Models;

namespace SharpCord.Payloads;

/// <summary>
/// Represents the structure of a command payload that can be registered with Discord's API.
/// </summary>
public class CommandPayload
{
    /// <summary>
    /// Gets or sets the name of the application command.
    /// </summary>
    /// <remarks>
    /// This property represents the unique identifier for a command, used to invoke it within the Discord client.
    /// Command names should be user-friendly, concise, and adhere to Discord's command naming conventions.
    /// </remarks>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the application command.
    /// </summary>
    /// <remarks>
    /// This property provides a succinct explanation of the command's purpose or functionality.
    /// It serves as a user-facing description, appearing in the Discord client to inform users
    /// about the specifics of what the command does.
    /// </remarks>
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the type of the application command.
    /// </summary>
    /// <remarks>
    /// This property defines the type of the command, specifying its purpose and context.
    /// The value is one of the predefined options in the <see cref="ApplicationCommandType"/> enumeration, such as
    /// ChatInput, User, Message, or PrimaryEntryPoint. The type determines how the command is expected
    /// to behave and where it can be invoked.
    /// </remarks>
    [JsonPropertyName("type")]
    public ApplicationCommandType Type { get; set; } = ApplicationCommandType.ChatInput;

    /// <summary>
    /// Gets or sets the default permissions required for members to execute the command.
    /// </summary>
    /// <remarks>
    /// This property represents the permissions mask that determines which roles or members
    /// are allowed to invoke the command by default. The permissions are specified as a string,
    /// which corresponds to Discord's permission bitfield. If set to <c>null</c>, all guild
    /// members can invoke the command unless explicitly restricted.
    /// </remarks>
    [JsonPropertyName("default_member_permissions")]
    public string? DefaultMemberPermissions { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the command is permitted to be used in direct messages (DMs).
    /// </summary>
    /// <remarks>
    /// This property controls whether the command is allowed to be invoked directly within a user's DMs.
    /// If set to <c>false</c>, the command can only be used in guild channels.
    /// </remarks>
    [JsonPropertyName("dm_permission")]
    public bool? DMPermission { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the command is marked as Not Safe For Work (NSFW).
    /// </summary>
    /// <remarks>
    /// Commands marked as NSFW are restricted to channels designated as NSFW within Discord.
    /// </remarks>
    [JsonPropertyName("nsfw")]
    public bool? NSFW { get; set; }

    /// <summary>
    /// Gets or sets the list of options for the command.
    /// </summary>
    /// <remarks>
    /// Each option is represented by an instance of <see cref="ApplicationCommandOption"/>.
    /// These options define additional parameters that can be used within the command.
    /// </remarks>
    [JsonPropertyName("options")]
    public List<ApplicationCommandOption> Options { get; set; }
}