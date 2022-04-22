using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListarProductos
    {
        // escribo lo que quiero listar en la vista, es personalizado
        // tiene que ser en orden

        public int Id { get; set; }
        public string CodigoReferencia { get; set; }
        public string Sucursal { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public int Stock { get; set; }
        public string PeriodoMovimiento { get; set; }
        public string InventarioBajo { get; set; }
        public DateTime FechaModificacion { get; set; }
        
        public string Estado { get; set; }
        public string IncluyeColor { get; set; }
        public string Talla { get; set; }

        public bool Escalas { get; set; }

       
        public decimal PrecioVenta { get; set; }

        public decimal PrecioMayorista { get; set; }

        public decimal PrecioEntidadGubernamental { get; set; }
        public decimal PrecioCuentaClave { get; set; }
        public decimal PrecioRevendedor { get; set; }
        public decimal DescuentoEspecial { get; set; }
        public decimal Coste { get; set; }

        public string Notas { get; set; }


        public string StockControl { get; set; }
      
        public string PermitirVenta { get; set; }
        public string PermitirCompra { get; set; }

        public string Ubicacion { get; set; }
        public DateTime FechaIngreso { get; set; }
        
        public decimal Impuesto { get; set; }
        public bool Deleted { get; set; }
        public bool  Acciones { get; set; }
        public byte[] Imagen { get; set; }//posicion 28 total 29
        
    }
}
