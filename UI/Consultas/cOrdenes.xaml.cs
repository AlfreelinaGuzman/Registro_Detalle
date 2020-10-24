using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Registro_Detalle.BLL;
using Registro_Detalle.Entidades;

namespace Registro_Detalle.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cOrdenes.xaml
    /// </summary>
    public partial class cOrdenes : Window
    {
        public cOrdenes()
        {
            InitializeComponent();
        }
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Ordenes>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = OrdenesBLL.GetList(p => p.OrdenID == this.ToInt(CriterioTextBox.Text));
                        break;

                    case 1:
                        listado = OrdenesBLL.GetList(p => p.ProductosID == this.ToInt(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                listado = OrdenesBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }

        public int ToInt(string value)
        {
            int retorno = 0;

            int.TryParse(value, out retorno);

            return retorno;
        }

        private void DatosDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
