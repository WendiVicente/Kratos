using CapaDatos.Models.Cotizacion;
using CapaDatos.Models.CuentaCobrar;
using CapaDatos.Models.Pedidos;
using CapaDatos.Models.Productos.Promocion;
using CapaDatos.Models.ProductosToFacturar;
using CapaDatos.Models.Sucursales;
using CapaDatos.Models.Vales;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Productos.Combos
{
    public class Combo
    {
        public Combo()
        {

            DetalleCombos = new List<DetalleCombo>();
            DetallePromociones = new List<DetallePromocion>();
            DetalleVales = new List<DetalleVale>();
            DetalleCotizaciones = new List<DetalleCotizacion>();
            DetallePedidos= new List<DetallePedidos>();
            DetalleFacturas = new List<DetalleFactura>();
            ProductosEnReserva = new List<ProductosReserva>();
            SolicitudDetalles = new List<SolicitudDetalle>();
            temporalProductostofacturar = new List<TemporalProductos>();
        }


        [Key]
        public Guid Id { get; set; }
        public string CodigoBarras { get; set; }
        public int? SucursalId { get; set; }
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
        public bool  isActive { get; set; }

        public Sucursal Sucursal { get; set; }


        public ICollection<DetalleCombo> DetalleCombos { get; set; }
        public ICollection<DetallePromocion> DetallePromociones { get; set; }
        public ICollection<DetalleVale> DetalleVales { get; set; }
        public ICollection<DetalleCotizacion> DetalleCotizaciones { get; set; }
        public ICollection<DetallePedidos> DetallePedidos { get; set; }
        public ICollection<DetalleFactura> DetalleFacturas { get; set; }

        public ICollection<ProductosReserva> ProductosEnReserva { get; set; }
        public byte[] Imagen { get; set; }
        public ICollection<SolicitudDetalle> SolicitudDetalles { get; set; }
        public ICollection<TemporalProductos> temporalProductostofacturar { get; set; }
    }
}
