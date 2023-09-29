using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = "Data Source=LAB1504-26\\SQLEXPRESS;Initial Catalog=Neptuno3;User ID=TecsupUser ;Password=123456";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("InsertarProductos12", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idproducto", int.Parse(txtIdProducto.Text));
                    cmd.Parameters.AddWithValue("@nombreproducto", txtNombreProducto.Text);
                    cmd.Parameters.AddWithValue("@idproveedor", int.Parse(txtIdProveedor.Text));
                    cmd.Parameters.AddWithValue("@idcategoria", int.Parse(txtIdCategoria.Text));
                    cmd.Parameters.AddWithValue("@cantidadunidad", txtCantpUni.Text);
                    cmd.Parameters.AddWithValue("@preciounidad", txtPreciopUnidad.Text);
                    cmd.Parameters.AddWithValue("@unidadesenexistencia", int.Parse(txtUniExistencia.Text));
                    cmd.Parameters.AddWithValue("@unidadesenpedido", int.Parse(txtUniPedido.Text));
                    cmd.Parameters.AddWithValue("@nivelnuevopedido", int.Parse(txtNuePedido.Text));
                    cmd.Parameters.AddWithValue("@suspendido", txtSuspendido.Text);
                    cmd.Parameters.AddWithValue("@categoriaproducto", txtCategoriaProducto.Text);
                    cmd.Parameters.AddWithValue("@estado", 1);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producto ingresada correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar la Producto: " + ex.Message);
            }
        }
    }
}
