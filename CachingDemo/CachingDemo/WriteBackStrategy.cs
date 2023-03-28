using CachingDemo;
using System.Runtime.Caching;

public class WriteBackStrategy<TKey, T> : IWriteStrategy<TKey, T> where T : class
{
    public TKey Create(T item, ObjectCache cache, CacheItemPolicy policy, IRepository<TKey, T> repo)
    {
        var id = repo.Create(item);

        if (id == null)
        {
            throw new InvalidOperationException("Can't create item in data store.");
        }

        var cacheItem = new CacheItem(id.ToString(), item);
        cache.Add(cacheItem, policy);

        return id;
    }

    public bool Delete(TKey key, ObjectCache cache, IRepository<TKey, T> repo)
    {
        cache.Remove(key?.ToString());

        ThreadPool.QueueUserWorkItem(
            (state) =>
            {
                state = repo.Delete(key);
            });

        return true;
    }

    public bool Write(TKey key, T item, ObjectCache cache, CacheItemPolicy policy, IRepository<TKey, T> repo)
    {
        var cacheItem = new CacheItem(key?.ToString(), item);
        cache.Set(cacheItem, policy);

        ThreadPool.QueueUserWorkItem(
            (state) =>
            {
                state = repo.Update(key, item);
            });

        return true;
    }
}