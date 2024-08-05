using Microsoft.AspNetCore.Identity;

namespace CulinaryAnalytics.Models.Auth
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string CompanyCode { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
    }
}
