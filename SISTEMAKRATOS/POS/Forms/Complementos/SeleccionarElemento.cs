using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Productos;
using CapaDatos.Repository;
using ComponentFactory.Krypton.Toolkit;
using POS.Validations;
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
    public partial class SeleccionarElemento : BaseContext
    {
        private readonly TallasRepository tallasRepository = null;
        private readonly ColoresRepository coloresRepository = null;
        private readonly TomoEdicionRepository tomoEdicionRepository = null;

        private List<DetalleTalla> detalleTallas = null;
        private List<DetalleColor> detalleColors = null;
        private List<DetalleTomoEdicion> detalleTomo = null;
        private List<DetalleTomoEdicion> detalleEdicion = null;
        private int _opcion;
        private int _productoId;
        private int colorId = 0;
        private int tallaId = 0;
        private int tomoId = 0;
        private int edicionId = 0;
        private int stockMinimo = 0;
        private int stockTotal = 0;
        private string _codigoprod;

        private PuntoDeVenta _pos = null;

        public SeleccionarElemento(int opcion, PuntoDeVenta principal, ListarProductos producto)
        {
            _opcion = opcion;
            _pos = principal;            
            _productoId = producto.Id;
            _codigoprod = producto.CodigoReferencia;
            tallasRepository = new TallasRepository(_context);
            coloresRepository = new ColoresRepository(_context);
            tomoEdicionRepository = new TomoEdicionRepository(_context);
            InitializeComponent();
        }

        private void SeleccionarColor_Load(object sender, EventArgs e)
        {
            detalleTallas = new List<DetalleTalla>();
            detalleColors = new List<DetalleColor>();
            detalleTomo = new List<DetalleTomoEdicion>();
            detalleEdicion = new List<DetalleTomoEdicion>();
            CargarCombos();
            cargarStock();
        }

        private void CargarCombos()
        {
            switch (_opcion)
            {
                case 1:
                    detalleColors = coloresRepository.GetProductoListaColor(_productoId);
                    List<Elemento> elements1 = GetElementsColors(detalleColors);
                    CargaComboColor(elements1);
                    cbTallas.Enabled = false;
                    cbTomo.Enabled = false;
                    cbEdicion.Enabled = false;
                    break;
                case 2:
                    detalleTallas = tallasRepository.GetTallaListaProducto(_productoId);
                    List<Elemento> elements2 = GetElementsTallas(detalleTallas);
                    CargaComboTalla(elements2);
                    cbColores.Enabled = false;
                    cbTomo.Enabled = false;
                    cbEdicion.Enabled = false;
                    break;
                case 3:
                    detalleTomo = tomoEdicionRepository.GetListTomos(_codigoprod).ToList();
                    detalleEdicion = tomoEdicionRepository.GetListEdiciones(_codigoprod).ToList();
                    List<Elemento> elements3 = GetElementsTomo(detalleTomo);
                    CargaComboTomo(elements3);
                    List<Elemento> elements4 = GetElementsEdicion(detalleEdicion);
                    CargaComboEdicion(elements4);
                    cbColores.Enabled = false;
                    cbTallas.Enabled = false;
                    break;

            }
        }

        private void CargaComboColor(List<Elemento> listado)
        {
            cbColores.DataSource = listado;
            cbColores.DisplayMember = "Nombre";
            cbColores.ValueMember = "Id";
            cbColores.SelectedIndex = 0;
            cbColores.Invalidate();

        }

        private void CargaComboTalla(List<Elemento> listado)
        {
            cbTallas.DataSource = listado;
            cbTallas.DisplayMember = "Nombre";
            cbTallas.ValueMember = "Id";
            cbTallas.SelectedIndex = 0;
            cbTallas.Invalidate();
        }

        private void CargaComboTomo(List<Elemento> listado)
        {
            cbTomo.DataSource = listado;
            cbTomo.DisplayMember = "Nombre";
            cbTomo.ValueMember = "Id";
            cbTomo.SelectedIndex = 0;
            cbTomo.Invalidate();
        }

        private void CargaComboEdicion(List<Elemento> listado)
        {
            cbEdicion.DataSource = listado;
            cbEdicion.DisplayMember = "Nombre";
            cbEdicion.ValueMember = "Id";
            cbEdicion.SelectedIndex = 0;
            cbEdicion.Invalidate();
        }

        private List<Elemento> GetElementsTomo(List<DetalleTomoEdicion> detalleTE)
        {
            List<Elemento> nuevalist = new List<Elemento>();
            foreach (DetalleTomoEdicion item in detalleTE)
            {
                string tmpdet = item.Tomo;
                nuevalist.Add(new Elemento(item.Id, tmpdet));
            }
            return nuevalist;
        }

        private List<Elemento> GetElementsEdicion(List<DetalleTomoEdicion> detalleTE)
        {
            List<Elemento> nuevalist = new List<Elemento>();
            foreach (DetalleTomoEdicion item in detalleTE)
            {
                string tmpdet = item.Edicion;
                nuevalist.Add(new Elemento(item.Id, tmpdet));
            }
            return nuevalist;
        }

        private List<Elemento> GetElementsTallas(List<DetalleTalla> detalleTallas)
        {
            List<Elemento> nuevalist = new List<Elemento>();
            foreach (DetalleTalla item in detalleTallas)
            {
                nuevalist.Add(new Elemento(item.Id, item.Talla));
            }
            return nuevalist;
        }

        private List<Elemento> GetElementsColors(List<DetalleColor> detalleColors)
        {
            List<Elemento> nuevalist = new List<Elemento>();
            foreach(DetalleColor item in detalleColors)
            {
                nuevalist.Add(new Elemento(item.Id, item.Color));
            }
            return nuevalist;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //_principal.EliminarUltima();
            SeleccionarElemento_FormClosing(null, null);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {         
            if (!Int32.TryParse(txtCantidad.Text, out var a) || txtCantidad.Text == "0")
            {
                MessageBox.Show("¡Debe ingresar una cantidad valida!", "Advertencia");
            }
            else
            {
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                int stock = Convert.ToInt32(lbStock.Text);
                int stockrestante = stockTotal - stockMinimo;
                if (cantidad > stock || cantidad > stockrestante) 
                {
                    MessageBox.Show("¡La cantidad ingresada excede el stock minimo o disponible!", "Advertencia");
                }
                else 
                {
                    switch (_opcion)
                    {
                        case 1:
                            _pos.AsignarValoresDetalle(1, cantidad, colorId, cbColores.Text);
                            break;
                        case 2:
                            _pos.AsignarValoresDetalle(2, cantidad, tallaId, cbTallas.Text);
                            break;
                        case 3:
                            _pos.AsignarValoresDetalle(3, cantidad, tomoId, cbTomo.Text);
                            break;
                        case 4:
                            _pos.AsignarValoresDetalle(3, cantidad, edicionId, cbEdicion.Text);
                            break;
                    }
                    Close();
                }
            }
        }

        private void cbColores_SelectedIndexChanged(object sender, EventArgs e)
        {
            colorId = obtenerId(cbColores);
            var color = detalleColors.Where(x => x.Id == colorId).FirstOrDefault();
            if(color != null)
                lbStock.Text = color.Stock.ToString();
        }

        private void cbTallas_SelectedIndexChanged(object sender, EventArgs e)
        {
            tallaId = obtenerId(cbTallas);
            var talla = detalleTallas.Where(x => x.Id == tallaId).FirstOrDefault();
            if(talla != null)
                lbStock.Text = talla.Stock.ToString();
        }

        private void cbTomo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _opcion = 3;
            if (int.TryParse(cbTomo.SelectedValue.ToString(), out var b))
            {
                tomoId = Convert.ToInt32(cbTomo.SelectedValue.ToString());
                var tomo = detalleTomo.Where(x => x.Id == tomoId).FirstOrDefault();
                if (tomo != null)
                    lbStock.Text = tomo.Stock.ToString();
            }         
        }

        private void cbEdicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            _opcion = 4;
            if (int.TryParse(cbEdicion.SelectedValue.ToString(), out var b))
            {
                edicionId = Convert.ToInt32(cbEdicion.SelectedValue.ToString());
                var edicion = detalleEdicion.Where(x => x.Id == edicionId).FirstOrDefault();
                if (edicion != null)
                    lbStock.Text = edicion.Stock.ToString();
            }
        }

        private string obtenerNombre(KryptonComboBox comboBox)
        {
            Elemento element = (Elemento)comboBox.SelectedItem;

            return element.Nombre;
        }

        private int obtenerId(KryptonComboBox comboBox)
        {
            Elemento element = (Elemento)comboBox.SelectedItem;
            if (element != null)
                return element.Id;
            else
                return 0;
        }

        private void cargarStock()
        {
            Producto prod = new ProductosRepository(_context).Get(_productoId);
            if (prod != null)
            {
                stockMinimo = prod.stockMinimo;
                lbStockMinimo.Text = stockMinimo.ToString();
                stockTotal = prod.Stock;
                lbStockGeneral.Text = stockTotal.ToString();
            }             

        }

        private void SeleccionarElemento_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!guardar)
            //    _pos.EliminarUltima();
        }
    }

    public class Elemento
    {
        public Elemento(int _id, string _nombre)
        {
            Id = _id;
            Nombre = _nombre;
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

}
