namespace CulinaryAnalytics.Commands.GetList
{
    public record GetDictionaryListItemsCommand(int DictionaryListId) : IRequest<StandardReply<List<DictionaryListItem>>>;
    internal class GetDictionaryListItemsCommandHandler : IRequestHandler<GetDictionaryListItemsCommand, StandardReply<List<DictionaryListItem>>>
    {
        private readonly IDictionaryListItemService _dictionaryListItemService;
        private readonly ILogger _logger;

        public GetDictionaryListItemsCommandHandler(IDictionaryListItemService dictionaryListItemService, ILogger<GetDictionaryListItemsCommandHandler> logger)
        {
            _dictionaryListItemService = dictionaryListItemService;
            _logger = logger;
        }

        public Task<StandardReply<List<DictionaryListItem>>> Handle(GetDictionaryListItemsCommand request, CancellationToken cancellationToken)
        {
             return _dictionaryListItemService.GetAsync(x => x.DictionaryListId == request.DictionaryListId);
        }
    }
}
