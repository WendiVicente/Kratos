using CapaDatos.ListasPersonalizadas;
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
    public partial class ReporteTiposClientes : BaseContext
    {
        private int idTiposCliente;
        private ClientesRepository _clientesRepository = null;
        
        public ReporteTiposClientes(int tiposIdcliente)
        {
            idTiposCliente = tiposIdcliente;
            _clientesRepository = new ClientesRepository(_context);
            InitializeComponent();
        }

        private void ReporteTiposClientes_Load(object sender, EventArgs e)
        {
            CargarTabla();
          //  Cargarfechas();

            this.rvTiposCliente.RefreshReport();
        }

        private void CargarTabla()
        {
            var listadeclientes = _clientesRepository.GetList(idTiposCliente);
            rvTiposCliente.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Clientes.ReporteTiposClientes.rdlc";
            var rds1 = new ReportDataSource("listarclientes", listadeclientes);
            rvTiposCliente.LocalReport.DataSources.Clear();
            rvTiposCliente.LocalReport.DataSources.Add(rds1);
        }


        private void Cargarparametros()
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                 //new ReportParameter("tiposdecliente",dtFechainicio.Value.ToShortDateString()),
                

            };
            rvTiposCliente.LocalReport.SetParameters(reportParameters);
        }
    }
}
