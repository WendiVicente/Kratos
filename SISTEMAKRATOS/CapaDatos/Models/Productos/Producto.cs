using CapaDatos.Models.CuentaCobrar;
using CapaDatos.Models.Precios;
using CapaDatos.Models.Productos;
using CapaDatos.Models.Productos.Combos;
using CapaDatos.Models.Productos.Promocion;
using CapaDatos.Models.ProductosToFacturar;
using CapaDatos.Models.Sucursales;
using CapaDatos.Models.Vales;
using sharedDatabase.Models.Proveedores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace sharedDatabase.Models
{
    public class Producto
    {
        public Producto()
        {
            DetalleFacturas = new List<DetalleFactura>();
            DetalleColors = new List<DetalleColor>();
            DetalleCombos = new List<DetalleCombo>();
            TipoPrecios = new List<TipoPrecio>();
            DetallePromocions = new List<DetallePromocion>();
            DetalleVales = new List<DetalleVale>();
            DetalleTallas = new List<DetalleTalla>();
            DetalleColorTallas = new List<DetalleColorTalla>();
            ProductosEnReserva = new List<ProductosReserva>();
            SolicitudDetalles = new List<SolicitudDetalle>();
            temporalProductostofacturar = new List<TemporalProductos>();

        }

        public int Id { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [Required]
        public int SucursalId { get; set; }

        [Required]
        public string Descripcion { get; set; }
        public string DescripcionCorta { get; set; }

        //[Required, StringLength(50)]
        public string CodigoBarras { get; set; }
        
        public string Ubicacion { get; set; } // ubicacion donde se encuentra el producto

        //public bool ControlarStock { get; set; } 

        public decimal Utilidad { get; set; } // si quieres dejemosla la utilidad, para mientras.ok ok
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaModificacion { get; set; }

        public decimal PrecioVenta { get; set; }
        public decimal Coste { get; set; }

        public decimal PrecioMayorista { get; set; }
        //public decimal PrecioMinorista { get; set; }
        public decimal PrecioEntidadGubernamental { get; set; }
        public decimal PrecioCuentaClave { get; set; }
        public decimal PrecioRevendedor { get; set; }

        public decimal DescuentoEspecial { get; set; }
        public decimal Impuesto { get; set; }


        [Range(0, Int32.MaxValue)]
        public int Stock { get; set; }
        public int stockMinimo { get; set; }
        public bool StockControl { get; set; }
        public string Notas { get; set; }
        public bool Deleted { get; set; }  // por defecto es 0
        
        public bool PermitirVenta { get; set; }
        public bool PermitirCompra { get; set; } 
        public bool TieneColor { get; set; }
        public bool TieneTalla { get; set; }
        public string PeriodoMovimiento { get; set; }
        
      
        public Categoria Categoria { get; set; }
        public Sucursal Sucursal { get; set; }
        public ICollection<DetalleFactura> DetalleFacturas { get; set; }
        public ICollection<DetalleColor> DetalleColors { get; set; }
        public ICollection<DetalleCombo> DetalleCombos { get; set; }
        public ICollection<TipoPrecio> TipoPrecios { get; set; }
        public ICollection<DetallePromocion> DetallePromocions { get; set; }
        public ICollection<DetalleVale> DetalleVales { get; set; }

        public ICollection<DetalleTalla> DetalleTallas { get; set; }
        public ICollection<DetalleColorTalla> DetalleColorTallas { get; set; }
        public bool TieneEscalas { get; set; }
        public byte[] Imagen { get; set; }
        public ICollection<ProductosReserva> ProductosEnReserva { get; set; }
        public ICollection<SolicitudDetalle> SolicitudDetalles { get; set; }
        public ICollection<TemporalProductos> temporalProductostofacturar { get; set; }
        public int? ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }
        public string Marca { get; set; }
        public string Numeral { get; set; }
        public string UnidadMedida { get; set; }
    }

}
