using CapaDatos.ListasPersonalizadas;
using CapaDatos.ListasPersonalizadas.VentasAcumuladas;
using CapaDatos.Models.Clientes;
using CapaDatos.Models.Cotizacion;
using CapaDatos.Models.CuentaCobrar;
using CapaDatos.Models.Pedidos;
using CapaDatos.Models.Precios;
using CapaDatos.Models.Productos;
using CapaDatos.Models.Productos.Combos;
using CapaDatos.Models.ProductosToFacturar;
using CapaDatos.Models.Usuarios;
using CapaDatos.Models.Vales;
using CapaDatos.Repository;
using CapaDatos.Repository.PreciosRepository;
using CapaDatos.Repository.SolicitudestoFacturar;
using CapaDatos.Validation;
using CapaDatos.WebServiceSAT;
using ComponentFactory.Krypton.Toolkit;
using POS.Forms;
using POS.Forms.Complementos;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POS
{

    public partial class pos : BaseContext
    {
        private readonly TipoOperacionRespository _tipoOperacionRespository = null;
        private readonly SucursalesRepository _sucursalesRepository = null;
        private readonly ProductosRepository _productosRepository = null;
        private readonly ClientesRepository _clientesRepository = null;
        private readonly RepositoryUsuarios _usersRepository = null;
        private readonly MarcasRepository _marcasRepository = null;
        private readonly ColoresRepository _coloresRepository = null;
        private readonly TallasRepository _tallasRepository = null;
        private readonly TomoEdicionRepository _tomoEdicionRepository = null;
        private readonly CombosRepository _combosRepository = null;
        private readonly SolicitudesRepository _solicitudesRepository = null;
        private readonly ValesRepository _valesRepository = null;
        private readonly CotizacionRepository _cotizacionRepository = null;
        private readonly TipoPrecioRepository _preciosRepository = null;
        private readonly TiposClienteRepository _tipoclienteRepository = null;
        private readonly DetalleProductoRepository _detalleProductoRepository = null;
        private readonly ProductosTempRepository _productosTempRepository = null;
        private readonly ClienteCreditoRepository _clienteCreditoRepository = null;
        private readonly CuentasCobrarRepository _cuentasCobrarRepository = null;

        private bool vista = true;
        private ItemLista _itemlista = null;
        public Cliente _cliente = null;
        private TokenSAT TokenObtenidoSat = null;
        private IList<ListarProductos> _listadolocal = null;
        private IList<ListarProductos> _listadoConsulta = null;
        private List<ListarDetalleFacturas> _listaDetFacturas = null;
        private List<SolicitudDetalle> _listadoSolicitudDetalle = null;
        private List<DetalleVale> _listadoValeDetalle = null;
        private List<DetalleCotizacion> _listadoCotDetalle = null;
        private List<DetalleProducto> _listaDetalle = null;
        private List<ListaProductosTmp> _listaProdTmp = null;

        private List<Keys> pressedKeys = new List<Keys>();
        private CuentaCB _cuentaPorCobrar = null;
        private Vale _valeUpdate = new Vale();
        private AsignacionVale _asigValeUpdate = new AsignacionVale();
        private Cotizacion _cotizacionUpdate = new Cotizacion();
        private SolicitudToFacturar _solicitudUpdate = new SolicitudToFacturar();
        private User _usuarioVentas = null;
        private ComboBox _codigo = new ComboBox();
        private ComboBox _codigoCorto = new ComboBox();
        private ComboBox _descripcion = new ComboBox();

        private int indice = 0;
        private int indicefila = 0;
        private int sucursalVendedor = 1;
        private int _ProductoId;
        private string noDocumetno = "";
        private decimal porcentajeD = 0.00m;
        private decimal Totalf = 0.00m;
        private bool update = false;
        private bool mostrarIngresoToken = false;
        private bool mostrarMsgDetalle = false;
        private bool conectado = false;
        public string _observaciones = "";
        public bool ventaCredito = false;
        public bool validacionToken = false;   
        public bool ProductosTemporales = false;

        private readonly int colCodOriginal = 0;
        private readonly int colCodAlterno = 1;
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



        public pos(User user)
        {
            UsuarioLogeadoPOS.User = user;
            sucursalVendedor = user.SucursalId;
            _tipoOperacionRespository = new TipoOperacionRespository(_context);
            _sucursalesRepository = new SucursalesRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            _clientesRepository = new ClientesRepository(_context);
            _usersRepository = new RepositoryUsuarios(_context);
            _marcasRepository = new MarcasRepository(_context);
            _coloresRepository = new ColoresRepository(_context);
            _tallasRepository = new TallasRepository(_context);
            _tomoEdicionRepository = new TomoEdicionRepository(_context);
            _solicitudesRepository = new SolicitudesRepository(_context);
            _combosRepository = new CombosRepository(_context);
            _valesRepository = new ValesRepository(_context);
            _cotizacionRepository = new CotizacionRepository(_context);
            _preciosRepository = new TipoPrecioRepository(_context);
            _tipoclienteRepository = new TiposClienteRepository(_context);
            _detalleProductoRepository = new DetalleProductoRepository(_context);
            _productosTempRepository = new ProductosTempRepository(_context);
            _clienteCreditoRepository = new ClienteCreditoRepository(_context);
            _cuentasCobrarRepository = new CuentasCobrarRepository(_context);
            _listadoConsulta = new List<ListarProductos>();
            _listadolocal = new List<ListarProductos>();
            _listaDetFacturas = new List<ListarDetalleFacturas>();
            _listadoSolicitudDetalle = new List<SolicitudDetalle>();
            _listadoValeDetalle = new List<DetalleVale>();
            _listadoCotDetalle = new List<DetalleCotizacion>();
            _listaDetalle = new List<DetalleProducto>();
            _listaProdTmp = new List<ListaProductosTmp>();
            _cliente = new Cliente();
            _itemlista = new ItemLista();
            CargarTokenSat();
            InitializeComponent();
        }

        private void PuntoDeVenta_Load(object sender, EventArgs e)
        {
            CargarTipoOperaciones();
            CargarClientes();
            CargarVendedores();
            CargaFecha();
            CargaProductos();
            MostrarIconoMonitor();
            CargaPedido();
            CargarCombosConsulta();
        }

        private void CargarTokenSat()
        {
            Internet internet = new Internet(1);
            TokenObtenidoSat = internet.TokenObtenidoSat;
            conectado = internet.conectado;
        }

        public void CargarDatos()
        {
            LimpiarTextbox();
            CargaFecha();
            CargarTipoOperaciones();
            CargaPedido();
            dtpFecha.Enabled = true;
            cbTipoCliente.Enabled = true;
            cbTipoOperacion.Enabled = true;
        }

        public void CargaPedido()
        {
            txtNumeroPedido.Text = Numero();
        }

        public string Numero()
        {
            string valor = cbTipoOperacion.SelectedValue.ToString();
            int opc = !int.TryParse(valor, out var b) ? 0 : Convert.ToInt32(valor);
            string numero = "";
            string tipo;
            switch (opc)
            {
                case 16:
                    tipo = "VCN-";
                    string solic = _solicitudesRepository.GetLastSolicitud("VCN-", sucursalVendedor);
                    numero = ObtenerNumero(solic, tipo);
                    MostrarCamposCuentas(false);
                    break;
                case 17:
                    tipo = "VCR-";
                    string solir = _solicitudesRepository.GetLastSolicitud("VCR-", sucursalVendedor);
                    numero = ObtenerNumero(solir, tipo);
                    MostrarCamposCuentas(true);
                    break;
                case 21:
                    tipo = "CT-";
                    string cot = _cotizacionRepository.GetLastCotizacion(sucursalVendedor);
                    numero = ObtenerNumero(cot, tipo);
                    MostrarCamposCuentas(false);
                    break;
                case 22:
                    tipo = "VA-";
                    string vale = _valesRepository.GetLastVale(sucursalVendedor);
                    numero = ObtenerNumero(vale, tipo);
                    MostrarCamposCuentas(false);
                    break;
                default:
                    tipo = "VCN-";
                    string sol = _solicitudesRepository.GetLastSolicitud("VCN-", UsuarioLogeadoPOS.User.SucursalId);
                    numero = ObtenerNumero(sol, tipo);
                    MostrarCamposCuentas(false);
                    break;
            }
            return numero;
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

        internal void cargarDGVDetalle(List<ListaProductosTmp> listaDetalles)
        {
            Actualizar();
            _listaProdTmp = listaDetalles;
            dtpFecha.Enabled = false;
            cbTipoCliente.Enabled = false;
            cbTipoOperacion.Enabled = false;
            cbTipoOperacion.SelectedValue = 16;

            var detalles = _detalleProductoRepository.GetDetallesTmp();
            foreach (var item in listaDetalles)
            {
                int sucursal = UsuarioLogeadoPOS.User.SucursalId;
                var prod = _productosRepository.Get(item.ProductoId);
                if (prod.SucursalId == sucursal)
                {
                    dgvListadoProductos.Rows.Add(new DataGridViewRow());
                    int indice = dgvListadoProductos.Rows.Count - 2;
                    var data = dgvListadoProductos.Rows[indice];

                    decimal pDescuento = 0.00m;
                    if (item.Descuento > 0)
                    {
                        pDescuento = item.Precio - (item.Descuento / item.Cantidad);
                    }

                    if (!EvaluarProductoListado(prod.CodigoBarras, 0))
                    {
                        data.Cells[colCodOriginal].Value = prod.CodigoBarras;
                        data.Cells[colCodAlterno].Value = prod.Id;
                        data.Cells[colDescripcion].Value = prod.Descripcion;
                        data.Cells[colCantidad].Value = item.Cantidad;
                        data.Cells[colPrecio].Value = item.Precio;
                        data.Cells[colRebajaD].Value = pDescuento;
                        data.Cells[colPrecioD].Value = pDescuento * item.Cantidad;
                        data.Cells[colSubtotal].Value = item.PrecioTotal;
                    }
                    else
                    {
                        EliminarUltima();
                    }
                    knPOS.SelectedPage = pgPuntoDeVenta;
                    PrecioEscala(prod.Id, data, 3);
                    if (detalles.Count() > 0)
                    {
                        var details = detalles.Where(x => x.ProductoId == prod.Id && x.Cantidad == item.Cantidad).ToList();

                        if (details.Count() > 0)
                        {
                            foreach (var elemento in details)
                            {
                                _listaDetalle.Add(elemento);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El producto seleccionado se encuentra en otra sucursal.", "Notificación");
                }
            }
            Calculartotal();
            CalcularDescuentos();
            OtrasExistencias();
        }

        private void LimpiarTextbox()
        {
            mostrarIngresoToken = false;
            txtBuscador.Text = "";
            txtDescuento.Text = "0.00";
            txtTotal.Text = "0.00";
            txtLinea.Text = "";
            txtExistencia.Text = "";
            txtEOtrasTiendas.Text = "";
        }

        public void CargarClientes()
        {
            cbTipoCliente.DataSource = _clientesRepository.GetTipos();
            cbTipoCliente.DisplayMember = "TipoCliente";
            cbTipoCliente.ValueMember = "Id";
            cbTipoCliente.Invalidate();
        }

        public void CargarVendedores()
        {
            cbVendedor.DataSource = _usersRepository.GetlistaUsuariosSucursal(UsuarioLogeadoPOS.User.SucursalId);
            cbVendedor.DisplayMember = "Name";
            cbVendedor.ValueMember = "Id";
            cbVendedor.Invalidate();
            cbVendedor.Text = UsuarioLogeadoPOS.User.Name;
            mostrarIngresoToken = true;
        }

        public void CargaFecha()
        {
            dtpFecha.Value = DateTime.Now;
            dtpFecha.CustomFormat = "MM/dd/yyyy HH:mm tt";
        }

        public void CargarTipoOperaciones()
        {
            cbTipoOperacion.DataSource = _tipoOperacionRespository.GetAllTipoOperaciones();
            cbTipoOperacion.DisplayMember = "Nombre";
            cbTipoOperacion.ValueMember = "Id";
            cbTipoOperacion.Invalidate();
        }

        public void CargaProductos()
        {
            _listadoConsulta = _productosRepository.GetListAll().ToList();
            _listadolocal = _productosRepository.GetList(UsuarioLogeadoPOS.User.SucursalId).ToList();

            ((DataGridViewComboBoxColumn)this.dgvListadoProductos.Columns[0]).DataSource = _listadolocal;
            ((DataGridViewComboBoxColumn)this.dgvListadoProductos.Columns[0]).DisplayMember = "CodigoReferencia";
            ((DataGridViewComboBoxColumn)this.dgvListadoProductos.Columns[0]).ValueMember = "Id";

            ((DataGridViewComboBoxColumn)this.dgvListadoProductos.Columns[1]).DataSource = _listadolocal;
            ((DataGridViewComboBoxColumn)this.dgvListadoProductos.Columns[1]).DisplayMember = "Id";
            ((DataGridViewComboBoxColumn)this.dgvListadoProductos.Columns[1]).ValueMember = "Id";

            ((DataGridViewComboBoxColumn)this.dgvListadoProductos.Columns[2]).DataSource = _listadolocal;
            ((DataGridViewComboBoxColumn)this.dgvListadoProductos.Columns[2]).DisplayMember = "Descripcion";
            ((DataGridViewComboBoxColumn)this.dgvListadoProductos.Columns[2]).ValueMember = "Id";
        }

        public void CargaElementos()
        {
            if (vista)
            {
                if (String.IsNullOrEmpty(txtBuscador.Text))
                {
                    pgConsulta.Visible = true;
                    dgvConsulta.Visible = true;
                    CargaGridProductosConsulta(_listadoConsulta.ToList(), vista);
                    knPOS.SelectedPage = pgConsulta;
                }
                else
                {
                    knPOS.SelectedPage = pgConsulta;
                    txtBuscador_TextChanged(null, null);
                }
                btnCambiarVista.Text = "Vista Imagen";
                vista = false;
            }
            else
            {
                btnCambiarVista.Text = "Vista Listado";
                CargaGridProductosConsulta(_listadoConsulta.ToList(), vista);
                vista = true;
                
            }

        }

        private void CargarCombosConsulta()
        {
            cbDetalleProdcuto.DataSource = _listadolocal;
            cbDetalleProdcuto.DisplayMember = "Descripcion";
            cbDetalleProdcuto.ValueMember = "Id";

            cbPuntodeventa.DataSource = _sucursalesRepository.GetList();
            cbPuntodeventa.DisplayMember = "NombreSucursal";
            cbPuntodeventa.ValueMember = "Id";


        }

        public void CargaGridProductosConsulta(List<ListarProductos> listado, bool mostrarImagen)
        {            
            if (!mostrarImagen)
            {
                dgvConsulta.Columns[0].Visible = true;
                dgvConsulta.Columns[0].Width = 150;
                dgvConsulta.RowTemplate.Height = 150;
            }
            else
            {
                dgvConsulta.Columns[0].Visible = false;
                dgvConsulta.RowTemplate.Height = 22;
            }
            BindingSource recurso = new BindingSource();
            recurso.DataSource = listado;
            dgvConsulta.DataSource = typeof(List<>);
            dgvConsulta.DataSource = recurso;            
            dgvConsulta.ClearSelection();
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void MostrarIconoMonitor()
        {
            if (UsuarioLogeadoPOS.User.Privilegios == "Solo Venta" || UsuarioLogeadoPOS.User.Privilegios == "Usuario Estandar" || UsuarioLogeadoPOS.User.Privilegios == "Solo POS")
            {
                pbMonitor.Visible = false;
            }
            if (UsuarioLogeadoPOS.User.Privilegios == "Administrador" || UsuarioLogeadoPOS.User.Privilegios == "Solo Caja")
            {
                pbMonitor.Visible = true;
            }
        }

        private void pbLupa_Click(object sender, EventArgs e)
        {
            vista = true;
            CargarCombosConsulta();
            CargaElementos();
        }

        private void btnCambiarVista_Click(object sender, EventArgs e)
        {
            CargaElementos();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Observaciones"] == null)
            {
                Observaciones oberv = new Observaciones(_observaciones, this);
                oberv.Show();
            }
            else
            {
                Application.OpenForms["Observaciones"].Activate();
            }
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            DatosCliente();
        }

        private void btnTraslados_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Traslados"] == null)
            {
                Traslados traslado = new Traslados();
                traslado.Show();
            }
            else
            {
                Application.OpenForms["Traslados"].Activate();
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            Cobrar(false);
        }

        private void pbCalculadora_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Calculadora"] == null)
            {
                Calculadora calc = new Calculadora();
                calc.Show();
            }
            else
            {
                Application.OpenForms["Calculadora"].Activate();
            }
        }

        private void btnSeleccionarGuardados_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DocumentosGuardados"] == null)
            {
                DocumentosGuardados guardados = new DocumentosGuardados(this);

                guardados.Show();
            }
            else
            {
                Application.OpenForms["DocumentosGuardados"].Activate();
            }

        }

        private void dgvListadoProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var fila = dgvListadoProductos.CurrentRow;
            decimal subtotal = 0.00m;
            decimal precio = 0.00m;
            if (fila != null)
            {
                int id = Convert.ToInt32(fila.Cells[colCodAlterno].Value);
                ListarProductos prod = _listadolocal.Where(x => x.Id == id).FirstOrDefault();
                if (ValidarExistenciasCero())//valida que un producto tenga existencias 
                {
                    if (ValidarStock(prod))//valida que la cantidad ingresada sea valida para las existencias del producto 
                    {
                        var cell = dgvListadoProductos.CurrentCell;
                        PrecioEscala(prod.Id, fila, cell.ColumnIndex);
                        if (fila.Cells[colRebajaD].Value == null && fila.Cells[colPrecioD].Value == null)
                        {

                            subtotal = Convert.ToDecimal(fila.Cells[colPrecio].Value) * Convert.ToInt32(fila.Cells[colCantidad].Value);
                            fila.Cells[colSubtotal].Value = subtotal;
                        }
                        else
                        {
                            if (cell.ColumnIndex == colRebajaD)
                            {
                                subtotal = Convert.ToDecimal(fila.Cells[colRebajaD].Value) * Convert.ToInt32(fila.Cells[colCantidad].Value);
                                fila.Cells[colPrecioD].Value = subtotal;
                                fila.Cells[colSubtotal].Value = subtotal;
                            }
                            else if (cell.ColumnIndex == colPrecioD)
                            {
                                subtotal = Convert.ToDecimal(fila.Cells[colPrecioD].Value);
                                precio = Convert.ToDecimal(fila.Cells[colPrecioD].Value) / Convert.ToInt32(fila.Cells[colCantidad].Value);

                                fila.Cells[colRebajaD].Value = decimal.Round(precio, 2);
                                fila.Cells[colSubtotal].Value = subtotal;
                            }
                            else if (cell.ColumnIndex == colCantidad)
                            {
                                subtotal = Convert.ToDecimal(fila.Cells[colRebajaD].Value) * Convert.ToInt32(fila.Cells[colCantidad].Value);
                                fila.Cells[colSubtotal].Value = subtotal;
                                fila.Cells[colPrecioD].Value = subtotal;
                            }
                            else
                            {
                                subtotal = Convert.ToDecimal(fila.Cells[colPrecio].Value) * Convert.ToInt32(fila.Cells[colCantidad].Value);
                                fila.Cells[colSubtotal].Value = subtotal;
                            }
                            if (fila.Cells[colRebajaD].Value == null || fila.Cells[colPrecioD].Value == null)
                            {
                                subtotal = Convert.ToDecimal(fila.Cells[colPrecio].Value) * Convert.ToInt32(fila.Cells[colCantidad].Value);
                                fila.Cells[colSubtotal].Value = subtotal;
                                fila.Cells[colRebajaD].Value = null;
                                fila.Cells[colPrecioD].Value = null;
                            }

                        }
                        Calculartotal();
                        CalcularDescuentos();
                        OtrasExistencias();
                    }
                    else
                    {
                        fila.Cells[colCantidad].Value = 1;
                        subtotal = Convert.ToDecimal(fila.Cells[colPrecio].Value) * Convert.ToInt32(fila.Cells[colCantidad].Value);
                        fila.Cells[colSubtotal].Value = subtotal;
                        MessageBox.Show("¡La cantidad ingresada excede a las existencias!");
                    }
                }
            }

        }

        private void dataGridView1_EditingControlShowing(object sender,
                                DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvListadoProductos.CurrentCell.ColumnIndex == colCodOriginal)
            {
                // Check box column
                _codigo = e.Control as ComboBox;
                _codigo.SelectedIndexChanged += new EventHandler(comboBoxCodigo_SelectedIndexChanged);
                //_codigo.SelectedIndexChanged += new EventHandler(comboBoxCodigo_KeyPress);
                indicefila = dgvListadoProductos.CurrentRow.Index;
            }

            if (dgvListadoProductos.CurrentCell.ColumnIndex == colCodAlterno)
            {
                // Check box column
                _codigoCorto = e.Control as ComboBox;
                _codigoCorto.SelectedIndexChanged += new EventHandler(comboBoxCodigoCorto_SelectedIndexChanged);
                indicefila = dgvListadoProductos.CurrentRow.Index;

            }
            if (dgvListadoProductos.CurrentCell.ColumnIndex == colDescripcion)
            {
                // Check box column
                _descripcion = e.Control as ComboBox;
                _descripcion.SelectedIndexChanged += new EventHandler(comboBoxDescripcion_SelectedIndexChanged);
                _descripcion.KeyPress += new KeyPressEventHandler(comboBoxCodigo_KeyPress);
                indicefila = dgvListadoProductos.CurrentRow.Index;

            }
        }
        void comboBoxCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Delete)
            {
                EliminarUltima();
            }
        }

        void comboBoxCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = ((ComboBox)sender).SelectedIndex;
            var fila = dgvListadoProductos.CurrentRow;
            indice = selectedIndex;
            if (indice > 0)
            {
                fila.Cells[colCodAlterno].Value = _listadolocal.ElementAt(indice).Id;
                fila.Cells[colDescripcion].Value = _listadolocal.ElementAt(indice).Descripcion;
                valores(fila);
                Calculartotal();
            }
        }

        void comboBoxCodigoCorto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = ((ComboBox)sender).SelectedIndex;
            var fila = dgvListadoProductos.CurrentRow;
            indice = selectedIndex;
            if (indice > 0)
            {
                fila.Cells[colCodOriginal].Value = _listadolocal.ElementAt(indice).CodigoReferencia;
                fila.Cells[colDescripcion].Value = _listadolocal.ElementAt(indice).Descripcion;
                valores(fila);
                Calculartotal();
            }
        }

        void comboBoxDescripcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = ((ComboBox)sender).SelectedIndex;
            var fila = dgvListadoProductos.CurrentRow;
            indice = selectedIndex;
            if (indice > 0)
            {
                fila.Cells[colCodOriginal].Value = _listadolocal.ElementAt(indice).CodigoReferencia;
                fila.Cells[colCodAlterno].Value = _listadolocal.ElementAt(indice).Id;
                valores(fila);
                Calculartotal();
            }
        }

        private void valores(DataGridViewRow fila)
        {
            if (indice > 0)
            {
                ListarProductos prod = _listadolocal.ElementAt(indice);
                int stock = 0;
                //if (fila.Cells[colCantidad].Value == null)
                //{
                fila.Cells[colCantidad].Value = 1;
                stock = 1;
                //}
                //else
                //{
                //stock = Convert.ToInt32(fila.Cells[colCantidad].Value.ToString());
                //}
                txtExistencia.Text = prod.Stock.ToString();

                decimal precio = PrecioProducto(prod.Id, 1);
                if (precio >= 0.01m)
                {
                    fila.Cells[colPrecio].Value = precio;
                    fila.Cells[colSubtotal].Value = stock * precio;
                }
                else
                {
                    fila.Cells[colPrecio].Value = prod.PrecioVenta;
                    fila.Cells[colSubtotal].Value = stock * prod.PrecioVenta;
                }
                MostrarDetalles(prod);
            }

            indice = 0;
        }

        private void MostrarDetalles(ListarProductos prod)
        {
            if (prod != null)
            {
                _ProductoId = prod.Id;
                if (prod.IncluyeColor == "Sí")
                {
                    CargarDetalle(prod.Id.ToString(), 1, prod.Descripcion);
                }
                else if (prod.Talla == "Sí")
                {
                    CargarDetalle(prod.Id.ToString(), 2, prod.Descripcion);
                }
                else if (prod.TomoEdicion == "Sí")
                {
                    CargarDetalle(prod.CodigoReferencia, 3, prod.Descripcion);
                }
                else
                {
                    pgDetalle.Visible = false;
                    pnlColor.Enabled = false;
                    pnlTalla.Enabled = false;
                    pnlTomo.Enabled = false;
                    pnlEdicion.Enabled = false;
                    lbProdColor.Text = "";
                    lbProdTalla.Text = "";
                    lbProdTomo.Text = "";
                    lbProdEdicion.Text = "";
                    mostrarMsgDetalle = false;
                }
            }
        }

        private void CargarDetalle(string codigo, int opc, string nombreProducto)
        {
            pgDetalle.Visible = true;
            mostrarMsgDetalle = true;
            LimpiarCombosDetalle();
            switch (opc)
            {
                case 1:
                    CargarColores(Convert.ToInt32(codigo));
                    pnlColor.Enabled = true;
                    pnlTalla.Enabled = false;
                    pnlTomo.Enabled = false;
                    pnlEdicion.Enabled = false;
                    lbProdColor.Text = nombreProducto;
                    lbProdTalla.Text = "";
                    lbProdTomo.Text = "";
                    lbProdEdicion.Text = "";
                    break;
                case 2:
                    CargarTallas(Convert.ToInt32(codigo));
                    pnlColor.Enabled = false;
                    pnlTalla.Enabled = true;
                    pnlTomo.Enabled = false;
                    pnlEdicion.Enabled = false;
                    lbProdColor.Text = "";
                    lbProdTalla.Text = nombreProducto;
                    lbProdTomo.Text = "";
                    lbProdEdicion.Text = "";
                    break;
                case 3:
                    var detalleTomo = _tomoEdicionRepository.GetListTomos(codigo).ToList();
                    var detalleEdicion = _tomoEdicionRepository.GetListEdiciones(codigo).ToList();
                    if (detalleTomo.Count() > 0)
                    {
                        CargarTomos(detalleTomo);
                        pnlColor.Enabled = false;
                        pnlTalla.Enabled = false;
                        pnlTomo.Enabled = true;
                        pnlEdicion.Enabled = false;
                        lbProdColor.Text = "";
                        lbProdTalla.Text = "";
                        lbProdTomo.Text = nombreProducto;
                        lbProdEdicion.Text = "";
                    }
                    else if (detalleEdicion.Count() > 0)
                    {
                        CargarEdicion(detalleEdicion);
                        pnlColor.Enabled = false;
                        pnlTalla.Enabled = false;
                        pnlTomo.Enabled = false;
                        pnlEdicion.Enabled = true;
                        lbProdColor.Text = "";
                        lbProdTalla.Text = "";
                        lbProdTomo.Text = "";
                        lbProdEdicion.Text = nombreProducto;
                    }
                    break;
            }
        }

        private void CargarColores(int ProductoId)
        {
            var detalleColores = _coloresRepository.GetProductoListaColor(ProductoId);
            if (detalleColores.Count() > 0)
            {
                cbColores.DataSource = detalleColores;
                cbColores.DisplayMember = "Color";
                cbColores.ValueMember = "Id";
                cbColores.SelectedIndex = 0;
                cbColores.Invalidate();
            }
            CargarAllDGV();
        }

        private void CargarTallas(int ProductoId)
        {
            var detalleTallas = _tallasRepository.GetTallaListaProducto(ProductoId);
            if (detalleTallas.Count() > 0)
            {
                cbTalla.DataSource = detalleTallas;
                cbTalla.DisplayMember = "Talla";
                cbTalla.ValueMember = "Id";
                cbTalla.SelectedIndex = 0;
                cbTalla.Invalidate();
            }
            CargarAllDGV();
        }

        private void CargarTomos(List<DetalleTomoEdicion> listado)
        {
            cbTomos.DataSource = listado;
            cbTomos.DisplayMember = "Tomo";
            cbTomos.ValueMember = "Id";
            cbTomos.SelectedIndex = 0;
            cbTomos.Invalidate();
            CargarAllDGV();
        }

        private void CargarEdicion(List<DetalleTomoEdicion> listado)
        {
            cbEdiciones.DataSource = listado;
            cbEdiciones.DisplayMember = "Edicion";
            cbEdiciones.ValueMember = "Id";
            cbEdiciones.SelectedIndex = 0;
            cbEdiciones.Invalidate();
            CargarAllDGV();
        }

        private void CargarAllDGV()
        {
            CargarDGVDetalle(dgvColores, "Color");
            CargarDGVDetalle(dgvTallas, "Talla");
            CargarDGVDetalle(dgvTomos, "Tomo");
            CargarDGVDetalle(dgvEdiciones, "Edicion");
        }

        private void LimpiarCombosDetalle()
        {
            cbColores.Text = "";
            cbTalla.Text = "";
            cbTomos.Text = "";
            cbEdiciones.Text = "";
        }

        private void Calculartotal()
        {
            decimal total = 0.00m;
            foreach (DataGridViewRow row in dgvListadoProductos.Rows)
            {
                total += Convert.ToDecimal(row.Cells[colSubtotal].Value);
            }
            txtTotal.Text = total.ToString();
            Totalf = total;
        }

        private decimal PrecioProducto(int ProductoId, int cantidad)
        {
            decimal Precio = 0.00m;
            var tipo = _preciosRepository.Get(ProductoId);
            string tipoCliente = cbTipoCliente.Text;
            if (tipo != null)
            {
                var detalleprecioslista = _preciosRepository.GetDetallePrecioListar(tipo.Id, 0);
                if (detalleprecioslista != null)
                {
                    foreach (var item in detalleprecioslista)
                    {
                        var tipoObtenido = _tipoclienteRepository.GetTipo(item.TiposId);
                        if (tipoObtenido.TipoCliente == tipoCliente)
                        {
                            Precio = item.Precio;
                        }
                        if (tipoObtenido.TipoCliente == tipoCliente)
                        {
                            Precio = item.Precio;
                        }
                        if (tipoObtenido.TipoCliente == tipoCliente)
                        {
                            Precio = item.Precio;
                        }
                        if (tipoObtenido.TipoCliente == tipoCliente)
                        {
                            Precio = item.Precio;
                        }
                    }
                }
            }
            return Precio;
        }

        private void PrecioEscala(int ProductoId, DataGridViewRow fila, int Index)
        {
            try
            {
                var prodtmp = _productosRepository.Get(ProductoId);
                if (fila != null)
                {
                    if (Index == 3)
                    {
                        if (prodtmp.TieneEscalas)
                        {
                            decimal PrecioEscala = 0.00m;
                            int Cantidad = Convert.ToInt32(fila.Cells[colCantidad].Value);
                            int tipoClienteId = Convert.ToInt32(cbTipoCliente.SelectedValue.ToString());
                            decimal precioActual = Convert.ToDecimal(fila.Cells[colPrecio].Value);
                            var tipoprecio = _preciosRepository.Get(prodtmp.Id);
                            List<DetallePrecio> detalles = new List<DetallePrecio>();
                            if (tipoprecio != null)
                            {
                                detalles = _preciosRepository.GetDetallePrecios(tipoprecio.Id);
                            }

                            if (detalles.Count > 0)
                            {
                                detalles.OrderByDescending(x => x.TiposId);
                                foreach (DetallePrecio detalle in detalles)
                                {
                                    if (detalle.TiposId == tipoClienteId)
                                    {
                                        if (Cantidad >= detalle.RangoInicio && Cantidad <= detalle.RangoFinal)
                                        {
                                            PrecioEscala = detalle.Precio;
                                        }
                                    }
                                }
                                if (PrecioEscala > 0.01m)
                                {
                                    fila.Cells[colPrecio].Value = PrecioEscala;
                                    fila.Cells[colSubtotal].Value = Cantidad * PrecioEscala;
                                }
                                else
                                {
                                    fila.Cells[colPrecio].Value = prodtmp.PrecioVenta;
                                    fila.Cells[colSubtotal].Value = Cantidad * prodtmp.PrecioVenta;
                                }
                            }
                            else
                            {
                                fila.Cells[colPrecio].Value = prodtmp.PrecioVenta;
                                fila.Cells[colSubtotal].Value = Cantidad * prodtmp.PrecioVenta;
                            }

                        }
                        else
                        {
                            fila.Cells[colPrecio].Value = prodtmp.PrecioVenta;
                            fila.Cells[colSubtotal].Value = Convert.ToInt32(fila.Cells[colCantidad].Value) * prodtmp.PrecioVenta;
                        }
                    }
                    else
                    {
                        fila.Cells[colPrecio].Value = prodtmp.PrecioVenta;
                        fila.Cells[colSubtotal].Value = Convert.ToInt32(fila.Cells[colCantidad].Value) * prodtmp.PrecioVenta;
                    }
                }
            }
            catch (Exception io)
            {
                KryptonMessageBox.Show("Error en escalas de precios " + io.Message);
            }
        }

        public void AsignarValoresDetalle(int opc, int cantidad, int idDetalle, string detalle)
        {
            var fila = dgvListadoProductos.CurrentRow;
            string codigo = fila.Cells[colCodOriginal].Value.ToString();
            switch (opc)
            {
                case 1:
                    fila.Cells[colCantidad].Value = cantidad;
                    fila.Cells[colColor].Value = idDetalle;
                    break;
                case 2:
                    fila.Cells[colCantidad].Value = cantidad;
                    fila.Cells[colTalla].Value = idDetalle;
                    break;
                case 3:
                    fila.Cells[colCantidad].Value = cantidad;
                    fila.Cells[colTE].Value = idDetalle;
                    break;
            }
        }

        private void CalcularDescuentos()
        {
            decimal p1 = 0.00m;
            decimal p2 = 0.00m;
            decimal resultado = 0.00m;
            decimal descuento = 0.00m;
            foreach (DataGridViewRow row in dgvListadoProductos.Rows)
            {
                if (!(row.Cells[colRebajaD].Value == null))
                {
                    p1 = Convert.ToDecimal(row.Cells[colPrecio].Value);
                    p2 = Convert.ToDecimal(row.Cells[colRebajaD].Value);
                    if (p1 > p2 && p2 >= 0.01m)
                    {
                        resultado = p1 - p2;
                        descuento += (resultado * Convert.ToInt32(row.Cells[colCantidad].Value));
                    }
                }
            }
            txtDescuento.Text = descuento.ToString();
        }

        public void OtrasExistencias()
        {
            var fila = dgvListadoProductos.CurrentRow;
            if (fila.Cells[colCodOriginal].Value != null)
            {
                string codigoreferencia = fila.Cells[colCodOriginal].Value.ToString();
                int cantidadExistencias = 0;
                var listadoProd = _listadoConsulta.Where(x => x.CodigoReferencia.Contains(codigoreferencia)).ToList();
                if (listadoProd.Count > 0)
                {
                    string sucursal = _sucursalesRepository.Get(UsuarioLogeadoPOS.User.SucursalId).NombreSucursal;
                    foreach (ListarProductos item in listadoProd)
                    {
                        if (item.Sucursal != sucursal)
                        {
                            cantidadExistencias += item.Stock;
                        }
                    }
                    txtEOtrasTiendas.Text = cantidadExistencias.ToString();
                }
            }
        }

        public void CargarListadoDetalleSolicitud()
        {
            if (dgvListadoProductos.RowCount > 0)
            {
                SolicitudDetalle detalleSolicitud = new SolicitudDetalle();
                foreach (DataGridViewRow row in dgvListadoProductos.Rows)
                {
                    if (row.Cells[colCodAlterno].Value != null)
                    {
                        if (row.Cells[colIdDoc].Value != null)
                        {
                            detalleSolicitud.Id = (int)row.Cells[colIdDoc].Value;
                        }
                        detalleSolicitud.ProductoId = Convert.ToInt32(row.Cells[colCodAlterno].Value);
                        detalleSolicitud.Cantidad = Convert.ToInt32(row.Cells[colCantidad].Value);
                        detalleSolicitud.Precio = Convert.ToDecimal(row.Cells[colPrecio].Value);
                        detalleSolicitud.SubTotal = Convert.ToDecimal(row.Cells[colSubtotal].Value);
                        if (row.Cells[colRebajaD].Value != null)
                        {
                            detalleSolicitud.Descuento = (detalleSolicitud.Precio - Convert.ToDecimal(row.Cells[colRebajaD].Value)) * detalleSolicitud.Cantidad;
                        }
                        detalleSolicitud.PrecioTotal = detalleSolicitud.SubTotal;

                        if (row.Cells[colColor].Value != null)
                        {
                            detalleSolicitud.DetalleColorId = Convert.ToInt32(row.Cells[colColor].Value);
                        }
                        if (row.Cells[colTalla].Value != null)
                        {
                            detalleSolicitud.DetalleTallaId = Convert.ToInt32(row.Cells[colTalla].Value);
                        }
                        if (row.Cells[colTE].Value != null)
                        {
                            detalleSolicitud.DetalleTomoEdicionId = Convert.ToInt32(row.Cells[colTE].Value);
                        }
                        _listadoSolicitudDetalle.Add(detalleSolicitud);
                        detalleSolicitud = new SolicitudDetalle();
                    }
                }
            }
        }

        public void CargarListadoDetalleVale()
        {
            if (dgvListadoProductos.RowCount > 0)
            {
                DetalleVale detallevale = new DetalleVale();
                foreach (DataGridViewRow row in dgvListadoProductos.Rows)
                {
                    if (row.Cells[colCodAlterno].Value != null)
                    {
                        if (row.Cells[colIdDoc].Value == null)
                        {
                            detallevale.Id = Guid.NewGuid();
                        }
                        else
                        {
                            detallevale.Id = (Guid)row.Cells[colIdDoc].Value;
                        }
                        detallevale.ProductoId = Convert.ToInt32(row.Cells[colCodAlterno].Value);
                        detallevale.Cantidad = Convert.ToInt32(row.Cells[colCantidad].Value);
                        detallevale.precio = Convert.ToDecimal(row.Cells[colPrecio].Value);
                        detallevale.PrecioTotal = Convert.ToDecimal(row.Cells[colSubtotal].Value);
                        if (row.Cells[colRebajaD].Value != null)
                        {
                            detallevale.Descuento = (detallevale.precio - Convert.ToDecimal(row.Cells[colRebajaD].Value)) * detallevale.Cantidad;
                        }
                        if (row.Cells[colColor].Value != null)
                        {
                            detallevale.DetalleColorId = Convert.ToInt32(row.Cells[colColor].Value);
                        }
                        if (row.Cells[colTalla].Value != null)
                        {
                            detallevale.DetalleTallaId = Convert.ToInt32(row.Cells[colTalla].Value);
                        }
                        if (row.Cells[colTE].Value != null)
                        {
                            detallevale.DetalleTomoEdicionId = Convert.ToInt32(row.Cells[colTE].Value);
                        }
                        _listadoValeDetalle.Add(detallevale);
                        detallevale = new DetalleVale();
                    }
                }
            }
        }

        public void CargarListadoDetalleCotizacion()
        {
            if (dgvListadoProductos.RowCount > 0)
            {
                DetalleCotizacion detalleCot = new DetalleCotizacion();
                foreach (DataGridViewRow row in dgvListadoProductos.Rows)
                {
                    if (row.Cells[colCodAlterno].Value != null)
                    {
                        if (row.Cells[colIdDoc].Value == null)
                        {
                            detalleCot.Id = Guid.NewGuid();
                        }
                        else
                        {
                            detalleCot.Id = (Guid)row.Cells[colIdDoc].Value;
                        }
                        detalleCot.ProductoId = Convert.ToInt32(row.Cells[colCodAlterno].Value);
                        detalleCot.Cantidad = Convert.ToInt32(row.Cells[colCantidad].Value);
                        detalleCot.Precio = Convert.ToDecimal(row.Cells[colPrecio].Value);
                        detalleCot.PrecioTotal = Convert.ToDecimal(row.Cells[colSubtotal].Value);
                        if (row.Cells[colRebajaD].Value != null)
                        {
                            detalleCot.Descuento = detalleCot.Precio - Convert.ToDecimal(row.Cells[colRebajaD].Value);
                        }
                        if (row.Cells[colColor].Value != null)
                        {
                            detalleCot.DetalleColorId = Convert.ToInt32(row.Cells[colColor].Value);
                        }
                        if (row.Cells[colTalla].Value != null)
                        {
                            detalleCot.DetalleTallaId = Convert.ToInt32(row.Cells[colTalla].Value);
                        }
                        if (row.Cells[colTE].Value != null)
                        {
                            detalleCot.DetalleTomoEdicionId = Convert.ToInt32(row.Cells[colTE].Value);
                        }
                        _listadoCotDetalle.Add(detalleCot);
                        detalleCot = new DetalleCotizacion();
                    }
                }
            }
        }

        public void GuardarVenta(bool MostrarMonitor)
        {
            try
            {
                int value = (int)cbTipoOperacion.SelectedValue;
                switch (value)
                {
                    case 21:
                        GuardarCotizacion();
                        break;
                    case 22:
                        GuardarVale();
                        break;
                    default:
                        GuardarVentaPendiente();
                        break;
                }
                GuardarDetalles();
                ActualizarProductosTemporales();
                ProductosCredito(value);
                CargarDatos();
                LimpiarGridListado();
                Actualizar();
                btnLimpiar_Click(null, null);
                if (MostrarMonitor)
                {
                    if (UsuarioLogeadoPOS.User.Privilegios == "Solo Venta" || UsuarioLogeadoPOS.User.Privilegios == "Usuario Estandar" || UsuarioLogeadoPOS.User.Privilegios == "Solo POS")
                    {
                        MessageBox.Show("¡Datos Guardados con Éxito!", "Notificación");
                    }
                    if (UsuarioLogeadoPOS.User.Privilegios == "Administrador" || UsuarioLogeadoPOS.User.Privilegios == "Solo Caja")
                    {
                        if(value != 17)
                            CargarFormsPago();
                        else
                            MessageBox.Show("¡Datos Guardados con Éxito!", "Notificación");
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

        private void GuardarCotizacion()
        {
            CargarListadoDetalleCotizacion();
            GuardarCotizacionProd();
            _listadoCotDetalle = new List<DetalleCotizacion>();
        }

        private void GuardarVale()
        {
            CargarListadoDetalleVale();
            GuardarValeProd();
            _listadoValeDetalle = new List<DetalleVale>();
        }

        private void GuardarVentaPendiente()
        {
            CargarListadoDetalleSolicitud();
            GuardarSolicitudProd();
            _listadoSolicitudDetalle = new List<SolicitudDetalle>();
        }

        private SolicitudToFacturar GetModelSolicitud()
        {
            if (update)
            {
                _solicitudUpdate.NitCliente = _cliente.Nit;
                _solicitudUpdate.NombreCliente = _cliente.Nombres;
                _solicitudUpdate.DireccionCliente = _cliente.Direccion;
                _solicitudUpdate.ClienteId = _cliente.Id;
                _solicitudUpdate.UserId = cbVendedor.SelectedValue.ToString();
                _solicitudUpdate.Vendedor = cbVendedor.Text;
                _solicitudUpdate.FechaVenta = dtpFecha.Value;
                _solicitudUpdate.Observaciones = _observaciones;
                _solicitudUpdate.SucursalId = sucursalVendedor;
                _solicitudUpdate.Temporales = ProductosTemporales;
                return _solicitudUpdate;
            }
            else
            {
                SolicitudToFacturar enc = new SolicitudToFacturar();
                enc.Id = Guid.NewGuid();
                enc.NoSolicitud = txtNumeroPedido.Text;
                enc.NitCliente = _cliente.Nit;
                enc.NombreCliente = _cliente.Nombres;
                enc.DireccionCliente = _cliente.Direccion;
                enc.ClienteId = _cliente.Id;
                enc.UserId = cbVendedor.SelectedValue.ToString();
                enc.Vendedor = cbVendedor.Text;
                enc.FechaVenta = dtpFecha.Value;
                enc.Observaciones = _observaciones;
                enc.Estado = false;
                enc.SucursalId = sucursalVendedor;
                enc.Temporales = ProductosTemporales;
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
                        _cuentaPorCobrar.SaldoActual += Convert.ToDecimal(txtTotal.Text);
                        _cuentasCobrarRepository.Update(_cuentaPorCobrar);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error interno al guardar los datos. \n" + ex.Message);
            }
        }

        private Vale GetModelVale()
        {
            if (update)
            {
                _valeUpdate.Monto = Convert.ToDecimal(txtTotal.Text);
                _valeUpdate.SucursalId = sucursalVendedor;
                _valeUpdate.UserId = cbVendedor.SelectedValue.ToString();
                _valeUpdate.TiposId = Convert.ToInt32(cbTipoCliente.SelectedValue);
                _valeUpdate.Observaciones = _observaciones;
                return _valeUpdate;
            }
            else
            {
                Vale enc = new Vale();
                enc.Id = Guid.NewGuid();
                enc.Descripcion = "Vale Generado el " + DateTime.Now + " para " + _cliente.Nombres;
                enc.FechaRecepcion = dtpFecha.Value;
                enc.NoVale = txtNumeroPedido.Text;
                enc.Monto = Convert.ToDecimal(txtTotal.Text);
                enc.SucursalId = sucursalVendedor;
                enc.UserId = cbVendedor.SelectedValue.ToString();
                enc.TiposId = Convert.ToInt32(cbTipoCliente.SelectedValue);
                enc.IsActive = false;
                enc.Observaciones = _observaciones;
                return enc;
            }
        }

        private AsignacionVale GetModelAsigVale(Guid noVale)
        {
            if (update)
            {
                _asigValeUpdate.Nombre = _cliente.Nombres;
                _asigValeUpdate.Direccion = _cliente.Direccion;
                _asigValeUpdate.Nit = _cliente.Nit;
                _asigValeUpdate.ClienteId = _cliente.Id;
                _asigValeUpdate.Monto = Convert.ToDecimal(txtTotal.Text);
                _asigValeUpdate.Reciduo = 0.00m;
                //_asigValeUpdate.Estado = "0";
                _asigValeUpdate.FechaCambio = _asigValeUpdate.FechaCambio.AddDays(8);
                return _asigValeUpdate;
            }
            else
            {
                AsignacionVale enc = new AsignacionVale();
                enc.Id = Guid.NewGuid();
                enc.ValeId = noVale;
                enc.FechaAsignacion = dtpFecha.Value;
                enc.NumeroVale = txtNumeroPedido.Text;
                enc.Nombre = _cliente.Nombres;
                enc.Direccion = _cliente.Direccion;
                enc.Nit = _cliente.Nit;
                enc.ClienteId = _cliente.Id;
                enc.Monto = Convert.ToDecimal(txtTotal.Text);
                enc.Reciduo = 0.00m;
                enc.Estado = "0";
                enc.FechaCambio = dtpFecha.Value.AddDays(8);
                return enc;
            }
        }

        private void GuardarValeProd()
        {
            try
            {
                if (update)
                {
                    var vale = GetModelVale();
                    if (!ModelState.IsValid(vale)) return;
                    _valesRepository.Update(vale);

                    var asigVale = GetModelAsigVale(vale.Id);
                    if (!ModelState.IsValid(asigVale)) return;
                    _valesRepository.UpdateAsignacion(asigVale);

                    foreach (var item in _listadoValeDetalle)
                    {
                        var detVale = _valesRepository.GetDetalleVale(item.Id);
                        if (detVale != null)
                        {
                            detVale.ProductoId = item.ProductoId;
                            detVale.Cantidad = item.Cantidad;
                            detVale.precio = item.precio;
                            detVale.Descuento = item.Descuento;
                            detVale.PrecioTotal = item.PrecioTotal;
                            _valesRepository.UpdateDetalleVale(detVale);
                        }
                        else
                        {
                            item.AsignacionValeId = asigVale.Id;
                            _valesRepository.AddDetalle(item);
                        }
                    }
                }
                else
                {
                    var vale = GetModelVale();
                    if (!ModelState.IsValid(vale)) return;
                    _valesRepository.Add(vale);

                    var asigVale = GetModelAsigVale(vale.Id);
                    if (!ModelState.IsValid(asigVale)) return;
                    _valesRepository.AddAsignacionVale(asigVale);

                    foreach (var item in _listadoValeDetalle)
                    {
                        item.AsignacionValeId = asigVale.Id;
                        _valesRepository.AddDetalle(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error interno al guardar los datos. \n" + ex.Message);
            }
        }

        private Cotizacion GetModelCotizacion()
        {
            if (update)
            {
                _cotizacionUpdate.Nombre = _cliente.Nombres;
                _cotizacionUpdate.Direccion = _cliente.Direccion;
                _cotizacionUpdate.Nit = _cliente.Nit;
                _cotizacionUpdate.NombreVendedor = cbVendedor.Text;
                _cotizacionUpdate.ClienteId = _cliente.Id;
                _cotizacionUpdate.SucursalId = sucursalVendedor;
                _cotizacionUpdate.Observaciones = _observaciones;
                _cotizacionUpdate.FechaLimite = _cotizacionUpdate.FechaLimite.AddDays(8);
                return _cotizacionUpdate;
            }
            else
            {
                Cotizacion cotz = new Cotizacion();
                cotz.Id = Guid.NewGuid();
                cotz.NoCotizacion = txtNumeroPedido.Text;
                cotz.FechaRecepcion = dtpFecha.Value;
                cotz.FechaLimite = dtpFecha.Value.AddDays(8);

                cotz.Nombre = _cliente.Nombres;
                cotz.Direccion = _cliente.Direccion;
                cotz.Nit = _cliente.Nit;
                cotz.NombreVendedor = cbVendedor.Text;
                cotz.ClienteId = _cliente.Id;
                cotz.SucursalId = sucursalVendedor;
                cotz.Estado = false;
                cotz.Observaciones = _observaciones;
                return cotz;
            }
        }

        private void GuardarCotizacionProd()
        {
            try
            {
                if (update)
                {
                    var cotizacion = GetModelCotizacion();
                    if (!ModelState.IsValid(cotizacion)) return;
                    _cotizacionRepository.Updatecotizacion(cotizacion);

                    foreach (var item in _listadoCotDetalle)
                    {
                        var detCotizacion = _cotizacionRepository.GetDetalleCotizacion(item.Id);
                        if (detCotizacion != null)
                        {
                            detCotizacion.ProductoId = item.ProductoId;
                            detCotizacion.Cantidad = item.Cantidad;
                            detCotizacion.Precio = item.Precio;
                            detCotizacion.Descuento = item.Descuento;
                            detCotizacion.PrecioTotal = item.PrecioTotal;
                            _cotizacionRepository.UpdateDetalleCotizacion(detCotizacion);
                        }
                        else
                        {
                            item.CotizacionId = cotizacion.Id;
                            _cotizacionRepository.AddDetalles(item);
                        }
                    }
                }
                else
                {
                    var cotizacion = GetModelCotizacion();
                    if (!ModelState.IsValid(cotizacion)) return;
                    _cotizacionRepository.AddEncabezado(cotizacion);

                    foreach (var item in _listadoCotDetalle)
                    {
                        item.CotizacionId = cotizacion.Id;
                        _cotizacionRepository.AddDetalles(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error interno al guardar los datos. \n" + ex.Message);
            }
        }

        public void LimpiarGridListado()
        {
            int count = 0;
            foreach (DataGridViewRow row in dgvListadoProductos.Rows)
            {
                if (row.Cells[colCodOriginal].Value != null)
                {
                    count++;
                }
            }

            for (int i = 0; i < count; i++)
            {
                dgvListadoProductos.Rows.RemoveAt(0);
            }
        }

        public bool ValidarStock(ListarProductos prod)
        {
            bool valida = false;
            var cell = dgvListadoProductos.CurrentCell;
            var row = dgvListadoProductos.CurrentRow;
            if (cell.ColumnIndex == 3)
            {
                int cantidadIngresada = Convert.ToInt32(row.Cells[colCantidad].Value);
                if (cantidadIngresada <= prod.Stock)
                {
                    valida = true;
                }
                else
                {
                    valida = false;
                }
            }
            else
            {
                valida = true;
            }
            return valida;
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

        private void dgvListadoProductos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnPrecios_Click(object sender, EventArgs e)
        {
            Int32 selectedCellCount =
            dgvConsulta.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                if (Application.OpenForms["DetallePrecios"] == null)
                {
                    ListarProductos prod = (ListarProductos)dgvConsulta.CurrentRow.DataBoundItem;

                    DetallePrecios precios = new DetallePrecios(prod);
                    precios.Show();
                }
                else
                {
                    Application.OpenForms["DetallePrecios"].Activate();
                }
            }
        }

        private void cbDetalleProdcuto_TextChanged(object sender, EventArgs e)
        {
            string descripcion = cbDetalleProdcuto.Text.ToUpper();
            string descmin = cbDetalleProdcuto.Text;
            var filter = _listadoConsulta.Where(a => a.Descripcion.Contains(descripcion) || a.Descripcion.Contains(descmin));
            dgvConsulta.DataSource = filter.ToList();
        }

        private void cbPuntodeventa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sucursal = cbPuntodeventa.Text;
            var filter = _listadoConsulta.Where(a => a.Sucursal.Contains(sucursal));
            dgvConsulta.DataSource = filter.ToList();
        }

        private void cbDetalleProdcuto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDetalleProdcuto.SelectedValue != null)
            {
                int idproducto = Convert.ToInt32(cbPuntodeventa.SelectedValue);
                var filter = _listadoConsulta.Where(a => a.Id == idproducto);
                dgvConsulta.DataSource = filter.ToList();
            }

        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            pgConsulta.Visible = true;
            dgvConsulta.Visible = true;
            string descripcion = txtBuscador.Text.ToUpper().Trim();
            string descmin = txtBuscador.Text.Trim();
            List<int> marcas = _marcasRepository.GetMarcaName(descripcion);

            var filter = _listadoConsulta.Where(a => a.Descripcion.Contains(descripcion) || a.Descripcion.Contains(descmin) ||
                                    a.CodigoReferencia.Contains(descmin) || a.CodigoReferencia.Contains(descripcion) ||
                                    marcas.Contains(a.Marca)).ToList();
            CargaGridProductosConsulta(filter, vista);
        }

        private void dgvConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            int sucursal = UsuarioLogeadoPOS.User.SucursalId;
            var fila = dgvConsulta.CurrentRow;
            var producto = (ListarProductos)fila.DataBoundItem;
            var prod = _productosRepository.Get(producto.Id);
            if (prod.SucursalId == sucursal)
            {
                dgvListadoProductos.Rows.Add(new DataGridViewRow());
                int indice = dgvListadoProductos.Rows.Count - 2;
                var data = dgvListadoProductos.Rows[indice];

                if (!EvaluarProductoListado(producto.CodigoReferencia, 0))
                {
                    data.Cells[colCodOriginal].Value = producto.CodigoReferencia;
                    data.Cells[colCodAlterno].Value = producto.Id;
                    data.Cells[colDescripcion].Value = producto.Descripcion;
                    data.Cells[colCantidad].Value = 1;
                    data.Cells[colPrecio].Value = producto.PrecioVenta;
                    data.Cells[colRebajaD].Value = null;
                    data.Cells[colPrecioD].Value = null;
                    data.Cells[colSubtotal].Value = 1 * producto.PrecioVenta;
                    txtExistencia.Text = producto.Stock.ToString();
                    MostrarDetalles(producto);
                }
                else
                {
                    EliminarUltima();
                }
                mostrarMsgDetalle = false;
                knPOS.SelectedPage = pgPuntoDeVenta;
                PrecioEscala(prod.Id, data, 3);
                Calculartotal();
                CalcularDescuentos();
                OtrasExistencias();
                mostrarMsgDetalle = true;
            }
            else
            {
                MessageBox.Show("El producto seleccionado se encuentra en otra sucursal.", "Notificación");
            }
        }

        private void dgvListadoProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Delete)
            {
                var fila = dgvListadoProductos.CurrentRow;
                var cell = dgvListadoProductos.CurrentCell;
                decimal subtotal = 0.00m;
                if (cell.ColumnIndex == 5 || cell.ColumnIndex == 6)
                {
                    dgvListadoProductos.CurrentRow.Cells[colRebajaD].Value = "";
                    dgvListadoProductos.CurrentRow.Cells[colPrecioD].Value = "";
                    subtotal = Convert.ToDecimal(fila.Cells[colPrecio].Value) * Convert.ToInt32(fila.Cells[colCantidad].Value);
                    fila.Cells[colSubtotal].Value = subtotal;
                }
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            decimal totaltmp = Convert.ToDecimal(txtTotal.Text);
            if (totaltmp < Totalf)
            {
                decimal r = Totalf - totaltmp;
                porcentajeD = (r * 100) / Totalf;
                lbPorcentajeD.Text = decimal.Round(porcentajeD, 2) + "%";
                Totalf = totaltmp;
            }
            else
            {
                lbPorcentajeD.Text = "0.00%";
            }
        }

        private void dgvListadoProductos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var fila = dgvListadoProductos.CurrentRow;

            if (fila != null)
            {
                _ProductoId = Convert.ToInt32(fila.Cells[colCodAlterno].Value);
                var prod = _productosRepository.GetListaProducto(_ProductoId);
                MostrarDetalles(prod);
            }
        }

        private bool ValidarExistenciasCero()
        {
            bool valida = true;
            var fila = dgvListadoProductos.CurrentRow;
            int id = Convert.ToInt32(fila.Cells[colCodAlterno].Value);
            ListarProductos prod = _listadolocal.Where(x => x.Id == id).FirstOrDefault();
            if (prod != null)
            {
                if (prod.Stock == 0)
                {
                    MessageBox.Show("¡No hay existencias del producto!");
                    EliminarUltima();
                    valida = false;
                }
                else
                {
                    valida = true;
                }
            }
            else
            {
                valida = false;
            }
            return valida;
        }

        private void ReiniciarCombos(DataGridViewRow fila)
        {
            if (Application.OpenForms["SeleccionarElemento"] != null)
            {
                Application.OpenForms["SeleccionarElemento"].Close();
            }
            fila.Cells[colCodOriginal].Value = _listadolocal.ElementAt(0).CodigoReferencia;
            fila.Cells[colCodAlterno].Value = _listadolocal.ElementAt(0).Id;
            fila.Cells[colDescripcion].Value = _listadolocal.ElementAt(0).Descripcion;
            fila.Cells[colCantidad].Value = null;
            fila.Cells[colPrecio].Value = null;
            fila.Cells[colRebajaD].Value = null;
            fila.Cells[colPrecioD].Value = null;
            fila.Cells[colSubtotal].Value = null;
            indice = fila.Index;
        }

        private bool EvaluarProductoListado(string Codigo, int idDetalle)
        {
            bool validacion = false;
            foreach (DataGridViewRow row in dgvListadoProductos.Rows)
            {
                if (row.Cells[colColor].Value != null)
                {
                    int id = Convert.ToInt32(row.Cells[colColor].Value);
                    if (id == idDetalle)
                    {
                        return true;
                    }
                }
                else if (row.Cells[colTalla].Value != null)
                {
                    int id = Convert.ToInt32(row.Cells[colTalla].Value);
                    if (id == idDetalle)
                    {
                        return true;
                    }
                }
                else if (row.Cells[colTE].Value != null)
                {
                    int id = Convert.ToInt32(row.Cells[colTE].Value);
                    if (id == idDetalle)
                    {
                        return true;
                    }
                }
                else
                {
                    if (row.Cells[colCodOriginal].Value != null)
                    {
                        string CodigoBarras = row.Cells[colCodOriginal].Value.ToString();
                        if (CodigoBarras == Codigo)
                        {
                            return true;
                        }
                    }

                }
            }
            return validacion;
        }

        public static string GenerateRandom(string tipo)
        {
            Random randomGenerate = new System.Random();
            string nocuenta = tipo;
            var cadena = System.Convert.ToString(randomGenerate.Next(00000001, 99999999));
            var resulto = String.Concat(nocuenta, cadena);
            return resulto;
        }

        private void cbTipoOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNumeroPedido.Text = Numero();
        }

        public void CargarDocumento(int doc, Guid id)
        {
            update = true;
            cbTipoOperacion.SelectedValue = doc;
            LimpiarGridListado();
            switch (doc)
            {
                case 16:
                    CargarSolicitud(doc, id);
                    MostrarCamposCuentas(false);
                    btnCobrar.Enabled = true;
                    break;
                case 17:
                    CargarSolicitud(doc, id);
                    MostrarCamposCuentas(true);
                    btnCobrar.Enabled = false;
                    break;
                case 21:
                    CargarCotizacion(doc, id);
                    MostrarCamposCuentas(false);
                    btnCobrar.Enabled = true;
                    break;
                case 22:
                    CargarVale(doc, id);
                    MostrarCamposCuentas(false);
                    btnCobrar.Enabled = true;
                    break;
            }
        }

        private void CargarSolicitud(int doc, Guid id)
        {
            try
            {
                _solicitudUpdate = _solicitudesRepository.Get(id);
                var solicitud = _solicitudUpdate;
                if (solicitud != null)
                {
                    txtNumeroPedido.Text = solicitud.NoSolicitud;
                    noDocumetno = solicitud.NoSolicitud;
                    dtpFecha.Value = solicitud.FechaVenta;
                    _observaciones = solicitud.Observaciones;
                    if (solicitud.ClienteId > 0)
                    {
                        _cliente = _clientesRepository.Get(solicitud.ClienteId);
                        cbTipoCliente.SelectedValue = _cliente.TiposId;
                    }
                    else
                    {
                        _cliente = new Cliente
                        {
                            Nombres = solicitud.NombreCliente,
                            Direccion = solicitud.DireccionCliente,
                            Nit = solicitud.NitCliente
                        };
                    }
                    var detallesolicitudes = _solicitudesRepository.GetDetallebySolicitud(solicitud.Id);
                    decimal descuentoT = 0.00m;
                    foreach (SolicitudDetalle item in detallesolicitudes)
                    {
                        var producto = _productosRepository.Get((int)item.ProductoId);
                        dgvListadoProductos.Rows.Add(new DataGridViewRow());
                        int indice = dgvListadoProductos.Rows.Count - 2;
                        var data = dgvListadoProductos.Rows[indice];

                        decimal pDescuento = 0.00m;
                        if (item.Descuento > 0)
                        {
                            descuentoT += descuentoT;
                            pDescuento = item.Precio - (item.Descuento / item.Cantidad);
                        }

                        data.Cells[colCodOriginal].Value = producto.CodigoBarras;
                        data.Cells[colCodAlterno].Value = producto.Id;
                        data.Cells[colDescripcion].Value = producto.Descripcion;
                        data.Cells[colCantidad].Value = item.Cantidad;
                        data.Cells[colPrecio].Value = item.Precio;
                        data.Cells[colRebajaD].Value = pDescuento;
                        data.Cells[colPrecioD].Value = pDescuento * item.Cantidad;
                        data.Cells[colSubtotal].Value = item.SubTotal;
                        data.Cells[colIdDoc].Value = item.Id;
                        data.Cells[colColor].Value = item.DetalleColorId;
                        data.Cells[colTalla].Value = item.DetalleTallaId;
                        data.Cells[colTE].Value = item.DetalleTomoEdicionId;
                    }
                    _listaDetalle = _detalleProductoRepository.GetListNoDocumento(solicitud.NoSolicitud);
                    Calculartotal();
                    CalcularDescuentos();
                    _observaciones = solicitud.Observaciones;
                    if (cbVendedor.SelectedValue.ToString() != solicitud.UserId.ToString())
                    {
                        validacionToken = false;
                        mostrarIngresoToken = true;
                    }
                    cbVendedor.SelectedValue = solicitud.UserId;
                    if (doc == 17)
                    {
                        var credito = _clienteCreditoRepository.GetByDocumento(solicitud.Id);
                        if (credito != null)
                        {
                            _cuentaPorCobrar = _cuentasCobrarRepository.Get(credito.CuentaCBId);
                            lbCuentaxCobrar.Text = _cuentaPorCobrar.NoCuenta;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("¡No se pudo obtener la venta!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡No se pudo obtener la venta! \n" + ex.Message);
            }
        }

        private void CargarCotizacion(int doc, Guid id)
        {
            try
            {
                _cotizacionUpdate = _cotizacionRepository.GetCotizacion(id);
                var cotizacion = _cotizacionUpdate;
                if (cotizacion != null)
                {
                    txtNumeroPedido.Text = cotizacion.NoCotizacion;
                    noDocumetno = cotizacion.NoCotizacion;
                    dtpFecha.Value = cotizacion.FechaRecepcion;
                    _observaciones = cotizacion.Observaciones;

                    if (cotizacion.ClienteId > 0)
                    {
                        _cliente = _clientesRepository.Get(cotizacion.ClienteId);
                        cbTipoCliente.SelectedValue = _cliente.TiposId;
                    }
                    else
                    {
                        _cliente = new Cliente
                        {
                            Nombres = cotizacion.Nombre,
                            Direccion = cotizacion.Direccion,
                            Nit = cotizacion.Nit
                        };
                    }
                    var detallecotizaciones = _cotizacionRepository.GetDetalleCotizacionslista(cotizacion.Id);
                    foreach (DetalleCotizacion item in detallecotizaciones)
                    {
                        var producto = _productosRepository.Get((int)item.ProductoId);
                        dgvListadoProductos.Rows.Add(new DataGridViewRow());
                        int indice = dgvListadoProductos.Rows.Count - 2;
                        var data = dgvListadoProductos.Rows[indice];

                        decimal pDescuento = 0.00m;
                        if (item.Descuento > 0)
                            pDescuento = item.Precio - (item.Descuento / item.Cantidad);
                        data.Cells[colCodOriginal].Value = producto.CodigoBarras;
                        data.Cells[colCodAlterno].Value = producto.Id;
                        data.Cells[colDescripcion].Value = producto.Descripcion;
                        data.Cells[colCantidad].Value = item.Cantidad;
                        data.Cells[colPrecio].Value = item.Precio;
                        data.Cells[colRebajaD].Value = pDescuento;
                        data.Cells[colPrecioD].Value = pDescuento * item.Cantidad;
                        data.Cells[colSubtotal].Value = item.PrecioTotal;
                        data.Cells[colIdDoc].Value = item.Id;
                        data.Cells[colColor].Value = item.DetalleColorId;
                        data.Cells[colTalla].Value = item.DetalleTallaId;
                        data.Cells[colTE].Value = item.DetalleTomoEdicionId;
                    }
                    _listaDetalle = _detalleProductoRepository.GetListNoDocumento(cotizacion.NoCotizacion);
                    Calculartotal();
                    CalcularDescuentos();
                    _observaciones = cotizacion.Observaciones;
                    User usuario = null;
                    if (cbVendedor.Text != cotizacion.NombreVendedor)
                    {
                        var usuarios = _usersRepository.GetlistaUsuarios();
                        usuario = usuarios.Where(x => x.Name == cotizacion.NombreVendedor).FirstOrDefault();
                        validacionToken = false;
                        mostrarIngresoToken = true;
                    }
                    cbVendedor.SelectedValue = usuario.Id;
                }
                else
                {
                    MessageBox.Show("¡No se pudo obtener la cotización!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡No se pudo obtener la cotización! \n" + ex.Message);
            }
        }

        private void CargarVale(int doc, Guid id)
        {
            try
            {
                _valeUpdate = _valesRepository.GetVale(id);
                var vale = _valeUpdate;
                if (vale != null)
                {
                    txtNumeroPedido.Text = vale.NoVale;
                    noDocumetno = vale.NoVale;
                    dtpFecha.Value = vale.FechaRecepcion;
                    cbTipoCliente.SelectedValue = vale.TiposId;
                    _observaciones = vale.Observaciones;

                    _asigValeUpdate = _valesRepository.GetAsignacionVale(vale.Id).FirstOrDefault();
                    var asigVale = _asigValeUpdate;
                    if (asigVale != null)
                    {
                        if (asigVale.ClienteId > 0)
                        {
                            _cliente = _clientesRepository.Get((int)asigVale.ClienteId);
                            cbTipoCliente.SelectedValue = _cliente.TiposId;
                        }
                        else
                        {
                            _cliente = new Cliente
                            {
                                Nombres = asigVale.Nombre,
                                Direccion = asigVale.Direccion,
                                Nit = asigVale.Nit
                            };
                        }
                        var detallevale = _valesRepository.GetListadoDetalleVales(asigVale.Id);
                        decimal descuentoT = 0.00m;
                        foreach (DetalleVale item in detallevale)
                        {
                            var producto = _productosRepository.Get((int)item.ProductoId);
                            dgvListadoProductos.Rows.Add(new DataGridViewRow());
                            int indice = dgvListadoProductos.Rows.Count - 2;
                            var data = dgvListadoProductos.Rows[indice];

                            decimal pDescuento = 0.00m;
                            if (item.Descuento >= 1)
                            {
                                descuentoT += item.Descuento;
                                pDescuento = item.precio - (item.Descuento / item.Cantidad);
                            }

                            data.Cells[colCodOriginal].Value = producto.CodigoBarras;
                            data.Cells[colCodAlterno].Value = producto.Id;
                            data.Cells[colDescripcion].Value = producto.Descripcion;
                            data.Cells[colCantidad].Value = item.Cantidad;
                            data.Cells[colPrecio].Value = item.precio;
                            data.Cells[colRebajaD].Value = pDescuento;
                            data.Cells[colPrecioD].Value = pDescuento * item.Cantidad;
                            data.Cells[colSubtotal].Value = item.PrecioTotal;
                            data.Cells[colIdDoc].Value = item.Id;
                            data.Cells[colColor].Value = item.DetalleColorId;
                            data.Cells[colTalla].Value = item.DetalleTallaId;
                            data.Cells[colTE].Value = item.DetalleTomoEdicionId;
                        }
                        _listaDetalle = _detalleProductoRepository.GetListNoDocumento(vale.NoVale);
                        Calculartotal();
                        CalcularDescuentos();
                        _observaciones = vale.Observaciones;
                        if (cbVendedor.SelectedValue.ToString() != vale.UserId.ToString())
                        {
                            validacionToken = false;
                            mostrarIngresoToken = true;
                        }
                        cbVendedor.SelectedValue = vale.UserId;
                    }
                    else
                    {
                        MessageBox.Show("¡No se pudo obtener el detalle del vale!");
                    }
                }
                else
                {
                    MessageBox.Show("¡No se pudo obtener el detalle del vale!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡No se pudo obtener el vale! \n" + ex.Message);
            }
        }



        private void DatosCliente()
        {
            DialogResult dialogResult = MessageBox.Show("El tipo de cliente es: " + cbTipoCliente.Text.ToUpper(), "Confirmación", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Application.OpenForms["DatosCliente"] == null)
                {
                    int tipocliente = Convert.ToInt32(cbTipoCliente.SelectedValue);
                    DatosCliente cliente = new DatosCliente(_cliente, tipocliente, this, TokenObtenidoSat, conectado);
                    cliente.Show();
                }
                else
                {
                    Application.OpenForms["DatosCliente"].Activate();
                }
            }
        }

        private void Cobrar(bool mostrarMonitor)
        {
            pressedKeys = new List<Keys>();
            if (dgvListadoProductos.RowCount > 1)
            {
                if (_cliente.Nombres != null && _cliente.Nit != null)
                {
                    
                    if (validacionToken)
                    {
                        if (ValidarCuentaxCobrar())
                        {
                            GuardarVenta(mostrarMonitor);
                        }
                    }
                    else
                    {
                        IngresarToken(true);
                    }
                }
                else
                {
                    DatosCliente();
                }
            }
            else
            {
                MessageBox.Show("¡No puede guardarse la información! \n El Listado esta vacio.");
            }
        }

        public void EliminarUltima()
        {
            int rows = dgvListadoProductos.Rows.Count;
            if (rows > 0)
            {
                var lastRow = dgvListadoProductos.Rows[rows - 2];
                dgvListadoProductos.Rows.RemoveAt(rows - 2);
            }
        }

        private void knPOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2)
            {
                DatosCliente();
            }
            else
            {
                pressedKeys.Add(e.KeyCode);
            }

            if (pressedKeys.Exists(x => x == Keys.ShiftKey) && pressedKeys.Exists(x => x == Keys.F5))
            {
                Cobrar(false);
            }
        }

        private void dgvListadoProductos_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var fila = dgvListadoProductos.CurrentRow;
            try
            {
                if (fila.Cells[colIdDoc].Value != null)
                {
                    int doc = Convert.ToInt32(cbTipoOperacion.SelectedValue);
                    switch (doc)
                    {
                        case 16:
                            int idcn = Convert.ToInt32(fila.Cells[colIdDoc].Value);
                            var detallecn = _solicitudesRepository.GetDetalleSolicitud(idcn);
                            _solicitudesRepository.DeleteDetalleSolicitud(detallecn);
                            break;
                        case 17:
                            int idcr = Convert.ToInt32(fila.Cells[colIdDoc].Value);
                            var detallecr = _solicitudesRepository.GetDetalleSolicitud(idcr);
                            _solicitudesRepository.DeleteDetalleSolicitud(detallecr);
                            break;
                        case 21:
                            Guid idc = (Guid)fila.Cells[colIdDoc].Value;
                            var detallec = _cotizacionRepository.GetDetalleCotizacion(idc);
                            _cotizacionRepository.DeleteDetalleCotizacion(detallec);
                            break;
                        case 22:
                            Guid idv = (Guid)fila.Cells[colIdDoc].Value;
                            var detallev = _valesRepository.GetDetalleVale(idv);
                            _valesRepository.DeleteDetalleVale(detallev);
                            break;
                    }
                }
            }
            catch 
            {
                MessageBox.Show("¡No se ha podido eliminar el Producto! ");
            }
        }

        private void btntmp_Click(object sender, EventArgs e)
        {
            CargarFormsPago();
        }

        private void dgvListadoProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var fila = dgvListadoProductos.CurrentRow;
            int ind = fila.Index + 1;
            txtLinea.Text = ind.ToString();
            if (fila != null)
            {
                _ProductoId = Convert.ToInt32(fila.Cells[1].Value);
                var prod = _productosRepository.GetListaProducto(_ProductoId);
                MostrarDetalles(prod);
            }
        }

        public void IngresarToken(bool cobrar)
        {

            if (mostrarIngresoToken)
            { 
                  if (cbVendedor.SelectedValue != null)
                {
                    _usuarioVentas = _usersRepository.Get(cbVendedor.SelectedValue.ToString());
                    sucursalVendedor = _usuarioVentas.SucursalId;
                    if (Application.OpenForms["IngresoToken"] == null)
                    {

                        IngresoToken token = new IngresoToken(_usuarioVentas.token, this, cobrar);
                        token.Show();
                    }
                    else
                    {
                        Application.OpenForms["IngresoToken"].Activate();
                    }
                }

            }
        }

        private void cbVendedor_SelectedValueChanged(object sender, EventArgs e)
        {            
            //if (!validacionToken)
            //{
                IngresarToken(false);
            //}
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            CargarDatos();
            LimpiarGridListado();
            //validacionToken = false;
            mostrarIngresoToken = true;
            pgDetalle.Visible = false;
            _listaDetalle.Clear();
            CargarAllDGV();
            _cuentaPorCobrar = null;
            lbCuentaxCobrar.Visible = false;
            lbCuentaxCobrar.Text = "";
        }

        public void Actualizar()
        {
            mostrarIngresoToken = false;
            PuntoDeVenta_Load(null, null);
            LimpiarGridListado();
            _cliente = new Cliente();
            pgDetalle.Visible = false;
            pnlColor.Enabled = false;
            pnlTalla.Enabled = false;
            pnlTomo.Enabled = false;
            pnlEdicion.Enabled = false;
            _listaDetalle.Clear();
            CargarAllDGV();
            _cuentaPorCobrar = null;
            lbCuentaxCobrar.Text = "CC-0000000";
        }

        private void cbTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvListadoProductos.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgvListadoProductos.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        int productoId = Convert.ToInt32(row.Cells[1].Value);
                        PrecioEscala(productoId, row, 3);
                        if (row.Cells[colRebajaD].Value != null && row.Cells[colPrecioD].Value != null)
                        {
                            decimal RebajaD = Convert.ToDecimal(row.Cells[colRebajaD].Value);
                            if (RebajaD > 0.00m)
                            {
                                decimal subtotal = RebajaD * Convert.ToInt32(row.Cells[colCantidad].Value);
                                row.Cells[colPrecioD].Value = subtotal;
                                row.Cells[colSubtotal].Value = subtotal;
                            }                            
                        }
                    }
                }
                Calculartotal();
                CalcularDescuentos();
            }
        }

        private void pbDocumento_Click(object sender, EventArgs e)
        {
            if (dgvListadoProductos.RowCount > 1)
            {
                if (_cliente != null)
                {
                    if (noDocumetno.Length == 0)
                    {
                        Cobrar(false);
                    }
                    if (cbTipoOperacion.SelectedValue != null)
                    {
                        int idTipoDocumento = Convert.ToInt32(cbTipoOperacion.SelectedValue);
                        if (Application.OpenForms["DocumentoPOS"] == null)
                        {
                            DocumentoPOS doc = new DocumentoPOS(txtNumeroPedido.Text, idTipoDocumento, checkImagen.Checked);
                            doc.Show();
                        }
                        else
                        {
                            Application.OpenForms["DocumentoPOS"].Activate();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("¡No ha ingresado un cliente válido!", "Notificación");   
                }                
            }
            else
            {
                MessageBox.Show("El Listado esta vacio, no se puede\ngenerar el documeno.", "Notificación");
            }

        }

        private void cbColores_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbColores.SelectedItem != null)
            {
                var detallecolor = (DetalleColor)cbColores.SelectedItem;
                if (detallecolor != null)
                    lbStockColor.Text = "Existencias: " + detallecolor.Stock.ToString();
            }
        }

        private void cbTalla_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbTalla.SelectedItem != null)
            {
                var detalletalla = (DetalleTalla)cbTalla.SelectedItem;
                if (detalletalla != null)
                    lbStockTalla.Text = "Existencias: " + detalletalla.Stock.ToString();
            }
        }

        private void cbTomos_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbTomos.SelectedItem != null)
            {
                var detalletomo = (DetalleTomoEdicion)cbTomos.SelectedItem;
                if (detalletomo != null)
                    lbStockTomo.Text = "Existencias: " + detalletomo.Stock.ToString();
            }
        }

        private void cbEdiciones_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbEdiciones.SelectedItem != null)
            {
                var detalleedicion = (DetalleTomoEdicion)cbEdiciones.SelectedItem;
                if (detalleedicion != null)
                    lbStockEdicion.Text = "Existencias: " + detalleedicion.Stock.ToString();
            }
        }

        private void btnAgregarColor_Click(object sender, EventArgs e)
        {
            if (!comprobarElemento(dgvColores, cbColores.Text))
            {
                if (txtCantidadColor.Text != "")
                {
                    int number;
                    if (Int32.TryParse(txtCantidadColor.Text, out number))
                    {
                        int cantidad = Convert.ToInt32(txtCantidadColor.Text);
                        var color = (DetalleColor)cbColores.SelectedItem;
                        if (cantidad <= color.Stock)
                        {
                            DetalleProducto detalle = new DetalleProducto
                            {
                                noDocumento = txtNumeroPedido.Text,
                                ProductoId = color.ProductoId,
                                DetalleId = color.Id,
                                TipoDetalle = "Color",
                                Detalle = color.Color,
                                Cantidad = cantidad,
                                FechaDocumento = DateTime.Now
                            };
                            btnAceptarColor.Enabled = true;
                            _listaDetalle.Add(detalle);
                            txtCantidadColor.Text = "";
                            CargarDGVDetalle(dgvColores, "Color");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El valor ingresado no es válido.", "Notificación");
                    }
                }
                else
                {
                    MessageBox.Show("El campo cantidad esta vacio.", "Notificación");
                }
            }
        }

        private void btnAgregarTalla_Click(object sender, EventArgs e)
        {
            if (!comprobarElemento(dgvTallas, cbTalla.Text))
            {
                if (txtCantidadTalla.Text != "")
                {
                    int number;
                    if (Int32.TryParse(txtCantidadTalla.Text, out number))
                    {
                        int cantidad = Convert.ToInt32(txtCantidadTalla.Text);
                        var talla = (DetalleTalla)cbTalla.SelectedItem;
                        if (cantidad <= talla.Stock)
                        {
                            DetalleProducto detalle = new DetalleProducto
                            {
                                noDocumento = txtNumeroPedido.Text,
                                ProductoId = talla.ProductoId,
                                DetalleId = talla.Id,
                                TipoDetalle = "Talla",
                                Detalle = talla.Talla,
                                Cantidad = cantidad,
                                FechaDocumento = DateTime.Now
                            };
                            btnAceptarTalla.Enabled = true;
                            _listaDetalle.Add(detalle);
                            txtCantidadTalla.Text = "";
                            CargarDGVDetalle(dgvTallas, "Talla");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El valor ingresado no es válido.", "Notificación");
                    }
                }
                else
                {
                    MessageBox.Show("El campo cantidad esta vacio.", "Notificación");
                }
            }
        }

        private void btnAgregarTomo_Click(object sender, EventArgs e)
        {
            if (!comprobarElemento(dgvTomos, cbTomos.Text))
            {
                if (txtCantidatTomo.Text != "")
                {
                    int number;
                    if (Int32.TryParse(txtCantidatTomo.Text, out number))
                    {
                        int cantidad = Convert.ToInt32(txtCantidatTomo.Text);
                        var tomo = (DetalleTomoEdicion)cbTomos.SelectedItem;

                        if (cantidad <= tomo.Stock)
                        {
                            DetalleProducto detalle = new DetalleProducto
                            {
                                noDocumento = txtNumeroPedido.Text,
                                ProductoId = _ProductoId,
                                DetalleId = tomo.Id,
                                TipoDetalle = "Tomo",
                                Detalle = tomo.Tomo,
                                Cantidad = cantidad,
                                FechaDocumento = DateTime.Now

                            };
                            btnAceptarTomo.Enabled = true;
                            _listaDetalle.Add(detalle);
                            txtCantidatTomo.Text = "";
                            CargarDGVDetalle(dgvTomos, "Tomo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El valor ingresado no es válido.", "Notificación");
                    }
                }
                else
                {
                    MessageBox.Show("El campo cantidad esta vacio.", "Notificación");
                }
            }
        }

        private void btnAgregarEdicion_Click(object sender, EventArgs e)
        {
            if (!comprobarElemento(dgvEdiciones, cbEdiciones.Text))
            {
                if (txtCantidadEdicion.Text != "")
                {
                    int number;
                    if (Int32.TryParse(txtCantidadEdicion.Text, out number))
                    {
                        int cantidad = Convert.ToInt32(txtCantidadEdicion.Text);
                        var edicion = (DetalleTomoEdicion)cbEdiciones.SelectedItem;
                        if (cantidad <= edicion.Stock)
                        {
                            DetalleProducto detalle = new DetalleProducto
                            {
                                noDocumento = txtNumeroPedido.Text,
                                ProductoId = _ProductoId,
                                DetalleId = edicion.Id,
                                TipoDetalle = "Edicion",
                                Detalle = edicion.Edicion,
                                Cantidad = cantidad,
                                FechaDocumento = DateTime.Now
                            };
                            btnAceptarEdiciones.Enabled = true;
                            _listaDetalle.Add(detalle);
                            txtCantidadEdicion.Text = "";
                            CargarDGVDetalle(dgvEdiciones, "Edicion");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El valor ingresado no es válido.", "Notificación");
                    }
                }
                else
                {
                    MessageBox.Show("El campo cantidad esta vacio.", "Notificación");
                }
            }
        }

        private void CargarDGVDetalle(DataGridView datag, string detalle)
        {
            if (_listaDetalle.Count() > 0)
            {

                List<DetalleProducto> listadotmp = _listaDetalle.Where(x => x.ProductoId == _ProductoId).ToList();
                if (listadotmp.Count() > 0)
                {
                    listadotmp = listadotmp.Where(x => x.TipoDetalle == detalle).ToList();
                    datag.DataSource = typeof(List<>);
                    datag.DataSource = listadotmp;

                    int Total = listadotmp.Sum(x => x.Cantidad);

                    if (detalle == "Color")
                    {
                        lbTotalColores.Text = "Total: " + Total;
                    }
                    else if (detalle == "Talla")
                    {
                        lbTotalTallas.Text = "Total: " + Total;
                    }
                    else if (detalle == "Tomo")
                    {
                        lbTotalTomos.Text = "Total: " + Total;
                    }
                    else if (detalle == "")
                    {
                        lbTotalEdiciones.Text = "Total: " + Total;
                    }

                    if (Total > 0)
                    {
                        AsignarCantidad(Total);
                    }
                }
                else
                {
                    datag.DataSource = new List<DetalleProducto>();
                }
            }
            else
            {
                datag.DataSource = new List<DetalleProducto>();
            }
            datag.Columns[0].Visible = false;
            datag.Columns[3].Visible = false;
            datag.Columns[4].Visible = false;
            datag.Columns[7].Visible = false;
            datag.Columns[1].HeaderText = "Pedido";
            datag.Columns[2].HeaderText = "Codigo";
            datag.ClearSelection();
        }

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
                            item.noDocumento = txtNumeroPedido.Text;
                        }
                        item.FechaDocumento = DateTime.Now;
                        _detalleProductoRepository.Update(item);
                    }
                }
                _listaDetalle.Clear();
                _listaDetalle = new List<DetalleProducto>();
                CargarAllDGV();
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

        private void AsignarCantidad(int Total)
        {
            if (dgvListadoProductos.CurrentRow != null)
            {
                var fila = dgvListadoProductos.CurrentRow;
                int productoId = Convert.ToInt32(fila.Cells[1].Value);
                decimal Precio = PrecioProducto(productoId, Total);
                fila.Cells[colCantidad].Value = Total;
                if (Precio > 0.00m)
                {
                    fila.Cells[colPrecio].Value = Precio;
                }

                if (fila.Cells[colRebajaD].Value != null)
                {
                    decimal rebaja = Convert.ToDecimal(fila.Cells[colRebajaD].Value);
                    if (rebaja > 0.00m)
                    {
                        fila.Cells[colPrecioD].Value = Convert.ToDecimal(fila.Cells[colRebajaD].Value) * Total;
                        fila.Cells[colSubtotal].Value = Convert.ToDecimal(fila.Cells[colRebajaD].Value) * Total;
                    }
                    else
                    {
                        fila.Cells[colSubtotal].Value = Convert.ToDecimal(fila.Cells[colPrecio].Value) * Total;
                    }
                }
                else
                {
                    fila.Cells[colSubtotal].Value = Convert.ToDecimal(fila.Cells[colPrecio].Value) * Total;
                }
            }
        }

        private bool comprobarElemento(DataGridView datag, string detalle)
        {
            foreach (DataGridViewRow row in datag.Rows)
            {
                if (row.Cells[5].Value.ToString() == detalle)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnEliminarColor_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvColores.CurrentRow != null)
                {
                    var fila = dgvColores.CurrentRow;
                    var detalle = (DetalleProducto)fila.DataBoundItem;
                    _listaDetalle.Remove(detalle);
                    if (detalle.Id > 0)
                        _detalleProductoRepository.DeleteDetalleProducto(detalle);
                    CargarDGVDetalle(dgvColores, "Color");
                }
                else
                {
                    MessageBox.Show("No se ha elegido una fila", "Notificación");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void btnEliminarTalla_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTallas.CurrentRow != null)
                {
                    var fila = dgvTallas.CurrentRow;
                    var detalle = (DetalleProducto)fila.DataBoundItem;
                    _listaDetalle.Remove(detalle);
                    if (detalle.Id > 0)
                        _detalleProductoRepository.DeleteDetalleProducto(detalle);
                    CargarDGVDetalle(dgvTallas, "Talla");
                }
                else
                {
                    MessageBox.Show("No se ha elegido una fila", "Notificación");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void btnEliminarTomo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTomos.CurrentRow != null)
                {
                    var fila = dgvTomos.CurrentRow;
                    var detalle = (DetalleProducto)fila.DataBoundItem;
                    _listaDetalle.Remove(detalle);
                    if (detalle.Id > 0)
                        _detalleProductoRepository.DeleteDetalleProducto(detalle);
                    CargarDGVDetalle(dgvTomos, "Tomo");
                }
                else
                {
                    MessageBox.Show("No se ha elegido una fila", "Notificación");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void btnEliminarEdicion_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEdiciones.CurrentRow != null)
                {
                    var fila = dgvEdiciones.CurrentRow;
                    var detalle = (DetalleProducto)fila.DataBoundItem;
                    _listaDetalle.Remove(detalle);
                    if (detalle.Id > 0)
                        _detalleProductoRepository.DeleteDetalleProducto(detalle);
                    CargarDGVDetalle(dgvEdiciones, "Edicion");
                }
                else
                {
                    MessageBox.Show("No se ha elegido una fila", "Notificación");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void pbActualizar_Click(object sender, EventArgs e)
        {
            _listadoConsulta = _productosRepository.GetListAll();
            CargaGridProductosConsulta(_listadoConsulta.ToList(), !vista);
            CargarCombosConsulta();
        }

        private void btnAceptarColor_Click(object sender, EventArgs e)
        {
            mostrarMsgDetalle = false;
            CargarAllDGV();
            pgDetalle.Visible = false;
            knPOS.SelectedPage = pgPuntoDeVenta;
        }

        private void btnAceptarTalla_Click(object sender, EventArgs e)
        {
            mostrarMsgDetalle = false;
            CargarAllDGV();
            pgDetalle.Visible = false;
            knPOS.SelectedPage = pgPuntoDeVenta;
        }

        private void btnAceptarTomo_Click(object sender, EventArgs e)
        {
            mostrarMsgDetalle = false;
            CargarAllDGV();
            pgDetalle.Visible = false;
            knPOS.SelectedPage = pgPuntoDeVenta;
        }

        private void btnAceptarEdiciones_Click(object sender, EventArgs e)
        {
            mostrarMsgDetalle = false;
            CargarAllDGV();
            pgDetalle.Visible = false;
            knPOS.SelectedPage = pgPuntoDeVenta;
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            decimal total = 0.00m;
            decimal totaldescuento = Convert.ToDecimal(txtDescuento.Text);
            foreach (DataGridViewRow row in dgvListadoProductos.Rows)
            {
                if (row.Cells[colCodAlterno].Value != null)
                {
                    int Cantidad = Convert.ToInt32(row.Cells[colCantidad].Value);
                    decimal Precio = Convert.ToDecimal(row.Cells[colPrecio].Value);
                    total += (Precio * Cantidad);
                }

            }
            if (total > 0)
            {
                lbPorcentajeD.Text = decimal.Round((totaldescuento * 100 / total), 2) + "%";
            }
            
        }

        private void knPOS_SelectedPageChanged(object sender, EventArgs e)
        {
            try
            {
                if (mostrarMsgDetalle)
                {
                    if (knPOS.SelectedPage == pgPuntoDeVenta)
                    {
                        DialogResult dialogResult = MessageBox.Show("No se ha seleccionado un detalle ¿Desea eliminar el producto \n" + NombreProducto() + " del listado?", "Confirmación", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            int indice = 0;
                            foreach (DataGridViewRow row in dgvListadoProductos.Rows)
                            {
                                if (row.Cells[colCodAlterno].Value != null)
                                {
                                    int id = Convert.ToInt32(row.Cells[colCodAlterno].Value);
                                    if (id == _ProductoId)
                                    {
                                        indice = row.Index;
                                    }
                                }
                            }
                            dgvListadoProductos.Rows.RemoveAt(indice);
                            CargarAllDGV();
                            pgDetalle.Visible = false;
                            lbProdTalla.Text = "";
                            lbProdColor.Text = "";
                            lbProdTomo.Text = "";
                            lbProdEdicion.Text = "";
                        }
                        else
                        {
                            if (pgDetalle.Visible)
                            {
                                knPOS.SelectedPage = pgDetalle;
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un problema interno", "Notificacón");
            }
            
        }

        private string NombreProducto()
        {
            string nombreProducto = "";

            if (lbProdColor.Text.Length > 0)
            {
                nombreProducto = lbProdColor.Text;
            }
            if (lbProdTalla.Text.Length > 0)
            {
                nombreProducto = lbProdTalla.Text;
            }
            if (lbProdTomo.Text.Length > 0)
            {
                nombreProducto = lbProdTomo.Text;
            }
            if (lbProdEdicion.Text.Length > 0)
            {
                nombreProducto = lbProdEdicion.Text;
            }
            return nombreProducto;
        }

        private void pbAgregarCliente_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["NuevoCliente"] == null)
            {
                NuevoCliente cliente = new NuevoCliente();
                cliente.Show();
            }
            else
            {
                Application.OpenForms["NuevoCliente"].Activate();
            }
        }

        private void btnCuentaPorCobrar_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["CuentaPorCobrar"] == null)
            {
                CuentaPorCobrar cxc = new CuentaPorCobrar(this);
                cxc.Show();
            }
            else
            {
                Application.OpenForms["CuentaPorCobrar"].Activate();
            }
        }

        public void AsignarCuentaxCobrar(CuentaCB cuenta)
        {
            _cuentaPorCobrar = null;
            _cuentaPorCobrar = cuenta;
            lbCuentaxCobrar.Visible = true;
            lbCuentaxCobrar.Text = _cuentaPorCobrar.NoCuenta;
        }

        public bool ValidarCuentaxCobrar()
        {
            if ((int)cbTipoOperacion.SelectedValue == 17)
            {
                if (_cuentaPorCobrar == null)
                {
                    MessageBox.Show("No se ha seleccionado una cuenta por cobrar.", "Advertencia");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
            
        }

        private void MostrarCamposCuentas(bool mostrar)
        {
            btnCuentaPorCobrar.Visible = mostrar;
            lbCuentaxCobrar.Visible = mostrar;
            pbAgregarCliente.Visible = mostrar;
        }

        private void ProductosCredito(int value) 
        {
            if (value == 17)
            {
                var solicitud = _solicitudesRepository.GetSolicitudByNo(txtNumeroPedido.Text);
                if(solicitud != null)
                {
                    var detalles = _solicitudesRepository.GetDetallebySolicitud(solicitud.Id);
                    if (detalles.Count() > 0)
                    {
                        foreach (SolicitudDetalle item in detalles)
                        {
                            ValidarExistencias(item, solicitud.NoSolicitud, true);
                        }
                    }
                }
            }
        }

        public bool ValidarExistencias(SolicitudDetalle solicitudDetalle, string noDocumento, bool save = false)
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
                                        case "Tomo":
                                            var tomo = _tomoEdicionRepository.GetDetalleTE(detalle.DetalleId);
                                            if (tomo != null)
                                                actualizarStock(detalle.Cantidad, tomo, producto, 3);
                                            break;
                                        case "Edicion":
                                            var edicion = _tomoEdicionRepository.GetDetalleTE(detalle.DetalleId);
                                            if (edicion != null)
                                                actualizarStock(detalle.Cantidad, edicion, producto, 3);
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
                        var _detalleTC = (DetalleTomoEdicion)detalle;
                        _detalleTC.Stock -= Cantidad;
                        _tomoEdicionRepository.Update(_detalleTC);
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

        private void cbVendedor_TextChanged(object sender, EventArgs e)
        {
            validacionToken = false;
        }

        private void cbColores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

