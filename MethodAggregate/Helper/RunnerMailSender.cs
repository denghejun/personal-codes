using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodAggregate.RunnerOptions;
using Newegg.Framework.Tools.Log;
using Newegg.FrameworkAPI.SDK.Mail;

namespace MethodAggregate.Helper
{
    public static class RunnerMailSender
    {
        public static bool Send(MailOption option, bool isNeedLog = false)
        {
            return option == null ? false : RunnerMailSender.Send(option.From, option.To, option.CC, option.Subject, option.Body, (MailContentType)Enum.Parse(typeof(MailContentType), option.ContentType.ToString()), (MailPriority)Enum.Parse(typeof(MailPriority), option.Priority.ToString()), isNeedLog);
        }

        public static bool Send(string from, string to, string cc, string subject, string body, MailContentType contentType = MailContentType.Html, MailPriority priority = MailPriority.Low, bool isNeedLog = false)
        {
            bool isSuccessful = false;
            string errorMsg = string.Empty;

            try
            {
                MailRequest request = new MailRequest();
                request.Subject = subject;
                request.From = from;
                request.To = to;
                request.CC = cc;
                request.Body = body;
                request.ContentType = contentType;
                //request.IsNeedLog = isNeedLog;
                request.Priority = priority;
                request.MailType = MailType.Smtp;
                request.SmtpSetting = new SmtpSetting
                {
                    BodyEncoding = MailEncoding.UTF8,
                    SubjectEncoding = MailEncoding.UTF8,
                };

                isSuccessful = Newegg.FrameworkAPI.SDK.Mail.MailSender.Send(request).IsSendSuccess;
                return isSuccessful;
            }
            catch (Exception e)
            {
                errorMsg = e.Message;
                return false;
            }
            finally
            {
                if (isNeedLog || !isSuccessful)
                {
                    RunnerMailSender.WriteEmailLog(from, to, cc, subject, body, isSuccessful, errorMsg);
                }
            }
        }

        private static void WriteEmailLog(string from, string to, string cc, string subject, string body, bool isSuccessful, string errorMsg)
        {
            Logger.WriteLog(new LogEntry()
            {
                ID = DateTime.Now.ToString(),
                ExtendedProperties = new List<ExtendProperty>() { 
                            new ExtendProperty() { Key = "From", Value = from } ,
                            new ExtendProperty() { Key = "To", Value = to } ,
                            new ExtendProperty() { Key = "Cc", Value =cc } ,
                            new ExtendProperty() { Key = "Subject", Value = subject } ,
                            new ExtendProperty() { Key = "Body", Value = body } ,
                            new ExtendProperty() { Key = "IsSuccessful", Value =isSuccessful.ToString() } ,
                            new ExtendProperty() { Key = "ErrorMsg", Value = errorMsg} 
                        }
            });
        }
    }
}
