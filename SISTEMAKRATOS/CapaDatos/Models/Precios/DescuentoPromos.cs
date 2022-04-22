using CapaDatos.Models.Productos.Promocion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Precios
{
    public class DescuentoPromos
    {
        public DescuentoPromos()
        {
            DetallePromocions = new List<DetallePromocion>();
        }
        public Guid Id { get; set; }
        public int Descuento { get; set; }

        public ICollection<DetallePromocion> DetallePromocions { get; set; }
    }
}
