using CulinaryAnalytics.Core;
using CulinaryAnalytics.Models.Entities;

namespace CulinaryAnalytics.Services.Implementations
{
    public abstract class BaseDataService<T> : IDataService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        protected BaseDataService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public Task<T?> CreateAsync(T entity)
        {
            return _repository.CreateAsync(entity);
        }

        public Task<T?> DeleteAsync(T entity)
        {
            return _repository.DeleteAsync(entity);
        }

        public Task<T?> GetAsync(long id)
        {
            return _repository.GetAsync(id);
        }

        public Task<List<T>> GetAsync()
        {
            return _repository.GetAsync();
        }

        public Task<List<T>> GetAsync(int page = 1, int size = 20)
        {
            return _repository.GetAsync(page, size);
        }

        public Task<List<T>> GetAsync(params Func<T, bool>[] filters)
        {
            return _repository.GetAsync(filters);
        }

        public Task<int> GetTotalRecordsAsync()
        {
            return _repository.GetTotalRecordsAsync();
        }

        public Task<T?> UpdateAsync(T entity)
        {
            return _repository.UpdateAsync(entity);
        }
    }
}
