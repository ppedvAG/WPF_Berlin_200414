using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates
{
    //Das Interface INotifyPropertyChanged ist dafür verantwortlich, dass die GUI über Veränderungen in den Properties informiert wird
    //und somit diese Veränderungen abbilden kann.
    public class Person : INotifyPropertyChanged
    {
        public string Vorname { get; set; }

        public string Nachname { get; set; }

        private int alter;
        public int Alter
        {
            get { return alter; }
            //Aufruf des PropertyChanged-Events im Setter (dort wo die Veränderung durchgeführt wird) mit Übergabe des Event-Senders und der veränderten Property
            //(Das ? prüft die vorangegangene Variable darauf, ob sie initialisiert wurde und verhindert, dass eine NullException geworfen wird)
            set { alter = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Alter")); }
        }

        //Durch das Interface gefordertes Event
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
