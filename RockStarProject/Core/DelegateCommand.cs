using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RockStarProject.Core
{
    public class DelegateCommand : ICommand
    {
        readonly Action<object> _execute;
        bool _canExecute;

        public DelegateCommand(Action<object> OnExecute, bool CanExecute = true)
        {
            _execute = OnExecute;
            _canExecute = CanExecute;
        }

        public DelegateCommand(Action OnExecute, bool CanExecute = true)
        {
            _execute = O => OnExecute?.Invoke();
            _canExecute = CanExecute;
        }
        public DelegateCommand()
        {

        }
        public virtual bool CanExecute(object Parameter) => _canExecute;

        public virtual void Execute(object Parameter) => _execute?.Invoke(Parameter);

        public void RaiseCanExecuteChanged(bool CanExecute)
        {
            if (_canExecute != CanExecute)
            {
                _canExecute = CanExecute;
                App.Current?.Dispatcher.Invoke(() =>
                {
                    CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                });
            }
        }
        public void NotifyCanExecuteIfNeeded(object parameter)
        {
            RaiseCanExecuteChanged(CanExecute(parameter));
        }
        public event EventHandler CanExecuteChanged;
    }
}
