using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodAggregate.RunnerOptions
{
    public static class RunnerMailContentFormat
    {
        public static readonly string MAIL_SUBJECT = "IR runner monitor report.";
        public static readonly string MAIL_BODY_FORMAT = @"
                                                                               <h3>Runner Monitor Execute Context</h3>
                                                                               <h5>Request</h5>  {0}
                                                                               <h5>Response</h5>  {1}
                                                                               <h5>Exception</h5>  <font style='color:red'>{2}</font>
                                                                               <p style='color:gray'>This Email From Newegg IR Team Super Runner Monitor.</p>";
    }

    public class RunnerMailOptionContext
    {
        private MailOption _basicMailOption;
        public RunnerMailOptionContext(Exception e)
        {
            this.Exception = e;
        }

        public Exception Exception { get; private set; }
        public MailOption BasicMailOption
        {
            get
            {
                return this._basicMailOption ?? (this._basicMailOption = this.ResolveBasicMailOption());
            }
            private set
            {
                this._basicMailOption = value;
            }
        }
        protected virtual MailOption ResolveBasicMailOption()
        {
            var exception = this.Exception == null ? "N/A" : this.Exception.Message;
            return new MailOption()
            {
                Subject = RunnerMailContentFormat.MAIL_SUBJECT,
                Body = string.Format(RunnerMailContentFormat.MAIL_BODY_FORMAT, "N/A", "N/A", exception),
            };
        }
    }



    public class RunnerMailOptionContext<T> : RunnerMailOptionContext
    {
        public RunnerMailOptionContext(T state, bool stateIsRequest, Exception e)
            : base(e)
        {
            this.State = state;
            this.StateIsRequest = stateIsRequest;
        }

        public T State { get; private set; }
        public bool StateIsRequest { get; private set; }
        protected override MailOption ResolveBasicMailOption()
        {
            var stateSerialized = this.State != null ? ServiceStack.Text.JsonSerializer.SerializeToString(State) : "null";
            var request = this.StateIsRequest ? stateSerialized : "N/A";
            var response = !this.StateIsRequest ? stateSerialized : "N/A";
            var exception = this.Exception == null ? "N/A" : this.Exception.Message;
            return new MailOption()
            {
                Subject = RunnerMailContentFormat.MAIL_SUBJECT,
                Body = string.Format(RunnerMailContentFormat.MAIL_BODY_FORMAT, request, response, exception),
            };
        }
    }

    public class RunnerMailOptionContext<TRequest, TResponse> : RunnerMailOptionContext
    {
        public RunnerMailOptionContext(TRequest request, TResponse response, Exception e)
            : base(e)
        {
            this.Request = request;
            this.Response = response;
        }
        public TRequest Request { get; private set; }
        public TResponse Response { get; private set; }
        protected override MailOption ResolveBasicMailOption()
        {
            var request = this.Request != null ? ServiceStack.Text.JsonSerializer.SerializeToString(this.Request) : "null";
            var response = this.Response != null ? ServiceStack.Text.JsonSerializer.SerializeToString(this.Response) : "null";
            var exception = this.Exception == null ? "N/A" : this.Exception.Message;
            return new MailOption()
            {
                Subject = RunnerMailContentFormat.MAIL_SUBJECT,
                Body = string.Format(RunnerMailContentFormat.MAIL_BODY_FORMAT, request, response, exception),
            };
        }
    }


    public class MailOption
    {
        public MailOption()
        {
            this.ContentType = RunnerMailOptionContentType.Html;
            this.Priority = RunnerMailOptionMailPriority.Low;
        }

        public MailOption(string from, string to, string cc, string subject, string body)
        {
            this.From = from;
            this.To = to;
            this.CC = cc;
            this.Subject = subject;
            this.Body = body;
            this.ContentType = RunnerMailOptionContentType.Html;
            this.Priority = RunnerMailOptionMailPriority.Low;
        }

        public string Subject { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string CC { get; set; }
        public string Body { get; set; }
        public RunnerMailOptionContentType ContentType { get; set; }
        public RunnerMailOptionMailPriority Priority { get; set; }
    }

    public enum RunnerMailOptionContentType
    {
        Text,
        Html
    }

    public enum RunnerMailOptionMailPriority
    {
        Normal = 0,
        Low = 1,
        High = 2,
    }
}
