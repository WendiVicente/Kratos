using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.CuentaCobrar
{
    public class Movimiento
    {
        public Movimiento()
        {
            NotaPagos = new List<NotaPago>();
           // NotaCreditos = new List<NotaCredito>();
        }
        public int Id { get; set; }
        public string tipoMovimiento { get; set; }
        public bool IsActive { get; set; }

        public ICollection<NotaPago> NotaPagos { get; set; }
       // public ICollection<NotaCredito> NotaCreditos { get; set; }
    }
}
