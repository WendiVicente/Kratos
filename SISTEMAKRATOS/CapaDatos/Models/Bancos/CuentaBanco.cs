using CapaDatos.Models.Transacciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Bancos
{
   public class CuentaBanco
    {
        public CuentaBanco()
        {
            Transacciones = new List<Transaccion>();
        }
        public Guid Id { get; set; }
        public string NombreCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal MontoInicial { get; set; }
        public int BancaId { get; set; }
        public int Moneda { get; set; }
        public string Empresa { get; set; }

        public bool Diaria { get; set; }
        public bool Semanal { get; set; }
        public bool Mensual { get; set; }
        public bool Anual { get; set; }
       
        public bool IsActive { get; set; }

        public Banca Banca { get; set; }
        public ICollection<Transaccion> Transacciones { get; set; }

    }
}
