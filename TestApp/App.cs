using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public interface IApp
    {
        string Run();
    }

    public class App : IApp, IDisposable
    {
        public string Run()
        {
            return "App running.";
        }

        public void Dispose()
        {
            Console.WriteLine("App service(IApp) auto disposed by Autofac.");
        }
    }
}
