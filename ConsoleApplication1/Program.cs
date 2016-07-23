using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
//using MethodAggregate;
using Newegg.OZZO.RunnerProxy;
using Newegg.OZZO.RunnerProxy.Models;

namespace ConsoleApplication1
{
    class Program
    {
        public static string Mail_Account = "leo.h.deng@newegg.com";
        static void Main(string[] args)
        {
            try
            {

                //ThreadPool.QueueUserWorkItem(o =>
                //{
                //    try
                //    {
                //        Runner.StartProcessCacheRunners(10, 20);
                //    }
                //    catch (Exception e)
                //    {
                //        Console.WriteLine(e.Message);
                //    }
                //}, null);


                ThreadPool.QueueUserWorkItem(o =>
                {
                    try
                    {
                        Test_LocalCacheRetryRunne_Action_T2();
                        Test_LocalCacheRetryRunne_Action_T();
                        Test_LocalCacheRetryRunne_Action_T3();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }, null);

                //RunnerProxy.StartProcessCacheRunners(new MethodAggregate.Models.CacheProcessOption());
                //new LocalCacheRetryRunner_Test().Test_LocalCacheRetryRunne_Action_T2();
                //new LocalCacheRetryRunner_Test().Test_LocalCacheRetryRunne_Action_T();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Read();
        }

        public static void Test_LocalCacheRetryRunne_Action_T()
        {
            int count = 0;
            Runner.Run(request =>
            {
                //throw new Exception("something wrong.");
                return request + ": from response";
            }, "this is a request content1.", new RunnerOption<string, string>()
            {
                IsSuccessVerifier = (request, response) => response.Contains(request)
                ,
                RetryCount = 2,
                RetryOption = RetryOption.LocalCacheRetryAfterMaxRetryCount,
                MailOptionConstructor = mailContext =>
                {
                    mailContext.BasicMailOption.Mailer = new NeweggAPIMailer();
                    mailContext.BasicMailOption.Content.From = "nesc-cd.mis.ozzo@newegg.com";
                    mailContext.BasicMailOption.Content.To = Mail_Account;
                    return mailContext.BasicMailOption;
                }
            });
        }

        public static void Test_LocalCacheRetryRunne_Action_T2()
        {
            int count = 0;
            Runner.Run((req) =>
            {
                return req;
            }, new RunnerCache() { MethodInfo = new CacheMethodInfo() { MethodName = "Test_LocalCacheRetryRunne_Action_T" } }, new RunnerOption<RunnerCache, RunnerCache>()
            {
                IsSuccessVerifier = (res, re) => false
                ,
                RetryCount = 2,
                RetryOption = RetryOption.LocalCacheRetryAfterMaxRetryCount,
                MailOptionConstructor = mailContext =>
                {
                    mailContext.BasicMailOption.Mailer = new NeweggAPIMailer();
                    mailContext.BasicMailOption.Content.From = "nesc-cd.mis.ozzo@newegg.com";
                    mailContext.BasicMailOption.Content.To = Mail_Account;
                    return mailContext.BasicMailOption;
                }
            });
        }

        public static void Test_LocalCacheRetryRunne_Action_T3()
        {
            int count = 0;
            Runner.Run((req) =>
            {
                return req;
            }, new RunnerCache() { MethodInfo = new CacheMethodInfo() { MethodName = "Test_LocalCac888heRetryRunne_Action_T" } }, new RunnerOption<RunnerCache, RunnerCache>()
            {
                IsSuccessVerifier = (res, re) => false
                ,
                RetryCount = 2,
                RetryOption = RetryOption.LocalCacheRetryAfterMaxRetryCount,
                MailOptionConstructor = mailContext =>
                {
                    mailContext.BasicMailOption.Mailer = new NeweggAPIMailer();
                    mailContext.BasicMailOption.Content.From = "nesc-cd.mis.ozzo@newegg.com";
                    mailContext.BasicMailOption.Content.To = Mail_Account;
                    return mailContext.BasicMailOption;
                }
            });
        }
    }
}
