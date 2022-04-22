using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListarCotizaciones
    {

        public Guid Id { get; set; }
        public string NoCotizacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Nit { get; set; }
        public string NombreVendedor { get; set; }
        public string Estado { get; set; } // 0 en peticion y 1 comprado

        public string Sucursal { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public DateTime FechaLimite { get; set; }
        public decimal Total { get; set; }
        public bool IsActive { get; set; } // anulado o no
        public int ClienteId { get; set; }
    }
}
