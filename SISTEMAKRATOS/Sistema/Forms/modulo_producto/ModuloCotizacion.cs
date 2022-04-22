using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Cotizacion;
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
    public partial class ModuloCotizacion : BaseContext
    {
        private ProductosRepository _productosRepository = null;
        private CombosRepository _combosRepository = null;
        private CotizacionRepository _cotizacionRepository = null;
        private SucursalesRepository _sucursalesRepository = null;
        private TipoPrecioRepository _tipoPrecioRepository=null;
        private ClientesRepository _clientesRepository=null;
        
       
        private IList<ListarCotizaciones> _listarcotiz = null;
        public List<ListarClientes> clientesseleccionados = null;
      
        private bool MostrarMenu = true;
        List<ListarCotizaciones> listacoti;
        private List<ListarDetalleCotiz> listaDetallesCotizacion;

        private List<ListarProductos> _listadoproductos;
        private List<ListarCombos> _listarCombos;
        int valor = 0;
        private Guid NuevoGuidCotiz;
        public ModuloCotizacion()
        {
            _productosRepository = new ProductosRepository(_context);
            _combosRepository = new CombosRepository(_context);
            _cotizacionRepository = new CotizacionRepository(_context);
            _sucursalesRepository = new SucursalesRepository(_context);
            _tipoPrecioRepository = new TipoPrecioRepository(_context);
            listaDetallesCotizacion = new List<ListarDetalleCotiz>();
            _clientesRepository = new ClientesRepository(_context);
          
            InitializeComponent();

          
        }
        #region variables
        private readonly int colAccionesProd = 0;
        private readonly int colAccionesCombo = 0;
        #endregion 

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
        
        private void ModuloCotizaciones_Load(object sender, EventArgs e)
        {
            CargarProductos();
            CargarDGV();
            CargarCombos();
            CargarTipoPrecio();
            CargarClienteNocotizacion();
            Cargar();
            RefrescarDataGridCombos(true);
        }
        public void Cargar()
        {
            var cliente = _cotizacionRepository.GetLastCotizacion(UsuarioLogeadoSistemas.User.SucursalId);
            lbnoVale.Text = ObtenerNumero(cliente, "CT-");
        }

        private string ObtenerNumero(string soli, string CL)
        {

            string numero = "";
            if (soli=="")
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
         
            //lbnoVale.Text =codigo;
           
                       
        private void ModuloCotizaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MostrarMenu)
                MenuPrincipal(this, false);
        }
        private void CargarTipoPrecio()
        {
           
            try
            {
                comboPreciostipos.DataSource = _clientesRepository.GetTipos();
                comboPreciostipos.DisplayMember = "TipoCliente";
                comboPreciostipos.ValueMember = "Id";
                comboPreciostipos.Invalidate();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("no hay ningun proveedor,deberá ingresar uno", ex.Message);
            }
        }
        private void CargarClienteNocotizacion()
        {
            try
            {
                comboClientes.DataSource = _clientesRepository.GetClientes();
                comboClientes.DisplayMember = "Nombres";
                comboClientes.ValueMember = "Id";
                comboClientes.Invalidate();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("no hay ningun cliente, deberá ingresar uno", ex.Message);
            }
        }

        #region LISTADO

        public void CargarDGV()
        {
            _listarcotiz = _cotizacionRepository.GetListGenerales(0);
            BindingSource source = new BindingSource();
            source.DataSource = _listarcotiz;
            DgvListCotizaciones.DataSource = typeof(List<>);
            DgvListCotizaciones.DataSource = source;
        }

        private void TxtBuscador_TextChanged(object sender, EventArgs e)
        {
            var filtro = _listarcotiz.Where(a => a.Nombre.Contains(TxtBuscador.Text) ||
                                           (a.Nombre != null && a.Nombre.Contains(TxtBuscador.Text)) ||
                                           (a.Apellido != null && a.Apellido.Contains(TxtBuscador.Text)) ||
                                           (a.NoCotizacion != null && a.NoCotizacion.Contains(TxtBuscador.Text)) ||
                                           (a.Nit != null && a.Nit.Contains(TxtBuscador.Text)) ||
                                           (a.Cliente != null && a.Cliente.Contains(TxtBuscador.Text)));
            DgvListCotizaciones.DataSource = filtro.ToList();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            PageGestion.Visible = true;
            NavCotizacion.SelectedPage = PageGestion;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (DgvListCotizaciones.CurrentRow != null)
            {
                PageGestion.Visible = true;
                NavCotizacion.SelectedPage = PageGestion;
            }
            else
            {
                KryptonMessageBox.Show("No ha seleccionado ninguna fila" +
                    " del listado.", "Notificación");
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            RefrescarDataGridCombos();
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (DgvListCotizaciones.CurrentRow == null)
            {
                return;
            }

            var dialog = KryptonMessageBox.Show("¿Está seguro que desea eliminar esta cotizacion ?", "Eliminar cotizacion",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);
            // dale proba okoko

            if (dialog == DialogResult.Yes)
            {
                var cotiz = (ListarCotizaciones)DgvListCotizaciones.CurrentRow.DataBoundItem;
                var getcotiz = _cotizacionRepository.GetCotizacion(cotiz.Id);
                getcotiz.IsActive = true;
                _cotizacionRepository.Updatecotizacion(getcotiz);
                CargarDGV();
            }
        }
        //  GetList(UsuarioLogeadoSistemas.User.SucursalId);
        #endregion
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

        private void toolCotz_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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

        private void DgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = DgvProductos.CurrentRow.Index;
            if (DgvProductos.CurrentCell.ColumnIndex == colAccionesProd)
            {
                var fila = DgvProductos.CurrentRow;
                ListarProductos listarcotizaciones = (ListarProductos)fila.DataBoundItem;
                int tienedetalle = ObtenerTipoDetalle(listarcotizaciones);
                if (listarcotizaciones.Acciones)
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
        private void CargarDGVcotizacion(List<ListarDetalleCotiz> lista)
        {
            BindingSource recurso = new BindingSource();
            recurso.DataSource = lista;
            DgvVale.DataSource = typeof(List<>);
            DgvVale.DataSource = recurso;
          //  DgvVale.AutoResizeColumns();
            DgvVale.ClearSelection();
        }
        private ListarDetalleCotiz GetlistaDetalle()
        {
            return new ListarDetalleCotiz()
            {

            };
        }
        private void AgregarListarDetalles(List<ListarProductos> listadoseleccioncoti)
        {

            foreach (var item in listadoseleccioncoti)
            {

                var detalleCotiza = GetlistaDetalle();
                detalleCotiza.ProductoId = item.Id;
                detalleCotiza.Descripcion = item.Descripcion;
                detalleCotiza.CotizacionId = NuevoGuidCotiz;
                detalleCotiza.Cantidad = 1;
 


               
                    if (comboPreciostipos.Text == "Mayorista")
                    {
                        detalleCotiza.Precio = item.PrecioMayorista;

                    }
                    if (comboPreciostipos.Text == "Minorista")
                    {
                        detalleCotiza.Precio = item.PrecioVenta;

                    }
                    if (comboPreciostipos.Text == "Cuenta Clave")
                    {
                        detalleCotiza.Precio = item.PrecioCuentaClave;

                    }
                    if (comboPreciostipos.Text == "Revendedor")
                    {
                        detalleCotiza.Precio = item.PrecioRevendedor;

                    }
                    if (comboPreciostipos.Text == "Gubernamental")
                    {
                        detalleCotiza.Precio = item.PrecioEntidadGubernamental;

                    }
                    detalleCotiza.Total = detalleCotiza.Precio * detalleCotiza.Cantidad;

                var exist = listaDetallesCotizacion.Find(x => x.Id == detalleCotiza.Id);
                if (exist == null)
                    listaDetallesCotizacion.Add(detalleCotiza);

            }
            CargarDGVcotizacion(listaDetallesCotizacion);
          

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
            
        private List<ListarProductos> SeleccionIsActive()
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
        private void LimpiarSeleccionCotizacion()
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
        private void BtnAgregarProd_Click(object sender, EventArgs e)
        {       
            {
                List<ListarProductos> seleccionados = SeleccionIsActive();
                if (seleccionados.Count > 0)
                {
                    AgregarListarDetalles(seleccionados);
                    ActualizarMonto();
                    LimpiarSeleccionCotizacion();
                
                }
                else
                {
                    KryptonMessageBox.Show("No hay productos seleccionados", "Advertencia");
                }
            }
           
        }


        private void DgvVale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private List<ListarCombos> SeleccionCombosCotizacion()
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
        private void CargarDGVCotizacion(List<ListarDetalleCotiz> lista)
        {
            BindingSource recurso = new BindingSource();
            recurso.DataSource = lista;
            DgvVale.DataSource = typeof(List<>);
            DgvVale.DataSource = recurso;
            DgvVale.ClearSelection();
        }
        private void AgregarListarDetallesCotizacionCombos(List<ListarCombos> listadoseleccion)
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
                    var detalleCotizacion = GetlistaDetalle();
                    detalleCotizacion.ComboId = Guid.Parse(Rows.Cells[2].Value.ToString());
                    detalleCotizacion.Descripcion = Rows.Cells[4].Value.ToString();
                    detalleCotizacion.CotizacionId = NuevoGuidCotiz;
                    detalleCotizacion.Cantidad = 1;

                    if (comboPreciostipos.Text == "Mayorista")
                    {
                        detalleCotizacion.Precio = Convert.ToDecimal(Rows.Cells[8].Value.ToString());
                    }
                    if (comboPreciostipos.Text == "Minorista")
                    {
                        detalleCotizacion.Precio = Convert.ToDecimal(Rows.Cells[9].Value.ToString());
                    }
                    if (comboPreciostipos.Text == "Cuenta Clave")
                    {
                        detalleCotizacion.Precio = Convert.ToDecimal(Rows.Cells[11].Value.ToString());
                    }
                    if (comboPreciostipos.Text == "Revendedor")
                    {
                        detalleCotizacion.Precio = Convert.ToDecimal(Rows.Cells[12].Value.ToString());

                    }
                    if (comboPreciostipos.Text == "Gubernamental")
                    {
                        detalleCotizacion.Precio = Convert.ToDecimal(Rows.Cells[10].Value.ToString());

                    }

                    detalleCotizacion.Total = detalleCotizacion.Cantidad * detalleCotizacion.Precio;
                    listaDetallesCotizacion.Add(detalleCotizacion);

                }


                if (filasTotales == filasSeleccion)
                {
                    KryptonMessageBox.Show("Debera tener seleccionada  la columna 'Acciones'\n "
                        + "Selecione un Producto, dando click en la columna Acciones\n"
                        );

                    return;
                }

            }
            CargarDGVCotizacion(listaDetallesCotizacion);
        }
        private void LimpiarSeleccionCotizacionCombo()
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

        private void BtnAgregarCombo_Click(object sender, EventArgs e)
        {

            List<ListarCombos> seleccionados = SeleccionCombosCotizacion();
            if (seleccionados.Count > 0)
            {
                AgregarListarDetallesCotizacionCombos(seleccionados);
                LimpiarSeleccionCotizacionCombo();

            }
            else
            {
                KryptonMessageBox.Show("No hay productos seleccionados", "Advertencia");
            }
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

        private void txtestado_TextChanged(object sender, EventArgs e)
        {

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
        private DetalleCotizacion GetDetalleCotizacion()
        {
            return new DetalleCotizacion()
            {
            };
        }
        private void ActualizarMonto()
        {
            decimal actualizarTotal = 0.00M;
            decimal cantidad = 0.00m;

            foreach (DataGridViewRow fila in DgvVale.Rows)
            {
                if (fila.Cells[4].Value != null)

                    cantidad = cantidad + (decimal)fila.Cells[4].Value;
            }


            lbtotal1.Text = cantidad.ToString();

        }
        private Cotizacion GetModelCotizacion()
        {
            return new Cotizacion()
            {
                Id = Guid.NewGuid(),
                FechaRecepcion=dtpinicio.Value,
                FechaLimite=dtpfin.Value,
                SucursalId = UsuarioLogeadoSistemas.User.SucursalId,
                NombreVendedor = UsuarioLogeadoSistemas.User.Name,
                NoCotizacion=lbnoVale.Text,
                Nombre=comboClientes.Text,
                
            };
        }
        private void GuardarCotizacion(int idcliente)
        {

            if (DgvVale.RowCount == 0) { KryptonMessageBox.Show("Debe tener un producto para Facturar"); return; }
            var detallePedido = GetDetalleCotizacion();
            var encabezadopedido = GetModelCotizacion();

            if (!ModelState.IsValid(detallePedido)) { return; }
            if (!ModelState.IsValid(encabezadopedido)) { return; }
            encabezadopedido.ClienteId = idcliente;
            encabezadopedido.NoCotizacion = lbnoVale.Text;

           
            _cotizacionRepository.AddEncabezado(encabezadopedido);
            foreach (var item in listaDetallesCotizacion)
            {
                if (item.ProductoId != 0)
                {
                    var detalle = new DetalleCotizacion()
                    {
                        Id = Guid.NewGuid(),
                        ProductoId = item.ProductoId,
                        CotizacionId=encabezadopedido.Id,

                        

                        //ComboId = item.ComboId,
                    };
                    _cotizacionRepository.AddDetalles(detalle);

                }
                else
                {
                    var detalle = new DetalleCotizacion()
                    {
                        Id = Guid.NewGuid(),
                        // ProductoId = item.ProductoId,
                        CotizacionId = encabezadopedido.Id,
                        ComboId = item.ComboId, //analizar
                    };
                    _cotizacionRepository.AddDetalles(detalle);
                }
            }

        }
        private void LimpiarSeleccionPromoCotizacion()
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
        private void LimpiarSeleccionCotiCombo()
        {
            foreach (ListarCombos prod in _listarCombos)
            {
                prod.Acciones = false;
            }
            BindingSource source = new BindingSource
            {
                DataSource = _listarCombos
            };
            DgvCombos.DataSource = typeof(List<>);
            DgvCombos.DataSource = source;
            DgvCombos.ClearSelection();


        }
        public void RefrescarDataGridCombos(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _cotizacionRepository = null;
                _cotizacionRepository = new CotizacionRepository(_context);
            }

            BindingSource source = new BindingSource();
            _listarcotiz = _cotizacionRepository.GetListGenerales(0);
            source.DataSource = _listarcotiz;
            DgvListCotizaciones.DataSource = typeof(List<>);
            DgvListCotizaciones.DataSource = source;
            DgvListCotizaciones.AutoResizeColumns();
            //DgvListPromociones.Columns[0].Visible = false;
        }
        private void LimpiarContenido()
        {
          
            txtestado.Text = "";
            DgvVale.Rows.Clear();
          
           
        }
       
        private void BtnGuardarC_Click(object sender, EventArgs e)
        {

            GuardarCotizacion(int.Parse(comboClientes.SelectedValue.ToString()));
            LimpiarSeleccionPromoCotizacion();
            LimpiarSeleccionCotiCombo();
            RefrescarDataGridCombos();
            LimpiarContenido();

        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string txt1 = txtbuscarproducto.Text;
                String txt2 = txtbuscarproducto.Text.ToUpper();
                var filter = _listadoproductos.Where(a => a.Descripcion.Contains(txt1) || a.Descripcion.Contains(txt2));

                DgvProductos.DataSource = filter.ToList();
                DgvProductos.ClearSelection();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("BuscarProductos() ha fallado! " + ex.Message);
            }
        }

        private void txtbuscarcombo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string txt1 = txtbuscarcombo.Text;
                String txt2 = txtbuscarcombo.Text.ToUpper();
                var filter = _listarCombos.Where(a => a.Descripcion.Contains(txt1) || a.Descripcion.Contains(txt2));

                DgvCombos.DataSource = filter.ToList();
                DgvCombos.ClearSelection();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("BuscarProductos() ha fallado! " + ex.Message);
            }
        }

        private void DgvListCotizaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvVale_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ActualizarMonto();
        }

        private void DgvVale_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            ActualizarMonto();
        }

        private void DgvVale_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            ActualizarMonto();
        }

        private void DgvVale_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var filaActual = (ListarDetalleCotiz)DgvVale.CurrentRow.DataBoundItem;
            filaActual.Total = filaActual.Precio * filaActual.Cantidad;
            ActualizarMonto();

        }

       
    }
}
