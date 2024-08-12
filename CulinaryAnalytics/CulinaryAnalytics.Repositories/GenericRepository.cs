using CulinaryAnalytics.Core;
using CulinaryAnalytics.Models.Entities;
using Microsoft.Extensions.Logging;

namespace CulinaryAnalytics.Repositories
{
    public class GenericRepository<T>(CaappContext context, ILogger<GenericRepository<T>> logger) : IRepository<T> where T : BaseEntity
    {
        private readonly CaappContext _context = context;
        private readonly ILogger _logger = logger;

        public async Task<T?> CreateAsync(T entity)
        {
            entity.Deleted = false;
            entity.Active = true;
            entity.DateCreated = DateTime.Now.ToUniversalTime();

            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T?> DeleteAsync(T entity)
        {
            var localEntity = (await GetAsync(entity.Id));
            if (localEntity != null)
            {
                localEntity.Deleted = true;
                localEntity.DateUpdated = DateTime.Now.ToUniversalTime();
                _context.Entry(localEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return localEntity ?? entity;
        }

        public Task<T?> GetAsync(long id)
        {
            return _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<T>> GetAsync(int page = 1, int size = 20)
        {
            return _context.Set<T>().Where(x => !x.Deleted).Skip((page - 1) * size).Take(size).ToListAsync();
        }

        public Task<List<T>> GetAsync(params Func<T, bool>[] filters)
        {
            var query = _context.Set<T>().Where(x => !x.Deleted);
            foreach (var filter in filters)
            {
                query = query.Where(filter).AsQueryable();
            }
            return query.ToListAsync();
        }

        public Task<List<T>> GetAsync()
        {
            return _context.Set<T>().Where(x => !x.Deleted).ToListAsync();
        }

        public Task<int> GetTotalRecordsAsync()
        {
            return _context.Set<T>().CountAsync();
        }

        public async Task<T?> UpdateAsync(T entity)
        {
            entity.DateUpdated = DateTime.Now.ToUniversalTime();
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
