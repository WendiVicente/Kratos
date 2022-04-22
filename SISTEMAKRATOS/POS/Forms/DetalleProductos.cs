using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Precios;
using CapaDatos.Models.Productos;
using CapaDatos.Repository;
using CapaDatos.Repository.PreciosRepository;
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
    public partial class DetalleProductos : BaseContext
    {
        private readonly TallasRepository tallasRepository = null;
        private readonly ColoresRepository coloresRepository = null;
        //private readonly DetalleEstiloRepository estiloRepository = null;
        private readonly TallasyColoresRepository tallasyColoresRepository = null;
        private readonly TipoPrecioRepository tipoPrecioRepository = null;
        private readonly ProductosRepository productosRepository = null;

        private List<DetalleTalla> detalleTallas = null;
        private List<DetalleColor> detalleColors = null;
        //private List<DetalleEstilo> detalleEstilos = null;
        private List<DetalleColorTalla> detalleColorTallas = null;
        private List<ProductoDetalle> productoDetalles = new List<ProductoDetalle>();

        private int _opcion;
        private int _productoId;
        private int stockValidar = 0;
        private bool EliminarUltima = true;
        private int TipoClienteId = 0;
        Producto ProductoLocal;

        private PrincipalV2 _principal = null;

        public DetalleProductos(int opcion, PrincipalV2 principal, int productoId, int TipoCliente)
        {
            _opcion = opcion;
            _principal = principal;
            _productoId = productoId;
            TipoClienteId = TipoCliente;
            tallasRepository = new TallasRepository(_context);
            coloresRepository = new ColoresRepository(_context);
            //estiloRepository = new DetalleEstiloRepository(_context);
            tallasyColoresRepository = new TallasyColoresRepository(_context);
            tipoPrecioRepository = new TipoPrecioRepository(_context);
            productosRepository = new ProductosRepository(_context);
            InitializeComponent();
        }

        private void DetalleProductos_Load(object sender, EventArgs e)
        {
            CargarProducto();
            CargarComboBox();            
        }

        private void CargarComboBox()
        {
            switch (_opcion)
            {
                case 1:
                    detalleColors = coloresRepository.GetProductoListaColor(_productoId);
                    CargarCombo(GetElementsColors(detalleColors));
                    lbDetalle.Text = "Colores";
                    break;
                case 2:
                    detalleTallas = tallasRepository.GetTallaListaProducto(_productoId);
                    CargarCombo(GetElementsTallas(detalleTallas));
                    lbDetalle.Text = "Tallas";
                    break;
                case 3:
                    detalleColorTallas = tallasyColoresRepository.GetTallaColorListaProducto(_productoId);
                    CargarCombo(GetElementsTallasColor(detalleColorTallas));
                    lbDetalle.Text = "Color y Talla";
                    break;
                case 4:
                    //detalleEstilos = estiloRepository.GetProductoListaEstilo(_productoId);
                    //CargarCombo(GetElementsEstilos(detalleEstilos));
                    lbDetalle.Text = "Estilos";
                    break;
            }
        }

        private void CargarProducto()
        {
            ProductoLocal = productosRepository.Get(_productoId);
            lbProd.Text = ProductoLocal.Descripcion;
        }

        private void CbDetalles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbDetalles.SelectedItem != null)
            {
                Elemento elemento = (Elemento)CbDetalles.SelectedItem;
                switch (_opcion)
                {
                    case 1:
                        DetalleColor color = coloresRepository.GetDetalleColor(elemento.Id);
                        lbStock.Text = "Existencias " + color.Stock;
                        stockValidar = color.Stock;
                        break;
                    case 2:
                        DetalleTalla talla = tallasRepository.GetDetalleTalla(elemento.Id);
                        lbStock.Text = "Existencias " + talla.Stock;
                        stockValidar = talla.Stock;
                        break;
                    case 3:
                        DetalleColorTalla colortalla = tallasyColoresRepository.GetColorTalla(elemento.Id);
                        lbStock.Text = "Existencias " + colortalla.Stock;
                        stockValidar = colortalla.Stock;
                        break;
                    case 4:
                        //DetalleEstilo estilo = estiloRepository.GetDetalleEstilo(elemento.Id);
                        //lbStock.Text = "Existencias " + estilo.Stock;
                        //stockValidar = estilo.Stock;
                        break;
                }
            }
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void BtnAgregarLista_Click(object sender, EventArgs e)
        {
            if (!comprobarElemento(DgvListaDetalles, CbDetalles.Text))
            {
                if (TxtCantidad.Text != "")
                {
                    int number;
                    if (Int32.TryParse(TxtCantidad.Text, out number))
                    {
                        int cantidad = Convert.ToInt32(TxtCantidad.Text);
                        Elemento elemento = (Elemento)CbDetalles.SelectedItem;
                        if (cantidad <= stockValidar)
                        {
                            ProductoDetalle detalle = new ProductoDetalle
                            {
                                ProductoId = _productoId,
                                DetalleId = elemento.Id,
                                Detalle = elemento.Nombre,
                                Cantidad = cantidad,
                            };
                            productoDetalles.Add(detalle);
                            TxtCantidad.Text = "";
                            CargarDGVDetalle();
                            MostrarTotalAceptar();
                        }
                        else
                        {
                            MessageBox.Show("El valor ingresado excede las existencias.", "Notificación");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El valor ingresado no es válido.", "Notificación");
                    }
                }
                else
                {
                    MessageBox.Show("El campo cantidad esta vacio.", "Notificación");
                }
            }
        }

        private bool comprobarElemento(DataGridView datag, string detalle)
        {
            foreach (DataGridViewRow row in datag.Rows)
            {
                if (row.Cells[2].Value.ToString() == detalle)
                {
                    return true;
                }
            }
            return false;
        }

        private void CargarDGVDetalle()
        {
            DgvListaDetalles.DataSource = typeof(List<>);
            DgvListaDetalles.DataSource = productoDetalles;
            DgvListaDetalles.ClearSelection();  
        }

        private void MostrarTotalAceptar()
        {
            if (productoDetalles.Count() > 0)
            {
                int cantidad = productoDetalles.Sum(x => x.Cantidad);
                lbTotal.Text = "Total: " + cantidad;
                BtnAceptar.Enabled = true;
            }
            else
            {
                lbTotal.Text = "Total: 0";
                BtnAceptar.Enabled = false;
            }
        }

        private void BtnEliminarLista_Click(object sender, EventArgs e)
        {
            if(DgvListaDetalles.CurrentRow != null)
            {
                var fila = DgvListaDetalles.CurrentRow;
                ProductoDetalle detalle = (ProductoDetalle)fila.DataBoundItem;
                productoDetalles.Remove(detalle);
                CargarDGVDetalle();
                MostrarTotalAceptar();
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            List<ListarDetalleFacturas> detalleFacturas = GetListadoProductos();
            AsignarPrecioEscala(detalleFacturas);
            foreach (ListarDetalleFacturas detalleFactura in detalleFacturas)
            {
                _principal._listaDetalleFacturas.Add(detalleFactura);
            }
            _principal.cargarDGVDetalleFactura(_principal._listaDetalleFacturas);
            EliminarUltima = false;
            Close();
        }

        private void CargarCombo(List<Elemento> elementos)
        {
            CbDetalles.DataSource = elementos;
            CbDetalles.DisplayMember = "Nombre";
            CbDetalles.ValueMember = "Id";
            CbDetalles.Invalidate();            
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
            foreach (DetalleColor item in detalleColors)
            {
                nuevalist.Add(new Elemento(item.Id, item.Color));
            }
            return nuevalist;
        }

        //private List<Elemento> GetElementsEstilos(List<DetalleEstilo> detalleEstilos)
        //{
        //    List<Elemento> nuevalist = new List<Elemento>();
        //    foreach (DetalleEstilo item in detalleEstilos)
        //    {
        //        nuevalist.Add(new Elemento(item.Id, item.Estilo));
        //    }
        //    return nuevalist;
        //}

        private List<ListarDetalleFacturas> GetListadoProductos()
        {
            List<ListarDetalleFacturas> listado = new List<ListarDetalleFacturas>();
            ListarDetalleFacturas productoFactura;
            foreach (ProductoDetalle detalle in productoDetalles)
            {
                productoFactura = new ListarDetalleFacturas
                {
                    ProductoId = detalle.ProductoId,
                    Descripcion = ProductoLocal.Descripcion,
                    Cantidad = detalle.Cantidad,
                    Precio = ProductoLocal.PrecioVenta,
                    SubTotal = ProductoLocal.PrecioVenta * detalle.Cantidad,
                    PrecioTotal = ProductoLocal.PrecioVenta * detalle.Cantidad,
                };

                switch (_opcion)
                {
                    case 1:
                        productoFactura.DetalleColorId = detalle.DetalleId;
                        productoFactura.Color = detalle.Detalle;
                        break;
                    case 2:
                        productoFactura.DetalleTallaId = detalle.DetalleId;
                        productoFactura.Talla = detalle.Detalle;
                        break;
                    case 3:
                        productoFactura.TallayColorId = detalle.DetalleId;
                        string[] colorytalla = detalle.Detalle.Split('-');
                        productoFactura.Talla = colorytalla[0];
                        productoFactura.Color = colorytalla[1];
                        break;
                    case 4:
                        //productoFactura.EstiloId = detalle.DetalleId;
                        //productoFactura.Estilo = detalle.Detalle;
                        break;
                }
                listado.Add(productoFactura);
            }
            return listado;
        }

        private void AsignarPrecioEscala(List<ListarDetalleFacturas> detalleFacturas)
        {
            decimal PrecioEscala = 0.00m;
            if (ProductoLocal.TieneEscalas == true)
            {
                var tipoprecio = tipoPrecioRepository.Get(_productoId);
                var detalles = tipoPrecioRepository.GetDetallePrecios(tipoprecio.Id);
                int Cantidad = detalleFacturas.Sum(x => x.Cantidad);
                if (detalles.Count > 0)
                {
                    detalles = detalles.OrderBy(x => x.RangoInicio).ToList();
                    foreach (DetallePrecio detalle in detalles)
                    {
                        if (detalle.TiposId == TipoClienteId)
                        {
                            if (Cantidad >= detalle.RangoInicio && Cantidad <= detalle.RangoFinal)
                            {
                                PrecioEscala = detalle.Precio;
                            }
                        }                        
                    }

                    if (PrecioEscala == 0.00m)
                    {
                        PrecioEscala = ProductoLocal.PrecioVenta;
                    }

                    foreach (ListarDetalleFacturas detalle1 in detalleFacturas)
                    {
                        detalle1.Precio = PrecioEscala;
                        detalle1.SubTotal = detalle1.Cantidad * detalle1.Precio;
                        detalle1.PrecioTotal = detalle1.SubTotal - detalle1.Descuento;
                    }
                }
            }
        }

        private void DetalleProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (EliminarUltima)
            {
                //_principal.EliminarUltima();
            }
        }
    }

    public class ProductoDetalle
    {
        public ProductoDetalle()
        { }
        public int ProductoId { get; set; }
        public int DetalleId { get; set; }
        public string Detalle { get; set; }
        public int Cantidad { get; set; }        
    }
}
