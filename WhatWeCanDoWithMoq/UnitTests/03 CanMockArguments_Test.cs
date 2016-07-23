using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WhatWeCanDoWithMoq.Source;

namespace WhatWeCanDoWithMoq.UnitTests
{
    [TestClass]
    public class _03_CanMockArguments_Test
    {
        [TestMethod]
        public void Test_AnyName_Args()
        {
            var foo = CanMockArguments.Mock().Object;
            var anyNameUser = foo.GetUser("anyName");
            var evenAgeUser = foo.GetUser(8);
            var oddAgeUser = foo.GetUser(7);
            var youngAgeUser = foo.GetUser(20);
            var nameAsAgeUser = foo.GetUser("22");
        }
    }
}
