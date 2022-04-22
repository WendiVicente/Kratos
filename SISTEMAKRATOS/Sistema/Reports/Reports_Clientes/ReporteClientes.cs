using CapaDatos.ListasPersonalizadas;
using CapaDatos.Repository;
using Microsoft.Reporting.WinForms;
using sharedDatabase.Models;
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
    public partial class ReporteClientes : BaseContext
    {
        private ClientesRepository _clientesRepository = null;
        private List<Cliente> _clienteslista = null;
        public ReporteClientes(List<Cliente> clientes)
        {
            _clienteslista = clientes;
            _clientesRepository = new ClientesRepository(_context);
            InitializeComponent();
        }

        private void ReporteClientes_Load(object sender, EventArgs e)
        {
            CargarTabla();


            this.rvlistaclientesSelect.RefreshReport();
        }

        private void CargarTabla()
        {
            
            var listadeclientes = _clientesRepository.ObtenerClientesSelected();
            // var listaParse= (ListarClientes)_clienteslista
            
            var listafiltrada = new List<ListarClientes>();
            foreach (var item in _clienteslista)
            {
                var id = item.Id;
                var listaObtenida = listadeclientes.Where(a => a.Codigo == id).ToList();
                listafiltrada = listafiltrada.Concat(listaObtenida).ToList();
            }

            rvlistaclientesSelect.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Clientes.ReporteClientes.rdlc";
            var rds1 = new ReportDataSource("listaclientesseleccionados", listafiltrada);
            rvlistaclientesSelect.LocalReport.DataSources.Clear();
            rvlistaclientesSelect.LocalReport.DataSources.Add(rds1);
            



        }




    }
}
