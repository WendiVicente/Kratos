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
    public partial class ReporteHorasExtra : BaseContext
    {
       RecursosRepository _recursosRepository = null;
        public ReporteHorasExtra()
        {
            _recursosRepository = new RecursosRepository(_context);
            InitializeComponent();
        }

        private void ReporteHorasExtra_Load(object sender, EventArgs e)
        {
            CargarTabla();
            this.rvhorasextra.RefreshReport();
        }

        private void CargarTabla()
        {
            var listarHoras = _recursosRepository.GetlistHorasExtrase();
            rvhorasextra.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reporte_RRHH.ReporteHorasExtra.rdlc";
            var rds1 = new ReportDataSource("horasextra", listarHoras);
            rvhorasextra.LocalReport.DataSources.Clear();
            rvhorasextra.LocalReport.DataSources.Add(rds1);
        }


    }
}
