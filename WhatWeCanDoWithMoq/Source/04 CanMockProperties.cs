using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WhatWeCanDoWithMoq.Interfaces;
using WhatWeCanDoWithMoq.Models;

namespace WhatWeCanDoWithMoq.Source
{
    public class CanMockProperties
    {
        public static Mock<Foo> Mock()
        {
            var mockFoo = new Mock<Foo>();
            mockFoo.Setup(foo => foo.Current).Returns(new User() { Name = "Mock Properties" });
            mockFoo.Setup(foo => foo.Current.Name).Returns("Temp Name");
            //mockFoo.SetupSet(o => o.MyProperty = 100);
            mockFoo.SetupSet(o => o.MyProperty = 100).Verifiable(); // 假设会设置这个值为100，待以后验证。这一步相当于  mockFoo.VerifySet(o => o.MyProperty = 100);
            // 在这里这样写，只是为了后边方便统一验证的方式比如：mockFoo.Verify();就可已验证：1.Set方法至少被调用一次；2。且值应该是100
            //mockFoo.SetupAllProperties(); // 设置属性（所有或指定某个属性），以便在后续能够真实的设置其值。
            return mockFoo;
        }
    }
}
