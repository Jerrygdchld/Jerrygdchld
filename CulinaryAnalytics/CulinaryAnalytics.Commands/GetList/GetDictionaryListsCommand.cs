using System.Reflection;

namespace CulinaryAnalytics.Commands.GetList
{
    public record GetDictionaryListsCommand() : IRequest<IStandardReply<List<DictionaryList>>>;
    internal class GetDictionaryListsCommandHandler : IRequestHandler<GetDictionaryListsCommand, IStandardReply<List<DictionaryList>>>
    {
        private readonly IDictionaryListService _dictionaryListService;
        private readonly ILogger _logger;

        public GetDictionaryListsCommandHandler(IDictionaryListService dictionaryListService, ILogger<GetDictionaryListsCommandHandler> logger)
        {
            _dictionaryListService = dictionaryListService;
            _logger = logger;
        }

        public async Task<IStandardReply<List<DictionaryList>>> Handle(GetDictionaryListsCommand request, CancellationToken cancellationToken)
        {
            var sr = IStandardReply<List<DictionaryList>>.CreateStandardReply(true);
            try
            {
                sr.Response = await _dictionaryListService.GetAsync();
                sr.TotalRecords = await _dictionaryListService.GetTotalRecordsAsync();
            }
            catch (Exception ex)
            {
                sr.ProcessException(ex, null, _logger, MethodBase.GetCurrentMethod()?.Name ?? "", false);
            }
            return sr;
        }
    }
}
