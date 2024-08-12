using System.Reflection;

namespace CulinaryAnalytics.Commands.Updates
{
    public record UpdateDictionaryListItemCommand(DictionaryListItem Item) : IRequest<IStandardReply<DictionaryListItem>>;
    internal class UpdateDictionaryListItemCommandHandler : IRequestHandler<UpdateDictionaryListItemCommand, IStandardReply<DictionaryListItem>>
    {
        private readonly IDictionaryListItemService _dictionaryListItemService;
        private readonly ILogger _logger;

        public UpdateDictionaryListItemCommandHandler(IDictionaryListItemService dictionaryListItemService, ILogger<ValueTask> logger)
        {
            _dictionaryListItemService = dictionaryListItemService;
            _logger = logger;
        }

        public async Task<IStandardReply<DictionaryListItem>> Handle(UpdateDictionaryListItemCommand request, CancellationToken cancellationToken)
        {
            var sr = IStandardReply<DictionaryListItem>.CreateStandardReply(true);
            try
            {
                sr.Response = await _dictionaryListItemService.UpdateAsync(request.Item);
            }
            catch (Exception ex)
            {
                sr.ProcessException(ex, request.Item, _logger, MethodBase.GetCurrentMethod()?.Name ?? "", false);
            }
            return sr;
        }
    }
}
