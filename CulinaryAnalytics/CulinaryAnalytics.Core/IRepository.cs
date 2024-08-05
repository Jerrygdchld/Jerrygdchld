namespace CulinaryAnalytics.Core
{
    public interface IRepository<T>
    {
        Task<StandardReply<T>> CreateAsync(T entity);
        Task<StandardReply<T>> DeleteAsync(T entity);
        Task<StandardReply<T>> UpdateAsync(T entity);
        Task<StandardReply<T>> GetAsync(long id);
        Task<StandardReply<List<T>>> GetAsync();
        Task<StandardReply<List<T>>> GetAsync(int page = 1, int size = 20);
        Task<StandardReply<List<T>>> GetAsync(params Func<T, bool>[] filters);
    }
}
