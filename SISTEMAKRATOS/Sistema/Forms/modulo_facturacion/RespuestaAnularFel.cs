using CapaDatos.Models.DocumentoSAT;
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

namespace Sistema.Forms.modulo_facturacion
{
    public partial class RespuestaAnularFel : BaseContext
    {
        private static AnulacionCertificado _certiAnulado = null;
        public RespuestaAnularFel(AnulacionCertificado certificado)
        {
            _certiAnulado = certificado;

            InitializeComponent();
        }

        private void RespuestaAnularFel_Load(object sender, EventArgs e)
        {
            Traerparametros();
            this.rvRespuestaSat.RefreshReport();
        }
        private void Traerparametros( )
        {
            
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                new ReportParameter("autorizacion",_certiAnulado.Autorizacion ),
                new ReportParameter("serie" ,_certiAnulado.Serie),
                new ReportParameter("numero",_certiAnulado.NUMERO),

                new ReportParameter("nombrecomprador",_certiAnulado.NOMBRE_COMPRADOR),
                  new ReportParameter("nitcomprador",_certiAnulado.NIT_COMPRADOR),
                   
                
                 new ReportParameter("nombreeface", _certiAnulado.NOMBRE_EFACE),
                 new ReportParameter("niteface", _certiAnulado.NIT_EFACE),
                 new ReportParameter("backprocesor", _certiAnulado.BACKPROCESOR),

                new ReportParameter("fechacreacioncert",_certiAnulado.Fecha_DTE.ToString()),


            };
            rvRespuestaSat.LocalReport.SetParameters(reportParameters);

        }



    }
}
