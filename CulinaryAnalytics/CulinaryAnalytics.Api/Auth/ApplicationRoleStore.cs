using CulinaryAnalytics.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CulinaryAnalytics.Api.Auth
{
    public class ApplicationRoleStore : IRoleStore<ApplicationRole>
    {
        private readonly AuthDbContext _dbContext;
        private readonly ILogger _logger;

        public ApplicationRoleStore(AuthDbContext dbContext, ILogger<ApplicationRoleStore> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            try
            {
                if (_dbContext.Roles.Any(r =>
                                        (r.Name != null && r.Name.Equals(role.Name, StringComparison.InvariantCultureIgnoreCase))
                                        || (r.NormalizedName != null && r.NormalizedName.Equals(role.Name, StringComparison.InvariantCultureIgnoreCase))))
                {
                    _dbContext.Update(role);
                }
                else
                {
                    _dbContext.Add(role);
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

        public async Task<IdentityResult> DeleteAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            try
            {
                _dbContext.Remove(role);
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

        public void Dispose()
        {
        }

        public Task<ApplicationRole?> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            if (int.TryParse(roleId, out var id))
            {
                return _dbContext.Roles.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            }
            return Task.FromResult((ApplicationRole?)null);
        }

        public Task<ApplicationRole?> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            return GetRoleAsync(normalizedRoleName, cancellationToken);
        }

        public async Task<string?> GetNormalizedRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return role.NormalizedName ?? (await GetRoleAsync(role, cancellationToken))?.NormalizedName;
        }

        public Task<string> GetRoleIdAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Id.ToString());
        }

        public async Task<string?> GetRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return role.Name ?? (await GetRoleAsync(role, cancellationToken))?.Name;
        }

        public Task SetNormalizedRoleNameAsync(ApplicationRole role, string? normalizedName, CancellationToken cancellationToken)
        {
            if (normalizedName == null || role.NormalizedName == normalizedName)
            {
                return Task.CompletedTask;
            }
            role.NormalizedName = normalizedName;
            _dbContext.Update(role);
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task SetRoleNameAsync(ApplicationRole role, string? roleName, CancellationToken cancellationToken)
        {
            if (roleName == null || role.Name == roleName)
            {
                return Task.CompletedTask;
            }
            role.Name = roleName;
            _dbContext.Update(role);
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            try
            {
                _dbContext.Update(role);
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

        private Task<ApplicationRole?> GetRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            return _dbContext.Roles.FirstOrDefaultAsync(r =>
                                        (r.Name != null && r.Name.Equals(roleName, StringComparison.InvariantCultureIgnoreCase))
                                        || (r.NormalizedName != null && r.NormalizedName.Equals(roleName, StringComparison.InvariantCultureIgnoreCase)));
        }

        private Task<ApplicationRole?> GetRoleAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return _dbContext.Roles.FirstOrDefaultAsync(r =>
                                        r.Id == role.Id
                                        || (r.Name != null && r.Name.Equals(role.Name, StringComparison.InvariantCultureIgnoreCase))
                                        || (r.NormalizedName != null && r.NormalizedName.Equals(role.Name, StringComparison.InvariantCultureIgnoreCase)));
        }
    }
}
