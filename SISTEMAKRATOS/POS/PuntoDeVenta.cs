using CapaDatos.ListasPersonalizadas;
using CapaDatos.ListasPersonalizadas.VentasAcumuladas;
using CapaDatos.Models.Clientes;
using CapaDatos.Models.CuentaCobrar;
using CapaDatos.Models.Pedidos;
using CapaDatos.Models.Precios;
using CapaDatos.Models.Productos;
using CapaDatos.Models.Productos.Combos;
using CapaDatos.Models.ProductosToFacturar;
using CapaDatos.Models.Usuarios;
using CapaDatos.Repository;
using CapaDatos.Repository.PreciosRepository;
using CapaDatos.Repository.SolicitudestoFacturar;
using CapaDatos.Validation;
using CapaDatos.WebServiceSAT;
using ComponentFactory.Krypton.Toolkit;
using POS.Forms;
using POS.Forms.Facturacion;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class PuntoDeVenta : BaseContext
    {
        private CotizacionRepository _cotizacionRepository = null;
        private PedidoRepository _pedidoRepository = null;
        private ValesRepository _valesRepository = null;
        private ProductosRepository _productosRepository = null;
        private CombosRepository _combosRepository = null;
        private ColoresRepository _coloresRepository = null;
        private TallasRepository _tallasRepository = null;
        private TallasyColoresRepository _tallasyColoresRepository = null;
        private SolicitudesRepository _solicitudesRepository = null;
        private CategoriaProdRepository _categoriaProdRepository = null;
        private readonly TipoPrecioRepository _tipoPrecioRepository = null;
        private readonly TiposClienteRepository _tipoclienteRepository = null;
        private readonly ClientesRepository _clientesRepository = null;
        private readonly DetalleProductoRepository _detalleProductoRepository = null;
        private readonly ProductosTempRepository _productosTempRepository = null;
        private List<SolicitudDetalle> _listadoSolicitudDetalle = null;
        private SolicitudToFacturar _solicitudUpdate = new SolicitudToFacturar();
        private readonly CuentasCobrarRepository _cuentasCobrarRepository = null;
        public Cliente _cliente = null;
        private readonly ClienteCreditoRepository _clienteCreditoRepository = null;
        private CuentaCB _cuentaPorCobrar = null;
        private TokenSAT TokenObtenidoSat = null;
        private bool conectado = false;
        private List<Keys> pressedKeys = new List<Keys>();
        public bool validacionToken = false;
        private readonly int colCodOriginal = 0;
        private readonly int colCodAlterno = 8;
        private readonly int colDescripcion = 2;
        private readonly int colCantidad = 3;
        private readonly int colPrecio = 4;
        private readonly int colRebajaD = 5;
        private readonly int colPrecioD = 6;
        private readonly int colSubtotal = 7;
        private readonly int colIdDoc = 8;
        private readonly int colColor = 9;
        private readonly int colTalla = 10;
        private readonly int colTE = 11;
        private bool update = false;
        private List<ListaProductosTmp> _listaProdTmp = null;
        private bool btcoti = false;

        //listas detalles
        public List<ListarDetalleCotiz> _listadetallesCotiz = new List<ListarDetalleCotiz>();
        public List<ListarDetallePedidos> _listadetallesPedidos = new List<ListarDetallePedidos>();
        public List<ListarDetalleVales> _listadetallesvales = new List<ListarDetalleVales>();
        public IList<ListarCombos> _listaCombos = new List<ListarCombos>();
        public IList<ListarProductos> _listaProductos = null, listareducidaDebusquedal = null;
        public List<ListarDetalleFacturas> _listaDetalleFacturas = new List<ListarDetalleFacturas>();
        public List<SolicitudDetalle> _listaSolicitudDetalles = null;
        public List<ListarAcumuladasEncabezado> _listaSolicitud = null;
        public List<Producto> _allProductosList = null, listatotalbusqueda = null;

        private List<DetalleProducto> _listaDetalle = null;

        //variables
        public Guid idCotizacion;
        public Guid idPedido;
        private bool selectProducto = true;
        public ListarVales _valeSelected = null;
        public String colorSel = "";
        public String tallaSel = "";
        public int detcolorId = 0;
        public int dettallaId = 0;
        public int dettallacolorId = 0;
        public int cantidad = 1;
        public decimal TotalCobro = 0.00m;
        public int valor;
        private int sucursalVendedor = 1;
        //objetos creados
        private TableLayoutPanel tabla;
        public Form Formulario;

        public PuntoDeVenta(User user, Form formBack)
        {
            UsuarioLogeadoPOS.User = user;
            Formulario = formBack;
            sucursalVendedor = user.SucursalId;
            CargarTokenSat();
            InitializeComponent();
            _cotizacionRepository = new CotizacionRepository(_context);
            _clientesRepository = new ClientesRepository(_context);
            _pedidoRepository = new PedidoRepository(_context);
            _valesRepository = new ValesRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            _combosRepository = new CombosRepository(_context);
            _coloresRepository = new ColoresRepository(_context);
            _tallasRepository = new TallasRepository(_context);
            _tallasyColoresRepository = new TallasyColoresRepository(_context);
            _solicitudesRepository = new SolicitudesRepository(_context);
            _categoriaProdRepository = new CategoriaProdRepository(_context);
            _tipoPrecioRepository = new TipoPrecioRepository(_context);
            _tipoclienteRepository = new TiposClienteRepository(_context);
            _productosTempRepository = new ProductosTempRepository(_context);

            _clienteCreditoRepository = new ClienteCreditoRepository(_context);
            _cliente = new Cliente();
            _listaDetalle = new List<DetalleProducto>();
            _detalleProductoRepository = new DetalleProductoRepository(_context);
            _listaProdTmp = new List<ListaProductosTmp>();
            _listadoSolicitudDetalle = new List<SolicitudDetalle>();
            _cuentasCobrarRepository = new CuentasCobrarRepository(_context);
            cargarUsuarioYSucursal();

        }
        private IList<ListarCombos> ComboLoad()
        {
            var combosbd = _combosRepository.GetListarCombos(UsuarioLogeadoPOS.User.SucursalId);
            return combosbd;
        }
        private IList<ListarProductos> ProductosLoad1()
        {
            var productosbd = _productosRepository.GetList(UsuarioLogeadoPOS.User.SucursalId).Take(50).ToList();
            return productosbd;
        }

        private IList<ListarProductos> ProductosAll()
        {
            var productosbd = _productosRepository.GetList(UsuarioLogeadoPOS.User.SucursalId).ToList();
            return productosbd;
        }
        private void cargarUsuarioYSucursal()
        {

            lbsucursal.Text = UsuarioLogeadoPOS.User.Sucursal.NombreSucursal;
            lbusuariologeado.Text = UsuarioLogeadoPOS.User.UserName;


        }

        public void CargaPedido()
        {
            nodocumento.Text = Numero();
        }
        private void CargarTokenSat()
        {
            Internet internet = new Internet(2);
            TokenObtenidoSat = internet.TokenObtenidoSat;
            conectado = internet.conectado;
        }
        private void CargarProductosGenerales(IList<ListarProductos> lista)
        {
            //var lista= _productosRepository.GetList(UsuarioLogeadoPOS.User.SucursalId);
            BindingSource recurso = new BindingSource();

            recurso.DataSource = lista;
            dgvProductosBd.DataSource = typeof(List<>);
            dgvProductosBd.DataSource = recurso;
            //dgvProductosBd.AutoResizeColumns();
            _listaProductos = lista;

            int value = dgvProductosBd.ColumnCount;
            if (value > 0)
            {
                for (int i = 18; i <= 28; i++)
                {
                    dgvProductosBd.Columns[i].Visible = false;
                }

            }

            dgvProductosBd.ClearSelection();
        }
        public void CargarClientes()
        {
            tipocliente.ComboBox.DataSource = _clientesRepository.GetTipos();
            tipocliente.ComboBox.DisplayMember = "TipoCliente";
            tipocliente.ComboBox.ValueMember = "Id";
            tipocliente.Invalidate();
        }
       
        private void cargaProductosInit()
        {
            //  tablaProductos.Controls.Clear();
            CargarProductosGenerales(_listaProductos);
            selectProducto = true;
        }
        private void CargarPorCategoria(int catid)
        {
            var productosbdcat = _productosRepository.GetListByCategoria(catid, UsuarioLogeadoPOS.User.SucursalId).ToList();
            _listaProductos = productosbdcat;
            cargaProductosInit();
        }
        private void PuntoDeVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegresarFormulario(false);
        }

        private void RegresarFormulario(bool cerrar = true)
        {
            if (Formulario != null)
            {
                Formulario.Show();
                Formulario.Activate();
            }
            if (cerrar)
            {
                Close();
            }
        }
        public void cargarDGVDetalleFactura(List<ListarDetalleFacturas> lista)
        {
            BindingSource recurso = new BindingSource();

            recurso.DataSource = lista;
            dgvproductosadd.DataSource = typeof(List<>);
            dgvproductosadd.DataSource = recurso;
            dgvproductosadd.AutoResizeColumns();
            dgvproductosadd.Columns[0].Visible = false;
            dgvproductosadd.Columns[9].Visible = false;
            dgvproductosadd.Columns[10].Visible = false;
            dgvproductosadd.Columns[11].Visible = false;
            dgvproductosadd.Columns[12].Visible = false;
            dgvproductosadd.Columns[13].Visible = false;
            dgvproductosadd.Columns[14].Visible = false;
            dgvproductosadd.Columns[15].Visible = false;
            dgvproductosadd.Columns[16].Visible = false;
            dgvproductosadd.Columns[18].Visible = false;
            dgvproductosadd.ClearSelection();
        }
        public ListarDetalleFacturas GetDetalleFactura()
        {
            return new ListarDetalleFacturas()
            {


            };

        }
        public List<ListarDetalleFacturas> GetCotizacionToFacturaDetalle()
        {
            //  var list = new List<ListarDetalleFacturas>();

            foreach (var item in _listadetallesCotiz)
            {
                if (_listadetallesCotiz == null) { continue; }
                var detalleFactura = GetDetalleFactura();
                detalleFactura.DetalleColorId = item.DetalleColorId;
                detalleFactura.DetalleTallaId = item.DetalleTallaId;
                detalleFactura.TallayColorId = item.TallayColorId;
                detalleFactura.Color = item.Color;
                detalleFactura.Talla = item.Talla;
                detalleFactura.ProductoId = (int)item.ProductoId;
                detalleFactura.Descripcion = item.Descripcion;
                detalleFactura.Cantidad = item.Cantidad;
                detalleFactura.Precio = item.Precio;
                detalleFactura.Descuento = 0;
                detalleFactura.PrecioTotal = item.Total;
                detalleFactura.SubTotal = detalleFactura.PrecioTotal;
                detalleFactura.ComboId = item.ComboId;
                _listaDetalleFacturas.Add(detalleFactura);
            }
            return _listaDetalleFacturas;

        }
        public List<ListarDetalleFacturas> GetPedidoToFacturaDetalle()
        {
            // var list = new List<ListarDetalleFacturas>();

            foreach (var item in _listadetallesPedidos)
            {
                if (_listadetallesPedidos == null) { continue; }
                var detalleFactura = GetDetalleFactura();
                detalleFactura.DetalleColorId = item.DetalleColorId;
                detalleFactura.DetalleTallaId = item.DetalleTallaId;
                detalleFactura.TallayColorId = item.TallayColorId;
                detalleFactura.Color = item.Color;
                detalleFactura.Talla = item.Talla;
                detalleFactura.ProductoId = (int)item.ProductoId;
                detalleFactura.Descripcion = item.Descripcion;
                detalleFactura.Cantidad = item.Cantidad;
                detalleFactura.Precio = item.Precio;
                detalleFactura.Descuento = 0;
                detalleFactura.PrecioTotal = item.Total;
                detalleFactura.SubTotal = detalleFactura.PrecioTotal;
                detalleFactura.ComboId = item.ComboId;
                _listaDetalleFacturas.Add(detalleFactura);
            }
            return _listaDetalleFacturas;

        }
        public List<ListarDetalleFacturas> GetValeToFacturaDetalle()
        {
            // var list = new List<ListarDetalleFacturas>();

            foreach (var item in _listadetallesvales)
            {
                if (_listadetallesvales == null) { continue; }
                var detalleFactura = GetDetalleFactura();
                detalleFactura.DetalleColorId = item.DetalleColorId;
                detalleFactura.DetalleTallaId = item.DetalleTallaId;
                detalleFactura.TallayColorId = item.TallayColorId;
                detalleFactura.Color = item.Color;
                detalleFactura.Talla = item.Talla;
                detalleFactura.ProductoId = (int)item.ProductoId;
                detalleFactura.Descripcion = item.Descripcion;
                detalleFactura.Cantidad = item.Cantidad;
                detalleFactura.Precio = item.Precio;
                detalleFactura.Descuento = 0;
                detalleFactura.PrecioTotal = item.Total;
                detalleFactura.SubTotal = detalleFactura.PrecioTotal;
                detalleFactura.ComboId = item.ComboId;
                _listaDetalleFacturas.Add(detalleFactura);
            }
            return _listaDetalleFacturas;

        }
       

      
        public void cargarValeLabel()
        {
            if (_valeSelected != null)
            {

                nodocumento.Text = _valeSelected.NoVale;
                // lbvalename.Visible = true;
            }
            else
            {
                //  lbvalename.Visible = false;
                nodocumento.Text = null;
            }


        }

      


        private string ObtenerNumero(string noDocumento, string tipo)
        {
            string numero = "";
            if (noDocumento.Length > 0)
            {
                int maxsol = Convert.ToInt32(noDocumento.Split('-')[1]) + 1;
                if (maxsol < 10)
                    numero = tipo + "00" + maxsol;
                else if (maxsol < 100)
                    numero = tipo + "0" + maxsol;
                else
                    numero = tipo + maxsol;
            }
            else
            {
                numero = tipo + "001";
            }
            return numero;
        }

        public string Numero()
        {


            string numero = "";
            string tipo;

            switch (valor)
            {
                case 2:

                    tipo = "VCN-";
                    string solic = _solicitudesRepository.GetLastSolicitud("VCN-", sucursalVendedor);
                    numero = ObtenerNumero(solic, tipo);
                    // MostrarCamposCuentas(false);
                    break;
                case 3:
                    tipo = "VCR-";
                    string solir = _solicitudesRepository.GetLastSolicitud("VCR-", sucursalVendedor);
                    numero = ObtenerNumero(solir, tipo);
                    // MostrarCamposCuentas(true);
                    break;
                case 1:

                    tipo = "CT-";
                    string cot = _cotizacionRepository.GetLastCotizacion(sucursalVendedor);
                    numero = ObtenerNumero(cot, tipo);
                    // MostrarCamposCuentas(false);
                    break;
                case 4:
                    tipo = "VA-";
                    string vale = _valesRepository.GetLastVale(sucursalVendedor);
                    numero = ObtenerNumero(vale, tipo);
                    //  MostrarCamposCuentas(false);
                    break;
                default:
                    tipo = "VCN-";
                    string sol = _solicitudesRepository.GetLastSolicitud("VCN-", UsuarioLogeadoPOS.User.SucursalId);
                    numero = ObtenerNumero(sol, tipo);
                    // MostrarCamposCuentas(false);
                    break;
            }
            return numero;
        }

        private void SumaFilas()
        {

            try
            {
                decimal cantidad = 0.00m;
                if (dgvproductosadd.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvproductosadd.Rows)
                    {
                        cantidad = cantidad + Convert.ToDecimal(row.Cells[8].Value);
                    }
                }
                lbtotal.Text = cantidad.ToString();
            }
            catch (Exception io)
            {
                KryptonMessageBox.Show("Error en SumaFilas() " + io.Message);
            }

        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }
        public List<ListarDetalleFacturas> CrearListaBySelected(DataGridView datagrid, int colAcciones)
        {
            // int colAcciones = 17;
            int filasSeleccion = 0;
            int contador = 0;
            var listaDetalles = new List<ListarDetalleFacturas>();
            //  if (dgvproductosadd.RowCount == 0) { return; }

            foreach (DataGridViewRow rows in datagrid.Rows)
            {

                var filasTotales = int.Parse(datagrid.RowCount.ToString());
                bool acciones = Convert.ToBoolean(rows.Cells[colAcciones].Value);
                if (!acciones)
                {
                    filasSeleccion += 1;
                }
                else
                {
                    var fila = (ListarDetalleFacturas)datagrid.Rows[contador].DataBoundItem;
                    listaDetalles.Add(fila);

                }
                contador += 1;


            }

            return listaDetalles;
        }
        private bool VerificarExiste(int idProducto)
        {
            bool existe = false;

            foreach (DataGridViewRow row in dgvproductosadd.Rows)
            {
                if (Convert.ToInt32(row.Cells[10].Value) == idProducto)
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }
        public int validarTallaColor(Producto producto)
        {
            int value = 0;
            if (producto.TieneColor == true && producto.TieneTalla == false)
            {
                //tiene solamente color
                value = 1;
            }
            else if (producto.TieneColor == false && producto.TieneTalla == true)
            {
                //tiene solamente talla
                value = 2;
            }
            else if (producto.TieneColor == true && producto.TieneTalla == true)
            {
                //tiene talla y color
                value = 3;
            }
            else
            {
                //no tiene ninguno
                value = 0;
            }

            return value;
        }
        public bool actualizarStock(int Cantidad, Object detalle, Producto producto, int opc)
        {
            bool actualizado = false;
            if (detalle != null)
            {
                switch (opc)
                {
                    case 1:
                        var _detalleC = (DetalleColor)detalle;
                        _detalleC.Stock -= Cantidad;
                        _coloresRepository.Update(_detalleC);
                        producto.Stock -= Cantidad;
                        _productosRepository.Update(producto);
                        actualizado = true;
                        break;
                    case 2:
                        var _detalleT = (DetalleTalla)detalle;
                        _detalleT.Stock -= Cantidad;
                        _tallasRepository.Update(_detalleT);
                        producto.Stock -= Cantidad;
                        _productosRepository.Update(producto);
                        actualizado = true;
                        break;
                    case 3:
                        var _detalleTC = (DetalleColorTalla)detalle;
                        _detalleTC.Stock -= Cantidad;
                        _tallasyColoresRepository.Update(_detalleTC);
                        producto.Stock -= Cantidad;
                        _productosRepository.Update(producto);
                        actualizado = true;
                        break;
                    case 4:
                        var _combos = (Combo)detalle;
                        _combos.Stock -= Cantidad;
                        _combosRepository.Update(_combos);
                        actualizado = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (producto != null)
                {
                    producto.Stock -= Cantidad;
                    _productosRepository.Update(producto);
                    actualizado = true;
                }
                else
                {
                    actualizado = false;
                }
            }

            return actualizado;
        }
        public bool ValidarExistencias(ListarDetalleFacturas detallefactura, bool save = false)
        {
            int Cantidad = detallefactura.Cantidad;
            bool validacion = false;
            try
            {
                //validaciones de existencias para el producto
                if (detallefactura.ProductoId != 0)
                {
                    Producto producto = new Producto();
                    producto = _productosRepository.Get(detallefactura.ProductoId);
                    if (producto.StockControl == true)
                    {
                        if (producto.Stock > producto.stockMinimo)
                        {
                            int _stockRestante = producto.Stock - producto.stockMinimo;
                            //valida si hay sufiente stock 
                            if (_stockRestante >= Cantidad)
                            {
                                //si se quiere actualizar en la bd save debe ser true
                                if (save)
                                {
                                    //obtiene las propiedades del producto color/talla/color y talla
                                    int opc = validarTallaColor(producto);

                                    switch (opc)
                                    {
                                        case 1:
                                            var listaobtenidaDetalleColor = _coloresRepository.GetProductoListaColor(producto.Id);
                                            var detalleColorToLess = listaobtenidaDetalleColor.Where(x => x.Id == detallefactura.DetalleColorId).FirstOrDefault();
                                            validacion = actualizarStock(Cantidad, detalleColorToLess, producto, 1);
                                            break;
                                        case 2:
                                            var listTallabyProducto = _tallasRepository.GetTallaListaProducto(producto.Id);
                                            var detalleTallaToLess = listTallabyProducto.Where(x => x.Id == detallefactura.DetalleTallaId).FirstOrDefault();
                                            validacion = actualizarStock(Cantidad, detalleTallaToLess, producto, 2);
                                            break;
                                        case 3:
                                            var tallasyColores = _tallasyColoresRepository.GetTallaColorListaProducto(producto.Id);
                                            var colorytallatoLess = tallasyColores.Where(x => x.Id == detallefactura.TallayColorId).FirstOrDefault();
                                            validacion = actualizarStock(Cantidad, colorytallatoLess, producto, 3);
                                            break;
                                        default:
                                            validacion = actualizarStock(Cantidad, null, producto, 0);
                                            break;
                                    }
                                }
                                //si no solo mostrara que si puede continuar pero que no seran acutalizada la info
                                else
                                {
                                    validacion = true;
                                }
                            }
                            else
                            {
                                validacion = false;
                            }
                        }
                        else
                        {
                            validacion = false;
                        }
                    }
                    else
                    {
                        validacion = false;
                    }
                }
                //validaciones de existencias para los combos
                else
                {
                    Combo ncombo = _combosRepository.Get(detallefactura.ComboId);
                    if (ncombo != null)
                    {
                        if (ncombo.Stock > Cantidad)
                        {
                            if (save)
                            {
                                var comboToLess = _combosRepository.Get(detallefactura.ComboId);
                                validacion = actualizarStock(Cantidad, comboToLess, null, 4);
                            }
                            else
                            {
                                validacion = true;
                            }
                        }
                        else
                        {
                            validacion = false;
                        }
                    }
                }
            }
            catch (Exception io)
            {
                KryptonMessageBox.Show("Error en ValidarExistencias() " + io.Message);
                return false;
            }
            return validacion;

        }


        public List<ListarAcumuladasEncabezado> listadeVentasPendientes = new List<ListarAcumuladasEncabezado>();



        public void GuardarDetalles()
        {
            try
            {
                foreach (DetalleProducto item in _listaDetalle)
                {
                    if (item.Id == 0)
                    {
                        _detalleProductoRepository.Add(item);
                    }
                    else
                    {
                        if (item.noDocumento == "TMP")
                        {
                            item.noDocumento = nodocumento.Text;
                        }
                        item.FechaDocumento = DateTime.Now;
                        _detalleProductoRepository.Update(item);
                    }
                }
                _listaDetalle.Clear();
                _listaDetalle = new List<DetalleProducto>();

            }
            catch
            {
                MessageBox.Show("Ocurrio un error en guardar los detalles.", "Notificación");
            }
        }
        private void ActualizarProductosTemporales()
        {
            if (_listaProdTmp.Count() > 0)
            {
                foreach (var item in _listaProdTmp)
                {
                    _productosTempRepository.Update(GetTempProd(item));
                }
            }
        }
        private TemporalProductos GetTempProd(ListaProductosTmp tmp)
        {
            TemporalProductos temporal = _productosTempRepository.GetTemporal(tmp.Id);
            temporal.IsActive = true;
            return temporal;
        }
        public bool ValidarExistencias(SolicitudDetalle solicitudDetalle, string noDocumento, bool save = true)
        {
            int Cantidad = solicitudDetalle.Cantidad;
            bool validacion = false;
            try
            {
                //validaciones de existencias para el producto
                if (solicitudDetalle.ProductoId != 0)
                {
                    Producto producto = new Producto();
                    producto = _productosRepository.Get((int)solicitudDetalle.ProductoId);
                    if (producto.Stock > producto.stockMinimo)
                    {
                        int _stockRestante = producto.Stock - producto.stockMinimo;
                        //valida si hay sufiente stock 
                        if (_stockRestante >= Cantidad)
                        {
                            //si se quiere actualizar en la bd save debe ser true
                            if (save)
                            {

                                var detallesDoc = _detalleProductoRepository.GetListNoDocumento(noDocumento);
                                if (detallesDoc.Count() > 0)
                                {
                                    detallesDoc = detallesDoc.Where(x => x.ProductoId == producto.Id).ToList();
                                }
                                foreach (var detalle in detallesDoc)
                                {
                                    switch (detalle.TipoDetalle)
                                    {
                                        case "Color":
                                            var color = _coloresRepository.GetDetalleColor(detalle.DetalleId);
                                            if (color != null)
                                                actualizarStock(detalle.Cantidad, color, producto, 1);
                                            break;
                                        case "Talla":
                                            var talla = _tallasRepository.GetDetalleTalla(detalle.DetalleId);
                                            if (talla != null)
                                                actualizarStock(detalle.Cantidad, talla, producto, 2);
                                            break;

                                    }
                                }

                            }
                            //si no solo mostrara que si puede continuar pero que no seran acutalizada la info
                            else
                            {
                                validacion = true;
                            }
                        }
                        else
                        {
                            validacion = false;
                        }
                    }
                    else
                    {
                        validacion = false;
                    }
                }
            }
            catch (Exception io)
            {
                MessageBox.Show("Error en ValidarExistencias() " + io.Message);
                return false;
            }
            return validacion;

        }
        private void LimpiarTextbox()
        {
       
           
          
            lbtotal.Text = "0.00";
           
        }
        public void CargarDatos()
        {
            LimpiarTextbox();
            //CargaFecha();
            //CargarTipoOperaciones();
            CargaPedido();
            //dtpFecha.Enabled = true;
            //cbTipoCliente.Enabled = true;
            //cbTipoOperacion.Enabled = true;
        }
        private void CargarFormsPago()
        {
            if (Application.OpenForms["MonitorFacturacion"] == null)
            {
                MonitorFacturacion sel = new MonitorFacturacion(this);
                sel.Show();
            }
            else
            {
                Application.OpenForms["MonitorFacturacion"].Activate();
            }
        }
        public void CargarListadoDetalleSolicitud()
        {
            if (dgvproductosadd.RowCount > 0)
            {
                SolicitudDetalle detalleSolicitud = new SolicitudDetalle();
                foreach (DataGridViewRow row in dgvproductosadd.Rows)
                {
                    detalleSolicitud.ProductoId = Convert.ToInt32(row.Cells[10].Value);
                    detalleSolicitud.Cantidad = Convert.ToInt32(row.Cells[4].Value);
                    detalleSolicitud.Precio = Convert.ToDecimal(row.Cells[5].Value);
                    detalleSolicitud.SubTotal = Convert.ToDecimal(row.Cells[7].Value);


                    if (row.Cells[6].Value != null)
                    {
                        detalleSolicitud.Descuento = (detalleSolicitud.Precio - Convert.ToDecimal(row.Cells[6].Value)) * detalleSolicitud.Cantidad;
                    }
                    detalleSolicitud.PrecioTotal = detalleSolicitud.SubTotal;



                    _listadoSolicitudDetalle.Add(detalleSolicitud);
                    detalleSolicitud = new SolicitudDetalle();
                }
            }
        }


        private SolicitudToFacturar GetModelSolicitud()
        {
            if (update)
            {
                _solicitudUpdate.NitCliente = _cliente.Nit;
                _solicitudUpdate.NombreCliente = _cliente.Nombres;
                _solicitudUpdate.DireccionCliente = _cliente.Direccion;
                _solicitudUpdate.ClienteId = _cliente.Id;
                _solicitudUpdate.FechaVenta = DateTime.Now;
                _solicitudUpdate.Vendedor = UsuarioLogeadoPOS.User.Name;
                _solicitudUpdate.SucursalId = sucursalVendedor;
                return _solicitudUpdate;
            }
            else
            {
                SolicitudToFacturar enc = new SolicitudToFacturar();
                enc.Id = Guid.NewGuid();
                enc.NoSolicitud = nodocumento.Text;
                enc.NitCliente = _cliente.Nit;
                enc.NombreCliente = _cliente.Nombres;
                enc.DireccionCliente = _cliente.Direccion;
                enc.ClienteId = _cliente.Id;
                enc.FechaVenta = DateTime.Now;
                enc.Vendedor = UsuarioLogeadoPOS.User.Name;
                enc.Estado = false;
                enc.SucursalId = sucursalVendedor;
                return enc;
            }
        }
        private void GuardarSolicitudProd()
        {
            try
            {
                if (update)
                {
                    var ventaAcumulada = GetModelSolicitud();
                    if (!ModelState.IsValid(ventaAcumulada)) return;
                    _solicitudesRepository.Update(ventaAcumulada);

                    foreach (var item in _listadoSolicitudDetalle)
                    {
                        var detSolicitud = _solicitudesRepository.GetDetalleSolicitud(item.Id);
                        if (detSolicitud != null)
                        {
                            detSolicitud.ProductoId = item.ProductoId;
                            detSolicitud.Cantidad = item.Cantidad;
                            detSolicitud.Precio = item.Precio;
                            detSolicitud.SubTotal = item.SubTotal;
                            detSolicitud.Descuento = item.Descuento;
                            detSolicitud.PrecioTotal = item.PrecioTotal;

                            _solicitudesRepository.UpdateDetalle(detSolicitud);
                        }
                        else
                        {
                            item.SolicitudToFacturarId = ventaAcumulada.Id;
                            _solicitudesRepository.AddDetalleSolicitud(item);
                        }
                    }
                    //if (ventaAcumulada.NoSolicitud.Contains("VCR-"))
                    //{
                    //    ClienteCredito credito = new ClienteCredito
                    //    {
                    //        DocumentoId = ventaAcumulada.Id,
                    //        CuentaCBId = _cuentaPorCobrar.Id,
                    //    };
                    //    if (!ModelState.IsValid(credito)) return;
                    //    _clienteCreditoRepository.Add(credito);
                    //}
                }
                else
                {
                    var ventaAcumulada = GetModelSolicitud();
                    if (!ModelState.IsValid(ventaAcumulada)) return;
                    _solicitudesRepository.Add(ventaAcumulada);

                    foreach (var item in _listadoSolicitudDetalle)
                    {
                        item.SolicitudToFacturarId = ventaAcumulada.Id;
                        _solicitudesRepository.AddDetalleSolicitud(item);
                    }

                    if (ventaAcumulada.NoSolicitud.Contains("VCR-"))
                    {
                        ClienteCredito credito = new ClienteCredito
                        {
                            DocumentoId = ventaAcumulada.Id,
                            CuentaCBId = _cuentaPorCobrar.Id,
                        };
                        if (!ModelState.IsValid(credito)) return;
                        _clienteCreditoRepository.Add(credito);
                        _cuentaPorCobrar.SaldoActual += Convert.ToDecimal(lbtotal.Text);
                        _cuentasCobrarRepository.Update(_cuentaPorCobrar);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error interno al guardar los datos. \n" + ex.Message);
            }
        }

        private void GuardarVentaPendiente()
        {
            CargarListadoDetalleSolicitud();
            GuardarSolicitudProd();
            _listadoSolicitudDetalle = new List<SolicitudDetalle>();
        }
        public void LimpiarGridListado()
        {
            int count = 0;
            foreach (DataGridViewRow row in dgvproductosadd.Rows)
            {
                if (row.Cells[colCodOriginal].Value != null)
                {
                    count++;
                }
            }

            for (int i = 0; i < count; i++)
            {
                dgvproductosadd.Rows.RemoveAt(0);
            }
        }
        public void GuardarVenta(bool MostrarMonitor)
        {
            try
            {

                GuardarVentaPendiente();

                GuardarDetalles();
                ActualizarProductosTemporales();
                LimpiarGridListado();
                CargarDatos();

                if (MostrarMonitor)
                {
                    if (UsuarioLogeadoPOS.User.Privilegios == "Solo Venta" || UsuarioLogeadoPOS.User.Privilegios == "Usuario Estandar" || UsuarioLogeadoPOS.User.Privilegios == "Solo POS")
                    {
                        MessageBox.Show("¡Datos Guardados con Éxito!", "Notificación");
                    }
                    if (UsuarioLogeadoPOS.User.Privilegios == "Administrador" || UsuarioLogeadoPOS.User.Privilegios == "Solo Caja")
                    {

                        CargarFormsPago();

                    }
                }
                else
                {
                    MessageBox.Show("¡Datos Guardados con Éxito!", "Notificación");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema interno, por favor revise la informacion ingresada." + ex.Message);
                return;
            }
        }

        private void Cobrar(bool mostrarMonitor)
        {
            pressedKeys = new List<Keys>();
            var listaobtenidaDetalle = CrearListaBySelected(dgvproductosadd, 17);
            if (listaobtenidaDetalle.Count == 0) { KryptonMessageBox.Show("Debe seleccionar un producto a facturar"); return; }
            if (dgvproductosadd.RowCount > 0)
            {
                if (_cliente.Nombres != null && _cliente.Nit != null)
                {

                    GuardarVenta(mostrarMonitor);

                }
                else
                {
                    MessageBox.Show("¡No ha ingresado un cliente válido!", "Notificación");
                }
            }
            else
            {
                MessageBox.Show("¡No puede guardarse la información! \n El Listado esta vacio.");
            }
        }




        private void OperacionPorFila()
        {
            try
            {
                if (dgvproductosadd.CurrentRow.DataBoundItem != null)
                {
                    var filaActual = (ListarDetalleFacturas)dgvproductosadd.CurrentRow.DataBoundItem;
                    if (dgvproductosadd.CurrentCell.ColumnIndex == 4)
                    {
                        var prodtmp = _productosRepository.Get(filaActual.ProductoId);

                        if (prodtmp.TieneEscalas)
                        {
                            var tipoprecio = _tipoPrecioRepository.Get(prodtmp.Id);
                            var detalles = _tipoPrecioRepository.GetDetallePrecios(tipoprecio.Id);
                            if (detalles.Count > 0)
                            {
                                detalles.OrderBy(x => x.RangoInicio);
                                foreach (DetallePrecio detalle in detalles)
                                {

                                    if (filaActual.Cantidad >= detalle.RangoInicio && filaActual.Cantidad <= detalle.RangoFinal)
                                    {
                                        filaActual.Precio = detalle.Precio;
                                    }

                                    if (detalle.Escala == "E1")
                                    {
                                        if (filaActual.Cantidad < detalle.RangoInicio)
                                        {
                                            filaActual.Precio = prodtmp.PrecioVenta;
                                        }
                                    }


                                }
                            }
                            else
                            {
                                filaActual.Precio = prodtmp.PrecioVenta;
                                filaActual.SubTotal = filaActual.Cantidad * filaActual.Precio;
                                filaActual.PrecioTotal = filaActual.SubTotal - filaActual.Descuento;
                            }
                            filaActual.SubTotal = filaActual.Cantidad * filaActual.Precio;
                            filaActual.PrecioTotal = filaActual.SubTotal - filaActual.Descuento;
                        }
                        else
                        {
                            filaActual.SubTotal = filaActual.Cantidad * filaActual.Precio;
                            filaActual.PrecioTotal = filaActual.SubTotal - filaActual.Descuento;
                        }
                    }
                    else
                    {
                        filaActual.SubTotal = filaActual.Cantidad * filaActual.Precio;
                        filaActual.PrecioTotal = filaActual.SubTotal - filaActual.Descuento;
                    }

                }

            }
            catch (Exception io)
            {
                KryptonMessageBox.Show("Error en SumaFilas() " + io.Message);
            }

        }
       
        public void EliminarUltima()
        {
            int rows = dgvproductosadd.Rows.Count;
            if (rows > 0)
            {
                var lastRow = dgvproductosadd.Rows[rows - 1];
                var llastRow = _listaDetalleFacturas.LastOrDefault();

                dgvproductosadd.Rows.Remove(lastRow);
                _listaDetalleFacturas.Remove(llastRow);
            }
        }
        public void ListaColorTallaSeleccionado()
        {
            int rows = _listaDetalleFacturas.Count;
            if (rows > 0)
            {
                var lastRow = _listaDetalleFacturas.LastOrDefault();
                lastRow.Color = colorSel;
                lastRow.Talla = tallaSel;
                lastRow.DetalleColorId = detcolorId;
                lastRow.DetalleTallaId = dettallaId;
                lastRow.TallayColorId = dettallacolorId;
                lastRow.Cantidad = cantidad;
                lastRow.PrecioTotal = cantidad * lastRow.Precio;
                lastRow.SubTotal = cantidad * lastRow.Precio;
                SumaFilas();
            }
        }
        public void ColorTallaSeleccionado()
        {
            int rows = dgvproductosadd.Rows.Count;
            if (rows > 0)
            {
                var lastRow = dgvproductosadd.Rows[rows - 1];
                lastRow.Cells[1].Value = colorSel;
                lastRow.Cells[2].Value = tallaSel;
                lastRow.Cells[4].Value = cantidad;
                lastRow.Cells[8].Value = cantidad * Convert.ToDecimal(lastRow.Cells[5].Value);
                lastRow.Cells[13].Value = detcolorId;
                lastRow.Cells[14].Value = dettallaId;
                lastRow.Cells[15].Value = dettallacolorId;
                dgvproductosadd.AutoResizeColumns();
                dgvproductosadd.ClearSelection();
                ListaColorTallaSeleccionado();
            }
        }
       
      

        private void DatosCliente()
        {
            DialogResult dialogResult = MessageBox.Show("El tipo de cliente es: " + tipocliente.Text.ToUpper(), "Confirmación", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Application.OpenForms["DatosCliente"] == null)
                {
                    int tipoclientes = Convert.ToInt32(tipocliente.ComboBox.SelectedValue);
                    DatosCliente cliente = new DatosCliente(_cliente, tipoclientes, this, TokenObtenidoSat, conectado);
                    cliente.Show();
                }
                else
                {
                    Application.OpenForms["DatosCliente"].Activate();
                }
            }
        }
        private void VentanaCajeroyVendedor()
        {
            try
            {
                if (dgvproductosadd.RowCount <= 0) return;
                var listaErrores = new List<String>();
                var cadenadeError = "";
                var listaobtenidaDetalle = CrearListaBySelected(dgvproductosadd, 17);
                if (listaobtenidaDetalle.Count == 0) { KryptonMessageBox.Show("Debe seleccionar un producto a facturar"); return; }

                foreach (var item in _listaDetalleFacturas)
                {
                    if (!ValidarExistencias(item, false))
                    {
                        cadenadeError += "No hay suficiente stock del producto: "
                                      + item.Descripcion + " " + item.Color + " " + item.Talla + " " + "Revise existencias!\n";
                        listaErrores.Add(cadenadeError);
                        continue;
                    }
                }
                if (listaErrores.Count > 0)
                {
                    KryptonMessageBox.Show(cadenadeError);
                }
                else
                {
                    /*
                     * Administrador
                       Usuario Estandar
                       Solo Venta
                       Solo Caja
                       Solo POS
                       solo Administracion
                    */
                    if (UsuarioLogeadoPOS.User.Privilegios == "Solo Venta" || UsuarioLogeadoPOS.User.Privilegios == "Usuario Estandar" || UsuarioLogeadoPOS.User.Privilegios == "Solo POS")
                    {
                        MessageBox.Show("¡Datos Guardados con Éxito!", "Notificación");
                    }


                }

            }
            catch (IOException ex)
            {
                KryptonMessageBox.Show("Error en cobro " + ex.Message);
            }

        }
      
      
        private void btnCotizacion_Click_1(object sender, EventArgs e)
        {

            if (Application.OpenForms["AgregarCotizacion"] == null)
            {

                AgregarCotizacion AddCotizacion = new AgregarCotizacion(this);

                AddCotizacion.Show();
                valor = 1;
            }
            else
            {
                Application.OpenForms["AgregarCotizacion"].Activate();
            }

        }

     
        private void pbCabello_Click(object sender, EventArgs e)
        {
            CargarPorCategoria(1);
        }

        private void pbCosmeticos_Click_2(object sender, EventArgs e)
        {
            CargarPorCategoria(2);
        }

        private void pbFacial_Click_1(object sender, EventArgs e)
        {
            CargarPorCategoria(3);
        }

        private void pbManicuraPe_Click_1(object sender, EventArgs e)
        {
            CargarPorCategoria(4);
        }

        private void pbPersonal_Click_1(object sender, EventArgs e)
        {
            CargarPorCategoria(5);
        }

        private void pbUnias_Click_1(object sender, EventArgs e)
        {
            CargarPorCategoria(6);
        }

        private void pbVarios_Click_1(object sender, EventArgs e)
        {
            CargarPorCategoria(8);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DatosCliente();
        }

        private void btnCotizacion_Click_2(object sender, EventArgs e)
        {
            valor = 1;
            if (Application.OpenForms["AgregarCotizacion"] == null)
            {

                AgregarCotizacion AddCotizacion = new AgregarCotizacion(this);

                AddCotizacion.Show();
            }
            else
            {
                Application.OpenForms["AgregarCotizacion"].Activate();
            }
        }

        private void btnVentasPendientes_Click(object sender, EventArgs e)
        {
            valor = 2;
            if (Application.OpenForms["VentasPendientes"] == null)
            {
                VentasPendientes VentasPendientesFACT = new VentasPendientes(this);

                VentasPendientesFACT.Show();
            }
            else
            {
                Application.OpenForms["VentasPendientes"].Activate();
            }
        }

        private void btnpedidos_Click_2(object sender, EventArgs e)
        {
            if (Application.OpenForms["AgregarPedido"] == null)
            {
                AgregarPedido AddCotizacion = new AgregarPedido(this);

                AddCotizacion.Show();
            }
            else
            {
                Application.OpenForms["AgregarPedido"].Activate();
            }
        }

        private void btnVales_Click_2(object sender, EventArgs e)
        {
            valor = 4;
            if (Application.OpenForms["AgregarVale"] == null)
            {
                AgregarVale AddCotizacion = new AgregarVale(this);

                AddCotizacion.Show();
            }
            else
            {
                Application.OpenForms["AgregarVale"].Activate();
            }
        }

        private void btnCalculadora_Click_2(object sender, EventArgs e)
        {
            if (Application.OpenForms["Calculadora"] == null)
            {
                Calculadora calc = new Calculadora();
                calc.Show();
            }
            else { Application.OpenForms["Calculadora"].Activate(); }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Cobrar(false);
        }

        private void toolStripButton4_Click_2(object sender, EventArgs e)
        {
            dgvproductosadd.ClearSelection();
            try
            {
                int acciones = 17;

                if (dgvproductosadd.RowCount > 0)
                {
                    foreach (DataGridViewRow row in dgvproductosadd.Rows)
                    {
                        row.Cells[acciones].Value = true;


                    }
                }


            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CargarFormsPago();
        }

        private void dgvProductosBd_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {
            try
            
            {
                // checkAll.Checked = false;
                if (selectProducto == true)
                {
                    var selectFila = (ListarProductos)dgvProductosBd.CurrentRow.DataBoundItem;

                    if (!VerificarExiste(Convert.ToInt32(selectFila.Id)))
                    {
                        var detallefactura = GetDetalleFactura();

                        detallefactura.Cantidad = 1;
                        detallefactura.Descripcion = selectFila.Descripcion;
                        detallefactura.Precio = selectFila.PrecioVenta;
                        detallefactura.SubTotal = detallefactura.Cantidad * detallefactura.Precio;
                        detallefactura.PrecioTotal = detallefactura.Cantidad * detallefactura.Precio;
                        detallefactura.ProductoId = selectFila.Id;
                        if (detallefactura.Precio > 0 && selectFila.Stock > 0)
                        {
                            if (selectFila.IncluyeColor == "Si" && selectFila.Talla == "No")
                            {
                                //cargar list de color   
                                SeleccionarElemento sel = new SeleccionarElemento(1, this, detallefactura.ProductoId);
                                sel.Show();
                            }
                            else if (selectFila.IncluyeColor == "No" && selectFila.Talla == "Si")
                            {
                                //cargar list de talla
                                SeleccionarElemento sel = new SeleccionarElemento(2, this, detallefactura.ProductoId);
                                sel.Show();
                            }
                            else if (selectFila.IncluyeColor == "Si" && selectFila.Talla == "Si")
                            {
                                //cargar listado de colores y tallas
                                SeleccionarElemento sel = new SeleccionarElemento(3, this, detallefactura.ProductoId);
                                sel.Show();
                            }

                            _listaDetalleFacturas.Add(detallefactura);
                            cargarDGVDetalleFactura(_listaDetalleFacturas);
                        }
                        else
                        {
                            KryptonMessageBox.Show("El producto contiene informacion que no es valida (precio/stock)\npor favor revisar el Detalle del Producto.");
                            return;
                        }
                    }
                    else
                    {
                        KryptonMessageBox.Show("¡El producto ya ha sido Agregado!");
                        return;
                    }


                }
                else
                {
                    var selectFila = (ListarCombos)dgvProductosBd.CurrentRow.DataBoundItem;
                    var detallefactura = GetDetalleFactura();
                    detallefactura.Cantidad = 1;
                    detallefactura.Descripcion = selectFila.Descripcion;
                    detallefactura.Precio = selectFila.Precioventa;
                    detallefactura.SubTotal = detallefactura.Cantidad * detallefactura.Precio;
                    detallefactura.ComboId = selectFila.IdCombo;
                    detallefactura.PrecioTotal = detallefactura.Cantidad * detallefactura.Precio;
                    _listaDetalleFacturas.Add(detallefactura);
                    cargarDGVDetalleFactura(_listaDetalleFacturas);

                }
            }
            catch (Exception ex)
            {

                KryptonMessageBox.Show("Error: dgvprodbd_Cellclick " + ex.Message);
            }
        }

        private void dgvproductosadd_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // var filaSeleted= (Listar)
            }
            catch (Exception ex)
            {

                KryptonMessageBox.Show(ex.Message);
            }
        }

        private void dgvproductosadd_CellEndEdit_2(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                OperacionPorFila();
                SumaFilas();
            }
        }

        private void dgvproductosadd_RowsAdded_2(object sender, DataGridViewRowsAddedEventArgs e)
        {
            SumaFilas();
        }

        private void dgvproductosadd_UserDeletingRow_2(object sender, DataGridViewRowCancelEventArgs e)
        {
            var fila = dgvproductosadd.CurrentRow;
            decimal ttal = 0.00m;
            ttal = Convert.ToDecimal(lbtotal.Text);
            ttal = ttal - Convert.ToDecimal(fila.Cells[8].Value);
            lbtotal.Text = ttal.ToString();
        }

        private void txtbuscarProducto_TextChanged(object sender, EventArgs e)
        {
            string descripcion = txtbuscarProducto.Text.ToUpper();
            string descmin = txtbuscarProducto.Text;
            var filter = _listaProductos.Where(a => a.Descripcion.Contains(descripcion) || a.Descripcion.Contains(descmin));
            dgvProductosBd.DataSource = filter.ToList();
        }

        

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            RegresarFormulario(true);
        }

        private void PuntoDeVenta_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargaPedido();
        }
    }
}
