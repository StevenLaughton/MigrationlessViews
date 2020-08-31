using Microsoft.EntityFrameworkCore;
using MigrationlessViews.Classes;
using MigrationlessViews.Extensions;
using System.Linq;


namespace MigrationlessViews
{
    public static class DbViewProvider
    {
        /// <summary>
        /// Returns a set on the database context that executes  
        /// the sql in a file with the name TView.sql
        /// </summary>
        /// <param name="context">The DbContext for the project</param>
        /// <param name="viewDictionary"></param>
        /// <typeparam name="TView"></typeparam>
        /// <returns></returns>
        public static IQueryable<TView> DbView<TView>(this DbContext context, ViewDictionary viewDictionary)
            where TView : View
        {
            return context.Set<TView>().FromSqlRaw(viewDictionary.GetSqlString(typeof(TView).Name));
        }
    }
}