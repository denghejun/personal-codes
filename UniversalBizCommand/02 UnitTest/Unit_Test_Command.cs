using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversalBizCommand._03_ReceivingPostCommands;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.ComponentModel;
using UniversalBizCommand._01_Core;

namespace UniversalBizCommand
{
    [TestClass]
    public class Unit_Test_Command
    {
        [TestMethod]
        public void Test_Generate_NoRequestNoResponse_Command()
        {
            try
            {
                CommandProxy<MockedNoRequestNoResponseCommand>.Command.Run();
            }
            catch (Exception e)
            {

            }
        }

        [TestMethod]
        public void Test_Generate_OnlyRequest_Command()
        {
            try
            {
                CommandProxy<MockedOnlyRequestCommand>.Command.Run(MockedCommandRequest.Empty);
            }
            catch (Exception e)
            {

            }
        }

        [TestMethod]
        public void Test_Generate_OnlyResponse_Command()
        {
            try
            {
                var response = CommandProxy<MockedOnlyResponseCommand>.Command.Run();
            }
            catch
            {

            }
        }

        [TestMethod]
        public void Test_Generate_HasRequestHasResponse_Command()
        {
            try
            {
                var respones = CommandProxy<MockedHasRequestHasResponseCommand>.Command.Run(new MockedCommandRequest() { id = 1001 });
            }
            catch (Exception)
            {

            }
        }

        [TestMethod]
        public void Test_Override_InnerRunMethod_Command()
        {
            var respones = CommandProxy<OverrideInnerRunMethodCommand>.Command.Run(MockedCommandRequest.Empty);
        }

        [TestMethod]
        public void Test_ProcessReceivingPost_Command()
        {
            var result = CommandProxy<ProcessReceivingPostCommand>.Command.Run(new RecivingPostInputEntity());
        }
    }
}
