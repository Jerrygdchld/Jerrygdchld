using CulinaryAnalytics.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace CulinaryAnalytics.Services
{
    public static class Register
    {
        public static IServiceCollection RegisterServices(this IServiceCollection collection)
        {
            collection.AddScoped<IDictionaryListService, DictionaryListService>();
            collection.AddScoped<IDictionaryListItemService, DictionaryListItemService>();
            return collection;
        }
    }
}
