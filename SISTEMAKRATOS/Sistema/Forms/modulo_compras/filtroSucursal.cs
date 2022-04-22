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

namespace Sistema.Forms.modulo_compras
{
    public partial class filtroSucursal : BaseContext
    {
        private readonly VerCompras _verCompras = null;
        private SucursalesRepository _sucursalesRepository = null;
        public filtroSucursal(VerCompras verCompras)
        {
            _sucursalesRepository = new SucursalesRepository(_context);
            _verCompras = verCompras;
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _verCompras.lbMostrarSucursal.Text = listsucursales.Text;
            var valorCombobox = listsucursales.SelectedValue.ToString();
            
            _verCompras.RefrescarDataGridCompras(true, Convert.ToInt32(valorCombobox));
        }

        private void filtroSucursal_Load(object sender, EventArgs e)
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
    }
}
