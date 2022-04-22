using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Productos.Combos;
using CapaDatos.Repository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models;
using Sistema.Forms.modulo_producto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_combos
{
    public partial class ModuloCombos : BaseContext
    {
        #region REPOS
        private TallasyColoresRepository _tallascoloresRepository = null; 
        private ProductosRepository _productosRepository = null;
        private ColoresRepository _coloresRepository = null;
        private TallasRepository _tallasRepository = null;
        private CombosRepository _combosRepository = null;
        private IList<ListarCombos> combos = null;
        #endregion REPOS

        #region LISTAS
        private List<ListarProductos> _listadoproductos;
        private List<ComboDetalleLista> listaDetallesDel;
        private List<ComboDetalleLista> listaDetalles;
        #endregion LISTAS

        #region VARIABLES
        private ListarCombos Combo;
        private bool MostrarMenu = true;
        private bool ComboNuevo = true;
        private readonly int colAccionesProd = 2;
        private readonly int colAccionesDet = 4;
        private int cantidadProdDet = 0;
        private int cantidadProd = 0;
        byte[] filefoto = null;
        #endregion VARIABLES

        #region FORMULARIO
        public ModuloCombos()
        {
            _tallascoloresRepository = new TallasyColoresRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            _coloresRepository = new ColoresRepository(_context);
            _tallasRepository = new TallasRepository(_context);
            _combosRepository = new CombosRepository(_context);
            listaDetallesDel = new List<ComboDetalleLista>();
            listaDetalles = new List<ComboDetalleLista>();            
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

        private void ModuloCombos_Load(object sender, EventArgs e)
        {
            RefrescarDataGridCombos(false);
            CargarProductos();
        }

        private void ModuloCombos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MostrarMenu)
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

        #endregion

        #region LISTADO

        public void RefrescarDataGridCombos(bool loadNewContext = true)
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
            DgvListCombos.DataSource = typeof(List<>);
            DgvListCombos.DataSource = source;
            DgvListCombos.ClearSelection();
        }

        private void TxtBuscador_TextChanged(object sender, EventArgs e)
        {
            var filtro = combos.Where(a => a.Descripcion.Contains(TxtBuscador.Text) ||
                                     (a.Descripcion != null && a.Descripcion.Contains(TxtBuscador.Text)));
            DgvListCombos.DataSource = filtro.ToList();
            DgvListCombos.ClearSelection();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            PageGestion.Visible = true;
            NavCombos.SelectedPage = PageGestion;
            ComboNuevo = true;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (DgvListCombos.CurrentRow != null)
            {
                var fila = DgvListCombos.CurrentRow;
                Combo = (ListarCombos)fila.DataBoundItem;
                CargarCombo(Combo);
                PageGestion.Visible = true;
                NavCombos.SelectedPage = PageGestion;
                ComboNuevo = false;                
            }
            else
            {
                KryptonMessageBox.Show("No ha seleccionado ninguna fila del listado.", "Notificación");
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            RefrescarDataGridCombos(true);
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (DgvListCombos.CurrentRow == null)
            {
                return;
            }

            var dialog = KryptonMessageBox.Show("¿Está seguro que desea eliminar el combo de la lista?", "Eliminar combo",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);

            if (dialog == DialogResult.Yes)
            {
                var combofila = (ListarCombos)DgvListCombos.CurrentRow.DataBoundItem;
                var ComboObtenido = _combosRepository.Get(combofila.IdCombo);
                ComboObtenido.isActive = true;
                _combosRepository.Update(ComboObtenido);
                _combosRepository.DeleteDetalles(combofila.IdCombo);
                RefrescarDataGridCombos(true);
            }
        }

        #endregion LISTADO

        #region GESTION

        private void CargarCombo(ListarCombos combo)
        {
            TxtDescripcion.Text = combo.Descripcion;
            TxtCodigoBarras.Text = combo.CodigoBarras;
            TxtCosto.Text = combo.PrecioCompra.ToString();
            TxtStock.Text = combo.Stock.ToString();
            txtprecioventa.Text = combo.Precioventa.ToString();
            txtpreciomayorista.Text = combo.PrecioMayorista.ToString();
            txtprecioentidad.Text = combo.PrecioMayorista.ToString();
            txtpreciocuentaclave.Text = combo.PrecioCuentaClave.ToString();
            txtrevendedor.Text = combo.PrecioRevendedor.ToString();
            if (combo.Imagen != null)
            {
                filefoto = combo.Imagen;
                MemoryStream mStream = new MemoryStream(filefoto);
                PbImgCombo.Image = Image.FromStream(mStream);
                PbImgCombo.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            listaDetalles = _combosRepository.GetListDetalleCombo(combo.IdCombo);
            CargarDGVCombos(listaDetalles);
        }

        private void CargarDGVCombos(List<ComboDetalleLista> lista)
        {
            BindingSource recurso = new BindingSource();
            recurso.DataSource = lista;
            DgvDetallesCombo.DataSource = typeof(List<>);
            DgvDetallesCombo.DataSource = recurso;
            DgvDetallesCombo.AutoResizeColumns();
            DgvDetallesCombo.ClearSelection();
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

        private void BtnAddImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog imagen = new OpenFileDialog();
            imagen.Filter = "Archivos JPG (*.jpg)|*.jpg| Archivos png(*.png)|*.png";
            DialogResult filestream = imagen.ShowDialog();

            if (filestream == DialogResult.OK)
            {
                PbImgCombo.Image = Image.FromFile(imagen.FileName);
                PbImgCombo.SizeMode = PictureBoxSizeMode.StretchImage;
                FilestreamImagen();
            }
        }

        private void FilestreamImagen()
        {
            filefoto = null;
            MemoryStream memoryStream = new MemoryStream();
            PbImgCombo.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            memoryStream.GetBuffer();
            filefoto = memoryStream.GetBuffer();
        }

        private void DgvDetallesCombo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SumarCostos();
        }

        private void DgvDetallesCombo_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var fila = DgvDetallesCombo.CurrentRow;
            var filaActualEliminada = (ComboDetalleLista)fila.DataBoundItem;
            listaDetallesDel.Add(filaActualEliminada);
            SumarCostos();
        }

        private void TxtBuscadorProd_TextChanged(object sender, EventArgs e)
        {
            BuscarProductos();
        }

        private void BuscarProductos()
        {
            string txt1 = TxtBuscadorProd.Text.ToLower();
            string txt2 = txt1.ToUpper();
            var filter = _listadoproductos.Where(a =>
            (a.Descripcion != null && a.Descripcion.Contains(txt1)) || (a.Descripcion.Contains(txt2)) ||
            (a.CodigoReferencia != null && a.CodigoReferencia.Contains(txt1)) ||
            (a.Ubicacion != null && a.Ubicacion.Contains(txt1)) || (a.Ubicacion.Contains(txt2)));
            DgvProductos.DataSource = filter.ToList();
            DgvProductos.ClearSelection();
        }

        private void BtnPreciosProd_Click(object sender, EventArgs e)
        {
            if (DgvProductos.CurrentRow != null)
            {
                int id = Convert.ToInt32(DgvProductos.CurrentRow.Cells[0].Value);
                Producto prod = _productosRepository.Get(id);
                Precios(this, prod);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (DgvDetalle.Rows.Count == 0)
            {
                List<ListarProductos> seleccionados = SeleccionAcciones();
                if (seleccionados.Count > 0)
                {
                    AgregarListarDetalles(seleccionados);
                   LimpiarSeleccion();
                }
                else
                {
                    KryptonMessageBox.Show("No hay productos seleccionados", "Advertencia");
                }
            }
            else
            {
                List<ListarDetalle> seleccionados = SeleccionDetalles();
                if (seleccionados.Count > 0)
                {
                    AgregarConDetalles(seleccionados);
                    DgvDetalle.Rows.Clear();
                    LimpiarSeleccion();
                }
                else
                {
                    KryptonMessageBox.Show("No ha seleccionado ninguna fila del \nlistado de detalles del producto", "Advertencia");
                }
            }
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

        private void AgregarListarDetalles(List<ListarProductos> listadoseleccion)
        {
            foreach (var item in listadoseleccion)
            {
                ComboDetalleLista detallecombo = new ComboDetalleLista
                {
                    ProductoId = item.Id,
                    Referencia = item.CodigoReferencia,
                    Cantidad = 1,
                    Descripcion = item.Descripcion,
                };
                var exist = listaDetalles.Find(x => x.ProductoId == detallecombo.ProductoId);
                if (exist == null)
                    listaDetalles.Add(detallecombo);
            }
            CargarDGVCombos(listaDetalles);
            SumarCostos();
        }

        private List<ListarDetalle> SeleccionDetalles()
        {
            List<ListarDetalle> listadoseleccion = new List<ListarDetalle>();
            foreach (DataGridViewRow Rows in DgvDetalle.Rows)
            {
                ListarDetalle detalle = (ListarDetalle)Rows.DataBoundItem;
                if (detalle.Acciones)
                {
                    listadoseleccion.Add(detalle);
                }
            }
            return listadoseleccion;
        }

        private void AgregarConDetalles(List<ListarDetalle> listadoseleccion)
        {
            foreach (var item in listadoseleccion)
            {
                ListarProductos prod = _listadoproductos.Find(x => x.Id == item.ProductoId);
                if (prod != null)
                {
                    ComboDetalleLista detallecombo = new ComboDetalleLista();
                    detallecombo.ProductoId = prod.Id;
                    detallecombo.Referencia = prod.CodigoReferencia;
                    detallecombo.Cantidad = 1;
                    detallecombo.Descripcion = prod.Descripcion;

                    int opc = ObtenerTipoDetalle(prod);
                    switch (opc)
                    {
                        case 1:
                            detallecombo.ColorId = item.DetalleId;
                            detallecombo.Color = item.Detalle;
                            break;
                        case 2:
                            detallecombo.TallaId = item.DetalleId;
                            detallecombo.Talla = item.Detalle;
                            break;
                        case 3:
                            detallecombo.TallayColorId = item.DetalleId;
                            string[] colortalla = item.Detalle.Split('-');
                            detallecombo.Color = colortalla[0].Trim();
                            detallecombo.Talla = colortalla[1].Trim();
                            break;
                    }

                    var exist = listaDetalles.Find(x => x.ProductoId == detallecombo.ProductoId &&
                                                    x.TallaId == detallecombo.TallaId &&
                                                    x.ColorId == detallecombo.ColorId &&
                                                    x.TallayColorId == detallecombo.TallayColorId);
                    if (exist == null)
                        listaDetalles.Add(detallecombo);
                }
            }
            CargarDGVCombos(listaDetalles);
            SumarCostos();
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

        private void LimpiarSeleccion()
        {
            foreach (ListarProductos prod in _listadoproductos )
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
            ResetCantidadSelec();
            TxtBuscadorDet.Text = "";
            TxtBuscadorProd.Text = "";
        }

        private void ResetCantidadSelec()
        {
            cantidadProd = 0;
            cantidadProdDet = 0;
        }

        private void SumarCostos()
        {
            decimal adquisision = 0.00m;
            foreach (DataGridViewRow rows in DgvDetallesCombo.Rows)
            {
                var item = (ComboDetalleLista)rows.DataBoundItem;
                var producto = _productosRepository.GetProductByBarCode(item.Referencia, UsuarioLogeadoSistemas.User.SucursalId);
                if (producto != null)
                {
                    decimal cant = (producto.Coste * item.Cantidad);
                    adquisision += cant;
                }
            }
            TxtCosto.Text = adquisision.ToString();
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
                    LlenarTextBox(0);
                    if (tienedetalle > 0)
                        cantidadProdDet--;
                    else
                        cantidadProd--;
                }
                else
                {
                    DgvProductos.CurrentRow.Cells[colAccionesProd].Value = true;
                    LlenarTextBox(listarProductos.Id);
                    if (tienedetalle > 0)
                        cantidadProdDet++;
                    else
                        cantidadProd++;
                }

                ValidarSeleccionados();
            }
        }

        public void LlenarTextBox(int prod)
        {
            var productoObtenido = _productosRepository.Get(prod);
            int opcion = ObtenerTipoDetalle(productoObtenido);
            switch (opcion)
            {
                case 1:
                    var listadeColoresProductos = _coloresRepository.GetListaDetalle(productoObtenido.Id);
                    CargarDgvDetalle(listadeColoresProductos);
                    BtnAgregar.Enabled = false;
                    break;
                case 2:
                    var listadeTallaProductos = _tallasRepository.GetListaDetalle(productoObtenido.Id);
                    CargarDgvDetalle(listadeTallaProductos);
                    BtnAgregar.Enabled = false;
                    break;
                case 3:
                    var listadeTallaColorProductos = _tallascoloresRepository.GetListaDetalle(productoObtenido.Id);
                    CargarDgvDetalle(listadeTallaColorProductos);
                    BtnAgregar.Enabled = false;
                    break;
                default:
                    CargarDgvDetalle(new List<ListarDetalle>());
                    BtnAgregar.Enabled = true;
                    break;
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

        private void CargarDgvDetalle(List<ListarDetalle> listarDetalles)
        {
            BindingSource source = new BindingSource
            {
                DataSource = listarDetalles
            };
            DgvDetalle.DataSource = typeof(List<>);
            DgvDetalle.DataSource = source;
            DgvDetalle.ClearSelection();
        }

        private void ValidarSeleccionados()
        {
            if (cantidadProdDet == 1 && cantidadProd == 0)
            {
                ListarProductos productos = _listadoproductos.Find(x => x.Acciones == true);
                LlenarTextBox(productos.Id);
                BtnAgregar.Enabled = true;
            }
            else if (cantidadProdDet == 1 && cantidadProd > 0)
            {
                DgvDetalle.Rows.Clear();
                BtnAgregar.Enabled = false;
            }
            else if (cantidadProdDet == 0 && cantidadProd > 0)
            {
                DgvDetalle.Rows.Clear();
                BtnAgregar.Enabled = true;
            }
            else if (cantidadProdDet > 1)
            {
                DgvDetalle.Rows.Clear();
                BtnAgregar.Enabled = false;
            }
        }             

        private void DgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvDetalle.CurrentCell.ColumnIndex == colAccionesDet)
            {
                var fila = DgvDetalle.CurrentRow;
                ListarDetalle detalle = (ListarDetalle)fila.DataBoundItem;
                if (detalle.Acciones)
                {
                    DgvDetalle.CurrentRow.Cells[colAccionesDet].Value = false;
                }
                else
                {
                    DgvDetalle.CurrentRow.Cells[colAccionesDet].Value = true;
                }
            }
        }               

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = ValidarNullos();
                if (mensaje.Length == 0)
                {
                    GuardarCombo();
                    LimpiarContenido();
                    LimpiarVariables();
                    RefrescarDataGridCombos();
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
            if (string.IsNullOrEmpty(TxtCodigoBarras.Text))
            {
                msj = "Debe ingresar un codigo de referencia";
            }
            else if (!string.IsNullOrEmpty(TxtCosto.Text))
            {
                decimal compara = 0.00m;
                decimal preciov = Convert.ToDecimal(TxtCosto.Text);

                if (preciov <= compara)
                {
                    msj = "Debe ingresar un precio de adquisición válido";
                }
            }
            else if (!string.IsNullOrEmpty(txtprecioventa.Text))
            {
                decimal compara = 0.00m;
                decimal preciov = Convert.ToDecimal(txtprecioventa.Text);

                if (preciov <= compara)
                {
                    msj = "Debe ingresar un precio de venta válido";
                }
            }
            return msj;
        }

        private void GuardarCombo()
        {
            try
            {
                Combo encabezadoCombo;
                if (ComboNuevo)
                {
                    encabezadoCombo = GetCombo(new Combo());
                    encabezadoCombo.Id = Guid.NewGuid();
                    _combosRepository.Add(encabezadoCombo);
                }
                else
                {
                    Combo comboAct = _combosRepository.Get(Combo.IdCombo);
                    encabezadoCombo = GetCombo(comboAct);
                    _combosRepository.Update(encabezadoCombo);
                }

                if (ModelState.IsValid(encabezadoCombo))
                {

                    foreach (var item in listaDetalles)
                    {
                        if (item.Id > 0)
                        {
                            var detalleCombo = _combosRepository.Getdetalle(item.Id);
                            detalleCombo.Cantidad = item.Cantidad;
                            if (detalleCombo != null)
                                _combosRepository.UpdateDetalleCombo(detalleCombo);
                        }
                        else
                        {
                            var detalle = new DetalleCombo()
                            {
                                ComboId = encabezadoCombo.Id,
                                Referencia = item.Referencia.ToString(),
                                Descripcion = item.Descripcion,
                                Cantidad = item.Cantidad,
                            };

                            if (item.TallayColorId != 0) { detalle.DetalleColorTallaId = item.TallayColorId; }
                            if (item.TallaId != 0) { detalle.DetalleTallaId = item.TallaId; }
                            if (item.ColorId != 0) { detalle.DetalleColorId = item.ColorId; }
                            _combosRepository.AddDetalle(detalle);
                            _context.SaveChanges();
                        }
                    }
                    EliminarDetalles();
                    if (!ComboNuevo)
                    {
                        NavCombos.SelectedPage = PageListado;
                        PageGestion.Visible = false;
                    }
                    KryptonMessageBox.Show("Combo Registrado con exito", "Notificación");
                }
                else
                {
                    KryptonMessageBox.Show("Error interno en la obtencion de la información", "ERROR");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        public Combo GetCombo(Combo combo)
        {
            combo.SucursalId = UsuarioLogeadoSistemas.User.SucursalId;
            combo.Descripcion = TxtDescripcion.Text;
            combo.FechaInicio = DateTime.Now;
            combo.Precioventa = txtprecioventa.Text != "" ? decimal.Parse(txtprecioventa.Text) : 0.00m;
            combo.PrecioMayorista = txtpreciomayorista.Text != "" ? decimal.Parse(txtpreciomayorista.Text) : 0.00m;
            combo.PrecioCuentaClave =txtpreciocuentaclave.Text != "" ? decimal.Parse(txtpreciocuentaclave.Text) : 0.00m;
            combo.PrecioEntidadGubernamental = txtprecioentidad.Text != "" ? decimal.Parse(txtprecioentidad.Text) : 0.00m;
            combo.PrecioRevendedor = txtrevendedor.Text != "" ? decimal.Parse(txtrevendedor.Text) : 0.00m;
            combo.PrecioCompra = TxtCosto.Text != "" ? decimal.Parse(TxtCosto.Text) : 0.00m;
            combo.TieneColor = false;
            combo.FechaMovimiento = DateTime.Now;
            combo.CategoriaId = 1;
            combo.Stock =TxtStock.Text !=""? int.Parse(TxtStock.Text):0;
            combo.CodigoBarras = TxtCodigoBarras.Text;
            combo.Imagen = filefoto;
            return combo;
        }

        private void EliminarDetalles()
        {
            if (listaDetallesDel.Count > 0)
            {
                foreach (var item in listaDetallesDel)
                {
                    DetalleCombo detalle = _combosRepository.Getdetalle(item.Id);
                    if (detalle != null)
                    {
                        _combosRepository.DeleteProductoDetalle(detalle);
                    }
                }
            }
        }

        private void LimpiarContenido()
        {
            TxtDescripcion.Text = "";
            TxtCodigoBarras.Text = "";
            TxtCosto.Text = "";
            TxtStock.Text = "";
            txtprecioventa.Text = "";
            txtpreciomayorista.Text = "";
            txtprecioentidad.Text = "";
            txtpreciocuentaclave.Text = "";
            txtrevendedor.Text = "";
            PbImgCombo.Image = Sistema.Properties.Resources.anadir_imagen32;
            PbImgCombo.SizeMode = PictureBoxSizeMode.CenterImage;
            DgvDetallesCombo.Rows.Clear();
            DgvDetalle.Rows.Clear();
            LimpiarSeleccion();
        }

        private void LimpiarVariables()
        {
            listaDetalles = new List<ComboDetalleLista>();
            Combo = null;
            cantidadProdDet = 0;
            cantidadProd = 0;
            filefoto = null;
        }


        #endregion GESTION

        private void toolCombos_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void DgvDetallesCombo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
