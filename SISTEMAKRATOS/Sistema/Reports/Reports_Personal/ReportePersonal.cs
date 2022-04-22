using CapaDatos.ListasPersonalizadas;
using Microsoft.Reporting.WinForms;
using Sistema.Forms.modulo_personal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Reports.Reports_Personal
{
    public partial class ReportePersonal : BaseContext
    {
        private IList<ListarPersonal> listaProveedores = null;
        private VerPersonal _verPersonal = null;
        private string fechainit;
        private string fechafinal;
        private string estadoActual;
        public ReportePersonal(IList<ListarPersonal> listaRecibida, VerPersonal forms)
        {
            listaProveedores = listaRecibida;
            _verPersonal = forms;
            InitializeComponent();
            fechainit = _verPersonal.fechaInicio.ToString();
            fechafinal = _verPersonal.fechaFinal.ToString();
            estadoActual = _verPersonal.estadocliente;
        }

        private void ReportePersonal_Load(object sender, EventArgs e)
        {
            CargarTabla();
            cargarTextbox();
            
            this.rvpersonal.RefreshReport();
        }
        private void CargarTabla()
        {

            rvpersonal.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Personal.ReportePersonal.rdlc";
            var rds1 = new ReportDataSource("personal", listaProveedores);
            rvpersonal.LocalReport.DataSources.Clear();
            rvpersonal.LocalReport.DataSources.Add(rds1);

        }

        public void cargarTextbox()
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                new ReportParameter("fechainicio",fechainit),
                new ReportParameter("fechafinal",fechafinal),
                new ReportParameter("estado",estadoActual),
            };
            rvpersonal.LocalReport.SetParameters(reportParameters);

        }


    }
}
