using CulinaryAnalytics.Core;
using CulinaryAnalytics.Core.Implementations;
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

        public Task<StandardReply<T>> CreateAsync(T entity)
        {
            return _repository.CreateAsync(entity);
        }

        public Task<StandardReply<T>> DeleteAsync(T entity)
        {
            return _repository.DeleteAsync(entity);
        }

        public Task<StandardReply<T>> GetAsync(long id)
        {
            return _repository.GetAsync(id);
        }

        public Task<StandardReply<List<T>>> GetAsync()
        {
            return _repository.GetAsync();
        }

        public Task<StandardReply<List<T>>> GetAsync(int page = 1, int size = 20)
        {
            return _repository.GetAsync(page, size);
        }

        public Task<StandardReply<List<T>>> GetAsync(params Func<T, bool>[] filters)
        {
            return _repository.GetAsync(filters);
        }

        public Task<StandardReply<T>> UpdateAsync(T entity)
        {
            return _repository.UpdateAsync(entity);
        }
    }
}
