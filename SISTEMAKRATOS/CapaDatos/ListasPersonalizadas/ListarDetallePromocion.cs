using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListarDetallePromocion
    {
        public Guid Id { get; set; }

        public string Referencia { get; set; }
        public string Descripcion { get; set; }
        public string Promocion { get; set; }
        public decimal Descuento { get; set; }
        public int ProductoId { get; set; }//5
        public Guid PromocionId { get; set; }
        public Guid DescuentoPromosId { get; set; }
        public Guid ComboId { get; set; }
        public string NombreCombo { get; set; }

    }
}
