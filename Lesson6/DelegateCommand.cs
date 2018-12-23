using System;
using System.Windows.Input;

namespace Lesson6
{
    class DelegateCommand : ICommand
    {
        Action<object> _execute;
        Func<object, bool> _canExecute;

        public DelegateCommand(Action<object> executeAction) : this(executeAction, null)
        {
        }

        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteFunc)
        {
            _canExecute = canExecuteFunc;
            _execute = executeAction;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return CanExecute(parameter);
            return true;
        }

        public void Execute(object parameter)
        {
            _execute?.Invoke(parameter);
        }
    }
}
