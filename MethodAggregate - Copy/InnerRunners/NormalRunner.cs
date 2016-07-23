using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodAggregate.RunnerOptions;

namespace MethodAggregate.InnerRunners
{
    public class NormalRunner : InnerRunner
    {
        public override void Run(Action action, RunnerOption option)
        {
            action();
        }

        public override void Run<T>(Action<T> action, T request, RunnerOption<T> option)
        {
            action(request);
        }

        public override T Run<T>(Func<T> func, RunnerOption<T> option)
        {
            return func();
        }

        public override TResponse Run<TRequest, TResponse>(Func<TRequest, TResponse> func, TRequest request, RunnerOption<TRequest, TResponse> option)
        {
            return func(request);
        }
    }
}
