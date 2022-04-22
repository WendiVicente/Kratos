using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Repository;
using CapaDatos.Repository.PreciosRepository;
using CapaDatos.Models.Productos.Promocion;
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
using CapaDatos.Validation;
using CapaDatos.Models.Precios;
using CapaDatos.Models.Productos.Combos;
using Sistema.Forms.modulo_promos;

namespace Sistema.Forms.modulo_producto
{
    public partial class ModuloPromos : BaseContext

    {
        private ProductosRepository _productosRepository = null;
        private CombosRepository _combosRepository = null;
        private PromocionRepository _promocionRepository = null;
        private IList<ListarPromocion> promocion = null;
        private bool MostrarMenu = true;
        private List<ListarDetallePromocion> listadetallepromocion = null;
        private SucursalesRepository _sucursalesRepository = null;
        private TipoPrecioRepository _tipoPrecioRepository = null;
        private List<ListarProductos> _listadoproductos;
        private List<ListarCombos> _listarcombos;
        public List<ListarSucursales> SucursalesSeleccionadas = null;
        private ListarPromocion promos;
        readonly Form FormularioVolver;
        Producto _producto;

        public ModuloPromos()

        {
            _productosRepository = new ProductosRepository(_context);
            _combosRepository = new CombosRepository(_context);
            _promocionRepository = new PromocionRepository(_context);
            listadetallepromocion=new List<ListarDetallePromocion>();
            _sucursalesRepository=new SucursalesRepository(_context);
            _tipoPrecioRepository=new TipoPrecioRepository(_context);
            
            InitializeComponent();
        }
        public ModuloPromos(Form form, Producto producto)

        {
           
            FormularioVolver = form;
            _producto = producto;
            InitializeComponent();
        }
        private readonly int colAccionesProd = 0;
        private readonly int colAccionesComb = 0;
        private int cantidadProdDet = 0;
        private int cantidadProd = 0;
        private bool promonuevo = true;
        private void BtnVolver_Click(object sender, EventArgs e)
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
        private Promocion GetModelPromocion()
        {
            return new Promocion()
            {
                Id=Guid.NewGuid(),
               
                FechaInicio = dtpFecha.Value,
                FechaFin = dtpfin.Value,
                HoraFin = dtpfin.Value.ToString("HH:mm"),
                HoraInicio = dtpFecha.Value.ToString("HH:mm"),

            };
        }

        private void ModuloPromos_Load(object sender, EventArgs e)
        {
            CargarProductos();
            CargarCombos();
            RefrescarDataGridPromos(true);
            CargarSucursal();
            cargarDescuentos();

        }
        private void CargarSucursal()
        {
            try
            {
                comboSucursales.DataSource = _sucursalesRepository.GetList();
                comboSucursales.DisplayMember = "NombreSucursal";
                comboSucursales.ValueMember = "Id";
                comboSucursales.Invalidate();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("No hay ninguna Sucursal, deberá ingresar uno", ex.Message);
            }
        }
        

        private void ModuloPromos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MostrarMenu)
                MenuPrincipal(this, false);
        }

        public void RefrescarDataGridPromos(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _promocionRepository = null;
                _promocionRepository = new PromocionRepository(_context);
            }

            BindingSource source = new BindingSource();
            promocion = _promocionRepository.GetlistPromocion();
            source.DataSource = promocion;
            DgvListPromociones.DataSource = typeof(List<>);
            DgvListPromociones.DataSource = source;
            DgvListPromociones.AutoResizeColumns();
            //DgvListPromociones.Columns[0].Visible = false;
        }

        private void TxtBuscador_TextChanged(object sender, EventArgs e)
        {
            var filtro = promocion.Where(a => a.Descripcion.Contains(TxtBuscador.Text) ||
                                        (a.Descripcion != null && a.Descripcion.Contains(TxtBuscador.Text)));
            DgvListPromociones.DataSource = filtro.ToList();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            PageGestion.Visible = true;
            NavPromos.SelectedPage = PageGestion;
        }
        private void CargarPromociones(ListarPromocion promo)
        {
            txtdescripromos.Text = promo.Descripcion;

            comboSucursales.DisplayMember = promo.Sucursal;
            dtpFecha.Value = promo.FechaInicio;
            dtpfin.Value = promo.FechaInicio;
           
           
            listadetallepromocion = _promocionRepository.GetlistDetallePromocion(promo.Id);
            CargarDGVPromos(listadetallepromocion);
        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (DgvListPromociones.CurrentRow != null)
            {
                var fila = DgvListPromociones.CurrentRow;
                promos = (ListarPromocion)fila.DataBoundItem;
                CargarPromociones(promos);
                PageGestion.Visible = true;
                NavPromos.SelectedPage = PageGestion;
                promonuevo = false;
            }
            else
            {
                KryptonMessageBox.Show("No ha seleccionado ninguna fila del listado.", "Notificación");
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            RefrescarDataGridPromos();
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (DgvListPromociones.CurrentRow == null)
            {
                return;
            }

            var dialog = KryptonMessageBox.Show("¿Está seguro que desea eliminar la promocion de la lista?", "Eliminar combo",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);
            if (dialog == DialogResult.Yes)
            {
                var promofila = (ListarPromocion)DgvListPromociones.CurrentRow.DataBoundItem;
                var promoobtenido = _promocionRepository.Get(promofila.Id);
                promoobtenido.IsActive = true;
                _promocionRepository.Update(promoobtenido);
                _promocionRepository.DeleteDetalles(promofila.Id);
                RefrescarDataGridPromos(true);

            }
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
            _listarcombos = _combosRepository.GetListarCombos(UsuarioLogeadoSistemas.User.SucursalId).ToList();
            source.DataSource = _listarcombos;
            DgvCombos.DataSource = typeof(List<>);
            DgvCombos.DataSource = source;
            DgvCombos.ClearSelection();


        }



        #region GESTION

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

        private void BtnDetalleCombo_Click(object sender, EventArgs e)
        {
            if(Application.OpenForms["DetalleCombo"] != null)
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


        #endregion
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
                DetalleProducto( this, producto);
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
        private List<ListarCombos> SeleccionAccionesCombos()
        {
            List<ListarCombos> listadoseleccioncombo = new List<ListarCombos>();
            foreach (DataGridViewRow Rows in DgvCombos.Rows)
            {
                ListarCombos combos = (ListarCombos)Rows.DataBoundItem;
                if (combos.Acciones)
                {
                    listadoseleccioncombo.Add(combos);
                }
            }
            return listadoseleccioncombo;
        }
        private void AgregarListarDetallesPedidos(List<ListarProductos> listadoseleccion)
        {
            foreach (var item in listadoseleccion)
            {
                ListarDetallePromocion detallepromocion = new ListarDetallePromocion
                {
                    ProductoId = item.Id,
                    Descripcion = item.Descripcion,
                    Promocion=txtdescripromos.Text,
                    Referencia=item.CodigoReferencia,
                    Descuento= comboDescuento.Text != "" ? decimal.Parse(comboDescuento.Text) : 0.00m,


                };
                var exist = listadetallepromocion.Find(x => x.ProductoId == detallepromocion.ProductoId);
                if (exist == null)
                    listadetallepromocion.Add(detallepromocion);
            }
            CargarDGVPromos(listadetallepromocion);

        }
        private void AgregarListarDetallesCombos(List<ListarCombos> listadoseleccioncombo)
        {
            foreach (var item in listadoseleccioncombo)
            {
                ListarDetallePromocion detallepromocion = new ListarDetallePromocion
                {
                   Id = item.IdCombo,
                    Descripcion = item.Descripcion,
                    Promocion = txtdescripromos.Text,
                    Referencia=item.CodigoBarras,
                    NombreCombo=item.Descripcion,
                    Descuento = comboDescuento.Text != "" ? decimal.Parse(comboDescuento.Text) : 0.00m,


                };
                var exist = listadetallepromocion.Find(x => x.Id == detallepromocion.Id);
                if (exist == null)
                    listadetallepromocion.Add(detallepromocion);
            }
            CargarDGVPromos(listadetallepromocion);

        }
        private void CargarDGVPromos(List<ListarDetallePromocion> lista)
        {
            BindingSource recurso = new BindingSource();
            recurso.DataSource = lista;
            listPromociones.DataSource = typeof(List<>);
            listPromociones.DataSource = recurso;
            listPromociones.AutoResizeColumns();
            listPromociones.ClearSelection();
        }
        private void LimpiarSeleccionPromoProducto()
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
        private void LimpiarSeleccionPromoCombo()
        {
            foreach (ListarCombos prod in _listarcombos)
            {
                prod.Acciones = false;
            }
            BindingSource source = new BindingSource
            {
                DataSource = _listarcombos
            };
            DgvCombos.DataSource = typeof(List<>);
            DgvCombos.DataSource = source;
            DgvCombos.ClearSelection();


        }
        private void BtnAgregarProd_Click(object sender, EventArgs e)
        {
            List<ListarProductos> seleccionados = SeleccionAcciones();
            if (seleccionados.Count > 0)
            {
                AgregarListarDetallesPedidos(seleccionados);
                LimpiarSeleccionPromoProducto();
            }
            else
            {
                KryptonMessageBox.Show("No hay productos seleccionados", "Advertencia");
            }
        }

        private void listPromociones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DgvCombos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = DgvCombos.CurrentRow.Index;
            if (DgvCombos.CurrentCell.ColumnIndex == colAccionesComb)
            {
                var fila = DgvCombos.CurrentRow;
                ListarCombos listarCombo = (ListarCombos)fila.DataBoundItem;
                if (listarCombo.Acciones)
                {
                    DgvCombos.CurrentRow.Cells[colAccionesComb].Value = false;
                }
                else
                {
                    DgvCombos.CurrentRow.Cells[colAccionesComb].Value = true;
                }


            }
        }

        private void BtnAgregarCombo_Click(object sender, EventArgs e)
        {
            List<ListarCombos> seleccionados = SeleccionAccionesCombos();
            if (seleccionados.Count > 0)
            {
                AgregarListarDetallesCombos(seleccionados);
                LimpiarSeleccionPromoCombo();
            }
            else
            {
                KryptonMessageBox.Show("No hay productos seleccionados", "Advertencia");
            }
        }
       
        private DetallePromocion GetDetallePromo()
        {
            return new DetallePromocion()
            {
            };
        }
        private void guardarPromo(int idsucursal)
        {

            var encabezadoPromo = GetModelPromocion();
            var detallePromo = GetDetallePromo();
            if (!ModelState.IsValid(detallePromo)) return;
            if (!ModelState.IsValid(encabezadoPromo)) return;
            encabezadoPromo.Descripcion = txtdescripromos.Text;
            encabezadoPromo.SucursalId = idsucursal;

            _promocionRepository.AddPromocion(encabezadoPromo);
            foreach (var item in listadetallepromocion)
            {
                if (item.ProductoId != 0)
                {
                    var detalle = new DetallePromocion()
                    {
                        Id = Guid.NewGuid(),
                        ProductoId = item.ProductoId,
                        PromocionId = encabezadoPromo.Id,
                        DescuentoPromosId = Guid.Parse(comboDescuento.SelectedValue.ToString()),
                        //ComboId = item.ComboId,
                    };
                    _promocionRepository.AddDetallePromocion(detalle);

                }
                else
                {
                    var detalle = new DetallePromocion()
                    {
                        Id = Guid.NewGuid(),
                        // ProductoId = item.ProductoId,
                        PromocionId = encabezadoPromo.Id,
                        DescuentoPromosId = Guid.Parse(comboDescuento.SelectedValue.ToString()),
                        ComboId = item.ComboId, //analizar
                    };
                    _promocionRepository.AddDetallePromocion(detalle);
                }

            }
            //  KryptonMessageBox.Show("Registro guardado correctamente!");
            // Close();
        }
        private void LimpiarContenido()
        {
           
            txtdescripromos.Text = "";
            listPromociones.Rows.Clear();

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtdescripromos.Text)) { KryptonMessageBox.Show("Debe de ingresar el nombre de la promoción"); return; }
            if (listPromociones.RowCount == 0)
            {
                KryptonMessageBox.Show("Debe de ingresar Productos a la promoción");
                return;
            }
            if (checkSucursales.Checked == true && SucursalesSeleccionadas.Count > 0)
            {
                foreach (var item in SucursalesSeleccionadas)
                {
                    guardarPromo(item.Id);
                }
                KryptonMessageBox.Show("Registro guardado correctamente!");
                LimpiarSeleccionPromoProducto();

            }
            else
            {
                guardarPromo(int.Parse(comboSucursales.SelectedValue.ToString()));
                KryptonMessageBox.Show("Registro guardado correctamente!");
                LimpiarSeleccionPromoCombo();
            }
            LimpiarContenido();
            RefrescarDataGridPromos();
        }
        private void guardarDescuento()
        {
            if (string.IsNullOrEmpty(txtnuevodescuento.Text)) { return; }
            var descuentonuevo = GetDescuentoPromos();
            if (!ModelState.IsValid(descuentonuevo)) { return; }
            _tipoPrecioRepository.AddDescuento(descuentonuevo);


        }
        private DescuentoPromos GetDescuentoPromos()
        {
            return new DescuentoPromos()
            {
                Id = Guid.NewGuid(),
                Descuento = int.Parse(txtnuevodescuento.Text),
            };
        }
       
        private void cargarDescuentos()
        {
            comboDescuento.DataSource = _tipoPrecioRepository.GetDescuentopromosAll();
            comboDescuento.ValueMember = "Id";
            comboDescuento.DisplayMember = "Descuento";
            //comboDescuento.SelectedIndex = 0;


        }

        private void DgvListPromociones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtBuscadorProd_TextChanged(object sender, EventArgs e)
        {
            BuscarProductos();

        }

        private void BuscarProductos()
        {
            try
            {
                string txt1 = TxtBuscadorProd.Text;
                String txt2 = TxtBuscadorProd.Text.ToUpper();
                var filter = _listadoproductos.Where(a => a.Descripcion.Contains(txt1) || a.Descripcion.Contains(txt2));

                DgvProductos.DataSource = filter.ToList();
                DgvProductos.ClearSelection();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("BuscarProductos() ha fallado! " + ex.Message);
            }
        }
        private void BuscarCombo()
        {
            try
            {
                string txt1 = txtbuscarcombo.Text;
                String txt2 = txtbuscarcombo.Text.ToUpper();
                var filter = _listarcombos.Where(a => a.Descripcion.Contains(txt1) || a.Descripcion.Contains(txt2));

                DgvCombos.DataSource = filter.ToList();
                DgvCombos.ClearSelection();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Buscar Combo ha fallado! " + ex.Message);
            }
        }
              
        
        private void txtbuscarcombo_TextChanged(object sender, EventArgs e)
        {
            BuscarCombo();
        }

        private void checkSucursales_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSucursales.Checked == true)
            {
                if (Application.OpenForms["AgregarMasSucursales"] == null)
                {


                    AgregarMasSucursales elegirMasTipos = new AgregarMasSucursales();
                    elegirMasTipos.Show();


                }

                else { Application.OpenForms["AgregarMasSucursales"].Activate(); }

            }
            else
            {
                SucursalesSeleccionadas = null;
            }
        }

        private void txtnuevodescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter)) { 
            guardarDescuento();
            txtnuevodescuento.Text = "";
            cargarDescuentos();
        }
        }

        private void TxtBuscadorProd_Click(object sender, EventArgs e)
        {

        }
    }
}
