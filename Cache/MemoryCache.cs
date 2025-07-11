using SharpCord.Interfaces;
using SharpCord.Types;

namespace SharpCord.Cache;

public class MemoryCache<T> : ICache<T>
{
    internal readonly Dictionary<Snowflake, T> _cache = new();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public T? Get(Snowflake id) => _cache.TryGetValue(id, out var val) ? val : default;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    public void Set(Snowflake id, T value) => _cache[id] = value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Remove(Snowflake id) => _cache.Remove(id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Contains(Snowflake id) => _cache.ContainsKey(id);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IReadOnlyCollection<T> GetAll() => _cache.Values;

    /// <summary>
    /// 
    /// </summary>
    public void Clear() => _cache.Clear();
}