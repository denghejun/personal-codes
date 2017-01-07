using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sparkling.Component.Async.Core;
using System.Threading;
using Sparkling.Component.Async.Interface;

namespace CommonAsyncComponent
{
    class Program
    {
        static void Main(string[] args)
        {
            IProgress p = new ConsoleProgress();
            Console.WriteLine("press any key to start.");
            Console.ReadLine();
            //AsyncComponent.Instance.BeginActionInvoke(
            //action: () =>
            //{

            //},
            //success: () =>
            //{

            //},
            //millisecondsTimeout: 2000,
            //error: e =>
            //{

            //});

            Console.ReadLine();
        }
    }
}
