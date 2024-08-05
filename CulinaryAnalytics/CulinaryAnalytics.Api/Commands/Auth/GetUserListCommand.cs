using CulinaryAnalytics.Core;
using CulinaryAnalytics.Models.Auth;
using MediatR;

namespace CulinaryAnalytics.Api.Commands.Auth
{
    public record GetUserListCommand() : IRequest<IStandardReply<IEnumerable<ApplicationUser>>>;
    public class GetUserListCommandHandler : IRequestHandler<GetUserListCommand, IStandardReply<IEnumerable<ApplicationUser>>>
    {
        private readonly ApplicationUserManager _userManager;
        private readonly ILogger _logger;

        public GetUserListCommandHandler(ApplicationUserManager userManager, ILogger<GetUserListCommandHandler> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public Task<IStandardReply<IEnumerable<ApplicationUser>>> Handle(GetUserListCommand request, CancellationToken cancellationToken)
        {
            var sr = IStandardReply<IEnumerable<ApplicationUser>>.CreateStandardReply(true);
            try
            {
                sr.Response = _userManager.Users.ToList();
                sr.TotalRecords = _userManager.Users.Count();
                foreach (var item in sr.Response)
                {
                    item.PasswordHash = null;
                    item.SecurityStamp = null;
                }
            }
            catch (Exception ex)
            {
                sr.Success = false;
                sr.ProcessException(ex, request, _logger, "GetUserListCommand", false);
            }
            return Task.FromResult(sr);
        }
    }
}
