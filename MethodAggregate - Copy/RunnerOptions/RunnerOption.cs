using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodAggregate.RunnerOptions
{
    public class RunnerOption : RunnerOptionBase
    {
        public Func<bool> IsSuccessVerifier { get; set; }
        public static RunnerOption Default
        {
            get
            {
                return new RunnerOption()
                {
                    IsSuccessVerifier = () => { return true; }
                };
            }
        }
    }

    public class RunnerOption<T> : RunnerOptionBase
    {
        public T Request { get; set; }
        public Func<T, bool> IsSuccessVerifier { get; set; }
        public static RunnerOption<T> Default
        {
            get
            {
                return new RunnerOption<T>()
                {
                    IsSuccessVerifier = param => { return true; }
                };
            }
        }
    }

    public class RunnerOption<TRequest, TResponse> : RunnerOptionBase
    {
        public TRequest Request { get; set; }
        public Func<TRequest, TResponse, bool> IsSuccessVerifier { get; set; }
        public static RunnerOption<TRequest, TResponse> Default
        {
            get
            {
                return new RunnerOption<TRequest, TResponse>()
                {
                    IsSuccessVerifier = (request, response) => { return true; }
                };
            }
        }
    }
}
