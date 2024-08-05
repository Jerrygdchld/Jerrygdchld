using CulinaryAnalytics.Commands.GetList;
using CulinaryAnalytics.Commands.Updates;
using CulinaryAnalytics.Models.Entities.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryAnalytics.Api.EndPoints
{
    public static class AdminEndPoints
    {
        public static void Map(WebApplication app)
        {
            app.MapGroup("/admin")
                .MapAdminApi()
                .WithOpenApi()
                .RequireAuthorization()
                .WithTags("Admin")
                ;
        }
        public static RouteGroupBuilder MapAdminApi(this RouteGroupBuilder group)
        {
            group.MapGet("/dictionaries", ([FromServices] IMediator mediator) =>
            {
                return mediator.Send(new GetDictionaryListsCommand());
            })
            .WithName("GetDictionaries");

            group.MapGet("/dictionaries/{id}/items", ([FromServices] IMediator mediator, int id) =>
            {
                return mediator.Send(new GetDictionaryListItemsCommand(id));
            })
            .WithName("GetDictionaryItems");

            group.MapPut("/dictionaries/{id}/items", ([FromServices] IMediator mediator,[FromBody] DictionaryListItem item) =>
            {
                return mediator.Send(new UpdateDictionaryListItemCommand(item));
            })
            .WithName("UpdateDictionaryItem");

            return group;
        }
    }
}
