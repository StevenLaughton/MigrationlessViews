using Microsoft.Extensions.DependencyInjection;

namespace MigrationlessViews.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddDbViews(this IServiceCollection services)
        {
            services.AddSingleton<ViewDictionary>();
            services.AddScoped<DbViewProvider>();
        }
    }
}