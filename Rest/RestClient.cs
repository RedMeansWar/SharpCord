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