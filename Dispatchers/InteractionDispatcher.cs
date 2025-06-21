using Microsoft.VisualBasic;
using SharpCord.Models;

namespace SharpCord.Dispatchers;

public class InteractionDispatcher
{
    internal readonly Dictionary<string, Func<Interaction, Task>> _handlers = new();

    public void Register(string name, Func<Interaction, Task> handler) => _handlers[name] = handler;
    
    public async Task HandleInteractionAsync(BaseInteraction interaction)
    {
    }
}