using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodAggregate.RunnerOptions
{
    public class MailOption
    {
        public string Subject { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string CC { get; set; }
        public string Body { get; set; }
        public MailContentType ContentType { get; set; }
        public MailPriority Priority { get; set; }
        public MailType MailType { get; set; }
    }

    public enum MailContentType
    {
        Html = 0,
        Text = 1,
    }

    public enum MailPriority
    {
        Normal = 0,
        Low = 1,
        High = 2,

    }

    public enum MailType
    {
        LondongII = 0,
        Smtp = 1,
    }
}
