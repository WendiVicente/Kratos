using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListaDetallePago
    {
        public int Id { get; set; }
        public Guid? FacturaId { get; set; }
        public int CajaId { get; set; }
        public string Documento { get; set; }
        public string TipoPago { get; set; }
        public string Entidad { get; set; }
        public string Numero { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
