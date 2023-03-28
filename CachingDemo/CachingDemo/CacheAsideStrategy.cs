using System.Runtime.Caching;

namespace CachingDemo
{
    public class CacheAsideStrategy<TKey, T> : IReadStrategy<TKey, T> where T : class
    {
        public T Read(TKey key, ObjectCache cache, CacheItemPolicy policy, IRepository<TKey, T> repo)
        {
            object item = cache.Get(key.ToString());

            return (T)item;
        }
    }
}