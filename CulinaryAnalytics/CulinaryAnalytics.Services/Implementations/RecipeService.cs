using CulinaryAnalytics.Core;
using CulinaryAnalytics.Models.Entities.StoreFront;

namespace CulinaryAnalytics.Services.Implementations
{
    public class RecipeService : BaseDataService<Recipe>, IRecipeService
    {
        private readonly IRepository<Recipe> _repository;

        public RecipeService(IRepository<Recipe> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
