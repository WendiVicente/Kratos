using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.DocumentoSAT;
using CapaDatos.Repository;
using Microsoft.Reporting.WinForms;
using Sistema.Forms.modulo_Ccobrar;
using Sistema.Forms.modulo_cliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Reports.Reporte_Facturacion
{
    public partial class ReporteFactura : BaseContext
    {
        private readonly FacturasRepository _facturasRepository = null;
        private IList<ListarDetalleFacturas> listadetalles = null;
        private readonly DocumentoCertificadoSAT DocCertificado = null;
        private ModuloClientes pagoForms = null;
        private Guid idfactura;
        public ReporteFactura(ModuloClientes forms,Guid idfac,DocumentoCertificadoSAT DocCertif)
        {
            pagoForms = forms;
            idfactura = idfac;
            DocCertificado = DocCertif;
            _facturasRepository = new FacturasRepository(_context);
            InitializeComponent();
        }

        private void ReporteFactura_Load(object sender, EventArgs e)
        {
            if (DocCertificado != null)
            {
                CargarTabla();
                traerparametros();
                this.rvFactura.RefreshReport();
            }
           
        }
        private void CargarTabla()
        {
            listadetalles = _facturasRepository.GetDetallebyFactura(idfactura);

            rvFactura.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reporte_Facturacion.ReporteFactura.rdlc";
            var rds1 = new ReportDataSource("detallefactura", listadetalles);
            rvFactura.LocalReport.DataSources.Clear();
            rvFactura.LocalReport.DataSources.Add(rds1);

        }


        private void traerparametros()
        {
            decimal iva = 0.10714284m;
            var sumatotal = listadetalles.Sum(x => x.PrecioTotal);
            var direccionCl = _facturasRepository.Get(idfactura);
            var ivatotal = sumatotal * iva;

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                new ReportParameter("noautorizacion",DocCertificado.Autorizacion ),
                new ReportParameter("nombrecomprador",DocCertificado.NOMBRE_COMPRADOR),
                  new ReportParameter("nitcomprador",DocCertificado.NIT_COMPRADOR),
                   new ReportParameter("direcomprador",direccionCl.Direccion),
                new ReportParameter("serie" ,DocCertificado.Serie),
                new ReportParameter("numero",DocCertificado.NUMERO),
                 new ReportParameter("nombreeface", DocCertificado.NOMBRE_EFACE),
                  new ReportParameter("niteface", DocCertificado.NIT_EFACE),
                new ReportParameter("ivatotal",ivatotal.ToString("0.0000")),
                new ReportParameter("totalfactura",sumatotal.ToString("0.00"))

            };
            rvFactura.LocalReport.SetParameters(reportParameters);

        }
    }
}
