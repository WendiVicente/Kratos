using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharedDatabase.Models.Caja
{ 
    public class DetallePago
    {
        public int Id { get; set; }
        public Guid ?FacturaId { get; set; }
        public int CajaId { get; set; }
        public string Documento { get; set; }
        public string Pago { get; set; }
        public string Entidad { get; set; }
        public string Numero { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

    }
}
