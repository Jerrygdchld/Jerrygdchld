using CulinaryAnalytics.Core;
using CulinaryAnalytics.Models.Auth;
using MediatR;
using System.Security.Claims;

namespace CulinaryAnalytics.Api.Commands.UserOptions
{
    public record GetUserDtoFromClaimCommand(ClaimsPrincipal Claim) : IRequest<IStandardReply<UserDto>>;
    public class GetUserDtoFromClaimCommandHandler(ILogger<GetUserDtoFromClaimCommandHandler> logger) : IRequestHandler<GetUserDtoFromClaimCommand, IStandardReply<UserDto>>
    {
        private readonly ILogger _logger = logger;

        public Task<IStandardReply<UserDto>> Handle(GetUserDtoFromClaimCommand request, CancellationToken cancellationToken)
        {
            var sr = IStandardReply<UserDto>.CreateStandardReply(true);
            try
            {
                var userDto = new UserDto
                {
                    Email = request.Claim.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? "",
                    FirstName = request.Claim.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value ?? "",
                    LastName = request.Claim.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value ?? "",
                    ImageUrl = request.Claim.Claims.FirstOrDefault(c => c.Type == "IconUrl")?.Value ?? "",
                    CompanyCode = request.Claim.Claims.FirstOrDefault(c => c.Type == "CompanyCode")?.Value ?? ""
                };
                sr.Response = userDto;
            }
            catch (Exception ex)
            {
                sr.ProcessException(ex, request, _logger, "GetUserDtoFromClaimCommand", false);
            }
            return Task.FromResult(sr);
        }
    }
}
