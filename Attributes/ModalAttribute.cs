namespace SharpCord.Attributes;

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public sealed class ModalAttribute : Attribute
{
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    public ModalAttribute(string name) => Name = name;
}