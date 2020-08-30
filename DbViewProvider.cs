using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MigrationlessViews.Extensions;
using MigrationlessViews.Interfaces;
using System;
using System.Linq;


namespace MigrationlessViews
{
    public class DbViewProvider<TContext> where TContext : DbContext
    {

        private readonly ViewDictionary _viewDictionary;
        private readonly DbContext _context;

        public DbViewProvider(ViewDictionary viewDictionary,
            TContext dbContext)
        {
            _viewDictionary = viewDictionary;
            _context = dbContext;
        }


        /// <summary>
        /// Returns a set on the database context that executes  
        /// the sql in a file with the name TView.sql
        /// </summary>
        /// <param name="context">The DbContext for the project</param>
        /// <param name="viewDictionary"></param>
        /// <typeparam name="TView"></typeparam>
        /// <returns></returns>
        public IQueryable<TView> DbView<TView>()
            where TView : class, IView
        {
            return _context.Set<TView>().FromSqlRaw(_viewDictionary.GetSqlString(typeof(TView).Name));
        }
    }

    public static class DbViewProvider2
    {
        public static IServiceProvider ServiceProvider { get; }

        public static IQueryable<TView> DbView2<TView>(this DbContext context)
            where TView : class, IView
        {

            var sqlDictionary = (ViewDictionary)ServiceProvider.GetService(typeof(ViewDictionary))
                ?? throw new NotImplementedException();

            return context.Set<TView>().FromSqlRaw(sqlDictionary.GetSqlString(typeof(TView).Name));
        }
    }
}