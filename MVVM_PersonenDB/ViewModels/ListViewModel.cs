using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_PersonenDB.ViewModels
{
    public class ListViewModel
    {
        //Command-Properties
        public CustomCommand NeuCmd { get; set; }
        public CustomCommand AendernCmd { get; set; }
        public CustomCommand LoeschenCmd { get; set; }

        //Listen-Property, welche auf die Liste des Models verlinkt
        public ObservableCollection<Model.Person> Personenliste { get { return Model.Person.Personenliste; } }

        public ListViewModel()
        {
            //Command-Definitionen

            //Löschen einer Person
            this.LoeschenCmd = new CustomCommand
                (
                    //CanExe: s.u.
                    p => p is Model.Person,

                    //Exe:
                    p =>
                    {
                        //Anzeige einer MessageBox, ob Löschvorgang wirklich gewollt ist
                        if (MessageBox.Show($"Soll {(p as Model.Person).Vorname} {(p as Model.Person).Nachname} wirklich gelöcht werden?", "Person löschen", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                            //Löschen der ausgewählten Person
                            Model.Person.Personenliste.Remove(p as Model.Person);
                    }
                 );

            //Ändern einer bestehenden Person
            this.AendernCmd = new CustomCommand
                (
                    //CanExe: Kann ausgeführt werden, wenn der Parameter (der im DataGrid ausgewählte Eintrag) eine Person ist.
                    //Fungiert als Null-Prüfung
                    p => p is Model.Person,

                    //Exe:
                    p =>
                    {
                        //Instanzieren eines neuen DetailViews
                        Views.DetailView neuePersonDialog = new Views.DetailView();
                        //Zuweisung eines neuen DetailViewModels als dessen DataContext
                        //sowie Zuweisung einer Kopie der ausgewählten Person in die 'AktuellePerson'-Property des neuen DetailViewModels
                        neuePersonDialog.DataContext = new DetailViewModel() { AktuellePerson = new Model.Person(p as Model.Person) };

                        //Ändern des Titels des neuen DetailViews
                        (neuePersonDialog as Views.DetailView).Title = "Ändere " + (p as Model.Person).Vorname + " " + (p as Model.Person).Nachname;

                        //Aufruf des DetailViews mit Überprüfung auf dessen DialogResult (wird true, wenn der Benutzer OK klickt)
                        if (neuePersonDialog.ShowDialog() == true)
                            //Austausch der (veränderten) Person-Kopie mit dem Original in der Liste
                            Model.Person.Personenliste[Model.Person.Personenliste.IndexOf(p as Model.Person)] = (neuePersonDialog.DataContext as DetailViewModel).AktuellePerson;
                    }
                );

            //Hinzufügen einer neuen Person
            this.NeuCmd = new CustomCommand
                (
                    //CanExe: kann immer ausgeführt werden
                    p => true,

                    //Exe:
                    p =>
                    {
                        //Instanzieren eines neuen DetailViews
                        Views.DetailView neuePersonDialog = new Views.DetailView();
                        //Zuweisung eines neuen DetailViewModels als dessen DataContext
                        //sowie Zuweisung einer neuen Person in die 'AktuellePerson'-Property des neuen DetailViewModels
                        neuePersonDialog.DataContext = new DetailViewModel() { AktuellePerson = new Model.Person() };

                        //Aufruf des DetailViews mit Überprüfung auf dessen DialogResult (wird true, wenn der Benutzer OK klickt)
                        if (neuePersonDialog.ShowDialog() == true)
                            //Hinzufügen der neuen Person zu Liste
                            Model.Person.Personenliste.Add((neuePersonDialog.DataContext as DetailViewModel).AktuellePerson);
                    }
                );
        }

    }
}
