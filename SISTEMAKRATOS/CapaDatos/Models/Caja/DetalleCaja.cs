using sharedDatabase.Models.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace sharedDatabase.Models.Caja
{
    public class DetalleCaja
    {
        public int Id { get; set; }
        public int CajaId { get; set; }
        public Guid? FacturaId { get; set; }
        public Guid? CompraId { get; set; }
        public string Descripcion { get; set; }

        //public decimal Ingreso { get; set; } 

        public decimal Efectivo { get; set; }
        public decimal Cheques { get; set; }
        public decimal TarjetaCredito { get; set; }
        public decimal TarjetaDebito { get; set; } 



        public decimal Egreso { get; set; }



        public Caja Caja { get; set; }
        public Factura Factura { get; set; }
        public Compra Compra { get; set; }
        public decimal Transferencia { get; set; }
    }
}
