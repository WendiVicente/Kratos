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

namespace Sistema.Forms.modulo_Sucursales
{
    public partial class ListaSucursales : BaseContext
    {
        private SucursalesRepository _sucursalesRepository  = null;
        public ListaSucursales()
        {
            _sucursalesRepository = new SucursalesRepository(_context);
            InitializeComponent();
        }



       

        private void ListaSucursales_Load(object sender, EventArgs e)
        {
            RefrescarDataGridSucursales(true);
        }

        private void BuscarSucursal_Click(object sender, EventArgs e)
        {
            BuscarSucursal childForm = new BuscarSucursal(dglistasucursales);
            childForm.Show();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dglistasucursales.CurrentRow == null)
            {
                return;
            }

            var dialog = KryptonMessageBox.Show("¿Está seguro que desea eliminar la sucursal de la lista?", "Eliminar sucursal",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);
            // dale proba okoko

            if (dialog == DialogResult.Yes)
            {
                var productolista = (ListarSucursales)dglistasucursales.CurrentRow.DataBoundItem;
                var productoObtenido = _sucursalesRepository.Get(productolista.Id);
                productoObtenido.IsActive = true;
                _sucursalesRepository.Update(productoObtenido);
                RefrescarDataGridSucursales(true);

            }

        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (dglistasucursales.CurrentRow == null)
            {
                return;
            }

            var sucursal = (CapaDatos.ListasPersonalizadas.ListarSucursales)dglistasucursales.CurrentRow.DataBoundItem;
            var Getsucursal = _sucursalesRepository.Get(sucursal.Id);

            DetalleSucursal childForm = new DetalleSucursal(Getsucursal, this);
            childForm.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            RefrescarDataGridSucursales(true);
        }


        public void RefrescarDataGridSucursales(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _sucursalesRepository = null;
                _sucursalesRepository = new SucursalesRepository(_context);
            }

            BindingSource source = new BindingSource();

            source.DataSource = _sucursalesRepository.GetList();
            dglistasucursales.DataSource = typeof(List<>);
            dglistasucursales.DataSource = source;
            dglistasucursales.AutoResizeColumns();


        }
    }
}
