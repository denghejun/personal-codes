using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MethodAggregate.Helper;
using MethodAggregate.InnerRunners;
using MethodAggregate.Models;
using MethodAggregate.RunnerOptions;

namespace MethodAggregate
{
    public static class Runner
    {
        public static void Run(Action action, RunnerOption option)
        {
            RunnerEmitter.Emit<InnerRunner>(option).Run(action, option);
        }

        public static void Run<T>(Action<T> action, T request, RunnerOption<T> option)
        {
            RunnerEmitter.Emit<InnerRunner>(option).Run(action, request, option);
        }

        public static T Run<T>(Func<T> func, RunnerOption<T> option)
        {
            return RunnerEmitter.Emit<InnerRunner>(option).Run(func, option);
        }

        public static TResponse Run<TRequest, TResponse>(Func<TRequest, TResponse> func, TRequest request, RunnerOption<TRequest, TResponse> option)
        {
            return RunnerEmitter.Emit<InnerRunner>(option).Run(func, request, option);
        }

        public static void StartProcessCacheRunners(int workersForAllCacheFiles = 1, int workersForEachFile = 0)
        {
            RunnerCacheManager.StartProcessCacheRunners(new CacheProcessOption()
            {
                WorkersForAllCacheFiles = workersForAllCacheFiles,
                WorkersForEachFile = workersForEachFile
            });
        }

        public static void StartProcessCacheRunners(CacheProcessOption option)
        {
            if (option == null)
            {
                throw new ArgumentNullException("option");
            }

            RunnerCacheManager.StartProcessCacheRunners(option);
        }
    }
}
