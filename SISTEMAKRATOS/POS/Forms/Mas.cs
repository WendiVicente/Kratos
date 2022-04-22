using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Productos;
using CapaDatos.Models.Productos.Combos;
using CapaDatos.Repository;
using CapaDatos.Repository.PreciosRepository;
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

namespace POS.Forms
{
    public partial class Mas : BaseContext
    {
        
        private ProductosRepository _productoRepository = null;
        private TallasyColoresRepository _tallasyColoresRepository = null;
        private TallasRepository _tallasRepository = null;
        private ColoresRepository _coloresRepository = null;
        private TipoPrecioRepository _tipoPrecioRepository = null;
        private CombosRepository _combosRepository = null;
        private PreciosDetallePepsRepository _preciosPepsRepository = null;
        private string idproducto;
        //Principal _principal = null;
        private Producto productoBuscado = null;
        private Combo _comboObtenido = null;
        private bool isProducto;
        public Mas( string id)
        {

            idproducto = id;
            //_principal = forms;
            _tallasRepository = new TallasRepository(_context);
            _coloresRepository = new ColoresRepository(_context);
            _productoRepository = new ProductosRepository(_context);
            _tallasyColoresRepository = new TallasyColoresRepository(_context);
            _tipoPrecioRepository = new TipoPrecioRepository(_context);
            _combosRepository = new CombosRepository(_context);
            _preciosPepsRepository = new PreciosDetallePepsRepository(_context);

            InitializeComponent();
            
        }

        private void Mas_Load(object sender, EventArgs e)
        {
            if (idproducto.Contains("-"))
            {
                var idcombo = Guid.Parse(idproducto);
                 _comboObtenido = _combosRepository.Get(idcombo);
                cargarPreciosCombos(_comboObtenido);

                isProducto = false;
                Cargarcomboconten(_comboObtenido.Id);
            }
            else
            {
                productoBuscado = _productoRepository.Get(int.Parse(idproducto));
                isProducto = true;
                cargarPrecios(productoBuscado);
                CargarColoresyTallas();
            }
            
            
        }

        
        //models facturas

        private ListarDetalleFacturas modeloVenta()
        {
            ListarDetalleFacturas detalle = new ListarDetalleFacturas()
            {
               
                Descripcion = txtproducto.Text,
                Cantidad = 1,
                
               
               
            };
            return detalle;
        }
        // validar stock 
        private void VerStock(bool isProducto)
        {
            if (isProducto)
            {
                txtStock.Text = productoBuscado.Stock.ToString() ;
            }

        }
        private void EnviarProductoToVenta()
        {
            var detalleFactura = modeloVenta();
            detalleFactura.ProductoId = productoBuscado.Id;
            if (productoBuscado.TieneColor == true && productoBuscado.TieneTalla == true)
            {
                if (dgvcolorytalla.CurrentRow == null) { KryptonMessageBox.Show("Debe seleccinar una fila del color y talla");return; }
               var coloytalla= Traercolordgv();
                detalleFactura.TallayColorId = coloytalla.Id;
                detalleFactura.Color = coloytalla.Color;
                detalleFactura.Talla = coloytalla.Talla;

            }
            if (productoBuscado.TieneColor == true && productoBuscado.TieneTalla == false)
            {
                detalleFactura.Color = comboColor.Text;
                detalleFactura.DetalleColorId= int.Parse(comboColor.SelectedValue.ToString());
            }
            if (productoBuscado.TieneColor == false && productoBuscado.TieneTalla == true)
            {
                detalleFactura.Talla = comboTalla.Text;
                detalleFactura.DetalleTallaId= int.Parse(comboTalla.SelectedValue.ToString());
            }

            if (productoBuscado.TieneEscalas == false)
            {
                if (rbmino.Checked == true)
                {
                    detalleFactura.Precio = productoBuscado.PrecioVenta;

                }
                if (rbmayo.Checked == true)
                {
                    detalleFactura.Precio = productoBuscado.PrecioMayorista;

                }
                if (rbcclave.Checked == true)
                {
                    detalleFactura.Precio = productoBuscado.PrecioCuentaClave;

                }
                if (rbgobi.Checked == true)
                {
                    detalleFactura.Precio = productoBuscado.PrecioEntidadGubernamental;

                }
                if (rbrevende.Checked == true)
                {
                    detalleFactura.Precio = productoBuscado.PrecioRevendedor;

                }
            }
            else
            {
                if (dgvprecios.CurrentRow == null) { KryptonMessageBox.Show("Debe seleccinar una fila de precios"); return; }

                var tipoPrecio = TraerPreciodgv();
                detalleFactura.TipoPrecioId = tipoPrecio.TiposId;
                 detalleFactura.Precio = tipoPrecio.Precio;


            }
            detalleFactura.PrecioTotal = detalleFactura.Precio * detalleFactura.Cantidad;
            detalleFactura.SubTotal = detalleFactura.PrecioTotal;
            //_principal._listaDetalleFacturas.Add(detalleFactura);
            //_principal.cargarDGVDetalleFactura(_principal._listaDetalleFacturas);

        }

        private void EnviarComboToVenta()
        {
            var detalleFactura = modeloVenta();
            detalleFactura.ComboId = _comboObtenido.Id;
            if (rbmino.Checked == true)
            {
                detalleFactura.Precio = _comboObtenido.Precioventa;

            }
            if (rbmayo.Checked == true)
            {
                detalleFactura.Precio = _comboObtenido.PrecioMayorista;

            }
            if (rbcclave.Checked == true)
            {
                detalleFactura.Precio = _comboObtenido.PrecioCuentaClave;

            }
            if (rbgobi.Checked == true)
            {
                detalleFactura.Precio = _comboObtenido.PrecioEntidadGubernamental;

            }
            if (rbrevende.Checked == true)
            {
                detalleFactura.Precio = _comboObtenido.PrecioRevendedor;

            }
            detalleFactura.PrecioTotal = detalleFactura.Precio * detalleFactura.Cantidad;
            detalleFactura.SubTotal = detalleFactura.PrecioTotal;
            //_principal._listaDetalleFacturas.Add(detalleFactura);
            //_principal.cargarDGVDetalleFactura(_principal._listaDetalleFacturas);
        }


        private ListarDetalleColorTallas Traercolordgv()
        {

            var coloytallaselected = (ListarDetalleColorTallas)dgvcolorytalla.CurrentRow.DataBoundItem;
            return coloytallaselected;

        }
        private ListarDetallePrecios TraerPreciodgv()
        {
            var tipoPrecio = (ListarDetallePrecios)dgvprecios.CurrentRow.DataBoundItem;
            return tipoPrecio;
        }

        private void cargarPrecios(Producto producto)
        {
            try
            {

                txtproducto.Text = producto.Descripcion;
                if (producto.TieneEscalas == false)
                {
                    

                    

                    txtminorista.Text = producto.PrecioVenta.ToString();
                    txtmayorista.Text = producto.PrecioMayorista.ToString();
                    txtcuentaclav.Text = producto.PrecioCuentaClave.ToString();
                    txtgobierno.Text = producto.PrecioEntidadGubernamental.ToString();
                    txtrevendedor.Text = producto.PrecioRevendedor.ToString();
                }
                else
                {
                    cargardgvPrecios();
                }
            }
            catch (Exception ex)
            {

                KryptonMessageBox.Show(ex.Message);
            }
            

        }
        private void cargardgvPrecios()
        { int todosTipos = 0;
            var tipoprecio = _tipoPrecioRepository.Get(productoBuscado.Id);
            var detalletipoPrecio = _tipoPrecioRepository.GetDetallePrecioListar(tipoprecio.Id, todosTipos);
            BindingSource source = new BindingSource();
            source.DataSource = detalletipoPrecio;
            dgvprecios.DataSource = typeof(List<>);
            dgvprecios.DataSource = source;
            dgvprecios.Columns[0].Visible = false;
            dgvprecios.Columns[1].Visible = false;
            dgvprecios.Columns[7].Visible = false;

        }
        private void cargarPreciosCombos(Combo combo)
        {
                txtproducto.Text = combo.Descripcion;
                txtminorista.Text = combo.Precioventa.ToString();
                txtmayorista.Text = combo.PrecioMayorista.ToString();
                txtcuentaclav.Text = combo.PrecioCuentaClave.ToString();
                txtgobierno.Text = combo.PrecioEntidadGubernamental.ToString();
                txtrevendedor.Text = combo.PrecioRevendedor.ToString();
          

        }

        private void CargarColoresyTallas()
        {
            try
            {
                if (isProducto == false) { return; }
                if (productoBuscado.TieneColor == true && productoBuscado.TieneTalla == true)
                {
                    CargarDGVcolortalla(productoBuscado.Id);
                }
                if (productoBuscado.TieneColor == true && productoBuscado.TieneTalla == false)
                {
                    var listadeColoresProductos = _coloresRepository.GetProductoListaColor(productoBuscado.Id);
                    cargarComboColores(listadeColoresProductos);
                }
                if (productoBuscado.TieneColor == false && productoBuscado.TieneTalla == true)
                {
                    var listadeTallaProductos = _tallasRepository.GetTallaListaProducto(productoBuscado.Id);
                    cargarComboTallas(listadeTallaProductos);
                }

            }
            catch (Exception ex)
            {

                KryptonMessageBox.Show(ex.Message);
            }

           
        }
        public void CargarDGVcolortalla(int idproducto)
        {
            if (isProducto == false) { return; }

            BindingSource source = new BindingSource();
            var detalleListsObtenida = _tallasyColoresRepository.GetListaDetalleColorTallas(idproducto);
            source.DataSource = detalleListsObtenida;
            dgvcolorytalla.DataSource = typeof(List<>);
            dgvcolorytalla.DataSource = source;
            dgvcolorytalla.AutoResizeColumns();
            dgvcolorytalla.Columns[0].Visible = false;
            dgvcolorytalla.Columns[1].Visible = false;

        }
        public void Cargarcomboconten(Guid idcombo)
        {


            BindingSource source = new BindingSource();
            var detallecombo = _combosRepository.GetListDetalleCombo(idcombo);
            source.DataSource = detallecombo;
            dgvcolorytalla.DataSource = typeof(List<>);
            dgvcolorytalla.DataSource = source;
            dgvcolorytalla.AutoResizeColumns();
            dgvcolorytalla.Columns[0].Visible = false;
            //dgvcolorytalla.Columns[1].Visible = false;

        }
        private void cargarComboColores(List<DetalleColor> detalleColors)
        {
            if (isProducto == false) { return; }
            comboColor.DataSource = detalleColors;
            comboColor.ValueMember = "Id";
            comboColor.DisplayMember = "Color";
            comboColor.SelectedIndex = 0;
        }
        private void cargarComboTallas(List<DetalleTalla> listaTallas)
        {
            if (isProducto == false) { return; }
            comboTalla.DataSource = listaTallas;
            comboTalla.ValueMember = "Id";
            comboTalla.DisplayMember = "Talla";
            comboTalla.SelectedIndex = 0;
        }
      
        private void btnEnviaraVenta_Click(object sender, EventArgs e)
        {
            if (isProducto)
            {
                EnviarProductoToVenta();
            }
            else
            {
                EnviarComboToVenta();
            }
           
        }

        private void dgvprecios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }


        private void limpiarPreciosTxtbox()
        {
            txtcuentaclav.Text = "";
            txtgobierno.Text = "";
            txtmayorista.Text = "";
            txtminorista.Text = "";
            txtrevendedor.Text = "";
        }
    }
}
