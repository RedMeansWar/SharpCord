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

namespace SharpCord.Models;

/// <summary>
/// Represents various types of activities that a user can be engaged in.
/// </summary>
public enum ActivityType
{
    /// <summary>
    /// Represents the activity type where the user is engaged in playing a game or interactive activity.
    /// </summary>
    Playing,

    /// <summary>
    /// Represents the activity type where the user is streaming content, such as a live broadcast or video stream.
    /// </summary>
    Streaming,

    /// <summary>
    /// Represents the activity type where the user is listening to something, such as music or a podcast.
    /// </summary>
    Listening,

    /// <summary>
    /// Represents the activity type where the user is watching something, such as a video or stream.
    /// </summary>
    Watching,

    /// <summary>
    /// Represents a custom activity type, which allows users to define their own unique activity.
    /// </summary>
    Custom,

    /// <summary>
    /// Represents the "Competing" activity type, which indicates that a user is engaged in a competitive activity.
    /// </summary>
    Competing
}