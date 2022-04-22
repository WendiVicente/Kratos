using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.ListasPersonalizadas.VentasAcumuladas;
using CapaDatos.Models.Cotizacion;
using CapaDatos.Models.Precios;
using CapaDatos.Models.Productos;
using CapaDatos.Models.Productos.Combos;
using CapaDatos.Models.ProductosToFacturar;
using CapaDatos.Models.Usuarios;
using CapaDatos.Repository;
using CapaDatos.Repository.PreciosRepository;
using CapaDatos.Repository.SolicitudestoFacturar;
using ComponentFactory.Krypton.Toolkit;
using NSubstitute;
using POS.Forms;
using POS.Validations;
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
    public partial class PrincipalV2 : BaseContext
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

        //listas detalles
        public List<ListarDetalleCotiz> _listadetallesCotiz = new List<ListarDetalleCotiz>();
        public List<ListarDetallePedidos> _listadetallesPedidos = new List<ListarDetallePedidos>();
        public IList<ListarCombos> _listaCombos = new List<ListarCombos>();
        public IList<ListarProductos> _listaProductos = null, listareducidaDebusquedal = null;
        public List<ListarDetalleFacturas> _listaDetalleFacturas = new List<ListarDetalleFacturas>();
        public List<SolicitudDetalle> _listaSolicitudDetalles = null;
        public List<ListarAcumuladasEncabezado> _listaSolicitud = null;
        public List<Producto> _allProductosList = null, listatotalbusqueda = null;
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
        //objetos creados
        private TableLayoutPanel tabla;
        public PrincipalV2(User user)
        {
            UsuarioLogeadoPOS.User = user;
            InitializeComponent();
            _cotizacionRepository = new CotizacionRepository(_context);
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
            cargarUsuarioYSucursal();
        }

        private void PrincipalV2_Load(object sender, EventArgs e)
        {
            //TODO: clickl en datagrid para luego agregar el detalle en la venta, unicamente si es cajero , vendedor no

            cargarListaVentasPendientes();

            var cargaCombo = ComboLoad();
            var cargaProducto = ProductosLoad1();
            _allProductosList = null;//_productosRepository.GetAllProductos().Take(50).ToList();
            listatotalbusqueda = null;// _productosRepository.GetAllProductos();
            //listareducidaDebusquedal = _productosRepository.GetList(UsuarioLogeadoPOS.User.SucursalId);
            _listaCombos = cargaCombo;

            cargaProductosInit();

            cargarCateroriasb();
            CargarProductosGenerales(cargaProducto);
        }
        private void cargarListaVentasPendientes()
        {
           
                _listaSolicitud = _solicitudesRepository.GetSolicitudesxUser(UsuarioLogeadoPOS.User.Privilegios,UsuarioLogeadoPOS.User.Id);
                CargarVentasSolicitadas(_listaSolicitud);
          
            
        }


        private void CargarVentasSolicitadas(List<ListarAcumuladasEncabezado> lista)
        {
            BindingSource recurso = new BindingSource();

            recurso.DataSource = lista;
            dgVentasPendientes.DataSource = typeof(List<>);
            dgVentasPendientes.DataSource = recurso;
            dgVentasPendientes.AutoResizeColumns();
            dgVentasPendientes.Columns[0].Visible = false;
            dgVentasPendientes.Columns[3].Visible = false;

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
        private void CargarCombosGenerales(IList<ListarCombos> lista)
        {
            //var lista= _productosRepository.GetList(UsuarioLogeadoPOS.User.SucursalId);
            BindingSource recurso = new BindingSource();

            recurso.DataSource = lista;
            dgvProductosBd.DataSource = typeof(List<>);
            dgvProductosBd.DataSource = recurso;
            //dgvProductosBd.AutoResizeColumns();
            // _listaCombos = lista;
        }

        private void cargarCateroriasb()
        {
            //CargarButtonsCategoria(_categoriaProdRepository.GetListcategoriaToButton());
        }
        private void cargarUsuarioYSucursal()
        {

            lbsucursal.Text = UsuarioLogeadoPOS.User.Sucursal.NombreSucursal;
            lbusuariologeado.Text = UsuarioLogeadoPOS.User.UserName;


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

        private void CargarPorCategoria(int catid) 
        {
            var productosbdcat = _productosRepository.GetListByCategoria(catid, UsuarioLogeadoPOS.User.SucursalId).ToList();
            _listaProductos = productosbdcat;
            cargaProductosInit();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Cargando cargando = new Cargando();
            //cargando.Show();
            CargarBD();
            //cargando.Close();
        }
        public void CargarBD()
        {
            //tableButtonCategoria.Controls.Clear();
            //cargarCateroriasb();
            //var cargaProducto = ProductosAll();
            //_listaProductos = cargaProducto;
            //cargaProductosInit();
            cargarListaVentasPendientes();
        }
        public void cargarValeLabel()
        {
            if (_valeSelected != null)
            {

                lbnumeroVale.Text = _valeSelected.NoVale;
                lbvalename.Visible = true;
            }
            else
            {
                lbvalename.Visible = false;
                lbnumeroVale.Text = null;
            }


        }

        public ProductosRepository AccesoProductoRepository()
        {
            try
            {
                _context = null;
                _context = new Context();
                _productosRepository = null;
                _productosRepository = new ProductosRepository(_context);
            }
            catch (Exception io)
            {
                KryptonMessageBox.Show("Error en 'AccesoProductosRepository' " + io.Message);
            }


            return _productosRepository;
        }


        public ListarDetalleFacturas GetDetalleFactura()
        {
            return new ListarDetalleFacturas()
            {


            };

        }

        public void resetValues()
        {
            checkAll.Checked = false;
            SumaFilas();
            dgvproductosadd.ClearSelection();
        }

        public void eliminarDGVDetalleFactura(int id)
        {
            try
            {
                if (_listaDetalleFacturas.Count > 0)
                {
                    ListarDetalleFacturas detalle = _listaDetalleFacturas.Where(x => x.ProductoId == id).FirstOrDefault();
                    int index = _listaDetalleFacturas.IndexOf(detalle);
                    dgvproductosadd.Rows.RemoveAt(index);
                }

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("No se pudo eliminar el producto del listado de Productos Agregados");
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
            dgvproductosadd.ClearSelection();
        }
        public List<ListarDetalleFacturas> GetSolicitudToFacturaDetalle(List<ListaVentasAcumuladas> solicitudDetalleslista)
        {
            //  var list = new List<ListarDetalleFacturas>();

            foreach (var item in solicitudDetalleslista)
            {
                if (solicitudDetalleslista == null) { continue; }
                var detalleFactura = GetDetalleFactura();
                detalleFactura.Id = (int)item.Id;
                detalleFactura.DetalleColorId = (int)item.DetalleColorId;
                detalleFactura.DetalleTallaId = (int)item.DetalleTallaId;
                detalleFactura.TallayColorId = item.TallayColorId;
                detalleFactura.Color = item.Color;
                detalleFactura.Talla = item.Talla;
                detalleFactura.ProductoId = (int)item.ProductoId;
                detalleFactura.Descripcion = item.Descripcion;
                detalleFactura.Cantidad = item.Cantidad;
                detalleFactura.Precio = item.Precio;
                detalleFactura.Descuento = item.Descuento;
                detalleFactura.PrecioTotal = item.PrecioTotal;
                detalleFactura.SubTotal = detalleFactura.PrecioTotal;
                detalleFactura.ComboId = item.ComboId;
                _listaDetalleFacturas.Add(detalleFactura);
            }
            return _listaDetalleFacturas;

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

        // TableLayoutPanel tablilla = new TableLayoutPanel();
        //private TableLayoutPanel CreateTable(PictureBox pbimg, decimal precio, Label descripcion, int notabla, string idprod)
        //{
        //    var tablilla = new TableLayoutPanel();
        //    tablilla.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        //    tablilla.ColumnCount = 1;
        //    tablilla.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        //    //tablilla.Controls.Add(pbimg, 0, 0);
        //    tablilla.Controls.Add(descripcion, 0, 1);
        //    tablilla.Controls.Add(tablaDeprecios(precio, idprod), 0, 2);
        //    tablilla.Name = notabla.ToString();
        //    tablilla.Location = new System.Drawing.Point(5, 5);
        //    tablilla.Name = notabla.ToString();
        //    tablilla.RowCount = 3;
        //    tablilla.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.55102F));
        //    tablilla.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.44898F));
        //    tablilla.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
        //    return tablilla;
        //}
        //private TableLayoutPanel tablaDeprecios(decimal precio, string idproducto)
        //{
        //    TableLayoutPanel tablaprecios2 = new TableLayoutPanel();
        //    tablaprecios2.ColumnCount = 2;
        //    tablaprecios2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
        //    tablaprecios2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
        //    tablaprecios2.Controls.Add(Createlabelprecio(precio), 1, 0);
        //    tablaprecios2.Controls.Add(crearbuttonprecios(idproducto), 0, 0);
        //    tablaprecios2.Dock = System.Windows.Forms.DockStyle.Fill;
        //    tablaprecios2.Location = new System.Drawing.Point(3, 101);
        //    tablaprecios2.Name = "tablaprecios";
        //    tablaprecios2.RowCount = 1;
        //    tablaprecios2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        //    tablaprecios2.Size = new System.Drawing.Size(125, 47);
        //    tablaprecios2.TabIndex = 0;
        //    return tablaprecios2;
        //}
        //private TableLayoutPanel tablaCategorias(KryptonButton botoncl)
        //{
        //    TableLayoutPanel tablaCategoriasToselect = new TableLayoutPanel();
        //    tablaCategoriasToselect.BackColor = System.Drawing.Color.White;
        //    tablaCategoriasToselect.ColumnCount = 1;
        //    tablaCategoriasToselect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        //    tablaCategoriasToselect.Controls.Add(botoncl, 0, 0);
        //    //tablaCategoriasToselect.Controls.Add(this.btnfantasia, 0, 7);
        //    //tablaCategoriasToselect.Controls.Add(this.btnjuguetes, 0, 6);
        //    //tablaCategoriasToselect.Controls.Add(this.btnfiesta, 0, 5);
        //    //tablaCategoriasToselect.Controls.Add(this.btnropa, 0, 4);
        //    //tablaCategoriasToselect.Controls.Add(this.btnzapateria, 0, 3);
        //    //tablaCategoriasToselect.Controls.Add(this.btnlibreria, 0, 2);
        //    // tablaCategoriasToselect.Controls.Add(this.label3, 0, 1); tableLayoutPanel8
        //    tablaCategoriasToselect.Dock = System.Windows.Forms.DockStyle.Top;
        //    tablaCategoriasToselect.Location = new System.Drawing.Point(2, 2);
        //    tablaCategoriasToselect.Margin = new System.Windows.Forms.Padding(2);
        //    tablaCategoriasToselect.Name = "tableButtonCategoria";
        //    tablaCategoriasToselect.RowCount = 14;
        //    tablaCategoriasToselect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.18841F));
        //    tablaCategoriasToselect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.81159F));
        //    tablaCategoriasToselect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
        //    tableButtonCategoria.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));

        //    this.tableButtonCategoria.Size = new System.Drawing.Size(122, 738);
        //    this.tableButtonCategoria.TabIndex = 0;
        //    return tableButtonCategoria;
        //}
        /*
        private Label crearLabelToCategory()
        {
            Label etiquetaCat = new Label();
            etiquetaCat.AutoSize = false;
            etiquetaCat.BackColor = System.Drawing.Color.Transparent;
            etiquetaCat.Dock = System.Windows.Forms.DockStyle.Top;
            etiquetaCat.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            etiquetaCat.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            etiquetaCat.Location = new System.Drawing.Point(2, 10);
            etiquetaCat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            etiquetaCat.Name = "etiquetaCat";
            etiquetaCat.Size = new System.Drawing.Size(118, 34);
            etiquetaCat.TabIndex = 9;
            etiquetaCat.Text = "Categorias";
            return etiquetaCat;
        }
        */
        //private Label crearbuttonprecios(string idp)
        //{
        //    Label btnprecioso = new Label();
        //    btnprecioso.AutoSize = false;
        //    btnprecioso.BackColor = System.Drawing.SystemColors.ActiveCaption;
        //    btnprecioso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        //    btnprecioso.Dock = System.Windows.Forms.DockStyle.Top;
        //    btnprecioso.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //    btnprecioso.Location = new System.Drawing.Point(3, 0);
        //    btnprecioso.Name = idp;
        //    btnprecioso.Size = new System.Drawing.Size(69, 47);
        //    btnprecioso.Click += new EventHandler(verprecios_DoubleClick);
        //    btnprecioso.TabIndex = 1;
        //    btnprecioso.Text = "Ver Precios";
        //    return btnprecioso;
        //}
        //private Label CreatelabelDesrip(string descrip, string id)
        //{
        //    Label lbdescrip = new Label();
        //    lbdescrip.AutoSize = true;
        //    lbdescrip.Dock = System.Windows.Forms.DockStyle.Fill;
        //    lbdescrip.Location = new System.Drawing.Point(3, 76);
        //    lbdescrip.Name = id.ToString();
        //    lbdescrip.Size = new System.Drawing.Size(120, 22);
        //    lbdescrip.TabIndex = 1;
        //    lbdescrip.Text = descrip;
        //    return lbdescrip;
        //}
        //private Label Createlabelprecio(decimal precio)
        //{
        //    Label lbprec = new Label();
        //    lbprec.AutoSize = true;
        //    lbprec.Dock = System.Windows.Forms.DockStyle.Right;
        //    lbprec.Location = new System.Drawing.Point(87, 98);
        //    //lbprec.Name = "lbprec";
        //    lbprec.Size = new System.Drawing.Size(36, 31);
        //    lbprec.TabIndex = 2;
        //    lbprec.Text = precio.ToString();
        //    lbprec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        //    return lbprec;
        //}

        //private PictureBox CreatePBimg(MemoryStream img, string id)
        //{
        //    PictureBox pbimg = new PictureBox();
        //    pbimg.Dock = System.Windows.Forms.DockStyle.Fill;
        //    // pbimg.Image = Image.FromFile(@"C:\Users\alexa\Pictures\umg\38546035.jpg");
        //    pbimg.Image = Image.FromStream(img);
        //    pbimg.Location = new System.Drawing.Point(3, 3);
        //    pbimg.Size = new System.Drawing.Size(120, 70);
        //    pbimg.TabIndex = 0;
        //    pbimg.TabStop = false;
        //    pbimg.Name = id;
        //    pbimg.Click += new EventHandler(AddtoGrid_Click);

        //    // pbimg.MouseDown += new MouseEventHandler(fs_MouseDown);
        //    return pbimg;
        //}
        private KryptonButton CreateButtonCategory(string nombreBT)
        {
            KryptonButton btncategoria = new KryptonButton();
            btncategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            btncategoria.Location = new System.Drawing.Point(2, 397);
            btncategoria.Margin = new System.Windows.Forms.Padding(2);
            btncategoria.Name = nombreBT;
            btncategoria.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            btncategoria.Size = new System.Drawing.Size(118, 66);
            btncategoria.TabIndex = 7;
            btncategoria.Values.Text = nombreBT;
            btncategoria.Click += new System.EventHandler(this.btnCatGenerico_Click);
            return btncategoria;

        }
        //void AddtoGrid_Click(object sender, EventArgs e)
        //{
        //    try
        //    {//TODO: error al momento de guardar clavo en click de imagen
        //        int idproducto;
        //        PictureBox picture = sender as PictureBox;
        //        if (Int32.TryParse(picture.Name.ToString(), out idproducto))
        //        {
        //            // var idproducto = int.Parse(picture.Name.ToString());
        //            var productolista = listareducidaDebusquedal.Where(x => x.Id == idproducto).FirstOrDefault();
        //            var productoObtenido = listatotalbusqueda.Where(x => x.Id == idproducto).FirstOrDefault();
        //            if (productoObtenido.TieneColor == true || productoObtenido.TieneTalla == true)
        //            {
        //                abrirPrecios(idproducto.ToString());
        //            }
        //            else
        //            {
        //                cargarProdToDgvFact(productolista);
        //            }

        //        }
        //        else
        //        {

        //            abrirPrecios(picture.Name.ToString());

        //        }


        //    }
        //    catch (Exception ex)
        //    {

        //        KryptonMessageBox.Show(ex.Message);
        //    }


        //    //  cargarProdToDgvFact(productolista);

        //}


        //void verprecios_DoubleClick(object sender, EventArgs e)
        //{
        //    Label lbbutoton = sender as Label;
        //    var idproducto = (lbbutoton.Name.ToString());
        //    abrirPrecios(idproducto);

        //}


        //private void abrirPrecios(string idproducto)
        //{
        //    if (Application.OpenForms["Mas"] == null)
        //    {


        //        Mas mas = new Mas(this, idproducto);

        //        mas.Show();
        //    }

        //    else { Application.OpenForms["Mas"].Activate(); }
        //}


        private void cargarProdToDgvFact(ListarProductos producto)
        {
            var detallefactura = GetDetalleFactura();

            detallefactura.ProductoId = producto.Id;
            detallefactura.Cantidad = 1;
            detallefactura.Descripcion = producto.Descripcion;
            detallefactura.Precio = producto.PrecioVenta;
            detallefactura.SubTotal = detallefactura.Cantidad * detallefactura.Precio;
            detallefactura.PrecioTotal = detallefactura.SubTotal;
            _listaDetalleFacturas.Add(detallefactura);
            cargarDGVDetalleFactura(_listaDetalleFacturas);

        }


        int contador = 0;

        //private void CargaImgProductos(IList<ListarProductos> listaproductos, bool isListaproducto)
        //{
        //    contador = 0;
        //    PictureBox creapbox; 
        //    if (isListaproducto)
        //    {

        //        foreach (var item in listaproductos)
        //        {

        //            if (item.Imagen == null)
        //            {
        //                creapbox = null;
        //                //creapbox = CreateImgGenerica(item.Id.ToString());
        //                //  continue;
        //            }
        //            else
        //            {
        //                var imgResult = cargarImg(item.Imagen);
        //                 creapbox = CreatePBimg(imgResult, item.Id.ToString());
        //            }

        //            var creaLbDescrip = CreatelabelDesrip(item.Descripcion, item.Id.ToString());
        //            tabla = CreateTable(creapbox, item.PrecioVenta, creaLbDescrip, contador, item.Id.ToString());

        //            for (int x = 0; x < tablaProductos.ColumnCount; x++)//columnas (fila, columna)
        //            {
        //                tablaProductos.Controls.Add(tabla, contador, x);
        //            }

        //            contador += 1;
        //        }

        //    }
        //    else
        //    {
        //        foreach (var item in _listaCombos)
        //        {
        //             creapbox = new PictureBox();
        //            if (item.Imagen != null)
        //            {
        //                var imgResult = cargarImg(item.Imagen);
        //                creapbox = CreatePBimg(imgResult, item.IdCombo.ToString());
        //            }

        //            var creaLbDescrip = CreatelabelDesrip(item.Descripcion, item.IdCombo.ToString());
        //            tabla = CreateTable(creapbox, item.Precioventa, creaLbDescrip, contador, item.IdCombo.ToString());

        //            for (int x = 0; x < tablaProductos.ColumnCount; x++)//columnas (fila, columna)
        //            {
        //                tablaProductos.Controls.Add(tabla, contador, x);
        //            }

        //            contador += 1;
        //        }

        //    }

        //}

        //private void CargarButtonsCategoria(IList<ListarCategoriaProd> listaCategoria)
        //{
        //    if (listaCategoria == null) { KryptonMessageBox.Show("Debera crear las categorias para continuar"); Close(); }
        //    var contadorx = 0;
        //    //Label etiquedatitulo= crearLabelToCategory();
        //    tableButtonCategoria.RowCount = listaCategoria.Count;
        //    // tableButtonCategoria.Controls.Add(etiquedatitulo, 0, 0);


        //    foreach (var item in listaCategoria)
        //    {
        //        var buttonActual = CreateButtonCategory(item.Categoria);

        //        this.tableButtonCategoria.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.18841F));
        //        //  var tablaBts = tablaCategorias(buttonActual);


        //        tableButtonCategoria.Controls.Add(buttonActual, 0, contadorx);
        //        contadorx++;

        //    }
        //}





        //private MemoryStream cargarImg(byte[] imgbyte)
        //{

        //    MemoryStream mStream = new MemoryStream(imgbyte);



        //    return mStream;
        //}




        //private PictureBox CreateImgGenerica( string id)
        //{
        //    PictureBox imgp = new PictureBox();
        //    imgp.Dock = System.Windows.Forms.DockStyle.Fill;
        //    imgp.Image = Image.FromFile(@"C:\SoftwareRedDowl\generico.jpg");
        //    //pbimg.Image = Image.FromStream(img);
        //    imgp.Location = new System.Drawing.Point(3, 3);
        //    imgp.Size = new System.Drawing.Size(120, 70);
        //    imgp.TabIndex = 0;
        //    imgp.TabStop = false;
        //    imgp.Name = id;
        //    imgp.Click += new EventHandler(AddtoGrid_Click);

        //    // pbimg.MouseDown += new MouseEventHandler(fs_MouseDown);
        //    return imgp;
        //}


        // creacion de buttones por medio de las categorias creadas









        private void btncotizacion_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["AgregarCotizacion"] == null)
            {

                //AgregarCotizacion AddCotizacion = new AgregarCotizacion(this);

                //AddCotizacion.Show();
            }
            else
            {
                Application.OpenForms["AgregarCotizacion"].Activate();
            }
        }

        private void btnpedidos_Click(object sender, EventArgs e)
        {
            //if (Application.OpenForms["AgregarPedido"] == null)
            //{
            //    AgregarPedido AddCotizacion = new AgregarPedido(this);

            //    AddCotizacion.Show();
            //}
            //else
            //{
            //    Application.OpenForms["AgregarPedido"].Activate();
            //}
        }

        private void btnVales_Click(object sender, EventArgs e)
        {
            //if (Application.OpenForms["AgregarVale"] == null)
            //{
            //    AgregarVale AddCotizacion = new AgregarVale(this);

            //    AddCotizacion.Show();
            //}
            //else
            //{
            //    Application.OpenForms["AgregarVale"].Activate();
            //}
        }

        private void btnproductos_Click(object sender, EventArgs e)
        {
            var listado = ProductosAll();
            CargarProductosGenerales(listado);
            selectProducto = true;
        }
        private void cargaProductosInit()
        {
            //  tablaProductos.Controls.Clear();
            CargarProductosGenerales(_listaProductos);
            selectProducto = true;
        }
        private void btncombos_Click(object sender, EventArgs e)
        {
            // tablaProductos.Controls.Clear();
            // CargaImgProductos(_listaProductos, false);
            CargarCombosGenerales(_listaCombos);
            selectProducto = false;
        }


        private void btnCatGenerico_Click(object sender, EventArgs e)
        {
            try
            {
                KryptonButton btnCatGeneric = sender as KryptonButton;
                var filtro = _listaProductos.Where(x => x.Categoria.Contains(btnCatGeneric.Text));
                var contadorproductos = _listaProductos.Count;
                dgvProductosBd.DataSource = filtro.ToList();
                //var rowcount = tablaProductos.RowCount;
                //var columcount = tablaProductos.ColumnCount;
                //tablaProductos.Controls.Clear();
                // CargaImgProductos(filtro.ToList(), true);

                selectProducto = true;
            }
            catch (Exception ex)
            {

                KryptonMessageBox.Show("Error btnCatGenerico " + ex.Message);
            }

        }



        //private void btnzapateria_Click(object sender, EventArgs e)
        //{

        //    var filtro = _listaProductos.Where(x => x.Categoria.Contains(categoria));
        //    tablaProductos.Controls.Clear();
        //    CargaImgProductos(filtro.ToList(), true);
        //    selectProducto = true;

        //}

        //private void btnropa_Click(object sender, EventArgs e)
        //{
        //    var filtro = _listaProductos.Where(x => x.Categoria.Contains(btnropa.Text));
        //    tablaProductos.Controls.Clear();
        //    CargaImgProductos(filtro.ToList(), true);
        //    selectProducto = true;
        //}

        //private void btnfiesta_Click(object sender, EventArgs e)
        //{

        //    var filtro = _listaProductos.Where(x => x.Categoria.Contains(categoria));
        //    tablaProductos.Controls.Clear();
        //    CargaImgProductos(filtro.ToList(), true);
        //    selectProducto = true;
        //}

        //private void btnjuguetes_Click(object sender, EventArgs e)
        //{
        //    var filtro = _listaProductos.Where(x => x.Categoria.Contains(btnjuguetes.Text));
        //    tablaProductos.Controls.Clear();
        //    CargaImgProductos(filtro.ToList(), true);
        //    selectProducto = true;
        //}

        //private void btnfantasia_Click(object sender, EventArgs e)
        //{

        //    var filtro = _listaProductos.Where(x => x.Categoria.Contains(categoria));
        //    tablaProductos.Controls.Clear();
        //    CargaImgProductos(filtro.ToList(), true);
        //    selectProducto = true;
        //}

        //private void btnotros_Click(object sender, EventArgs e)
        //{
        //    var filtro = _listaProductos.Where(x => x.Categoria.Contains(btnotros.Text));
        //    tablaProductos.Controls.Clear();
        //    CargaImgProductos(filtro.ToList(), true);
        //    selectProducto = true;
        //}
        private void txtbuscarcombo_TextChanged(object sender, EventArgs e)
        {
            BuscarCombos();
        }
        private void txtbuscar2_TextChanged(object sender, EventArgs e)
        {
            BuscarProductos();

        }

        //private void dgvProductoyCombos_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (selectProducto == true)
        //    {
        //        var selectFila = (ListarProductos)dgvProductoyCombos.CurrentRow.DataBoundItem;
        //        var detallefactura = GetDetalleFactura();
        //        detallefactura.Cantidad = 1;
        //        detallefactura.Descripcion = selectFila.Descripcion;
        //        detallefactura.Precio = selectFila.PrecioVenta;
        //        detallefactura.SubTotal = detallefactura.Cantidad * detallefactura.Precio;
        //        _listaDetalleFacturas.Add(detallefactura);
        //        cargarDGVDetalleFactura(_listaDetalleFacturas);
        //    }
        //    else
        //    {
        //        var selectFila = (ListarCombos)dgvProductoyCombos.CurrentRow.DataBoundItem;
        //        var detallefactura = GetDetalleFactura();
        //        detallefactura.Cantidad = 1;
        //        detallefactura.Descripcion = selectFila.Descripcion;
        //        detallefactura.Precio = selectFila.Precioventa;
        //        detallefactura.SubTotal = detallefactura.Cantidad * detallefactura.Precio;
        //        _listaDetalleFacturas.Add(detallefactura);
        //        cargarDGVDetalleFactura(_listaDetalleFacturas);

        //    }

        //}
       

        private void txtcodreferencia_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var codigoReferencia = txtcodreferencia.Text.Trim();
                //var productox = listareducidaDebusquedal.Where(x => x.CodigoReferencia == codigoReferencia).FirstOrDefault();
                var productox = _productosRepository.GetProductByBarCode(codigoReferencia, UsuarioLogeadoPOS.User.SucursalId);
                // var comprobarEnTabla = new ComprobarExistenciaEnTabla(ListaProductSelect);


                if (productox == null) return;
                if (e.KeyCode == Keys.Enter)
                {

                    var detallefactura = GetDetalleFactura();
                    detallefactura.Cantidad = 1;
                    detallefactura.Descripcion = productox.Descripcion;
                    detallefactura.Precio = productox.PrecioVenta;
                    detallefactura.SubTotal = detallefactura.Cantidad * detallefactura.Precio;
                    detallefactura.ProductoId = productox.Id;
                    _listaDetalleFacturas.Add(detallefactura);
                    txtcodreferencia.Text = "";
                    cargarDGVDetalleFactura(_listaDetalleFacturas);
                }
            }
            catch (Exception ex)
            {

                KryptonMessageBox.Show("Error en Codigo de referencia" + ex.Message);
                return;
            }



            //  }
        }
        private void BuscarProductos()
        {
            try
            {
                String txt = txtbuscar2.Text.ToUpper();
                var filter = _listaProductos.Where(a => a.Descripcion.Contains(txt));
                //||
                //a.CodigoReferencia != null && a.CodigoReferencia.Contains(txtbuscar2.Text) ||
                //(a.Descripcion != null && a.Descripcion.Contains(txtbuscar2.Text))).ToList();
                //||
                //(a.Categoria != null && a.Categoria.Contains(txtbuscar2.Text)) ||
                //(a.Ubicacion != null && a.Ubicacion.Contains(txtbuscar2.Text)) ||
                //(a.Notas != null && a.Notas.Contains(txtbuscar2.Text)))

                dgvProductosBd.DataSource = filter.ToList();
                // tablaProductos.Controls.Clear();
                // CargaImgProductos(filter, true);
            }
            catch (Exception ex)
            {

                KryptonMessageBox.Show("BuscarProductos() ha fallado! " + ex.Message);
            }


        }
        private void BuscarCombos()
        {


            try
            {
                var filter = _listaCombos.Where(a => a.CodigoBarras != null && a.CodigoBarras.Contains(txtbuscarcombo.Text) ||
                           (a.Descripcion != null && a.Descripcion.Contains(txtbuscarcombo.Text))).ToList();
                dgvProductosBd.DataSource = filter.ToList();
            }
            catch (Exception ex)
            {

                KryptonMessageBox.Show("BuscarCombos() ha fallado! " + ex.Message);
            }


            //   tablaProductos.Controls.Clear();
            // CargaImgProductos(filter, true);

        }


        private void txtbuscar2_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dgvproductosadd_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {

            KryptonMessageBox.Show("¡No se introdujo ningún valor valido en la celda!");

        }

        private void dgvproductosadd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                OperacionPorFila();
                SumaFilas();
            }
            
        }

        private void dgvproductosadd_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            SumaFilas();
        }

        private void dgvproductosadd_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var fila = dgvproductosadd.CurrentRow;
            decimal ttal = 0.00m;
            ttal = Convert.ToDecimal(txttotalf.Text);
            ttal = ttal - Convert.ToDecimal(fila.Cells[8].Value);
            txttotalf.Text = ttal.ToString();

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
                txttotalf.Text = cantidad.ToString();
            }
            catch (Exception io)
            {
                KryptonMessageBox.Show("Error en SumaFilas() " + io.Message);
            }
            
        }

        private void dgvproductosadd_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            SumaFilas();
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

        private void btncobrar_Click(object sender, EventArgs e)
        {
            if (dgvproductosadd.RowCount == 0)
            {
                KryptonMessageBox.Show("¡No hay productos agregados al listado!", "Notificación");
            }
            {
                VentanaCajeroyVendedor();
            }
        }

        private void ValidarMontoInsert()
        {
            //   var filaActual = (ListarDetalleFacturas)dgvproductosadd.CurrentRow.DataBoundItem;


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
                        CargarFormsAcumuladas(listaobtenidaDetalle);

                    }
                    if (UsuarioLogeadoPOS.User.Privilegios == "Administrador" || UsuarioLogeadoPOS.User.Privilegios == "Solo Caja")
                    {
                        CargarFormsPago(listaobtenidaDetalle);
                    }

                }

            }
            catch (IOException ex)
            {
                KryptonMessageBox.Show("Error en cobro " + ex.Message);
            }

        }

        private void CargarFormsPago(List<ListarDetalleFacturas> listaobtenidaDetalle)
        {
            if (Application.OpenForms["Pago"] != null) return;

            Pago childForm = new Pago(this, listaobtenidaDetalle, listadeVentasPendientes);
            childForm.Show();
        }
        private void CargarFormsAcumuladas(List<ListarDetalleFacturas> listaobtenidaDetalle)
        {
            if (Application.OpenForms["VentaAcumulada"] != null) return;

            VentaAcumulada childForm = new VentaAcumulada(this, listaobtenidaDetalle);
            childForm.Show();
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

        private void btnborrarvale_Click(object sender, EventArgs e)
        {
            _valeSelected = null;
            cargarValeLabel();
        }

        private void dgvproductosadd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarFila(dgvproductosadd, 17);
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

        private void btnVentasPendientes_Click(object sender, EventArgs e)
        {
            //if (Application.OpenForms["VentasPendientes"] == null)
            //{
            //    VentasPendientes VentasPendientesFACT = new VentasPendientes(this);

            //    VentasPendientesFACT.Show();
            //}
            //else
            //{
            //    Application.OpenForms["VentasPendientes"].Activate();
            //}

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

        private void dgvproductosadd_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        public ListarAcumuladasEncabezado ventaAcumuladaSelected = null;

        private void dgvProductosBd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                checkAll.Checked = false;
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
                             //   SeleccionarElemento sel = new SeleccionarElemento(1, this, detallefactura.ProductoId);
                               // sel.Show();
                            }
                            else if (selectFila.IncluyeColor == "No" && selectFila.Talla == "Si")
                            {
                                //cargar list de talla
                              //  SeleccionarElemento sel = new SeleccionarElemento(2, this, detallefactura.ProductoId);
                               // sel.Show();
                            }
                            else if (selectFila.IncluyeColor == "Si" && selectFila.Talla == "Si")
                            {
                                //cargar listado de colores y tallas
                                //SeleccionarElemento sel = new SeleccionarElemento(3, this, detallefactura.ProductoId);
                                //sel.Show();
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

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            dgvproductosadd.ClearSelection();
            try
            {
                int acciones = 17;
                if (checkAll.Checked == true)
                {
                    if (dgvproductosadd.RowCount > 0)
                    {
                        foreach (DataGridViewRow row in dgvproductosadd.Rows)
                        {
                            row.Cells[acciones].Value = true;


                        }
                    }

                }
                else
                {
                    foreach (DataGridViewRow row in dgvproductosadd.Rows)
                    {
                        row.Cells[acciones].Value = false;


                    }

                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }


        }
        public List<ListarAcumuladasEncabezado> listadeVentasPendientes = new List<ListarAcumuladasEncabezado>();
        private void dgVentasPendientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaObj = (ListarAcumuladasEncabezado)dgVentasPendientes.CurrentRow.DataBoundItem;
            ventaAcumuladaSelected = filaObj;
            if (ValidarRol())
            {
                CargarDetalleToFactura(filaObj);
                listadeVentasPendientes.Add(ventaAcumuladaSelected);
            }
        }


        private void dgVentasPendientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pbCabello_Click(object sender, EventArgs e)
        {
            CargarPorCategoria(1);
        }

        private void pbCosmeticos_Click(object sender, EventArgs e)
        {
            CargarPorCategoria(2);
        }

        private void pbFacial_Click(object sender, EventArgs e)
        {
            CargarPorCategoria(3);
        }

        private void pbManicuraPe_Click(object sender, EventArgs e)
        {
            CargarPorCategoria(4);
        }

        private void pbPersonal_Click(object sender, EventArgs e)
        {
            CargarPorCategoria(5);
        }

        private void pbUnias_Click(object sender, EventArgs e)
        {
            CargarPorCategoria(6);
        }

        private void pbVarios_Click(object sender, EventArgs e)
        {
            CargarPorCategoria(7);
        }

        private void btnCalculadora_Click(object sender, EventArgs e)
        {
            //string[] lines = { "" };
            //System.IO.File.WriteAllLines(@"C:\Guid\Guid.txt", lines);
            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Guid\Guid.txt"))
            //{
            //    for (int i = 0; i < 7660; i++)
            //    {
            //        file.WriteLine(Guid.NewGuid().ToString());
            //    }
            //}

            if (Application.OpenForms["Calculadora"] == null)
            {
                Calculadora calc = new Calculadora();
                calc.Show();
            }
            else { Application.OpenForms["Calculadora"].Activate(); }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private bool ValidarRol()
        {

            if (UsuarioLogeadoPOS.User.UserName == "admin@admin")
            {
                return true;
            }
            else { return false; }


        }


        private void CargarDetalleToFactura(ListarAcumuladasEncabezado encabezado)
        {
            Guid idSolicitud = encabezado.Id;
            var detalleObtenido = _solicitudesRepository.GetListaVentasAcumuladasbyUser(idSolicitud);
            if (detalleObtenido != null)
            {
                //var listaDetalles= GetSolicitudToFacturaDetalle(detalleObtenido);
                // _listadetallesPedidos = listaDetalles;
                cargarDGVDetalleFactura(GetSolicitudToFacturaDetalle(detalleObtenido));
            }
        }
    }
}
