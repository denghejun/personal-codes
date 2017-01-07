using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MEFConsoleExample.Interface;

namespace MEFConsoleExample
{
    class Program
    {
        [ImportMany]
        public ILogger[] Loggers { get; set; }
        static void Main(string[] args)
        {
            Program p = new Program();
         
            // why is here
            AssemblyCatalog catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());

            // what is the container and what does the container do
            CompositionContainer container = new CompositionContainer(catalog);

            // compose?
            container.ComposeParts(p);

            container.GetExports<ILogger>();
            foreach (var item in p.Loggers)
            {
                item.WriteMessage(item.ToString());
            }

            Console.ReadKey();
        }
    }
}
