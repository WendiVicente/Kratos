using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListarNotasPago
    {
        public Guid Id { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string NoDocumento { get; set; }
        public string Descripcion { get; set; }
        public string Movimiento { get; set; }
        public decimal Monto { get; set; }
        
        public string Responsable { get; set; }

        public int MovimientoId { get; set; }
        public string UserId { get; set; }
        public int FacturaId { get; set; }
        public Guid CuentaCBId { get; set; }
        public string NoCuenta { get; set; }
       
    }
}
