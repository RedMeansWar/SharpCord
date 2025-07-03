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

using System.Reflection.Metadata;
using SharpCord.Models;
using SharpCord.Guild;

namespace SharpCord.Attributes;

/// <summary>
/// Represents an attribute used to define metadata for creating a channel with specific properties.
/// </summary>
/// <remarks>
/// Can be applied to methods, allowing customization of channel creation behavior with properties such as name, type, and parent ID.
/// </remarks>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class CreateChannelAttribute : Attribute
{
    /// <summary>
    /// Gets or sets the ID of the guild associated with the channel to be created.
    /// </summary>
    public string GuildId { get; set; }
    
    /// <summary>
    /// Gets or sets the name of the channel to be created.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the type of the channel to be created.
    /// </summary>
    public ChannelType Type { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the parent channel or category.
    /// </summary>
    public string? ParentId { get; set; }

    /// <summary>
    /// Specifies that the attributed method is associated with the creation of a channel in a guild.
    /// </summary>
    public CreateChannelAttribute(string guildId, string name, ChannelType type = ChannelType.GuildText)
    {
        GuildId = guildId;
        Name = name;
        Type = type;
    }

    /// <summary>
    /// Executes an asynchronous operation, typically involving the creation or management of a resource.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task ExecuteAsync() => await Channel.CreateChannelAsync(GuildId, Name, Type, ParentId);
}

/// <summary>
/// Represents an attribute used to define metadata for deleting a channel.
/// </summary>
/// <remarks>
/// Can be applied to methods, enabling the identification and handling of channel deletion operations.
/// </remarks>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class DeleteChannelAttribute : Attribute
{
    /// <summary>
    /// Gets or sets the identifier of the guild associated with the operation.
    /// </summary>
    public string GuildId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the channel targeted for the operation.
    /// </summary>
    public string ChannelId { get; set; }

    /// <summary>
    /// Represents an attribute used to define metadata for deleting a channel.
    /// </summary>
    /// <remarks>
    /// Can be applied to methods, enabling the identification and handling of channel deletion operations.
    /// </remarks>
    public DeleteChannelAttribute(string guildId, string channelId)
    {
        GuildId = guildId;
        ChannelId = channelId;
    }

    /// <summary>
    /// Asynchronously executes the associated operation.
    /// </summary>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// </returns>
    public async Task ExecuteAsync() => await Channel.DeleteChannelAsync(GuildId, ChannelId);
}