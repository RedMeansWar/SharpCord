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
/// Represents error codes specific to SharpCord. These error codes are used
/// to identify and handle various error conditions and exceptions within the library
/// related to operations and functionalities.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SharpCordErrorCodes
{
    /// <summary>
    /// Indicates a missing token required for managing application command permissions
    /// in SharpCord. This error occurs when the necessary token for authorization
    /// is not provided while attempting to perform operations related to
    /// application command permissions.
    /// </summary>
    [JsonPropertyName("ApplicationCommandPermissionsTokenMissing")]
    ApplicationCommandPermissionsTokenMissing,

    /// <summary>
    /// Represents a deprecated error indicating that no focused option was found
    /// during an autocomplete interaction in SharpCord.
    /// This error was used specifically to handle cases where autocomplete interactions
    /// failed to identify the focused input option.
    /// </summary>
    [JsonPropertyName("AutocompleteInteractionOptionNoFocusedOption")]
    AutocompleteInteractionOptionNoFocusedOption,

    /// <summary>
    /// Represents a deprecated error related to resolving a ban ID in SharpCord.
    /// This error was used for identifying issues when attempting to resolve a ban's unique identifier.
    /// </summary>
    [JsonPropertyName("BanResolveId")]
    BanResolveId,

    /// <summary>
    /// Represents an error in SharpCord related to an invalid bit field.
    /// This error occurs when a provided bit field is recognized as malformed or outside the acceptable range of values.
    /// </summary>
    [JsonPropertyName("BitFieldInvalid")]
    BitFieldInvalid,

    /// <summary>
    /// Indicates a SharpCord error related to a bulk ban operation.
    /// This error occurs when an attempt is made to perform a bulk ban, but the provided options for the operation are empty or invalid.
    /// </summary>
    [JsonPropertyName("BulkBanUsersOptionEmpty")]
    BulkBanUsersOptionEmpty,

    /// <summary>
    /// Represents an error related to a button's custom identifier in the SharpCord library.
    /// This error can occur when the custom identifier associated with a button is improperly defined, invalid, or does not adhere to the expected format.
    /// </summary>
    [Obsolete] 
    [JsonPropertyName("ButtonCustomId")]
    ButtonCustomId,

    /// <summary>
    /// Indicates an error related to a button's label in the SharpCord library.
    /// This error may occur when the label associated with a button is improperly defined, invalid, or does not meet required conditions.
    /// </summary>
    [Obsolete] 
    [JsonPropertyName("ButtonLabel")]
    ButtonLabel,

    /// <summary>
    /// Indicates an error related to a button's URL in the SharpCord library.
    /// This error may occur when the URL associated with a button is improperly defined or invalid.
    /// </summary>
    [Obsolete] 
    [JsonPropertyName("ButtonURL")]
    ButtonURL,

    /// <summary>
    /// Represents an error indicating that the specified channel is not present in the cache.
    /// This occurs when an operation requires accessing a channel that has not been
    /// cached by SharpCord, typically due to configuration or state limitations.
    /// </summary>
    [JsonPropertyName("ChannelNotCached")] 
    ChannelNotCached,

    /// <summary>
    /// Represents an error in SharpCord that occurs when the client
    ///  provides an invalid or unsupported option. This error indicates
    /// that the provided option does not meet the expected criteria or
    /// is not recognized by the system.
    /// </summary>
    [JsonPropertyName("ClientInvalidOption")]
    ClientInvalidOption,

    /// <summary>
    /// Represents an error where the client is initialized with an invalid or improperly
    /// configured set of shard identifiers in SharpCord. This typically occurs when the
    /// provided shard configuration does not match the expected or allowable shard setup
    /// for the application or environment.
    /// </summary>
    [JsonPropertyName("ClientInvalidProvidedShards")]
    ClientInvalidProvidedShards,

    /// <summary>
    /// Represents an error indicating that the required intents for the client
    /// are missing. This error occurs when the necessary Gateway Intents
    /// are not specified, preventing the client from receiving specific types
    /// of events from the Discord API.
    /// </summary>
    [JsonPropertyName("ClientMissingIntents")]
    ClientMissingIntents,

    /// <summary>
    /// Represents an error indicating that the client is not ready to perform the requested operation in SharpCord.
    /// This error occurs when certain prerequisites or initialization steps required for the client
    /// to operate have not yet been completed.
    /// </summary>
    [JsonPropertyName("ClientNotReady")] ClientNotReady,

    /// <summary>
    /// Represents an error related to converting or transforming color values in SharpCord.
    /// This error occurs when an invalid color value or format is provided, or when a
    /// color conversion operation fails due to unsupported formats or parameters.
    /// </summary>
    [JsonPropertyName("ColorConvert")] ColorConvert,

    /// <summary>
    /// Represents an error related to an invalid or unsupported color range
    /// in SharpCord. This error occurs when a specified color value exceeds
    /// the allowed limits or does not comply with the accepted range or format.
    /// </summary>
    [JsonPropertyName("ColorRange")] ColorRange,

    /// <summary>
    /// Represents an error indicating that a command interaction option is empty
    /// in SharpCord. This error occurs when an expected option value for a
    /// command interaction is missing or not provided during execution.
    /// </summary>
    [JsonPropertyName("CommandInteractionOptionEmpty")]
    CommandInteractionOptionEmpty,

    /// <summary>
    /// Represents an error where a command interaction option is expected to
    /// include a subcommand, but none is provided. This error typically occurs
    /// when handling command interactions that require a hierarchical structure
    /// involving subcommands, yet the interaction data does not fulfill this requirement.
    /// </summary>
    [JsonPropertyName("CommandInteractionOptionNoSubcommand")]
    CommandInteractionOptionNoSubcommand,

    /// <summary>
    /// Represents an error indicating that a command interaction option
    /// is missing a subcommand group when one is expected. This error
    /// typically occurs during the processing of command interactions
    /// in SharpCord where the structure of the input does not align
    /// with the expected schema involving subcommand groups.
    /// </summary>
    [JsonPropertyName("CommandInteractionOptionNoSubcommandGroup")]
    CommandInteractionOptionNoSubcommandGroup,

    /// <summary>
    /// Represents an error indicating that a specified interaction option
    /// was not found during the processing of a command in SharpCord.
    /// This error occurs when the expected option for a command interaction
    /// is missing or does not match the provided parameters.
    /// </summary>
    [JsonPropertyName("CommandInteractionOptionNotFound")]
    CommandInteractionOptionNotFound,

    /// <summary>
    /// Represents an error related to the type of an option in a command interaction
    /// within SharpCord. This error occurs when an invalid or unsupported option type
    /// is encountered during the processing of a command interaction.
    /// </summary>
    [JsonPropertyName("CommandInteractionOptionType")]
    CommandInteractionOptionType,

    /// <summary>
    /// Represents an error that occurs when attempting to delete a group direct message
    /// channel in SharpCord. This error may indicate issues such as insufficient
    /// permissions, invalid channel identifiers, or an inability to perform the operation
    /// due to other restrictions or constraints.
    /// </summary>
    [JsonPropertyName("DeleteGroupDMChannel")]
    DeleteGroupDMChannel,

    /// <summary>
    /// Represents an error indicating that one or more privileged Gateway Intents
    /// are disallowed or not enabled within the application's settings. This error
    /// occurs when an operation or connection attempt requires specific enabled intents
    /// that the application does not have access to or has not been configured for.
    /// </summary>
    [Obsolete]
    [JsonPropertyName("DisallowedIntents")]
    DisallowedIntents,

    /// <summary>
    /// Represents an error that occurs when there is an issue managing emojis
    /// in SharpCord. This may happen due to insufficient permissions,
    /// invalid input, or other restrictions related to emoji management operations.
    /// </summary>
    [JsonPropertyName("EmojiManaged")] 
    EmojiManaged,

    /// <summary>
    /// Represents an error related to invalid or unrecognized emoji types
    /// in SharpCord. This error occurs when an operation is performed
    /// using an emoji type that does not meet the expected format
    /// or requirements.
    /// </summary>
    [JsonPropertyName("EmojiType")] 
    EmojiType,

    /// <summary>
    /// Represents an error that occurs when attempting to create an entitlement
    /// with an invalid or unauthorized owner in SharpCord. This error typically
    /// indicates that the specified owner does not meet the requirements
    /// or permissions needed for the entitlement creation process.
    /// </summary>
    [JsonPropertyName("EntitlementCreateInvalidOwner")]
    EntitlementCreateInvalidOwner,

    /// <summary>
    /// Represents an error in SharpCord that occurs when resolving a user ID
    /// while fetching a ban entry fails. This error typically arises when the
    /// provided ID is invalid or does not match any existing user associated
    /// with a ban in the system.
    /// </summary>
    [JsonPropertyName("FetchBanResolveId")]
    FetchBanResolveId,

    /// <summary>
    /// Represents an error that occurs when attempting to fetch a direct message channel
    /// associated with a guild in SharpCord. This error typically arises when there is
    /// an issue retrieving the channel or if the operation is not permitted.
    /// </summary>
    [JsonPropertyName("FetchGuildDMChannel")]
    FetchGuildDMChannel,

    /// <summary>
    /// Represents an error encountered while attempting to fetch the owner ID
    /// in SharpCord. This error signifies a failure or issue in getting
    /// the necessary owner identification, which may be required for
    /// certain operations or permissions handling.
    /// </summary>
    [JsonPropertyName("FetchOwnerId")] 
    FetchOwnerId,

    /// <summary>
    /// Represents an error indicating that a specified file could not be found
    /// within the context of SharpCord operations. This error is typically encountered
    /// when attempting to access or reference a file that does not exist at the
    /// given path or location.
    /// </summary>
    [JsonPropertyName("FileNotFound")] 
    FileNotFound,

    /// <summary>
    /// Represents an error related to global command permissions in SharpCord.
    /// This occurs when there is an issue managing or verifying permissions
    /// for global commands within the application.
    /// </summary>
    [JsonPropertyName("GlobalCommandPremissions")]
    GlobalCommandPremissions,

    /// <summary>
    /// Represents an issue with permissions for performing actions on a guild channel.
    /// This error occurs when the current user or application does not have the
    /// required permissions to manage or interact with a specific guild channel
    /// in SharpCord.
    /// </summary>
    [JsonPropertyName("GuildChannelPermissions")]
    GuildChannelPermissions,

    /// <summary>
    /// Represents an error code indicating that a guild channel is orphaned,
    /// meaning it is not associated with a valid parent category or guild structure
    /// in SharpCord. This can occur when a channel's relationships or hierarchy
    /// are improperly configured or missing.
    /// </summary>
    [JsonPropertyName("GuildChannelOrphan")]
    GuildChannelOrphan,

    /// <summary>
    /// Represents an error code that indicates a failure to resolve or identify
    /// a guild channel in SharpCord. This error typically occurs when the
    /// specified guild channel cannot be found, is inaccessible, or is invalid
    /// during an operation that requires channel identification or resolution.
    /// </summary>
    [JsonPropertyName("GuildChannelResolve")]
    GuildChannelResolve,

    /// <summary>
    /// Indicates that the specified guild channel is not owned by the user or client in SharpCord.
    /// This error occurs when attempting to perform operations or modifications on a guild channel
    /// without appropriate ownership or permissions.
    /// </summary>
    [JsonPropertyName("GuildChannelUnowned")]
    GuildChannelUnowned,

    /// <summary>
    /// Indicates that a message is required in a Guild Forum to perform the requested operation.
    /// This error occurs when attempting to execute actions that mandate a message being present
    /// within a Guild Forum context in SharpCord.
    /// </summary>
    [JsonPropertyName("GuildForumMessageRequired")]
    GuildForumMessageRequired,

    /// <summary>
    /// Represents an error that occurs when a timeout is reached while attempting
    /// to retrieve or manage guild members in SharpCord. This error typically indicates
    /// that the operation exceeded the allowed time limit for completion.
    /// </summary>
    [JsonPropertyName("GuildMembersTimeout")]
    GuildMembersTimeout,

    /// <summary>
    /// Represents an error code indicating that the operation being attempted requires
    /// ownership of the guild, but the current context does not meet this requirement.
    /// This error typically occurs when non-owner users
    /// attempt certain actions reserved for guild owners.
    /// </summary>
    [JsonPropertyName("GuildOwned")]
    GuildOwned,

    /// <summary>
    /// Represents an error that occurs during the resolution process of a scheduled event
    /// in SharpCord. This error typically signifies an issue encountered when retrieving
    /// or processing data associated with a guild's scheduled event.
    /// </summary>
    [JsonPropertyName("GuildScheduledEventResolve")]
    GuildScheduledEventResolve,

    /// <summary>
    /// Represents a timeout error that occurs while attempting to interact with
    /// the guild soundboard sounds feature in SharpCord. This error indicates that
    /// the operation has exceeded the allowed time limit and could not be completed.
    /// </summary>
    [JsonPropertyName("GuildSoundboardSoundsTimeout")]
    GuildSoundboardSoundsTimeout,

    /// <summary>
    /// Represents an error occurring when an attempt is made to resolve an entity
    /// within a guild that is not cached. This error indicates that the entity
    /// was not found in the local cache and may require additional steps to retrieve
    /// or handle the entity.
    /// </summary>
    [JsonPropertyName("GuildUncachedEntityResolve")]
    GuildUncachedEntityResolve,

    /// <summary>
    /// Represents an error where the current user's guild data could not be cached
    /// in the SharpCord library. This may occur if the user's guild information
    /// is unavailable or not retrieved during the caching process.
    /// </summary>
    [JsonPropertyName("GuildUncachedMe")]
    GuildUncachedMe,

    /// <summary>
    /// Represents an error encountered when attempting to resolve a guild voice channel
    /// in SharpCord. This error occurs when the specified voice channel cannot be
    /// identified or located within the guild's available channels.
    /// </summary>
    [JsonPropertyName("GuildVoiceChannelResolve")]
    GuildVoiceChannelResolve,

    /// <summary>
    /// Represents an error related to invalid or unsupported image formats
    /// in SharpCord. This error occurs when the provided image format
    /// does not meet the expected requirements or is not supported
    /// during an operation involving image processing.
    /// </summary>
    [Obsolete] 
    [JsonPropertyName("ImageFormat")]
    ImageFormat,

    /// <summary>
    /// Represents an error related to invalid or unsupported image size parameters
    /// in SharpCord. This error occurs when an image size value provided for
    /// an operation is invalid, exceeds limits, or is not supported by the API.
    /// </summary>
    [Obsolete] 
    [JsonPropertyName("ImageSize")]
    ImageSize,

    /// <summary>
    /// Represents an error condition where an interaction has already been responded to
    /// in SharpCord. This occurs when an attempt is made to reply to an interaction
    /// that has already received a response.
    /// </summary>
    [JsonPropertyName("InteractionAlreadyReplied")]
    InteractionAlreadyReplied,

    /// <summary>
    /// Represents an error occurring during the collection of interactions
    /// in SharpCord. This error typically indicates an issue with handling
    /// or processing interactions collected through the interaction collector.
    /// </summary>
    [JsonPropertyName("InteractionCollectorError")]
    InteractionCollectorError,

    /// <summary>
    /// Represents an error that occurs when attempting to respond ephemerally
    /// to an interaction in SharpCord, but the response has already been sent
    /// or another error prevents the ephemeral reply process.
    /// </summary>
    [Obsolete]
    [JsonPropertyName("InteractionEphemeralReplied")]
    InteractionEphemeralReplied,

    /// <summary>
    /// Represents an error where an interaction has not been replied to within the required time frame.
    /// This error occurs when a response to an interaction is not sent before the predetermined timeout,
    /// potentially causing the action to fail or the interaction to expire.
    /// </summary>
    [JsonPropertyName("InteractionNotReplied")]
    InteractionNotReplied,

    /// <summary>
    /// Represents an error indicating the presence of an invalid or unsupported
    /// element in SharpCord. This error occurs when an operation encounters
    /// an element that does not meet the expected requirements or is not
    /// recognized by the system.
    /// </summary>
    [JsonPropertyName("InvalidElement")]
    InvalidElement,

    /// <summary>
    /// Represents an error that occurs when one or more gateway intents
    /// provided are invalid or not recognized in SharpCord. This can happen
    /// if the intents used are unsupported, not enabled, or improperly specified
    /// during connection or configuration with the gateway.
    /// </summary>
    [Obsolete] [JsonPropertyName("InvalidIntents")]
    InvalidIntents,

    /// <summary>
    /// Represents an error indicating that one or more necessary OAuth scopes
    /// are missing in the request within SharpCord. This error occurs when the required
    /// scopes for performing a particular operation are not granted or included
    /// in the authorization process.
    /// </summary>
    [JsonPropertyName("InvalidMissingScopes")]
    InvalidMissingScopes,

    /// <summary>
    /// Represents an error that occurs when attempting to use invalid OAuth2 scopes
    /// in combination with permission settings in SharpCord. This indicates that
    /// the specified scopes are not compatible with the requested permissions.
    /// </summary>
    [JsonPropertyName("InvalidScopesWithPermissions")]
    InvalidScopesWithPermissions,

    /// <summary>
    /// Represents an error in SharpCord where a provided type does not match the
    /// expected type or is considered invalid. This error typically occurs when
    /// an operation requires a specific type, and the provided input fails
    /// to meet the required type constraints or validity expectations.
    /// </summary>
    [JsonPropertyName("InvalidType")]
    InvalidType,

    /// <summary>
    /// Represents an error in SharpCord where a specified invite could not
    /// be found. This typically occurs when a provided invite code is invalid,
    /// expired, or does not exist.
    /// </summary>
    [JsonPropertyName("InviteNotFound")]
    InviteNotFound,

    /// <summary>
    /// Represents an error indicating that a required channel is missing
    /// in the provided invite options. This error occurs when attempting
    /// to create or manage an invite without specifying a valid channel.
    /// </summary>
    [JsonPropertyName("InviteOptionsMissingChannel")]
    InviteOptionsMissingChannel,

    /// <summary>
    /// Represents an error code indicating a failure to resolve an invite
    /// within SharpCord. This error occurs when the provided invite code
    /// is invalid, expired, or otherwise unable to be processed successfully.
    /// </summary>
    [JsonPropertyName("InviteResolveCode")]
    InviteResolveCode,

    /// <summary>
    /// Represents an error that occurs when an operation is attempted on
    /// a destroyed or disposed manager instance in SharpCord. This error
    /// typically indicates that the manager instance has been terminated
    /// and is no longer available for use.
    /// </summary>
    [Obsolete] 
    [JsonPropertyName("ManagerDestroyed")]
    ManagerDestroyed,

    /// <summary>
    /// Represents an error indicating an invalid nonce length provided during a member fetch operation in SharpCord.
    /// This error occurs when the nonce value used for the operation does not comply with the expected length requirements.
    /// </summary>
    [JsonPropertyName("MemberFetchNonceLength")]
    MemberFetchNonceLength,

    /// <summary>
    /// Represents an error related to bulk deletion of messages in SharpCord.
    /// This error occurs when an operation involving the removal of multiple
    /// messages encounters an issue, such as exceeding allowed limits or
    /// encountering inaccessible messages.
    /// </summary>
    [JsonPropertyName("MessageBulkDeleteType")]
    MessageBulkDeleteType,

    /// <summary>
    /// Represents an error related to the type of message content in SharpCord.
    /// This error occurs when the provided message content type is invalid, unsupported,
    /// or does not meet the required specifications for processing.
    /// </summary>
    [JsonPropertyName("MessageContentType")]
    MessageContentType,

    /// <summary>
    /// Represents an error in SharpCord where attempting to send a message to an
    /// existing thread fails. This may occur due to invalid permissions, missing
    /// access to the thread, or other related issues preventing the operation.
    /// </summary>
    [JsonPropertyName("MessageExistingThread")]
    MessageExistingThread,

    /// <summary>
    /// Indicates that a message nonce is required for the operation in SharpCord.
    /// This error occurs when a nonce, typically used for identifying or verifying
    /// the uniqueness of a message, is not provided during the execution of a
    /// message-related process.
    /// </summary>
    [JsonPropertyName("MessageNonceRequired")]
    MessageNonceRequired,

    /// <summary>
    /// Represents an error related to the message nonce type in SharpCord.
    /// This error occurs when the specified nonce type for a message does
    /// not meet the expected format or criteria during a message operation.
    /// </summary>
    [JsonPropertyName("MessageNonceType")]
    MessageNonceType,

    /// <summary>
    /// Represents an error related to the type of message reference in SharpCord.
    /// This error occurs when an issue is identified with the specified type
    /// of message reference, such as an invalid or incompatible reference type
    /// during operations involving messages.
    /// </summary>
    [JsonPropertyName("MessageReferenceType")]
    MessageReferenceType,

    /// <summary>
    /// Represents an error indicating that the parent entity for a message thread
    /// in SharpCord is invalid, missing, or not properly referenced. This error
    /// occurs when operations related to message threads require a valid parent,
    /// but it is not correctly provided or accessible.
    /// </summary>
    [JsonPropertyName("MessageThreadParent")]
    MessageThreadParent,

    /// <summary>
    /// Represents an error indicating the absence of the required permission to manage
    /// emojis and stickers in SharpCord. This error occurs when attempting to perform
    /// actions involving emojis or stickers without having the appropriate
    /// Manage Emojis and Stickers permission.
    /// </summary>
    [Obsolete] [JsonPropertyName("MissingManageEmojisAndStickersPermission")]
    MissingManageEmojisAndStickersPermission,

    /// <summary>
    /// Indicates that the required permission for managing guild expressions
    /// is missing in SharpCord. This error occurs when an operation involving
    /// the management of guild-specific expressions is attempted without the
    /// appropriate permissions granted.
    /// </summary>
    [JsonPropertyName("MissingManageGuildExpressionsPermission")]
    MissingManageGuildExpressionsPermission,

    /// <summary>
    /// Represents an error in SharpCord where a specific field is not found
    /// during a modal submit interaction process. This error is encountered
    /// when the expected field in the payload of the interaction is missing
    /// or inaccessible.
    /// </summary>
    [JsonPropertyName("ModalSubmitInteractionFieldNotFound")]
    ModalSubmitInteractionFieldNotFound,

    /// <summary>
    /// Represents an error related to the type of a field in a modal submit interaction
    /// within SharpCord. This error occurs when an invalid or unsupported field type
    /// is encountered during the processing of a modal submission.
    /// </summary>
    [JsonPropertyName("ModalSubmitInteractionFieldType")]
    ModalSubmitInteractionFieldType,

    /// <summary>
    /// Indicates that the specified sound is not a Guild Soundboard sound in SharpCord.
    /// This error occurs when an operation expects a sound from the Guild Soundboard,
    /// but a non-Soundboard sound or an unsupported type of sound is provided instead.
    /// </summary>
    [JsonPropertyName("NotGuildSoundboardSound")]
    NotGuildSoundboardSound,

    /// <summary>
    /// Represents an error where the specified sticker is not recognized as a guild sticker
    /// in SharpCord. This error occurs when an operation requiring a guild sticker is attempted
    /// on a non-guild sticker resource.
    /// </summary>
    [JsonPropertyName("NotGuildSticker")]
    NotGuildSticker,

    /// <summary>
    /// Represents an error code indicating that a requested feature or functionality
    /// is not implemented in SharpCord. This error typically occurs when an attempt
    /// is made to access a feature that has not yet been developed or is intentionally
    /// unimplemented.
    /// </summary>
    [JsonPropertyName("NotImplemented")]
    NotImplemented,

    /// <summary>
    /// Indicates that the specified poll has already expired in SharpCord.
    /// This error occurs when attempting to interact with or modify a poll
    /// that has already passed its expiration time.
    /// </summary>
    [JsonPropertyName("PollAlreadyExpired")]
    PollAlreadyExpired,

    /// <summary>
    /// Represents an error related to invalid or unsupported prune days type
    /// in SharpCord. This error occurs when the specified prune days type
    /// does not meet the required criteria or is not recognized for the
    /// intended operation.
    /// </summary>
    [JsonPropertyName("PruneDaysType")]
    PruneDaysType,

    /// <summary>
    /// Represents an error that occurs when resolving a user associated with a reaction
    /// in SharpCord. This may indicate an issue where the user's information could not
    /// be retrieved or resolved during operations involving message reactions.
    /// </summary>
    [JsonPropertyName("ReactionResolveUser")]
    ReactionResolveUser,

    /// <summary>
    /// Represents an error indicating an issue with the required resource type in SharpCord.
    /// This error occurs when the specified resource type is invalid, unavailable, or does
    /// not meet the necessary criteria for the requested operation.
    /// </summary>
    [JsonPropertyName("ReqResourceType")]
    ReqResourceType,

    /// <summary>
    /// Represents an error related to invalid or missing custom IDs for select menu components in SharpCord.
    /// This error occurs when the provided custom ID does not meet the required format or is unavailable
    /// during the execution of operations involving select menu interactions.
    /// </summary>
    [Obsolete]
    [JsonPropertyName("SelectMenuCustomId")]
    SelectMenuCustomId,

    /// <summary>
    /// Represents an error related to a missing or invalid placeholder
    /// value in a select menu within SharpCord. This error occurs when
    /// a required placeholder for a select menu is not provided or does
    /// not meet the expected format or constraints.
    /// </summary>
    [Obsolete]
    [JsonPropertyName("SelectMenuPlaceholder")]
    SelectMenuPlaceholder,

    /// <summary>
    /// Represents an error related to the description field in a select option
    /// within SharpCord. This error occurs when the provided description is
    /// invalid, exceeds the allowed length, or does not meet the required
    /// format constraints.
    /// </summary>
    [Obsolete]
    [JsonPropertyName("SelectOptionDescription")]
    SelectOptionDescription,

    /// <summary>
    /// Represents an error related to the label of a select option in SharpCord.
    /// This error typically occurs when a select option label is invalid, missing,
    /// or does not meet the necessary requirements for rendering or processing.
    /// </summary>
    [Obsolete]
    [JsonPropertyName("SelectOptionLabel")]
    SelectOptionLabel,

    /// <summary>
    /// Represents an error occurring when a select option value is invalid or improperly set
    /// in SharpCord. This error typically arises during operations involving
    /// dropdown menu interactions where the provided select option value does not
    /// meet the expected criteria or is missing.
    /// </summary>
    [Obsolete] 
    [JsonPropertyName("SelectOptionValue")]
    SelectOptionValue,

    /// <summary>
    /// Indicates that the sharding process has already been initiated in SharpCord.
    /// This error occurs when an attempt is made to spawn shards after they have
    /// already been initialized or started.
    /// </summary>
    [JsonPropertyName("ShardingAlreadySpawned")]
    ShardingAlreadySpawned,

    /// <summary>
    /// Represents an error indicating that a sharding process is already underway
    /// in SharpCord. This error occurs when an operation is attempted that conflicts
    /// with the currently active shard initialization or management process.
    /// </summary>
    [JsonPropertyName("ShardingInProcess")]
    ShardingInProcess,

    /// <summary>
    /// Indicates an invalid sharding configuration in SharpCord. This error occurs when
    /// the provided sharding setup does not meet the required criteria or contains
    /// invalid parameters, preventing proper functionality of shard management.
    /// </summary>
    [Obsolete] 
    [JsonPropertyName("ShardingInvalid")]
    ShardingInvalid,

    /// <summary>
    /// Represents an error occurring due to an invalid evaluation broadcast
    /// during a sharding operation in SharpCord. This error typically arises
    /// when an evaluation command is improperly transmitted or received
    /// across shards, leading to unexpected behavior or communication failure.
    /// </summary>
    [JsonPropertyName("ShardingInvalidEvalBroadcast")]
    ShardingInvalidEvalBroadcast,

    /// <summary>
    /// Represents an error indicating that no child shard exists within the
    /// sharding system in SharpCord. This occurs when an operation that
    /// requires the presence of one or more child shards is attempted, but
    /// none are found or initialized.
    /// </summary>
    [JsonPropertyName("ShardingNoChildExists")]
    ShardingNoChildExists,

    /// <summary>
    /// Represents an error where no shards are configured in SharpCord.
    /// This occurs when sharding is required but no shards have been specified
    /// or initialized for the application's operation.
    /// </summary>
    [JsonPropertyName("ShardingNoShards")]
    ShardingNoShards,

    /// <summary>
    /// Indicates that a sharding process already exists in SharpCord.
    /// This error occurs when an attempt is made to initialize or start
    /// another sharding process while one is already active or in progress.
    /// </summary>
    [JsonPropertyName("ShardingProcessExists")]
    ShardingProcessExists,

    /// <summary>
    /// Represents the error that occurs when a shard unexpectedly stops or fails to continue
    /// its operation after indicating readiness in SharpCord. This may be caused by unforeseen
    /// issues or instability during the sharding process.
    /// </summary>
    [JsonPropertyName("ShardingReadyDied")]
    ShardingReadyDied,

    /// <summary>
    /// Represents an error that occurs when a shard unexpectedly disconnects
    /// during the sharding ready process in SharpCord. This error typically
    /// signifies unexpected interruptions or issues in establishing or maintaining
    /// a stable connection for a shard.
    /// </summary>
    [JsonPropertyName("ShardingReadyDisconnected")]
    ShardingReadyDisconnected,

    /// <summary>
    /// Represents a timeout error during the sharding process in SharpCord.
    /// This error occurs when the initialization or readiness of one or more
    /// shards exceeds the allowed time limit, potentially due to network issues
    /// or delays in Discord's server response.
    /// </summary>
    [JsonPropertyName("ShardingReadyTimeout")]
    ShardingReadyTimeout,

    /// <summary>
    /// Represents an error indicating that sharding is required to proceed with the operation
    /// in SharpCord. This error typically occurs when a Discord bot requires sharding
    /// to manage its connections or data across multiple servers effectively.
    /// </summary>
    [Obsolete] [JsonPropertyName("ShardingRequired")]
    ShardingRequired,

    /// <summary>
    /// Represents an error related to an incorrect calculation or assignment of shards
    /// in SharpCord's sharding system. This error typically occurs when there is
    /// a mismatch or misconfiguration in the shard allocation process, which can lead
    /// to improper distribution of workloads across shards.
    /// </summary>
    [JsonPropertyName("ShardingShardMiscalculation")]
    ShardingShardMiscalculation,

    /// <summary>
    /// Represents an error where the specified shard cannot be found within the
    /// sharding system in SharpCord. This error typically occurs when attempting
    /// to reference or interact with a shard that does not exist or is not properly
    /// initialized in the current sharding configuration.
    /// </summary>
    [JsonPropertyName("ShardingShardNotFound")]
    ShardingShardNotFound,

    /// <summary>
    /// Represents an error indicating that a sharding worker already exists in SharpCord.
    /// This error is triggered when attempting to create or initialize a new sharding worker
    /// while another worker for the same shard is already active or initialized.
    /// </summary>
    [JsonPropertyName("ShardingWorkerExists")]
    ShardingWorkerExists,

    /// <summary>
    /// Represents an error indicating that the maximum allowable length
    /// for a split operation in SharpCord has been exceeded. This error
    /// occurs when the content being split exceeds the defined limit,
    /// potentially due to size constraints or configuration settings.
    /// </summary>
    [Obsolete] 
    [JsonPropertyName("SplitMaxLen")]
    SplitMaxLen,

    /// <summary>
    /// Represents an error in resolving a stage channel in SharpCord.
    /// This error typically occurs when there is a failure to retrieve
    /// or process a stage channel due to invalid input, missing identifiers,
    /// or insufficient permissions.
    /// </summary>
    [JsonPropertyName("StageChannelResolve")]
    StageChannelResolve,

    /// <summary>
    /// Represents an error code in SharpCord that indicates an issue encountered
    /// while processing or applying the sweep filter operation. This error typically
    /// occurs when the sweep filter's return operation fails, encounters unexpected
    /// input, or produces invalid output during execution.
    /// </summary>
    [JsonPropertyName("SweepFilterReturn")]
    SweepFilterReturn,

    /// <summary>
    /// Represents an error related to the thread invitable type configuration in SharpCord.
    /// This error occurs when there is an issue setting or retrieving the "invitable" property
    /// of a thread, which determines whether non-members can be invited to join the thread.
    /// </summary>
    [JsonPropertyName("ThreadInvitableType")]
    ThreadInvitableType,

    /// <summary>
    /// Represents an error indicating that the provided token is invalid in the context of SharpCord.
    /// This error occurs when the supplied token fails authentication or does not meet
    /// the required standards for authorization within the system.
    /// </summary>
    [JsonPropertyName("TokenInvalid")]
    TokenInvalid,

    /// <summary>
    /// Represents an error indicating that a required authorization token is missing
    /// in SharpCord. This occurs when an operation requires an authentication token
    /// that has not been supplied.
    /// </summary>
    [JsonPropertyName("TokenMissing")]
    TokenMissing,

    /// <summary>
    /// Represents an error where the user's banner was not fetched in SharpCord.
    /// This indicates that an attempt to retrieve the user's banner was unsuccessful
    /// or the banner data was not available during the operation.
    /// </summary>
    [Obsolete] 
    [JsonPropertyName("UserBannerNotFetched")]
    UserBannerNotFetched,

    /// <summary>
    /// Represents an error indicating that a user does not have a direct message (DM)
    /// channel available in SharpCord. This typically occurs when attempting to perform
    /// actions that require a DM channel, but the channel is unavailable or cannot be created.
    /// </summary>
    [JsonPropertyName("UserNoDMChannel")]
    UserNoDMChannel,

    /// <summary>
    /// Represents an error related to the vanity URL functionality in SharpCord.
    /// This error occurs when there is an issue retrieving, assigning,
    /// or interacting with the vanity URL configuration for a specific guild.
    /// <remarks>Not used anymore since the introduction of GUILD_WEB_PAGE_VANITY_URL feature</remarks>
    /// </summary>
    [Obsolete] 
    [JsonPropertyName("VanityURL")]
    VanityURL,

    /// <summary>
    /// Indicates an error where a voice channel is referenced but it is not a stage channel
    /// in SharpCord. This occurs when an operation explicitly requires a stage channel,
    /// but a regular voice channel is provided instead.
    /// </summary>
    [JsonPropertyName("VoiceNotStageChannel")]
    VoiceNotStageChannel,

    /// <summary>
    /// Represents an error indicating that the voice state type provided is invalid
    /// or not recognized in SharpCord. This error typically occurs when an unexpected
    /// or unsupported value is used for a voice state operation.
    /// </summary>
    [JsonPropertyName("VoiceStateInvalidType")]
    VoiceStateInvalidType,

    /// <summary>
    /// Represents an error that occurs when attempting to interact with or modify
    /// a voice state that does not belong to the current user in SharpCord.
    /// This error is triggered when an operation requires control over a voice state
    /// outside the user's ownership or authorization.
    /// </summary>
    [JsonPropertyName("VoiceStateNotOwn")] 
    VoiceStateNotOwn,

    /// <summary>
    /// Represents an error related to webhook application handling in SharpCord.
    /// This error is encountered when issues arise with the configuration,
    /// execution, or integration of webhook applications.
    /// </summary>
    [JsonPropertyName("WebhookApplication")]
    WebhookApplication,

    /// <summary>
    /// Represents an error related to webhook message handling in SharpCord. This error occurs
    /// when an issue arises while attempting to process, send, or interact with webhook messages,
    /// such as invalid parameters or messaging constraints.
    /// </summary>
    [JsonPropertyName("WebhookMessage")] 
    WebhookMessage,

    /// <summary>
    /// Represents an error that occurs when the required token for webhook operations
    /// in SharpCord is unavailable. This typically indicates that the token needed
    /// to authenticate and execute webhook-related actions is missing or cannot
    /// be accessed.
    /// </summary>
    [JsonPropertyName("WebhookTokenUnavailable")]
    WebhookTokenUnavailable,

    /// <summary>
    /// Represents an error indicating that the provided webhook URL is invalid
    /// in SharpCord. This may occur if the URL format is incorrect or does not
    /// meet the requirements for webhook operations.
    /// </summary>
    [JsonPropertyName("WebhookURLInvalid")]
    WebhookURLInvalid,

    /// <summary>
    /// Represents an error code indicating that a WebSocket close operation
    /// was requested. This may occur when the client or server is 
    /// intentionally closing a WebSocket connection as part of the connection
    /// lifecycle or due to specific application logic.
    /// </summary>
    [Obsolete] 
    [JsonPropertyName("WSCloseRequested")]
    WSCloseRequested,

    /// <summary>
    /// Indicates that a WebSocket connection already exists in SharpCord.
    /// This error is raised when an attempt is made to establish a new WebSocket
    /// connection while an existing connection is still active.
    /// </summary>
    [Obsolete] 
    [JsonPropertyName("WSConnectionExists")]
    WSConnectionExists,

    /// <summary>
    /// Indicates that the WebSocket connection is not open in SharpCord.
    /// This error occurs when an operation requiring an active WebSocket connection
    /// is attempted while the connection is closed or has not been established.
    /// </summary>
    [Obsolete] 
    [JsonPropertyName("WSNotOpen")]
    WSNotOpen
}