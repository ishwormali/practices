using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition.Hosting;
using System.IO;

using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition;
namespace AgileOutlook
{
    public class PluginLocator
    {
        public static void ComposeParts(params object[] attributedParts)
        {
            AssemblyCatalog catalog = new AssemblyCatalog(typeof(PluginLocator).Assembly);

            AggregateCatalog catalogs = new AggregateCatalog(catalog);
            var pluginDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"\plugins");
            if (Directory.Exists(pluginDirectory))
            {
                DirectoryCatalog dirCatalog = new DirectoryCatalog(pluginDirectory);
                catalogs.Catalogs.Add(dirCatalog);
            }

            pluginDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            if (Directory.Exists(pluginDirectory))
            {
                DirectoryCatalog dirCatalog = new DirectoryCatalog(pluginDirectory);
                catalogs.Catalogs.Add(dirCatalog);
            }

            CompositionContainer container = new CompositionContainer(catalogs);

            container.ComposeParts(attributedParts);

        }
    }
}
