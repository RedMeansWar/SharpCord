using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using SharpCord.Attributes;
using SharpCord.Models;
using SharpCord.Utils;
using SharpCord.Payloads;

namespace SharpCord.Registry;

/// <summary>
/// Provides a registry for managing and storing commands and slash commands recognized by the application.
/// </summary>
public static class CommandRegistry
{
    /// <summary>
    /// Maintains a collection of instances of command-handling classes, mapped by their respective names.
    /// </summary>
    /// <remarks>
    /// This dictionary stores objects representing command handler instances, where the keys are command names
    /// and the values are the associated object instances. These instances correspond to classes that define
    /// methods decorated with the <see cref="SharpCord.Attributes.CommandAttribute"/> attribute.
    /// It allows commands to be executed in the context of their respective class instances.
    /// </remarks>
    public static Dictionary<string, object> CommandInstances { get; private set; } = new();

    /// <summary>
    /// Stores the registered slash commands within the application mapped by their respective names.
    /// </summary>
    /// <remarks>
    /// This dictionary maps slash command names (as keys) to their corresponding method information (as values).
    /// It provides a centralized registry for handling slash commands. These commands are registered
    /// via the <see cref="RegisterCommandsFrom{T}"/> method, scanning for methods decorated with the
    /// <see cref="SharpCord.Attributes.CommandAttribute"/> attribute and adding them to this collection.
    /// </remarks>
    public static Dictionary<string, MethodInfo> SlashCommands { get; private set; } = new();
    
    /// <summary>
    /// Stores the registered prefix-based commands within the application mapped by their respective names.
    /// </summary>
    /// <remarks>
    /// This dictionary maps prefix-based command names (as keys) to their associated method information (as values).
    /// It is used to manage and execute commands that are triggered by specific prefixes in text-based input.
    /// Commands are intended to be registered via a method that scans for methods annotated with the
    /// <see cref="SharpCord.Attributes.CommandAttribute"/> attribute, adding them to this collection.
    /// </remarks>
    public static Dictionary<string, MethodInfo> PrefixCommands { get; private set; } = new();

    /// <summary>
    /// Registers all slash commands defined in the application by sending payloads to the Discord API.
    /// </summary>
    /// <remarks>
    /// This method iterates through all commands stored in <see cref="SharpCord.Commands.CommandRegistry.SlashCommands"/>.
    /// For each command, it retrieves metadata from the associated <see cref="SharpCord.Attributes.CommandAttribute"/> and
    /// constructs a corresponding payload. The payload is then serialized into JSON format and posted to the appropriate
    /// Discord API endpoint, differentiating between guild-specific and global commands based on the presence of a GuildId.
    /// Successful registrations are logged, while any failures, including API responses, are captured and logged as errors.
    /// </remarks>
    /// <returns>
    /// A task that represents the asynchronous operation of registering slash commands with the Discord API.
    /// </returns>
    public static async Task RegisterAllSlashCommandsAsync()
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bot", DiscordClient.Token);

        foreach (var command in SlashCommands)
        {
            var method = command.Value;
            var attr = method.GetCustomAttribute<CommandAttribute>();
            if (attr is null) continue;

            var payload = new CommandPayload
            {
                Name = attr.Name.ToLower(),
                Description = string.IsNullOrWhiteSpace(attr.Description) ? "No description provided" : attr.Description,
                Type = attr.Type,
                DefaultMemberPermissions = attr.DefaultMemberPermissions,
                DMPermission = attr.DMPermission,
                NSFW = attr.NSFW
            };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var applicationId = DiscordClient.GetApplicationIdFromToken();

            var url = attr.GuildId is not null
                ? $"https://discord.com/api/v10/applications/{applicationId}/guilds/{attr.GuildId}/commands"
                : $"https://discord.com/api/v10/applications/{applicationId}/commands";

            var response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                Log.Info($"✅ Registered command: {payload.Name}");
            }
            else
            {
                var body = await response.Content.ReadAsStringAsync();
                Log.Error($"❌ Failed to register '{payload.Name}': {response.StatusCode}\n{body}");
            }
        }
    }

    /// <summary>
    /// Registers commands defined in the specified type, identifying methods marked with
    /// <see cref="SharpCord.Attributes.CommandAttribute"/> and <see cref="SharpCord.Attributes.PrefixCommandAttribute"/>.
    /// </summary>
    /// <typeparam name="T">The type containing the methods to be scanned for command attributes.</typeparam>
    /// <remarks>
    /// This method scans the specified type for public instance methods decorated with
    /// either <see cref="SharpCord.Attributes.CommandAttribute"/> or
    /// <see cref="SharpCord.Attributes.PrefixCommandAttribute"/> attributes. Slash commands are registered with their
    /// corresponding attributes in <see cref="SharpCord.Commands.CommandRegistry.SlashCommands"/>, while prefix-based
    /// commands are stored in <see cref="SharpCord.Commands.CommandRegistry.PrefixCommands"/>. Additionally, instances of the
    /// containing class are stored for later invocation.
    /// </remarks>
    public static void RegisterCommandsFrom<T>()
    {
        var type = typeof(T);
        var instance = Activator.CreateInstance(type)!;

        foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
        {
            var slashAttr = method.GetCustomAttribute<CommandAttribute>();
            if (slashAttr is not null)
            {
                var name = slashAttr.Name.ToLower();
                SlashCommands[name] = method;
                CommandInstances[name] = instance;
                Log.Info($"Registered slash command: {name}");
                continue;
            }
            
            var prefixAttr = method.GetCustomAttribute<PrefixCommandAttribute>();
            if (prefixAttr is not null)
            {
                var name = prefixAttr.Name.ToLower();
                PrefixCommands[name] = method;
                CommandInstances[name] = instance;
            }
        } 
    }
}