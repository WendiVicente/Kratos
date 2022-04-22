using CapaDatos.Models.CuentaCobrar;
using CapaDatos.Models.Devoluciones;
using CapaDatos.Models.Usuarios;
using sharedDatabase.Models.Caja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharedDatabase.Models
{
    public class Factura
    {
        public Factura()
        {
            DetalleFacturas = new List<DetalleFactura>();
            DetalleCajas = new List<DetalleCaja>();
            NotaPagos = new List<NotaPago>();
            NotaCreditos = new List<NotaCredito>();
            NotaDebitos = new List<NotaDebito>();
        }

        public Guid Id { get; set; }
        public int? ClienteId { get; set; }
        public string UserId { get; set; }
        public string NoFactura { get; set; }
        public string Serie { get; set; }

        public DateTime FechaVenta {get;set;}

        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public string NIT { get; set; }

        public string TipoPago { get; set; }
        public string Vendedor { get; set; }

        public bool IsActive { get; set; }
        public bool TieneFel { get;set; }
        public Cliente Cliente { get; set; }
        public User User { get; set; }

        public ICollection<DetalleFactura> DetalleFacturas { get; set; }
        public ICollection<DetalleCaja> DetalleCajas { get; set; }
        public ICollection<NotaPago>NotaPagos { get; set; }
        public ICollection<NotaCredito> NotaCreditos { get; set; }
        public ICollection<NotaDebito> NotaDebitos { get; set; }

    }
}
