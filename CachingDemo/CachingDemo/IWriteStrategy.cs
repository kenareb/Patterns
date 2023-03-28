using CachingDemo;
using System.Runtime.Caching;

public interface IWriteStrategy<TKey, T> where T : class
{
    bool Write(TKey key, T item, ObjectCache cache, CacheItemPolicy policy, IRepository<TKey, T> repo);

    TKey Create(T item, ObjectCache cache, CacheItemPolicy policy, IRepository<TKey, T> repo);

    bool Delete(TKey key, ObjectCache cache, IRepository<TKey, T> repo);
}