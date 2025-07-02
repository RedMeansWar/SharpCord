using System.Reflection;
using System.Text.Json;
using SharpCord.Attributes;
using SharpCord.Models;
using SharpCord.Utils;

namespace SharpCord.Registry;

/// <summary>
/// Provides a registry for managing and dispatching events within the application.
/// Allows methods marked with <see cref="EventHandlerAttribute"/> to be registered as
/// event handlers, and facilitates the asynchronous dispatching of events to these handlers.
/// </summary>
public static class EventRegistry
{
    internal static readonly Dictionary<string, List<MethodInfo>> _handlers = new();

    /// <summary>
    /// Registers all methods within the specified type as event handlers
    /// if they are decorated with the <see cref="EventHandlerAttribute"/>.
    /// The registered methods are stored internally and associated with their
    /// respective event names as determined by the attribute.
    /// </summary>
    /// <typeparam name="T">
    /// The type containing methods to be registered as event handlers.
    /// Methods must be marked with <see cref="EventHandlerAttribute"/> to be registered.
    /// </typeparam>
    public static void RegisterEventsFrom<T>()
    {
        var type = typeof(T);

        foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        {
            var attr = method.GetCustomAttribute<EventHandlerAttribute>();
            if (attr is null) continue;
            
            if (!_handlers.TryGetValue(attr.EventName, out var list))
                _handlers[attr.EventName] = list = [];
            
            list.Add(method);
        }
    }

    /// <summary>
    /// Dispatches an event to all registered handlers that correspond to the specified event name.
    /// The provided payload is passed to the event handlers as a parameter, and the invocation
    /// is performed asynchronously.
    /// </summary>
    /// <param name="eventName">
    /// The name of the event to dispatch. This will determine which handlers will be invoked.
    /// </param>
    /// <param name="payload">
    /// The payload associated with the event. This data is passed to the handlers and can be
    /// deserialized based on the expected parameter type of the handler method.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous dispatch operation.
    /// </returns>
    public static async Task DispatchAsync(string eventName, JsonElement payload)
    {
        if (!EventHandlerAttribute.TryParse(eventName, out var evt)) return;

        if (evt == DiscordEvents.InteractionCreate)
        {
            var interaction = JsonSerializer.Deserialize<Interaction.Interaction>(payload.GetRawText());
            if (interaction?.Data?.Name is not null && interaction.Type == BaseInteractionType.ApplicationCommand)
            {
                var commandName = interaction.Data.Name.ToLower();
                if (CommandRegistry.SlashCommands.TryGetValue(commandName, out var method) &&
                    CommandRegistry.CommandInstances.TryGetValue(commandName, out var instance))
                {
                    try
                    {
                        Log.Warning($"Executing slash command: /{commandName}");
                        method.Invoke(instance, [interaction]);
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"Failed to execute slash command: /{commandName}\n{ex}");
                    }
                }
                else
                {
                    Log.Warning($"Slash command /{commandName} not found in registry.");
                }

                return;
            }
        }
        
        if (!_handlers.TryGetValue(EventHandlerAttribute.ToDiscordString(evt), out var methods)) return;

        foreach (var method in methods)
        {
            var instance = Activator.CreateInstance(method.DeclaringType!);
            
            var parameters = method.GetParameters();
            switch (parameters.Length)
            {
                case 0: method.Invoke(instance, null); break;
                case 1:
                {
                    var paramType = parameters[0].ParameterType;
                    if (paramType == typeof(JsonElement))
                    {
                        method.Invoke(instance, [payload]);
                    }
                    else
                    {
                        var model = JsonSerializer.Deserialize(payload.GetRawText(), paramType);
                        method.Invoke(instance, [model]);
                    }
                } 
                break;
            }
        }
    }

}