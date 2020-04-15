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

namespace PersonenDB_Bsp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public Person NeuePerson { get; set; }

        public DialogWindow()
        {
            InitializeComponent();

            this.NeuePerson = new Person();

            this.DataContext = this.NeuePerson;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            string ausgabe = NeuePerson.Vorname + " " + NeuePerson.Nachname + " (" + NeuePerson.Geschlecht + ")\n" + NeuePerson.Geburtsdatum.ToShortDateString() + "\n" + NeuePerson.Lieblingsfarbe.ToString();
            if (NeuePerson.Verheiratet) ausgabe = ausgabe + "\nIst verheiratet";
            if (MessageBox.Show(ausgabe + "\nAbspeichern?", NeuePerson.Vorname + " " + NeuePerson.Nachname, MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void BtnAbbruch_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Wirklich abbrechen?", "Abbruch", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                this.Close();
        }
    }
}
