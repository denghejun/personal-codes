using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatWeCanDoWithMoq.Models;

namespace WhatWeCanDoWithMoq.Interfaces
{
    public interface IFoo
    {
        User Current { get; set; }
        User GetUser(string name);
        User CreateEmptyUser();
        User GetUser(int feed);
        void Init();
    }
}
