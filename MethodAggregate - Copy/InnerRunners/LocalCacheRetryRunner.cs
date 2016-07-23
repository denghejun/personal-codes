using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodAggregate.InnerRunners
{
    public class LocalCacheRetryRunner : InnerRunner
    {
        public override void Run(Action action, RunnerOptions.RunnerOption option)
        {
            throw new NotImplementedException();
        }

        public override void Run<T>(Action<T> action, T request, RunnerOptions.RunnerOption<T> option)
        {
            throw new NotImplementedException();
        }

        public override T Run<T>(Func<T> func, RunnerOptions.RunnerOption<T> option)
        {
            throw new NotImplementedException();
        }

        public override TResponse Run<TRequest, TResponse>(Func<TRequest, TResponse> func, TRequest request, RunnerOptions.RunnerOption<TRequest, TResponse> option)
        {
            throw new NotImplementedException();
        }
    }
}
