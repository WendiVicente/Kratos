using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Prestamos;
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

namespace Sistema.Forms.modulo_Prestamos
{
    public partial class SolicitudPDF : BaseContext
    {
        private Prestamos _prestamos = new Prestamos();
        private List<CuotasCredito> _listaCreditos = new List<CuotasCredito>();
        private string  _creditType;
        private ListarClientes _clientename;
        public SolicitudPDF(Prestamos prestamos, List<CuotasCredito> listacreditos, ListarClientes client,string tipcredi)
        {
            InitializeComponent();
            _listaCreditos = listacreditos;
            _prestamos = prestamos;
            _clientename = client;
            _creditType = tipcredi;
        }

        private void SolicitudPDF_Load(object sender, EventArgs e)
        {
            CargarTabla();
            traerparametros();
            this.rvSolicitudPrestamo.RefreshReport();
        }

        private void traerparametros()
        {
            var sumascuota = _listaCreditos.Sum(x => x.MontoCuotas);
            var sumaamorti = _listaCreditos.Sum(x => x.Amortizacion);

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                new ReportParameter("codigo",_prestamos.NoDocumento ),
                 new ReportParameter("nombrecliente",_clientename.Nombres+" "+_clientename.Apellidos ),
                  new ReportParameter("periodopago", _creditType ),
                   new ReportParameter("fechapretamo",_prestamos.FechaSolicitud.ToString("dd/MM/yyyy") ),
                    new ReportParameter("montosolicitado","Q."+_prestamos.Monto.ToString() ),
                     new ReportParameter("tasainteres",_prestamos.TasaInteres.ToString()+"%" ),
                      new ReportParameter("importefinal","Q"+_prestamos.ImporteFinanciado.ToString() ),
                      new ReportParameter("sumacuotas",sumascuota.ToString() ),
                       new ReportParameter("sumaAmortiz",sumaamorti.ToString() ),


            };
            rvSolicitudPrestamo.LocalReport.SetParameters(reportParameters);

        }
        private void CargarTabla()
        {
           
            rvSolicitudPrestamo.LocalReport.ReportEmbeddedResource = "Sistema.Forms.modulo_Prestamos.SolicitudPDF.rdlc";
            var rds1 = new ReportDataSource("cuotas", _listaCreditos);
            rvSolicitudPrestamo.LocalReport.DataSources.Clear();
            rvSolicitudPrestamo.LocalReport.DataSources.Add(rds1);

        }
    }
}
