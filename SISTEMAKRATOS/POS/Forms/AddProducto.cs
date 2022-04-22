using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Repository;
using ComponentFactory.Krypton.Toolkit;
using POS.Validations;
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
    public partial class AddProducto : BaseContext
    {
        //private ProductosRepository _productosRepository = null;
        //comment for repository github vibe
        private readonly MDIParent1 _mDIParent;

        public AddProducto(MDIParent1 mDI)
        {
            _mDIParent = mDI;
            InitializeComponent();
        }

        private void kryptonPanel2_Paint(object sender, PaintEventArgs e)
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            CargarDgv();
            base.OnLoad(e);
        }


        private void CargarDgv()
        {

            var recargarLista = _mDIParent.AccesoProductoRepository();
            ListadoProductos.ListaDeProductos = recargarLista.GetList(UsuarioLogeadoPOS.User.SucursalId);

            BindingSource source = new BindingSource();
            source.DataSource = ListadoProductos.ListaDeProductos;
            dgListaProductos.DataSource = typeof(List<>);
            dgListaProductos.DataSource = source;
            dgListaProductos.AutoResizeColumns();

        }
        private void btnBuscarP_Click(object sender, EventArgs e)
        {
            AddRowListaProductos();
        }

        private void txtbuscarP_TextChanged(object sender, EventArgs e)
        {
            var ProductoBuscado = ListadoProductos.ListaDeProductos;

            var filter = ProductoBuscado.Where(a => a.Descripcion.Contains(txtbuscarP.Text) ||
            (a.CodigoReferencia != null && a.CodigoReferencia.Contains(txtbuscarP.Text)) ||
            (a.Categoria != null && a.Categoria.Contains(txtbuscarP.Text)) ||
            (a.Notas != null && a.Notas.Contains(txtbuscarP.Text)));
            dgListaProductos.DataSource = filter.ToList();


        }

        private void AddRowListaProductos()
        {
            if (dgListaProductos.Rows.Count == 0) return;
            if (dgListaProductos.CurrentRow == null) return;


            var produc = (ListarProductos)dgListaProductos.CurrentRow.DataBoundItem;
            var producto = ListadoProductos.GetProducto(produc.CodigoReferencia);
            if (producto == null) return;


            // comprueba si el producto ya esta insertado en tabla.
            var comprobarEnTabla = new ComprobarExistenciaEnTabla(_mDIParent.ListaProductSelect);
            _mDIParent.CargarDataGridView(producto, comprobarEnTabla.ComprobarProductoRepetidoFila(producto), true); 

            _mDIParent.ActualizarLabels();
            txtbuscarP.Text = null;
        }

       
    }
}
