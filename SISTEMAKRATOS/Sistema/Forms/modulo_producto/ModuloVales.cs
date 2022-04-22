using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Cotizacion;
using CapaDatos.Models.Vales;
using CapaDatos.Repository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_producto
{
    public partial class ModuloVales : BaseContext, detalleproductovale

    {


        private bool MostrarMenu = true;
        private ProductosRepository _productosRepository = null;
        private List<Cliente> _listaclientes = null;
        private ClientesRepository _clientesRepository = null;
        private IList<ListarClientes> listaClientestodos => _clientesRepository.GetList(filtroid);
        public int filtroid = 0;
        private ValesRepository _valesRepository = null;
        private Guid idvale = Guid.NewGuid();
        private List<Cliente> clienteslist = new List<Cliente>();
        private Cliente _clienteActual = null;
        private List<int> Novaleslist = new List<int>();
        private List<ListarDetalleVales> _listaDetalleToVale;
        private ListarVales _vale=null;
        private List<Producto> ListaFilasenDGV = null;
        private List<Producto> ListaFilaRebajas = null;
        private readonly int colAccionesProd = 0;
        private readonly int colAccionesCombo = 0;
        private List<ListarProductos> _listadoproductos;
        private List<ListarCombos> _listarCombos;
        private CombosRepository _combosRepository = null;

        private TallasRepository _tallasRepository = null;
        private ColoresRepository _coloresRepository = null;
        private TallasyColoresRepository _tallasyColoresRepository = null;
        private IList<ListarVales> listaVales = null;
        private bool valenu = true;



        public ModuloVales()
        {
            
            _productosRepository = new ProductosRepository(_context);
            _clientesRepository = new ClientesRepository(_context);
            _valesRepository = new ValesRepository(_context);
            _listaDetalleToVale = new List<ListarDetalleVales>();
            _listaclientes = new List<Cliente>();
            _combosRepository = new CombosRepository(_context);

            _tallasRepository = new TallasRepository(_context);
            _coloresRepository = new ColoresRepository(_context);
            _tallasyColoresRepository = new TallasyColoresRepository(_context);
            
            InitializeComponent();
            ObtenerNumero();
          

        }
       


        private void BtnVolver_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["MenuProductos"] == null)
            {
                MenuProductos menuProductos = new MenuProductos();
                menuProductos.Show();
            }
            else
            {
                Application.OpenForms["MenuProductos"].Activate();
            }
            MostrarMenu = false;
            Close();
        }


        private void ModuloVales_Load(object sender, EventArgs e)
        {
            lbfecha.Text = DateTime.Now.ToString();
            CargarTipos();

            ObtenerNumero();
            ListaFilasenDGV = new List<Producto>();
            ListaFilaRebajas = new List<Producto>();
            _vale=new ListarVales();
            TraerAsignacion();
          
            CargarProductos();
            CargarCombos();
            cargarDGV();

          
        }
      
     
        public void cargarDGV()
        {
            listaVales = _valesRepository.GetListaVales(UsuarioLogeadoSistemas.User.SucursalId);
            BindingSource source = new BindingSource();
            source.DataSource = listaVales;
            DgvListVales.DataSource = typeof(List<>);
            DgvListVales.DataSource = source;
            DgvListVales.AutoResizeColumns();


        }
        private void ActualizarMonto()
        {
            decimal actualizarTotal = 0.00M;
            decimal montodisponible = decimal.Parse(txtMontoC.Text);

            foreach (DataGridViewRow fila in DgvVale.Rows)
            {
                if (fila.Cells[7].Value != null)
                    actualizarTotal += (decimal)fila.Cells[7].Value;
            }

            if (actualizarTotal > montodisponible) { KryptonMessageBox.Show("No cuenta con suficiente monto disponible"); return; }
            decimal subtotal = montodisponible - actualizarTotal;
            txtreciduo.Text = subtotal.ToString("0.00");
            lbtotal1.Text = actualizarTotal.ToString();

        }
        private void CargarCombos()
        {

            BindingSource source = new BindingSource();
            _listarCombos = _combosRepository.GetListarCombos(UsuarioLogeadoSistemas.User.SucursalId).ToList();
            source.DataSource = _listarCombos;
            DgvCombos.DataSource = typeof(List<>);
            DgvCombos.DataSource = source;
            DgvCombos.ClearSelection();


        }

        private void CargarProductos()
        {
            BindingSource source = new BindingSource();
            
            _listadoproductos = _productosRepository.GetList(UsuarioLogeadoSistemas.User.SucursalId).ToList();
            source.DataSource = _listadoproductos;
            DgvProductos.DataSource = typeof(List<>);
            DgvProductos.DataSource = source;
            DgvProductos.ClearSelection();
        }
        private void TraerAsignacion()
        {
            var Asignacionlist = _valesRepository.GetAsignacionVale(_vale.Id);
            if (Asignacionlist == null) { return; }


            foreach (var item in Asignacionlist)
            {
                if (item.ClienteId != null)
                {
                    var clienteobtenido = _clientesRepository.Get((int)item.ClienteId);
                    clienteslist.Add(clienteobtenido);
                }
                //if (item.NoVale != 0)
                //{
                //    Novaleslist.Add(item.NoVale);
                //}

            }

            cargarClientesVales(clienteslist, Novaleslist);
        }

        private void cargarClientesVales(List<Cliente> listaclientes, List<int> numbervale)
        {
            if (listaclientes.Count > 0)
            {
                comboClientes.DataSource = listaclientes;
                comboClientes.ValueMember = "Id";
                comboClientes.DisplayMember = "Nombres";
            }
            //if (numbervale.Count > 0)
            //{
            //    comboClientes.DataSource = numbervale;
            //}
        }


        public void RefrescarDataGridClientes(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _clientesRepository = null;
                _clientesRepository = new ClientesRepository(_context);
            }

            BindingSource source = new BindingSource();
            // var clientes = _clientesRepository.GetList(filtroid);
            source.DataSource = listaClientestodos;
            DgvAunPersonal.DataSource = typeof(List<>);
            DgvAunPersonal.DataSource = source;
            DgvAunPersonal.AutoResizeColumns();
            for (int i = 0; i < 17; i++)
            {
                DgvAunPersonal.Columns[i].Visible = false;
            }
            DgvAunPersonal.Columns[1].Visible = true;
            DgvAunPersonal.Columns[2].Visible = true;
            DgvAunPersonal.Columns[3].Visible = true;
            DgvAunPersonal.Columns[4].Visible = true;
            DgvAunPersonal.Columns[5].Visible=true;
            DgvAunPersonal.Columns[15].Visible = true;

        }

        public void cargarDetalles(List<ListarDetalle> listado)
        {
            foreach (var item in listado)
            {
                ListarDetalleVales detallepedido = new ListarDetalleVales
                {
                    ProductoId = item.ProductoId,
                    Cantidad = 1,
                    Color = item.Detalle,
                    Talla = item.Detalle,


                };

                var exist = _listaDetalleToVale.Find(x => x.ProductoId == detallepedido.ProductoId);
                if (exist == null)
                    _listaDetalleToVale.Add(detallepedido);
                detallepedido.Total = detallepedido.Precio * detallepedido.Cantidad;
            }
            CargarDGVPedidos(_listaDetalleToVale);
        }

        private void CargarTipos()
        {
            var tipos = _clientesRepository.GetTipos();

            combotipos.DataSource = tipos;
            combotipos.DisplayMember = "TipoCliente";
            combotipos.ValueMember = "Id";
            combotipos.SelectedIndex = 0;
            combotipos.Invalidate();
        }

        private void ObtenerNumero()
        {

            int numeroA1 = new Random().Next(10, 70);
            string codigoBarras = "00" + numeroA1;
            lbcorrelVale.Text = codigoBarras;
        }
        private void ModuloVales_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MostrarMenu)
                MenuPrincipal(this, false);
        }

        private void DgvAunPersonal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var fila = DgvAunPersonal.CurrentCell;
            if (fila.ColumnIndex == 15)
            {
                var row = DgvAunPersonal.CurrentRow;
                if (row.Cells[15].Value != null)
                {
                    bool seleccion = Convert.ToBoolean(row.Cells[15].Value);
                    if (seleccion)
                    {
                        row.Cells[15].Value = false;
                    }
                    else
                    {
                        row.Cells[15].Value = true;
                    }
                }
            }
        }

        private void checkClientes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkClientes.Checked == true)
            {
                RefrescarDataGridClientes();
            }
            else
            {
                DgvAunPersonal.DataSource = null;
            }
        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtMonto.Text) || txtMonto.Text != "0")
            {
                var monto = decimal.Parse(txtMonto.Text);
                if (!string.IsNullOrEmpty(txtcantidad.Text))
                {
                    try
                    {
                        var cantidad = int.Parse(txtcantidad.Text);
                        txtmontoindividual.Text = (monto / cantidad).ToString();
                    }
                    catch (DivideByZeroException)
                    {
                        KryptonMessageBox.Show("No es posible dividir (0)");
                    }

                }
                else { return; }
            }
            else { return; }
        }
        private bool SeleccionAcciones(List<Cliente> clienteslista)
        {
            if (DgvAunPersonal.RowCount <= 0) { return false; }
            foreach (DataGridViewRow Rows in DgvAunPersonal.Rows)
            {
                bool acciones = Convert.ToBoolean(Rows.Cells[15].Value);
                if (acciones)
                {
                    var Id = int.Parse(Rows.Cells[0].Value.ToString());
                    var clienteobtenido = _clientesRepository.Get(Id);
                    clienteslista.Add(clienteobtenido);
                }
            }

            if (clienteslista.Count() > 0)
            {
                return true;
            }
            else
            {
                KryptonMessageBox.Show("Debera tener seleccionada  la columna 'Acciones'\n "
                    + "Selecione un Cliente, dando click en la columna Acciones\n"
                    );

                return false;
            }
        }
        public Vale GetNewVale()
        {
            return new Vale()
            {
                Id = idvale,
                NoVale = lbcorrelVale.Text.Trim(),
                SucursalId = UsuarioLogeadoSistemas.User.SucursalId,
                FechaRecepcion = DateTime.Now,
                Monto = decimal.Parse(txtMonto.Text),
                Descripcion = txtdescrip.Text,
                UserId = UsuarioLogeadoSistemas.User.Id,
                TiposId = int.Parse(combotipos.SelectedValue.ToString()),
            };
        }
        private AsignacionVale GetAsignacionNuevo()
        {
            return new AsignacionVale()
            {

                Id = Guid.NewGuid(),
                ValeId = idvale,
                Estado = "Asignado",
                FechaAsignacion = DateTime.Now,
                FechaCambio = DateTime.Now,
                NoVale = Convert.ToInt32(lbcorrelVale.Text),
                Monto = txtMonto.Text != "" ? decimal.Parse(txtMonto.Text) : 0.00m,
                Reciduo = txtreciduo.Text != "" ? decimal.Parse(txtreciduo.Text) : 0.00m,
              
            };
        }
        private void GuardarAsignacionValeListaClientes()
        {
            var totalitems = _listaclientes.Count;
            foreach (var cliente in _listaclientes)
            {
                var asignacion = GetAsignacionNuevo();
                if (!ModelState.IsValid(asignacion)) { return; }
                asignacion.ClienteId = cliente.Id;
                var operacion = (decimal.Parse(txtMonto.Text) / totalitems).ToString("0.00");
                asignacion.Monto = decimal.Parse(operacion);
                asignacion.Reciduo = decimal.Parse(operacion);
                asignacion.Nombre = cliente.Nombres;
                asignacion.Apellido = cliente.Apellidos;
                asignacion.Nit = cliente.Nit;
                asignacion.Telefono = cliente.Telefonos;
                _valesRepository.AddAsignacionVale(asignacion);

            }
        }
        private void GuardarvaleIndividual()
        {
            var totalitems = int.Parse(txtcantidad.Text);
            for (int i = 1; i <= totalitems; i++)
            {
                var asignacion = GetAsignacionNuevo();
                if (!ModelState.IsValid(asignacion)) { return; }
                asignacion.NoVale = i;
                asignacion.Monto = decimal.Parse(txtmontoindividual.Text);
                asignacion.Reciduo = decimal.Parse(txtmontoindividual.Text);
                _valesRepository.AddAsignacionVale(asignacion);
            }

        }
        private void GuardarValesNuevo()
        {

            if (string.IsNullOrEmpty(txtdescrip.Text)) { KryptonMessageBox.Show("debe ingresar una descripción para el vale"); return; }
            if (string.IsNullOrEmpty(txtcantidad.Text) || txtcantidad.Text == "0") { KryptonMessageBox.Show("campo cantidad inválido "); return; }
            if (string.IsNullOrEmpty(txtMonto.Text) || txtMonto.Text == "0.00") { KryptonMessageBox.Show("campo monto inválido "); return; }

            var encabezadoVale = GetNewVale();
            ///var detalleVales = GetDatosDetalleVales();
           //var detalleRebaja = GetDatosDetalleRebajas();
            if (!ModelState.IsValid(encabezadoVale)) { return; }

            _valesRepository.Add(encabezadoVale);

            if (checkClientes.Checked == true)
            {
                if (_listaclientes.Count == 0) { return; }
                GuardarAsignacionValeListaClientes();
            }
            else
            {
                if (!string.IsNullOrEmpty(txtcantidad.Text) || txtcantidad.Text != "0")
                {
                    _listaclientes.Clear();
                    GuardarvaleIndividual();
                }


            }


            KryptonMessageBox.Show("Registro Guardado correctamente! ");
            // limpiardatos();


        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (SeleccionAcciones(_listaclientes))
            {
                GuardarValesNuevo();
            }
        }
        private void cargarAsignacionTextbox(int id)
        {
            if (clienteslist.Count > 0)
            {
                var valeobtenido = _valesRepository.GetAsinacionPorCliente(id, _vale.Id);
                if (valeobtenido == null) { return; }
                lbnoVale.Text = valeobtenido.NoVale.ToString();
                fechainicio.Text = valeobtenido.FechaAsignacion.ToString();
                txtfechacambio.Text = valeobtenido.FechaCambio.ToString();
                txtestado.Text = valeobtenido.Estado;
                txtMontoC.Text = valeobtenido.Monto.ToString();
                txtreciduo.Text = valeobtenido.Reciduo.ToString();
            }
            else if (Novaleslist.Count > 0)
            {

                var valeobtenido = _valesRepository.GetAsinacionPorNumero(id, _vale.Id);
                if (valeobtenido == null) { return; }
                lbnoVale.Text = valeobtenido.NoVale.ToString();
                fechainicio.Text = valeobtenido.FechaAsignacion.ToString();
                txtfechacambio.Text = valeobtenido.FechaCambio.ToString();
                txtestado.Text = valeobtenido.Estado;
                txtMontoC.Text = valeobtenido.Monto.ToString();
                txtreciduo.Text = valeobtenido.Reciduo.ToString();

            }
        }
        private void cargarTxtCliente()
        {
            if (comboClientes.SelectedValue is Cliente) return;
            var clienteSeleccionado = int.Parse(comboClientes.SelectedValue.ToString());
            var clienteOptenido = _clientesRepository.Get(clienteSeleccionado);
            if (clienteOptenido == null) return;
            _clienteActual = clienteOptenido;
            cargarAsignacionTextbox(clienteOptenido.Id);

        }
        private void cargarTxtenBlanco()
        {

            if (comboClientes.SelectedValue is Cliente) return;
            var clienteSeleccionado = int.Parse(comboClientes.SelectedValue.ToString());
            var clienteOptenido = _clientesRepository.Get(clienteSeleccionado);
            if (clienteOptenido == null) return;
            _clienteActual = clienteOptenido;
            cargarAsignacionTextbox(clienteOptenido.Id);
        }
        private void comboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clienteslist.Count > 0)
            {
                cargarTxtCliente();
            }
            if (Novaleslist.Count > 0)
            {
                cargarTxtenBlanco();
            }


            ListaFilasenDGV.Clear();
            ListaFilaRebajas.Clear();
            _listaDetalleToVale.Clear();

        }
        private int ObtenerTipoDetalle(Producto producto)
        {
            int DetalleProd;
            if (producto != null)
            {
                if (producto.TieneColor && !producto.TieneTalla)
                    DetalleProd = 1;
                else if (!producto.TieneColor && producto.TieneTalla)
                    DetalleProd = 2;
                else if (producto.TieneColor && producto.TieneColor)
                    DetalleProd = 3;
                else
                    DetalleProd = 0;
            }
            else
            {
                DetalleProd = 0;
            }

            return DetalleProd;
        }
        private int ObtenerTipoDetalle(ListarProductos producto)
        {
            int DetalleProd;
            if (producto != null)
            {
                if (producto.IncluyeColor == "Si" && producto.Talla == "No")
                    DetalleProd = 1;
                else if (producto.IncluyeColor == "No" && producto.Talla == "Si")
                    DetalleProd = 2;
                else if (producto.IncluyeColor == "Si" && producto.Talla == "Si")
                    DetalleProd = 3;
                else
                    DetalleProd = 0;
            }
            else
            {
                DetalleProd = 0;
            }

            return DetalleProd;
        }
        public void LlenarTextBox()
        {
            if (Application.OpenForms["DetalleProductoForm"] != null)
            {
                Application.OpenForms["DetalleProductoForm"].Close();
            }

            if (DgvProductos.CurrentRow != null)
            {
                var fila = DgvProductos.CurrentRow;
                ListarProductos prod = (ListarProductos)fila.DataBoundItem;
                Producto producto = _productosRepository.Get(prod.Id);
                DetalleProductoVale( producto);
            }
        }
        private void DgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (DgvProductos.CurrentCell.ColumnIndex == colAccionesProd)
            {
                var fila = DgvProductos.CurrentRow;
                ListarProductos listarProductos = (ListarProductos)fila.DataBoundItem;
                int tienedetalle = ObtenerTipoDetalle(listarProductos);
                if (listarProductos.Acciones)
                {
                    DgvProductos.CurrentRow.Cells[colAccionesProd].Value = false;
                    
                }
                else
                {
                    DgvProductos.CurrentRow.Cells[colAccionesProd].Value = true;
                    if (tienedetalle > 0)
                        LlenarTextBox();
                    //  cantidadProdDet--;
                    else
                        // cantidadProd--;
                        KryptonMessageBox.Show("No hay Detalles ", "Advertencia");
                }


            }
        }

        private void DgvCombos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
            if (DgvCombos.CurrentCell.ColumnIndex == colAccionesCombo)
            {
                var fila = DgvCombos.CurrentRow;
                ListarCombos listarCombo = (ListarCombos)fila.DataBoundItem;
                if (listarCombo.Acciones)
                {
                    DgvCombos.CurrentRow.Cells[colAccionesCombo].Value = false;
                }
                else
                {
                    DgvCombos.CurrentRow.Cells[colAccionesCombo].Value = true;
                }


            }
        }

        private void BtnPreciosProd_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ModuloPrecios"] != null)
            {
                Application.OpenForms["ModuloPrecios"].Close();
            }

            if (DgvProductos.CurrentRow != null)
            {
                var fila = DgvProductos.CurrentRow;
                ListarProductos prod = (ListarProductos)fila.DataBoundItem;
                Producto producto = _productosRepository.Get(prod.Id);
                Precios(this, producto);
            }
        }
        private void AgregarListarDetallesPedidos(List<ListarProductos> listadoseleccion)
        {
            foreach (var item in listadoseleccion)
            {
                ListarDetalleVales detallepedido = new ListarDetalleVales
                {
                    ProductoId = item.Id,
                    Descripcion = item.Descripcion,
                    Cantidad = 1,
                    Talla = item.Talla,
                    Precio = item.PrecioVenta,
                    Color = item.IncluyeColor,
                   

                };
                var exist = _listaDetalleToVale.Find(x => x.ProductoId == detallepedido.ProductoId);
                if (exist == null)
                    _listaDetalleToVale.Add(detallepedido);
                detallepedido.Total = detallepedido.Precio * detallepedido.Cantidad;
            }
          
            CargarDGVPedidos(_listaDetalleToVale);
            ActualizarMonto();
         

        }
        public void CargarDGVPedidos(List<ListarDetalleVales> lista)
        {
            BindingSource recurso = new BindingSource();
            recurso.DataSource = lista;
            DgvVale.DataSource = typeof(List<>);
            DgvVale.DataSource = recurso;
            DgvVale.ClearSelection();
        }
        private List<ListarProductos> SeleccionAcciones()
        {
            List<ListarProductos> listadoseleccion = new List<ListarProductos>();
            foreach (DataGridViewRow Rows in DgvProductos.Rows)
            {
                ListarProductos product = (ListarProductos)Rows.DataBoundItem;
                if (product.Acciones)
                {
                    listadoseleccion.Add(product);
                }
            }
            return listadoseleccion;
        }
        private void BtnAgregarProd_Click(object sender, EventArgs e)
        {

            List<ListarProductos> seleccionados = SeleccionAcciones();
            if (seleccionados.Count > 0)
            {
                AgregarListarDetallesPedidos(seleccionados);

             

            }
            else
            {
                KryptonMessageBox.Show("No hay productos seleccionados", "Advertencia");
            }
            ActualizarMonto();
        }
        private void AgregarListarDetallesPedidosCombos(List<ListarCombos> listadoseleccion)
        {
            foreach (var item in listadoseleccion)
            {
                ListarDetalleVales detallepedidocombo = new ListarDetalleVales
                {

                    ComboId = item.IdCombo,
                    Cantidad = 1,
                    Descripcion = item.Descripcion,
                    Precio = item.Precioventa,

                };
                var exist = _listaDetalleToVale.Find(x => x.ComboId == detallepedidocombo.ComboId);
                if (exist == null)
                    _listaDetalleToVale.Add(detallepedidocombo);
               
            }
            CargarDGVPedidos(_listaDetalleToVale);

        }
        private List<ListarCombos> SeleccionCombos()
        {
            List<ListarCombos> listadoseleccion = new List<ListarCombos>();
            foreach (DataGridViewRow Rows in DgvCombos.Rows)
            {
                ListarCombos product = (ListarCombos)Rows.DataBoundItem;
                if (product.Acciones)
                {
                    listadoseleccion.Add(product);
                }
            }
            return listadoseleccion;
        }
        private void BtnAgregarCombo_Click(object sender, EventArgs e)
        {

            List<ListarCombos> seleccionados = SeleccionCombos();
            if (seleccionados.Count > 0)
            {
                AgregarListarDetallesPedidosCombos(seleccionados);
            }
            else
            {
                KryptonMessageBox.Show("No hay productos seleccionados", "Advertencia");
            }
        }
        public List<DetalleVale> GetDatosDetalleVales()
        {
            var List = new List<DetalleVale>();

            foreach (DataGridViewRow item in DgvVale.Rows)
            {
                if (item == null)
                {
                    continue;
                }

                DetalleVale detallevale = new DetalleVale
                {
                    Id = Guid.NewGuid(),
                    ProductoId = int.Parse(item.Cells[2].Value.ToString()),
                    Cantidad = int.Parse(item.Cells[6].Value.ToString()),
                    AsignacionValeId = Guid.NewGuid(),
                    ComboId = Guid.Parse(item.Cells[3].Value.ToString()),
                    precio = decimal.Parse(item.Cells[5].Value.ToString()),
                   
                };

                List.Add(detallevale);
            }

            return List;

        }
        private void GuardarVales()
        {
            if (txtestado.Text == "Cobrado") { KryptonMessageBox.Show("Vale ya cambiado anteriormente, Estado Cobrado"); return; }
            if (DgvVale.RowCount == 0) { KryptonMessageBox.Show("Debe tener un producto para Facturar"); return; }
            var detalleVales = GetDatosDetalleVales();
            if (!ModelState.IsValid(detalleVales)) { return; }
            foreach (var item in detalleVales)
            {
                if (item.ProductoId == 0)
                {
                    item.ProductoId = null;
                    var combob = _combosRepository.Get((Guid)item.ComboId);
                    if (combob.Stock <= 0) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }
                    if (combob.Stock < item.Cantidad) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }
                    combob.Stock -= item.Cantidad;
                    _combosRepository.Update(combob, true);
                }
                else
                {
                    item.ComboId = null;
                    var producto = _productosRepository.Get((int)item.ProductoId);
                    if (producto.Stock <= 0) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }
                    if (producto.Stock < item.Cantidad) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }

                    producto.Stock -= item.Cantidad;
                    _productosRepository.Update(producto, true);
                    if (item.DetalleColorId != 0)
                    {
                        var detalleObtenido = _coloresRepository.GetDetalleColor((int)item.DetalleColorId);
                        if (detalleObtenido.Stock < item.Cantidad) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }
                        detalleObtenido.Stock -= item.Cantidad;
                        _coloresRepository.Update(detalleObtenido);
                    }
                    if (item.DetalleTallaId != 0)
                    {
                        var detalleObtenidotalla = _tallasRepository.GetDetalleTalla((int)item.DetalleTallaId);
                        if (detalleObtenidotalla.Stock < item.Cantidad) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }
                        detalleObtenidotalla.Stock -= item.Cantidad;
                        _tallasRepository.Update(detalleObtenidotalla);
                    }
                    if (item.DetalleColorTallaId != 0)
                    {
                        var detallecolortallaobten = _tallasyColoresRepository.GetColorTalla((int)item.DetalleColorTallaId);
                        if (detallecolortallaobten.Stock < item.Cantidad) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }
                        detallecolortallaobten.Stock -= item.Cantidad;
                        _tallasyColoresRepository.Update(detallecolortallaobten);
                    }

                }

                if (item.DetalleColorId == 0)
                {
                    item.DetalleColorId = null;
                    //item.DetalleColorTallaId = null;
                }
                if (item.DetalleTallaId == 0)
                {
                    item.DetalleTallaId = null;
                }
                if (item.DetalleColorTallaId == 0)
                {
                    item.DetalleColorTallaId = null;
                }

                _valesRepository.AddDetalle(item);
            }
            UpdateAsignacion();
            KryptonMessageBox.Show("Registro Guardado correctamente! ");
           
            Close();

        }
        public AsignacionVale GetAsignacionUpdate(AsignacionVale asignacion)
        {

            asignacion.Reciduo = decimal.Parse(txtreciduo.Text);
            asignacion.FechaCambio = DateTime.Now;

            return asignacion;
        }
        private void UpdateAsignacion()
        {
            AsignacionVale valeoptenido = null;
            if (clienteslist.Count > 0)
            {
                valeoptenido = _valesRepository.GetAsinacionPorCliente(int.Parse(comboClientes.SelectedValue.ToString()), _vale.Id);
            }
            else if (Novaleslist.Count > 0)
            {
                valeoptenido = _valesRepository.GetAsinacionPorNumero(int.Parse(comboClientes.SelectedValue.ToString()), _vale.Id);
            }
            var AsignacionUpdate = GetAsignacionUpdate(valeoptenido);
            if (!ModelState.IsValid(AsignacionUpdate)) { return; }

            AsignacionUpdate.Estado = "Cobrado";
            _valesRepository.UpdateAsignacion(AsignacionUpdate);


        }

        private void BtnGuardarC_Click(object sender, EventArgs e)
        {
            var montoinicial = decimal.Parse(txtMontoC.Text);
            var totalmonto = decimal.Parse(lbtotal1.Text);
            if (totalmonto > montoinicial) { KryptonMessageBox.Show("Total es mayor al monto asignado en el vale"); return; }
            if (montoinicial >= totalmonto)
            {
                GuardarVales();
            }
        }
        private void cargarClientesVale(ListarVales promo)
        {
            TraerAsignacion();
        }
        private void BtnCobrar_Click(object sender, EventArgs e)
        {
            if (DgvListVales.CurrentRow != null)
            {
               var fila = DgvListVales.CurrentRow;
               _vale = (ListarVales)fila.DataBoundItem;
                cargarClientesVale(_vale);
               
               PageCobrar.Visible = true;
                NavVale.SelectedPage = PageCobrar;
                valenu = false;
            }
            else
            {
                KryptonMessageBox.Show("No ha seleccionado ninguna fila del listado.", "Notificación");
            }


        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void toolHeader_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void DgvVale_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void toolStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void prueba()
        { 
        }

        public void DetalleProductoVale(Producto prod = null)
        {
            if (Application.OpenForms["DetalleProductoForm"] == null)
            {
                DetalleProductoForm detalleprof = new DetalleProductoForm(this, prod);
                detalleprof.Show();
            }
            else
            {
                Application.OpenForms["DetalleProductoForm"].Activate();
            }
        }

        private void BtnVolver_Click_1(object sender, EventArgs e)
        {
            if (Application.OpenForms["MenuProductos"] == null)
            {
                MenuProductos combos = new MenuProductos();
                combos.Show();
            }
            else
            {
                Application.OpenForms["MenuProductos"].Activate();
            }
            MostrarMenu = false;
            Close();
        }
    }

    internal interface detalleproductovale
    {
        void CargarDGVPedidos(List<ListarDetalleVales> lista);
    }
} 

