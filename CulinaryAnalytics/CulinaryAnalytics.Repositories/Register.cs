using CulinaryAnalytics.Core;
using CulinaryAnalytics.Models.Entities.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CulinaryAnalytics.Repositories
{
    public static class Register
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddDbContext<CaappContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableServiceProviderCaching(false);
                options.EnableThreadSafetyChecks(true);
            });
            collection.AddScoped<IRepository<DictionaryList>, GenericRepository<DictionaryList>>();
            collection.AddScoped<IRepository<DictionaryListItem>, GenericRepository<DictionaryListItem>>();
            return collection;
        }
    }
}
