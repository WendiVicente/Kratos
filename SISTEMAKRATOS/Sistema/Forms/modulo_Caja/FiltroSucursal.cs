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

namespace Sistema.Forms.modulo_Caja
{
    public partial class FiltroSucursal : BaseContext
    {
        private VerCajas _verCajas = null;
        private SucursalesRepository _sucursalesRepository = null;
        public FiltroSucursal(VerCajas verCajas)
        {
            _sucursalesRepository = new SucursalesRepository(_context);
            _verCajas = verCajas;
            InitializeComponent();
            CargarCombox();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (listsucursales.Items.Count <= 0) { KryptonMessageBox.Show("No hay ninguna sucursal"); return; }
            CallSucursal();
        }

        private void CargarCombox()
        {
            var sucursal = _sucursalesRepository.GetList();

            // agregar nuevo item a la lista
            sucursal.Add(new ListarSucursales { Id = 0, NombreSucursal = "Todas" });
            var s = sucursal.OrderBy(a => a.Id).ToList();

            // mostrar datos en dgv
            listsucursales.DataSource = s;
            listsucursales.DisplayMember = "NombreSucursal";
            listsucursales.ValueMember = "Id";
            listsucursales.Text = "Seleccione una Sucursal"; // esto no jalo? no me jalo
            listsucursales.SelectedIndex = 0;
            listsucursales.Invalidate();
        }

        private void CallSucursal()
        {
            _verCajas.lbMostrarSucursal.Text = listsucursales.Text;
            var valorCombobox = listsucursales.SelectedValue.ToString();
            _verCajas.sucursalvalor = Convert.ToInt32(valorCombobox);
            _verCajas.RefrescardgCajas(true);
        }

        private void FiltroSucursal_Load(object sender, EventArgs e)
        {

        }
    }
}
