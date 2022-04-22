using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListarTransacciones
    {
        public Guid Id { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Solicitante { get; set; }

        public decimal Monto { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public string Sucursal { get; set; }

        public string CuentaOrigen { get; set; }
        public string CuentaDestino { get; set; }
 
        
        public string TipoMovimiento { get; set; } 
        public int? CajaId { get; set; }
        public string Responsable { get; set; }
        public bool Acciones { get; set; }





    }
}
