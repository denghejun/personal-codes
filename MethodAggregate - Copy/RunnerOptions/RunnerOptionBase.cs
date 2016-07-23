using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodAggregate.RunnerOptions
{
    public abstract class RunnerOptionBase
    {
        public RunnerOptionBase()
        {
            this.RetryCount = 0;
            this.RetryInterval = TimeSpan.FromMilliseconds(1000);
            this.RetryOption = RetryOption.None;
        }
        public RetryOption RetryOption { get; set; }
        public int RetryCount { get; set; }
        public TimeSpan RetryInterval { get; set; }
        public MailOption MailOption { get; set; }
    }
}
