using CulinaryAnalytics.Core;
using CulinaryAnalytics.Core.Implementations;
using CulinaryAnalytics.Models.Entities;
using Microsoft.Extensions.Logging;

namespace CulinaryAnalytics.Repositories
{
    public class GenericRepository<T>(CaappContext context, ILogger<GenericRepository<T>> logger) : IRepository<T> where T : BaseEntity
    {
        private readonly CaappContext _context = context;
        private readonly ILogger _logger = logger;

        public async Task<StandardReply<T>> CreateAsync(T entity)
        {
            var reply = new StandardReply<T>();
            try
            {
                entity.Deleted = false;
                entity.Active = true;
                entity.DateCreated = DateTime.Now.ToUniversalTime();

                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
                reply.Response = entity;
            }
            catch (Exception ex)
            {
                reply.ProcessException(ex, entity, _logger, $"CreateAsync {typeof(T).Name}", false);
            }

            return reply;
        }

        public async Task<StandardReply<T>> DeleteAsync(T entity)
        {
            var reply = new StandardReply<T>();
            try
            {
                var localEntity = (await GetAsync(entity.Id)).Response;
                if (localEntity != null)
                {
                    localEntity.Deleted = true;
                    localEntity.DateUpdated = DateTime.Now.ToUniversalTime();
                    _context.Entry(localEntity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                reply.Response = localEntity;
            }
            catch (Exception ex)
            {
                reply.ProcessException(ex, entity, _logger, $"DeleteAsync {typeof(T).Name}", false);
            }

            return reply;
        }

        public async Task<StandardReply<T>> GetAsync(long id)
        {
            var reply = new StandardReply<T>();
            try
            {
                reply.Response = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                reply.ProcessException(ex, new { TypeName = typeof(T).Name, Id = id }, _logger, $"GetAsync {typeof(T).Name}", false);
            }

            return reply;
        }

        public async Task<StandardReply<List<T>>> GetAsync(int page = 1, int size = 20)
        {
            var reply = new StandardReply<List<T>>();
            try
            {
                reply.TotalRecords = await _context.Set<T>().Where(x => !x.Deleted).CountAsync();
                reply.Response = await _context.Set<T>().Where(x => !x.Deleted).Skip((page - 1) * size).Take(size).ToListAsync();
            }
            catch (Exception ex)
            {
                reply.ProcessException(ex, new { TypeName = typeof(T).Name, Page = page, Size = size }, _logger, $"GetAsync {typeof(T).Name}", false);
            }

            return reply;
        }

        public Task<StandardReply<List<T>>> GetAsync(params Func<T, bool>[] filters)
        {
            var reply = new StandardReply<List<T>>();
            try
            {
                var query = _context.Set<T>().Where(x => !x.Deleted);
                foreach (var filter in filters)
                {
                    query = query.Where(filter).AsQueryable();
                }
                reply.TotalRecords = query.Count();
                reply.Response = query.ToList();
            }
            catch (Exception ex)
            {
                reply.ProcessException(ex, new { TypeName = typeof(T).Name }, _logger, $"GetAsync {typeof(T).Name}", false);
            }
            return Task.FromResult(reply);
        }

        public async Task<StandardReply<List<T>>> GetAsync()
        {
            var reply = new StandardReply<List<T>>();
            try
            {
                reply.TotalRecords = await _context.Set<T>().Where(x => !x.Deleted).CountAsync();
                reply.Response = await _context.Set<T>().Where(x => !x.Deleted).ToListAsync();
            }
            catch (Exception ex)
            {
                reply.ProcessException(ex, new { TypeName = typeof(T).Name }, _logger, $"GetAsync {typeof(T).Name}", false);
            }
            return reply;
        }

        public async Task<StandardReply<T>> UpdateAsync(T entity)
        {
            var reply = new StandardReply<T>();
            try
            {
                entity.DateUpdated = DateTime.Now.ToUniversalTime();
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                reply.Response = entity;
            }
            catch (Exception ex)
            {
                reply.ProcessException(ex, entity, _logger, $"CreateAsync {typeof(T).Name}", false);
            }

            return reply;
        }
    }
}
