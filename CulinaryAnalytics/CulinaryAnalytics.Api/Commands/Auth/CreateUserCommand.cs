using CulinaryAnalytics.Core;
using CulinaryAnalytics.Models.Auth;
using MediatR;

namespace CulinaryAnalytics.Api.Commands.Auth
{
    public record CreateUserCommand(ApplicationUser User, string Password, string[] Roles) : IRequest<IStandardReply<ApplicationUser>>;
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IStandardReply<ApplicationUser>>
    {
        private readonly ApplicationUserManager _userManager;
        private readonly ILogger _logger;

        public CreateUserCommandHandler(ApplicationUserManager userManager, ILogger<CreateUserCommandHandler> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IStandardReply<ApplicationUser>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var sr = IStandardReply<ApplicationUser>.CreateStandardReply(true);

            try
            {
                var ir = await _userManager.CreateAsync(
                        request.User,
                        request.Password
                    );

                if (ir.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(request?.User?.Email ?? string.Empty) ?? await _userManager.FindByNameAsync(request?.User?.UserName ?? string.Empty);
                    if (user != null)
                    {
                        await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("CompanyCode", user.CompanyCode));
                        await _userManager.SetLockoutEnabledAsync(user, false);
                        await _userManager.SetLockoutEndDateAsync(user, DateTime.Now.AddHours(-1));
                    }
                    if (user != null && request != null && request.Roles != null && request.Roles.Length > 0)
                    {
                        foreach (var r in request.Roles)
                        {
                            await _userManager.AddToRoleAsync(user, r);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sr.Success = false;
                sr.ProcessException(ex, request, _logger, "CreateUserCommand", false);
            }
            return sr;
        }
    }
}
