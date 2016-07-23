using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Features.Metadata;

namespace UnitTests
{
    class Class1
    {
        public void Test()
        {
            Meta<Model,ModelMeta> l;
        }
    }

    public class Model
    {
        public int Age { get; set; }
    }

    public class ModelMeta
    {
        public string Name { get; set; }
    }
}
