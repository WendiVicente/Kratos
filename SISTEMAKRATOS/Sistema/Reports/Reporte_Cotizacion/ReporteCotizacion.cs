using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Cotizacion;
using CapaDatos.Models.DocumentoSAT;
using CapaDatos.Repository;
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

namespace Sistema.Reports.Reporte_Cotizacion
{
    public partial class ReporteCotizacion : BaseContext
    {
        private readonly CotizacionRepository _cotizacionRepository = null;
        // public static Emisor emi = new Context().Emisors.ToList().Where(x => x.entorno ==1).ElementAt(0);
        private Cotizacion _cotizacion;
        private List<ListarDetalleCotiz> _listaPersonalizDetalle = null;

        public ReporteCotizacion(Cotizacion cotizacion)
        {
            _cotizacion = cotizacion;
            // _listaDetalles = listaDetalles;
            _cotizacionRepository = new CotizacionRepository(_context);
            InitializeComponent();
        }

        private void ReporteCotizacion_Load(object sender, EventArgs e)
        {
            CargarTabla();
            traerparametros();
            this.rvcotizacion.RefreshReport();
        }

        private void CargarTabla()
        {
            try
            {
                _listaPersonalizDetalle = _cotizacionRepository.GetListDetalleCotiz(_cotizacion.Id);

                rvcotizacion.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reporte_Cotizacion.ReporteCotizacion.rdlc";
                var rds1 = new ReportDataSource("Listacotizacion", _listaPersonalizDetalle);
                rvcotizacion.LocalReport.DataSources.Clear();
                rvcotizacion.LocalReport.DataSources.Add(rds1);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }


        private void traerparametros()
        {
            decimal iva = 0.10714284m;
            var sumatotal = _listaPersonalizDetalle.Sum(x => x.Total);

            var ivatotal = sumatotal * iva;

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                new ReportParameter("fecha",DateTime.Now.ToString() ),
                //new ReportParameter("nitemisor",emi.nitemisor),
                //new ReportParameter("nombrecomercial",emi.namecomercial),
                new ReportParameter("nocotizacion",_cotizacion.NoCotizacion),
                new ReportParameter("nombrecliente",_cotizacion.Nombre),
                new ReportParameter("nitcliente" ,_cotizacion.Nit),
                new ReportParameter("ivatotal",ivatotal.ToString("0.0000")),
                new ReportParameter("totalfactura",sumatotal.ToString("0.00"))

            };
            rvcotizacion.LocalReport.SetParameters(reportParameters);

        }
    }
}
