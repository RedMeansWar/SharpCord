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
/// Defines the different types of application commands that can be used.
/// </summary>
public enum ApplicationCommandType
{
    /// <summary>
    /// Represents a slash command type specifically for chat input commands.
    /// These commands are triggered by slash "/" followed by user-defined or pre-defined command keywords.
    /// </summary>
    ChatInput = 1,

    /// <summary>
    /// Represents a user command type, allowing interactions directly with a specific user.
    /// These commands are typically context menu options available for user entities.
    /// </summary>
    User = 2,

    /// <summary>
    /// Represents a command type associated with messages.
    /// These commands are typically contextual, operating directly on messages within the application.
    /// </summary>
    Message = 3,

    /// <summary>
    /// Represents the primary command entry point, serving as the main interface
    /// for initiating or handling an application command.
    /// </summary>
    PrimaryEntryPoint = 4,
}