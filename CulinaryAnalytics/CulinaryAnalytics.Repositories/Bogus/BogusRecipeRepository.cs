using CulinaryAnalytics.Core;
using CulinaryAnalytics.Models.Entities.StoreFront;
using Microsoft.Extensions.Caching.Memory;

namespace CulinaryAnalytics.Repositories.Bogus
{
    public class BogusRecipeRepository : IRepository<Recipe>
    {
        private readonly IMemoryCache _cache;
        private readonly ICollection<Recipe>? _recipes;

        public BogusRecipeRepository(IMemoryCache cache)
        {
            _cache = cache;
            _recipes = _cache.Get<List<Recipe>>("recipes");
        }

        public Task<Recipe?> CreateAsync(Recipe entity)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe?> DeleteAsync(Recipe entity)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe?> GetAsync(long id)
        {
            return Task.FromResult(_recipes?.FirstOrDefault(x => x.Id == id));
        }

        public Task<List<Recipe>> GetAsync()
        {
            return Task.FromResult(_recipes?.ToList() ?? []);
        }

        public Task<List<Recipe>> GetAsync(int page = 1, int size = 20)
        {
            return Task.FromResult(_recipes?.Take(size).Skip((page - 1) * size).ToList() ?? []);
        }

        public Task<List<Recipe>> GetAsync(params Func<Recipe, bool>[] filters)
        {
            var query = _recipes?.Where(x => !x.Deleted);
            foreach (var filter in filters)
            {
                query = query?.Where(filter).AsQueryable();
            }
            return Task.FromResult(query?.ToList() ?? []);
        }
        public Task<int> GetTotalRecordsAsync()
        {
            return Task.FromResult(_recipes?.Count ?? 0);
        }

        public Task<Recipe?> UpdateAsync(Recipe entity)
        {
            throw new NotImplementedException();
        }
    }
}
