using SharpCord.Interfaces;
using SharpCord.Models;

namespace SharpCord.Builders;

/// <summary>
/// Represents a builder for creating Discord modals, enabling customization of
/// the modal's title, custom identifier, and contained interactive components.
/// </summary>
public class ModalBuilder
{
    internal readonly List<IComponent> _components = new();

    /// <summary>
    /// Gets or sets the title of the modal. This value represents the header text displayed at the top of the modal.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the unique identifier for the modal. This value is used to distinguish the modal in interaction events.
    /// </summary>
    public string CustomId { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="label"></param>
    /// <param name="customId"></param>
    /// <param name="style"></param>
    /// <param name="placeholder"></param>
    /// <param name="required"></param>
    /// <returns></returns>
    public ModalBuilder AddInput(string label, string customId, TextInputStyle style = TextInputStyle.Short, string? placeholder = null, bool required = true)
    {
        _components.Add(new TextInputComponent
        {
            Label = label,
            CustomId = customId,
            Style = style,
            Placeholder = placeholder,
            Required = required
        });

        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Modal Build() => new() { Components = _components };
}