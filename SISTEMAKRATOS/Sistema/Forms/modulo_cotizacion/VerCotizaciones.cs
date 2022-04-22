using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Sucursales;
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

namespace Sistema.Forms.modulo_cotizacion
{
    public partial class VerCotizaciones : BaseContext
    {
        private CotizacionRepository _cotizacionRepository = null;
        private SucursalesRepository _sucursalesRepository = null;
        private IList<ListarCotizaciones> _listarcotiz = null;

        public VerCotizaciones()
        {
            _cotizacionRepository = new CotizacionRepository(_context);
            _sucursalesRepository = new SucursalesRepository(_context);
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void VerCotizaciones_Load(object sender, EventArgs e)
        {
            cargarDGV();
            
        }
        public void cargarDGV()
        {
            _listarcotiz = _cotizacionRepository.GetListGenerales(0);
            BindingSource source = new BindingSource();
            source.DataSource = _listarcotiz;
            dgvVales.DataSource = typeof(List<>);
            dgvVales.DataSource = source;
            dgvVales.AutoResizeColumns();
            dgvVales.Columns[0].Visible = false;
            dgvVales.Columns[13].Visible = false;



        }

        private void btncobrar_Click(object sender, EventArgs e)
        {
            if (dgvVales.CurrentRow == null)
            {
                return;
            }

            var pedido = (ListarCotizaciones)dgvVales.CurrentRow.DataBoundItem;


            Editarcotizacion childForm = new Editarcotizacion(pedido); // me sirve para refrescar el dg cie el thiscunado regrese
            childForm.Show();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            var filtro = _listarcotiz.Where(a => a.Nombre.Contains(txtbuscar.Text) ||
           (a.Nombre != null && a.Nombre.Contains(txtbuscar.Text)) ||
            (a.Apellido != null && a.Apellido.Contains(txtbuscar.Text)) ||
            (a.NoCotizacion != null && a.NoCotizacion.Contains(txtbuscar.Text)) ||
             (a.Nit != null && a.Nit.Contains(txtbuscar.Text)) ||
             (a.Cliente != null && a.Cliente.Contains(txtbuscar.Text)));
            dgvVales.DataSource = filtro.ToList();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgvVales.CurrentRow == null)
            {
                return;
            }

            var dialog = KryptonMessageBox.Show("¿Está seguro que desea eliminar esta cotizacion ?", "Eliminar cotizacion",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);
            // dale proba okoko

            if (dialog == DialogResult.Yes)
            {
                var cotiz = (ListarCotizaciones)dgvVales.CurrentRow.DataBoundItem;
                var getcotiz = _cotizacionRepository.GetCotizacion(cotiz.Id);
                getcotiz.IsActive = true;
                _cotizacionRepository.Updatecotizacion(getcotiz);
                cargarDGV();

            }


        }

        private void btnreload_Click(object sender, EventArgs e)
        {
            cargarDGV();
        }
    }
}
