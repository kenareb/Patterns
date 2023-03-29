namespace CachingDemo
{
    public interface IRepository<TKey, T> where T : class
    {
        TKey Create(T item);

        T Read(TKey key);

        bool Update(TKey key, T item);

        bool Delete(TKey key);
    }
}