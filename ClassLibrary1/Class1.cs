using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Model
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }

    public class TestClass
    {
        public static Model Test(int a, int b)
        {
            return new Model() { ID = (a + b).ToString() };
        }
    }
}
