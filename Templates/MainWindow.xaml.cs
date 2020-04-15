using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Templates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Properties vom Typ ObservableCollection informieren die GUI automatisch über Veränderungen (z.B. neuer Listeneintrag). Sie eignen sich besonders gut
        //für eine Bindung an ein ItemControl (z.B. ComboBox, ListBox, DataGrid, ...)
        public ObservableCollection<Person> Personenliste { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Personenliste = new ObservableCollection<Person>();

            //Erstellen von Bsp-Daten
            Personenliste.Add(new Person() { Vorname = "Anna", Nachname = "Meier", Alter = 30 });
            Personenliste.Add(new Person() { Vorname = "Hugo", Nachname = "Müller", Alter = 34 });
            Personenliste.Add(new Person() { Vorname = "Hannes", Nachname = "Fischer", Alter = 56 });

            //Setzen des DataContext des Stackpanels auf dieses MainWindow-Objekt (Einfache Bindungen zu Properties in dieser Datei möglich)
            SplItemTemplateBsp.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Du hast geklickt");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Erhöhung des Alters der Person im DataContextes des StackPanels
            (SplDataContextBsp.DataContext as Person).Alter++;
        }

        private void BtnNeu_Click(object sender, RoutedEventArgs e)
        {
            //Hinzufügen einer neuen Person
            Personenliste.Add(new Person() { Vorname = "Marie", Nachname = "Fischer", Alter = 12 });
        }
    }
}
