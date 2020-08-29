using Microsoft.Extensions.DependencyInjection;

namespace MigrationlessViews.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddDbViews(this IServiceCollection services)
        {
            return services.AddSingleton<ViewDictionary>()
                        .AddScoped<DbViewProvider>();
        }
    }
}