using CapaDatos.Models.Sucursales;
using CapaDatos.Repository;
using CapaDatos.Validation;
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
    public partial class DetalleSucursal : BaseContext
    {
        private readonly Sucursal _sucursal = null;
        private readonly SucursalesRepository _sucursalesRepository  = null;
        private readonly ListaSucursales _listaSucursales = null;

        public DetalleSucursal(Sucursal sucursal, ListaSucursales listaSucursalesForm)
        {
            _sucursal = sucursal;
            _sucursalesRepository = new SucursalesRepository(_context);
            _listaSucursales = listaSucursalesForm;
            InitializeComponent();
        }



        private void DetalleSucursal_Load(object sender, EventArgs e)
        {
            CargarModelo();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            var sucursal = _sucursalesRepository.Get(_sucursal.Id);

            var GetSucursal = GetViewModel(sucursal);

            if (ModelState.IsValid(GetSucursal))
            {
                try
                {
                    _sucursalesRepository.Update(GetSucursal);
                    _listaSucursales.RefrescarDataGridSucursales(true);
                    Close();
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK);
                }
            }
            else
            {
                KryptonMessageBox.Show("Hay campos obligatorios sin llenar", "ERROR", MessageBoxButtons.OK);

            }
        }

        private void CargarModelo()
        {
            txtsucursal.Text = _sucursal.NombreSucursal;
            txtdireccion.Text = _sucursal.Direccion;
            txtencargado.Text = _sucursal.NombreEncargado;
            txttelefono.Text = _sucursal.Telefono;

        }

        private Sucursal GetViewModel(Sucursal sucursal)
        {
            sucursal.NombreSucursal = txtsucursal.Text;
            sucursal.Direccion = txtdireccion.Text;
            sucursal.NombreEncargado = txtencargado.Text;
            sucursal.Telefono = txttelefono.Text;


            return sucursal;
        }

    }
}
