using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
   public class ListarVentas
    {

        public DateTime FechaVenta { get; set; }
        public Guid Id { get; set; }
        //public string Cliente { get; set; }
        
        public string NoFactura { get; set; }
        public string Serie { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string NIT { get; set; }
        public string Usuario { get; set; }
        public string TipoPago { get; set; }
        public decimal? Total { get; set; }        

    }
}
