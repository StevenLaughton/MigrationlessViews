using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MigrationlessViews.Extensions;
using MigrationlessViews.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace MigrationlessViews
{
    public class DbViewProvider
    {

        private readonly IServiceProvider _services;

        public DbViewProvider(IServiceProvider services)
        {
            _services = services;
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
            var contextName = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.BaseType?.Name == "DbContext").FirstOrDefault();

            var dbContext = (DbContext)_services.GetRequiredService(contextName);
            var sqlDictionary = (ViewDictionary)_services.GetRequiredService(typeof(ViewDictionary));

            return dbContext.Set<TView>().FromSqlRaw(sqlDictionary.GetSqlString(typeof(TView).Name));
        }
    }
}