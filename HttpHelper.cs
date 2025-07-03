using SharpCord.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SharpCord
{
    /// <summary>
    /// SharpCord HTTP Helper, made for sending requests a bit easier.
    /// </summary>
    public static class HttpHelper
    {
        private static HttpClient _httpClient;

        public static void InitializeHelper(HttpClient http)
        {
            _httpClient = http;

            _httpClient.DefaultRequestHeaders.Authorization = new("Bot", DiscordClient.Token);
        }

        /// <summary>
        /// Send a request to the Discord API with your own options
        /// </summary>
        /// <param name="method"></param>
        /// <param name="path"></param>
        /// <param name="body"></param>
        /// <returns></returns>
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
