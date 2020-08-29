using Microsoft.Extensions.DependencyInjection;

namespace MigrationlessViews.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static void AddDbViews(this IServiceCollection services)
        {
            services.AddSingleton<ViewDictionary>();
            services.AddScoped<DbViewProvider>();
        }
    }
}