using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Precios;
using CapaDatos.Models.Productos;
using CapaDatos.Repository;
using CapaDatos.Repository.PreciosRepository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_producto
{
    public partial class ModuloProducto : BaseContext
    {
        #region REPOS
        private readonly TallasyColoresRepository _tallasyColoresRepository = null;
        private readonly TiposClienteRepository _tiposClienteRepository = null;
        private readonly ProveedoresRepository _proveedoresRepository = null;
        private readonly TipoPrecioRepository _tipoPrecioRepository = null;
        private readonly TallasRepository _tallasRepository = null;
        private readonly ColoresRepository _colorRepository = null;
        private ProductosRepository _productosRepository = null;
        #endregion REPOS

        #region LISTAS
        public List<DetalleColor> _listacolores = new List<DetalleColor>();
        public List<DetalleColor> _listacoloresProd = new List<DetalleColor>();
        public List<DetalleColor> _listacoloresDel = new List<DetalleColor>();
        public List<DetalleTalla> _listaTallas = new List<DetalleTalla>();
        public List<DetalleTalla> _listaTallasProd = new List<DetalleTalla>();
        public List<DetalleTalla> _listaTallasDel = new List<DetalleTalla>();
        public List<DetalleColorTalla> _listaColorTallas = new List<DetalleColorTalla>();
        public List<DetalleColorTalla> _listaColorTallasDel = new List<DetalleColorTalla>();
        public List<ListarDetallePrecios> _listaDetallePrecios = new List<ListarDetallePrecios>();
        private List<ListarProductos> ListadoProductos = null;
        #endregion LISTAS

        #region VARIABLES
        public ListarDetallePrecios precio = null;
        public Producto Producto = new Producto();
        public int stockToValidar = 0;
        public int _idProducto = 0;
        public int ingreso;
        public int DetalleProd;
        byte[] filefoto = null;
        private bool MostrarMenu = true;
        private bool MostrarFormsDetalle = false;
        private bool ProductoNuevo = true;
        public bool TieneEscalas = false;
        double cantidadSemanas = 0;
        readonly string validaGuid = "00000000-0000-0000-0000-000000000000";
        #endregion VARIABLES

        #region FORMULARIO
        public ModuloProducto()
        {
            _tallasyColoresRepository = new TallasyColoresRepository(_context);
            _tiposClienteRepository = new TiposClienteRepository(_context);
            _proveedoresRepository = new ProveedoresRepository(_context);
            _tipoPrecioRepository = new TipoPrecioRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            _tallasRepository = new TallasRepository(_context);
            _colorRepository = new ColoresRepository(_context);
            InitializeComponent();
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

        private void ModuloProducto_Load(object sender, EventArgs e)
        {
            RefrescarDataGridProductos();
            CargarCategorias();
            Cargarproveedores();
            CargarComboClientes();
            CargarEscala();
        }

        private void ModuloProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MostrarMenu)
                MenuPrincipal(this, false);
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
            ListadoProductos = _productosRepository.GetList(UsuarioLogeadoSistemas.User.SucursalId).ToList();
            source.DataSource = ListadoProductos;
            DgvListProductos.DataSource = typeof(List<>);
            DgvListProductos.DataSource = source;
            DgvListProductos.ClearSelection();
        }

        private void CargarComboClientes()
        {
            var tiposClientes = _tiposClienteRepository.GettiposCliente();
            CbTiposClientes.DataSource = tiposClientes.Where(x => x.Estado == "Activa").ToList();
            CbTiposClientes.DisplayMember = "TipoCliente";
            CbTiposClientes.ValueMember = "Id";
            CbTiposClientes.SelectedIndex = 0;
            CbTiposClientes.Invalidate();

            tiposClientes.Add(new ListaDeTiposCliente { Id = 0, TipoCliente = "Todos", Estado = "Activa" });
            var c = tiposClientes.OrderBy(a => a.Id).ToList();
            CbClientesTipos.ComboBox.DataSource = c.Where(x => x.Estado == "Activa").ToList();
            CbClientesTipos.ComboBox.DisplayMember = "TipoCliente";
            CbClientesTipos.ComboBox.ValueMember = "Id";
            CbClientesTipos.ComboBox.SelectedIndex = 0;
            CbClientesTipos.ComboBox.Invalidate();
        }

        private void CargarEscala()
        {
            CbEscala.Items.Insert(0, "E1");
            CbEscala.Items.Insert(1, "E2");
            CbEscala.Items.Insert(2, "E3");
            CbEscala.Items.Insert(3, "E4");
            CbEscala.SelectedIndex = 0;
        }

        public void CargarCategorias()
        {
            categoriaprod.DataSource = _productosRepository.GetCategoriasList();
            categoriaprod.DisplayMember = "Nombre";
            categoriaprod.ValueMember = "Id";
            categoriaprod.Invalidate();
        }

        private void Cargarproveedores()
        {
            try
            {
                cbproveedor.DataSource = _proveedoresRepository.GetList();
                cbproveedor.DisplayMember = "Nombre";
                cbproveedor.ValueMember = "Id";
                cbproveedor.Invalidate();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("no hay ningun proveedor,deberá ingresar uno", ex.Message);
            }
        }
        #endregion FORMULARIO

        #region LISTADO        

        private void BuscarProductos()
        {
            try
            {
                string txt1 = TxtBuscador.Text;
                String txt2 = TxtBuscador.Text.ToUpper();
                var filter = ListadoProductos.Where(a => a.Descripcion.Contains(txt1) || a.Descripcion.Contains(txt2));

                DgvListProductos.DataSource = filter.ToList();
                DgvListProductos.ClearSelection();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("BuscarProductos() ha fallado! " + ex.Message);
            }
        }

        private void TxtBuscador_TextChanged(object sender, EventArgs e)
        {
            BuscarProductos();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            ProductoNuevo = true;
            PageGestion.Visible = true;
            NavProductos.SelectedPage = PageGestion;
            LbFechaIng.Visible = false;
            LbFechaIngreso.Visible = false;
            MostrarFormsDetalle = true;
            TxtBuscador.Text = "";
            LimpiarContenido();
            LimpiarVariables();
        }

        private void BtnDetalle_Click(object sender, EventArgs e)
        {
            if (DgvListProductos.CurrentRow != null)
            {
                ProductoNuevo = false;
                var fila = DgvListProductos.CurrentRow;
                ListarProductos lista = (ListarProductos)fila.DataBoundItem;
                PageGestion.Visible = true;
                NavProductos.SelectedPage = PageGestion;
                LbFechaIng.Visible = true;
                LbFechaIngreso.Visible = true;
                Producto = _productosRepository.Get(lista.Id);
                MostrarFormsDetalle = false;
                CargarTextBox();
                TxtBuscador.Text = "";
            }
            else
            {
                KryptonMessageBox.Show("No ha seleccionado ninguna fila del listado.", "Notificación");
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            RefrescarDataGridProductos(true);
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (DgvListProductos.CurrentRow == null)
            {
                return;
            }

            var dialog = KryptonMessageBox.Show("¿Está seguro que desea eliminar el producto de la lista?", "Eliminar producto",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);

            if (dialog == DialogResult.Yes)
            {
                var productolista = (ListarProductos)DgvListProductos.CurrentRow.DataBoundItem;
                var productoObtenido = _productosRepository.Get(productolista.Id);
                productoObtenido.Deleted = true;
                _productosRepository.Update(productoObtenido);
                RefrescarDataGridProductos(true);
            }
        }
        #endregion LISTADO

        #region GESTION

        #region GESTION - CARGA DATA
        private void CargarTextBox()
        {
            try
            {
                LbFechaIngreso.Text = Producto.FechaIngreso.ToString();
                nomproductotxt.Text = Producto.Descripcion;
                if (Producto.CategoriaId > 0)
                {
                    categoriaprod.SelectedValue = Producto.CategoriaId;
                }
                if (Producto.ProveedorId > 0)
                {
                    cbproveedor.SelectedValue = Producto.ProveedorId;
                }
                txtdescripcorta.Text = Producto.DescripcionCorta;
                ubicaciontxt.Text = Producto.Ubicacion;
                TxtCoste.Text = Producto.Coste.ToString();
                TxtPrecioVenta.Text = Producto.PrecioVenta.ToString();
                TxtLimiteDesc.Text = Producto.DescuentoEspecial.ToString();
                TxtStockProducto.Text = Producto.Stock.ToString();
                stockToValidar = Producto.Stock;
                if (Producto.Imagen != null)
                {
                    filefoto = Producto.Imagen;
                    MemoryStream mStream = new MemoryStream(filefoto);
                    pBox.Image = Image.FromStream(mStream);
                    pBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                codigoreferencia.Text = Producto.CodigoBarras;
                if (Producto.TieneColor && Producto.TieneTalla)
                {
                    DetalleProd = 3;
                    RbColorTalla.Checked = true;
                    TraerTallayColor(Producto.Id);
                }
                else if (!Producto.TieneColor && Producto.TieneTalla)
                {
                    DetalleProd = 2;
                    RbTalla.Checked = true;
                    TraerTalla(Producto.Id);
                }
                else if (Producto.TieneColor && !Producto.TieneTalla)
                {
                    DetalleProd = 1;
                    RbColor.Checked = true;
                    TraerColor(Producto.Id);
                }
                txtmarca.Text = Producto.Marca;
                txtnumeral.Text = Producto.Numeral;
                txtunidadmedida.Text = Producto.UnidadMedida;
                notasinternas.Text = Producto.Notas;
                CheckExistencia.Checked = Producto.StockControl;
                TxtCantidadmin.Text = Producto.stockMinimo.ToString();
                CheckEscalaPrecio.Checked = Producto.TieneEscalas;
                txtprecioVar.Text = Producto.PrecioVenta.ToString();
                txtpreciomayorista.Text = Producto.PrecioMayorista.ToString();
                txtpreciocuentaclave.Text = Producto.PrecioCuentaClave.ToString();
                txtpreciocuentaclave.Text = Producto.PrecioEntidadGubernamental.ToString();
                txtpreciorevendedor.Text = Producto.PrecioRevendedor.ToString();
                TxtLimiteDesc.Text = Producto.DescuentoEspecial.ToString();
                TraerEscalasPrecios(Producto.Id);
                MostrarTiempo(Producto.PeriodoMovimiento);
                MostrarFormsDetalle = true;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }

        public void TraerColor(int Id)
        {
            if (_colorRepository.GetColor(Id) != null)
            {
                var productodetalleColor = _colorRepository.GetProductoListaColor(Id);
                TxtStockProducto.Text = productodetalleColor.Sum(x => x.Stock).ToString();
                _listacolores = productodetalleColor;
            }
        }

        public void TraerTalla(int Id)
        {
            if (_tallasRepository.GetTallaListaProducto(Id) != null)
            {
                var productodetalleTalla = _tallasRepository.GetTallaListaProducto(Id);
                TxtStockProducto.Text = productodetalleTalla.Sum(x => x.Stock).ToString();
                _listaTallas = productodetalleTalla;
            }
        }

        public void TraerTallayColor(int Id)
        {
            if (_tallasyColoresRepository.GetTallaColorListaProducto(Id) != null)
            {
                var listatallaycolorbyproduc = _tallasyColoresRepository.GetTallaColorListaProducto(Id);
                TxtStockProducto.Text = listatallaycolorbyproduc.Sum(x => x.Stock).ToString();
                _listaColorTallas = listatallaycolorbyproduc;
            }
        }

        private void TraerEscalasPrecios(int ProductoId)
        {
            Producto prod = _productosRepository.Get(ProductoId);

            if (prod.TieneEscalas)
            {
                var tipo = _tipoPrecioRepository.Get(ProductoId);
                if (tipo != null)
                {
                    _listaDetallePrecios = _tipoPrecioRepository.GetDetallePrecioListar(tipo.Id, 0);
                    CargarDataGridPrecios(_listaDetallePrecios);
                }
            }
        }

        private void MostrarTiempo(string value)
        {
            if (value != null)
            {
                int cantidad = Convert.ToInt32(value);
                switch (cantidad)
                {
                    case 0:
                        CheckMovimiento.Checked = false;
                        ResetCheckMovimiento();
                        break;
                    case 4:
                        CheckMovimiento.Checked = true;
                        RbCuatro.Checked = true;
                        break;
                    case 8:
                        CheckMovimiento.Checked = true;
                        RbOcho.Checked = true;
                        break;
                    default:
                        CheckMovimiento.Checked = true;
                        RbPersonal.Checked = true;
                        dtpfechainicio.Value = DateTime.Now;
                        dtpfechafinal.Value = DateTime.Now.AddDays(cantidad * 7);
                        break;
                }
            }
            else
            {
                CheckMovimiento.Checked = false;
                ResetCheckMovimiento();
            }
        }

        public Producto GetviewModel(Producto product)
        {
            Producto.Descripcion = nomproductotxt.Text;
            Producto.CategoriaId = Convert.ToInt32(categoriaprod.SelectedValue.ToString());
            Producto.ProveedorId = Convert.ToInt32(cbproveedor.SelectedValue.ToString());
            Producto.PermitirVenta = true;
            Producto.PermitirCompra = true;
            Producto.StockControl = true;
            Producto.Ubicacion = ubicaciontxt.Text;
            Producto.CodigoBarras = codigoreferencia.Text;
            Producto.DescripcionCorta = txtdescripcorta.Text;
            Producto.Impuesto = 0.12M;
            Producto.Coste = Convert.ToDecimal(TxtCoste.Text);
            Producto.TieneEscalas = CheckEscalaPrecio.Checked;
            Producto.Stock = Convert.ToInt32(TxtStockProducto.Text);
            Producto.Notas = notasinternas.Text;
            Producto.FechaIngreso = DateTime.Now;
            Producto.FechaModificacion = DateTime.Now;
            Producto.SucursalId = UsuarioLogeadoSistemas.User.SucursalId;
            Producto.stockMinimo = int.Parse(TxtCantidadmin.Text);
            Producto.PeriodoMovimiento = cantidadSemanas.ToString("0");
            Producto.Imagen = filefoto;
            Producto.UnidadMedida = txtunidadmedida.Text;
            Producto.Marca = txtmarca.Text;
            Producto.Numeral = txtnumeral.Text;
            Producto.StockControl = CheckExistencia.Checked;
            Producto.stockMinimo = Convert.ToInt32(TxtCantidadmin.Text);
            Producto.PeriodoMovimiento = cantidadSemanas.ToString();
            Producto.PrecioVenta = Convert.ToDecimal(TxtPrecioVenta.Text);
            Producto.Utilidad = Convert.ToDecimal(TxtPrecioVenta.Text) - Convert.ToDecimal(TxtCoste.Text);
            Producto.PrecioVenta = Convert.ToDecimal(TxtPrecioVenta.Text);
            Producto.PrecioMayorista = Convert.ToDecimal(txtpreciomayorista.Text);
            Producto.PrecioCuentaClave = Convert.ToDecimal(txtpreciocuentaclave.Text);
            Producto.PrecioEntidadGubernamental = Convert.ToDecimal(txtpreciogobierno.Text);
            Producto.PrecioRevendedor = Convert.ToDecimal(txtpreciorevendedor.Text);
            Producto.DescuentoEspecial = Convert.ToDecimal(TxtLimiteDesc.Text);
            return Producto;
        }

        private void BtnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog imagen = new OpenFileDialog();
            imagen.Filter = "Archivos JPG (*.jpg)|*.jpg| Archivos png(*.png)|*.png";
            DialogResult filestream = imagen.ShowDialog();

            if (filestream == DialogResult.OK)
            {
                pBox.Image = Image.FromFile(imagen.FileName);
                pBox.SizeMode = PictureBoxSizeMode.StretchImage;
                FilestreamImagen();
            }
        }

        private void FilestreamImagen()
        {
            filefoto = null;
            MemoryStream memoryStream = new MemoryStream();
            pBox.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            memoryStream.GetBuffer();
            filefoto = memoryStream.GetBuffer();
        }

        private void TxtCantidadInt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtStockProducto_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtStockProducto.Text))
            {
                stockToValidar = int.Parse(TxtStockProducto.Text);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = ValidarNullos();
                if (mensaje.Length == 0)
                {
                    GuardarProducto();
                }
                else
                {
                    KryptonMessageBox.Show(mensaje, "Notificacion");
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "ERROR");
                return;
            }

        }

        private string ValidarNullos()
        {
            string msj = "";
            if (categoriaprod.SelectedValue == null)
            {
                msj = "Debe seleccionar una categoria";
            }
            else
            if (cbproveedor.SelectedValue == null)
            {
                msj = "Debe seleccionar un proveedor";
            }
            else
            if (string.IsNullOrEmpty(codigoreferencia.Text))
            {
                msj = "Debe ingresar un codigo de referencia";
            }
            if (!TieneEscalas)
            {
                if (!string.IsNullOrEmpty(TxtPrecioVenta.Text))
                {
                    decimal compara = 0.00m;
                    decimal preciov = Convert.ToDecimal(TxtPrecioVenta.Text);

                    if (preciov <= compara)
                    {
                        msj = "Debe ingresar un precio de venta valido";
                    }
                }
            }
            return msj;
        }

        private void GuardarProducto()
        {
            try
            {
                CalcularTiempo();
                GetviewModel(Producto);
                if (ModelState.IsValid(Producto))
                {
                    if (ProductoNuevo)
                    {
                        _productosRepository.Add(Producto);
                        Producto = _productosRepository.GetProductByBarCode(codigoreferencia.Text, UsuarioLogeadoSistemas.User.SucursalId);
                    }
                    else
                    {
                        _productosRepository.Update(Producto);
                        NavProductos.SelectedPage = PageGestion;
                        PageGestion.Visible = false;
                    }
                    GuardarPrecios(Producto);
                    GuardarDetalles(Producto.Id);
                    LimpiarContenido();
                    LimpiarVariables();
                    RefrescarDataGridProductos();
                    KryptonMessageBox.Show("¡Datos guardados éxitosamente!", "Confirmación");
                }
                else
                {
                    KryptonMessageBox.Show("Modelo de Producto inválido", "Advertencia");
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Valide los campos ingresados, no se aceptan nullos.\n" + ex.Message, "ERROR");
                return;
            }
        }

        public void CalcularTiempo()
        {
            if (RbCuatro.Checked)
            {
                cantidadSemanas = 4;
            }
            if (RbOcho.Checked)
            {
                cantidadSemanas = 8;
            }
            if (RbPersonal.Checked)
            {
                cantidadSemanas = (dtpfechafinal.Value - dtpfechainicio.Value).TotalDays / 7;
            }
        }

        #endregion GESTION - CARGA DATA

        #region GESTION - ALERTAS

        private void CheckExistencia_CheckedChanged(object sender, EventArgs e)
        {
            AlertaStock(CheckExistencia.Checked);
        }

        private void CheckMovimiento_CheckedChanged(object sender, EventArgs e)
        {
            VerMovimiento(CheckMovimiento.Checked);
            if (!CheckMovimiento.Checked)
            {
                VerTiempos(false);
                ResetCheckMovimiento();
            }
        }

        private void RbPersonal_CheckedChanged(object sender, EventArgs e)
        {
            VerTiempos(RbPersonal.Checked);
        }

        private void RbOcho_CheckedChanged(object sender, EventArgs e)
        {
            if (RbOcho.Checked)
                VerTiempos(false);
        }

        private void RbCuatro_CheckedChanged(object sender, EventArgs e)
        {
            if (RbCuatro.Checked)
                VerTiempos(false);
        }

        private void AlertaStock(bool mostrar)
        {
            Lbcantidadmin.Visible = mostrar;
            TxtCantidadmin.Visible = mostrar;
        }

        private void VerTiempos(bool mostrar)
        {
            PnlFechas.Visible = mostrar;
        }

        private void VerMovimiento(bool mostrar)
        {
            RbCuatro.Visible = mostrar;
            RbOcho.Visible = mostrar;
            RbPersonal.Visible = mostrar;
        }

        private void ResetCheckMovimiento()
        {
            RbCuatro.Checked = false;
            RbOcho.Checked = false;
            RbPersonal.Checked = false;
        }

        #endregion GESTION - ALERTAS    

        #region GESTION - COLORES/TALLAS

        private void ResetCheckDetalle()
        {
            RbColor.Checked = false;
            RbTalla.Checked = false;
            RbColorTalla.Checked = false;
        }

        private void RbColor_Click(object sender, EventArgs e)
        {
            RbColor_CheckedChanged(null, null);
        }

        private void RbTalla_Click(object sender, EventArgs e)
        {
            RbTalla_CheckedChanged(null, null);
        }

        private void RbColorTalla_Click(object sender, EventArgs e)
        {
            RbColorTalla_CheckedChanged(null, null);
        }

        private void RbColor_CheckedChanged(object sender, EventArgs e)
        {
            if (ValidarListadosDetalle())
            {
                if (RbColor.Checked)
                    ColorProperties();
                else
                    OcultarForm();
            }            
        }

        private void RbTalla_CheckedChanged(object sender, EventArgs e)
        {
            if (ValidarListadosDetalle())
            {
                if (RbTalla.Checked)
                    TallaProperties();
                else
                    OcultarForm();
            }
        }

        private void RbColorTalla_CheckedChanged(object sender, EventArgs e)
        {
            if (ValidarListadosDetalle())
            {
                if (RbColorTalla.Checked)
                    ColorTallaProperties();
                else
                    OcultarForm();
            }            
        }

        private void ColorProperties()
        {
            if (StockDetalle(RbColor))
            {
                if (RbColor.Checked == true)
                {
                    if (MostrarFormsDetalle)
                    {
                        if (Application.OpenForms["AgregarColor"] == null)
                        {
                            AgregarColor agregarColor = new AgregarColor(this, _listacolores);
                            agregarColor.Show();
                        }
                        else
                        {
                            Application.OpenForms["AgregarColor"].Activate();
                        }
                    }                    
                }
                else
                {
                    _listacolores.Clear();
                }
            }            
        }

        private void TallaProperties()
        {
            if (StockDetalle(RbTalla))
            {
                if (RbTalla.Checked == true)
                {
                    if (MostrarFormsDetalle)
                    {
                        if (Application.OpenForms["AgregarTalla"] == null)
                        {
                            AgregarTalla agregarTalla = new AgregarTalla(this, _listaTallas);
                            agregarTalla.Show();
                        }
                        else
                        {
                            Application.OpenForms["AgregarTalla"].Activate();
                        }
                    }                    
                }
                else
                {
                    _listacolores.Clear();
                }
            }
        }

        private void ColorTallaProperties()
        {
            if (StockDetalle(RbColorTalla))
            {
                if (RbColorTalla.Checked == true)
                {
                    if (MostrarFormsDetalle)
                    {
                        if (Application.OpenForms["AgregarColorTalla"] == null)
                        {
                            AgregarColorTalla agregarColorTalla = new AgregarColorTalla(this, _listaColorTallas);
                            agregarColorTalla.Show();
                        }
                        else
                        {
                            Application.OpenForms["AgregarColorTalla"].Activate();
                        }
                    }                    
                }
                else
                {
                    _listacolores.Clear();
                }
            }
        }

        private bool StockDetalle(KryptonRadioButton radioButton)
        {
            bool validacion = true;
            if (string.IsNullOrEmpty(TxtStockProducto.Text) || int.Parse(TxtStockProducto.Text) <= 0)
            {
                if (ingreso == 0)
                {
                    KryptonMessageBox.Show("Por favor ingrese el stock, antes de continuar..");
                    radioButton.Checked = false;
                    validacion = false;
                    ingreso += 1;
                }
                radioButton.Checked = false;
            }
            ingreso = 0;
            return validacion;
        }

        private void OcultarForm()
        {
            AgregarColor formColor = null;
            AgregarTalla formTalla = null;
            AgregarColorTalla formColorTalla = null;


            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(AgregarColor))
                {
                    formColor = (AgregarColor)frm;
                }
                if (frm.GetType() == typeof(AgregarTalla))
                {
                    formTalla = (AgregarTalla)frm;
                }
                if (frm.GetType() == typeof(AgregarColorTalla))
                {
                    formColorTalla = (AgregarColorTalla)frm;
                }
            }

            if (formColor != null)
            {
                formColor.Close();
            }
            if (formTalla != null)
            {
                formTalla.Close();
            }
            if (formColorTalla != null)
            {
                formColorTalla.Close();
            }
        }

        private bool ValidarListadosDetalle()
        {
            bool validacion = true;
            var dtallacolortmp = _tallasyColoresRepository.GetTallaColorListaProducto(Producto.Id);
            var dtallastmp = _tallasRepository.GetTallaListaProducto(Producto.Id);
            var dcolortmp = _listacolores = _colorRepository.GetProductoListaColor(Producto.Id);

            //validacion para eliminar la informacion de color 
            if (dcolortmp.Count > 0 && DetalleProd != 1)
            {
                DialogResult dialogResult = KryptonMessageBox.Show("Se ha encontrado un listado en Color, si continua con el proceso se eliminará.\n¿Desea Continuar?", "Advertencia", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _listacoloresDel = dcolortmp;
                    EliminarColores();
                    validacion = true;
                }
                else if (dialogResult == DialogResult.No)
                {
                    validacion = false;
                }
            }

            //validacion para eliminar la informacion de talla
            if (dtallastmp.Count > 0 && DetalleProd != 2)
            {
                DialogResult dialogResult = KryptonMessageBox.Show("Se ha encontrado un listado en Talla, si continua con el proceso se eliminará.\n¿Desea Continuar?", "Advertencia", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _listaTallasDel = dtallastmp;
                    EliminarTallas();
                    validacion = true;
                }
                else if (dialogResult == DialogResult.No)
                {
                    validacion = false;
                }
            }
            return validacion;

            //validacion para eliminar la informacion de talla/color 
            if (dtallacolortmp.Count > 0 && DetalleProd != 3)
            {
                DialogResult dialogResult = KryptonMessageBox.Show("Se ha encontrado un listado en Talla y Color, si continua con el proceso se eliminará.\n¿Desea Continuar?", "Advertencia", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _listaColorTallasDel = dtallacolortmp;
                    EliminarColoresTallas();
                    validacion = true;
                }
                else if (dialogResult == DialogResult.No)
                {
                    validacion = false;
                }
            }
        }

        private void GuardarDetalles(int ProductoId)
        {
            switch (DetalleProd)
            {
                case 1:
                    GuardarColores(ProductoId);
                    break;
                case 2:
                    GuardarTallas(ProductoId);
                    break;
                case 3:
                    GuardarColoresTallas(ProductoId);
                    break;
            }
        }

        public void GuardarColores(int ProductoId)
        {
            if (_listacoloresProd.Count > 0)
            {
                foreach (DetalleColor dc in _listacoloresProd)
                {
                    if (ModelState.IsValid(dc))
                    {
                        var detalleColor = _colorRepository.GetDetalleColor(dc.Id);
                        if (detalleColor != null)
                        {
                            detalleColor.Stock = dc.Stock;
                            _colorRepository.Update(detalleColor);
                        }
                        else
                        {
                            dc.ProductoId = ProductoId;
                            _colorRepository.Add(dc);
                        }
                    }
                }
            }
            EliminarColores();
        }

        public void GuardarTallas(int ProductoId)
        {
            if (_listaTallasProd.Count > 0)
            {
                foreach (DetalleTalla dt in _listaTallasProd)
                {
                    if (ModelState.IsValid(dt))
                    {
                        var detalleTalla = _tallasRepository.GetDetalleTalla(dt.Id);
                        if (detalleTalla != null)
                        {
                            detalleTalla.Stock = dt.Stock;
                            _tallasRepository.Update(detalleTalla);
                        }
                        else
                        {
                            dt.ProductoId = ProductoId;
                            _tallasRepository.Add(dt);
                        }
                    }
                }
            }
            EliminarTallas();
        }

        public void GuardarColoresTallas(int ProductoId)
        {

            if (_listaColorTallas.Count > 0)
            {
                foreach (DetalleColorTalla dct in _listaColorTallas)
                {
                    if (ModelState.IsValid(dct))
                    {
                        var detalleColorTalla = _tallasyColoresRepository.GetColorTalla(dct.Id);
                        if (detalleColorTalla != null)
                        {
                            detalleColorTalla.Stock = dct.Stock;
                            _tallasyColoresRepository.Update(detalleColorTalla);
                        }
                        else
                        {
                            dct.ProductoId = ProductoId;
                            _tallasyColoresRepository.Add(dct);
                        }
                    }
                }
            }
            EliminarColoresTallas();
        }

        private void EliminarColores()
        {
            if (_listacoloresDel.Count > 0)
            {
                foreach (DetalleColor dc in _listacoloresDel)
                {
                    if (!ModelState.IsValid(dc)) return;
                    _colorRepository.DeleteDetalleColor(dc);
                }
            }
        }

        private void EliminarTallas()
        {
            if (_listaTallasDel.Count > 0)
            {
                foreach (DetalleTalla dt in _listaTallasDel)
                {
                    if (!ModelState.IsValid(dt)) return;
                    _tallasRepository.DeleteDetalleTalla(dt);
                }
            }
        }

        private void EliminarColoresTallas()
        {
            if (_listaColorTallasDel.Count > 0)
            {
                foreach (DetalleColorTalla dt in _listaColorTallasDel)
                {
                    if (!ModelState.IsValid(dt)) return;
                    _tallasyColoresRepository.DeleteDetalleTallaColor(dt);
                }
            }
        }

        #endregion GESTION COLOR/TALLA

        #region GESTION - PRECIOS

        private void CheckEscalaPrecio_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckEscalaPrecio.Checked)
                MostrarPrecios(true, false);
            else
                MostrarPrecios(false, true);
        }

        public void MostrarPrecios(bool Escala, bool Precios)
        {
            groupEscala.Enabled = Escala;
            TblEscalasPrecio.Enabled = Escala;
            txtpreciocuentaclave.Enabled = Precios;
            txtpreciogobierno.Enabled = Precios;
            txtpreciorevendedor.Enabled = Precios;
            txtpreciomayorista.Enabled = Precios;
        }

        private void CbEscala_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbEscala.SelectedIndex == 0)
            {
                txtRangoInic.Text = "1";
                txtRangoFinal.Text = "12";
            }
            if (CbEscala.SelectedIndex == 1)
            {
                txtRangoInic.Text = "13";
                txtRangoFinal.Text = "24";
            }
            if (CbEscala.SelectedIndex == 2)
            {
                txtRangoInic.Text = "25";
                txtRangoFinal.Text = "36";
            }
            if (CbEscala.SelectedIndex == 3)
            {
                txtRangoInic.Text = "37";
                txtRangoFinal.Text = "48";
            }
        }

        private void BtnAddPrecio_Click(object sender, EventArgs e)
        {
            if (precio == null)
            {
                ListarDetallePrecios detallePrecios = GetModel();
                if (!ComprobarEscala(detallePrecios))
                {
                    _listaDetallePrecios.Add(detallePrecios);
                    CargarDataGridPrecios(_listaDetallePrecios);
                }
                else
                {
                    KryptonMessageBox.Show("¡Escala ya ingresada!", "Notificación");
                }
            }
            else
            {
                int index = _listaDetallePrecios.IndexOf(precio);
                ListarDetallePrecios detallePrecios = _listaDetallePrecios.ElementAt(index);
                detallePrecios.RangoInicio = Convert.ToInt32(txtRangoInic.Text);
                detallePrecios.RangoFinal = Convert.ToInt32(txtRangoFinal.Text);
                detallePrecios.Precio = Convert.ToDecimal(txtprecioVar.Text);
                CargarDataGridPrecios(_listaDetallePrecios);
                precio = new ListarDetallePrecios();
            }
            txtprecioVar.Text = "0.00";
            txtRangoInic.Text = "";
            txtRangoFinal.Text = "";
        }

        private ListarDetallePrecios GetModel()
        {
            return new ListarDetallePrecios
            {
                Tipos = CbTiposClientes.Text,
                TiposId = Convert.ToInt32(CbTiposClientes.SelectedValue),
                Escala = CbEscala.Text,
                Precio = Convert.ToDecimal(txtprecioVar.Text),
                RangoInicio = Convert.ToInt32(txtRangoInic.Text),
                RangoFinal = Convert.ToInt32(txtRangoFinal.Text)
            };
        }

        public bool ComprobarEscala(ListarDetallePrecios detallePrecio)
        {
            foreach (DataGridViewRow row in DgvEscalasProducto.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    string escala = row.Cells[3].Value.ToString();
                    string tipos = row.Cells[2].Value.ToString();
                    if (escala == detallePrecio.Escala && tipos == detallePrecio.Tipos)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void CargarDataGridPrecios(List<ListarDetallePrecios> listaPrecios, int opc = 0)
        {
            BindingSource source = new BindingSource();
            if (opc > 0)
                source.DataSource = listaPrecios.Where(x => x.TiposId == opc);
            else
                source.DataSource = listaPrecios;
            DgvEscalasProducto.DataSource = typeof(List<>);
            DgvEscalasProducto.DataSource = source;
            DgvEscalasProducto.ClearSelection();
        }

        private void CbClientesTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = CbClientesTipos.ComboBox.SelectedValue.ToString();
            int opc = !int.TryParse(valor, out var _) ? 0 : Convert.ToInt32(valor);
            CargarDataGridPrecios(_listaDetallePrecios, opc);
        }

        private void BtnEditarP_Click(object sender, EventArgs e)
        {
            if (DgvEscalasProducto.CurrentRow != null)
            {
                var fila = DgvEscalasProducto.CurrentRow;
                precio = (ListarDetallePrecios)fila.DataBoundItem;
                txtprecioVar.Text = precio.Precio.ToString();
                CbTiposClientes.SelectedValue = precio.TiposId;
                CbEscala.Text = precio.Escala;
                txtRangoInic.Text = precio.RangoInicio.ToString();
                txtRangoFinal.Text = precio.RangoFinal.ToString();
            }
            else
            {
                KryptonMessageBox.Show("Seleccione una fila para continuar", "Advertencia");
            }
        }

        private void BtnEliminarP_Click(object sender, EventArgs e)
        {
            if (DgvEscalasProducto.CurrentRow != null)
            {
                var dialog = KryptonMessageBox.Show("¿Está seguro que desea eliminar la escala de la lista?", "Eliminar Escala",
              MessageBoxButtons.YesNoCancel,
              MessageBoxIcon.Question,
              MessageBoxDefaultButton.Button2);

                if (dialog == DialogResult.Yes)
                {
                    var fila = DgvEscalasProducto.CurrentRow;
                    ListarDetallePrecios detallePrecios = (ListarDetallePrecios)fila.DataBoundItem;
                    if (detallePrecios.Id.ToString() != validaGuid)
                    {
                        var precio = _tipoPrecioRepository.GetDetalle(detallePrecios.Id);
                        _tipoPrecioRepository.DeleteDetallePreciop(precio);
                    }
                    _listaDetallePrecios.Remove(detallePrecios);
                    CargarDataGridPrecios(_listaDetallePrecios);
                }
            }
            else
            {
                KryptonMessageBox.Show("Seleccione una fila para continuar", "Advertencia");
            }
        }

        private void GuardarPrecios(Producto product)
        {
            try
            {
                if (_listaDetallePrecios.Count > 0)
                {
                    List<DetallePrecio> listaDetalle = new List<DetallePrecio>();
                    TipoPrecio encabezadoTipoprecio = _tipoPrecioRepository.Get(product.Id);
                    if (encabezadoTipoprecio == null)
                    {
                        GuardarModelPrecio(product);
                        encabezadoTipoprecio = _tipoPrecioRepository.Get(product.Id);
                    }
                    if (!ModelState.IsValid(encabezadoTipoprecio)) return;

                    foreach (var item in _listaDetallePrecios)
                    {
                        DetallePrecio detallePrecio = new DetallePrecio();
                        detallePrecio.Id = item.Id;
                        detallePrecio.TipoPrecioId = item.TipoPrecioId;
                        detallePrecio.Escala = item.Escala;
                        detallePrecio.Precio = item.Precio;
                        detallePrecio.RangoInicio = item.RangoInicio;
                        detallePrecio.RangoFinal = item.RangoFinal;
                        detallePrecio.TiposId = item.TiposId;
                        detallePrecio.Tipos = _tiposClienteRepository.GetTipoName(item.Tipos);
                        listaDetalle.Add(detallePrecio);
                    }

                    foreach (var detailPrecio in listaDetalle)
                    {
                        var tmp = _tipoPrecioRepository.GetDetalle(detailPrecio.Id);

                        if (tmp != null)
                        {
                            tmp.RangoInicio = detailPrecio.RangoInicio;
                            tmp.RangoFinal = detailPrecio.RangoFinal;
                            tmp.Precio = detailPrecio.Precio;
                            _tipoPrecioRepository.UpdateDetallePrecio(tmp);
                        }
                        else
                        {
                            detailPrecio.Id = Guid.NewGuid();
                            detailPrecio.TipoPrecioId = encabezadoTipoprecio.Id;
                            _tipoPrecioRepository.AddDetallePrecio(detailPrecio);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Revise las escalas de precio y los valores ingresados", ex.Message);
            }
        }

        private void GuardarModelPrecio(Producto producto)
        {
            try
            {
                TipoPrecio encabezadoTipoprecio = new TipoPrecio()
                {
                    Id = Guid.NewGuid(),
                    FechaInicio = DateTime.Now,
                };
                if (ModelState.IsValid(encabezadoTipoprecio))
                {
                    encabezadoTipoprecio.ProductoId = producto.Id;
                    _tipoPrecioRepository.Add(encabezadoTipoprecio);
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("¡Ha ocurrido un error interno!" + ex.Message, "ERROR");
            }
        }

        #endregion GESTION -PRECIOS       

        #region GESTION - LIMPIAR

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarContenido();
            LimpiarVariables();
        }

        private void LimpiarContenido()
        {
            nomproductotxt.Text = "";
            CargarCategorias();
            Cargarproveedores();
            txtdescripcorta.Text = "";
            ubicaciontxt.Text = "";
            TxtCoste.Text = "0.00";
            TxtPrecioVenta.Text = "0.00";
            txtpreciocuentaclave.Text = "0.00";
            txtpreciogobierno.Text = "0.00";
            txtpreciorevendedor.Text = "0.00";
            txtpreciomayorista.Text = "0.00";
            TxtLimiteDesc.Text = "0.00";
            TxtStockProducto.Text = "0";
            TxtStockProducto.ReadOnly = false;
            TxtPrecioVenta.ReadOnly = false;
            pBox.Image = Sistema.Properties.Resources.anadir_imagen32;
            pBox.SizeMode = PictureBoxSizeMode.CenterImage;
            codigoreferencia.Text = "";
            txtmarca.Text = "";
            txtnumeral.Text = "";
            txtunidadmedida.Text = "";
            notasinternas.Text = "";
            CheckExistencia.Checked = false;
            CheckMovimiento.Checked = false;
            txtRangoFinal.Text = "";
            txtRangoInic.Text = "";
            txtprecioVar.Text = "0.00";
            CheckEscalaPrecio.Checked = false;
            LbFechaIng.Visible = false;
            LbFechaIngreso.Visible = false;
            ResetCheckDetalle();
        }

        private void LimpiarVariables()
        {
            _listacolores.Clear();
            _listacoloresProd.Clear();
            _listacoloresDel.Clear();
            _listaTallas.Clear();
            _listaTallasProd.Clear();
            _listaTallasDel.Clear();
            _listaColorTallas.Clear();
            _listaColorTallasDel.Clear();
            _listaDetallePrecios.Clear();
            CargarDataGridPrecios(_listaDetallePrecios);
            precio = null;
            Producto = new Producto();
            stockToValidar = 0;
            _idProducto = 0;
            ingreso = 0;
            DetalleProd = 0;
            filefoto = null;
            TieneEscalas = false;
            cantidadSemanas = 0;
        }

        #endregion GESTION - LIMPIAR

        #endregion

        private void toolProductos_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cbproveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
