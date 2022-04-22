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

namespace Sistema.Forms.modulo_recepcion
{
    public partial class BuscarPorSucursales : BaseContext
    {
        private readonly VerRecepciones _verRecepciones = null;
        private SucursalesRepository _sucursalesRepository = null;
        public BuscarPorSucursales(VerRecepciones recepciones)
        {
            _verRecepciones = recepciones;
            _sucursalesRepository = new SucursalesRepository(_context);
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _verRecepciones.lbsucursal.Text = listsucursales.Text;
            var valorCombobox = listsucursales.SelectedValue.ToString();
            _verRecepciones.sucursalvalor = Convert.ToInt32(valorCombobox);
            _verRecepciones.RefrescarDataGridCompras(true);
        }

        private void BuscarPorSucursales_Load(object sender, EventArgs e)
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

        private void listsucursales_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonHeader1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
