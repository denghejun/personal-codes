using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDependentServices;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ConsoleApp.UnitTest
{
    [TestClass]
    public class CoreTest
    {
        [TestMethod]
        public void Test_ConsoleApp_Core_CalculateComplex()
        {
            // 1. mock all you need dependent services.
            var mock = AutoMock.GetLoose();
            mock.Mock<ICalculate>().Setup(o => o.Add(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => (a + b));
            mock.Mock<ICalculate>().Setup(o => o.Sub(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => (a - b));
            mock.Mock<INotify>().Setup(o => o.Notify(It.IsAny<string>())).Returns<string>(msg => true);

            // 2. execute with the mocked services.
            var mockedConsoleAppCoreInstance = mock.Create<Core>();
            var result = mockedConsoleAppCoreInstance.CalculateComplex(5, 7);

            // 3. verify all you need.
            mock.Mock<ICalculate>().Verify(o => o.Add(5, 7), Times.Once()); // the mocked ICalculator Provider's Add(5,7) should be call only once.
            mock.Mock<ICalculate>().Verify(o => o.Sub(5, 7), Times.Once()); // the mocked ICalculator Provider's Sub(5,7) should be call only once.
            mock.Mock<INotify>().Verify(o => o.Notify(string.Format("RESULT:{0}", -24)), Times.Once()); // the mocked INotify Provider's Notify(...) should be call only once.
            Assert.AreEqual(result, -24); // the result should be -24
        }
    }
}
