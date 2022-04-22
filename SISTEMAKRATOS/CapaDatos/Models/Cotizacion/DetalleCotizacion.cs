using CapaDatos.Models.Productos;
using CapaDatos.Models.Productos.Combos;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Cotizacion
{
   public  class DetalleCotizacion
    {
       
        public Guid Id { get; set; }
        public int? ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal PrecioTotal { get; set; }
        public Guid CotizacionId { get; set; }
        public Guid? ComboId { get; set; }
        public int? DetalleColorId { get; set; }
        public int? DetalleTallaId { get; set; }
        public int? DetalleColorTallaId { get; set; }
        public int? DetalleTomoEdicionId { get; set; }
        public Cotizacion Cotizacion { get; set; }
        public Producto Producto { get; set; }
        public Combo Combo { get; set; }
        public DetalleColor DetalleColor { get; set; }
        public DetalleTalla DetalleTalla { get; set; }
        public DetalleColorTalla DetalleColorTalla { get; set; }
        public DetalleTomoEdicion DetalleTomoEdicion { get; set; }
        public decimal Descuento { get; set; }


    }
}
