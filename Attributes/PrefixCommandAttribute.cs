namespace SharpCord.Attributes;

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public class PrefixCommandAttribute : Attribute
{
    public string Name { get; }
    
    
    public PrefixCommandAttribute(string name) => Name = name;
}