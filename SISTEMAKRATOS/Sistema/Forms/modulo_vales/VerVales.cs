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

namespace Sistema.Forms.modulo_vales
{
    public partial class VerVales : BaseContext
    {
        private ValesRepository _valesRepository = null;
        private IList<ListarVales> listaVales = null;

        public VerVales()
        {
            _valesRepository = new ValesRepository(_context);
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void VerVales_Load(object sender, EventArgs e)
        {
            cargarDGV();
            dgvVales.ClearSelection();
        }

        public void cargarDGV()
        {
             listaVales = _valesRepository.GetListaVales();
            BindingSource source = new BindingSource();
            source.DataSource = listaVales;
            dgvVales.DataSource = typeof(List<>);
            dgvVales.DataSource = source;
            dgvVales.Columns[0].Visible = false;
            dgvVales.AutoResizeColumns();
            dgvVales.ClearSelection();


        }

        private void btncobrar_Click(object sender, EventArgs e)
        {
            if (dgvVales.Rows.Count <= 0)
            {
                KryptonMessageBox.Show("Seleccione un Vale para continuar");
                return;
            }
            else
            {
                var valeFila = (ListarVales)dgvVales.CurrentRow.DataBoundItem;

                if (Application.OpenForms["NuevoVale"] == null)
                {
                    NuevoVale vale = new NuevoVale(valeFila);
                    //vale.MdiParent = this;
                    vale.Show();
                }
                else
                {
                    Application.OpenForms["NuevoVale"].Activate();
                }
            }      
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgvVales.CurrentRow == null)
            {
                return;
            }

            var dialog = KryptonMessageBox.Show("¿Está seguro que desea eliminar este vale ?", "Eliminar Vale",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);
            // dale proba okoko

            if (dialog == DialogResult.Yes)
            {
                var vales = (ListarVales)dgvVales.CurrentRow.DataBoundItem;
                var getcotiz = _valesRepository.GetVale(vales.Id);
               getcotiz.IsActive = true;
                _valesRepository.Update(getcotiz);
                cargarDGV();

            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            cargarDGV();
            dgvVales.ClearSelection();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            var filtro = listaVales.Where(a => a.Descripcion.Contains(txtbuscar.Text) ||
         (a.Descripcion != null && a.Descripcion.Contains(txtbuscar.Text)) ||
          (a.Tipo != null && a.Tipo.Contains(txtbuscar.Text)) 
           );
            dgvVales.DataSource = filtro.ToList();
        }
    }
}
