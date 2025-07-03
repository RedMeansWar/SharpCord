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

namespace SharpCord.Interfaces;

/// <summary>
/// Represents the configuration options used for REST operations within the application.
/// This interface provides a set of properties to customize and manage REST-related settings,
/// including endpoints, headers, timeouts, rate limiting, and other optional configurations.
/// </summary>
public interface IRestOptions
{
    /// <summary>
    /// Gets the HTTP message handler used by the client for making requests.
    /// This can be used to customize or override the default request behavior
    /// when interacting with external services or APIs.
    /// </summary>
    HttpMessageHandler? Agent { get; }

    /// <summary>
    /// Gets the base URL or endpoint used for API communications. This property
    /// defines the primary address to which HTTP requests are sent when interacting
    /// with the API, serving as a foundational configuration for the client.
    /// </summary>
    string Api { get; }

    /// <summary>
    /// Gets the prefix to be used for authentication headers in HTTP requests.
    /// This is typically used to specify the scheme or format for
    /// authorization tokens when making API calls.
    /// </summary>
    string AuthPrefix { get; }

    /// <summary>
    /// Gets the base URL for accessing the Content Delivery Network (CDN).
    /// This is typically used to retrieve static assets or media resources efficiently.
    /// </summary>
    string Cdn { get; }

    /// <summary>
    /// Gets the maximum number of requests allowed globally per second.
    /// This is used to control the rate at which requests are sent,
    /// ensuring compliance with rate-limiting constraints and preventing
    /// overloading of external services.
    /// </summary>
    double GlobalRequestsPerSecond { get; }

    /// <summary>
    /// Gets the interval at which the handler sweeping process occurs.
    /// This defines the frequency at which unused or expired handlers
    /// are cleared to optimize resource usage and system performance.
    /// </summary>
    TimeSpan HandlerSweepInterval { get; }

    /// <summary>
    /// Gets the duration for which a hash remains valid before it is considered expired.
    /// This property is used to determine the lifespan of hash-based resources or identifiers
    /// within the system. After the specified duration, the hash may be regenerated or refreshed
    /// depending on the implementation.
    /// </summary>
    TimeSpan HashLifetime { get; }

    /// <summary>
    /// Gets the interval at which hash entries are swept or cleared from memory.
    /// This helps in managing memory usage and maintaining the efficiency of
    /// hash-based operations by periodically removing stale or unused entries.
    /// </summary>
    TimeSpan HashSweepInterval { get; }

    /// <summary>
    /// Gets the collection of HTTP headers to be included with requests.
    /// These headers can be used to provide additional metadata or authorization
    /// details required when interacting with external APIs or services.
    /// </summary>
    Dictionary<string, string> Headers { get; }

    /// <summary>
    /// Gets the interval at which warnings for invalid requests are issued.
    /// This value defines the frequency, in milliseconds, within which multiple
    /// invalid requests may trigger relevant warnings or alerts to the developer.
    /// </summary>
    int InvalidRequestWarningInterval { get; }

    /// <summary>
    /// Gets the URL or endpoint used to interact with the media proxy service.
    /// This typically serves as a gateway for handling media-related requests and resources.
    /// </summary>
    string MediaProxy { get; }

    /// <summary>
    /// Gets the offset, in milliseconds, to account for potential time discrepancies
    /// in request handling or scheduling. This is used to adjust timing calculations
    /// to ensure accurate synchronization and operation.
    /// </summary>
    int Offset { get; } // in ms

    /// <summary>
    /// Gets the value indicating how rate-limited requests are handled. This property can
    /// represent either a collection of routes for which to reject requests when the rate
    /// limit is reached or a delegate method to implement custom rate limit handling logic.
    /// </summary>
    object? RejectOnRateLimit { get; } // string[] or delegate

    /// <summary>
    /// Gets the number of times a request will be retried in case of failure.
    /// This determines how many additional attempts will be made to complete
    /// a request before considering it unsuccessful.
    /// </summary>
    int Retries { get; }

    /// <summary>
    /// Gets the duration of time to wait before a request is considered timed out.
    /// This is used to define the maximum allowed time for operations to complete
    /// before terminating the request and potentially retrying or throwing an error.
    /// </summary>
    TimeSpan Timeout { get; }

    /// <summary>
    /// Gets the additional string to be appended to the User-Agent header value for HTTP requests.
    /// This is used to provide custom identification or context about the client making the request.
    /// </summary>
    string? UserAgentAppendix { get; }

    /// <summary>
    /// Gets the version of the API or library being used.
    /// This is typically utilized to specify or retrieve the versioning information
    /// relevant for client or server communication protocols.
    /// </summary>
    string Version { get; }
}