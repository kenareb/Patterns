namespace CachingDemo
{
    public class DataStore<TKey, T> : IRepository<TKey, T> where T : class
    {
        public DataStore()
        { }

        public TKey Create(T item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TKey key)
        {
            throw new NotImplementedException();
        }

        public T Read(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Update(TKey key, T item)
        {
            throw new NotImplementedException();
        }
    }
}