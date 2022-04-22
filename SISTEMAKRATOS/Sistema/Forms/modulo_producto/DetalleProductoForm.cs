using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Vales;
using CapaDatos.Repository;
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
    public partial class DetalleProductoForm : BaseContext
    {
        private TallasyColoresRepository _tallascoloresRepository = null;
        private ProductosRepository _productosRepository = null;
        private ColoresRepository _coloresRepository = null;
        private TallasRepository _tallasRepository = null;
        private List<ListarDetalleVales> listadetallevale=null;
        private Form FormularioVolver = null;
        private ValesRepository  _valesRepository= null;
        readonly ModuloVales modvales=null;
        readonly Producto _producto;
        private readonly int colAccionesDet=0;

        public int tipoform;
 
        public DetalleProductoForm(ModuloVales form, Producto producto)
        {
            FormularioVolver = form;
            tipoform = 1;
          modvales=form;
            _producto = producto;
            LoadAll();
        }

        private void LoadAll()
        {
            _tallascoloresRepository = new TallasyColoresRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            _coloresRepository = new ColoresRepository(_context);
            _tallasRepository = new TallasRepository(_context);
            listadetallevale = new List<ListarDetalleVales>();
            _valesRepository = new ValesRepository(_context);
            InitializeComponent();
        }

        private void DetalleProductoForm_Load(object sender, EventArgs e)
        {
            CargarDetalles();
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
       
        private void TraerDetalles(int prod)
        {
           
            var productoObtenido = _productosRepository.Get(prod);
            int opcion = ObtenerTipoDetalle(productoObtenido);
            switch (opcion)
            {
                case 1:
                    var listadeColoresProductos = _coloresRepository.GetListaDetalle(productoObtenido.Id);
                    CargarDgvDetalle(listadeColoresProductos);
                    BtnAgregar.Enabled = true;
                    break;
                case 2:
                    var listadeTallaProductos = _tallasRepository.GetListaDetalle(productoObtenido.Id);
                    CargarDgvDetalle(listadeTallaProductos);
                    BtnAgregar.Enabled = true;
                    break;
                case 3:
                    var listadeTallaColorProductos = _tallascoloresRepository.GetListaDetalle(productoObtenido.Id);
                    CargarDgvDetalle(listadeTallaColorProductos);
                    BtnAgregar.Enabled = true;
                    break;
                default:
                    CargarDgvDetalle(new List<ListarDetalle>());
                    BtnAgregar.Enabled = false;
                    break;
            }
        }
        private void CargarDgvDetalle(List<ListarDetalle> listaPrecios)
        {
            BindingSource source = new BindingSource();
            source.DataSource = listaPrecios;
            DgvDetalle.DataSource = typeof(List<>);
            DgvDetalle.DataSource = source;
            DgvDetalle.ClearSelection();
        }
        public void CargarDetalles()
        {
            if (_producto != null)
            {
                
                    TraerDetalles(_producto.Id);
                
            }
        }
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms[FormularioVolver.Name] == null)
            {
                FormularioVolver.Show();
            }
            else
            {
                Application.OpenForms[FormularioVolver.Name].Activate();
            }
            Close();
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

        private void AgregarListarDetallesPedidos(List<ListarDetalle> listadoseleccion)
        {
            foreach (var item in listadoseleccion)
            {
                ListarDetalleVales detallepedido = new ListarDetalleVales
                {
                    ProductoId = item.ProductoId,
                    Cantidad = 1,
                    Color = item.Detalle,
                    Talla = item.Detalle,
                    

                };
              
                var exist = listadetallevale.Find(x => x.ProductoId == detallepedido.ProductoId);
                 if (exist == null)
                    listadetallevale.Add(detallepedido);
                detallepedido.Total = detallepedido.Precio * detallepedido.Cantidad;
            }
          
        }
      
       
        private List<ListarDetalle> SeleccionAcciones()
        {
            List<ListarDetalle> listadoseleccion = new List<ListarDetalle>();
            foreach (DataGridViewRow Rows in DgvDetalle.Rows)
            {
                ListarDetalle product = (ListarDetalle)Rows.DataBoundItem;
                if (product.Acciones)
                {
                    listadoseleccion.Add(product);
                    AgregarListarDetallesPedidos(listadoseleccion);
                }
            }
            return listadoseleccion;
        }
        private void BtnAgregar_Click_1(object sender, EventArgs e)
        {
            AsignarDetalles();
            //List<ListarDetalle> seleccionados = SeleccionAcciones();
            //if (seleccionados.Count > 0)
            //{
            //    AgregarListarDetallesPedidos(seleccionados);


            //}
            //else
            //{
            //    KryptonMessageBox.Show("No hay productos seleccionados", "Advertencia");
            //}


        }


        private void AsignarDetalles()
        {
            switch (tipoform)
            {
                case 1:
                    var listado = SeleccionAcciones();
                    modvales.cargarDetalles(listado);
                    break;
            }
        }
    }
}
