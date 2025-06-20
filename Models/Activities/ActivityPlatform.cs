using System.Text.Json.Serialization;

namespace SharpCord.Models;

/// <summary>
/// Defines a collection of platforms for which activities can be specified.
/// Each platform represents a specific environment where activities or applications can operate.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ActivityPlatform
{
    /// <summary>
    /// Represents the Android platform within the <see cref="ActivityPlatform"/> enum.
    /// This value is used to specify activities or applications executed on Android devices.
    /// </summary>
    [JsonPropertyName("android")] 
    Android,

    /// <summary>
    /// Represents the Desktop platform within the <see cref="ActivityPlatform"/> enum.
    /// This value is used to specify activities or applications executed on desktop environments.
    /// </summary>
    [JsonPropertyName("desktop")] 
    Desktop,

    /// <summary>
    /// Represents the Embedded platform within the <see cref="ActivityPlatform"/> enum.
    /// This value is used to specify activities or applications executed on embedded systems or devices.
    /// </summary>
    [JsonPropertyName("embedded")] 
    Embedded,

    /// <summary>
    /// Represents the iOS platform within the <see cref="ActivityPlatform"/> enum.
    /// This value is used to specify activities or applications executed on iOS devices.
    /// </summary>
    [JsonPropertyName("ios")] 
    IOS,

    /// <summary>
    /// Represents the PlayStation 4 (PS4) platform within the <see cref="ActivityPlatform"/> enum.
    /// This value is used to specify activities or applications executed on PlayStation 4 devices.
    /// </summary>
    [JsonPropertyName("ps4")] 
    PS4,

    /// <summary>
    /// Represents the PlayStation 5 platform within the <see cref="ActivityPlatform"/> enum.
    /// This value is used to specify activities or applications executed on PlayStation 5 devices.
    /// </summary>
    [JsonPropertyName("ps5")] 
    PS5,

    /// <summary>
    /// Represents the Samsung platform within the <see cref="ActivityPlatform"/> enum.
    /// This value is used to specify activities or applications executed on Samsung devices or platforms.
    /// </summary>
    [JsonPropertyName("samsung")] 
    Samsung,

    /// <summary>
    /// Represents the Xbox platform within the <see cref="ActivityPlatform"/> enum.
    /// This value is used to specify activities or applications executed on Xbox devices.
    /// </summary>
    [JsonPropertyName("xbox")] 
    Xbox
}