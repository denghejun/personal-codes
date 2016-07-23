using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MethodAggregate.Models;
using MethodAggregate.RunnerOptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodAggregate.UnitTest
{
    [TestClass]
    public class LocalCacheRetryRunner_Test
    {
        [TestMethod]
        public void Test_LocalCacheRetryRunne_Action_T()
        {
            int count = 0;
            Runner.Run(request =>
            {
                //throw new Exception("something wrong.");
                return request + ": from response";
            }, "this is a request content1.", new RunnerOption<string, string>()
            {
                IsSuccessVerifier = (request, response) => !response.Contains(request)
                ,
                RetryCount = 2,
                RetryOption = RetryOption.LocalCacheRetryAfterMaxRetryCount,
                MailOptionConstructor = mailContext =>
                {
                    mailContext.BasicMailOption.From = Func_Runner_Test.MAIL_FROM;
                    mailContext.BasicMailOption.To = Func_Runner_Test.MAIL_TO;
                    return mailContext.BasicMailOption;
                }
            });
        }

        [TestMethod]
        public void Test_LocalCacheRetryRunne_Action_T2()
        {
            int count = 0;
            Runner.Run((req) =>
            {
                return req;
            }, new Models.RunnerCache() {  MethodInfo = new Models.CacheMethodInfo() { MethodName = "Test_LocalCacheRetryRunne_Action_T" } },new RunnerOption<RunnerCache,RunnerCache>()
            {
                IsSuccessVerifier = (res, re) => false
                ,
                RetryCount = 2,
                RetryOption = RetryOption.LocalCacheRetryAfterMaxRetryCount,
                MailOptionConstructor = mailContext =>
                {
                    mailContext.BasicMailOption.From = Func_Runner_Test.MAIL_FROM;
                    mailContext.BasicMailOption.To = Func_Runner_Test.MAIL_TO;
                    return mailContext.BasicMailOption;
                }
            });
        }

        [TestMethod]
        public void Test_LocalCacheRetryRunne_Action_T3()
        {
            int count = 0;
            Runner.Run((req) =>
            {
                return req;
            }, new Models.RunnerCache() { MethodInfo = new Models.CacheMethodInfo() { MethodName = "Test_LocalCac888heRetryRunne_Action_T" } }, new RunnerOption<RunnerCache, RunnerCache>()
            {
                IsSuccessVerifier = (res, re) => false
                ,
                RetryCount = 2,
                RetryOption = RetryOption.LocalCacheRetryAfterMaxRetryCount,
                MailOptionConstructor = mailContext =>
                {
                    mailContext.BasicMailOption.From = Func_Runner_Test.MAIL_FROM;
                    mailContext.BasicMailOption.To = Func_Runner_Test.MAIL_TO;
                    return mailContext.BasicMailOption;
                }
            });
        }
    }
}
