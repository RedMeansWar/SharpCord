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

using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using SharpCord.Models;
using SharpCord.Utils;
using SharpCord.Interactions;

namespace SharpCord.Guild;

/// <summary>
/// Represents a channel entity with methods to manage and interact with channels.
/// </summary>
public class Channel
{
    /// <summary>
    /// Asynchronously creates a new channel with the specified parameters.
    /// </summary>
    /// <param name="interaction">The interaction context used to create the channel.</param>
    /// <param name="name">The name of the channel to be created.</param>
    /// <param name="type">The type of channel to be created.</param>
    /// <param name="parentId">Optional ID of the parent category under which the channel will be created.</param>
    /// <param name="position">Optional position of the channel in relation to other channels in the same category.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the newly created channel.</returns>
    public async Task CreateChannelAsync(Interaction interaction, string name, ChannelType type, string? parentId = null, int? position = null)
    {
        var payload = new
        {
            name,
            type = (int)type,
            parentId,
            position
        };

        var guildId = interaction.GuildId;
        var url = $"/guilds/{guildId}/channels";

        var response = await HttpHelper.SendRequestAsync(url, "POST", payload);

        if (!response.IsSuccessStatusCode)
        {
            var err = await response.Content.ReadAsStringAsync();
            Log.Error($"❌ Failed to create channel '{name}' in guild {guildId}: {response.StatusCode}\n{err}");
        }
        
        Log.Info($"✅ Created channel '{name}' in guild {guildId}");
    }

    /// <summary>
    /// Asynchronously creates a new channel with the specified parameters in a guild.
    /// </summary>
    /// <param name="guildId">The ID of the guild where the channel will be created.</param>
    /// <param name="name">The name of the channel to be created.</param>
    /// <param name="type">The type of channel to be created. Defaults to GuildText.</param>
    /// <param name="parentId">Optional ID of the parent category under which the channel will be created.</param>
    /// <param name="position">Optional position of the channel in relation to other channels in the same category.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the newly created channel.</returns>
    public static async Task CreateChannelAsync(string guildId, string name, ChannelType type = ChannelType.GuildText, string? parentId = null, int? position = null)
    {
        var payload = new
        {
            name,
            type = (int)type
        };

        var url = $"/guilds/{guildId}/channels";

        var response = await HttpHelper.SendRequestAsync(url, "POST", payload);
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"❌ Failed to create channel: {response.StatusCode}\n{body}");
        }

        Log.Info($"✅ Created channel '{name}' in guild {guildId}");
    }

    public static async Task DeleteChannelAsync(string guildId, string channelId)
    {
        
    }
}