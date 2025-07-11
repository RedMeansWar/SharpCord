using SharpCord.Types;

namespace SharpCord.Interfaces;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ICache<T>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    T? Get(Snowflake id);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    void Set(Snowflake id, T value);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    bool Remove(Snowflake id);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    bool Contains(Snowflake id);
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<T> GetAll();
    
    /// <summary>
    /// 
    /// </summary>
    void Clear();
}
