using SharpCord.Models;
using SharpCord.Types;

namespace SharpCord.Attributes;

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class CommandAttribute : Attribute
{
    /// <summary>
    /// Gets or sets the name of the command.
    /// </summary>
    /// <remarks>
    /// The name is a required property and uniquely identifies the command.
    /// It is recommended to use a descriptive and concise name that reflects the command's purpose.
    /// </remarks>
    public string Name { get; }

    /// <summary>
    /// Gets or sets the description of the command.
    /// </summary>
    /// <remarks>
    /// The description provides additional information about the purpose or functionality of the command.
    /// It is recommended to use a clear and concise description to ensure users understand its behavior.
    /// </remarks>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the default permissions required for members to execute the command.
    /// </summary>
    /// <remarks>
    /// This property specifies the permissions that members must have by default to use the command.
    /// If set to null, the command will have no specific permission requirements by default.
    /// This property can be used to restrict command usage to certain roles or members with the necessary permissions.
    /// </remarks>
    public string? DefaultMemberPermissions { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the command is usable in Direct Messages (DMs).
    /// </summary>
    /// <remarks>
    /// This property determines the availability of the command in private conversations outside of a guild context.
    /// Set to <c>true</c> to enable the command in DMs; otherwise, set to <c>false</c> to restrict it to guild usage only.
    /// If this property is <c>null</c>, the behavior will follow the platform's default setting.
    /// </remarks>
    public bool? DMPermission { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the command is marked as Not Safe For Work (NSFW).
    /// </summary>
    /// <remarks>
    /// Commands marked as NSFW can only be used in designated channels or contexts
    /// where NSFW content is permitted, ensuring compliance with application rules
    /// and user safety guidelines.
    /// </remarks>
    public bool? Nsfw { get; set; }

    /// <summary>
    /// Gets or sets the type of the application command.
    /// </summary>
    /// <remarks>
    /// Specifies the category of the application command, such as ChatInput, User, Message, or PrimaryEntryPoint.
    /// This property determines how the command is interpreted and presented in the application.
    /// The default value is ChatInput.
    /// </remarks>
    public ApplicationCommandType Type { get; set; } = ApplicationCommandType.ChatInput;

    /// <summary>
    /// Gets or sets the unique identifier of the guild where the command is applicable.
    /// </summary>
    /// <remarks>
    /// This property is optional and is used to specify the guild in which the command should be scoped.
    /// If not provided, the command might be treated as global and available across all eligible guilds.
    /// Providing a specific GuildId ensures that the command is restricted locally to that guild.
    /// </remarks>
    public string? GuildIdRaw { get; set; } // the raw version of this because attributes don't support "Snowflake"
    
    /// <summary>
    /// 
    /// </summary>
    public Snowflake? GuildId => GuildIdRaw is not null ? new Snowflake(GuildIdRaw) : null;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name">The command name (e.g., "ping").</param>
    /// <param name="description">The command description shown in Discord's UI.</param>
    /// <param name="guildId">
    /// (Optional) The guild ID this command is restricted to.
    /// Must be passed as a string due to C#'s attribute limitations,
    /// but internally it will be converted to a Snowflake for safety.
    /// </param>
    /// <remarks>
    /// This attribute is used to annotate methods and provides metadata such as the command's
    /// name, description, permissions, context, and other optional details. It facilitates the
    /// definition and management of commands in the application.
    /// </remarks>
    /// <code>
    /// [Command("ping")]
    /// private async Task PingCommand(Interaction interaction)
    /// {
    ///     await interaction.ReplyAsync("Pong!");
    /// }
    /// </code>
    public CommandAttribute(string name, string description = "", string? guildId = null)
    {
        Name = name;
        Description = description;
        GuildIdRaw = guildId;
    }
}