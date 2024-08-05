using caapp.www.Server.Commands;
using CulinaryAnalytics.Api.Commands.Auth;
using CulinaryAnalytics.Api.Commands.UserOptions;
using CulinaryAnalytics.Models.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CulinaryAnalytics.Api.EndPoints
{
    public static class UserEndPoints
    {
        public static void Map(WebApplication app)
        {
            app.MapGroup("/user")
                .MapUsersApi()
                .WithOpenApi()
                .RequireAuthorization()
                .WithTags("Public")
                ;
        }
        public static RouteGroupBuilder MapUsersApi(this RouteGroupBuilder group)
        {
            group.MapPost("/create", ([FromServices] IMediator mediator, [FromBody] NewUserDto userInfo) =>
            {
                var newUser = new ApplicationUser
                {
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    CompanyCode = userInfo.CompanyCode,
                    UserName = userInfo.UserName,
                    Email = userInfo.Email,
                    LockoutEnabled = false,
                    EmailConfirmed = true,
                    PhoneNumber = userInfo.PhoneNumber,
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false
                };

                return mediator.Send(new CreateUserCommand(newUser, userInfo.Password, userInfo.Roles));
            })
            .WithName("CreateUser");

            group.MapGet("/menu", ([FromServices] IMediator mediator) =>
            {
                return mediator.Send(new GetLeftMenuOptionsCommand());
            })
            .WithName("GetLeftMenu");

            group.MapGet("/list", ([FromServices] IMediator mediator) =>
            {
                return mediator.Send(new GetUserListCommand());
            })
            .WithName("UserList");

            group.MapGet("/current", ([FromServices] IMediator mediator, ClaimsPrincipal user) =>
            {
                return mediator.Send(new GetUserDtoFromClaimCommand(user));
            })
            .WithName("UserCurrent");

            return group;
        }
    }
}
