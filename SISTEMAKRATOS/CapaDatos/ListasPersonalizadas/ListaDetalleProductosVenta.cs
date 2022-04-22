using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListaDetalleProductosVenta
    {
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Ahorro { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }
}
