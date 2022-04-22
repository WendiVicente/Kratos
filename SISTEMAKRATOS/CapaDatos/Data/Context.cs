using CapaDatos.Models.Sucursales;
using sharedDatabase.Models;
using sharedDatabase.Models.Caja;
using sharedDatabase.Models.Compras;
using sharedDatabase.Models.Proveedores;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using CapaDatos.Models.Usuarios;
using CapaDatos.Models.Recepciones;
using CapaDatos.Models.Clientes;
using CapaDatos.Models.Productos.Combos;
using CapaDatos.Models.Productos;
using CapaDatos.Models.Precios;
using CapaDatos.Models.Bancos;
using CapaDatos.Models.Personal;
using CapaDatos.Models.Proveedores;
using CapaDatos.Models.Recursos_Humanos;
using CapaDatos.Models.Productos.Promocion;
using CapaDatos.Models.Transacciones;
using CapaDatos.Models.Vales;
using CapaDatos.Models.Cotizacion;
using CapaDatos.Models.Pedidos;
using CapaDatos.Models.CuentaCobrar;
using WebApi;
using CapaDatos.Models.DocumentoSAT;
using CapaDatos.Models.Prestamos;
using CapaDatos.Models.Devoluciones;
using CapaDatos.Models.ProductosToFacturar;
//using CapaDatos.Models.Caja;

namespace CapaDatos.Data
{
    public class Context : IdentityDbContext<User>
    {
        public Context() : base("Sistema")
        {
            this.Database.CommandTimeout = 180;
        }

        //respuesta de FEl SAT
        public DbSet<DocumentoCertificadoSAT> DocumentoCertificadoSATs { get; set; }
        public DbSet<AnulacionCertificado> AnulacionCertificados { get; set; }
        public DbSet<Emisor> Emisors { get; set; }

        //productos
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<DetalleProducto> DetalleProductos { get; set; }
        public DbSet<ClienteCredito> ClienteCreditos { get; set; }
        //public DbSet<Marca> Marcas { get; set; }
        //public DbSet<NTipo> NTipos { get; set; }

        public  DbSet<PreciosDetallePeps> PreciosDetallePeps { get; set; }


        // ventas
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }




        //clientes
        public DbSet<Cliente> Clientes { get; set; }


        //Compras

        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetalleCompras { get; set; }

        // recepciones

        public DbSet<Recepcion> recepcions { get; set; }

        public DbSet<EstadoRecepcion> EstadoRecepciones { get; set; }
        public DbSet<DetalleRecepcion> DetalleRecepciones { get; set; }


        // Proveedores




        // caja

        public DbSet<DetalleCaja> DetalleCajas { get; set; }
        public DbSet<DetalleMonetario> DetalleMonetarios { get; set; }
        public DbSet<Caja> Cajas { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<DetallePago> DetallePago { get; set; }
        //clientes
        public DbSet<Tipos> Tipos { get; set; }
        public DbSet<CategoriaCliente> CategoriaClientes { get; set; }
        public DbSet<DetalleTomoEdicion> DetalleTomoEdicions { get; set; }

        //detalle color
        public DbSet<DetalleColor> detalleColors { get; set; }
        public DbSet<DetalleTalla> DetalleTallas { get; set; }
        public DbSet<DetalleColorTalla> DetalleColorTallas { get; set; }
        //combo
        public DbSet<Combo> Combos { get; set; }
        public DbSet<DetalleCombo> DetalleCombos { get; set; }
        //precios tipos
        public DbSet<TipoPrecio> TipoPrecios { get; set; }
        public DbSet<DetallePrecio> DetallePrecios { get; set; }

        //banco
        public DbSet<Banca> Banco { get; set; }

        //Personal
        public DbSet<Personal> Personals { get; set; }
        public DbSet<TipoContrato> TipoContratos { get; set; }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Puesto> Puestos { get; set; }

        //caracteristicas de proveedor
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Frecuencia> Frecuencias { get; set; }
        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<TipoProveedor> TipoProveedors { get; set; }

        //horarios
        public DbSet<Ausencia> Ausencias { get; set; }
        public DbSet<EmpleadoAusencia> EmpleadoAusencias { get; set; }
        public DbSet<EntradaSalida> EntradaSalidas { get; set; }
        public DbSet<HorarioAsignado> HorarioAsignados { get; set; }
        public DbSet<HorarioE> HorarioEs { get; set; }
        public DbSet<HorasExtras> HorasExtras { get; set; }
        public DbSet<MotivoPase> MotivoPases { get; set; }
        public DbSet<PaseEmpleado> PaseEmpleados { get; set; }
        public DbSet<Retraso> Retrasos { get; set; }
        public DbSet<TipoES> TipoEs { get; set; }
        public DbSet<TipoRetraso> TipoRetrasos { get; set; }

        //nuevos
        public DbSet<Promocion> Promociones { get; set; }
        public DbSet<DetallePromocion> DetallePromociones { get; set; }
        public DbSet<DescuentoPromos> DescuentoPromos { get; set; }
        public DbSet<CuentaBanco> CuentaBancos { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<TipoMovimiento> TipoMovimientos { get; set; }
        public DbSet<EstadosTransac> EstadosTransacs { get; set; }

        //Vales
        public DbSet<Vale> Vales { get; set; }
        public DbSet<DetalleVale> DetalleVales { get; set; }
        public DbSet<DetalleRebajas> DetalleRebajas { get; set; }
        public DbSet<AsignacionVale> AsignacionVales { get; set; }

        //cotizaciones

        public DbSet<Cotizacion> Cotizaciones { get; set; }
        public DbSet<DetalleCotizacion> DetalleCotizaciones { get; set; }

        //pedidos
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedidos> DetallePedidos { get; set; }

        // cuentas por cobrar
        public DbSet<CuentaCB> CuentaCBs { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<NotaPago> NotaPagos { get; set; }
        public DbSet<NotaCredito> NotaCreditos { get; set; }
        public DbSet<NotaDebito> NotaDebitos { get; set; }
        public DbSet<DetalleNotaCredito> DetalleNotaCreditos { get; set; }
        public DbSet<Talonario> Talonarios { get; set; }
        public DbSet<ProductosReserva> ProductosReservas { get; set; }

        //prestamos 

        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<TipoCredito> TipoCreditos { get; set; }
        public DbSet<MetodoAmortizacion> MetodoAmortizaciones { get; set; }
        public DbSet<CuotasCredito> CuotasCreditos { get; set; }
        public DbSet<RegistroPagoCuota> RegistroPagoCuotas { get; set; }

        // registro de ventas sin factura

        public DbSet<TemporalProductos> TemporalProductos { get; set; }
        public DbSet<SolicitudToFacturar> SolicitudToFacturar { get; set; }
        public DbSet<SolicitudDetalle> solicitudDetalles { get; set; }


    }
}
