using Microsoft.EntityFrameworkCore;
using MigrationlessViews.Extensions;
using MigrationlessViews.Interfaces;
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
}