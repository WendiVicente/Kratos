using CapaDatos.Repository.RrhhRepository;
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

namespace Sistema.Reports.Reporte_RRHH
{
    public partial class ReporteLlegadasTarde : BaseContext
    {
        RecursosRepository _recursosRepository = null;
        public ReporteLlegadasTarde()
        {
            _recursosRepository = new RecursosRepository(_context);
            InitializeComponent();
        }

        private void ReporteLlegadasTarde_Load(object sender, EventArgs e)
        {
            CargarTabla();
            this.llegadastarde.RefreshReport();
        }


        private void CargarTabla()
        {
            var listaderetrasos = _recursosRepository.GetlistRetrasos();
            llegadastarde.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reporte_RRHH.ReporteLlegadasTarde.rdlc";
            var rds1 = new ReportDataSource("llegadastarde", listaderetrasos);
            llegadastarde.LocalReport.DataSources.Clear();
            llegadastarde.LocalReport.DataSources.Add(rds1);
        }


    }
}
