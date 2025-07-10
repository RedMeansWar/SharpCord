using SharpCord.Interfaces;
using SharpCord.Models;

namespace SharpCord.Builders;

/// <summary>
/// Represents a builder for creating and managing Discord component elements such as buttons within an action row.
/// </summary>
public class ComponentBuilder
{
    internal readonly List<IComponent> _buttons = new();

    /// <summary>
    /// Adds a button component to the component builder.
    /// </summary>
    /// <param name="label">The text label displayed on the button.</param>
    /// <param name="customId">The unique identifier for the button, used for interaction callbacks.</param>
    /// <param name="style">The style of the button, defined by the ButtonStyle enumeration.</param>
    /// <param name="disabled">A boolean indicating whether the button should be disabled. Defaults to false.</param>
    /// <returns>Returns the current instance of the ComponentBuilder, allowing for method chaining.</returns>
    public ComponentBuilder AddButton(string label, string customId, ButtonStyle style = ButtonStyle.Primary, bool disabled = false)
    {
        _buttons.Add(new ButtonComponent
        {
            Label = label,
            CustomId = customId,
            Style = style,
            Disabled = disabled,
            Type = ComponentType.Button
        });

        return this;
    }

    /// <summary>
    /// Adds a button to the component builder with specified properties.
    /// </summary>
    /// <param name="label">The text displayed on the button.</param>
    /// <param name="customId">The unique identifier for the button, used for interaction handling.</param>
    /// <param name="buttonStyle">The visual style of the button selected from the ButtonStyle enumeration.</param>
    /// <param name="disabled">Determines whether the button is disabled. The default value is false.</param>
    /// <returns>Returns the current instance of ComponentBuilder to allow for method chaining.</returns>
    public ComponentBuilder AddButton(string label, string customId, int buttonStyle, bool disabled = false)
        => AddButton(label, customId, (ButtonStyle)buttonStyle, disabled);

    /// <summary>
    /// Constructs and returns an ActionRow containing all added components.
    /// </summary>
    /// <returns>Returns a new instance of the ActionRow class with the configured components.</returns>
    public ActionRow Build()
    {
        return new()
        {
            Type = ComponentType.ActionRow,
            Components = _buttons
        };
    }

    /// <summary>
    /// Constructs and returns a list containing a single ActionRow with the configured components.
    /// </summary>
    /// <returns>Returns a list of ActionRow instances with the added components.</returns>
    public List<ActionRow> BuildAsList() => [Build()];
}