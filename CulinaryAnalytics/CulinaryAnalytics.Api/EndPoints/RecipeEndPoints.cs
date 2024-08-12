using CulinaryAnalytics.Commands.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryAnalytics.Api.EndPoints
{
    public static class RecipeEndPoints
    {
        public static void Map(WebApplication app)
        {
            app.MapGroup("/recipe")
                .MapRecipeApi()
                .WithOpenApi()
                .RequireAuthorization()
                .WithTags("Recipe")
                ;
        }
        public static RouteGroupBuilder MapRecipeApi(this RouteGroupBuilder group)
        {
            group.MapGet("/all", ([FromServices] IMediator mediator) =>
            {
                return mediator.Send(new GetCompanyRecipesCommand("abcde"));
            })
            .WithName("GetRecipes");

            return group;
        }
    }
}
