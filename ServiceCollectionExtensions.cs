using EfCoreViews.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace MigrationlessViews
{
    public static class ServiceCollectionExtensions
    {

        public static void AddDbViews(this IServiceCollection services)
        {
            services.AddSingleton<ViewDictionary>();
        }
    }
}