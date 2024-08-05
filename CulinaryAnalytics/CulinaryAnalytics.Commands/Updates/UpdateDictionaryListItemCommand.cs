
namespace CulinaryAnalytics.Commands.Updates
{
    public record UpdateDictionaryListItemCommand(DictionaryListItem Item) : IRequest<StandardReply<DictionaryListItem>>;
    internal class UpdateDictionaryListItemCommandHandler : IRequestHandler<UpdateDictionaryListItemCommand, StandardReply<DictionaryListItem>>
    {
        private readonly IDictionaryListItemService _dictionaryListItemService;

        public UpdateDictionaryListItemCommandHandler(IDictionaryListItemService dictionaryListItemService)
        {
            _dictionaryListItemService = dictionaryListItemService;
        }

        public Task<StandardReply<DictionaryListItem>> Handle(UpdateDictionaryListItemCommand request, CancellationToken cancellationToken)
        {
            return _dictionaryListItemService.UpdateAsync(request.Item);
        }
    }
}
