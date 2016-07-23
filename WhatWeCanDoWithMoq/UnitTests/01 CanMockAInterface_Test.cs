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
    public class _01_CanMockAInterface_Test
    {
        [TestMethod]
        public void Test_Mocked_Interface_IFoo()
        {
            var mockedIFoo = CanMockAInterface.MockIFoo();
            var getAUser = mockedIFoo.GetUser("Tim");
            getAUser = mockedIFoo.GetUser("Tom");
            var createEmptyUser = mockedIFoo.CreateEmptyUser();
            var _100AgeUser = mockedIFoo.GetUser(100);
            try
            {
                mockedIFoo.Init();
            }
            catch (Exception e)
            {

            }

            var currentUser = mockedIFoo.Current;
        }
    }
}
