using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodAggregate.InnerRunners;
using MethodAggregate.RunnerOptions;

namespace MethodAggregate
{
    public static class RunnerEmitter
    {
        public static T Emit<T>(RunnerOptionBase option) where T : InnerRunner
        {
            if (option == null)
            {
                return RunnerEmitter.Emit<NormalRunner>(option) as T;
            }
            else
            {
                if (typeof(T).Equals(typeof(InnerRunner)))
                {
                    switch (option.RetryOption)
                    {
                        case RetryOption.None:
                            return RunnerEmitter.Emit<NormalRunner>(option) as T;
                        case RetryOption.BaseOnRetryCounts:
                            return RunnerEmitter.Emit<RetryRunner>(option) as T;
                        case RetryOption.LocalCacheRetryAfterMaxRetryCount:
                            return RunnerEmitter.Emit<CachedRetryRunner>(option) as T;
                        default:
                            return RunnerEmitter.Emit<NormalRunner>(option) as T;
                    }
                }
                else
                {
                    return Activator.CreateInstance(typeof(T)) as T;
                }
            }
        }
    }
}
