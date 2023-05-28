using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FileDownloader.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public RelayCommand(Action<object> execute, Func<object, bool>? canExecute = null)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
#pragma warning disable CS8601 // Possible null reference assignment.
            _canExecute = canExecute;
#pragma warning restore CS8601 // Possible null reference assignment.
        }

        public bool CanExecute(object? parameter)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return _canExecute?.Invoke(parameter) ?? true;
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public void Execute(object? parameter)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            _execute(parameter);
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
