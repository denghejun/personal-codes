using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhatWeCanDoWithMoq.Source;

namespace WhatWeCanDoWithMoq.UnitTests
{
    [TestClass]
    public class _05_CanMockEvents
    {
        [TestMethod]
        public void Test()
        {
            var mockFoo = CanMockEvents.Mock();
        }
    }
}
