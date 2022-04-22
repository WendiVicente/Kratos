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
    public partial class BuscarSucursal : BaseContext
    {
        private readonly SucursalesRepository _sucursalesRepository = null;
        private readonly KryptonDataGridView _listarsucursales = null;
        public BuscarSucursal(KryptonDataGridView datagrid)
        {
            _sucursalesRepository = new SucursalesRepository(_context);
            _listarsucursales = datagrid;
            InitializeComponent();
        }

        private void BuscarSucursal_Load(object sender, EventArgs e)
        {

        }

        private void buscar_Click(object sender, EventArgs e)
        {
            var clientes = _sucursalesRepository.GetList();

            var filter = clientes.Where(a => a.NombreSucursal != null && a.NombreSucursal.Contains(buscarc.Text) ||
            (a.NombreEncargado != null && a.NombreEncargado.Contains(buscarc.Text)) ||
            (a.Direccion != null && a.Direccion.Contains(buscarc.Text))
            );
            _listarsucursales.DataSource = filter.ToList();
        }
    }
}
