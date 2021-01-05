using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace StudentRegistration.Command
{
    internal class RelayCommand<T> : ICommand
    {
        private Action<T> _action;
        private Func<T, bool> _canExecute;
        public RelayCommand(Action<T> action, Func<T, bool> canExecute=null)
        {
            if (action == null) 
            {
                throw new ArgumentNullException();
            }
            _action = action;
            _canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _action((T)parameter);
        }
    }
}
