using System.Reflection;
using SharpCord.Attributes;
using SharpCord.Utils;

namespace SharpCord.Registry;

/// <summary>
/// 
/// </summary>
public static class AttributeRegistry
{
    internal static List<MethodInfo> RegisteredActions { get; } = new();

    /// <summary>
    /// Registers all methods from the specified type that are decorated with supported attributes.
    /// Supported attributes can include actions such as creating or deleting a channel and assigning roles.
    /// The registered methods are added to an internal list for execution at a later time.
    /// </summary>
    /// <typeparam name="T">The type containing methods with action-related attributes to be registered.</typeparam>
    public static void RegisterActionsFrom<T>()
    {
        var type = typeof(T);
        foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        {
            var attributes = method.GetCustomAttributes(false);
            foreach (var attribute in attributes)
            {
                switch (attribute)
                {
                    case ModalAttribute modalAttr:
                    case CreateChannelAttribute createChannelAttr:
                    case DeleteChannelAttribute deleteChannelAttr:
                    case AssignRoleAttribute assignRoleAttr: RegisteredActions.Add(method); break;
                    default: Log.Warning($"Unknown attribute type: {attribute.GetType().Name}"); break;
                }
            }
        }
    }

    /// <summary>
    /// Executes all registered actions that have been marked with specific attributes and added to the registry.
    /// </summary>
    /// <returns>A task representing the asynchronous operation of executing the registered actions.</returns>
    public static async Task ExecuteActionAsync()
    {
        foreach (var action in RegisteredActions)
        {
            var instance = Activator.CreateInstance(action.DeclaringType);
            var parameters = action.GetParameters();
            var result = action.Invoke(instance, null);
        }
    }
}