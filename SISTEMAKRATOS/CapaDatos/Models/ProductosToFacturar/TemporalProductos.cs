using CapaDatos.Models.Productos;
using CapaDatos.Models.Productos.Combos;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.ProductosToFacturar
{
    public class TemporalProductos
    {
        public TemporalProductos()
        {

        }

        public int Id { get; set; }
        public int? ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
        public decimal SubTotal { get; set; }
        public decimal PrecioTotal { get; set; }
        public decimal Utilidad { get; set; }

        public int? DetalleColorId { get; set; }
        public int? DetalleTallaId { get; set; }
        public int? DetalleColorTallaId { get; set; }

        //public Guid FacturaId { get; set; }

        public Guid? ComboId { get; set; }
        public Producto Producto { get; set; }
        ///public Factura Factura { get; set; }
        public Combo Combo { get; set; }
        public DetalleColor DetalleColor { get; set; }
        public DetalleTalla DetalleTalla { get; set; }
        public DetalleColorTalla DetalleColorTalla { get; set; }
        public bool IsActive { get; set; }


    }
}
