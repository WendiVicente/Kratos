using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas.Devoluciones
{
    public class ListarNotasCredito
    {
        public string Estado { get; set; }
        public Guid Id { get; set; }
        public string NoDocumento { get; set; }
        
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public decimal Disponible { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public DateTime? FechaAceptacion { get; set; }
        public string NombreVendedor { get; set; }
        public Guid FacturaId { get; set; }
        public string NoFactura { get; set; }
        
       
    }
}
