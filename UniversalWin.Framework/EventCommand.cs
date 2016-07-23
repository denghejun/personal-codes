using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UniversalWin.Framework
{
    public class EventCommand : ICommand
    {
        private Action<object> _executeDelegate;

        private Func<object, bool> _canExecuteDelegate;

        public event EventHandler CanExecuteChanged;

        public EventCommand(Action<object> executeDelegate, Func<object, bool> canExecuteDelegate = null)
        {
            this._executeDelegate = executeDelegate;
            this._canExecuteDelegate = canExecuteDelegate;
        }

        public bool CanExecute(object parameter)
        {
            return this._canExecuteDelegate == null || this._canExecuteDelegate(parameter);
        }

        public void Execute(object parameter)
        {
            //if (this._executeDelegate != null&&this.CanExecute())
            //{
            //    this._executeDelegate(parameter);
            //}
        }

        public void RaiseCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
