using CachingDemo;
using System.Runtime.Caching;

public class WriteThroughStrategy<TKey, T> : IWriteStrategy<TKey, T> where T : class
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
        var success = repo.Delete(key);
        cache.Remove(key?.ToString());

        return success;
    }

    public bool Write(TKey key, T item, ObjectCache cache, CacheItemPolicy policy, IRepository<TKey, T> repo)
    {
        var success = repo.Update(key, item);
        if (!success)
        {
            throw new InvalidOperationException("Writing item to reposiory failed.");
        }

        var cacheItem = new CacheItem(key?.ToString(), item);
        cache.Set(cacheItem, policy);

        return true;
    }
}