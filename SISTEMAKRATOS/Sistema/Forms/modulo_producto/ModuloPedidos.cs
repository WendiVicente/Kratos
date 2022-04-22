using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Pedidos;
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

namespace Sistema.Forms.modulo_producto
{
    public partial class ModuloPedidos : BaseContext

    {
        private ProductosRepository _productosRepository = null;
        private CombosRepository _combosRepository = null;
        private PedidoRepository _pedidoRepository = null;
        public List<ListarSucursales> SucursalesSeleccionadas = null;
        private IList<ListarPedidos> pedido = null;
       
        

        private TipoPrecioRepository _tipoPrecioRepository = null;
        
        private ClientesRepository _ClientesRepository = null;
        #region REPOS
     

        #endregion REPOS
        #region LISTAS
        private List<ListarProductos> _listadoproductos;
        private List<ListarCombos> _listarCombos;
        private List<ListarDetallePedidos> listaDetallespedidos;
        private List<ListarTipoPrecios> tipoPrecios=null;
        private List<ListarClientes> listaClientes;

        int valor = 0;
        #endregion LISTAS
        #region VARIABLES

       
        private bool MostrarMenu = true;
       
        private readonly int colAccionesProd = 0;
        private readonly int colAccionesCombo = 0;

        


        #endregion VARIABLES
        public ModuloPedidos()
        {
            _productosRepository = new ProductosRepository(_context);
            _combosRepository = new CombosRepository(_context);
            _pedidoRepository = new PedidoRepository(_context);
            _tipoPrecioRepository = new TipoPrecioRepository(_context);
            _ClientesRepository = new ClientesRepository(_context);
            listaDetallespedidos= new List<ListarDetallePedidos>();
            
            InitializeComponent();
            Cargar();
           
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
        public void CargarDGV()
        {
            pedido = _pedidoRepository.GetListGenerales(0);
            BindingSource source = new BindingSource();
            source.DataSource = pedido;
            DgvListPedidos.DataSource = typeof(List<>);
            DgvListPedidos.DataSource = source;
        }
        private void ModuloPedidos_Load(object sender, EventArgs e)
        {
            CargarDGV();
            CargarProductos();
            CargarCombos();
            CargartipoPrecio();
            cargarcliente();
            RefrescarDataGridPedido(true);
            
           
         
        }
        private void ActualizarMonto()
        {
            decimal actualizarTotal = 0.00M;
            decimal cantidad = 0.00m;

            foreach (DataGridViewRow fila in DgvDetallePedidos.Rows)
            {
                if (fila.Cells[6].Value != null)

                    cantidad = cantidad + (decimal)fila.Cells[6].Value;
            }


            lbtotal1.Text = cantidad.ToString();

        }
        public void Cargar()
        {
            var cliente = _pedidoRepository.GetLastPedidos(UsuarioLogeadoSistemas.User.SucursalId);
            lbnoVale.Text = ObtenerNumero(cliente, "PD-");
           
        }
      
        private string ObtenerNumero(string soli, string CL)
        {
            string numero = "";
            if (soli.Equals(null))
            {
                numero = CL + "001";
            }
            else if (soli.Length > 0)
            {

                int maxsol = Convert.ToInt32(soli.Split('-')[1]) + 1;
                if (maxsol < 10)
                    numero = CL + "00" + maxsol;
                else if (maxsol < 100)
                    numero = CL + "0" + maxsol;
                else
                    numero = CL + maxsol;
            }
            return numero;
        }
    

        private void ModuloPedidos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MostrarMenu)
                MenuPrincipal(this, false);
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


        private void CargarCombos()
        {

            BindingSource source = new BindingSource();
            _listarCombos = _combosRepository.GetListarCombos(UsuarioLogeadoSistemas.User.SucursalId).ToList();
            source.DataSource = _listarCombos;
            DgvCombos.DataSource = typeof(List<>);
            DgvCombos.DataSource = source;
            DgvCombos.ClearSelection();


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

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            PageGestion.Visible = true;
            NavPedidos.SelectedPage = PageGestion;
        }

        private void comboPreciostipos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void CargartipoPrecio()
        {

            try
            {
                comboPreciostipos.DataSource = _ClientesRepository.GetTipos();
                comboPreciostipos.DisplayMember = "TipoCliente";
                comboPreciostipos.ValueMember = "Id";
                comboPreciostipos.Invalidate();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("No existe el tipo de precio,deberá ingresar uno", ex.Message);
            }
        }
        private void cargarcliente()
        {
            try
            {
                comboClientes.DataSource = _ClientesRepository.GetClientes();
                comboClientes.DisplayMember = "Nombres";
                comboClientes.ValueMember = "Id";
                comboClientes.Invalidate();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("No hay ningun cliente, deberá ingresar uno", ex.Message);
            }
        }

        private List<ListarDetalle> SeleccionDetalles()
        {
            List<ListarDetalle> listadoseleccion = new List<ListarDetalle>();
            foreach (DataGridViewRow Rows in DgvCombos.Rows)
            {
                ListarDetalle detalle = (ListarDetalle)Rows.DataBoundItem;
                if (detalle.Acciones)
                {
                    listadoseleccion.Add(detalle);
                }
            }
            return listadoseleccion;
        }
       
        private void LimpiarSeleccionPedido()
        {
            foreach (ListarProductos prod in _listadoproductos)
            {
                prod.Acciones = false;
            }
            BindingSource source = new BindingSource
            {
                DataSource = _listadoproductos
            };
            DgvProductos.DataSource = typeof(List<>);
            DgvProductos.DataSource = source;
            DgvProductos.ClearSelection();
           

        }
        private void LimpiarSeleccionPedidoCombo()
        {
            foreach (ListarCombos com in _listarCombos)
                {
                   com.Acciones = false;
                }
                BindingSource source = new BindingSource
                {
                    DataSource = _listarCombos
                };
                DgvCombos.DataSource = typeof(List<>);
                DgvCombos.DataSource = source;
                DgvCombos.ClearSelection();
               
            
            }
        private void BtnAgregarListado_Click(object sender, EventArgs e)
        {
           
                List<ListarProductos> seleccionados = SeleccionAcciones();
                if (seleccionados.Count > 0)
                {
                    AgregarListarDetallesPedidos(seleccionados);
                ActualizarMonto();
                LimpiarSeleccionPedido();
        
                }
                else
                {
                    KryptonMessageBox.Show("No hay productos seleccionados", "Advertencia");
                }
         }

            private void CargarDgvCombos(List<ListarDetalle> listarDetalles)
        {
            BindingSource source = new BindingSource
            {
                DataSource = listarDetalles
            };
            DgvCombos.DataSource = typeof(List<>);
            DgvCombos.DataSource = source;
            DgvCombos.ClearSelection();
        }
       
       
        

       

       
      
        private void DgvVale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnAgregarCombo_Click(object sender, EventArgs e)
        {

            List<ListarCombos> seleccionados = SeleccionCombos();
            if (seleccionados.Count > 0)
            {
                AgregarListarDetallesPedidosCombos(seleccionados);
                ActualizarMonto();
                LimpiarSeleccionPedidoCombo();
                
                
            }
            else
            {
                KryptonMessageBox.Show("No hay productos seleccionados", "Advertencia");
            }
        }


        #region GESTION

   

        private void CargarDGVPedidos(List<ListarDetallePedidos> lista)
        {
            BindingSource recurso = new BindingSource();
            recurso.DataSource = lista;
            DgvDetallePedidos.DataSource = typeof(List<>);
            DgvDetallePedidos.DataSource = recurso;
            DgvDetallePedidos.ClearSelection();
        }

        private void TxtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtCantDecimal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TxtCantDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as KryptonTextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }
        }

    
        private void DgvDetallesCombo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
          //  SumarCostos();
        }

        private void DgvVale_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //var fila = DgvPedidos.CurrentRow;
            //var filaActualEliminada = (ListarDetallePedidos)fila.DataBoundItem;
            //listaDetalles.Add(filaActualEliminada);
          //  SumarCostos();
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
        private ListarDetallePedidos GetlistaDetalle()
        {
            return new ListarDetallePedidos()
            {

            };
        }

        private void AgregarListarDetallesPedidos(List<ListarProductos> listadoseleccion)
        {
            foreach (var item in listadoseleccion)
            {

                var detallePedidoa = GetlistaDetalle();
                detallePedidoa.ProductoId = item.Id;
                detallePedidoa.Descripcion = item.Descripcion;
                detallePedidoa.PedidoId = Guid.NewGuid();
                detallePedidoa.Cantidad = 1;




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


                listaDetallespedidos.Add(detallePedidoa);
            }
                CargarDGVPedidos(listaDetallespedidos);
          
        }

        private void AgregarListarDetallesPedidosCombos(List<ListarCombos> listadoseleccion)
        {
            if (DgvCombos.RowCount <= 0) { return; }
            int filasSeleccion = 0;


            foreach (DataGridViewRow Rows in DgvCombos.Rows)
            {
                var filasTotales = int.Parse(DgvCombos.RowCount.ToString());


                bool acciones = Convert.ToBoolean(Rows.Cells[0].Value);
                if (!acciones)
                {
                    filasSeleccion += 1;
                }
                else
                {
                    var detallePedido = GetlistaDetalle();
                    detallePedido.ComboId = Guid.Parse(Rows.Cells[2].Value.ToString());
                    detallePedido.Descripcion = Rows.Cells[4].Value.ToString();
                    detallePedido.PedidoId = Guid.Parse(lbnoVale.Text);
                    detallePedido.Cantidad = 1;

                    if (comboPreciostipos.Text == "Mayorista")
                    {
                        detallePedido.Precio = Convert.ToDecimal(Rows.Cells[8].Value.ToString());
                    }
                    if (comboPreciostipos.Text == "Minorista")
                    {
                        detallePedido.Precio = Convert.ToDecimal(Rows.Cells[9].Value.ToString());
                    }
                    if (comboPreciostipos.Text == "Cuenta Clave")
                    {
                        detallePedido.Precio = Convert.ToDecimal(Rows.Cells[11].Value.ToString());
                    }
                    if (comboPreciostipos.Text == "Revendedor")
                    {
                        detallePedido.Precio = Convert.ToDecimal(Rows.Cells[12].Value.ToString());

                    }
                    if (comboPreciostipos.Text == "Gubernamental")
                    {
                        detallePedido.Precio = Convert.ToDecimal(Rows.Cells[10].Value.ToString());

                    }

                    detallePedido.Total = detallePedido.Cantidad * detallePedido.Precio;
                    listaDetallespedidos.Add(detallePedido);

                }


                if (filasTotales == filasSeleccion)
                {
                    KryptonMessageBox.Show("Debera tener seleccionada  la columna 'Acciones'\n "
                        + "Selecione un Producto, dando click en la columna Acciones\n"
                        );

                    return;
                }

            }
            CargarDGVPedidos(listaDetallespedidos);

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
                DetalleProducto(this, producto);
            }
        }
        private void DgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = DgvProductos.CurrentRow.Index;
            if (DgvProductos.CurrentCell.ColumnIndex == colAccionesProd)
            {
                var fila = DgvProductos.CurrentRow;
                ListarProductos listarProductos = (ListarProductos)fila.DataBoundItem;
                int tienedetalle = ObtenerTipoDetalle(listarProductos);
                if (listarProductos.Acciones)
                {
                    DgvProductos.CurrentRow.Cells[colAccionesProd].Value = false;
                    if (tienedetalle > 0)
                        LlenarTextBox();
                    //  cantidadProdDet--;
                    else
                        // cantidadProd--;
                        KryptonMessageBox.Show("No hay Detalles ", "Advertencia");
                }
                else
                {
                    DgvProductos.CurrentRow.Cells[colAccionesProd].Value = true;
                }
               

        }
        }


        #endregion GESTION

        private void dtpinicio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DgvCombos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = DgvCombos.CurrentRow.Index;
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

        private void DgvDetallePedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private Pedido GetModelPedido()
        {
            return new Pedido()
            {
                Id = Guid.NewGuid(),
                Nombre=comboClientes.Text,
                SucursalId = UsuarioLogeadoSistemas.User.SucursalId,
                FechaRecepcion = dtpinicio.Value,
                FechaLimite = dtpfin.Value,
                NombreVendedor = UsuarioLogeadoSistemas.User.Name,
               
                NoPedido=lbnoVale.Text,
                           
            };
        }
        private DetallePedidos GetDetallePedido()
        {
            return new DetallePedidos()
            {
            };
        }
      
       
       
       
        private void GuardarPedido(int idcliente)
        {

          if (DgvDetallePedidos.RowCount == 0) { KryptonMessageBox.Show("Debe tener un producto para Facturar"); return; }
            var detallePedido = GetDetallePedido();
            var encabezadopedido = GetModelPedido();

            if (!ModelState.IsValid(detallePedido)) { return; }
            if (!ModelState.IsValid(encabezadopedido)) { return; }
            encabezadopedido.ClienteId = idcliente;
            encabezadopedido.NoPedido = lbnoVale.Text;
            

            _pedidoRepository.AddEncabezado(encabezadopedido);
            foreach (var item in listaDetallespedidos)
            {
                if (item.ProductoId != 0)
                {
                    var detalle = new DetallePedidos()
                    {
                        Id = Guid.NewGuid(),
                        ProductoId = item.ProductoId,
                        PedidoId = encabezadopedido.Id,
                        
                    };
                    _pedidoRepository.AddDetalles(detalle);

                }
                else
                {
                    var detalle = new DetallePedidos()
                    {
                        Id = Guid.NewGuid(),
                        PedidoId = encabezadopedido.Id,
                        ComboId = item.ComboId, //analizar
                    };
                    _pedidoRepository.AddDetalles(detalle);
                }
            }

        }
      

        private void BtnDetalleCombo_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DetalleCombo"] != null)
            {
                Application.OpenForms["DetalleCombo"].Close();
            }

            if (DgvCombos.CurrentRow != null)
            {
                var fila = DgvCombos.CurrentRow;
                ListarCombos combo = (ListarCombos)fila.DataBoundItem;
                DetallesCombo(this, combo);
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string txt1 = toolStripTextBox1.Text;
                String txt2 = toolStripTextBox1.Text.ToUpper();
                var filter = _listadoproductos.Where(a => a.Descripcion.Contains(txt1) || a.Descripcion.Contains(txt2));

                DgvProductos.DataSource = filter.ToList();
                DgvProductos.ClearSelection();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("BuscarProductos() ha fallado! " + ex.Message);
            }
        }

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string txt1 = toolStripTextBox2.Text;
                String txt2 = toolStripTextBox2.Text.ToUpper();
                var filter = _listarCombos.Where(a => a.Descripcion.Contains(txt1) || a.Descripcion.Contains(txt2));

                DgvCombos.DataSource = filter.ToList();
                DgvCombos.ClearSelection();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("BuscarProductos() ha fallado! " + ex.Message);
            }
        }
        private void LimpiarContenido()
        {

            txtestado.Text = "";
            DgvDetallePedidos.Rows.Clear();


        }
        public void RefrescarDataGridPedido(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _pedidoRepository = null;
                _pedidoRepository = new PedidoRepository(_context);
            }

            BindingSource source = new BindingSource();
            pedido = _pedidoRepository.GetListGenerales(0);
            source.DataSource = pedido;
            DgvListPedidos.DataSource = typeof(List<>);
            DgvListPedidos.DataSource = source;
            DgvListPedidos.AutoResizeColumns();
            //DgvListPromociones.Columns[0].Visible = false;
        }
        private void BtnGuardarC_Click_1(object sender, EventArgs e)
        {
            GuardarPedido(int.Parse(comboClientes.SelectedValue.ToString()));
            Cargar();
            RefrescarDataGridPedido();
        }

        private void DgvListPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvDetallePedidos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var filaActual = (ListarDetallePedidos)DgvDetallePedidos.CurrentRow.DataBoundItem;
            filaActual.Total = filaActual.Precio * filaActual.Cantidad;
            ActualizarMonto();

        }

        private void DgvDetallePedidos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ActualizarMonto();
        }

        private void DgvDetallePedidos_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            ActualizarMonto();
        }

        private void DgvDetallePedidos_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            ActualizarMonto();
        }
    }
}
