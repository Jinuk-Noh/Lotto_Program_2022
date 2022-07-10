using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lotto_Program_2022.ViewModel.Command
{
    public class DataRetrieveCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action _execute;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }

        public DataRetrieveCommand(Action execute)
        {
            _execute = execute;
        }
    }
}
