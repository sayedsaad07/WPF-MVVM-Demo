using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFMVVMv_NET4_0.Shared
{
   public class RelayCommand :ICommand
    {
       private Action<object> _Execute;
       private Predicate<object> _CanExecute;
       public RelayCommand(Action<object> execute, Predicate<object> canExecute)
       {
           _Execute = execute;
           _CanExecute = canExecute;
       }
        public bool CanExecute(object parameter)
        {
            return _CanExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _Execute.Invoke(parameter);
        }
    }
}
