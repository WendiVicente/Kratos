using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Repository;
using ComponentFactory.Krypton.Toolkit;
using Sistema.Reports.Reports_Productos;
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
    public partial class ListaProductos : BaseContext
    {
        private ProductosRepository _productosRepository = null;


        public ListaProductos()
        {
            _productosRepository = new ProductosRepository(_context);
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            RefrescarDataGridProductos(false);
            base.OnLoad(e);
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
            var Productos = _productosRepository.GetList(UsuarioLogeadoSistemas.User.SucursalId);
            source.DataSource = Productos;
            listproductos.DataSource = typeof(List<>);
            listproductos.DataSource = source;
            listproductos.AutoResizeColumns();
        }

        private void btnDetalleP_Click(object sender, EventArgs e)
        {
            if (listproductos.CurrentRow == null)
            {
                return;
            }

            var producto = (ListarProductos)listproductos.CurrentRow.DataBoundItem;
            var Getproducto = _productosRepository.Get(producto.Id);

            DetalleProducto childForm = new DetalleProducto(Getproducto, this); // me sirve para refrescar el dg cie el thiscunado regrese
            childForm.Show();
        }

        private void buscarprod_Click(object sender, EventArgs e)
        {
            BuscarProducto buscarproducto = new BuscarProducto(listproductos);
            buscarproducto.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            RefrescarDataGridProductos(true); // al refrescar activa el nuevo contexto()

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (listproductos.CurrentRow == null)
            {
                return;
            }

            var dialog = KryptonMessageBox.Show("¿Está seguro que desea eliminar el producto de la lista?", "Eliminar producto",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);
            // dale proba okoko

            if (dialog== DialogResult.Yes)
            {
                var productolista = (ListarProductos)listproductos.CurrentRow.DataBoundItem;
                var productoObtenido = _productosRepository.Get(productolista.Id);
                productoObtenido.Deleted = true;
                _productosRepository.Update(productoObtenido);
                RefrescarDataGridProductos(true);

            }
            

        }

        private void listproductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListaProductos_Load(object sender, EventArgs e)
        {

        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ReporteProducto reporte = new ReporteProducto();
            reporte.Show();

        }
    }
}
