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
using SharpCord.Types;

namespace SharpCord.Models;

/// <summary>
/// 
/// </summary>
public class ApplicationCommand
{
    /// <summary>
    /// Gets or sets the unique identifier of the application command.
    /// </summary>
    /// <remarks>
    /// This property represents the Snowflake ID of the command, which serves as its unique identifier within the system.
    /// It is essential for distinguishing the command and performing operations such as updating or deleting.
    /// </remarks>
    [JsonPropertyName("id")]
    public Snowflake Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the application associated with the command.
    /// </summary>
    /// <remarks>
    /// This property represents the application that owns the command. It is a Snowflake value,
    /// which is a unique identifier commonly used in Discord API to track resources. The application ID
    /// is required to correctly register and manage commands at both global and guild levels.
    /// </remarks>
    [JsonPropertyName("application_id")] 
    public Snowflake ApplicationId { get; set; }

    /// <summary>
    /// Gets or sets the localized names for the application command in multiple languages.
    /// </summary>
    /// <remarks>
    /// This property stores a collection of localized names for the command, allowing it to be displayed
    /// appropriately in different regions or languages. The dictionary key represents the locale (e.g., "en-US"),
    /// while the value represents the corresponding localized name. If no entries are provided, the command may
    /// fall back to a default name.
    /// </remarks>
    [JsonPropertyName("name_localizations")]
    public Dictionary<string, string>? NameLocalizations { get; set; }

    /// <summary>
    /// Gets or sets the localized name of the application command.
    /// </summary>
    /// <remarks>
    /// This property provides a language-specific version of the command name, which can be displayed to users
    /// based on their locale settings. If no localization is available, it might fall back to the default name.
    /// </remarks>
    [JsonPropertyName("name_localized")]
    public string? NameLocalized { get; set; }

    /// <summary>
    /// Gets or sets the description for the application command.
    /// </summary>
    /// <remarks>
    /// This property defines a brief explanation or details about the application command. It is typically displayed
    /// to users to provide clarity about the purpose or functionality of the command.
    /// </remarks>
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the dictionary of localized descriptions for the application command.
    /// </summary>
    /// <remarks>
    /// This property allows you to specify descriptions for the command in different languages, using a dictionary with
    /// locale codes as keys and their corresponding localized descriptions as values. It enables the application command
    /// to dynamically display the appropriate description based on the user's locale.
    /// </remarks>
    [JsonPropertyName("description_localizations")]
    public Dictionary<string, string>? DescriptionLocalizations { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the application command can be used in direct messages.
    /// </summary>
    /// <remarks>
    /// This property determines if the command is accessible via direct messages with the bot.
    /// If set to <c>true</c>, the command is available for use in direct messages; otherwise, it is restricted to guild channels.
    /// </remarks>
    [JsonPropertyName("default_member_permissions")]
    public bool? DMPermission { get; set; }

    /// <summary>
    /// Gets or sets the default permissions required for a member to use the application command.
    /// </summary>
    /// <remarks>
    /// This property defines the permissions that are necessary for a member to execute the command.
    /// It is a bitwise value specifying the required permissions, allowing for granular control over accessibility.
    /// When not specified, it defaults to the permissions defined at a higher level if applicable.
    /// </remarks>
    [JsonPropertyName("default_member_permissions")]
    public string? DefaultMemberPermissions { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the application command is marked as Not Safe For Work (NSFW).
    /// </summary>
    /// <remarks>
    /// This property determines if the command contains content that may not be appropriate for all audiences.
    /// It is used to flag such commands to restrict their visibility or usage in specific contexts.
    /// </remarks>
    [JsonPropertyName("nsfw")]
    public bool? NSFW { get; set; }

    /// <summary>
    /// Gets or sets the type of the application command.
    /// </summary>
    /// <remarks>
    /// This property specifies the command type, represented by the <see cref="ApplicationCommandType"/> enumeration.
    /// Possible types include ChatInput, User, Message, and PrimaryEntryPoint.
    /// </remarks>
    [JsonPropertyName("type")]
    public ApplicationCommandType Type { get; set; } = ApplicationCommandType.ChatInput;

    /// <summary>
    /// Gets or sets the list of options associated with the application command.
    /// </summary>
    /// <remarks>
    /// This property represents a collection of <see cref="ApplicationCommandOption"/> objects.
    /// Each option provides additional parameters or inputs that can be configured for the command.
    /// </remarks>
    [JsonPropertyName("options")]
    public List<ApplicationCommandOption>? Options { get; set; }

    /// <summary>
    /// Gets or sets the list of integration types associated with the application command.
    /// </summary>
    /// <remarks>
    /// This property represents a collection of integer values that specify the various integration types
    /// applicable to the command. Each integer corresponds to a predefined integration type.
    /// </remarks>
    [JsonPropertyName("integration_types")]
    public List<int>? IntegrationTypes { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the version of the application command.
    /// </summary>
    /// <remarks>
    /// This property uses a Snowflake value for identifying specific versions of the application command.
    /// Snowflakes are unique 64-bit identifiers that incorporate timestamp and other relevant information.
    /// </remarks>
    [JsonPropertyName("version")]
    public Snowflake Version { get; set; }
    

}