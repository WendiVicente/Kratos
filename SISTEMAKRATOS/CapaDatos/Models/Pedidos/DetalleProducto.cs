using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Pedidos
{
    public class DetalleProducto
    {
        public int Id { get; set; }
        public string noDocumento { get; set; }
        public int ProductoId { get; set; }
        public int DetalleId { get; set; }
        public string TipoDetalle { get; set; }
        public string Detalle { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaDocumento { get; set; }
    }
}
