namespace SharpCord.Models;

/// <summary>
/// Represents predefined keyword presets used in auto-moderation rules.
/// </summary>
public enum AutoModerationRuleKeywordPresetType
{
    /// <summary>
    /// The keyword preset type used for detecting profane or inappropriate language.
    /// </summary>
    Profanity = 1,

    /// <summary>
    /// The keyword preset type used for detecting sexually explicit or inappropriate content.
    /// </summary>
    SexualContent = 2,

    /// <summary>
    /// The keyword preset type used for detecting slurs or offensive language targeting specific groups or individuals.
    /// </summary>
    Slurs = 3
}