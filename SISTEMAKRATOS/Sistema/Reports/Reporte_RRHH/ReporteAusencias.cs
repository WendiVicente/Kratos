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
    public partial class ReporteAusencias :BaseContext
    {
        RecursosRepository _recursosRepository = null;
        public ReporteAusencias()
        {
            _recursosRepository = new RecursosRepository(_context);
            InitializeComponent();
        }

        private void ReporteAusencias_Load(object sender, EventArgs e)
        {
            CargarTabla();
            this.rvAusencias.RefreshReport();
        }

        private void CargarTabla()
        {
            var listarAusencias = _recursosRepository.GetlistAusenciaRe();
            rvAusencias.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reporte_RRHH.ReporteAusencias.rdlc";
            var rds1 = new ReportDataSource("ausencias", listarAusencias);
            rvAusencias.LocalReport.DataSources.Clear();
            rvAusencias.LocalReport.DataSources.Add(rds1);
        }

    }
}
