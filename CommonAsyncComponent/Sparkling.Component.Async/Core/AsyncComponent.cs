/* 
 * name space: Sparkling.Component.Async.Core
 * component name: AsyncComponent
 * ahtor: Create by Deng he jun 2014-11-22 9:36:01
 * memo:(multi thread is not safe)
 * **/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sparkling.Component.Async.Interface;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace Sparkling.Component.Async.Core
{
    public sealed class AsyncComponent
    {
        // Fileds
        private static AsyncComponent _instance;
        private static object _syncLocker = new object();
        private IProgress _progress { get; set; }
        private readonly SynchronizationContext _syncContext = SynchronizationContext.Current;
        private AsyncComponent()
        {
        }

        // Instance
        private static AsyncComponent Instance
        {
            get
            {
                if (AsyncComponent._instance == null)
                {
                    lock (AsyncComponent._syncLocker)
                    {
                        if (AsyncComponent._instance == null)
                        {
                            AsyncComponent._instance = new AsyncComponent();
                        }
                    }
                }

                return AsyncComponent._instance;
            }
        }
        public static AsyncComponent GetInstance(IProgress progress = null)
        {
            AsyncComponent.Instance._progress = progress;
            return AsyncComponent.Instance;
        }

        // Async Action Delegate
        public void BeginActionInvoke(Action action, Action success, Action<Exception> error = null)
        {
            Action<Action> tempAction = new Action<Action>((act) =>
            {
                if (act != null)
                {
                    act.Invoke();
                }
            });

            this.BeginActionInvoke<Action>(tempAction, action, success, error);
        }
        public void BeginActionInvoke(Action action, Action success, Action<Exception> error, int millisecondsTimeout)
        {
            Action<Action> tempAction = new Action<Action>((act) =>
            {
                if (act != null)
                {
                    act.Invoke();
                }
            });

            this.BeginActionInvoke<Action>(tempAction, action, success, error, millisecondsTimeout);
        }

        public void BeginActionInvoke<T1>(Action<T1> action, T1 param, Action success, Action<Exception> error = null)
        {
            Action<T1, Action<T1>> tempAction = new Action<T1, Action<T1>>((p1, act) =>
            {
                if (act != null)
                {
                    act.Invoke(p1);
                }
            });

            this.BeginActionInvoke<T1, Action<T1>>(tempAction, param, action, success, error);
        }
        public void BeginActionInvoke<T1>(Action<T1> action, T1 param, Action success, Action<Exception> error, int millisecondsTimeout)
        {
            Action<T1, Action<T1>> tempAction = new Action<T1, Action<T1>>((p1, act) =>
            {
                if (act != null)
                {
                    act.Invoke(p1);
                }
            });

            this.BeginActionInvoke<T1, Action<T1>>(tempAction, param, action, success, error, millisecondsTimeout);
        }

        public void BeginActionInvoke<T1, T2>(Action<T1, T2> action, T1 param1, T2 param2, Action success, Action<Exception> error = null)
        {
            Action<T1, T2, Action<T1, T2>> tempAction = new Action<T1, T2, Action<T1, T2>>((p1, p2, act) =>
            {
                if (act != null)
                {
                    act.Invoke(p1, p2);
                }
            });

            this.BeginActionInvoke<T1, T2, Action<T1, T2>>(tempAction, param1, param2, action, success, error);
        }
        public void BeginActionInvoke<T1, T2>(Action<T1, T2> action, T1 param1, T2 param2, Action success, Action<Exception> error, int millisecondsTimeout)
        {
            Action<T1, T2, Action<T1, T2>> tempAction = new Action<T1, T2, Action<T1, T2>>((p1, p2, act) =>
            {
                if (act != null)
                {
                    act.Invoke(p1, p2);
                }
            });

            this.BeginActionInvoke<T1, T2, Action<T1, T2>>(tempAction, param1, param2, action, success, error, millisecondsTimeout);
        }

        public void BeginActionInvoke<T1, T2, T3>(Action<T1, T2, T3> action, T1 param1, T2 param2, T3 param3, Action success, Action<Exception> error = null)
        {
            IProgress refrenceProgress = this._progress;
            this.ShowProgress(refrenceProgress);
            action.BeginInvoke(param1, param2, param3, iAsync =>
            {
                try
                {
                    ((iAsync as AsyncResult).AsyncDelegate as Action<T1, T2, T3>).EndInvoke(iAsync);
                    this.SendCompleted(success);
                }
                catch (Exception e)
                {
                    this.SendError(error, e);
                }
                finally
                {
                    this.CloseProgress(refrenceProgress);
                }
            }, null);
        }
        public void BeginActionInvoke<T1, T2, T3>(Action<T1, T2, T3> action, T1 param1, T2 param2, T3 param3, Action success, Action<Exception> error, int millisecondsTimeout)
        {
            IProgress progressRefence = this._progress;
            this.ShowProgress(progressRefence);
            System.Threading.Thread asyncExecuteThread = null;
            Action<Action<T1, T2, T3>, T1, T2, T3> delegateAction = new Action<Action<T1, T2, T3>, T1, T2, T3>((method, a, b, c) =>
            {
                asyncExecuteThread = System.Threading.Thread.CurrentThread;
                method.Invoke(a, b, c);
            });

            IAsyncResult asyncResult = delegateAction.BeginInvoke(action, param1, param2, param3, iAsync =>
            {
                try
                {
                    ((iAsync as AsyncResult).AsyncDelegate as Action<Action<T1, T2, T3>, T1, T2, T3>).EndInvoke(iAsync);
                    this.SendCompleted(success);
                }
                catch (Exception e)
                {
                    if ((Thread.CurrentThread.ThreadState & ThreadState.AbortRequested) == ThreadState.AbortRequested)
                    {
                        return;
                    }

                    if ((Thread.CurrentThread.ThreadState & ThreadState.Aborted) == ThreadState.Aborted)
                    {
                        return;
                    }

                    this.SendError(error, e);
                }
                finally
                {
                    this.CloseProgress(progressRefence);
                }
            }, null);

            Action monitorThread = () =>
            {
                if (!asyncResult.AsyncWaitHandle.WaitOne(millisecondsTimeout))
                {
                    if (asyncExecuteThread != null)
                    {
                        asyncExecuteThread.Abort();
                    }

                    this.CloseProgress(progressRefence);
                    this.SendError(error, new TimeoutException(string.Format("Timeout : {0} milliseconds.", millisecondsTimeout)));
                }
            };

            monitorThread.BeginInvoke(null, null);
        }

        // Async Func Delegate
        public void BeginFuncInvoke<TResult>(Func<TResult> action, Action<TResult> success, Action<Exception> error = null)
        {
            Func<Func<TResult>, TResult> tempFunc = new Func<Func<TResult>, TResult>(func =>
            {
                return func.Invoke();
            });

            this.BeginFuncInvoke<Func<TResult>, TResult>(tempFunc, action, success, error);
        }
        public void BeginFuncInvoke<TResult>(Func<TResult> action, Action<TResult> success, Action<Exception> error, int millisecondsTimeout)
        {
            Func<Func<TResult>, TResult> tempFunc = new Func<Func<TResult>, TResult>(func =>
            {
                return func.Invoke();
            });

            this.BeginFuncInvoke<Func<TResult>, TResult>(tempFunc, action, success, error, millisecondsTimeout);
        }

        public void BeginFuncInvoke<T1, TResult>(Func<T1, TResult> action, T1 param1, Action<TResult> success, Action<Exception> error = null)
        {
            Func<T1, Func<T1, TResult>, TResult> tempFunc = new Func<T1, Func<T1, TResult>, TResult>((p1, func) =>
            {
                return func.Invoke(p1);
            });

            this.BeginFuncInvoke<T1, Func<T1, TResult>, TResult>(tempFunc, param1, action, success, error);
        }
        public void BeginFuncInvoke<T1, TResult>(Func<T1, TResult> action, T1 param1, Action<TResult> success, Action<Exception> error, int millisecondsTimeout)
        {
            Func<T1, Func<T1, TResult>, TResult> tempFunc = new Func<T1, Func<T1, TResult>, TResult>((p1, func) =>
            {
                return func.Invoke(p1);
            });

            this.BeginFuncInvoke<T1, Func<T1, TResult>, TResult>(tempFunc, param1, action, success, error, millisecondsTimeout);
        }

        public void BeginFuncInvoke<T1, T2, TResult>(Func<T1, T2, TResult> action, T1 param1, T2 param2, Action<TResult> success, Action<Exception> error = null)
        {
            Func<T1, T2, Func<T1, T2, TResult>, TResult> tempFunc = new Func<T1, T2, Func<T1, T2, TResult>, TResult>((p1, p2, func) =>
            {
                return func.Invoke(p1, p2);
            });

            this.BeginFuncInvoke<T1, T2, Func<T1, T2, TResult>, TResult>(tempFunc, param1, param2, action, success, error);
        }
        public void BeginFuncInvoke<T1, T2, TResult>(Func<T1, T2, TResult> action, T1 param1, T2 param2, Action<TResult> success, Action<Exception> error, int millisecondsTimeout)
        {
            Func<T1, T2, Func<T1, T2, TResult>, TResult> tempFunc = new Func<T1, T2, Func<T1, T2, TResult>, TResult>((p1, p2, func) =>
            {
                return func.Invoke(p1, p2);
            });

            this.BeginFuncInvoke<T1, T2, Func<T1, T2, TResult>, TResult>(tempFunc, param1, param2, action, success, error, millisecondsTimeout);
        }

        public void BeginFuncInvoke<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> action, T1 param1, T2 param2, T3 param3, Action<TResult> success, Action<Exception> error = null)
        {
            IProgress progressRefence = this._progress;
            this.ShowProgress(progressRefence);
            action.BeginInvoke(param1, param2, param3, iAsync =>
            {
                try
                {
                    TResult obj = ((iAsync as AsyncResult).AsyncDelegate as Func<T1, T2, T3, TResult>).EndInvoke(iAsync);
                    this.SendCompleted(success, obj);
                }
                catch (Exception e)
                {
                    this.SendError(error, e);
                }
                finally
                {
                    this.CloseProgress(progressRefence);
                }
            }, null);
        }
        public void BeginFuncInvoke<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> action, T1 param1, T2 param2, T3 param3, Action<TResult> success, Action<Exception> error, int millisecondsTimeout)
        {
            IProgress progressRefence = this._progress;
            this.ShowProgress(progressRefence);
            System.Threading.Thread asyncExecuteThread = null;
            Func<Func<T1, T2, T3, TResult>, T1, T2, T3, TResult> delegateFunc = (method, a, b, c) =>
            {
                asyncExecuteThread = Thread.CurrentThread;
                return method.Invoke(a, b, c);
            };

            var asyncResult = delegateFunc.BeginInvoke(action, param1, param2, param3, iAsync =>
            {
                try
                {
                    TResult obj = ((iAsync as AsyncResult).AsyncDelegate as Func<Func<T1, T2, T3, TResult>, T1, T2, T3, TResult>).EndInvoke(iAsync);
                    this.SendCompleted(success, obj);
                }
                catch (Exception e)
                {
                    if ((Thread.CurrentThread.ThreadState & ThreadState.AbortRequested) == ThreadState.AbortRequested)
                    {
                        return;
                    }

                    if ((Thread.CurrentThread.ThreadState & ThreadState.Aborted) == ThreadState.Aborted)
                    {
                        return;
                    }

                    this.SendError(error, e);
                }
                finally
                {
                    this.CloseProgress(progressRefence);
                }
            }, null);

            Action monitorThread = () =>
            {
                if (!asyncResult.AsyncWaitHandle.WaitOne(millisecondsTimeout))
                {
                    if (asyncExecuteThread != null)
                    {
                        asyncExecuteThread.Abort();
                    }

                    this.CloseProgress(progressRefence);
                    this.SendError(error, new TimeoutException(string.Format("Timeout : {0} milliseconds.", millisecondsTimeout)));
                }
            };

            monitorThread.BeginInvoke(null, null);
        }

        // Common
        private void ShowProgress(IProgress progress)
        {
            if (progress == null)
            {
                return;
            }

            if (this._syncContext != null)
            {
                this._syncContext.Send(state =>
                {
                    progress.Show();
                }, null);
            }
            else
            {
                progress.Show();
            }
        }
        private void CloseProgress(IProgress progress)
        {
            if (progress == null)
            {
                return;
            }

            if (this._syncContext != null)
            {
                this._syncContext.Send(state =>
                {
                    progress.Close();
                }, null);
            }
            else
            {
                progress.Close();
            }
        }
        private void SendError(Action<Exception> error, Exception e)
        {
            if (error != null)
            {
                if (this._syncContext != null)
                {
                    this._syncContext.Send(state =>
                    {
                        error.Invoke(e);
                    }, null);
                }
                else
                {
                    error.Invoke(e);
                }
            }
        }
        private void SendCompleted<T>(Action<T> success, T obj)
        {
            if (success != null)
            {
                if (this._syncContext != null)
                {
                    this._syncContext.Send(state =>
                    {
                        success.Invoke(obj);
                    }, null);
                }
                else
                {
                    success.Invoke(obj);
                }
            }
        }
        private void SendCompleted(Action success)
        {
            if (success != null)
            {
                if (this._syncContext != null)
                {
                    this._syncContext.Send(state =>
                    {
                        success.Invoke();
                    }, null);
                }
                else
                {
                    success.Invoke();
                }
            }
        }
    }
}
