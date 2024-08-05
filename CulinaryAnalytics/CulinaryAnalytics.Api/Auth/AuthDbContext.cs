using CulinaryAnalytics.Models.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CulinaryAnalytics.Api.Auth
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("Auth");
            builder.Entity<ApplicationRole>((e) =>
            {
                e.HasData(new List<ApplicationRole> {
                    new() { Id = 1, Name = "Super Admin", NormalizedName = "SUPERADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() },
                    new() { Id = 2, Name = "User Admin", NormalizedName = "USERADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() },
                    new() { Id = 3, Name = "Company Admin", NormalizedName = "COMPANYADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() },
                    new() { Id = 4, Name = "Super User", NormalizedName = "SUPERUSER", ConcurrencyStamp = Guid.NewGuid().ToString() },
                    new() { Id = 5, Name = "User", NormalizedName = "USER", ConcurrencyStamp = Guid.NewGuid().ToString() }
                });
            });
            builder.Entity<ApplicationUser>((e) =>
            {
                e.Property(e => e.FirstName).HasMaxLength(250);
                e.Property(e => e.LastName).HasMaxLength(250);
                e.Property(e => e.CompanyCode).HasMaxLength(20);
            });
            base.OnModelCreating(builder);
        }
    }
}
