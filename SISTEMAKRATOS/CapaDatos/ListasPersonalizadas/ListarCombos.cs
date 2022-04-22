using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListarCombos
    {
        public int ld { get; set; }
        public Guid IdCombo { get; set; }
       
        public string CodigoBarras { get; set; }
        public string Descripcion { get; set; }//3
        public int Stock { get; set; }

        public DateTime FechaInicio { get; set; }

        public decimal PrecioCompra { get; set; }
        public decimal PrecioMayorista { get; set; }
        public decimal Precioventa { get; set; }
        public decimal PrecioEntidadGubernamental { get; set; }
        public decimal PrecioCuentaClave { get; set; }
        public decimal PrecioRevendedor { get; set; }
        public decimal PromedioPrecioVenta { get; set; }
        public string SucursalId { get; set; }
        public bool Acciones { get; set; }

        public byte[] Imagen { get; set; }//15

    }
}
