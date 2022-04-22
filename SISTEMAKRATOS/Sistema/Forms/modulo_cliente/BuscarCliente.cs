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

namespace Sistema.Forms.modulo_cliente
{
    public partial class BuscarCliente : BaseContext
    {
        private readonly ClientesRepository _clientesRepository = null;
        private readonly KryptonDataGridView _listarClientes = null;
        // ok segui con actualizar, o refrescar
        public BuscarCliente(KryptonDataGridView datagrid)
        {
            _clientesRepository = new ClientesRepository(_context);
            _listarClientes = datagrid;
            InitializeComponent();
        }

        private void BuscarCliente_Load(object sender, EventArgs e)
        {
           
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            cargarfiltro();
        }

        private void cargarfiltro()
        {
            var clientes = _clientesRepository.GetList(0);

            var filter = clientes.Where(a => a.Nombres != null && a.Nombres.Contains(buscarc.Text) ||
            (a.Apellidos != null && a.Apellidos.Contains(buscarc.Text)) ||
            (a.Telefonos != null && a.Telefonos.Contains(buscarc.Text)) ||
            (a.Nit != null && a.Nit.Contains(buscarc.Text)) ||
            (a.Direccion != null && a.Direccion.Contains(buscarc.Text)) ||
            (a.Alias != null && a.Alias.Contains(buscarc.Text))
            );
            _listarClientes.DataSource = filter.ToList();

        }

        private void btnfiltro_Click(object sender, EventArgs e)
        {
            cargarfiltro();

        }
    }
}
