using CulinaryAnalytics.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CulinaryAnalytics.Api.Auth
{
    public class ApplicationUserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>
    {
        private readonly AuthDbContext _dbContext;
        private readonly ILogger _logger;

        public ApplicationUserStore(AuthDbContext dbContext, ILogger<ApplicationUserStore> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            try
            {
                if (_dbContext.Users.Any(u => u.UserName == user.UserName || u.Email == user.Email))
                {
                    _dbContext.Update(user);
                }
                else
                {
                    _dbContext.Add(user);
                }
                await _dbContext.SaveChangesAsync(cancellationToken);
                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                var identityError = new IdentityError { Code = ex.HelpLink ?? string.Empty, Description = ex.Message };
                return await Task.FromResult(IdentityResult.Failed(identityError));
            }
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            try
            {
                _dbContext.Remove(user);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                var identityError = new IdentityError { Code = ex.HelpLink ?? string.Empty, Description = ex.Message };
                return IdentityResult.Failed(identityError);
            }
        }

        public void Dispose()
        {
        }

        public Task<ApplicationUser?> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            if (int.TryParse(userId, out var id))
            {
                return _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            }
            return Task.FromResult((ApplicationUser?)null);
        }

        public Task<ApplicationUser?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return _dbContext.Users.FirstOrDefaultAsync(x =>
                                                        (x.UserName != null && x.UserName.Equals(normalizedUserName))
                                                        || (x.NormalizedUserName != null && x.NormalizedUserName.Equals(normalizedUserName))
                                                        || (x.Email != null && x.Email.Equals(normalizedUserName))
                                                        || (x.NormalizedEmail != null && x.NormalizedEmail.Equals(normalizedUserName))
                                                        , cancellationToken);
        }

        public async Task<string?> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return user.NormalizedUserName ?? user.UserName?.ToUpper() ?? (await GetUserAsync(user))?.NormalizedUserName;
        }

        public async Task<string?> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return user.PasswordHash ?? (await GetUserAsync(user))?.PasswordHash;
        }

        public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public async Task<string?> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return user.UserName ?? (await GetUserAsync(user))?.UserName ?? user.Email;
        }

        public async Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return !string.IsNullOrWhiteSpace(user.PasswordHash) && !string.IsNullOrWhiteSpace((await GetUserAsync(user))?.PasswordHash);
        }

        public Task SetNormalizedUserNameAsync(ApplicationUser user, string? normalizedName, CancellationToken cancellationToken)
        {
            if (normalizedName == null || user.NormalizedUserName == normalizedName)
            {
                return Task.CompletedTask;
            }
            user.NormalizedUserName = normalizedName?.ToUpper();
            _dbContext.Update(user);
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string? passwordHash, CancellationToken cancellationToken)
        {
            if (passwordHash == null || user.PasswordHash == passwordHash)
            {
                return Task.CompletedTask;
            }
            user.PasswordHash = passwordHash;
            _dbContext.Update(user);
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task SetUserNameAsync(ApplicationUser user, string? userName, CancellationToken cancellationToken)
        {
            if (userName == null || user.UserName == userName)
            {
                return Task.CompletedTask;
            }
            user.UserName = userName;
            _dbContext.Update(user);
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            try
            {
                _dbContext.Update(user);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                var identityError = new IdentityError { Code = ex.HelpLink ?? string.Empty, Description = ex.Message };
                return await Task.FromResult(IdentityResult.Failed(identityError));
            }
        }

        private Task<ApplicationUser?> GetUserAsync(ApplicationUser user)
        {
            return _dbContext.Users.FirstOrDefaultAsync(u =>
                                                        u.Id == user.Id
                                                        || u.UserName == user.UserName
                                                        || u.Email == user.Email
                                                        || u.PhoneNumber == user.PhoneNumber
            );
        }
    }
}
