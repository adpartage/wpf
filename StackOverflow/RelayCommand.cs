using System;
using System.Windows.Input;

namespace StackOverflow
{
    public class RelayCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Action<T> _executeHandler;
        private Func<T, bool> _canExecute;
        public RelayCommand(Action<T> executeHandler, Func<T, bool> canExecute)
        {
            _executeHandler = executeHandler;
            _canExecute = canExecute;
        }
        public RelayCommand(Action<T> methodToExecute)
            : this(methodToExecute, null)
        {
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute.Invoke((T)parameter);
        }

        public void Execute(object parameter)
        {
            _executeHandler?.Invoke((T)parameter);
        }
    }
}
