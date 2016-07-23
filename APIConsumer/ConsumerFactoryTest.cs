using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIConsumer.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APIConsumer
{
    [TestClass]
    public class ConsumerFactoryTest
    {
        [TestMethod]
        public void GetConsumer()
        {
            bool isSingle = ConsumerFactory.WMSAPI == ConsumerFactory.WMSAPI;
            Assert.AreEqual(isSingle, true);
        }
    }
}
