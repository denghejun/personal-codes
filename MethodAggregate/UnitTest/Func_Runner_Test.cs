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
    public class Func_Runner_Test
    {
        public const string MAIL_FROM = "Leo.H.Deng@newegg.com";
        public const string MAIL_TO = "Leo.H.Deng@newegg.com";
        public const string MAIL_SUBJECT = "IR runner monitor report.";
        public const string MAIL_BODY_FORMAT = @"<h3>Runner Monitor Execute Context</h3>
                                                                                <h5>Request</h5>  {0}
                                                                               <h5>Response</h5>  {1}
                                                                                <h5>Exception</h5>  <font style='color:red'>{2}</font>
<p style='color:gray'>This Email From Newegg IR Team Super Runner Monitor.</p>";

        #region Func_T
        [TestMethod]
        public void Test_Func_T_Runner()
        {
            // Without Retry
            int executeCountsWithoutRetry = 0;
            string responseWithoutRetry = Runner.Run(() =>
            {
                ++executeCountsWithoutRetry;
                return "Response content.";
            }, new RunnerOption<string>() { RetryOption = RetryOption.None });

            Assert.AreEqual(responseWithoutRetry, "Response content.");
            Assert.AreEqual(executeCountsWithoutRetry, 1);

            //With Retry
            int executeCountsWithRetry = 0;
            string responseWithRetry = null;

            try
            {
                responseWithRetry = Runner.Run(() =>
                {
                    ++executeCountsWithRetry;
                    throw new Exception("error");
                    return "Response content.";
                }, new RunnerOption<string>() { RetryOption = RetryOption.BaseOnRetryCounts, RetryCount = 2 });
            }
            catch
            { }

            Assert.AreEqual(responseWithRetry, null);
            Assert.AreEqual(executeCountsWithRetry, 3);
        }

        [TestMethod]
        public void Test_Func_T_Has_Verifier_Runner()
        {
            // Without Retry
            int executeCountsWithoutRetry = 0;
            string responseWithoutRetry = Runner.Run(() =>
            {
                ++executeCountsWithoutRetry;
                return "Response content.";
            }, new RunnerOption<string>()
            {
                RetryOption = RetryOption.None,
                RetryCount = 10,
                IsSuccessVerifier = response => response.StartsWith("xxx")
            });

            Assert.AreEqual(responseWithoutRetry, "Response content.");
            Assert.AreEqual(executeCountsWithoutRetry, 1);

            //With Retry
            int executeCountsWithRetry = 0;
            string responseWithRetry = null;

            try
            {
                responseWithRetry = Runner.Run(() =>
                {
                    ++executeCountsWithRetry;
                    return "Response content.";
                }, new RunnerOption<string>()
                {
                    IsSuccessVerifier = response => response.StartsWith("Response"),
                    RetryOption = RetryOption.BaseOnRetryCounts,
                    RetryCount = 2
                });
            }
            catch
            { }

            Assert.AreEqual(responseWithRetry, "Response content.");
            Assert.AreEqual(executeCountsWithRetry, 1);
        }

        [TestMethod]
        public void Test_Func_T_Has_MailOptionConstructor()
        {
            // Without Retry
            int executeCountsWithoutRetry = 0;
            string responseWithoutRetry = null;
            try
            {
                responseWithoutRetry = Runner.Run(() =>
            {
                ++executeCountsWithoutRetry;
                throw new Exception("error");
                return "Response content.";
            }, new RunnerOption<string>()
            {
                RetryOption = RetryOption.None,
                RetryCount = 10,
                MailOptionConstructor = mailContext =>
                {
                    mailContext.BasicMailOption.From = Func_Runner_Test.MAIL_FROM;
                    mailContext.BasicMailOption.To = Func_Runner_Test.MAIL_TO;
                    return mailContext.BasicMailOption;
                }
            });
            }
            catch
            { }

            Assert.AreEqual(responseWithoutRetry, null);
            Assert.AreEqual(executeCountsWithoutRetry, 1);

            //With Retry
            int executeCountsWithRetry = 0;
            string responseWithRetry = null;

            try
            {
                responseWithRetry = Runner.Run(() =>
                {
                    ++executeCountsWithRetry;
                    throw new Exception("error");
                    return "Response content.";
                }, new RunnerOption<string>()
                {
                    RetryOption = RetryOption.BaseOnRetryCounts,
                    RetryCount = 2,
                    MailOptionConstructor = mailContext =>
                    {
                        mailContext.BasicMailOption.From = Func_Runner_Test.MAIL_FROM;
                        mailContext.BasicMailOption.To = Func_Runner_Test.MAIL_TO;
                        return mailContext.BasicMailOption;
                    }
                });
            }
            catch
            { }

            Assert.AreEqual(responseWithRetry, null);
            Assert.AreEqual(executeCountsWithRetry, 3);
        }

        [TestMethod]
        public void Test_Func_T_BothHave_Verified_And_MailOptionConstructor()
        {
            // Without Retry
            int executeCountsWithoutRetry = 0;
            string responseWithoutRetry = null;
            try
            {
                responseWithoutRetry = Runner.Run(() =>
                {
                    ++executeCountsWithoutRetry;
                    return "Response content.";
                }, new RunnerOption<string>()
                {
                    RetryOption = RetryOption.None,
                    RetryCount = 10,
                    IsSuccessVerifier = response => response.StartsWith("xxx"),
                    MailOptionConstructor = mailContext =>
                    {
                        mailContext.BasicMailOption.From = Func_Runner_Test.MAIL_FROM;
                        mailContext.BasicMailOption.To = Func_Runner_Test.MAIL_TO;
                        return mailContext.BasicMailOption;
                    }
                });
            }
            catch
            { }

            Assert.AreEqual(responseWithoutRetry, "Response content.");
            Assert.AreEqual(executeCountsWithoutRetry, 1);

            //With Retry
            int executeCountsWithRetry = 0;
            string responseWithRetry = null;

            try
            {
                responseWithRetry = Runner.Run(() =>
                {
                    ++executeCountsWithRetry;
                    return "Response content.";
                }, new RunnerOption<string>()
                {
                    RetryOption = RetryOption.BaseOnRetryCounts,
                    RetryCount = 8,
                    IsSuccessVerifier = response => response.StartsWith("xxx"),
                    MailOptionConstructor = mailContext =>
                    {
                        mailContext.BasicMailOption.From = Func_Runner_Test.MAIL_FROM;
                        mailContext.BasicMailOption.To = Func_Runner_Test.MAIL_TO;
                        return mailContext.BasicMailOption;
                    }
                });
            }
            catch
            { }

            Assert.AreEqual(responseWithRetry, "Response content.");
            Assert.AreEqual(executeCountsWithRetry, 9);
        }
        #endregion

        #region Func_TRequest_TResponse
        [TestMethod]
        public void Test_Func_TRequest_TResponse_Runner()
        {

        }

        [TestMethod]
        public void Test_Func_TRequest_TResponse_Has_Verifier_Runner()
        {

        }

        [TestMethod]
        public void Test_Func_TRequest_TResponse_Has_MailOptionConstructor()
        {

        }

        [TestMethod]
        public void Test_Func_TRequest_TResponse_BothHave_Verified_And_MailOptionConstructor()
        {
            //With Retry
            int executeCountsWithRetry = 0;
            string responseWithRetry = null;

            try
            {
                responseWithRetry = Runner.Run(request =>
                {
                    ++executeCountsWithRetry;
                    return "Response content.";
                }, "request parameter.", new RunnerOption<string, string>()
                {
                    RetryOption = RetryOption.BaseOnRetryCounts,
                    RetryCount = 2,
                    IsSuccessVerifier = (request, response) => response.StartsWith("xxx"),
                    MailOptionConstructor = mailContext =>
                    {
                        mailContext.BasicMailOption.From = Func_Runner_Test.MAIL_FROM;
                        mailContext.BasicMailOption.To = Func_Runner_Test.MAIL_TO;
                        return mailContext.BasicMailOption;
                    }
                });
            }
            catch
            { }

            Assert.AreEqual(responseWithRetry, "Response content.");
            Assert.AreEqual(executeCountsWithRetry, 3);
        }
        #endregion
    }
}
