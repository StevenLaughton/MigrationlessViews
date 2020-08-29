using System.Linq;

namespace MigrationlessViews.Extensions
{
    public static class ViewDictionaryExtensions
    {
        public static string GetSqlString(this ViewDictionary viewDictionary, string entityName)
        {
            return viewDictionary.Views.First(d => d.Key == entityName).Value;
        }
    }
}