using CapaDatos.Data;
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

namespace Sistema.Forms.modulo_Prestamos
{
    public partial class ElegirCliente : BaseContext
    {
        private ClientesRepository _clientesRepository = null;
        public int filtroid = 0;
        private IList<ListarClientes> listaClientestodos => _clientesRepository.GetList(filtroid);
        private RegistroDesembolso _formRegistro = null;
        public ElegirCliente(RegistroDesembolso registroDesembolso)
        {
            InitializeComponent();
            _formRegistro = registroDesembolso;
            _clientesRepository = new ClientesRepository(_context);
        }

        private void ElegirCliente_Load(object sender, EventArgs e)
        {
            RefrescarDataGridClientes(true);
        }

        private void dgvclientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //var 
        }

        public void RefrescarDataGridClientes(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _clientesRepository = null;
                _clientesRepository = new ClientesRepository(_context);
            }

            BindingSource source = new BindingSource();
            // var clientes = _clientesRepository.GetList(filtroid);
            source.DataSource = listaClientestodos;
            dgvclientes.DataSource = typeof(List<>);
            dgvclientes.DataSource = source;
            dgvclientes.AutoResizeColumns();
            dgvclientes.Columns[0].Visible = false;


        }

        private void txtbuscarcl_TextChanged(object sender, EventArgs e)
        {
            var filtro = listaClientestodos.Where(a => a.Nombres.Contains(txtbuscarcl.Text) ||
         (a.Nombres != null && a.Nombres.Contains(txtbuscarcl.Text)) ||
          (a.Apellidos != null && a.Apellidos.Contains(txtbuscarcl.Text)) ||
           (a.CodigoCliente != null && a.CodigoCliente.Contains(txtbuscarcl.Text)) ||
           (a.Nit != null && a.Nit.Contains(txtbuscarcl.Text)));
            dgvclientes.DataSource = filtro.ToList();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (dgvclientes.CurrentRow != null)
            {
                var clienteFila = (ListarClientes)dgvclientes.CurrentRow.DataBoundItem;


                _formRegistro.clienteActual = clienteFila;
                _formRegistro.CargarClientetxts();
            }
        }
    }
}
