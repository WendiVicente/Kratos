using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Sucursales;
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

namespace Sistema.Forms.modulo_promos
{
    public partial class AgregarMasSucursales : BaseContext
    {
        private SucursalesRepository _sucursalesRepository = null;
        private Promos _promosforms = null;
        public AgregarMasSucursales()
        {
            _sucursalesRepository = new SucursalesRepository(_context);
             InitializeComponent();
        }

      

        private void btnaddTipos_Click(object sender, EventArgs e)
        {
            SucursalesSelected();
            Close();
        }
        private void CargarSucursales()
        {

            var sucursales = _sucursalesRepository.GetList();
            var s = sucursales.OrderBy(a => a.Id).ToList();
            cklistbox.DataSource = s;
            cklistbox.DisplayMember = "NombreSucursal";
            cklistbox.ValueMember = "Id";
            cklistbox.Invalidate();

        }

        private void AgregarMasSucursales_Load(object sender, EventArgs e)
        {
            CargarSucursales();
        }

        private void SucursalesSelected()
        {
            List<ListarSucursales> Listacheckbox = new List<ListarSucursales>();
            foreach (ListarSucursales item in cklistbox.CheckedItems)
            {
                Listacheckbox.Add(item);
            }

            _promosforms.SucursalesSeleccionadas = Listacheckbox;

        }
    }
}
