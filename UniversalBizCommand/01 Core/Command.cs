using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversalBizCommand._01_Core;

namespace UniversalBizCommand._01_Core
{
    public abstract class CommandBase
    {
    }

    public abstract class Command : CommandBase
    {
        // Hooks
        protected virtual void BeforeRun()
        {
        }
        protected virtual void AfterRun()
        {
        }
        protected virtual void AroundRun()
        {
        }
        protected virtual bool CanExecute()
        {
            return true;
        }
        protected virtual void WhenError(CommandException e)
        {
        }

        protected abstract void Execute();
        protected virtual void InnerRun()
        {
            if (this.CanExecute())
            {
                this.Execute();
            }
        }

        public virtual void Run()
        {
            try
            {
                this.BeforeRun();
                this.AroundRun();
                this.InnerRun();
                this.AfterRun();
                this.AroundRun();
            }
            catch (Exception e)
            {
                var cmdException = new CommandException() { Exception = e, Handled = false };
                this.WhenError(cmdException);
                if (!cmdException.Handled)
                {
                    throw;
                }
            }
        }
    }

    public abstract class Command<T> : CommandBase
    {
        // Hooks
        protected virtual void BeforeRun(T request)
        {
        }
        protected virtual void AfterRun(T request)
        {
        }
        protected virtual void AroundRun(T request)
        {
        }
        protected virtual void WhenError(CommandException<T> e)
        {
        }

        protected virtual bool CanExecute(T request)
        {
            return true;
        }
        protected virtual void Execute(T request)
        {
            throw new NotImplementedException();
        }
        protected virtual void InnerRun(T request)
        {
            if (this.CanExecute(request))
            {
                this.Execute(request);
            }
        }


        public virtual void Run(T request)
        {
            try
            {
                this.BeforeRun(request);
                this.AroundRun(request);
                this.InnerRun(request);
                this.AfterRun(request);
                this.AroundRun(request);
            }
            catch (Exception e)
            {
                var cmdException = new CommandException<T>() { State = request, Exception = e, Handled = false };
                this.WhenError(cmdException);
                if (!cmdException.Handled)
                {
                    throw;
                }
            }
        }

        // Hooks
        protected virtual void BeforeRun()
        {
        }
        protected virtual void AfterRun()
        {
        }
        protected virtual void AroundRun()
        {
        }
        protected virtual void WhenError(CommandException<T> e, out T responseWhenErrorHandled)
        {
            responseWhenErrorHandled = default(T);
        }

        protected virtual bool CanExecute(out T responseWhenCanExcuteFalse)
        {
            responseWhenCanExcuteFalse = default(T);
            return true;
        }
        protected virtual T Execute()
        {
            throw new NotImplementedException();
        }
        protected virtual T InnerRun()
        {
            T responseWhenCanExcuteFalse;
            return this.CanExecute(out responseWhenCanExcuteFalse) ? this.Execute() : responseWhenCanExcuteFalse;
        }

        public virtual T Run()
        {
            var result = default(T);

            try
            {
                this.BeforeRun();
                this.AroundRun();
                result = InnerRun();
                this.AfterRun();
                this.AroundRun();
                return result;
            }
            catch (Exception e)
            {
                var cmdException = new CommandException<T>() { State = result, Exception = e, Handled = false };
                var responseWhenErrorHandled = default(T);
                this.WhenError(cmdException, out responseWhenErrorHandled);
                if (!cmdException.Handled)
                {
                    throw;
                }
                else
                {
                    return responseWhenErrorHandled;
                }
            }
        }
    }

    public abstract class Command<TRequest, TResponse> : CommandBase
    {
        // Hooks
        protected virtual void BeforeRun(TRequest request)
        {
        }
        protected virtual void AfterRun(TRequest request)
        {
        }
        protected virtual void AroundRun(TRequest request)
        {
        }
        protected virtual void WhenError(CommandException<TRequest, TResponse> e, out TResponse responseWhenErrorHandled)
        {
            responseWhenErrorHandled = default(TResponse);
        }

        protected virtual bool CanExecute(TRequest request, out TResponse responseWhenCanExcuteFalse)
        {
            responseWhenCanExcuteFalse = default(TResponse);
            return true;
        }
        protected abstract TResponse Execute(TRequest request);
        protected virtual TResponse InnerRun(TRequest request)
        {
            TResponse responseWhenCanExcuteFalse;
            return this.CanExecute(request, out responseWhenCanExcuteFalse) ? this.Execute(request) : responseWhenCanExcuteFalse;
        }

        public virtual TResponse Run(TRequest request)
        {
            var result = default(TResponse);
            try
            {
                this.BeforeRun(request);
                this.AroundRun(request);
                result = InnerRun(request);
                this.AfterRun(request);
                this.AroundRun(request);
                return result;
            }
            catch (Exception e)
            {
                var cmdException = new CommandException<TRequest, TResponse>() { Request = request, Response = result, Exception = e, Handled = false };
                var responseWhenErrorHandled = default(TResponse);
                this.WhenError(cmdException, out responseWhenErrorHandled);
                if (!cmdException.Handled)
                {
                    throw;
                }
                else
                {
                    return responseWhenErrorHandled;
                }
            }
        }
    }

    public static class CommandProxy<T> where T : CommandBase
    {
        public static T Command
        {
            get
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
        }
    }

    public class CommandException
    {
        public Exception Exception { get; set; }
        public bool Handled { get; set; }
    }

    public class CommandException<T> : CommandException
    {
        public T State { get; set; }
    }

    public class CommandException<TRequest, TResponse> : CommandException
    {
        public TRequest Request { get; set; }
        public TResponse Response { get; set; }
    }
}

