using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharedDatabase.Models.Compras
{
    public class DetalleCompra
    {

        public DetalleCompra()
        {

        }

        public int Id { get; set; }
        public Guid CompraId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; } 
        public decimal BaseImponible { get; set; }
        public decimal Impuesto { get; set; }
        public decimal PrecioTotal { get; set; }

        public Producto Producto { get; set; }
        public Compra Compra { get; set; }

    }
}
