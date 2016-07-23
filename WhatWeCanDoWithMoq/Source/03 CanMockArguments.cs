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
    public class CanMockArguments
    {
        public static Mock<Foo> Mock()
        {
            var mockFoo = new Mock<Foo>() { };
            mockFoo.Setup(foo => foo.GetUser(It.IsAny<string>())).Returns<string>(name => new User { Name = name });
            mockFoo.Setup(foo => foo.GetUser(It.Is<int>(o => o % 2 == 0))).Returns<int>(age => new User() { Age = age, Name = "偶数" });
            mockFoo.Setup(foo => foo.GetUser(It.Is<int>(o => o % 2 != 0))).Returns<int>(age => new User() { Age = age, Name = "奇数" });
            mockFoo.Setup(foo => foo.GetUser(It.IsInRange<int>(20, 25, Range.Inclusive))).Returns<int>(age => new User() { Age = age, Name = "青年" });
            mockFoo.Setup(foo => foo.GetUser(It.IsRegex("^[\\d]+$"))).Returns<string>(name => new User() { Age = int.Parse(name), Name = name });
            return mockFoo;
        }
    }
}
