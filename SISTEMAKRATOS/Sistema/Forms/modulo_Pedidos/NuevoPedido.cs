using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Pedidos;
using CapaDatos.Models.Productos;
using CapaDatos.Repository;
using CapaDatos.Repository.PreciosRepository;
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

namespace Sistema.Forms.modulo_Pedidos
{
    public partial class NuevoPedido : BaseContext
    {
        private ProductosRepository _productosRepository = null;
        private PedidoRepository _pedidoRepository = null;
        private ClientesRepository _clientesRepository = null;
        private CombosRepository _combosRepository = null;
        private TipoPrecioRepository _tipoPrecioRepository = null;
        private TallasRepository _tallasRepository = null;
        private ColoresRepository _coloresRepository = null;
        private TallasyColoresRepository _tallasyColoresRepository = null;

        private Cliente _clienteActual = null;
        //datagrid cotizacion 
        private int coddetalleIdcolCotiz = 0, cotizId = 1, productidColcotiz = 2, combocolcotiz = 3,
            colorcolcotiz = 4, tallacolcotiz = 5, descripColCotiz = 6,
            preciocolcotiz = 7, cantidadcolcotiz = 8, subtotalcolcotiz = 9;
        private int coloridColcotiz = 10, tallaidColcotiz = 11, tallaColorIdCotiz = 12;

        private int colAcciones = 14;
        int colAccionesProd = 28;
        int cuentaclacol = 10;
        int gubernacol = 9;
        int reventacol = 11;
        int minoristacol = 8;
        int mayoristacol = 7;

        //columnas del dgv talla y color
        int IDTyCcol = 0;
        int productIDTyCcol = 1;
        int colorTyCcol = 3;
        int tallaTyCcol = 3;
        int colAccionesTyC = 5;
        //col dgv cotizaciones 

        private IList<ListarProductos> listaProductos = null;
        private IList<ListarCombos> combos = null;
        private List<ListarDetallePedidos> _listaDetalleToPedido = null;

        private List<Producto> ListaFilasenDGV = null;
        private List<Cliente> clienteslist = new List<Cliente>();
        private List<int> Novaleslist = new List<int>();

        private Layout _panelLayout = null;


        public NuevoPedido(Layout layout)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            _tipoPrecioRepository = new TipoPrecioRepository(_context);
            _clientesRepository = new ClientesRepository(_context);
            _combosRepository = new CombosRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            _pedidoRepository = new PedidoRepository(_context);
            _tallasRepository = new TallasRepository(_context);
            _coloresRepository = new ColoresRepository(_context);
            listaProductos = new List<ListarProductos>();
            _listaDetalleToPedido = new List<ListarDetallePedidos>();
            _tallasyColoresRepository = new TallasyColoresRepository(_context);
            _panelLayout = layout;

        }

        private void NuevoPedido_Load(object sender, EventArgs e)
        {
            ListaFilasenDGV = new List<Producto>();
            CargarDgvCombos();
            cargarClientes();
            CargarTipos();
            RefrescarDataGridProductos();
            lbnoVale.Text = Guid.NewGuid().ToString();
        }
        public void RefrescarDataGridProductos(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _productosRepository = null;
                _productosRepository = new ProductosRepository(_context);
            }
            BindingSource source = new BindingSource();
            listaProductos = _productosRepository.GetList(UsuarioLogeadoSistemas.User.SucursalId);
            source.DataSource = listaProductos;
            dgvProductos.DataSource = typeof(List<>);
            dgvProductos.DataSource = source;

            for (int i = 0; i < 28; i++)
            {
                dgvProductos.Columns[i].Visible = false;
            }
            dgvProductos.Columns[1].Visible = true;
            dgvProductos.Columns[3].Visible = true;
            dgvProductos.Columns[28].Visible = true;

            //dgvProductos.AutoResizeColumns();
        }

        public void CargarDgvCombos(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _combosRepository = null;
                _combosRepository = new CombosRepository(_context);
            }

            BindingSource source = new BindingSource();
            combos = _combosRepository.GetListarCombos(UsuarioLogeadoSistemas.User.SucursalId);
            source.DataSource = combos;
            dgvCombos.DataSource = typeof(List<>);

            dgvCombos.DataSource = source;
            dgvCombos.AutoResizeColumns();
            for (int i = 0; i < 15; i++)
            {
                dgvCombos.Columns[i].Visible = false;
            }
            dgvCombos.Columns[2].Visible = true;
            dgvCombos.Columns[3].Visible = true;
            dgvCombos.Columns[4].Visible = true;
            dgvCombos.Columns[6].Visible = true;
            dgvCombos.Columns[colAcciones].Visible = true;

        }

        private void cargarClientes()
        {
            var listaclientes = _clientesRepository.GetClientes();
            comboClientes.DataSource = listaclientes;
            comboClientes.ValueMember = "Id";
            comboClientes.DisplayMember = "Nombres";
            comboClientes.SelectedIndex = 0;


        }
        private void CargarTipos()
        {
            var tipos = _clientesRepository.GetTipos();

            comboPreciostipos.DataSource = tipos;
            comboPreciostipos.DisplayMember = "TipoCliente";
            comboPreciostipos.ValueMember = "Id";
            comboPreciostipos.SelectedIndex = 0;
            comboPreciostipos.Invalidate();
        }
        private void comboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarTxtCliente();
        }

        private void cargarTxtCliente()
        {
            if (comboClientes.SelectedValue is Cliente) return;
            var clienteSeleccionado = int.Parse(comboClientes.SelectedValue.ToString());
            var clienteOptenido = _clientesRepository.Get(clienteSeleccionado);
            if (clienteOptenido == null) return;
            _clienteActual = clienteOptenido;
            txtcodigoclient.Text = clienteOptenido.CodigoCliente;
            txttelefono.Text = clienteOptenido.Telefonos;
            txtnit.Text = clienteOptenido.Nit;
            lbdirec.Text = clienteOptenido.Direccion;
            txtnombre.Text = clienteOptenido.Nombres;
            txtapellido.Text = clienteOptenido.Apellidos;


        }


        private ListarDetallePedidos GetlistaDetalle()
        {
            return new ListarDetallePedidos()
            {

            };
        }



        public Pedido GetNewPedido()
        {
            return new Pedido()
            {
                Id = Guid.Parse(lbnoVale.Text),
                SucursalId = UsuarioLogeadoSistemas.User.SucursalId,
                FechaRecepcion = dtpinicio.Value,
                FechaLimite = dtpfin.Value,
                NombreVendedor = UsuarioLogeadoSistemas.User.Name,
                Nombre = txtnombre.Text,
                Apellido = txtapellido.Text,
                Telefono = txttelefono.Text,
                Nit = txtnit.Text,
                ClienteId = int.Parse(comboClientes.SelectedValue.ToString())


            };
        }
        public List<DetallePedidos> GetDatosDetallePedido()
        {
            var List = new List<DetallePedidos>();

            foreach (DataGridViewRow item in dgvpedidos.Rows)
            {
                if (item == null)
                {
                    continue;
                }

                DetallePedidos detallePedido = new DetallePedidos
                {
                    Id = Guid.NewGuid(),
                    ProductoId = int.Parse(item.Cells[productidColcotiz].Value.ToString()),
                    Cantidad = int.Parse(item.Cells[cantidadcolcotiz].Value.ToString()),
                    Precio = decimal.Parse(item.Cells[preciocolcotiz].Value.ToString()),
                    PrecioTotal = decimal.Parse(item.Cells[subtotalcolcotiz].Value.ToString()),
                    PedidoId = Guid.Parse(lbnoVale.Text),
                    ComboId = Guid.Parse(item.Cells[combocolcotiz].Value.ToString()),
                    DetalleColorId = int.Parse(item.Cells[coloridColcotiz].Value.ToString()),
                    DetalleTallaId = int.Parse(item.Cells[tallaidColcotiz].Value.ToString()),
                    DetalleColorTallaId = int.Parse(item.Cells[tallaColorIdCotiz].Value.ToString()),

                };

                List.Add(detallePedido);
            }

            return List;

        }




        private void CheckedAll()
        {
            foreach (DataGridViewRow Rows in dgvProductos.Rows)
            {
                bool acciones = Convert.ToBoolean(Rows.Cells[27].Value);
                if (!acciones)
                {
                    Rows.Cells[28].Value = true;
                }
                else
                {
                    Rows.Cells[28].Value = false;
                }
            }

        }

        private void CheckedCombos()
        {
            foreach (DataGridViewRow Rows in dgvCombos.Rows)
            {
                bool acciones = Convert.ToBoolean(Rows.Cells[colAcciones].Value);
                if (!acciones)
                {
                    Rows.Cells[colAcciones].Value = true;
                }
                else
                {
                    Rows.Cells[colAcciones].Value = false;
                }
            }

        }
        private void AgregarlistaToDgv(DataGridView datagrid, List<ListarDetallePedidos> listaT, List<Producto> listaProducto)

        {

            foreach (var item in listaProducto)
            {

                var detallePedidoa = GetlistaDetalle();
                detallePedidoa.ProductoId = item.Id;
                detallePedidoa.Descripcion = item.Descripcion;
                detallePedidoa.PedidoId = Guid.Parse(lbnoVale.Text);
                detallePedidoa.Cantidad = 1;
                detallePedidoa.Color = comboColores.Text;
                detallePedidoa.Talla = combotallas.Text;
                if (comboColores.Items.Count > 0)
                {
                    detallePedidoa.DetalleColorId = int.Parse(comboColores.SelectedValue.ToString());
                }
                if (combotallas.Items.Count > 0)
                {
                    detallePedidoa.DetalleTallaId = int.Parse(combotallas.SelectedValue.ToString());
                }


                if (item.TieneEscalas == false)
                {
                    if (comboPreciostipos.Text == "Mayorista")
                    {
                        detallePedidoa.Precio = item.PrecioMayorista;

                    }
                    if (comboPreciostipos.Text == "Minorista")
                    {
                        detallePedidoa.Precio = item.PrecioVenta;

                    }
                    if (comboPreciostipos.Text == "Cuenta Clave")
                    {
                        detallePedidoa.Precio = item.PrecioCuentaClave;

                    }
                    if (comboPreciostipos.Text == "Revendedor")
                    {
                        detallePedidoa.Precio = item.PrecioRevendedor;

                    }
                    if (comboPreciostipos.Text == "Gubernamental")
                    {
                        detallePedidoa.Precio = item.PrecioEntidadGubernamental;

                    }
                    detallePedidoa.Total = detallePedidoa.Precio * detallePedidoa.Cantidad;
                }
                else
                {
                    var TipoPrecio = _tipoPrecioRepository.Get(item.Id);
                    var detallePrecios = _tipoPrecioRepository.GetDetallePrecio(TipoPrecio.Id, int.Parse(comboPreciostipos.SelectedValue.ToString()));
                    if (detallePrecios == null) { return; }
                    foreach (var objeto in detallePrecios)
                    {
                        if (detallePedidoa.Cantidad >= objeto.RangoInicio && detallePedidoa.Cantidad <= objeto.RangoFinal)
                        {
                            detallePedidoa.Precio = objeto.Precio;
                            detallePedidoa.Total = detallePedidoa.Precio * detallePedidoa.Cantidad;
                        }
                    }

                }



                listaT.Add(detallePedidoa);


            }
            cargarlistaProductosSelected(datagrid, listaT);
        }

        private void limpiarSeleccion(DataGridView datagrid, int numerocol)
        {

            foreach (DataGridViewRow Rows in datagrid.Rows)
            {
                bool acciones = Convert.ToBoolean(Rows.Cells[numerocol].Value);
                if (acciones)
                {
                    Rows.Cells[numerocol].Value = false;
                }
            }
        }

        private void cargarlistaProductosSelected(DataGridView datagrid, List<ListarDetallePedidos> lista)
        {

            BindingSource recurso = new BindingSource();
            recurso.DataSource = lista;
            datagrid.DataSource = typeof(List<>);
            datagrid.DataSource = recurso;
            datagrid.Columns[0].Visible = false;
             datagrid.Columns[1].Visible = false;
            datagrid.Columns[2].Visible = false;
            datagrid.Columns[3].Visible = false;
            datagrid.Columns[10].Visible = false;
            datagrid.Columns[11].Visible = false;
            datagrid.Columns[12].Visible = false;
        }

        private void ActualizarMonto()
        {
            decimal actualizarTotal = 0.00M; ;

            foreach (DataGridViewRow fila in dgvpedidos.Rows)
            {
                if (fila.Cells[subtotalcolcotiz].Value != null)
                    actualizarTotal += (decimal)fila.Cells[subtotalcolcotiz].Value;
            }


            lbtotal1.Text = actualizarTotal.ToString();

        }



        private void CargarComboToPedido()
        {

            if (dgvCombos.RowCount <= 0) { return; }
            int filasSeleccion = 0;


            foreach (DataGridViewRow Rows in dgvCombos.Rows)
            {
                var filasTotales = int.Parse(dgvCombos.RowCount.ToString());


                bool acciones = Convert.ToBoolean(Rows.Cells[colAcciones].Value);
                if (!acciones)
                {
                    filasSeleccion += 1;
                }
                else
                {
                    var detallePedido = GetlistaDetalle();
                    detallePedido.ComboId = Guid.Parse(Rows.Cells[1].Value.ToString());
                    detallePedido.Descripcion = Rows.Cells[3].Value.ToString();
                    detallePedido.PedidoId = Guid.Parse(lbnoVale.Text);
                    detallePedido.Cantidad = 1;

                    if (comboPreciostipos.Text == "Mayorista")
                    {
                        detallePedido.Precio = Convert.ToDecimal(Rows.Cells[mayoristacol].Value.ToString());
                    }
                    if (comboPreciostipos.Text == "Minorista")
                    {
                        detallePedido.Precio = Convert.ToDecimal(Rows.Cells[minoristacol].Value.ToString());
                    }
                    if (comboPreciostipos.Text == "Cuenta Clave")
                    {
                        detallePedido.Precio = Convert.ToDecimal(Rows.Cells[cuentaclacol].Value.ToString());
                    }
                    if (comboPreciostipos.Text == "Revendedor")
                    {
                        detallePedido.Precio = Convert.ToDecimal(Rows.Cells[reventacol].Value.ToString());

                    }
                    if (comboPreciostipos.Text == "Gubernamental")
                    {
                        detallePedido.Precio = Convert.ToDecimal(Rows.Cells[gubernacol].Value.ToString());

                    }

                    detallePedido.Total = detallePedido.Cantidad * detallePedido.Precio;
                    _listaDetalleToPedido.Add(detallePedido);

                }


                if (filasTotales == filasSeleccion)
                {
                    KryptonMessageBox.Show("Debera tener seleccionada  la columna 'Acciones'\n "
                        + "Selecione un Producto, dando click en la columna Acciones\n"
                        );

                    return;
                }

            }
            cargarlistaProductosSelected(dgvpedidos, _listaDetalleToPedido);

        }

        private void SeleccionAcciones(DataGridView data, List<Producto> Productolista)
        {


            if (data.RowCount <= 0) { return; }
            int filasSeleccion = 0;
            foreach (DataGridViewRow Rows in data.Rows)
            {
                var filasTotales = int.Parse(data.RowCount.ToString());


                bool acciones = Convert.ToBoolean(Rows.Cells[28].Value);
                if (!acciones)
                {
                    filasSeleccion += 1;
                }
                else
                {
                    var Id = int.Parse(Rows.Cells[0].Value.ToString());
                    var productoObtenido = _productosRepository.Get(Id);
                    if (productoObtenido.TieneColor == false && productoObtenido.TieneTalla == false || productoObtenido.TieneColor == true || productoObtenido.TieneTalla == true)
                    {
                        Productolista.Add(productoObtenido);
                    }

                }


                if (filasTotales == filasSeleccion)
                {
                    KryptonMessageBox.Show("Debera tener seleccionada  la columna 'Acciones'\n "
                        + "Selecione un Producto, dando click en la columna Acciones\n");

                    return;
                }

            }


        }
        private void btnguardar_Click(object sender, EventArgs e)
        {

            GuardarPedidos();


        }

        private void dgvProductos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarFila(dgvProductos, colAccionesProd);
            var FilaActual = (ListarProductos)dgvProductos.CurrentRow.DataBoundItem;
            LlenarTextBox(FilaActual);
            var productoBuscar = _productosRepository.Get(FilaActual.Id);
            if (productoBuscar.TieneColor == true && productoBuscar.TieneTalla == true)
            {

                CargarDGVcolortalla(productoBuscar.Id);
                btnAddVale.Enabled = false;
            }
            else
            {
                btnAddVale.Enabled = true;
                dgvtallascolores.DataSource = null;
            }
        }

        private void dgvtallascolores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarfila(dgvtallascolores, colAccionesTyC);
        }

        private void btnAddRebaja_Click(object sender, EventArgs e)
        {


            CargarComboToPedido();
            //ListaFilaRebajas.Clear();
            limpiarSeleccion(dgvCombos, colAcciones);
            ActualizarMonto();
        }

        private void btnAddVale_Click(object sender, EventArgs e)
        {


            SeleccionAcciones(dgvProductos, ListaFilasenDGV);
            AgregarlistaToDgv(dgvpedidos, _listaDetalleToPedido, ListaFilasenDGV);
            ListaFilasenDGV.Clear();
            limpiarSeleccion(dgvProductos, colAccionesProd);

        }

        private void dgvToVales_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            BuscarEscalaPrecios();
        }

        private void dgvToVales_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

        }

        private void dgvToVales_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ActualizarMonto();
        }

        private void dgvCombos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarFila(dgvCombos, colAcciones);
            var comboActual = (ListarCombos)dgvCombos.CurrentRow.DataBoundItem;
            CargarDg(comboActual.IdCombo);

        }

        private void btnaddTallasycolores_Click(object sender, EventArgs e)
        {
            CargarSizeAndColorsToCombo();
            limpiarSeleccion(dgvtallascolores, 5);
            limpiarSeleccion(dgvProductos, 28);
        }

        private void txtbuscarcombo_TextChanged(object sender, EventArgs e)
        {
            var filter = combos.Where(a => a.Descripcion.Contains(txtbuscarcombo.Text) ||
            (a.CodigoBarras != null && a.CodigoBarras.Contains(txtbuscarcombo.Text))
            );
            dgvCombos.DataSource = filter.ToList();

        }
        private void seleccionarfila(DataGridView data, int numberCol)
        {
            bool estadoActual = Convert.ToBoolean(data.CurrentRow.Cells[numberCol].Value);
            if (estadoActual)
            {
                data.CurrentRow.Cells[numberCol].Value = false;
            }
            else
            {
                data.CurrentRow.Cells[numberCol].Value = true;

            }
        }

        private void dgvPedido_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            ActualizarMonto();
        }

        private void comboPreciostipos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtbuscarp_TextChanged(object sender, EventArgs e)
        {
            var filter = listaProductos.Where(a => a.Descripcion.Contains(txtbuscarp.Text) ||
                (a.CodigoReferencia != null && a.CodigoReferencia.Contains(txtbuscarp.Text)) ||
                (a.Categoria != null && a.Categoria.Contains(txtbuscarp.Text)) ||
                (a.Notas != null && a.Notas.Contains(txtbuscarp.Text)));
            dgvProductos.DataSource = filter.ToList();
        }

        private void SeleccionarFila(DataGridView datagrid, int acciones)
        {
            bool estadoActual = Convert.ToBoolean(datagrid.CurrentRow.Cells[acciones].Value);
            if (estadoActual)
            {
                datagrid.CurrentRow.Cells[acciones].Value = false;
            }
            else
            {
                datagrid.CurrentRow.Cells[acciones].Value = true;

            }

        }

        private void GuardarPedidos()
        {
            if (dgvpedidos.RowCount == 0) { KryptonMessageBox.Show("Debe tener un producto para Facturar"); return; }
            var detallePedido = GetDatosDetallePedido();
            var encabezadopedido = GetNewPedido();
            if (!ModelState.IsValid(detallePedido)) { return; }
            if (!ModelState.IsValid(encabezadopedido)) { return; }
            _pedidoRepository.AddEncabezado(encabezadopedido);
            foreach (var item in detallePedido)
            {
                if (item.ProductoId == 0)
                {
                    item.ProductoId = null;
                    var combob = _combosRepository.Get((Guid)item.ComboId);
                    if (combob.Stock <= 0) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }
                    if (combob.Stock < item.Cantidad) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }

                }
                else
                {
                    item.ComboId = null;
                    var producto = _productosRepository.Get((int)item.ProductoId);
                    if (producto.Stock <= 0) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }
                    if (producto.Stock < item.Cantidad) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }

                    if (item.DetalleColorId != 0)
                    {
                        var detalleObtenido = _coloresRepository.GetDetalleColor((int)item.DetalleColorId);
                        if (detalleObtenido.Stock < item.Cantidad) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }
                        //detalleObtenido.Stock -= item.Cantidad;
                        //_coloresRepository.Update(detalleObtenido);
                    }
                    if (item.DetalleTallaId != 0)
                    {
                        var detalleObtenidotalla = _tallasRepository.GetDetalleTalla((int)item.DetalleTallaId);
                        if (detalleObtenidotalla.Stock < item.Cantidad) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }
                        //detalleObtenidotalla.Stock -= item.Cantidad;
                        //_tallasRepository.Update(detalleObtenidotalla);
                    }
                    if (item.DetalleColorTallaId != 0)
                    {
                        var detallecolortallaobten = _tallasyColoresRepository.GetColorTalla((int)item.DetalleColorTallaId);
                        if (detallecolortallaobten.Stock < item.Cantidad) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }
                        //detallecolortallaobten.Stock -= item.Cantidad;
                        //_tallasyColoresRepository.Update(detallecolortallaobten);
                    }

                }

                if (item.DetalleColorId == 0)
                {
                    item.DetalleColorId = null;

                }
                if (item.DetalleTallaId == 0)
                {
                    item.DetalleTallaId = null;
                }
                if (item.DetalleColorTallaId == 0)
                {
                    item.DetalleColorTallaId = null;
                }

                _pedidoRepository.AddDetalles(item);
            }

            KryptonMessageBox.Show("Registro Guardado correctamente! ");
            cargarnuevamente();
            Close();

        }


        private void BuscarEscalaPrecios()
        {
            var codigoProducto = Convert.ToInt32(dgvpedidos.CurrentRow.Cells[productidColcotiz].Value);
            if (codigoProducto != 0)
            {
                var productoObtenido = _productosRepository.Get(codigoProducto);
                if (productoObtenido.TieneEscalas)
                {
                    var cantidad = Convert.ToInt32(dgvpedidos.CurrentRow.Cells[cantidadcolcotiz].Value);
                    var TipoPrecio = _tipoPrecioRepository.Get(codigoProducto);
                    var detallePrecios = _tipoPrecioRepository.GetDetallePrecio(TipoPrecio.Id, int.Parse(comboPreciostipos.SelectedValue.ToString()));
                    if (detallePrecios == null) { return; }
                    foreach (var item in detallePrecios)
                    {
                        if (cantidad >= item.RangoInicio && cantidad <= item.RangoFinal)
                        {

                            dgvpedidos.CurrentRow.Cells[preciocolcotiz].Value = item.Precio;
                            dgvpedidos.CurrentRow.Cells[subtotalcolcotiz].Value =
                           Convert.ToDecimal(dgvpedidos.CurrentRow.Cells[preciocolcotiz].Value) * Convert.ToDecimal(dgvpedidos.CurrentRow.Cells[cantidadcolcotiz].Value);
                        }
                    }

                }



                dgvpedidos.CurrentRow.Cells[subtotalcolcotiz].Value =
               Convert.ToDecimal(dgvpedidos.CurrentRow.Cells[preciocolcotiz].Value) * Convert.ToDecimal(dgvpedidos.CurrentRow.Cells[cantidadcolcotiz].Value);
            }
            dgvpedidos.CurrentRow.Cells[subtotalcolcotiz].Value =
                Convert.ToDecimal(dgvpedidos.CurrentRow.Cells[preciocolcotiz].Value) * Convert.ToDecimal(dgvpedidos.CurrentRow.Cells[cantidadcolcotiz].Value);

            ActualizarMonto();

        }

        public void CargarDg(Guid idcombo)
        {


            BindingSource source = new BindingSource();
            var detalleListsObtenida = _combosRepository.GetListDetalleCombo(idcombo);
            source.DataSource = detalleListsObtenida;
            dgvDetalleCombo.DataSource = typeof(List<>);
            dgvDetalleCombo.DataSource = source;
            dgvDetalleCombo.Columns[0].Visible = false;
            dgvDetalleCombo.Columns[1].Visible = false;
            dgvDetalleCombo.Columns[2].Visible = false;
            dgvDetalleCombo.Columns[3].Visible = false;
            dgvDetalleCombo.Columns[6].Visible = false;
            dgvDetalleCombo.Columns[8].Visible = false;
            dgvDetalleCombo.AutoResizeColumns();


        }

        public void LlenarTextBox(ListarProductos filaActual)
        {

            var productoObtenido = _productosRepository.Get(filaActual.Id);
            if (productoObtenido.TieneColor == true && productoObtenido.TieneTalla == false)
            {
                var listadeColoresProductos = _coloresRepository.GetProductoListaColor(productoObtenido.Id);
                cargarComboColores(listadeColoresProductos);

            }
            else
            {
                comboColores.DataSource = null;

            }
            if (productoObtenido.TieneColor == false && productoObtenido.TieneTalla == true)
            {
                var listadeTallaProductos = _tallasRepository.GetTallaListaProducto(productoObtenido.Id);
                cargarComboTallas(listadeTallaProductos);

            }
            else
            {
                combotallas.DataSource = null;

            }
            if (productoObtenido.TieneColor == true && productoObtenido.TieneTalla == true)
            {
                combotallas.DataSource = null;
                comboColores.DataSource = null;
            }
        }
        private void cargarComboColores(List<DetalleColor> detalleColors)
        {
            comboColores.DataSource = detalleColors;
            comboColores.ValueMember = "Id";
            comboColores.DisplayMember = "Color";
            comboColores.SelectedIndex = 0;
        }
        private void cargarComboTallas(List<DetalleTalla> listaTallas)
        {
            combotallas.DataSource = listaTallas;
            combotallas.ValueMember = "Id";
            combotallas.DisplayMember = "Talla";
            combotallas.SelectedIndex = 0;
        }
        private void CargarSizeAndColorsToCombo()
        {

            if (dgvtallascolores.RowCount <= 0) { return; }
            int filasSeleccion = 0;


            foreach (DataGridViewRow Rows in dgvtallascolores.Rows)
            {
                var filasTotales = int.Parse(dgvtallascolores.RowCount.ToString());


                bool acciones = Convert.ToBoolean(Rows.Cells[colAccionesTyC].Value);
                if (!acciones)
                {
                    filasSeleccion += 1;
                }
                else
                {
                    var detallePedido = GetlistaDetalle();

                    detallePedido.ProductoId = int.Parse(Rows.Cells[productIDTyCcol].Value.ToString());
                    var productoobtenido = _productosRepository.Get(detallePedido.ProductoId);
                    detallePedido.Cantidad = 1;
                    detallePedido.Descripcion = productoobtenido.Descripcion;
                    detallePedido.Color = Rows.Cells[colorTyCcol].Value.ToString();
                    detallePedido.Talla = Rows.Cells[tallaTyCcol].Value.ToString();
                    detallePedido.TallayColorId = int.Parse(Rows.Cells[IDTyCcol].Value.ToString());
                    detallePedido.PedidoId = Guid.Parse(lbnoVale.Text);
                    if (productoobtenido.TieneEscalas == false)
                    {
                        if (comboPreciostipos.Text == "Mayorista")
                        {
                            detallePedido.Precio = productoobtenido.PrecioMayorista;

                        }
                        if (comboPreciostipos.Text == "Minorista")
                        {
                            detallePedido.Precio = productoobtenido.PrecioVenta;

                        }
                        if (comboPreciostipos.Text == "Cuenta Clave")
                        {
                            detallePedido.Precio = productoobtenido.PrecioCuentaClave;

                        }
                        if (comboPreciostipos.Text == "Revendedor")
                        {
                            detallePedido.Precio = productoobtenido.PrecioRevendedor;

                        }
                        if (comboPreciostipos.Text == "Gubernamental")
                        {
                            detallePedido.Precio = productoobtenido.PrecioEntidadGubernamental;

                        }
                        detallePedido.Total = detallePedido.Precio * detallePedido.Cantidad;
                    }
                    else
                    {
                        var TipoPrecio = _tipoPrecioRepository.Get(productoobtenido.Id);
                        var detallePrecios = _tipoPrecioRepository.GetDetallePrecio(TipoPrecio.Id, int.Parse(comboPreciostipos.SelectedValue.ToString()));
                        if (detallePrecios == null) { return; }
                        foreach (var objeto in detallePrecios)
                        {
                            if (detallePedido.Cantidad >= objeto.RangoInicio && detallePedido.Cantidad <= objeto.RangoFinal)
                            {
                                detallePedido.Precio = objeto.Precio;
                                detallePedido.Total = detallePedido.Precio * detallePedido.Cantidad;
                            }
                        }
                    }

                    _listaDetalleToPedido.Add(detallePedido);

                }


                if (filasTotales == filasSeleccion)
                {
                    KryptonMessageBox.Show("Debera tener seleccionada  la columna 'Acciones'\n "
                        + "Selecione un Producto, dando click en la columna Acciones\n"
                        );

                    return;
                }

            }
            cargarlistaProductosSelected(dgvpedidos, _listaDetalleToPedido);

        }

        private void cargarnuevamente()
        {
            NuevoPedido nuevo = new NuevoPedido(_panelLayout);
            nuevo.MdiParent = _panelLayout;
            nuevo.Show();
        }
        public void CargarDGVcolortalla(int idproducto)
        {


            BindingSource source = new BindingSource();
            var detalleListsObtenida = _tallasyColoresRepository.GetListaDetalleColorTallas(idproducto);
            source.DataSource = detalleListsObtenida;
            dgvtallascolores.DataSource = typeof(List<>);
            dgvtallascolores.DataSource = source;
            dgvtallascolores.AutoResizeColumns();


        }




    }
}