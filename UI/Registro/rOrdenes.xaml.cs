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
using Registro_Detalle.Entidades;
using Registro_Detalle.BLL;
using Registro_Detalle.DAL;

namespace Registro_Detalle.UI.Registro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class rOrdenes: Window
    {
       Ordenes ordenes = new Ordenes();

        public rOrdenes ()
        {
            InitializeComponent();
           /* PrestamoIDComboBox.ItemsSource = PrestamoBLL.GetList();
            PrestamoIDComboBox.SelectedValuePath = "PrestamoID";
            PrestamoIDComboBox.DisplayMemberPath = "PrestamoID";*/
            this.DataContext = ordenes;
            OrdenIDTextBox.Text = "0";
        
        }

        private void Limpiar()
        {
            OrdenIDTextBox.Text = "0";
            FechaDatePickerTextBox.Text = Convert.ToString(DateTime.Now);

          // TotalTextBox_TextChanged.ItemsSouce = new List<MorasDetalle>();
            Actualizar();
        }

           private void Actualizar() 
        {
            this.DataContext = null;
            this.DataContext = ordenes;
        }

        private bool ExisteDB(){
            ordenes= OrdenesBLL.Buscar(Convert.ToInt32(OrdenIDTextBox.Text));
            return (ordenes != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            
            if (ordenes.OrdenID == 0)
            {
                paso = OrdenesBLL.Guardar(ordenes);
            }
            else
            {
                if (Existe())
                {
                    paso = OrdenesBLL.Guardar(ordenes);
                }
                else
                {
                    MessageBox.Show("No existe en la base de datos", "Error");
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Fallo al guardar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(OrdenIDTextBox.Text);

            Limpiar();

            if(MorasBLL.Eliminar(id))
                MessageBox.Show("Se elimino Correctamente");
            else
                MessageBox.Show(OrdenIDTextBox.Text,"No se pudo eliminar!");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Ordenes anterior = OrdenesBLL.Buscar(Convert.ToInt32(OrdenIDTextBox));

            if(anterior != null)
            {
                ordenes = anterior;
                Actualizar();
            }
            else
            {
                MessageBox.Show("No se encontro");
            }
        }

        private void AgregarBoton_Click(object sender, RoutedEventArgs e)
        {
            Contexto context = new Contexto();
            ordenes.Monto += Convert.ToDecimal(MontoTextBox.Text);
            ordenes.OrdenesDetalle.Add(new OrdenesDetalle(ordenes.OrdenID, Convert.ToInt32(SumplidorIDComboBox.SelectedValue), Convert.ToDecimal(MontoTextBox.Text)));
            

            this.DataContext = null;
            this.DataContext = ordenes;

            ValorTextBox.Clear();
        }

        private void RemoverBoton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                OrdenesDetalle mora = (OrdenesDetalle)DetalleDataGrid.SelectedValue;
                ordenes.Monto -= ordenes.Monto;
                ordenes.OrdenesDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                this.DataContext = null;
                this.DataContext = ordenes;
            }
        }
        private bool Existe()
        {
            Moras esValido = OrdenesBLL.Buscar(ordenes.OrdenID);

            return (esValido != null);
        }
    }
    }