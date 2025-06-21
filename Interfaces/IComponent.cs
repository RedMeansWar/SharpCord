using SharpCord.Models;

namespace SharpCord.Interfaces;

/// <summary>
/// Represents a component with its associated type.
/// </summary>
public interface IComponent
{
    ComponentType Type { get; set; }
}