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

using System.Text.Json.Serialization;

namespace SharpCord.Models;

/// <summary>
/// Represents a field in an embed, consisting of a name, value, and an optional
/// flag indicating whether the field should be displayed inline.
/// </summary>
public class EmbedField
{
    /// <summary>
    /// Gets or sets the name of the embed field.
    /// This is typically a string representing the field's title or heading.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the value of the embed field.
    /// This is typically a string containing the main content or information of the field.
    /// </summary>
    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the embed field is displayed inline
    /// with other fields. When set to true, the field will be aligned horizontally
    /// with other inline fields.
    /// </summary>
    [JsonPropertyName("inline")]
    public bool Inline { get; set; }
    
    public EmbedField() {}
    
    public EmbedField(string name, string value, bool inline = false)
    {
        Name = name;
        Value = value;
        Inline = inline;
    }
}