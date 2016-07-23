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
    public class _02_CanMockVitualMemberClass_Test
    {
        [TestMethod]
        public void Test_Mocked_Class_Foo()
        {
            var mockedIFoo = CanMockVitualMemberClass.MockFoo();
            var getAUser = mockedIFoo.Object.GetUser("Tim");
            getAUser = mockedIFoo.Object.GetUser("Tom");

            try
            {
                var createEmptyUser = mockedIFoo.Object.CreateEmptyUser();
                var createEmptyUser2Times = mockedIFoo.Object.CreateEmptyUser();
                mockedIFoo.Verify(foo => foo.CreateEmptyUser(), Moq.Times.Exactly(2), "you must invoke 2 times CreateEmptyUser().");
            }
            catch (Exception e)
            {

            }


            var _100AgeUser = mockedIFoo.Object.GetUser(100);
            try
            {
                mockedIFoo.Object.Init();
            }
            catch (Exception e)
            {

            }

            var currentUser = mockedIFoo.Object.Current;
        }
    }
}
