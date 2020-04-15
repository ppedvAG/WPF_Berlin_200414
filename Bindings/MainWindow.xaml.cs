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

namespace Bindings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TbxVier.Text = "Hallo";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Für die explizite Aktualisierung muss eine BindingExpression im CodeBehind erstellt werden und über die Methode UpdateSource() angefordert werden
            //Die BindingExpession wird per Übergabe der (statischen) DependencyProperty an die Methode GetBindingExpression() aus dem bindenen Objekt erhalten
            BindingExpression be = this.TbxVier.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
        }


    }
}
