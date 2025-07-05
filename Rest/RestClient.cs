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

using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using SharpCord.Helpers;
using SharpCord.Models;

namespace SharpCord.Rest;

/// <summary>
/// 
/// </summary>
public class RestClient
{
    internal readonly string _token;
    internal readonly HttpClient _http;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    public RestClient(string token)
    {
        _token = token;
        _http = new HttpClient();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    public async Task RegisterGlobalCommandAsync(ApplicationCommand command)
    {
        JsonSerializerOptions options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower, Converters = { new JsonStringEnumConverter() } };

        var response = await HttpHelper.SendRequestAsync($"/applications/{command.ApplicationId}/commands", "POST", command, options);

        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Registers a guild-specific application command.
    /// </summary>
    /// <param name="command">The application command to be registered.</param>
    /// <param name="guildId">The unique identifier of the guild where the command will be registered.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task RegisterGuildCommandAsync(ApplicationCommand command, string guildId)
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            Converters = { new JsonStringEnumConverter() }
        };

        var response = await HttpHelper.SendRequestAsync($"/applications/{command.ApplicationId}/guilds/{guildId}/commands", "POST", command, options);

        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Registers a guild-specific application command using the provided guild identifier.
    /// </summary>
    /// <param name="command">The application command to be registered.</param>
    /// <param name="guildId">The unique identifier of the guild where the command will be registered.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task RegisterGuildCommandAsync(ApplicationCommand command, long guildId) 
        => await RegisterGuildCommandAsync(command, guildId.ToString());

    /// <summary>
    /// Edits an existing global application command.
    /// </summary>
    /// <param name="applicationId">The unique identifier of the application that owns the command.</param>
    /// <param name="commandId">The unique identifier of the command to be edited.</param>
    /// <param name="command">The updated application command details.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task EditGlobalCommandAsync(string applicationId, string commandId, ApplicationCommand command)
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            Converters = { new JsonStringEnumConverter() }
        };

        var response = await HttpHelper.SendRequestAsync($"/applications/{applicationId}/commands/{commandId}", "PATCH", command, options);

        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Edits an existing guild-specific application command.
    /// </summary>
    /// <param name="applicationId">The unique identifier of the application.</param>
    /// <param name="commandId">The unique identifier of the command to be edited.</param>
    /// <param name="guildId">The unique identifier of the guild where the command resides.</param>
    /// <param name="command">The updated application command data.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task EditGuildCommandAsync(string applicationId, string commandId, string guildId, ApplicationCommand command)
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            Converters = { new JsonStringEnumConverter() }
        };

        var response = await HttpHelper.SendRequestAsync($"/applications/{applicationId}/guilds/{guildId}/commands/{commandId}", "PATCH", command, options);

        response.EnsureSuccessStatusCode();
    }
}