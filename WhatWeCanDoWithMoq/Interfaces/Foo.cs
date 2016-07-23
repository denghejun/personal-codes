using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatWeCanDoWithMoq.Models;

namespace WhatWeCanDoWithMoq.Interfaces
{
    public abstract class Foo
    {
        public abstract event EventHandler<EventArgs> Fire;
        public abstract User Current { get; set; }
        public abstract User GetUser(string name);
        public abstract User CreateEmptyUser();
        public abstract User GetUser(int feed);
        public abstract void Init();
        public abstract int MyProperty { get; set; }
    }
}
