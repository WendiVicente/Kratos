using CapaDatos.ListasPersonalizadas;
using Microsoft.Reporting.WinForms;
using Sistema.Forms.modulo_proveedor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Reports.Reports_Proveedores
{
    public partial class ReporteProveedoresGeneral : BaseContext
    {
        private IList<ListarProveedores> listaProveedores = null;
        private VerProveedores _verProveedores = null;
        private string fechainit;
        private string fechafinal;
        private string estadoActual;
        
        public ReporteProveedoresGeneral(IList<ListarProveedores> listaRecibida,VerProveedores forms)
        {
            listaProveedores = listaRecibida;
            _verProveedores = forms;
            InitializeComponent();
            fechainit = _verProveedores.fechaInicio.ToString();
            fechafinal = _verProveedores.fechaFinal.ToString();
            estadoActual = _verProveedores.estadocliente;


        }

        private void ReporteProveedoresGeneral_Load(object sender, EventArgs e)
        {
            CargarTabla();
            cargarTextbox();
            this.rvProveedores.RefreshReport();
        }
        private void CargarTabla()
        {

            rvProveedores.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Proveedores.ReporteProveedoresGeneral.rdlc";
            var rds1 = new ReportDataSource("listageneralproveedores", listaProveedores);
            rvProveedores.LocalReport.DataSources.Clear();
            rvProveedores.LocalReport.DataSources.Add(rds1);

        }
        public void cargarTextbox()
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
              
                 new ReportParameter("fechainicio",fechainit),
                  new ReportParameter("fechafinal",fechafinal),
                 //  new ReportParameter("sucursal",_verProveedores.idsucursal.ToString()),
                    new ReportParameter("estado",estadoActual),

            };
            rvProveedores.LocalReport.SetParameters(reportParameters);

        }

    }
}
