using CapaDatos.Models.Usuarios;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.CuentaCobrar
{
    public class NotaPago
    {
        public Guid Id { get; set; }
        public string NoDocumento { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public int MovimientoId { get; set; }
        public string UserId { get; set; }
        public Guid? FacturaId { get; set; }
        public Guid CuentaCBId { get; set; }
        public CuentaCB CuentaCB { get; set; }
        public Movimiento Movimiento { get; set; }
        public User  User { get; set; }
        public Factura Factura { get; set; }
    }
}
