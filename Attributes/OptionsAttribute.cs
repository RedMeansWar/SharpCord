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
/// An attribute used to define options for an application command parameter.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter)]
public class OptionsAttribute : Attribute
{
    /// <summary>
    /// Gets the name of the parameter this attribute is associated with.
    /// This name is used to identify the parameter when defining application command options.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets or sets the description of the parameter this attribute is associated with.
    /// This description is used to provide additional details or context about the parameter within application commands.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Determines whether the parameter associated with this attribute is required.
    /// A required parameter must be specified when using the application command.
    /// </summary>
    public bool Required { get; set; } = true;

    /// <summary>
    /// Gets or sets the type of the application command option.
    /// This type specifies the format of input data expected for the associated parameter,
    /// such as string, integer, user, channel, etc., as defined in
    /// <see cref="SharpCord.Models.ApplicationCommandOptionType"/>.
    /// </summary>
    public ApplicationCommandOptionType Type { get; set; } = ApplicationCommandOptionType.String;

    /// <summary>
    /// An attribute used to define options for an application command parameter.
    /// </summary>
    public OptionsAttribute(string name) => Name = name;
}