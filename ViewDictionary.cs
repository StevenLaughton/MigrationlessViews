using System.Collections.Generic;
using System.IO;

namespace MigrationlessViews
{
    public class ViewDictionary
    {
        public Dictionary<string, string> Views { get; set; }

        public ViewDictionary()
        {
            Views = new Dictionary<string, string>();
            var views = Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.sql", SearchOption.AllDirectories);

            foreach (var view in views)
            {
                Views.Add(Path.GetFileNameWithoutExtension(view), File.ReadAllText(view));
            }
        }
    }
}