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
using System.Windows.Shapes;

namespace PersonenDB_Bsp
{
    /// <summary>
    /// Interaction logic for DbAnsicht.xaml
    /// </summary>
    public partial class DbAnsicht : Window
    {
        public ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>();

        public DbAnsicht()
        {
            InitializeComponent();

            Personenliste.Add(new Person() { Vorname = "Otto", Nachname = "Meier", Geburtsdatum = new DateTime(2002, 5, 12), Verheiratet = true, Geschlecht = Gender.Männlich, Lieblingsfarbe = Colors.DarkOliveGreen });
            Personenliste.Add(new Person() { Vorname = "Anna", Nachname = "Müller", Geburtsdatum = new DateTime(1989, 2, 1), Verheiratet = false, Geschlecht = Gender.Weiblich, Lieblingsfarbe = Colors.Blue });
            Personenliste.Add(new Person() { Vorname = "Jürgen", Nachname = "Fischer", Geburtsdatum = new DateTime(1978, 11, 24), Verheiratet = true, Geschlecht = Gender.Divers, Lieblingsfarbe = Colors.DeepPink });

            this.DataContext = this;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void New_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
