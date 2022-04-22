using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas.Prestamos
{
    public class ListarRegistroPagos
    {
        public Guid Id { get; set; }
        public string Nopago { get; set; }
        public DateTime FechaPago { get; set; }


        public decimal Importe { get; set; }
        public decimal Mora { get; set; }
        public Guid PrestamosId { get; set; }
        public int NoCuotaPagada { get; set; }

        
    }
}
