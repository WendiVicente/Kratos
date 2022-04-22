using CapaDatos.Data;
using CapaDatos.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos.ListasPersonalizadas;
using ComponentFactory.Krypton.Toolkit;
using POS.Validations;

namespace Sistema.Forms.modulo_compras
{
    public partial class AddProductoComp : BaseContext
    {
        private ProductosRepository _productosRepository = null;
        private readonly ModuloCompras _solicitudCompra = null;
        public AddProductoComp(ModuloCompras solicitudCompra)
        {
            _solicitudCompra = solicitudCompra;
            _productosRepository = new ProductosRepository(_context);
            InitializeComponent();
        }


        public void CargarDgv()
        {

            var recargarLista = _solicitudCompra.AccesoProductoRepository();

            ListadoProductosC.ListaDeProductos = recargarLista.GetList(UsuarioLogeadoSistemas.User.SucursalId);

            BindingSource source = new BindingSource();
            source.DataSource = ListadoProductosC.ListaDeProductos;
            dgListaProductos.DataSource = typeof(List<>);
            dgListaProductos.DataSource = source;
            //dgListaProductos.AutoResizeColumns();

        }

        private void txtbuscarP_TextChanged(object sender, EventArgs e)
        {
            var ProductoBuscado = ListadoProductosC.ListaDeProductos;
            var filter = ProductoBuscado.Where(a => a.Descripcion.Contains(txtbuscarP.Text) ||
            (a.CodigoReferencia != null && a.CodigoReferencia.Contains(txtbuscarP.Text)) ||
            (a.Categoria != null && a.Categoria.Contains(txtbuscarP.Text)) ||
            (a.Notas != null && a.Notas.Contains(txtbuscarP.Text)));
            dgListaProductos.DataSource = filter.ToList();
        }
        public  void AddRowListaProductos()
        {
            if (dgListaProductos.Rows.Count == 0) return;
            if (dgListaProductos.CurrentRow == null) return;


            var produc = (ListarProductos)dgListaProductos.CurrentRow.DataBoundItem;
            var producto = ListadoProductosC.GetProducto(produc.CodigoReferencia);
            if (producto == null) return;


            // comprueba si el producto ya esta insertado en tabla.
            var comprobarEnTabla = new ComprobarExistenciaEnTabla(_solicitudCompra.ListaProductSelect);
            _solicitudCompra.CargarDataGridView(producto, comprobarEnTabla.ComprobarProductoRepetidoFila(producto));

          //  _solicitudCompra.ActualizarLabels();
            txtbuscarP.Text = null;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AddRowListaProductos();
            _solicitudCompra.ActualizarLabelTotal();
        }

        private void AddProductoComp_Load(object sender, EventArgs e)
        {
            CargarDgv();
        }
    }
}
