using System.Windows.Input;

namespace CryptoInfoApp.Helpers
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object>? _executeWithParam;
        private readonly Action? _execute;
        private readonly Func<object, bool>? _canExecuteWithParam;
        private readonly Func<bool>? _canExecute;

        public RelayCommand(Action<object> executeWithParam, Func<object, bool>? canExecuteWithParam = null)
        {
            _executeWithParam = executeWithParam;
            _canExecuteWithParam = canExecuteWithParam;
        }

        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (_canExecuteWithParam != null)
                return _canExecuteWithParam(parameter!);
            return _canExecute == null || _canExecute();
        }

        public void Execute(object? parameter)
        {
            if (_executeWithParam != null)
                _executeWithParam(parameter!);
            else
                _execute!();
        }
    }
}
