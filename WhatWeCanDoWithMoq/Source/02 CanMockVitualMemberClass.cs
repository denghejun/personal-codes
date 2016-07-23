using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using WhatWeCanDoWithMoq.Interfaces;
using WhatWeCanDoWithMoq.Models;

namespace WhatWeCanDoWithMoq.Source
{
    public class CanMockVitualMemberClass
    {
        public static Mock<Foo> MockFoo()
        {
            var mockedIFoo = new Mock<Foo>();

            // 1. mock a method.
            mockedIFoo.Setup(foo => foo.GetUser("Tom")).Returns(new User() { Name = "Tom", Age = 17 });
            mockedIFoo.Setup(foo => foo.CreateEmptyUser()).Returns(() => new User() { Name = "Empty" });
            mockedIFoo.Setup(foo => foo.Init()).Throws(new Exception("Initial failed."));
            mockedIFoo.Setup(foo => foo.GetUser(It.IsAny<int>())).Returns<int>(feed => new User() { Age = feed });

            // 2. mock a property.
            mockedIFoo.SetupGet(foo => foo.Current).Returns(new User { Name = "Unknown", Age = 0 });

            return mockedIFoo;
        }
    }
}
