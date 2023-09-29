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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private static List<Productos> ListarProductos()
        {
            List<Productos> productos = new List<Productos>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM productos"; // Cambia esto a tu consulta SQL real

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text; // Cambia a CommandType.StoredProcedure si estás usando un procedimiento almacenado
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Productos producto = new Productos
                                {
                                    IdProducto = reader.GetInt32(reader.GetOrdinal("idproducto")),
                                    NombreProducto = reader.GetString(reader.GetOrdinal("nombreproducto")),
                                    IdProveedor = reader.GetInt32(reader.GetOrdinal("idproveedor")),
                                    IdCategoria = reader.GetInt32(reader.GetOrdinal("idcategoria")),
                                    CantidadPorUnidad = reader.GetString(reader.GetOrdinal("cantidadPorUnidad")),
                                    PrecioUnitario = reader.GetDecimal(reader.GetOrdinal("preciounidad")),
                                    UnidadesEnExistencia = reader.GetInt32(reader.GetOrdinal("unidadesenexistencia")),
                                    UnidadesEnPedido = reader.GetInt32(reader.GetOrdinal("unidadesenpedido")),
                                    NivelNuevoPedido = reader.GetInt32(reader.GetOrdinal("nivelnuevopedido")),
                                    Suspendido = reader.GetInt32(reader.GetOrdinal("suspendido")),
                                    CategoriaProducto = reader.GetString(reader.GetOrdinal("categoriaproducto"))
                                };
                                productos.Add(producto);
                            }
                        }
                    }
                }
                connection.Close();
            }
            return productos;
        }
    }
}
