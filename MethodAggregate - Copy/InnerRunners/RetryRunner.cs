using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MethodAggregate.RunnerOptions;

namespace MethodAggregate
{
    public class RetryRunner : InnerRunner
    {
        public override void Run(Action action, RunnerOption option)
        {
            RetryRunner.Retry(option.RetryCount, option.RetryInterval, action, option.IsSuccessVerifier);
        }

        public override void Run<T>(Action<T> action, T request, RunnerOption<T> option)
        {
            RetryRunner.Retry(option.RetryCount, option.RetryInterval, action, request, option.IsSuccessVerifier);
        }

        public override T Run<T>(Func<T> func, RunnerOption<T> option)
        {
            return RetryRunner.Retry(option.RetryCount, option.RetryInterval, func, option.IsSuccessVerifier);
        }

        public override TResponse Run<TRequest, TResponse>(Func<TRequest, TResponse> func, TRequest request, RunnerOption<TRequest, TResponse> option)
        {
            return RetryRunner.Retry(option.RetryCount, option.RetryInterval, func, request, option.IsSuccessVerifier);
        }

        private static void Retry(int retryCounts, TimeSpan interval, Action action, Func<bool> isSuccessVerifier)
        {
            try
            {
                action();
                if (isSuccessVerifier != null && !isSuccessVerifier() && retryCounts > 0)
                {
                    Thread.Sleep(interval);
                    Retry(--retryCounts, interval, action, isSuccessVerifier);
                }
            }
            catch (Exception)
            {
                if (retryCounts > 0)
                {
                    Thread.Sleep(interval);
                    Retry(--retryCounts, interval, action, isSuccessVerifier);
                }
                else
                {
                    throw;
                }
            }
        }

        private static void Retry<T>(int retryCounts, TimeSpan interval, Action<T> action, T request, Func<T, bool> isSuccessVerifier)
        {
            try
            {
                action(request);
                if (isSuccessVerifier != null && !isSuccessVerifier(request) && retryCounts > 0)
                {
                    Thread.Sleep(interval);
                    Retry(--retryCounts, interval, action, request, isSuccessVerifier);
                }
            }
            catch (Exception)
            {
                if (retryCounts > 0)
                {
                    Thread.Sleep(interval);
                    Retry(--retryCounts, interval, action, request, isSuccessVerifier);
                }
                else
                {
                    throw;
                }
            }
        }

        private static T Retry<T>(int retryCounts, TimeSpan interval, Func<T> func, Func<T, bool> isSuccessVerifier)
        {
            try
            {
                var result = func();
                if (isSuccessVerifier != null && !isSuccessVerifier(result) && retryCounts > 0)
                {
                    Thread.Sleep(interval);
                    return Retry(--retryCounts, interval, func, isSuccessVerifier);
                }
                else
                {
                    return result;
                }
            }
            catch (Exception)
            {
                if (retryCounts > 0)
                {
                    Thread.Sleep(interval);
                    return Retry(--retryCounts, interval, func, isSuccessVerifier);
                }
                else
                {
                    throw;
                }
            }
        }

        private static TResponse Retry<TRequest, TResponse>(int retryCounts, TimeSpan interval, Func<TRequest, TResponse> func, TRequest request, Func<TRequest, TResponse, bool> isSuccessVerifier)
        {
            try
            {
                var result = func(request);
                if (isSuccessVerifier != null && !isSuccessVerifier(request, result) && retryCounts > 0)
                {
                    Thread.Sleep(interval);
                    return Retry(--retryCounts, interval, func, request, isSuccessVerifier);
                }
                else
                {
                    return result;
                }
            }
            catch (Exception)
            {
                if (retryCounts > 0)
                {
                    Thread.Sleep(interval);
                    return Retry(--retryCounts, interval, func, request, isSuccessVerifier);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
