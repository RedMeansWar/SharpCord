#region LICENSE
// Copyright (c) 2025 RedMeansWar
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System.Reflection;
using System.Text.Json;
using SharpCord.Attributes;
using SharpCord.Models;
using SharpCord.Utils;
using SharpCord.Interactions;

namespace SharpCord.Registry;

/// <summary>
/// Provides a registry for managing and dispatching events within the application.
/// Allows methods marked with <see cref="EventHandlerAttribute"/> to be registered as
/// event handlers, and facilitates the asynchronous dispatching of events to these handlers.
/// </summary>
public static class EventRegistry
{
    internal static readonly Dictionary<string, List<MethodInfo>> Handlers = new();
    private static readonly Dictionary<string, object> EventInstances = new();
    
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
        var instance = Activator.CreateInstance(type)!;

        foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        {
            var attr = method.GetCustomAttribute<EventHandlerAttribute>();
            if (attr == null) continue;

            var eventName = attr.EventName;
            if (!Handlers.ContainsKey(eventName))
                Handlers[eventName] = new List<MethodInfo>();

            Handlers[eventName].Add(method);
            EventInstances[eventName] = instance;
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
            var interaction = JsonSerializer.Deserialize<Interaction>(payload.GetRawText());
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
        
        if (!Handlers.TryGetValue(eventName, out var methods))
            return;

        foreach (var method in methods)
        {
            var instance = EventInstances[eventName];
            var parameters = method.GetParameters();

            if (parameters.Length == 0)
            {
                var result = method.Invoke(instance, null);
                if (result is Task task)
                    await task;
            }
            else
            {
                // If method expects payload, e.g., JsonElement or specific object
                object? arg = payload;

                if (parameters[0].ParameterType == typeof(JsonElement))
                {
                    arg = payload;
                }
                else
                {
                    try
                    {
                        arg = JsonSerializer.Deserialize(payload.GetRawText(), parameters[0].ParameterType);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to deserialize event payload for {eventName}: {ex.Message}");
                        continue;
                    }
                }

                var result = method.Invoke(instance, [arg]);
                if (result is Task task)
                    await task;
            }
        }
    }

}