using CulinaryAnalytics.Core;
using CulinaryAnalytics.Models.Entities.Common;

namespace CulinaryAnalytics.Services.Implementations
{
    internal class DictionaryListService : BaseDataService<DictionaryList>, IDictionaryListService
    {
        private readonly IRepository<DictionaryList> _repository;

        public DictionaryListService(IRepository<DictionaryList> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
