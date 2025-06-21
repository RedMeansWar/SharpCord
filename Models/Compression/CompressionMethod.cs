using System.Text.Json.Serialization;

namespace SharpCord.Models;

/// <summary>
/// Specifies the method of compression that can be applied.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CompressionMethod
{
    /// <summary>
    /// Represents the Zlib stream compression method.
    /// This method utilizes the Zlib data compression algorithm to perform
    /// stream-based compression, offering efficient reduction of data size.
    /// </summary>
    [JsonPropertyName("zlib-stream")]
    ZlibStream,
}