using CapaDatos.ListasPersonalizadas.Prestamos;
using CapaDatos.Models.Prestamos;
using CapaDatos.Repository.PrestamosRepository;
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

namespace Sistema.Reports.Reporte_Prestamos
{
    public partial class PagosReporte : BaseContext
    {
        private IList<ListarRegistroPagos> _listaRegistrosPago = new List<ListarRegistroPagos>();
        private RegistroPagoRepository _registroPagoRepository = null;
        private PrestamoRepository _prestamoRepository = null;
        private Prestamos _prestamos = null;
        private ListarPrestamos _prestamolistar = null;
       //private Cliente _cliente = null;
       // private CobroCreditos _comprobante = null;
        public PagosReporte(ListarPrestamos restamos)
        {
            InitializeComponent();
            _prestamolistar = restamos;
            _prestamoRepository = new PrestamoRepository(_context);
            _registroPagoRepository = new RegistroPagoRepository(_context);
           
        }

        private void PagosReporte_Load(object sender, EventArgs e)
        {
            _prestamos = _prestamoRepository.GetPrestamo(_prestamolistar.Id);
            _listaRegistrosPago = _registroPagoRepository.GetlistaPagosToReport(_prestamos.Id);
            CargarTabla();
            traerparametros();
            this.rvpagoreporte.RefreshReport();
        }

        private void traerparametros()
        {
            //var sumascuotaPagadas = _listaRegistrosPago.Where(x => x.Estado == "Cobrado").Sum(x => x.MontoCuotas);
            //var sumascuotapendientes = _listaCreditos.Where(x => x.Estado == "Pendiente").Sum(x => x.MontoCuotas);
            var sumamoras = _listaRegistrosPago.Sum(x => x.Mora);
            var sumascuotaPagadas = _listaRegistrosPago.Sum(x => x.Importe);

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                new ReportParameter("codigo",_prestamos.NoDocumento ),
                 new ReportParameter("nombrecliente",_prestamos.Cliente.Nombres+" "+_prestamos.Cliente.Apellidos ),
                  new ReportParameter("periodopago", _prestamos.TipoCredito.Tipo ),
                  new ReportParameter("fechapretamo",_prestamos.FechaSolicitud.ToString("dd/MM/yyyy") ),
                  new ReportParameter("montosolicitado","Q."+_prestamos.Monto.ToString() ),
                 new ReportParameter("tasainteres",_prestamos.TasaInteres.ToString()+"%" ),
                 new ReportParameter("importefinal","Q"+_prestamos.ImporteFinanciado.ToString() ),
                 new ReportParameter("deudaactual","Q."+_prestamos.DeudaActual.ToString() ),
                 new ReportParameter("sumacuotas","Q."+sumascuotaPagadas.ToString() ),
                 new ReportParameter("sumamora","Q."+sumamoras.ToString() ),
                 // new ReportParameter("sumapendientes","Q."+sumascuotapendientes.ToString() ),



            };
            rvpagoreporte.LocalReport.SetParameters(reportParameters);

        }
        private void CargarTabla()
        {

            rvpagoreporte.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reporte_Prestamos.PagosReporte.rdlc";
            var rds1 = new ReportDataSource("registropago", _listaRegistrosPago);
            rvpagoreporte.LocalReport.DataSources.Clear();
            rvpagoreporte.LocalReport.DataSources.Add(rds1);

        }
    }
}
