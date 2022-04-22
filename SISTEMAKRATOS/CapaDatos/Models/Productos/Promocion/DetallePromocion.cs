using CapaDatos.Models.Precios;
using CapaDatos.Models.Productos.Combos;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Productos.Promocion
{
   public class DetallePromocion
    {
        public Guid Id { get; set; }
        public int? ProductoId { get; set; }
        public Guid PromocionId { get; set; }
        public Guid DescuentoPromosId { get; set; }
        public Guid? ComboId { get; set; }
        public Producto Producto { get; set; }
        public Promocion Promocion { get; set; }
        public DescuentoPromos DescuentoPromos { get; set; }
        public Combo Combo { get; set; }
        

    }
}
