using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
   public  class ListarCajaDetalles
    {

        public int Id { get; set; }
        public int CajaId { get; set; }
        public Guid? FacturaId { get; set; }
        public Guid? CompraId { get; set; }
        public string Descripcion { get; set; }
        public decimal Efectivo { get; set; }
        public decimal Cheques { get; set; }
        public decimal TarjetaCredito { get; set; }
        public decimal TarjetaDebito { get; set; }
        public decimal Egreso { get; set; }
        public decimal Transferencias { get; set; }
      //  public decimal TotalEgresos { get; set; }



    }
}
