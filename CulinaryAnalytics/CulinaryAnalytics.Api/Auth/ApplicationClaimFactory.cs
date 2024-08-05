using CulinaryAnalytics.Models.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CulinaryAnalytics.Api.Auth
{
    public class ApplicationClaimFactory : IUserClaimsPrincipalFactory<ApplicationUser>
    {
        public Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var cp = new ClaimsPrincipal(
                                            new ClaimsIdentity(new[]
                                            {
                                                new Claim(ClaimTypes.Email, user?.Email ?? string.Empty),
                                                new Claim(ClaimTypes.GivenName, user?.FirstName ?? string.Empty),
                                                new Claim(ClaimTypes.Surname, user?.LastName ?? string.Empty),
                                                new Claim("CompanyCode", user?.CompanyCode ?? string.Empty),
                                                new Claim("IconUrl", user?.IconUrl ?? string.Empty)
                                            }, CookieAuthenticationDefaults.AuthenticationScheme)
                                        );
            return Task.FromResult(cp);
        }
    }
}
