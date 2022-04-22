using CapaDatos.ListasPersonalizadas;
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
    public partial class FiltrarBusqueda : BaseContext
    {
        private CapaDatos.Repository.ClientesRepository _clientesRepository = null;
        private IList<ListarClientes> listaClientestodos =>  _clientesRepository.GetList(0);
       // private IList<ListarClientes> clienteListsObtenida = null;

        public FiltrarBusqueda()
        {
            _clientesRepository = new CapaDatos.Repository.ClientesRepository(_context);
            InitializeComponent();
        }

        private void FiltrarBusqueda_Load(object sender, EventArgs e)
        {
            CargarDgv();
        }

       

        public void CargarDgv()
        {

            //clienteListsObtenida = (IList<ListarClientesDgv>)_clientesRepository.GetList(0);
            BindingSource source = new BindingSource();
            source.DataSource = listaClientestodos;
            dgvClientes.DataSource = typeof(List<>);
            dgvClientes.DataSource = source;
            dgvClientes.AutoResizeColumns();

        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {

        
            var filtro = listaClientestodos.Where(a => a.Nombres.Contains(txtbuscar.Text) ||
            (a.Nombres != null && a.Nombres.Contains(txtbuscar.Text)) ||
             (a.Apellidos != null && a.Apellidos.Contains(txtbuscar.Text)) ||
               //(a.codigo? != null && a.codigo.Contains(txtbuscar.Text)) ||
              (a.Apellidos != null && a.Apellidos.Contains(txtbuscar.Text)));
            dgvClientes.DataSource = filtro.ToList();

            
        }
    }
}
