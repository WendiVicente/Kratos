using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Productos
{
    public class PreciosDetallePeps
    {

        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioMayorista { get; set; }
        public decimal PrecioEntidadGubernamental { get; set; }
        public decimal PrecioCuentaClave { get; set; }
        public decimal PrecioRevendedor { get; set; }
        public decimal Coste { get; set; }
        public DateTime FechaIngreso { get; set; }



    }
}
