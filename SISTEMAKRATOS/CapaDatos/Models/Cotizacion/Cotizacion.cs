using CapaDatos.Models.Sucursales;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Cotizacion
{
    public class Cotizacion
    {
        public Cotizacion()
        {
            DetalleCotizaciones = new List<DetalleCotizacion>();
           
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Nit { get; set; }
        public string NombreVendedor { get; set; }
        public bool Estado { get; set; } // 0 en peticion y 1 comprado
       
  
        public int? SucursalId { get; set; }

        public int ClienteId { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public DateTime FechaLimite { get; set; }
        public bool IsActive { get; set; } // anulado o no
        public Sucursal Sucursal { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<DetalleCotizacion> DetalleCotizaciones { get; set; }
        public string NoCotizacion { get; set; }

    }
}
