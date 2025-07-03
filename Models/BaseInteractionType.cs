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

namespace SharpCord.Models;

/// <summary>
/// Represents the types of base interactions that can occur in the context of the application.
/// </summary>
public enum BaseInteractionType
{
    /// <summary>
    /// Denotes a ping interaction, commonly used to test connectivity
    /// or evaluate the application's responsiveness in real time.
    /// </summary>
    Ping = 1,

    /// <summary>
    /// Represents an interaction triggered by the execution of an application command,
    /// such as slash commands or context menu actions within the application.
    /// </summary>
    ApplicationCommand = 2,

    /// <summary>
    /// Represents an interaction triggered by a message component, such as buttons, select menus, or other interactive elements within a message.
    /// Typically used to handle user interactions with UI elements embedded in messages.
    /// </summary>
    MessageComponent = 3,

    /// <summary>
    /// Specifies a specialized attribute interaction type associated with
    /// application commands, used to define additional metadata or behavior
    /// for such commands within the application's interaction handling framework.
    /// </summary>
    ApplicationCommandAttribute = 4,

    /// <summary>
    /// Represents a modal submission interaction, typically triggered when
    /// a user submits data through a modal interface within the application.
    /// </summary>
    ModalSubmit = 5,
}