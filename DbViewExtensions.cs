using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace EfCoreViews.Infrastructure
{
    public static class DbViewExtensions
    {
        public static IQueryable<TView> DbView<TView>(this DbContext context, ViewDictionary viewDictionary) where TView : class, IView
        {
            return context.Set<TView>().FromSqlRaw(viewDictionary.GetSqlString(typeof(TView).Name));
        }

        private static string GetSqlString(this ViewDictionary viewDictionary, string entityName)
        {
            return viewDictionary.Views.First(d => d.Key == entityName).Value; ;
        }
    }
}