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

using SharpCord.Types;

namespace SharpCord.Models;

/// <summary>
/// Represents a voice channel within a guild on Discord.
/// Provides properties specific to voice channels, such as bitrate, user limits, and region settings.
/// Inherits from the <see cref="BaseChannel"/> class.
/// </summary>
public class BaseGuildVoiceChannel : BaseChannel
{
    /// <summary>
    /// Gets or sets the bitrate for the voice channel, defined in bits per second.
    /// The bitrate influences the audio quality within the channel, with higher values
    /// typically improving quality but requiring greater bandwidth. Actual maximum
    /// and default values may depend on server configurations and permissions.
    /// </summary>
    public int Bitrate { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of users allowed in the voice channel simultaneously.
    /// A value of 0 typically indicates no limit, allowing any number of users to join
    /// up to the server's configured maximum capacity. The actual limit may depend on
    /// server-level settings and permissions.
    /// </summary>
    public int UserLimit { get; set; }

    /// <summary>
    /// Gets or sets the regional server used for the channel's voice communication.
    /// The server region can influence latency and connection quality for users,
    /// and selecting the most appropriate region can improve the overall voice experience.
    /// The value may be null or automatically assigned by the platform.
    /// </summary>
    public int RtcRegion { get; set; }
}