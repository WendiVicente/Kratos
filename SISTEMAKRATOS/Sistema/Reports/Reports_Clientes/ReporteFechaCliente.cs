using CapaDatos.Repository;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Reports.Reports_Clientes
{
    public partial class ReporteFechaCliente : BaseContext
    {
       // private int idTiposCliente;
        private ClientesRepository _clientesRepository = null;
        private DateTime fechaInicio, fechaFinal;
        public ReporteFechaCliente(DateTime FechaInicio, DateTime FechaFinal)
        {
            fechaInicio = FechaInicio;
            fechaFinal = FechaFinal;
            _clientesRepository = new ClientesRepository(_context);
            InitializeComponent();
        }

        private void ReporteFechaCliente_Load(object sender, EventArgs e)
        {
            CargarTabla();
            this.rvfechacliente.RefreshReport();
        }


        private void CargarTabla()
        {
            var listadeclientes = _clientesRepository.GetListCleintesFecha(fechaInicio, fechaFinal.AddDays(1));
            rvfechacliente.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Clientes.ReporteFechaCliente.rdlc";
            var rds1 = new ReportDataSource("ClientesFecha", listadeclientes);
            rvfechacliente.LocalReport.DataSources.Clear();
            rvfechacliente.LocalReport.DataSources.Add(rds1);
        }
    }
}
