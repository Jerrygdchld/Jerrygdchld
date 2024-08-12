namespace CulinaryAnalytics.Core
{
    public interface IRepository<T>
    {
        Task<T?> CreateAsync(T entity);
        Task<T?> DeleteAsync(T entity);
        Task<T?> UpdateAsync(T entity);
        Task<T?> GetAsync(long id);
        Task<List<T>> GetAsync();
        Task<List<T>> GetAsync(int page = 1, int size = 20);
        Task<List<T>> GetAsync(params Func<T, bool>[] filters);
        Task<int> GetTotalRecordsAsync();
    }
}
