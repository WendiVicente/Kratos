using CapaDatos.Models.Productos.Combos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
   public class ListaCombosReporte
    {

        //
        //encabezado

        public Guid Id { get; set; }
        public string CodigoBarras { get; set; }
        public string SucursalId { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public int CategoriaId { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaMovimiento { get; set; }

        public decimal PrecioCompra { get; set; }
        public decimal PrecioMayorista { get; set; }
        public decimal Precioventa { get; set; }
        public decimal PrecioEntidadGubernamental { get; set; }
        public decimal PrecioCuentaClave { get; set; }
        public decimal PrecioRevendedor { get; set; }
        public decimal DescuentoEspecial { get; set; }
        public bool TieneColor { get; set; }
        public bool isActive { get; set; }

        //detalle 
        public int IdDetalleCombo { get; set; }

        public string DescripcionDetalle { get; set; }
        public int CantidadDetalle { get; set; }

        public string Color { get; set; }
        public string  Talla { get; set; }
       

    }
}
