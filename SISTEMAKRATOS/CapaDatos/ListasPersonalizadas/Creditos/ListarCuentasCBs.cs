using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas.Creditos
{
    public class ListarCuentasCBs
    {
        public Guid Id { get; set; }
        public string NoCuenta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public decimal SaldoActual { get; set; }
        public string  Cliente { get; set; }
        public string  Apellido { get; set; }
        public string Sucursal { get; set; }
        public string Estado { get; set; }

    }
}
