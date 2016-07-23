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
    public class CanMockLikeLinq
    {
        public static IFoo Mock()
        {
            var iWantedFooLikeThis = Moq.Mock.Of<IFoo>(o => o.GetUser(It.IsAny<int>()) == Moq.Mock.Of<User>(u => u.Name == "leo"));
            return iWantedFooLikeThis;
        }
    }
}
