using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MigrationlessViews.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddDbViews<TContext>(this IServiceCollection services) where TContext : DbContext
        {
            return services.AddSingleton<ViewDictionary>()
                        .AddScoped<DbViewProvider<TContext>>();
        }
    }
}