using CapaDatos.Models.Cotizacion;
using CapaDatos.Models.ProductosToFacturar;
using CapaDatos.Models.Vales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharedDatabase.Models
{
    public class DetalleTomoEdicion
    {
        public DetalleTomoEdicion()
        {
            Productos = new List<Producto>();
            DetalleVales = new List<DetalleVale>();
            DetalleCotizaciones = new List<DetalleCotizacion>();
            SolicitudDetalles = new List<SolicitudDetalle>();
            DetalleFacturas = new List<DetalleFactura>();
        }

        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Tomo { get; set; }
        
        public string Edicion { get; set; }

        public int Stock { get; set; }

        public ICollection<Producto> Productos { get; set; }
        public ICollection<DetalleVale> DetalleVales { get; set; }
        public ICollection<DetalleCotizacion> DetalleCotizaciones { get; set; }
        public ICollection<SolicitudDetalle> SolicitudDetalles { get; set; }
        public ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
