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

namespace Sistema.Forms.modulo_ventas
{
    public partial class BuscarSucursalGenerales : BaseContext
    {
        private readonly VentasGenerales _ventasGenerales = null;
        private readonly SucursalesRepository _sucursalesRepository = null;
        public BuscarSucursalGenerales(VentasGenerales ventasGenerales)
        {
            _sucursalesRepository = new SucursalesRepository(_context);
            _ventasGenerales = ventasGenerales;
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _ventasGenerales.lbMostrarSucursal.Text = listsucursales.Text;
            var valorCombobox = listsucursales.SelectedValue.ToString();
            _ventasGenerales.SucursalIdtoSearch = Convert.ToInt32(valorCombobox);
            _ventasGenerales.CargarListaVentas(true, Convert.ToInt32(valorCombobox));
        }

        private void BuscarSucursalGenerales_Load(object sender, EventArgs e)
        {
            var sucursal = _sucursalesRepository.GetList();

            // agregar nuevo item a la lista
            sucursal.Add(new ListarSucursales { Id = 0, NombreSucursal = "Todas" });
            var s = sucursal.OrderBy(a => a.Id).ToList();

            // mostrar datos en dgv
            listsucursales.DataSource = s;
            listsucursales.DisplayMember = "NombreSucursal";
            listsucursales.ValueMember = "Id";
           
            listsucursales.SelectedIndex = 0;
            listsucursales.Invalidate();
        }
    }

}
