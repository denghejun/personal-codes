using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodAggregate.RunnerOptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodAggregate.UnitTest
{
    [TestClass]
    public class Action_Runner_Test
    {
        [TestMethod]
        public void Test_Action_NormalRunner()
        {
            int executeCounts = 0;
            try
            {
                Runner.Run(() =>
                {
                    ++executeCounts;
                    throw new Exception("error");
                }, RunnerOption.Default);
            }
            catch (Exception)
            {
            }

            Assert.AreEqual(executeCounts, 1);
        }

        [TestMethod]
        public void Test_Action_T_NormalRunner()
        {
            int executeCounts = 0;
            try
            {
                Runner.Run(message =>
                {
                    ++executeCounts;
                    throw new Exception(message);
                }, "error message request.", new RunnerOption<string>() { });
            }
            catch (Exception)
            {
            }

            Assert.AreEqual(executeCounts, 1);
        }

        [TestMethod]
        public void Test_Action_T_RetryRunner()
        {
            int executeCounts = 0;
            int retryCounts = 2;
            try
            {
                Runner.Run(message =>
                {
                    ++executeCounts;
                    throw new Exception(message);
                }, "this is a message.", new RunnerOption<string>() { RetryOption = RetryOption.BaseOnRetryCounts, RetryCount = retryCounts });
            }
            catch (Exception)
            {
            }

            Assert.AreEqual(executeCounts, 3);
        }

        [TestMethod]
        public void Test_Action_T_HasVerifier_RetryRunner()
        {
            int executeCounts = 0;
            int retryCounts = 2;
            Runner.Run(message =>
            {
                ++executeCounts;
            },
            "this is a message.",
            new RunnerOption<string>()
            {
                RetryOption = RetryOption.BaseOnRetryCounts,
                RetryCount = retryCounts,
                IsSuccessVerifier = req => { return req.StartsWith("this"); },
                MailOptionConstructor = mailContext =>
                {
                    mailContext.BasicMailOption.From = Func_Runner_Test.MAIL_FROM;
                    mailContext.BasicMailOption.To = Func_Runner_Test.MAIL_TO;
                    return mailContext.BasicMailOption;
                }
            });

            Assert.AreEqual(executeCounts,1);
        }

        [TestMethod]
        public void Test_Action_LessThanOrEqualToZero_HasVerifier_RetryRunner()
        {
            int executeCounts = 0;
            int retryCounts = -1;
            Runner.Run(message =>
            {
                ++executeCounts;
            },
            "this is a message.",
            new RunnerOption<string>()
            {
                RetryOption = RetryOption.BaseOnRetryCounts,
                RetryCount = retryCounts,
                IsSuccessVerifier = req => { return req.StartsWith("message"); },
            });

            Assert.AreEqual(executeCounts, 1);
        }
    }
}
