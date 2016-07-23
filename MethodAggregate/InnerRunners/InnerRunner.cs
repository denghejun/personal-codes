using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodAggregate.RunnerOptions;

namespace MethodAggregate
{
    public abstract class InnerRunner
    {
        public abstract void Run(Action action, RunnerOption option);
        public abstract void Run<T>(Action<T> action, T request, RunnerOption<T> option);
        public abstract T Run<T>(Func<T> func, RunnerOption<T> option);
        public abstract TResponse Run<TRequest, TResponse>(Func<TRequest, TResponse> func, TRequest request, RunnerOption<TRequest, TResponse> option);
    }
}
