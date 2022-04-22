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
        private readonly TallasyColoresRepository tallasyColoresRepository = null;

        private List<DetalleTalla> detalleTallas = null;
        private List<DetalleColor> detalleColors = null;
        private List<DetalleColorTalla> detalleColorTallas = null;

        private int _opcion;
        private int _productoId;
        private int colorId = 0;
        private int tallaId = 0;
        private int tallacolorId = 0;
        private int stockMinimo = 0;
        private int stockTotal = 0;

        private PuntoDeVenta _principal = null;

        public SeleccionarElemento(int opcion, PuntoDeVenta principal, int productoId)
        {
            _opcion = opcion;
            _principal = principal;            
            _productoId = productoId;
            tallasRepository = new TallasRepository(_context);
            coloresRepository = new ColoresRepository(_context);
            tallasyColoresRepository = new TallasyColoresRepository(_context);
            InitializeComponent();
        }

        private void SeleccionarColor_Load(object sender, EventArgs e)
        {
            detalleTallas = new List<DetalleTalla>();
            detalleColors = new List<DetalleColor>();
            detalleColorTallas = new List<DetalleColorTalla>();
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
                    cbTallaColor.Enabled = false;
                    break;
                case 2:
                    detalleTallas = tallasRepository.GetTallaListaProducto(_productoId);
                    List<Elemento> elements2 = GetElementsTallas(detalleTallas);
                    CargaComboTalla(elements2);
                    cbColores.Enabled = false;
                    cbTallaColor.Enabled = false;
                    break;
                case 3:
                    detalleColorTallas = tallasyColoresRepository.GetTallaColorListaProducto(_productoId);
                    List<Elemento> elements3 = GetElementsTallasColor(detalleColorTallas);
                    CargaComboTallaColor(elements3);
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

        private void CargaComboTallaColor(List<Elemento> listado)
        {
            cbTallaColor.DataSource = listado;
            cbTallaColor.DisplayMember = "Nombre";
            cbTallaColor.ValueMember = "Id";
            cbTallaColor.SelectedIndex = 0;
            cbTallaColor.Invalidate();
        }

        private List<Elemento> GetElementsTallasColor(List<DetalleColorTalla> detalleColorTallas)
        {
            List<Elemento> nuevalist = new List<Elemento>();
            foreach (DetalleColorTalla item in detalleColorTallas)
            {
                string tmpdet = item.Talla + " - " + item.Color;
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
            _principal.EliminarUltima();
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {         
            if (!Int32.TryParse(txtCantidad.Text, out var a) || txtCantidad.Text == "0")
            {
                KryptonMessageBox.Show("¡Debe ingresar una cantidad valida!", "Advertencia");
            }
            else
            {
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                int stock = Convert.ToInt32(lbStock.Text);
                int stockrestante = stockTotal - stockMinimo;
                if (cantidad > stock || cantidad > stockrestante) 
                {
                    KryptonMessageBox.Show("¡La cantidad ingresada excede el stock minimo o disponible!", "Advertencia");
                }
                else 
                {
                    switch (_opcion)
                    {
                        case 1:
                            _principal.colorSel = obtenerNombre(cbColores);
                            _principal.detcolorId = colorId;
                            _principal.cantidad = cantidad;
                            _principal.ColorTallaSeleccionado();
                            break;
                        case 2:
                            _principal.tallaSel = obtenerNombre(cbTallas);
                            _principal.dettallaId = tallaId;
                            _principal.cantidad = cantidad;
                            _principal.ColorTallaSeleccionado();
                            break;
                        case 3:
                            string[] tmp = obtenerNombre(cbTallaColor).Trim().Split('-');
                            _principal.tallaSel = tmp[0];
                            _principal.colorSel = tmp[1];
                            _principal.dettallacolorId = tallacolorId;
                            _principal.cantidad = cantidad;
                            _principal.ColorTallaSeleccionado();
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

        private void cbTallaColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            tallacolorId = obtenerId(cbTallaColor);
            var tallacolor = detalleColorTallas.Where(x => x.Id == tallacolorId).FirstOrDefault();
            if(tallacolor != null)
            lbStock.Text = tallacolor.Stock.ToString();
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
