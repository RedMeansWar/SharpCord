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
using SharpCord.Attributes;
using SharpCord.Utils;

namespace SharpCord.Registry;

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
                    case AssignRoleAttribute assignRoleAttr:
                    case IfUserHasPermissionAttribute userHasPermissionAttr: RegisteredActions.Add(method); break;
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