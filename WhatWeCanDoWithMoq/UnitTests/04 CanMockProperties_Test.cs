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
    public class _04_CanMockProperties_Test
    {
        [TestMethod]
        public void Test()
        {
            try
            {
                var mockFoo = CanMockProperties.Mock();
                mockFoo.Object.Current = new Models.User() { Name = "New Name" };
                mockFoo.Object.MyProperty = 100;
                //mockFoo.VerifySet(o => o.MyProperty = 100);
                mockFoo.Verify();
            }
            catch (Exception ex)
            {

            }

        }
    }
}
