namespace CulinaryAnalytics.Commands.GetList
{
    public record GetDictionaryListsCommand() : IRequest<StandardReply<List<DictionaryList>>>;
    internal class GetDictionaryListsCommandHandler : IRequestHandler<GetDictionaryListsCommand, StandardReply<List<DictionaryList>>>
    {
        private readonly IDictionaryListService _dictionaryListService;
        private readonly ILogger _logger;

        public GetDictionaryListsCommandHandler(IDictionaryListService dictionaryListService, ILogger<GetDictionaryListsCommandHandler> logger)
        {
            _dictionaryListService = dictionaryListService;
            _logger = logger;
        }

        public Task<StandardReply<List<DictionaryList>>> Handle(GetDictionaryListsCommand request, CancellationToken cancellationToken)
        {
             return _dictionaryListService.GetAsync();
        }
    }
}
