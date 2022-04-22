using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas.VentasAcumuladas
{
    public class ListadoVentasProducto
    {
        public string Categoria { get; set; }
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public string Cliente { get; set;  }
        public int UnidadesVendidas { get; set; }
        public decimal Utilidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal CostoVenta { get; set; }
        public decimal Porcentaje { get; set; }
        public string UnidadMedida { get; set; }
        public Guid comboid { get; set; }
    }
}
