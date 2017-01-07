using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sparkling.Component.Async.Core;

namespace WindowsFormsApplication1
{
    public static class WinFormAsyncComponent
    {
        public static AsyncComponent Instance
        {
            get
            {
                return AsyncComponent.GetInstance(new ImageProgress());
            }
        }
    }
}
