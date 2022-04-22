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
    public partial class NuevaSucursal : BaseContext
    {
        private readonly SucursalesRepository _sucursalesRepository  = null;
        public NuevaSucursal()
        {
            _sucursalesRepository = new SucursalesRepository(_context);
            InitializeComponent();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            var model = GetViewModel();

            if (ModelState.IsValid(model))
            {
                try
                {
                    _sucursalesRepository.Add(model);
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


        public Sucursal GetViewModel()
        {
            return new Sucursal()
            {

                NombreEncargado = txtencargado.Text, 
                NombreSucursal = txtsucursal.Text,
                Telefono = txttelefono.Text,
                Direccion = txtdireccion.Text,
            };
        }


    }
}
