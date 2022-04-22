using CapaDatos.ListasPersonalizadas;
using CapaDatos.Repository;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_Pedidos
{
    public partial class VerPedidos : BaseContext
    {
        private PedidoRepository _pedidoRepository = null;
        private IList<ListarPedidos> listaPedido = null;
        public VerPedidos()
        {
            _pedidoRepository = new PedidoRepository(_context);
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void VerPedidos_Load(object sender, EventArgs e)
        {
            cargarDGV();
        }

        public void cargarDGV()
        {


            listaPedido = _pedidoRepository.GetListGenerales(0);
            BindingSource source = new BindingSource();
            source.DataSource = listaPedido;
            dgvPedidos.DataSource = typeof(List<>);
            dgvPedidos.DataSource = source;
            dgvPedidos.AutoResizeColumns();


        }

        private void btndetalle_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow == null)
            {
                return;
            }

            var pedido = (ListarPedidos)dgvPedidos.CurrentRow.DataBoundItem;
          

            DetallesVista childForm = new DetallesVista(pedido); // me sirve para refrescar el dg cie el thiscunado regrese
            childForm.Show();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow == null)
            {
                return;
            }

            var dialog = KryptonMessageBox.Show("¿Está seguro que desea eliminar este pedido ?", "Eliminar pedido",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);
            // dale proba okoko

            if (dialog == DialogResult.Yes)
            {
                var pedido = (ListarPedidos)dgvPedidos.CurrentRow.DataBoundItem;
                var gepedido = _pedidoRepository.GetPedido(pedido.Id);
                gepedido.IsActive = true;
                _pedidoRepository.UpdatePedido(gepedido);
                cargarDGV();

            }
        }

        private void btnreload_Click(object sender, EventArgs e)
        {
            cargarDGV();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            var filtro = listaPedido.Where(a => a.Cliente.Contains(txtbuscar.Text) ||
            (a.Cliente != null && a.Cliente.Contains(txtbuscar.Text)) ||
             (a.NombreVendedor != null && a.NombreVendedor.Contains(txtbuscar.Text)) 
            );
            dgvPedidos.DataSource = filtro.ToList();

        }
    }
}
