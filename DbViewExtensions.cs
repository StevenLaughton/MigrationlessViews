using Microsoft.EntityFrameworkCore;
using MigrationlessViews.Interfaces;
using System.Linq;

namespace EfCoreViews.Infrastructure
{
    public static class DbViewExtensions
    {
        public static IQueryable<TView> DbView<TView>(this DbContext context,
            ViewDictionary viewDictionary)
            where TView : class, IView
        {
            return context.Set<TView>().FromSqlRaw(viewDictionary.GetSqlString(typeof(TView).Name));
        }

        public static IQueryable<TFunction> DbFunction<TFunction>(this DbContext context,
            ViewDictionary viewDictionary,
            params object[] obs)
            where TFunction : class, IFunction
        {
            return context.Set<TFunction>().FromSqlRaw(viewDictionary.GetSqlString(typeof(TFunction).Name), obs);
        }


        public static IQueryable<TProcedure> DbStoredProcedure<TProcedure>(this DbContext context,
            ViewDictionary viewDictionary,
            params object[] obs)
            where TProcedure : class, IStoredProcedure
        {
            return context.Set<TProcedure>().FromSqlRaw(viewDictionary.GetSqlString(typeof(TProcedure).Name), obs);
        }

        private static string GetSqlString(this ViewDictionary viewDictionary, string entityName)
        {
            return viewDictionary.Views.First(d => d.Key == entityName).Value;
        }
    }
}