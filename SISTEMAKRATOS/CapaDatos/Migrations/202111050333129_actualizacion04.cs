namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacion04 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnulacionCertificadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Mensaje = c.String(),
                        AcuseReciboSAT = c.String(),
                        CodigosSAT = c.String(),
                        ResponseDATA1 = c.String(),
                        ResponseDATA2 = c.String(),
                        ResponseDATA3 = c.String(),
                        Autorizacion = c.String(),
                        Serie = c.String(),
                        NUMERO = c.String(),
                        Fecha_DTE = c.DateTime(nullable: false),
                        NIT_EFACE = c.String(),
                        NOMBRE_EFACE = c.String(),
                        NIT_COMPRADOR = c.String(),
                        NOMBRE_COMPRADOR = c.String(),
                        BACKPROCESOR = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AsignacionVales",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ValeId = c.Guid(nullable: false),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Telefono = c.String(),
                        Nit = c.String(),
                        ClienteId = c.Int(),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Reciduo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.String(),
                        NoVale = c.Int(nullable: false),
                        FechaAsignacion = c.DateTime(nullable: false),
                        FechaCambio = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .ForeignKey("dbo.Vales", t => t.ValeId, cascadeDelete: true)
                .Index(t => t.ValeId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false),
                        CodigoCliente = c.String(),
                        Apellidos = c.String(),
                        Telefonos = c.String(),
                        Nit = c.String(),
                        Direccion = c.String(),
                        Alias = c.String(),
                        TiposId = c.Int(nullable: false),
                        CategoriaId = c.Int(),
                        SucursalId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        PermitirCredito = c.Boolean(nullable: false),
                        DPI = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoriaClientes", t => t.CategoriaId)
                .ForeignKey("dbo.Tipos", t => t.TiposId, cascadeDelete: true)
                .ForeignKey("dbo.Sucursals", t => t.SucursalId)
                .Index(t => t.TiposId)
                .Index(t => t.CategoriaId)
                .Index(t => t.SucursalId);
            
            CreateTable(
                "dbo.CategoriaClientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Categoria = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cotizacions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Telefono = c.String(),
                        Nit = c.String(),
                        NombreVendedor = c.String(),
                        Estado = c.Boolean(nullable: false),
                        SucursalId = c.Int(),
                        ClienteId = c.Int(nullable: false),
                        FechaRecepcion = c.DateTime(nullable: false),
                        FechaLimite = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        NoCotizacion = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Sucursals", t => t.SucursalId)
                .Index(t => t.SucursalId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.DetalleCotizacions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductoId = c.Int(),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CotizacionId = c.Guid(nullable: false),
                        ComboId = c.Guid(),
                        DetalleColorId = c.Int(),
                        DetalleTallaId = c.Int(),
                        DetalleColorTallaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DetalleColors", t => t.DetalleColorId)
                .ForeignKey("dbo.DetalleColorTallas", t => t.DetalleColorTallaId)
                .ForeignKey("dbo.DetalleTallas", t => t.DetalleTallaId)
                .ForeignKey("dbo.Comboes", t => t.ComboId)
                .ForeignKey("dbo.Cotizacions", t => t.CotizacionId, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.ProductoId)
                .Index(t => t.ProductoId)
                .Index(t => t.CotizacionId)
                .Index(t => t.ComboId)
                .Index(t => t.DetalleColorId)
                .Index(t => t.DetalleTallaId)
                .Index(t => t.DetalleColorTallaId);
            
            CreateTable(
                "dbo.Comboes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CodigoBarras = c.String(),
                        SucursalId = c.Int(),
                        Descripcion = c.String(),
                        Stock = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaMovimiento = c.DateTime(nullable: false),
                        PrecioCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioMayorista = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Precioventa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioEntidadGubernamental = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioCuentaClave = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioRevendedor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DescuentoEspecial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TieneColor = c.Boolean(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        Imagen = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sucursals", t => t.SucursalId)
                .Index(t => t.SucursalId);
            
            CreateTable(
                "dbo.DetalleComboes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComboId = c.Guid(nullable: false),
                        Referencia = c.String(),
                        Descripcion = c.String(),
                        Cantidad = c.Int(nullable: false),
                        DetalleColorId = c.Int(),
                        DetalleTallaId = c.Int(),
                        DetalleColorTallaId = c.Int(),
                        Producto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comboes", t => t.ComboId, cascadeDelete: true)
                .ForeignKey("dbo.DetalleColors", t => t.DetalleColorId)
                .ForeignKey("dbo.DetalleColorTallas", t => t.DetalleColorTallaId)
                .ForeignKey("dbo.DetalleTallas", t => t.DetalleTallaId)
                .ForeignKey("dbo.Productoes", t => t.Producto_Id)
                .Index(t => t.ComboId)
                .Index(t => t.DetalleColorId)
                .Index(t => t.DetalleTallaId)
                .Index(t => t.DetalleColorTallaId)
                .Index(t => t.Producto_Id);
            
            CreateTable(
                "dbo.DetalleColors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductoId = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                        Color = c.String(),
                        PrecioCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioMayorista = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioMinorista = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioEntidadGubernamental = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioCuentaClave = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioRevendedor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productoes", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.DetalleFacturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductoId = c.Int(),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Utilidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DetalleColorId = c.Int(),
                        DetalleTallaId = c.Int(),
                        DetalleColorTallaId = c.Int(),
                        FacturaId = c.Guid(nullable: false),
                        ComboId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comboes", t => t.ComboId)
                .ForeignKey("dbo.DetalleColors", t => t.DetalleColorId)
                .ForeignKey("dbo.DetalleColorTallas", t => t.DetalleColorTallaId)
                .ForeignKey("dbo.DetalleTallas", t => t.DetalleTallaId)
                .ForeignKey("dbo.Productoes", t => t.ProductoId)
                .ForeignKey("dbo.Facturas", t => t.FacturaId, cascadeDelete: true)
                .Index(t => t.ProductoId)
                .Index(t => t.DetalleColorId)
                .Index(t => t.DetalleTallaId)
                .Index(t => t.DetalleColorTallaId)
                .Index(t => t.FacturaId)
                .Index(t => t.ComboId);
            
            CreateTable(
                "dbo.DetalleColorTallas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductoId = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                        Color = c.String(),
                        Talla = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productoes", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.DetallePedidos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductoId = c.Int(),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PedidoId = c.Guid(nullable: false),
                        ComboId = c.Guid(),
                        DetalleColorId = c.Int(),
                        DetalleTallaId = c.Int(),
                        DetalleColorTallaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comboes", t => t.ComboId)
                .ForeignKey("dbo.DetalleColors", t => t.DetalleColorId)
                .ForeignKey("dbo.DetalleColorTallas", t => t.DetalleColorTallaId)
                .ForeignKey("dbo.DetalleTallas", t => t.DetalleTallaId)
                .ForeignKey("dbo.Pedidoes", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.ProductoId)
                .Index(t => t.ProductoId)
                .Index(t => t.PedidoId)
                .Index(t => t.ComboId)
                .Index(t => t.DetalleColorId)
                .Index(t => t.DetalleTallaId)
                .Index(t => t.DetalleColorTallaId);
            
            CreateTable(
                "dbo.DetalleTallas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductoId = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                        Talla = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productoes", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.DetalleVales",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductoId = c.Int(),
                        Cantidad = c.Int(nullable: false),
                        precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AsignacionValeId = c.Guid(nullable: false),
                        ComboId = c.Guid(),
                        DetalleColorId = c.Int(),
                        DetalleTallaId = c.Int(),
                        DetalleColorTallaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AsignacionVales", t => t.AsignacionValeId, cascadeDelete: true)
                .ForeignKey("dbo.Comboes", t => t.ComboId)
                .ForeignKey("dbo.DetalleColors", t => t.DetalleColorId)
                .ForeignKey("dbo.DetalleColorTallas", t => t.DetalleColorTallaId)
                .ForeignKey("dbo.DetalleTallas", t => t.DetalleTallaId)
                .ForeignKey("dbo.Productoes", t => t.ProductoId)
                .Index(t => t.ProductoId)
                .Index(t => t.AsignacionValeId)
                .Index(t => t.ComboId)
                .Index(t => t.DetalleColorId)
                .Index(t => t.DetalleTallaId)
                .Index(t => t.DetalleColorTallaId);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoriaId = c.Int(nullable: false),
                        SucursalId = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false),
                        DescripcionCorta = c.String(),
                        CodigoBarras = c.String(),
                        Ubicacion = c.String(),
                        Utilidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaIngreso = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        PrecioVenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Coste = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioMayorista = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioEntidadGubernamental = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioCuentaClave = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioRevendedor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DescuentoEspecial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Impuesto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Int(nullable: false),
                        stockMinimo = c.Int(nullable: false),
                        StockControl = c.Boolean(nullable: false),
                        Notas = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        PermitirVenta = c.Boolean(nullable: false),
                        PermitirCompra = c.Boolean(nullable: false),
                        TieneColor = c.Boolean(nullable: false),
                        TieneTalla = c.Boolean(nullable: false),
                        PeriodoMovimiento = c.String(),
                        TieneEscalas = c.Boolean(nullable: false),
                        Imagen = c.Binary(),
                        ProveedorId = c.Int(),
                        Marca = c.String(),
                        Numeral = c.String(),
                        UnidadMedida = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Proveedors", t => t.ProveedorId)
                .ForeignKey("dbo.Sucursals", t => t.SucursalId, cascadeDelete: true)
                .Index(t => t.CategoriaId)
                .Index(t => t.SucursalId)
                .Index(t => t.ProveedorId);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Inactivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetallePromocions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductoId = c.Int(),
                        PromocionId = c.Guid(nullable: false),
                        DescuentoPromosId = c.Guid(nullable: false),
                        ComboId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comboes", t => t.ComboId)
                .ForeignKey("dbo.DescuentoPromos", t => t.DescuentoPromosId, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.ProductoId)
                .ForeignKey("dbo.Promocions", t => t.PromocionId, cascadeDelete: true)
                .Index(t => t.ProductoId)
                .Index(t => t.PromocionId)
                .Index(t => t.DescuentoPromosId)
                .Index(t => t.ComboId);
            
            CreateTable(
                "dbo.DescuentoPromos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descuento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Promocions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FechaInicio = c.DateTime(nullable: false),
                        Descripcion = c.String(),
                        SucursalId = c.Int(),
                        FechaFin = c.DateTime(nullable: false),
                        HoraInicio = c.String(),
                        HoraFin = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sucursals", t => t.SucursalId)
                .Index(t => t.SucursalId);
            
            CreateTable(
                "dbo.Sucursals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreSucursal = c.String(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                        NombreEncargado = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cajas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaApertura = c.DateTime(nullable: false),
                        FechaCierre = c.DateTime(),
                        MontoApertura = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstadoCaja = c.Boolean(nullable: false),
                        SucursalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sucursals", t => t.SucursalId, cascadeDelete: true)
                .Index(t => t.SucursalId);
            
            CreateTable(
                "dbo.DetalleCajas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CajaId = c.Int(nullable: false),
                        FacturaId = c.Guid(),
                        CompraId = c.Guid(),
                        Descripcion = c.String(),
                        Efectivo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cheques = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TarjetaCredito = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TarjetaDebito = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Egreso = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Transferencia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cajas", t => t.CajaId, cascadeDelete: true)
                .ForeignKey("dbo.Compras", t => t.CompraId)
                .ForeignKey("dbo.Facturas", t => t.FacturaId)
                .Index(t => t.CajaId)
                .Index(t => t.FacturaId)
                .Index(t => t.CompraId);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProveedorId = c.Int(nullable: false),
                        FechaLimite = c.DateTime(nullable: false),
                        NoComprobante = c.String(),
                        NombreVendedor = c.String(),
                        FechaRecepcion = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        SucursalId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Proveedors", t => t.ProveedorId, cascadeDelete: true)
                .ForeignKey("dbo.Sucursals", t => t.SucursalId)
                .Index(t => t.ProveedorId)
                .Index(t => t.SucursalId);
            
            CreateTable(
                "dbo.DetalleCompras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompraId = c.Guid(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BaseImponible = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Impuesto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Compras", t => t.CompraId, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.CompraId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Direccion = c.String(),
                        Correo = c.String(),
                        Telefonos = c.String(),
                        Telefonos2 = c.String(),
                        Celular = c.String(),
                        Celular2 = c.String(),
                        Nit = c.String(),
                        NoCuentaBancaria = c.String(),
                        Ingreso = c.DateTime(nullable: false),
                        Observaciones = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        SucursalId = c.Int(),
                        BancoId = c.Int(nullable: false),
                        RubroId = c.Int(nullable: false),
                        FrecuenciaId = c.Int(nullable: false),
                        TipoProveedorId = c.Int(nullable: false),
                        RazonSocial = c.String(),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Moneda = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bancas", t => t.BancoId, cascadeDelete: true)
                .ForeignKey("dbo.Frecuencias", t => t.FrecuenciaId, cascadeDelete: true)
                .ForeignKey("dbo.Rubroes", t => t.RubroId, cascadeDelete: true)
                .ForeignKey("dbo.Sucursals", t => t.SucursalId)
                .ForeignKey("dbo.TipoProveedors", t => t.TipoProveedorId, cascadeDelete: true)
                .Index(t => t.SucursalId)
                .Index(t => t.BancoId)
                .Index(t => t.RubroId)
                .Index(t => t.FrecuenciaId)
                .Index(t => t.TipoProveedorId);
            
            CreateTable(
                "dbo.Bancas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Entidad = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CuentaBancoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NombreCuenta = c.String(),
                        NumeroCuenta = c.String(),
                        TipoCuenta = c.String(),
                        MontoInicial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BancaId = c.Int(nullable: false),
                        Moneda = c.Int(nullable: false),
                        Empresa = c.String(),
                        Diaria = c.Boolean(nullable: false),
                        Semanal = c.Boolean(nullable: false),
                        Mensual = c.Boolean(nullable: false),
                        Anual = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bancas", t => t.BancaId, cascadeDelete: true)
                .Index(t => t.BancaId);
            
            CreateTable(
                "dbo.Transaccions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FechaSolicitud = c.DateTime(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstadosTransacId = c.Int(nullable: false),
                        Observaciones = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        TipoMovimientoId = c.Int(nullable: false),
                        CuentaOrigenId = c.Guid(),
                        CajaId = c.Int(),
                        CuentaBancoId = c.Guid(),
                        SucursalId = c.Int(),
                        UsuarioId = c.String(maxLength: 128),
                        Responsable = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CuentaBancoes", t => t.CuentaBancoId)
                .ForeignKey("dbo.EstadosTransacs", t => t.EstadosTransacId, cascadeDelete: true)
                .ForeignKey("dbo.Sucursals", t => t.SucursalId)
                .ForeignKey("dbo.TipoMovimientoes", t => t.TipoMovimientoId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.EstadosTransacId)
                .Index(t => t.TipoMovimientoId)
                .Index(t => t.CuentaBancoId)
                .Index(t => t.SucursalId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.EstadosTransacs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Estado = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoMovimientoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Movimiento = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        SucursalId = c.Int(nullable: false),
                        Privilegios = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sucursals", t => t.SucursalId, cascadeDelete: true)
                .Index(t => t.SucursalId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClienteId = c.Int(),
                        UserId = c.String(maxLength: 128),
                        NoFactura = c.String(),
                        Serie = c.String(),
                        FechaVenta = c.DateTime(nullable: false),
                        Nombre = c.String(),
                        Direccion = c.String(),
                        NIT = c.String(),
                        TipoPago = c.String(),
                        Vendedor = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        TieneFel = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.ClienteId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.NotaCreditoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NoDocumento = c.String(),
                        MontoDisponible = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descripcion = c.String(),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaTransaccion = c.DateTime(nullable: false),
                        FechaAceptacion = c.DateTime(),
                        NombreVendedor = c.String(),
                        FacturaId = c.Guid(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        NcbyItem = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Facturas", t => t.FacturaId, cascadeDelete: true)
                .Index(t => t.FacturaId);
            
            CreateTable(
                "dbo.DetalleNotaCreditoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotaCreditoId = c.Guid(nullable: false),
                        Descripcion = c.String(),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductoId = c.Int(),
                        ComboId = c.Guid(),
                        DetalleColorId = c.Int(),
                        DetalleTallaId = c.Int(),
                        TallayColorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NotaCreditoes", t => t.NotaCreditoId, cascadeDelete: true)
                .Index(t => t.NotaCreditoId);
            
            CreateTable(
                "dbo.NotaDebitoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NoDocumento = c.String(),
                        MontoDisponible = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descripcion = c.String(),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaTransaccion = c.DateTime(nullable: false),
                        FechaAceptacion = c.DateTime(),
                        NombreVendedor = c.String(),
                        FacturaId = c.Guid(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        NdbyItem = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Facturas", t => t.FacturaId, cascadeDelete: true)
                .Index(t => t.FacturaId);
            
            CreateTable(
                "dbo.NotaPagoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NoDocumento = c.String(),
                        Descripcion = c.String(),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaTransaccion = c.DateTime(nullable: false),
                        MovimientoId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        FacturaId = c.Guid(),
                        CuentaCBId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CuentaCBs", t => t.CuentaCBId, cascadeDelete: true)
                .ForeignKey("dbo.Facturas", t => t.FacturaId)
                .ForeignKey("dbo.Movimientoes", t => t.MovimientoId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.MovimientoId)
                .Index(t => t.UserId)
                .Index(t => t.FacturaId)
                .Index(t => t.CuentaCBId);
            
            CreateTable(
                "dbo.CuentaCBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NoCuenta = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        SaldoActual = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClienteId = c.Int(nullable: false),
                        SucursalId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Sucursals", t => t.SucursalId)
                .Index(t => t.ClienteId)
                .Index(t => t.SucursalId);
            
            CreateTable(
                "dbo.ProductosReservas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductoId = c.Int(),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CuentaCBId = c.Guid(nullable: false),
                        ComboId = c.Guid(),
                        DetalleColorId = c.Int(),
                        DetalleTallaId = c.Int(),
                        DetalleColorTallaId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comboes", t => t.ComboId)
                .ForeignKey("dbo.CuentaCBs", t => t.CuentaCBId, cascadeDelete: true)
                .ForeignKey("dbo.DetalleColors", t => t.DetalleColorId)
                .ForeignKey("dbo.DetalleColorTallas", t => t.DetalleColorTallaId)
                .ForeignKey("dbo.DetalleTallas", t => t.DetalleTallaId)
                .ForeignKey("dbo.Productoes", t => t.ProductoId)
                .Index(t => t.ProductoId)
                .Index(t => t.CuentaCBId)
                .Index(t => t.ComboId)
                .Index(t => t.DetalleColorId)
                .Index(t => t.DetalleTallaId)
                .Index(t => t.DetalleColorTallaId);
            
            CreateTable(
                "dbo.Talonarios",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Correlativo = c.Int(nullable: false),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaCambio = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        CuentaCBId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CuentaCBs", t => t.CuentaCBId, cascadeDelete: true)
                .Index(t => t.CuentaCBId);
            
            CreateTable(
                "dbo.Movimientoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tipoMovimiento = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Vales",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descripcion = c.String(),
                        FechaRecepcion = c.DateTime(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SucursalId = c.Int(),
                        UserId = c.String(maxLength: 128),
                        TiposId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        NoVale = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sucursals", t => t.SucursalId)
                .ForeignKey("dbo.Tipos", t => t.TiposId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.SucursalId)
                .Index(t => t.UserId)
                .Index(t => t.TiposId);
            
            CreateTable(
                "dbo.Tipos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipoCliente = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetallePrecios",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TipoPrecioId = c.Guid(nullable: false),
                        TiposId = c.Int(nullable: false),
                        Escala = c.String(),
                        RangoInicio = c.Int(nullable: false),
                        RangoFinal = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tipos", t => t.TiposId, cascadeDelete: true)
                .ForeignKey("dbo.TipoPrecios", t => t.TipoPrecioId, cascadeDelete: true)
                .Index(t => t.TipoPrecioId)
                .Index(t => t.TiposId);
            
            CreateTable(
                "dbo.Frecuencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Periodo = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rubroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoProveedors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recepcions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SucursalId = c.Int(nullable: false),
                        CompraId = c.Guid(nullable: false),
                        EstadoRecepcionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Compras", t => t.CompraId, cascadeDelete: true)
                .ForeignKey("dbo.EstadoRecepcions", t => t.EstadoRecepcionId, cascadeDelete: true)
                .Index(t => t.CompraId)
                .Index(t => t.EstadoRecepcionId);
            
            CreateTable(
                "dbo.DetalleRecepcions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecepcionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recepcions", t => t.RecepcionId, cascadeDelete: true)
                .Index(t => t.RecepcionId);
            
            CreateTable(
                "dbo.EstadoRecepcions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetalleMonetarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Moneda = c.Decimal(precision: 18, scale: 2),
                        Cantidad = c.Int(),
                        CajaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cajas", t => t.CajaId, cascadeDelete: true)
                .Index(t => t.CajaId);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Telefono = c.String(),
                        Nit = c.String(),
                        NombreVendedor = c.String(),
                        Estado = c.Boolean(nullable: false),
                        SucursalId = c.Int(),
                        ClienteId = c.Int(nullable: false),
                        FechaRecepcion = c.DateTime(nullable: false),
                        FechaLimite = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Sucursals", t => t.SucursalId)
                .Index(t => t.SucursalId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Personals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false),
                        Apellidos = c.String(),
                        Telefonos1 = c.String(),
                        Telefonos2 = c.String(),
                        Telefonos3 = c.String(),
                        Edad = c.Int(nullable: false),
                        Dpi = c.String(),
                        Nit = c.String(),
                        EstadoCivil = c.String(),
                        Direccion = c.String(),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaIngreso = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        HorarioId = c.Int(nullable: false),
                        ContratoId = c.Int(nullable: false),
                        SucursalId = c.Int(nullable: false),
                        PuestoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoContratoes", t => t.ContratoId, cascadeDelete: true)
                .ForeignKey("dbo.Horarios", t => t.HorarioId, cascadeDelete: true)
                .ForeignKey("dbo.Puestoes", t => t.PuestoId, cascadeDelete: true)
                .ForeignKey("dbo.Sucursals", t => t.SucursalId, cascadeDelete: true)
                .Index(t => t.HorarioId)
                .Index(t => t.ContratoId)
                .Index(t => t.SucursalId)
                .Index(t => t.PuestoId);
            
            CreateTable(
                "dbo.TipoContratoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmpleadoAusencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AusenciaId = c.Int(nullable: false),
                        PersonalId = c.Int(nullable: false),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFinal = c.DateTime(nullable: false),
                        Motivo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ausencias", t => t.AusenciaId, cascadeDelete: true)
                .ForeignKey("dbo.Personals", t => t.PersonalId, cascadeDelete: true)
                .Index(t => t.AusenciaId)
                .Index(t => t.PersonalId);
            
            CreateTable(
                "dbo.Ausencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EntradaSalidas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalId = c.Int(nullable: false),
                        TipoESId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Hora = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoES", t => t.TipoESId, cascadeDelete: true)
                .ForeignKey("dbo.Personals", t => t.PersonalId, cascadeDelete: true)
                .Index(t => t.PersonalId)
                .Index(t => t.TipoESId);
            
            CreateTable(
                "dbo.TipoES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Horarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Periodo = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HorarioAsignadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HorarioEId = c.Guid(nullable: false),
                        PersonalId = c.Int(nullable: false),
                        FechaAsignacion = c.DateTime(nullable: false),
                        CausaHorario = c.String(),
                        HorarioE_IdHorario = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HorarioEs", t => t.HorarioE_IdHorario)
                .ForeignKey("dbo.Personals", t => t.PersonalId, cascadeDelete: true)
                .Index(t => t.PersonalId)
                .Index(t => t.HorarioE_IdHorario);
            
            CreateTable(
                "dbo.HorarioEs",
                c => new
                    {
                        IdHorario = c.Guid(nullable: false),
                        Descripcion = c.String(),
                        HoraEntrada = c.String(),
                        HoraSalida = c.String(),
                        Lunes = c.Boolean(nullable: false),
                        Martes = c.Boolean(nullable: false),
                        Miercoles = c.Boolean(nullable: false),
                        Jueves = c.Boolean(nullable: false),
                        Viernes = c.Boolean(nullable: false),
                        Sabado = c.Boolean(nullable: false),
                        Domingo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdHorario);
            
            CreateTable(
                "dbo.HorasExtras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalId = c.Int(nullable: false),
                        Descripcion = c.String(),
                        HoraInicio = c.String(),
                        HorarioFinal = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        DiaCompleto = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personals", t => t.PersonalId, cascadeDelete: true)
                .Index(t => t.PersonalId);
            
            CreateTable(
                "dbo.PaseEmpleadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        HoraSalida = c.String(),
                        HoraEntrada = c.String(),
                        Descripcion = c.String(),
                        MotivoPaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MotivoPases", t => t.MotivoPaseId, cascadeDelete: true)
                .ForeignKey("dbo.Personals", t => t.PersonalId, cascadeDelete: true)
                .Index(t => t.PersonalId)
                .Index(t => t.MotivoPaseId);
            
            CreateTable(
                "dbo.MotivoPases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Motivo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Puestoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        DepartamentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departamentoes", t => t.DepartamentoId, cascadeDelete: true)
                .Index(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.Departamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Area = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Retrasoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalId = c.Int(nullable: false),
                        TipoRetrasoId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Minutos = c.String(),
                        Observacion = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personals", t => t.PersonalId, cascadeDelete: true)
                .ForeignKey("dbo.TipoRetrasoes", t => t.TipoRetrasoId, cascadeDelete: true)
                .Index(t => t.PersonalId)
                .Index(t => t.TipoRetrasoId);
            
            CreateTable(
                "dbo.TipoRetrasoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Retraso = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SolicitudDetalles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductoId = c.Int(),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DetalleColorId = c.Int(),
                        DetalleTallaId = c.Int(),
                        DetalleColorTallaId = c.Int(),
                        SolicitudToFacturarId = c.Guid(nullable: false),
                        ComboId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comboes", t => t.ComboId)
                .ForeignKey("dbo.DetalleColors", t => t.DetalleColorId)
                .ForeignKey("dbo.DetalleColorTallas", t => t.DetalleColorTallaId)
                .ForeignKey("dbo.DetalleTallas", t => t.DetalleTallaId)
                .ForeignKey("dbo.Productoes", t => t.ProductoId)
                .ForeignKey("dbo.SolicitudToFacturars", t => t.SolicitudToFacturarId, cascadeDelete: true)
                .Index(t => t.ProductoId)
                .Index(t => t.DetalleColorId)
                .Index(t => t.DetalleTallaId)
                .Index(t => t.DetalleColorTallaId)
                .Index(t => t.SolicitudToFacturarId)
                .Index(t => t.ComboId);
            
            CreateTable(
                "dbo.SolicitudToFacturars",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NoSolicitud = c.String(),
                        NombreCliente = c.String(),
                        UserId = c.String(),
                        Vendedor = c.String(),
                        FechaVenta = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TemporalProductos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductoId = c.Int(),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Utilidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DetalleColorId = c.Int(),
                        DetalleTallaId = c.Int(),
                        DetalleColorTallaId = c.Int(),
                        ComboId = c.Guid(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comboes", t => t.ComboId)
                .ForeignKey("dbo.DetalleColors", t => t.DetalleColorId)
                .ForeignKey("dbo.DetalleColorTallas", t => t.DetalleColorTallaId)
                .ForeignKey("dbo.DetalleTallas", t => t.DetalleTallaId)
                .ForeignKey("dbo.Productoes", t => t.ProductoId)
                .Index(t => t.ProductoId)
                .Index(t => t.DetalleColorId)
                .Index(t => t.DetalleTallaId)
                .Index(t => t.DetalleColorTallaId)
                .Index(t => t.ComboId);
            
            CreateTable(
                "dbo.TipoPrecios",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FechaInicio = c.DateTime(nullable: false),
                        ProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productoes", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.DetalleRebajas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AsignacionValeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AsignacionVales", t => t.AsignacionValeId, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.ProductoId)
                .Index(t => t.AsignacionValeId);
            
            CreateTable(
                "dbo.CuotasCreditoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoCuota = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        MontoSolicitado = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amortizacion = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Interes = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MontoCuotas = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ITF = c.String(),
                        Vence = c.DateTime(nullable: false),
                        Mora = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InteresesProyectados = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.String(),
                        Parcial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrestamosID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prestamos", t => t.PrestamosID, cascadeDelete: true)
                .Index(t => t.PrestamosID);
            
            CreateTable(
                "dbo.Prestamos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NoDocumento = c.String(),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TasaInteres = c.Int(nullable: false),
                        ImporteFinanciado = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NoCuotas = c.Int(nullable: false),
                        MontoCuotas = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeudaActual = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.String(),
                        Observaciones = c.String(),
                        FechaSolicitud = c.DateTime(nullable: false),
                        TipoCreditoId = c.Int(nullable: false),
                        AmortizacionId = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.MetodoAmortizacions", t => t.AmortizacionId, cascadeDelete: true)
                .ForeignKey("dbo.TipoCreditoes", t => t.TipoCreditoId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.TipoCreditoId)
                .Index(t => t.AmortizacionId)
                .Index(t => t.UsuarioId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.MetodoAmortizacions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Metodo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegistroPagoCuotas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nopago = c.String(),
                        FechaPago = c.DateTime(nullable: false),
                        Importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mora = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrestamosId = c.Guid(),
                        CuotasCreditoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CuotasCreditoes", t => t.CuotasCreditoId, cascadeDelete: true)
                .ForeignKey("dbo.Prestamos", t => t.PrestamosId)
                .Index(t => t.PrestamosId)
                .Index(t => t.CuotasCreditoId);
            
            CreateTable(
                "dbo.TipoCreditoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DocumentoCertificadoSATs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Mensaje = c.String(),
                        AcuseReciboSAT = c.String(),
                        CodigosSAT = c.String(),
                        ResponseDATA1 = c.String(),
                        ResponseDATA2 = c.String(),
                        ResponseDATA3 = c.String(),
                        Autorizacion = c.String(),
                        Serie = c.String(),
                        NUMERO = c.String(),
                        Fecha_DTE = c.DateTime(nullable: false),
                        NIT_EFACE = c.String(),
                        NOMBRE_EFACE = c.String(),
                        NIT_COMPRADOR = c.String(),
                        NOMBRE_COMPRADOR = c.String(),
                        BACKPROCESOR = c.String(),
                        FacturaId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emisors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        direccionEmisor = c.String(),
                        codpostalEmisor = c.String(),
                        muniEmisor = c.String(),
                        DeptoEmisor = c.String(),
                        paisEmisor = c.String(),
                        nitemisor = c.String(),
                        nombreemisor = c.String(),
                        codestable = c.String(),
                        namecomercial = c.String(),
                        tipoafiliacion = c.String(),
                        urlFel = c.String(),
                        urlToken = c.String(),
                        usernameFel = c.String(),
                        passwordFel = c.String(),
                        entorno = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PreciosDetallePeps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioVenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioMayorista = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioEntidadGubernamental = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioCuentaClave = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioRevendedor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Coste = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaIngreso = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CuotasCreditoes", "PrestamosID", "dbo.Prestamos");
            DropForeignKey("dbo.Prestamos", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Prestamos", "TipoCreditoId", "dbo.TipoCreditoes");
            DropForeignKey("dbo.RegistroPagoCuotas", "PrestamosId", "dbo.Prestamos");
            DropForeignKey("dbo.RegistroPagoCuotas", "CuotasCreditoId", "dbo.CuotasCreditoes");
            DropForeignKey("dbo.Prestamos", "AmortizacionId", "dbo.MetodoAmortizacions");
            DropForeignKey("dbo.Prestamos", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.DetalleRebajas", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.DetalleRebajas", "AsignacionValeId", "dbo.AsignacionVales");
            DropForeignKey("dbo.DetalleCotizacions", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.DetalleCotizacions", "CotizacionId", "dbo.Cotizacions");
            DropForeignKey("dbo.DetalleCotizacions", "ComboId", "dbo.Comboes");
            DropForeignKey("dbo.DetallePedidos", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.TipoPrecios", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.DetallePrecios", "TipoPrecioId", "dbo.TipoPrecios");
            DropForeignKey("dbo.TemporalProductos", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.TemporalProductos", "DetalleTallaId", "dbo.DetalleTallas");
            DropForeignKey("dbo.TemporalProductos", "DetalleColorTallaId", "dbo.DetalleColorTallas");
            DropForeignKey("dbo.TemporalProductos", "DetalleColorId", "dbo.DetalleColors");
            DropForeignKey("dbo.TemporalProductos", "ComboId", "dbo.Comboes");
            DropForeignKey("dbo.SolicitudDetalles", "SolicitudToFacturarId", "dbo.SolicitudToFacturars");
            DropForeignKey("dbo.SolicitudDetalles", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.SolicitudDetalles", "DetalleTallaId", "dbo.DetalleTallas");
            DropForeignKey("dbo.SolicitudDetalles", "DetalleColorTallaId", "dbo.DetalleColorTallas");
            DropForeignKey("dbo.SolicitudDetalles", "DetalleColorId", "dbo.DetalleColors");
            DropForeignKey("dbo.SolicitudDetalles", "ComboId", "dbo.Comboes");
            DropForeignKey("dbo.DetalleVales", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.DetalleTallas", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.Promocions", "SucursalId", "dbo.Sucursals");
            DropForeignKey("dbo.Productoes", "SucursalId", "dbo.Sucursals");
            DropForeignKey("dbo.Personals", "SucursalId", "dbo.Sucursals");
            DropForeignKey("dbo.Retrasoes", "TipoRetrasoId", "dbo.TipoRetrasoes");
            DropForeignKey("dbo.Retrasoes", "PersonalId", "dbo.Personals");
            DropForeignKey("dbo.Personals", "PuestoId", "dbo.Puestoes");
            DropForeignKey("dbo.Puestoes", "DepartamentoId", "dbo.Departamentoes");
            DropForeignKey("dbo.PaseEmpleadoes", "PersonalId", "dbo.Personals");
            DropForeignKey("dbo.PaseEmpleadoes", "MotivoPaseId", "dbo.MotivoPases");
            DropForeignKey("dbo.HorasExtras", "PersonalId", "dbo.Personals");
            DropForeignKey("dbo.HorarioAsignadoes", "PersonalId", "dbo.Personals");
            DropForeignKey("dbo.HorarioAsignadoes", "HorarioE_IdHorario", "dbo.HorarioEs");
            DropForeignKey("dbo.Personals", "HorarioId", "dbo.Horarios");
            DropForeignKey("dbo.EntradaSalidas", "PersonalId", "dbo.Personals");
            DropForeignKey("dbo.EntradaSalidas", "TipoESId", "dbo.TipoES");
            DropForeignKey("dbo.EmpleadoAusencias", "PersonalId", "dbo.Personals");
            DropForeignKey("dbo.EmpleadoAusencias", "AusenciaId", "dbo.Ausencias");
            DropForeignKey("dbo.Personals", "ContratoId", "dbo.TipoContratoes");
            DropForeignKey("dbo.Pedidoes", "SucursalId", "dbo.Sucursals");
            DropForeignKey("dbo.DetallePedidos", "PedidoId", "dbo.Pedidoes");
            DropForeignKey("dbo.Pedidoes", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Cotizacions", "SucursalId", "dbo.Sucursals");
            DropForeignKey("dbo.Comboes", "SucursalId", "dbo.Sucursals");
            DropForeignKey("dbo.Clientes", "SucursalId", "dbo.Sucursals");
            DropForeignKey("dbo.Cajas", "SucursalId", "dbo.Sucursals");
            DropForeignKey("dbo.DetalleMonetarios", "CajaId", "dbo.Cajas");
            DropForeignKey("dbo.Compras", "SucursalId", "dbo.Sucursals");
            DropForeignKey("dbo.Recepcions", "EstadoRecepcionId", "dbo.EstadoRecepcions");
            DropForeignKey("dbo.DetalleRecepcions", "RecepcionId", "dbo.Recepcions");
            DropForeignKey("dbo.Recepcions", "CompraId", "dbo.Compras");
            DropForeignKey("dbo.Proveedors", "TipoProveedorId", "dbo.TipoProveedors");
            DropForeignKey("dbo.Proveedors", "SucursalId", "dbo.Sucursals");
            DropForeignKey("dbo.Proveedors", "RubroId", "dbo.Rubroes");
            DropForeignKey("dbo.Productoes", "ProveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.Proveedors", "FrecuenciaId", "dbo.Frecuencias");
            DropForeignKey("dbo.Compras", "ProveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.Proveedors", "BancoId", "dbo.Bancas");
            DropForeignKey("dbo.Vales", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Vales", "TiposId", "dbo.Tipos");
            DropForeignKey("dbo.DetallePrecios", "TiposId", "dbo.Tipos");
            DropForeignKey("dbo.Clientes", "TiposId", "dbo.Tipos");
            DropForeignKey("dbo.Vales", "SucursalId", "dbo.Sucursals");
            DropForeignKey("dbo.AsignacionVales", "ValeId", "dbo.Vales");
            DropForeignKey("dbo.Transaccions", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "SucursalId", "dbo.Sucursals");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Facturas", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.NotaPagoes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.NotaPagoes", "MovimientoId", "dbo.Movimientoes");
            DropForeignKey("dbo.NotaPagoes", "FacturaId", "dbo.Facturas");
            DropForeignKey("dbo.Talonarios", "CuentaCBId", "dbo.CuentaCBs");
            DropForeignKey("dbo.CuentaCBs", "SucursalId", "dbo.Sucursals");
            DropForeignKey("dbo.ProductosReservas", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.ProductosReservas", "DetalleTallaId", "dbo.DetalleTallas");
            DropForeignKey("dbo.ProductosReservas", "DetalleColorTallaId", "dbo.DetalleColorTallas");
            DropForeignKey("dbo.ProductosReservas", "DetalleColorId", "dbo.DetalleColors");
            DropForeignKey("dbo.ProductosReservas", "CuentaCBId", "dbo.CuentaCBs");
            DropForeignKey("dbo.ProductosReservas", "ComboId", "dbo.Comboes");
            DropForeignKey("dbo.NotaPagoes", "CuentaCBId", "dbo.CuentaCBs");
            DropForeignKey("dbo.CuentaCBs", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.NotaDebitoes", "FacturaId", "dbo.Facturas");
            DropForeignKey("dbo.NotaCreditoes", "FacturaId", "dbo.Facturas");
            DropForeignKey("dbo.DetalleNotaCreditoes", "NotaCreditoId", "dbo.NotaCreditoes");
            DropForeignKey("dbo.DetalleFacturas", "FacturaId", "dbo.Facturas");
            DropForeignKey("dbo.DetalleCajas", "FacturaId", "dbo.Facturas");
            DropForeignKey("dbo.Facturas", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transaccions", "TipoMovimientoId", "dbo.TipoMovimientoes");
            DropForeignKey("dbo.Transaccions", "SucursalId", "dbo.Sucursals");
            DropForeignKey("dbo.Transaccions", "EstadosTransacId", "dbo.EstadosTransacs");
            DropForeignKey("dbo.Transaccions", "CuentaBancoId", "dbo.CuentaBancoes");
            DropForeignKey("dbo.CuentaBancoes", "BancaId", "dbo.Bancas");
            DropForeignKey("dbo.DetalleCompras", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.DetalleCompras", "CompraId", "dbo.Compras");
            DropForeignKey("dbo.DetalleCajas", "CompraId", "dbo.Compras");
            DropForeignKey("dbo.DetalleCajas", "CajaId", "dbo.Cajas");
            DropForeignKey("dbo.DetallePromocions", "PromocionId", "dbo.Promocions");
            DropForeignKey("dbo.DetallePromocions", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.DetallePromocions", "DescuentoPromosId", "dbo.DescuentoPromos");
            DropForeignKey("dbo.DetallePromocions", "ComboId", "dbo.Comboes");
            DropForeignKey("dbo.DetalleFacturas", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.DetalleComboes", "Producto_Id", "dbo.Productoes");
            DropForeignKey("dbo.DetalleColorTallas", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.DetalleColors", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.Productoes", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.DetalleVales", "DetalleTallaId", "dbo.DetalleTallas");
            DropForeignKey("dbo.DetalleVales", "DetalleColorTallaId", "dbo.DetalleColorTallas");
            DropForeignKey("dbo.DetalleVales", "DetalleColorId", "dbo.DetalleColors");
            DropForeignKey("dbo.DetalleVales", "ComboId", "dbo.Comboes");
            DropForeignKey("dbo.DetalleVales", "AsignacionValeId", "dbo.AsignacionVales");
            DropForeignKey("dbo.DetallePedidos", "DetalleTallaId", "dbo.DetalleTallas");
            DropForeignKey("dbo.DetalleFacturas", "DetalleTallaId", "dbo.DetalleTallas");
            DropForeignKey("dbo.DetalleCotizacions", "DetalleTallaId", "dbo.DetalleTallas");
            DropForeignKey("dbo.DetalleComboes", "DetalleTallaId", "dbo.DetalleTallas");
            DropForeignKey("dbo.DetallePedidos", "DetalleColorTallaId", "dbo.DetalleColorTallas");
            DropForeignKey("dbo.DetallePedidos", "DetalleColorId", "dbo.DetalleColors");
            DropForeignKey("dbo.DetallePedidos", "ComboId", "dbo.Comboes");
            DropForeignKey("dbo.DetalleFacturas", "DetalleColorTallaId", "dbo.DetalleColorTallas");
            DropForeignKey("dbo.DetalleCotizacions", "DetalleColorTallaId", "dbo.DetalleColorTallas");
            DropForeignKey("dbo.DetalleComboes", "DetalleColorTallaId", "dbo.DetalleColorTallas");
            DropForeignKey("dbo.DetalleFacturas", "DetalleColorId", "dbo.DetalleColors");
            DropForeignKey("dbo.DetalleFacturas", "ComboId", "dbo.Comboes");
            DropForeignKey("dbo.DetalleCotizacions", "DetalleColorId", "dbo.DetalleColors");
            DropForeignKey("dbo.DetalleComboes", "DetalleColorId", "dbo.DetalleColors");
            DropForeignKey("dbo.DetalleComboes", "ComboId", "dbo.Comboes");
            DropForeignKey("dbo.Cotizacions", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "CategoriaId", "dbo.CategoriaClientes");
            DropForeignKey("dbo.AsignacionVales", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RegistroPagoCuotas", new[] { "CuotasCreditoId" });
            DropIndex("dbo.RegistroPagoCuotas", new[] { "PrestamosId" });
            DropIndex("dbo.Prestamos", new[] { "ClienteId" });
            DropIndex("dbo.Prestamos", new[] { "UsuarioId" });
            DropIndex("dbo.Prestamos", new[] { "AmortizacionId" });
            DropIndex("dbo.Prestamos", new[] { "TipoCreditoId" });
            DropIndex("dbo.CuotasCreditoes", new[] { "PrestamosID" });
            DropIndex("dbo.DetalleRebajas", new[] { "AsignacionValeId" });
            DropIndex("dbo.DetalleRebajas", new[] { "ProductoId" });
            DropIndex("dbo.TipoPrecios", new[] { "ProductoId" });
            DropIndex("dbo.TemporalProductos", new[] { "ComboId" });
            DropIndex("dbo.TemporalProductos", new[] { "DetalleColorTallaId" });
            DropIndex("dbo.TemporalProductos", new[] { "DetalleTallaId" });
            DropIndex("dbo.TemporalProductos", new[] { "DetalleColorId" });
            DropIndex("dbo.TemporalProductos", new[] { "ProductoId" });
            DropIndex("dbo.SolicitudDetalles", new[] { "ComboId" });
            DropIndex("dbo.SolicitudDetalles", new[] { "SolicitudToFacturarId" });
            DropIndex("dbo.SolicitudDetalles", new[] { "DetalleColorTallaId" });
            DropIndex("dbo.SolicitudDetalles", new[] { "DetalleTallaId" });
            DropIndex("dbo.SolicitudDetalles", new[] { "DetalleColorId" });
            DropIndex("dbo.SolicitudDetalles", new[] { "ProductoId" });
            DropIndex("dbo.Retrasoes", new[] { "TipoRetrasoId" });
            DropIndex("dbo.Retrasoes", new[] { "PersonalId" });
            DropIndex("dbo.Puestoes", new[] { "DepartamentoId" });
            DropIndex("dbo.PaseEmpleadoes", new[] { "MotivoPaseId" });
            DropIndex("dbo.PaseEmpleadoes", new[] { "PersonalId" });
            DropIndex("dbo.HorasExtras", new[] { "PersonalId" });
            DropIndex("dbo.HorarioAsignadoes", new[] { "HorarioE_IdHorario" });
            DropIndex("dbo.HorarioAsignadoes", new[] { "PersonalId" });
            DropIndex("dbo.EntradaSalidas", new[] { "TipoESId" });
            DropIndex("dbo.EntradaSalidas", new[] { "PersonalId" });
            DropIndex("dbo.EmpleadoAusencias", new[] { "PersonalId" });
            DropIndex("dbo.EmpleadoAusencias", new[] { "AusenciaId" });
            DropIndex("dbo.Personals", new[] { "PuestoId" });
            DropIndex("dbo.Personals", new[] { "SucursalId" });
            DropIndex("dbo.Personals", new[] { "ContratoId" });
            DropIndex("dbo.Personals", new[] { "HorarioId" });
            DropIndex("dbo.Pedidoes", new[] { "ClienteId" });
            DropIndex("dbo.Pedidoes", new[] { "SucursalId" });
            DropIndex("dbo.DetalleMonetarios", new[] { "CajaId" });
            DropIndex("dbo.DetalleRecepcions", new[] { "RecepcionId" });
            DropIndex("dbo.Recepcions", new[] { "EstadoRecepcionId" });
            DropIndex("dbo.Recepcions", new[] { "CompraId" });
            DropIndex("dbo.DetallePrecios", new[] { "TiposId" });
            DropIndex("dbo.DetallePrecios", new[] { "TipoPrecioId" });
            DropIndex("dbo.Vales", new[] { "TiposId" });
            DropIndex("dbo.Vales", new[] { "UserId" });
            DropIndex("dbo.Vales", new[] { "SucursalId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Talonarios", new[] { "CuentaCBId" });
            DropIndex("dbo.ProductosReservas", new[] { "DetalleColorTallaId" });
            DropIndex("dbo.ProductosReservas", new[] { "DetalleTallaId" });
            DropIndex("dbo.ProductosReservas", new[] { "DetalleColorId" });
            DropIndex("dbo.ProductosReservas", new[] { "ComboId" });
            DropIndex("dbo.ProductosReservas", new[] { "CuentaCBId" });
            DropIndex("dbo.ProductosReservas", new[] { "ProductoId" });
            DropIndex("dbo.CuentaCBs", new[] { "SucursalId" });
            DropIndex("dbo.CuentaCBs", new[] { "ClienteId" });
            DropIndex("dbo.NotaPagoes", new[] { "CuentaCBId" });
            DropIndex("dbo.NotaPagoes", new[] { "FacturaId" });
            DropIndex("dbo.NotaPagoes", new[] { "UserId" });
            DropIndex("dbo.NotaPagoes", new[] { "MovimientoId" });
            DropIndex("dbo.NotaDebitoes", new[] { "FacturaId" });
            DropIndex("dbo.DetalleNotaCreditoes", new[] { "NotaCreditoId" });
            DropIndex("dbo.NotaCreditoes", new[] { "FacturaId" });
            DropIndex("dbo.Facturas", new[] { "UserId" });
            DropIndex("dbo.Facturas", new[] { "ClienteId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "SucursalId" });
            DropIndex("dbo.Transaccions", new[] { "UsuarioId" });
            DropIndex("dbo.Transaccions", new[] { "SucursalId" });
            DropIndex("dbo.Transaccions", new[] { "CuentaBancoId" });
            DropIndex("dbo.Transaccions", new[] { "TipoMovimientoId" });
            DropIndex("dbo.Transaccions", new[] { "EstadosTransacId" });
            DropIndex("dbo.CuentaBancoes", new[] { "BancaId" });
            DropIndex("dbo.Proveedors", new[] { "TipoProveedorId" });
            DropIndex("dbo.Proveedors", new[] { "FrecuenciaId" });
            DropIndex("dbo.Proveedors", new[] { "RubroId" });
            DropIndex("dbo.Proveedors", new[] { "BancoId" });
            DropIndex("dbo.Proveedors", new[] { "SucursalId" });
            DropIndex("dbo.DetalleCompras", new[] { "ProductoId" });
            DropIndex("dbo.DetalleCompras", new[] { "CompraId" });
            DropIndex("dbo.Compras", new[] { "SucursalId" });
            DropIndex("dbo.Compras", new[] { "ProveedorId" });
            DropIndex("dbo.DetalleCajas", new[] { "CompraId" });
            DropIndex("dbo.DetalleCajas", new[] { "FacturaId" });
            DropIndex("dbo.DetalleCajas", new[] { "CajaId" });
            DropIndex("dbo.Cajas", new[] { "SucursalId" });
            DropIndex("dbo.Promocions", new[] { "SucursalId" });
            DropIndex("dbo.DetallePromocions", new[] { "ComboId" });
            DropIndex("dbo.DetallePromocions", new[] { "DescuentoPromosId" });
            DropIndex("dbo.DetallePromocions", new[] { "PromocionId" });
            DropIndex("dbo.DetallePromocions", new[] { "ProductoId" });
            DropIndex("dbo.Productoes", new[] { "ProveedorId" });
            DropIndex("dbo.Productoes", new[] { "SucursalId" });
            DropIndex("dbo.Productoes", new[] { "CategoriaId" });
            DropIndex("dbo.DetalleVales", new[] { "DetalleColorTallaId" });
            DropIndex("dbo.DetalleVales", new[] { "DetalleTallaId" });
            DropIndex("dbo.DetalleVales", new[] { "DetalleColorId" });
            DropIndex("dbo.DetalleVales", new[] { "ComboId" });
            DropIndex("dbo.DetalleVales", new[] { "AsignacionValeId" });
            DropIndex("dbo.DetalleVales", new[] { "ProductoId" });
            DropIndex("dbo.DetalleTallas", new[] { "ProductoId" });
            DropIndex("dbo.DetallePedidos", new[] { "DetalleColorTallaId" });
            DropIndex("dbo.DetallePedidos", new[] { "DetalleTallaId" });
            DropIndex("dbo.DetallePedidos", new[] { "DetalleColorId" });
            DropIndex("dbo.DetallePedidos", new[] { "ComboId" });
            DropIndex("dbo.DetallePedidos", new[] { "PedidoId" });
            DropIndex("dbo.DetallePedidos", new[] { "ProductoId" });
            DropIndex("dbo.DetalleColorTallas", new[] { "ProductoId" });
            DropIndex("dbo.DetalleFacturas", new[] { "ComboId" });
            DropIndex("dbo.DetalleFacturas", new[] { "FacturaId" });
            DropIndex("dbo.DetalleFacturas", new[] { "DetalleColorTallaId" });
            DropIndex("dbo.DetalleFacturas", new[] { "DetalleTallaId" });
            DropIndex("dbo.DetalleFacturas", new[] { "DetalleColorId" });
            DropIndex("dbo.DetalleFacturas", new[] { "ProductoId" });
            DropIndex("dbo.DetalleColors", new[] { "ProductoId" });
            DropIndex("dbo.DetalleComboes", new[] { "Producto_Id" });
            DropIndex("dbo.DetalleComboes", new[] { "DetalleColorTallaId" });
            DropIndex("dbo.DetalleComboes", new[] { "DetalleTallaId" });
            DropIndex("dbo.DetalleComboes", new[] { "DetalleColorId" });
            DropIndex("dbo.DetalleComboes", new[] { "ComboId" });
            DropIndex("dbo.Comboes", new[] { "SucursalId" });
            DropIndex("dbo.DetalleCotizacions", new[] { "DetalleColorTallaId" });
            DropIndex("dbo.DetalleCotizacions", new[] { "DetalleTallaId" });
            DropIndex("dbo.DetalleCotizacions", new[] { "DetalleColorId" });
            DropIndex("dbo.DetalleCotizacions", new[] { "ComboId" });
            DropIndex("dbo.DetalleCotizacions", new[] { "CotizacionId" });
            DropIndex("dbo.DetalleCotizacions", new[] { "ProductoId" });
            DropIndex("dbo.Cotizacions", new[] { "ClienteId" });
            DropIndex("dbo.Cotizacions", new[] { "SucursalId" });
            DropIndex("dbo.Clientes", new[] { "SucursalId" });
            DropIndex("dbo.Clientes", new[] { "CategoriaId" });
            DropIndex("dbo.Clientes", new[] { "TiposId" });
            DropIndex("dbo.AsignacionVales", new[] { "ClienteId" });
            DropIndex("dbo.AsignacionVales", new[] { "ValeId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PreciosDetallePeps");
            DropTable("dbo.Emisors");
            DropTable("dbo.DocumentoCertificadoSATs");
            DropTable("dbo.TipoCreditoes");
            DropTable("dbo.RegistroPagoCuotas");
            DropTable("dbo.MetodoAmortizacions");
            DropTable("dbo.Prestamos");
            DropTable("dbo.CuotasCreditoes");
            DropTable("dbo.DetalleRebajas");
            DropTable("dbo.TipoPrecios");
            DropTable("dbo.TemporalProductos");
            DropTable("dbo.SolicitudToFacturars");
            DropTable("dbo.SolicitudDetalles");
            DropTable("dbo.TipoRetrasoes");
            DropTable("dbo.Retrasoes");
            DropTable("dbo.Departamentoes");
            DropTable("dbo.Puestoes");
            DropTable("dbo.MotivoPases");
            DropTable("dbo.PaseEmpleadoes");
            DropTable("dbo.HorasExtras");
            DropTable("dbo.HorarioEs");
            DropTable("dbo.HorarioAsignadoes");
            DropTable("dbo.Horarios");
            DropTable("dbo.TipoES");
            DropTable("dbo.EntradaSalidas");
            DropTable("dbo.Ausencias");
            DropTable("dbo.EmpleadoAusencias");
            DropTable("dbo.TipoContratoes");
            DropTable("dbo.Personals");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.DetalleMonetarios");
            DropTable("dbo.EstadoRecepcions");
            DropTable("dbo.DetalleRecepcions");
            DropTable("dbo.Recepcions");
            DropTable("dbo.TipoProveedors");
            DropTable("dbo.Rubroes");
            DropTable("dbo.Frecuencias");
            DropTable("dbo.DetallePrecios");
            DropTable("dbo.Tipos");
            DropTable("dbo.Vales");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Movimientoes");
            DropTable("dbo.Talonarios");
            DropTable("dbo.ProductosReservas");
            DropTable("dbo.CuentaCBs");
            DropTable("dbo.NotaPagoes");
            DropTable("dbo.NotaDebitoes");
            DropTable("dbo.DetalleNotaCreditoes");
            DropTable("dbo.NotaCreditoes");
            DropTable("dbo.Facturas");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TipoMovimientoes");
            DropTable("dbo.EstadosTransacs");
            DropTable("dbo.Transaccions");
            DropTable("dbo.CuentaBancoes");
            DropTable("dbo.Bancas");
            DropTable("dbo.Proveedors");
            DropTable("dbo.DetalleCompras");
            DropTable("dbo.Compras");
            DropTable("dbo.DetalleCajas");
            DropTable("dbo.Cajas");
            DropTable("dbo.Sucursals");
            DropTable("dbo.Promocions");
            DropTable("dbo.DescuentoPromos");
            DropTable("dbo.DetallePromocions");
            DropTable("dbo.Categorias");
            DropTable("dbo.Productoes");
            DropTable("dbo.DetalleVales");
            DropTable("dbo.DetalleTallas");
            DropTable("dbo.DetallePedidos");
            DropTable("dbo.DetalleColorTallas");
            DropTable("dbo.DetalleFacturas");
            DropTable("dbo.DetalleColors");
            DropTable("dbo.DetalleComboes");
            DropTable("dbo.Comboes");
            DropTable("dbo.DetalleCotizacions");
            DropTable("dbo.Cotizacions");
            DropTable("dbo.CategoriaClientes");
            DropTable("dbo.Clientes");
            DropTable("dbo.AsignacionVales");
            DropTable("dbo.AnulacionCertificadoes");
        }
    }
}
