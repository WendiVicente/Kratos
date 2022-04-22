using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class CompraDetalleList
    {
      
        public int Id { get; set; }
        
        public string Referencia { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Impuesto { get; set; }
        public decimal BaseImponible { get; set; }
        public decimal Total { get; set; }
        public int productoId { get; set; }
    }
}
