using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Commands
{
    //Commandklassen müssen das Interface ICommand implementieren
    public class CustomCommand : ICommand
    {
        //Diese Command-Klasse ist nicht spezialisiert. Sie kann über den Konstruktor mit beliebigen Methoden befüllt werden

        //Delegatedefinition
        public delegate bool CanExecuteDelegate(object parameter);
        public delegate void ExecuteDelegate(object parameter);


        //Eventanmeldung
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Eigenschaftsdefinitionen
        public CanExecuteDelegate CanExecuteMethode { get; set; }
        public ExecuteDelegate ExecuteMethode { get; set; }

        //Konstruktor
        public CustomCommand(CanExecuteDelegate can, ExecuteDelegate exe)
        {
            this.CanExecuteMethode = can;
            this.ExecuteMethode = exe;
        }

        //Methoden
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
