using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
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

namespace Sistema.Forms.modulo_producto
{
    public partial class SeleccionProductoColor : BaseContext
    {
        private ProductosRepository _productosRepository = null;
        public SeleccionProductoColor()
        {
            _productosRepository = new ProductosRepository(_context);
            InitializeComponent();
        }

        private void AgregarColor_Load(object sender, EventArgs e)
        {
            RefrescarDataGridProductos();
        }

        private void btnDetalleP_Click(object sender, EventArgs e)
        {
            if (dgvProductosColor.CurrentRow == null)
            {
                return;
            }

            var producto = (ListarProductos)dgvProductosColor.CurrentRow.DataBoundItem;
            var Getproducto = _productosRepository.Get(producto.Id);

          //  AgregarColor childForm = new AgregarColor(Getproducto); // me sirve para refrescar el dg cie el thiscunado regrese
           // childForm.Show();
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
            var clientes = _productosRepository.GetListProductosColores(UsuarioLogeadoSistemas.User.SucursalId,true);
            source.DataSource = clientes;
            dgvProductosColor.DataSource = typeof(List<>);
            dgvProductosColor.DataSource = source;
            dgvProductosColor.AutoResizeColumns();
        }



    }
}
