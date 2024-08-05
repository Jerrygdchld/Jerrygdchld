namespace CulinaryAnalytics.Models.Auth
{
    public class UserDto
    {
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string CompanyCode { get; set; } = string.Empty;
    }
}
