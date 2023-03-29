namespace CachingDemo
{
    using System.Runtime.Caching;

    public class ReadThroughStrategy<TKey, T> : IReadStrategy<TKey, T> where T : class
    {
        public T Read(TKey key, ObjectCache cache, CacheItemPolicy policy, IRepository<TKey, T> repo)
        {
            object item = cache.Get(key.ToString());

            if (item == null)
            {
                item = repo.Read(key);
                if (item != null)
                {
                    var cacheItem = new CacheItem(key?.ToString(), item);
                    cache.Add(cacheItem, policy);
                }
            }

            return (T)item;
        }
    }
}