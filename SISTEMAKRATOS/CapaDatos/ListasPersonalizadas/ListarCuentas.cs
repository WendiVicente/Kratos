using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
     public class ListarCuentas
    {
        public Guid Id { get; set; }
        public string NombreCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal MontoInicial { get; set; }
        public string BancaId { get; set; }
        public string Moneda { get; set; }
        public string Empresa { get; set; }

        public bool Diaria { get; set; }
        public bool Semanal { get; set; }
        public bool Mensual { get; set; }
        public bool Anual { get; set; }

        public string Estado { get; set; }
        public bool Acciones { get; set; }
    }
}
