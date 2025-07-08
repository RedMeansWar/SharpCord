using SharpCord.Guild;
using SharpCord.Models;

namespace SharpCord.Extensions;

/// <summary>
/// 
/// </summary>
public static class ChannelExtensions
{
    /// <summary>
    /// Asynchronously sends a specified message in a specified channel.
    /// </summary>
    /// <param name="channel"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static async Task SendMessageAsync(this BaseChannel channel, string message) => await Channel.SendMessageAsync(channel.Id.ToString(), message);
}