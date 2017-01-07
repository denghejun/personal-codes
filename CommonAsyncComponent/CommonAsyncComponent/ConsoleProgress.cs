using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sparkling.Component.Async.Interface;

namespace CommonAsyncComponent
{
    public class ConsoleProgress : IProgress
    {
        public void Show()
        {
            Console.WriteLine("正在处理中，请稍后... ...");
        }

        public void Close()
        {
            Console.WriteLine("处理完成");
        }
    }
}
