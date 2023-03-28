using CachingDemo;
using System.Runtime.Caching;

public interface IReadStrategy<TKey, T> where T : class
{
    T Read(TKey key, ObjectCache cache, CacheItemPolicy policy, IRepository<TKey, T> repo);
}
