using CulinaryAnalytics.Core;
using CulinaryAnalytics.Models.Entities.Common;

namespace CulinaryAnalytics.Services.Implementations
{
    public class DictionaryListItemService : BaseDataService<DictionaryListItem>, IDictionaryListItemService
    {
        private readonly IRepository<DictionaryListItem> _repository;

        public DictionaryListItemService(IRepository<DictionaryListItem> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
