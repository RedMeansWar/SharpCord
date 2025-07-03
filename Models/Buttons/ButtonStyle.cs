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
/// Defines the styles available for buttons, each reflecting a unique visual appearance
/// and typically associated with a specific purpose or action.
/// </summary>
public enum ButtonStyle
{
    /// <summary>
    /// Represents the primary button style with a visually distinctive and prominent appearance,
    /// typically used for main actions or calls to action. (Blue)
    /// </summary>
    Primary = 1,

    /// <summary>
    /// Represents the secondary button style with a less prominent appearance,
    /// typically used for supplementary or alternative actions. (Light Gray)
    /// </summary>
    Secondary = 2,

    /// <summary>
    /// Represents a success button style, commonly used to indicate a positive,
    /// confirming, or successful action. (Green)
    /// </summary>
    Success = 3,

    /// <summary>
    /// Represents the danger button style, designed to convey a warning or critical action,
    /// typically associated with actions requiring caution or that have potentially destructive outcomes. (Red)
    /// </summary>
    Danger = 4,

    /// <summary>
    /// Represents a button style used for hyperlinking or navigation purposes,
    /// designed to redirect users to an external or internal link when clicked. (Dark Gray)
    /// </summary>
    Link = 5,

    /// <summary>
    /// Represents a premium button style tailored for specialized or exclusive actions,
    /// designed to stand out with a unique appearance for higher emphasis. (Light Blue)
    /// </summary>
    Premium = 6,
}