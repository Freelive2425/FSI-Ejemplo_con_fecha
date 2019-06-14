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
using Entidades;
using Negocio;
namespace Presentacion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        nDatos dato = new nDatos();
        public MainWindow()
        {
            InitializeComponent();
            Mostrardatos();
        }
        private void Mostrardatos()
        {
            dgdatos.ItemsSource = dato.Listardatos();

        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            int cod;
            string nomb;
            decimal sueldo;
            DateTime d;
            List<eDatos> lista;
            lista = dato.Listardatos();
            cod = Convert.ToInt32(txtboxCodigo.Text);
            nomb = txtboxNombre.Text;
            sueldo = Convert.ToDecimal(txtboxSueldo.Text);
            d = (DateTime)dtfecha.SelectedDate;
            if (!lista.Exists(delegate (eDatos value)
             {
                 return value.Idpersona == cod;
             }))
            {
                MessageBox.Show(dato.Registrardatos(cod, nomb, sueldo, d));
                Mostrardatos();
                txtboxCodigo.Clear();
                txtboxNombre.Clear();
                txtboxSueldo.Clear();
                dtfecha.SelectedDate = null;
            }
            else
            {
                MessageBox.Show("El codigo ya existe");
            }
        }
    }
}
