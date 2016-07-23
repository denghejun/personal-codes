using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using AutofacWithMoq.ConsoleApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;

namespace AutofacWithMoq.ConsoleApp.UnitTests
{
    [TestClass]
    public class OrderCommandTest
    {
        [TestMethod]
        public void Test_OrderCommand_Executed_SendNotify_Sln_1()
        {
            var inputMessage = "input message";
            var mock = AutoMock.GetLoose();
            mock.Mock<INotification>().Setup(o => o.Notify(inputMessage)).Returns<string>(msg => msg + " has been processed.[Test]");
            var processedMessage = mock.Create<OrderCommand>().Execute(inputMessage);
            mock.Mock<INotification>().Verify(o => o.Notify(inputMessage), Moq.Times.Exactly(1));
            Assert.AreEqual(inputMessage + " has been processed.[Test]", processedMessage);
        }

        [TestMethod]
        public void Test_OrderCommand_Executed_SendNotify_Sln_2()
        {
            var inputMessage = "input message";
            var mock = AutoMock.GetLoose();
            var processedMessage = mock.Create<OrderCommand>().Execute(inputMessage);
            Assert.AreEqual(inputMessage + " has been processed.", processedMessage);
        }

        [TestMethod]
        public void Test_OrderCommand_Executed_SendNotify_Sln_3()
        {
            var inputMessage = "input message";
            var mock = AutoMock.GetLoose();
            mock.Provide<INotification, OrderCommandNotify>();
            var processedMessage = mock.Create<OrderCommand>().Execute(inputMessage);
            Assert.AreEqual(inputMessage + " has been processed.", processedMessage);
        }
    }
}
