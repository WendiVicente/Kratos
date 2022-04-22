using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.DocumentoSAT;
using CapaDatos.Repository;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.Reporting.WinForms;
using POS.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Recibo
{
    public partial class ReporteReciboCliente : BaseContext
    {
        private readonly FacturasRepository _facturasRepository = null;
        private IList<ListarDetalleFacturas> listadetalles = null;
        private readonly DocumentoCertificadoSAT DocCertificado = null;
        private Pago pagoForms = null;
        private Guid idfactura;
        public ReporteReciboCliente(Guid idfac, DocumentoCertificadoSAT DocCertif)
        {
            idfactura = idfac;
            DocCertificado = DocCertif;
            DocCertificado = DocCertif;
            _facturasRepository = new FacturasRepository(_context);
            InitializeComponent();
        }

        private void ReporteReciboCliente_Load(object sender, EventArgs e)
        {
             CargarTabla();
          ///  listadetalles = _facturasRepository.GetDetallebyFactura(idfactura);
            traerparametros();
            this.rvporte.RefreshReport();

            //  pagoForms.Close();


           
        }
        private void CargarTabla()
        {
            listadetalles = _facturasRepository.GetDetallebyFactura(idfactura);

            //rvfacturafel.LocalReport.ReportEmbeddedResource = "POS.Recibo.FacturaFEL.rdlc";
            rvporte.LocalReport.ReportEmbeddedResource = "POS.Recibo.ReporteReciboCliente.rdlc";
            var rds1 = new ReportDataSource("detallefactura", listadetalles);
            rvporte.LocalReport.DataSources.Clear();
            rvporte.LocalReport.DataSources.Add(rds1);

        }
       

        private void traerparametros()
        {
            try
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
                    new ReportParameter("fechaemision",DocCertificado.Fecha_DTE.ToString()),
                    new ReportParameter("nombreeface", "CENTRO KRATOS"),
                    new ReportParameter("niteface", DocCertificado.NIT_EFACE),
                    new ReportParameter("ivatotal",ivatotal.ToString("0.0000")),
                    new ReportParameter("totalfactura",sumatotal.ToString("0.00")),
                    new ReportParameter("serie" ,DocCertificado.Serie),
                    new ReportParameter("numero",DocCertificado.NUMERO),
                };
                rvporte.LocalReport.SetParameters(reportParameters);
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Error en traer los parametros de Recibo " + ex.Message);
            }
            
        }

    }
}
