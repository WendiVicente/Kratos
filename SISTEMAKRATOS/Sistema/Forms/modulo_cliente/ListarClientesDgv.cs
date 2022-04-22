using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Repository;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models;
using Sistema.Reports.Reports_Clientes;
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
    public partial class ListarClientesDgv : BaseContext
    {
        private ClientesRepository _clientesRepository = null;

        public string filtro;
        public int filtroid = 0;
        private IList<ListarClientes> listaClientestodos => _clientesRepository.GetList(filtroid);
        public ListarClientesDgv()
        {
            _clientesRepository = new ClientesRepository(_context);
            InitializeComponent();
        }

        private void ListarClientes_Load(object sender, EventArgs e)
        {
            RefrescarDataGridClientes(false);
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
            listaClientes.DataSource = typeof(List<>);
            listaClientes.DataSource = source;
            listaClientes.AutoResizeColumns();
            listaClientes.Columns[0].Visible = false;


        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void printPreviewToolStripButton_Click(object sender, EventArgs e)
        {
            BuscarCliente childForm = new BuscarCliente(listaClientes);
            //childForm.MdiParent = this;
            childForm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            RefrescarDataGridClientes(true);
            lbtipocliente.Text = "Todos";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            if (listaClientes.CurrentRow == null)
            {
                return;
            }

            var cliente = (CapaDatos.ListasPersonalizadas.ListarClientes)listaClientes.CurrentRow.DataBoundItem;
            var GetCliente = _clientesRepository.Get(cliente.Codigo);

            DetalleCliente childForm = new DetalleCliente(GetCliente, this);
            childForm.Show();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            if (listaClientes.CurrentRow == null)
            {
                return;
            }

            var dialog = KryptonMessageBox.Show("¿Está seguro que desea eliminar el Cliente ?", "Eliminar cliente",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);
            // dale proba okoko

            if (dialog == DialogResult.Yes)
            {
                var cliente = (CapaDatos.ListasPersonalizadas.ListarClientes)listaClientes.CurrentRow.DataBoundItem;
                var GetCliente = _clientesRepository.Get(cliente.Codigo);
                GetCliente.IsActive = true;
                _clientesRepository.Update(GetCliente);
                RefrescarDataGridClientes(true);

            }

        }

        private void btnlistarfecha_Click(object sender, EventArgs e)
        {
            BuscarFechas childForm = new BuscarFechas(listaClientes);
            childForm.Show();
        }

        private void btntipos_Click(object sender, EventArgs e)
        {
            FiltroTipoCliente childForm = new FiltroTipoCliente(this);
            childForm.Show();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            var filtro = listaClientestodos.Where(a => a.Nombres.Contains(txtbuscar.Text) ||
           (a.Nombres != null && a.Nombres.Contains(txtbuscar.Text)) ||
            (a.Apellidos != null && a.Apellidos.Contains(txtbuscar.Text)) ||
             (a.CodigoCliente != null && a.CodigoCliente.Contains(txtbuscar.Text)) ||
             (a.Nit != null && a.Nit.Contains(txtbuscar.Text)));
            listaClientes.DataSource = filtro.ToList();
        }

        private void txtbuscar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnchangeStado_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row  in listaClientes.Rows)
            {
                var Id = int.Parse(row.Cells[0].Value.ToString());
                var clienteObtenido = _clientesRepository.Get(Id);

                bool estadoActual = Convert.ToBoolean(row.Cells[10].Value);

                if (estadoActual!= clienteObtenido.IsActive)
                {
                    clienteObtenido.IsActive = estadoActual;
                    _clientesRepository.Update(clienteObtenido);

                }
                else
                {

                    _clientesRepository.Update(clienteObtenido);
                }
            }
        }

        private void btnreporteindividual_Click(object sender, EventArgs e)
        {
           // IList<ListarClientes> listatoSend = null;
            var listatoSend = new List<Cliente>();
            if (listaClientes.RowCount <= 0) {  return; }
            int filasSeleccion = 0;
            foreach (DataGridViewRow Rows in listaClientes.Rows)
            {
                var filasTotales = int.Parse(listaClientes.RowCount.ToString());


                bool acciones = Convert.ToBoolean(Rows.Cells[15].Value);
                if (!acciones)
                {
                    filasSeleccion +=1 ;
                }
                else
                {
                    var Id = int.Parse(Rows.Cells[0].Value.ToString());
                    var clienteObtenido = _clientesRepository.Get(Id);
                    //listatoSend = (List<ListarClientes>)listatoSend.Concat(clienteObtenido);
                    listatoSend.Add(clienteObtenido);
                }


                if (filasTotales == filasSeleccion)
                {
                    KryptonMessageBox.Show("Debera tener seleccionada  la columna 'Acciones'\n "
                        + "Selecione un Cliente, dando click en la columna Acciones\n"
                        );

                    return;
                }

            }

            ReporteClientes reporteporcliente = new ReporteClientes(listatoSend);
            reporteporcliente.Show();
               

           
        }
    }
}
