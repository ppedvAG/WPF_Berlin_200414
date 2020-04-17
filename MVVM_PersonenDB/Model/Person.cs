using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MVVM_PersonenDB.Model
{
    //Im Model-Teil eines MVVM-Programms werden die Buisness-Klassen abgelegt. Diese Klassen dürfen keine Referenzen auf die anderen MVVM-Teile haben.
    //Dieses Beispiel besteht nur aus einer Model-Klasse sowie einem Enumerator.

    //Enumerator zum Abbilden des Geschlechts
    public enum Gender { Männlich, Weiblich, Divers }

    //Model-Klasse 'Person' mit dem IDataErrorInfo-Interface zur Validierung der Benutzereingaben bezüglich der Klassenproperties
    public class Person : IDataErrorInfo
    {
        #region Statische Member
        //Statische Listenproperty zum Ablegen der geladenen Personen (ObservableCollection, damit die GUI über Veränderungen innerhalb der Liste
        //informiert wird)
        public static ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>();

        //Methode, welche Bsp-Daten generiert und damit den Zugriff auf eine Datenbank simuliert
        public static void LadePersonenliste()
        {
            Personenliste.Add(new Person() { Vorname = "Otto", Nachname = "Meier", Geburtsdatum = new DateTime(2002, 5, 12), Verheiratet = true, Geschlecht = Gender.Männlich, Lieblingsfarbe = Colors.DarkOliveGreen });
            Personenliste.Add(new Person() { Vorname = "Anna", Nachname = "Müller", Geburtsdatum = new DateTime(1989, 2, 1), Verheiratet = false, Geschlecht = Gender.Weiblich, Lieblingsfarbe = Colors.Blue });
            Personenliste.Add(new Person() { Vorname = "Jürgen", Nachname = "Fischer", Geburtsdatum = new DateTime(1978, 11, 24), Verheiratet = true, Geschlecht = Gender.Divers, Lieblingsfarbe = Colors.DeepPink });
        }
        #endregion

        #region Properties

        //Felder und Properties der 'Person'-Klasse

        private string vorname;
        public string Vorname
        {
            get { return vorname; }
            set { vorname = value; }
        }

        private string nachname;
        public string Nachname
        {
            get { return nachname; }
            set { nachname = value; }
        }

        private DateTime geburtsdatum;
        public DateTime Geburtsdatum
        {
            get { return geburtsdatum; }
            set { geburtsdatum = value; }
        }

        private bool verheiratet;
        public bool Verheiratet
        {
            get { return verheiratet; }
            set { verheiratet = value; }
        }

        private Color lieblingsfarbe;
        public Color Lieblingsfarbe
        {
            get { return lieblingsfarbe; }
            set { lieblingsfarbe = value; }
        }

        private Gender geschlecht;
        public Gender Geschlecht
        {
            get { return geschlecht; }
            set { geschlecht = value; }
        }

        //Durch das Interface geforderte Properties
        public string Error
        {
            get { return ""; }
        }

        //Property, welche die Validierungsfehler und deren Fehlermeldungen beinhaltet
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Vorname):
                        if (Vorname.Length <= 0 || Vorname.Length > 50) return "Bitte geben Sie Ihren Vornamen ein.";
                        if (!Vorname.All(x => Char.IsLetter(x))) return "Der Vorname darf nur Buchstaben enthalten.";
                        break;

                    case nameof(Nachname):
                        if (Nachname.Length <= 0 || Nachname.Length > 50) return "Bitte geben Sie Ihren Nachnamen ein.";
                        if (!Nachname.All(x => Char.IsLetter(x))) return "Der Nachname darf nur Buchstaben enthalten.";
                        break;

                    case nameof(Geburtsdatum):
                        if (Geburtsdatum > DateTime.Now) return "Das Geburtsdatum darf nicht in der Zukunft liegen.";
                        if (DateTime.Now.Year - Geburtsdatum.Year > 150) return "Das Geburtsdatum darf nicht mehr als 150 Jahre in der Vergangenheit liegen.";
                        break;

                    case nameof(Lieblingsfarbe):
                        if (Lieblingsfarbe.ToString().Equals("#00000000")) return "Wählen Sie Ihre Lieblingsfarbe aus.";
                        break;
                }
                return "";
            }
        }
        #endregion

        //Parameterloser Standartkonstruktor, welcher die leeren 'Person'-Objekte auf einen Startzustand setzt
        public Person()
        {
            //Die String-Eigenschaften werden auf "" initialisiert, um GUI-Fehler zu vermeiden
            this.Vorname = "";
            this.Nachname = "";
            //Die 'Gerburtsdatum'-Property wird auf das aktuelle Datum gesetzt, damit der Benutzer innerhalb der Auswahlmaske nicht so viel suchen muss
            this.Geburtsdatum = DateTime.Now;
        }

        //Kopierkonstruktor, welcher eine 1-zu-1-Kopie eines übergebenen 'Person'-Objekts erzeugt
        public Person(Person altePerson)
        {
            Vorname = altePerson.Vorname;
            Nachname = altePerson.Nachname;
            Verheiratet = altePerson.Verheiratet;
            Lieblingsfarbe = altePerson.Lieblingsfarbe;
            Geschlecht = altePerson.Geschlecht;
            Geburtsdatum = new DateTime(altePerson.Geburtsdatum.Year, altePerson.Geburtsdatum.Month, altePerson.Geburtsdatum.Day);
        }

    }
}
