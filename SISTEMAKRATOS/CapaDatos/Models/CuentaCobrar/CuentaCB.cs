using CapaDatos.Models.Sucursales;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.CuentaCobrar
{
    public class CuentaCB
    {
        public CuentaCB()
        {
            NotaPagos = new List<NotaPago>();
            Talonarios = new List<Talonario>();
            ProductosReservas = new List<ProductosReserva>();
        }
        public Guid Id { get; set; }
        public string  NoCuenta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public decimal SaldoActual { get; set; }
        public int ClienteId { get; set; }
        public int? SucursalId { get; set; }
        public bool IsActive { get; set; }

        public Cliente Cliente { get; set; }
        public Sucursal Sucursal { get; set; }
        public ICollection<NotaPago> NotaPagos { get; set; }
        public ICollection<Talonario> Talonarios { get; set; }
        public ICollection<ProductosReserva> ProductosReservas { get; set; }
    }
}
