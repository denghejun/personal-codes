using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using WhatWeCanDoWithMoq.Interfaces;
using Moq.Protected;

namespace WhatWeCanDoWithMoq.Source
{
    public class CanMockEvents
    {
        public static Mock<Foo> Mock()
        {
            var mockFoo = new Mock<Foo>() {DefaultValue = DefaultValue.Mock };
            mockFoo.Object.Fire += Object_Fire;
            mockFoo.Raise(o => o.Fire += null, EventArgs.Empty);
            return mockFoo;
        }

        static void Object_Fire(object sender, EventArgs e)
        {

        }
    }
}
