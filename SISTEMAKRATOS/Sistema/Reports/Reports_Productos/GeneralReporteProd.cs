using CapaDatos.ListasPersonalizadas;
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

namespace Sistema.Reports.Reports_Productos
{
    public partial class GeneralReporteProd : BaseContext
    {
        private IList<ListarProductos> _listaproducTodos = null;
        public GeneralReporteProd(IList<ListarProductos> listaReporte)
        {
            _listaproducTodos = listaReporte;
            InitializeComponent();
        }

        private void GeneralReporte_Load(object sender, EventArgs e)
        {
            CargarTabla();
            this.rvProductosGenerales.RefreshReport();
        }

        private void CargarTabla()
        {

            rvProductosGenerales.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Productos.GeneralReporteProd.rdlc";
            var rds1 = new ReportDataSource("listageneralproductos", _listaproducTodos);
            rvProductosGenerales.LocalReport.DataSources.Clear();
            rvProductosGenerales.LocalReport.DataSources.Add(rds1);

        }
    }
}
