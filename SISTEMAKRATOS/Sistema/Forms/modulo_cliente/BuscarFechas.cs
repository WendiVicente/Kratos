using CapaDatos.Repository;
using ComponentFactory.Krypton.Toolkit;
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
    public partial class BuscarFechas : BaseContext
    {

        private readonly ClientesRepository _clientesRepository = null;
        private readonly KryptonDataGridView _listarClientes = null;
        private DateTime FechaInicio => Convert.ToDateTime(dtpinicio.Value.ToLongDateString());

        private DateTime FechaFinal => Convert.ToDateTime(dtpfin.Value.ToLongDateString());

      //  private IList<ListarClientes> listadeCliente => _clientesRepository.GetListCleintesFecha(FechaInicio, FechaFinal.AddDays(1));
        public BuscarFechas(KryptonDataGridView datagrid)
        {
            _clientesRepository = new ClientesRepository(_context);
            _listarClientes = datagrid;
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            
            var clientes = _clientesRepository.GetListCleintesFecha(FechaInicio, FechaFinal.AddDays(1));

            _listarClientes.DataSource = clientes;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ReporteFechaCliente reporte = new ReporteFechaCliente(FechaInicio, FechaFinal);
            reporte.Show();
        }
    }
}
