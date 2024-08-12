using CulinaryAnalytics.Models.Entities.StoreFront;
using System.Reflection;

namespace CulinaryAnalytics.Commands.GetList
{
    public record GetCompanyRecipesCommand(string CompanyCode) : IRequest<IStandardReply<List<Recipe>>>;
    internal class GetCompanyRecipesCommandHandler : IRequestHandler<GetCompanyRecipesCommand, IStandardReply<List<Recipe>>>
    {
        private readonly IRecipeService _recipeService;
        private readonly ILogger _logger;

        public GetCompanyRecipesCommandHandler(IRecipeService recipeService, ILogger<GetCompanyRecipesCommandHandler> logger)
        {
            _recipeService = recipeService;
            _logger = logger;
        }

        public async Task<IStandardReply<List<Recipe>>> Handle(GetCompanyRecipesCommand request, CancellationToken cancellationToken)
        {
            var sr = IStandardReply<List<Recipe>>.CreateStandardReply(true);
            try
            {
                sr.Response = await _recipeService.GetAsync();
                sr.TotalRecords = await _recipeService.GetTotalRecordsAsync();
            }
            catch (Exception ex)
            {
                sr.ProcessException(ex, null, _logger, MethodBase.GetCurrentMethod()?.Name ?? "", false);
            }
            return sr;
        }
    }
}
