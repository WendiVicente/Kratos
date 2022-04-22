using CapaDatos.Data;
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

namespace Sistema.Forms.modulo_promos
{
    public partial class VerPromos : BaseContext
    {
        private PromocionRepository _promocionRepository = null;
        private IList<ListarPromocion> promocion = null;
        public VerPromos()
        {
            _promocionRepository = new PromocionRepository(_context);
            InitializeComponent();
        }

        private void VerPromos_Load(object sender, EventArgs e)
        {
            RefrescarDataGridPromos(true);
        }

        public void RefrescarDataGridPromos(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _promocionRepository = null;
                _promocionRepository = new PromocionRepository(_context);
            }

            BindingSource source = new BindingSource();
            promocion = _promocionRepository.GetlistPromocion();
            source.DataSource = promocion;
            dgvpromos.DataSource = typeof(List<>);

            dgvpromos.DataSource = source;
            dgvpromos.AutoResizeColumns();
            dgvpromos.Columns[0].Visible = false;
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            var filtro = promocion.Where(a => a.Descripcion.Contains(txtbuscar.Text) ||
         (a.Descripcion != null && a.Descripcion.Contains(txtbuscar.Text))
           );
            dgvpromos.DataSource = filtro.ToList();
        }

       

        private void btnDetalleP_Click(object sender, EventArgs e)
        {
            if (dgvpromos.CurrentRow == null)
            {
                return;
            }

            var promo = (ListarPromocion)dgvpromos.CurrentRow.DataBoundItem;
            var Getpromo = _promocionRepository.Get(promo.Id);

            if (Application.OpenForms["VerDetallePromo"] == null)
            {
                VerDetallePromo vale = new VerDetallePromo(promo);
                
                vale.Show();
            }
            else
            {
                Application.OpenForms["VerDetallePromo"].Activate();
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            RefrescarDataGridPromos();
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvpromos.CurrentRow == null)
            {
                return;
            }

            var dialog = KryptonMessageBox.Show("¿Está seguro que desea eliminar la promocion de la lista?", "Eliminar combo",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);
            // dale proba okoko

            if (dialog == DialogResult.Yes)
            {
                var promofila = (ListarPromocion)dgvpromos.CurrentRow.DataBoundItem;
                var promoobtenido = _promocionRepository.Get(promofila.Id);
                promoobtenido.IsActive = true;
                _promocionRepository.Update(promoobtenido);
                _promocionRepository.DeleteDetalles(promofila.Id);
                RefrescarDataGridPromos(true);

            }
        }


    }
}
