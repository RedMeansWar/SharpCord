using System.Reflection;
using System.Text.Json;
using SharpCord.Attributes;

namespace SharpCord.Registry;

/// <summary>
/// 
/// </summary>
public static class EventRegistry
{
    internal static readonly Dictionary<string, List<MethodInfo>> _handlers = new();

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

    public static async Task DispatchAsync(string eventName, JsonElement payload)
    {
        if (!EventHandlerAttribute.TryParse(eventName, out var evt)) return;
        if (!_handlers.TryGetValue(EventHandlerAttribute.ToDiscordString(evt), out var methods)) return;

        foreach (var method in methods)
        {
            var instance = Activator.CreateInstance(method.DeclaringType!);

            var parameters = method.GetParameters();
            if (parameters.Length == 0)
            {
                method.Invoke(instance, null);
            }
            else if (parameters.Length == 1)
            {
                var paramType = parameters[0].ParameterType;

                if (paramType == typeof(JsonElement))
                {
                    method.Invoke(instance, [payload]);
                }
                else
                {
                    var model = JsonSerializer.Deserialize(payload.GetRawText(), paramType);
                    method.Invoke(instance, [model!]);
                }
            }
        }
    }

}