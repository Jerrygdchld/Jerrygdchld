using System.Reflection;

namespace CulinaryAnalytics.Commands.GetList
{
    public record GetDictionaryListItemsCommand(int DictionaryListId) : IRequest<IStandardReply<List<DictionaryListItem>>>;
    internal class GetDictionaryListItemsCommandHandler : IRequestHandler<GetDictionaryListItemsCommand, IStandardReply<List<DictionaryListItem>>>
    {
        private readonly IDictionaryListItemService _dictionaryListItemService;
        private readonly ILogger _logger;

        public GetDictionaryListItemsCommandHandler(IDictionaryListItemService dictionaryListItemService, ILogger<GetDictionaryListItemsCommandHandler> logger)
        {
            _dictionaryListItemService = dictionaryListItemService;
            _logger = logger;
        }

        public async Task<IStandardReply<List<DictionaryListItem>>> Handle(GetDictionaryListItemsCommand request, CancellationToken cancellationToken)
        {
            var sr = IStandardReply<List<DictionaryListItem>>.CreateStandardReply(true);
            try
            {
                sr.Response = await _dictionaryListItemService.GetAsync(x => x.DictionaryListId == request.DictionaryListId);
                sr.TotalRecords = await _dictionaryListItemService.GetTotalRecordsAsync();
            }
            catch (Exception ex)
            {
                sr.ProcessException(ex, null, _logger, MethodBase.GetCurrentMethod()?.Name ?? "", false);
            }
            return sr;
        }
    }
}
