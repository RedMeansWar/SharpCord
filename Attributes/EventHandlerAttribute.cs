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

using SharpCord.Models;

namespace SharpCord.Attributes;

/// <summary>
/// Attribute used to designate a method as a handler for a specific Discord event.
/// </summary>
/// <remarks>
/// The EventAttribute class provides a way to associate a method with a named Discord event or a predefined DiscordEvent enumeration value.
/// This is primarily used in event dispatch systems to map incoming event names to corresponding handler methods.
/// </remarks>
[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class EventHandlerAttribute : Attribute
{
    /// <summary>
    /// Gets the name of the Discord event associated with the method.
    /// </summary>
    /// <remarks>
    /// The property represents either a custom string-defined event name or a value that corresponds to the stringified name of a <see cref="DiscordEvent"/>
    /// enumeration item. It is used during runtime to map event names to methods decorated with the <c>EventAttribute</c>.
    /// </remarks>
    public string EventName { get; }

    /// <summary>
    /// Attribute used to indicate that a method is a handler for a specific Discord event.
    /// </summary>
    /// <remarks>
    /// This attribute allows mapping of a method to an event name or a predefined enumeration value representing Discord events.
    /// It is applied on methods and assists in identifying which method handles a specific event in Discord applications.
    /// </remarks>
    public EventHandlerAttribute(string eventName) => EventName = eventName;

    /// <summary>
    /// Attribute used to indicate that a method is designated to handle a specific Discord event.
    /// </summary>
    /// <remarks>
    /// This attribute can associate a method with either a custom event name or a predefined value from the DiscordEvent enumeration.
    /// It supports event-driven systems by mapping incoming Discord event data to their respective method handlers.
    /// </remarks>
    public EventHandlerAttribute(DiscordEvents evt) => EventName = ToDiscordString(evt);
    
    internal static string ToDiscordString(DiscordEvents evt)
    {
        return string.Concat(evt.ToString()
                .Select((ch, i) => char.IsUpper(ch) && i > 0 ? "_" + ch : ch.ToString()))
                .ToUpper();
    }

    internal static bool TryParse(string raw, out DiscordEvents evt)
    {
        var name = string.Concat(raw.Split('_') .Select(w => char.ToUpper(w[0]) + w.Substring(1).ToLower()));
        return Enum.TryParse(name, out evt);
    }
}