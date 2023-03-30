namespace CachingDemo
{
    using System.Runtime.Caching;

    public enum WriteMode
    { WriteThrough = 0, WriteBack = 1 };

    public enum ReadMode
    { CacheAside = 0, ReadThrough = 1 };

    public class Cache<TKey, T> : IRepository<TKey, T> where T : class where TKey : notnull
    {
        private IRepository<TKey, T> _repo;
        private ObjectCache _cache = MemoryCache.Default;
        private CacheItemPolicy _defaultPolicy = new CacheItemPolicy();
        private IWriteStrategy<TKey, T> _writeStrategy;
        private IReadStrategy<TKey, T> _readStrategy;

        public Cache(IRepository<TKey, T> repo, ReadMode rMode = ReadMode.ReadThrough, WriteMode wMode = WriteMode.WriteThrough, string instanceName = "")
        {
            _repo = repo;

            switch (wMode)
            {
                case WriteMode.WriteThrough:
                    _writeStrategy = new WriteThroughStrategy<TKey, T>(); break;
                case WriteMode.WriteBack:
                    _writeStrategy = new WriteBackStrategy<TKey, T>(); break;
                default: throw new NotSupportedException("Unsupported write mode.");
            }

            switch (rMode)
            {
                case ReadMode.CacheAside:
                    _readStrategy = new CacheAsideStrategy<TKey, T>(); break;
                case ReadMode.ReadThrough:
                    _readStrategy = new ReadThroughStrategy<TKey, T>(); break;
                default: throw new NotSupportedException("Unsupported read mode.");
            }

            if (!string.IsNullOrEmpty(instanceName))
            {
                _cache = new MemoryCache(instanceName);
            }
        }

        public TKey Create(T item)
        {
            return _writeStrategy.Create(item, _cache, _defaultPolicy, _repo);
        }

        public bool Delete(TKey key)
        {
            return _writeStrategy.Delete(key, _cache, _repo);
        }

        public T Read(TKey key)
        {
            return _readStrategy.Read(key, _cache, _defaultPolicy, _repo);
        }

        public bool Update(TKey key, T item)
        {
            return _writeStrategy.Write(key, item, _cache, _defaultPolicy, _repo);
        }
    }
}