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

namespace SharpCord.Attributes;

/// <summary>
/// An attribute used to designate a method as a prefix-based command.
/// </summary>
/// <remarks>
/// This attribute is applied to methods to indicate that they can be invoked as commands
/// with a specific prefix. The <see cref="Name"/> property represents the unique identifier
/// for the command.
/// </remarks>
[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public class PrefixCommandAttribute : Attribute
{
    /// <summary>
    /// Gets the name associated with the command attribute.
    /// Represents the name of the command that will be matched for invocation
    /// when the command processor identifies a valid prefix.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// An attribute used to designate a method as a command that can be invoked via a specific prefix.
    /// </summary>
    public PrefixCommandAttribute(string name) => Name = name;
}