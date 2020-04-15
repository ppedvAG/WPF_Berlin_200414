using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PersonenDB_Bsp
{
    public enum Gender { Männlich, Weiblich, Divers}
    public class Person
    {
		public Person()
		{
			this.Geburtsdatum = DateTime.Now;
		}

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


	}
}
