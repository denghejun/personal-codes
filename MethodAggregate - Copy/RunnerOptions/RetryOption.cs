using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodAggregate.RunnerOptions
{
    public enum RetryOption
    {
        None,
        BaseOnRetryCounts,
        LocalCacheRetryAfterMaxRetryCount
    }
}
