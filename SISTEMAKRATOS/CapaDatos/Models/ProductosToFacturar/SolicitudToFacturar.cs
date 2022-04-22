using CapaDatos.Models.Sucursales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos.Models.ProductosToFacturar
{
    public class SolicitudToFacturar
    {

        public SolicitudToFacturar()
        {
            SolicitudDetalles = new List<SolicitudDetalle>();
        }

        public Guid Id { get; set; }
        public string NoSolicitud { get; set; }
        public string NitCliente { get; set; }
        public string NombreCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string UserId { get; set; }
        public string Vendedor { get; set; }
        public DateTime FechaVenta { get; set; }
        public string Observaciones { get; set; }
        public int ClienteId { get; set; }
        public int? SucursalId { get; set; }
        public bool Estado { get; set; }

        public ICollection<SolicitudDetalle> SolicitudDetalles { get; set; }
        public Sucursal Sucursal { get; set; }

        //para indicar que los detalles se tomaron de Productos Temporales
        public bool? Temporales { get; set; }



    }
}
