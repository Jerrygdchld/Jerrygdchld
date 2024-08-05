using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CulinaryAnalytics.Commands
{
    public static class Register
    {
        public static IServiceCollection RegisterCommands(this IServiceCollection collection)
        {
            collection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return collection;
        }
    }
}
