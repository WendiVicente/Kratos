using CapaDatos.Models.Productos;
using CapaDatos.Models.Productos.Combos;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.CuentaCobrar
{
   public class ProductosReserva
    {
        public Guid Id { get; set; }
        public int? ProductoId { get; set; }//null
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
        public Guid CuentaCBId { get; set; }
        public Guid? ComboId { get; set; }//null
        public int? DetalleColorId { get; set; }//null
        public int? DetalleTallaId { get; set; }//null
        public int? DetalleColorTallaId { get; set; }//null
        public bool IsActive { get; set; }
        public CuentaCB CuentaCB { get; set; }
        public Producto Producto { get; set; }
        public Combo Combo { get; set; }
        public DetalleColor DetalleColor { get; set; }
        public DetalleTalla DetalleTalla { get; set; }
        public DetalleColorTalla DetalleColorTalla { get; set; }


    }
}
