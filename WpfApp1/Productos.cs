using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listado_Productos
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int IdProveedor { get; set; }
        public int IdCategoria { get; set; }
        public string CantidadPorUnidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int UnidadesEnExistencia { get; set; }
        public int UnidadesEnPedido { get; set; }
        public int NivelNuevoPedido { get; set; }
        public int Suspendido { get; set; }
        public string CategoriaProducto { get; set; }
    }

    public class Productos
    {
        public List<Producto> ListaProductos { get; set; }

        public Productos()
        {
            ListaProductos = new List<Producto>();
        }
    }
}
