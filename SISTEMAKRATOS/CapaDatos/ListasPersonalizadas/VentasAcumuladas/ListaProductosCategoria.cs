using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.ListasPersonalizadas.VentasAcumuladas;

namespace CapaDatos.ListasPersonalizadas.VentasAcumuladas
{
    public class ListaProductosCategoria
    {
        public ListaProductosCategoria()
        {
            listadoVentas = new List<ListadoVentasProducto>();

        }
        public string CategoriaProducto { get; set; }

        public IList<ListadoVentasProducto> listadoVentas { get; set; }
    }
}
