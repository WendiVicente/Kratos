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

namespace Sistema.Forms.modulo_ventas
{
    public partial class BuscarSucursal : BaseContext
    {
       
        private readonly VentasHoy _ventasHoyForm = null;
        

        private readonly SucursalesRepository _sucursalesRepository = null;
        public BuscarSucursal(VentasHoy form) 
        {

            _ventasHoyForm = form;
            _sucursalesRepository = new SucursalesRepository(_context);
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _ventasHoyForm.lbMostrarSucursal.Text = listsucursales.Text;
            var valorCombobox = listsucursales.SelectedValue.ToString();
            _ventasHoyForm.CargarListaVentas(true, Convert.ToInt32(valorCombobox));



        }

        private void BuscarSucursal_Load(object sender, EventArgs e)
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

        private void addsucursal()
        {
            var sucursal = _sucursalesRepository.GetList();

            ListarSucursales nuevasucursal = new ListarSucursales();
            nuevasucursal.Id = 0;
            nuevasucursal.NombreSucursal = "Todas";
            sucursal.Add(nuevasucursal);

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
