using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Commands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Initialisierung des Commands mit Übergabe der beiden benötigten Methoden in Lamda-Schreibweise
            this.CloseCmd = new CustomCommand
                (
                    //parameter => (parameter as MainWindow).Width > 500,
                    delegate (object parameter) { return (parameter as MainWindow).Width > 500; },

                    //parameter => (parameter as MainWindow).Close()
                    delegate (object parameter) { (parameter as MainWindow).Close(); }
                );

            //Setzen des DataContext, damit die Kurzbindung an das Command funktioniert
            this.DataContext = this;
        }

        //Command-Property
        public CustomCommand CloseCmd { get; set; }
    }
}
