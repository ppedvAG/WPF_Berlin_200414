using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_PersonenDB
{
    public class CustomCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public delegate bool CanExecuteDelegate(object parameter);
        public delegate void ExecuteDelegate(object parameter);

        public CanExecuteDelegate CanExecuteMethode { get; set; }
        public ExecuteDelegate ExecuteMethode { get; set; }

        public CustomCommand(CanExecuteDelegate can, ExecuteDelegate exe)
        {
            this.CanExecuteMethode = can;
            this.ExecuteMethode = exe;
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteMethode(parameter);
        }

        public void Execute(object parameter)
        {
            ExecuteMethode(parameter);
        }

    }
}
