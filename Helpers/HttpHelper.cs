using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SharpCord.Utils;

namespace SharpCord.Helpers
{
    /// <summary>
    /// SharpCord HTTP Helper, made for sending requests a bit easier.
    /// </summary>
    public static class HttpHelper
    {
        private static HttpClient _httpClient;

        /// <summary>
        /// Initializes the HTTP helper with a provided <see cref="HttpClient"/> instance.
        /// Configures default headers for authorization using the bot token.
        /// </summary>
        /// <param name="http">An instance of <see cref="HttpClient"/> used for sending HTTP requests.</param>
        public static void InitializeHelper(HttpClient http)
        {
            _httpClient = http;

            SetHeader("Authorization", $"Bot {DiscordClient.Token}");
        }

        /// <summary>
        /// Sets your own header.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetHeader(string key, string value) => _httpClient.DefaultRequestHeaders.Add(key, value);

        /// <summary>
        /// Sends an HTTP request to the Discord API using the provided method and optional body payload.
        /// </summary>
        /// <param name="path">The relative API endpoint path to send the request to.</param>
        /// <param name="method">The HTTP method to use (e.g., GET, POST, PUT). Defaults to "GET".</param>
        /// <param name="body">The optional body payload of the request. If provided, it will be serialized to JSON.</param>
        /// <param name="serializerOptions">Optional JSON serializer options for customizing serialization.</param>
        /// <returns>Returns an instance of <see cref="HttpResponseMessage"/> representing the response from the API.</returns>
        public static async Task<HttpResponseMessage> SendRequestAsync(string path, string method = "GET", object? body = null, JsonSerializerOptions? serializerOptions = null)
        {
            HttpRequestMessage req = new(new(method), $"https://discord.com/api/v10{path}");

            if (body is HttpContent httpContent)
            {
                req.Content = httpContent; // for the multipart stuff
            }
            else if (body is not null)
            {
                string json = JsonSerializer.Serialize(body, serializerOptions);

                req.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            HttpResponseMessage res = await _httpClient.SendAsync(req);
            if (!res.IsSuccessStatusCode)
            {
                string error = await res.Content.ReadAsStringAsync();
                Log.Error($"Error sending request to the Discord API {res.StatusCode}: {error}");
            }

            return res;
        }
    }
}
