using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhatWeCanDoWithMoq.Interfaces;
using WhatWeCanDoWithMoq.Source;

namespace WhatWeCanDoWithMoq.UnitTests
{
    [TestClass]
    public class _06_CanMockLikeLinq
    {
        [TestMethod]
        public void Test()
        {
            IFoo iWanted = CanMockLikeLinq.Mock();
            var user = iWanted.GetUser(0009999);
            Assert.AreEqual(user.Name, "leo");
        }
    }
}
