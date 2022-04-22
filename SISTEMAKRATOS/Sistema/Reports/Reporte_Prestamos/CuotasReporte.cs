using CapaDatos.ListasPersonalizadas.Prestamos;
using CapaDatos.Models.Prestamos;
using CapaDatos.Repository.PrestamosRepository;
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

namespace Sistema.Reports.Reporte_Prestamos
{
    public partial class CuotasReporte : BaseContext
    {
        private ListarPrestamos _Prestamo = null;
        private Prestamos _prestamos = new Prestamos();

        private IList<ListarCuotas> _listaCreditos = new List<ListarCuotas>();
        public CuotasCreditoRepository _cuotasCreditoRepository = null;
        public RegistroPagoRepository _registroPagoRepository = null;
        public PrestamoRepository _prestamoRepository = null;
       // private Cliente _cliente = new Cliente();
        public CuotasReporte(ListarPrestamos prestamo)
        {
            _Prestamo = prestamo;
            _prestamoRepository = new PrestamoRepository(_context);
            _registroPagoRepository = new RegistroPagoRepository(_context);
            _cuotasCreditoRepository = new CuotasCreditoRepository(_context);

            InitializeComponent();

          

        }

        private void CuotasReporte_Load(object sender, EventArgs e)
        {
            _prestamos = _prestamoRepository.GetPrestamo(_Prestamo.Id);
            _listaCreditos = _cuotasCreditoRepository.GetListaCuotas(_Prestamo.Id);

            CargarTabla();
            traerparametros();

            this.rvreportecuotas.RefreshReport();
        }

        private void traerparametros()
        {
            var sumascuotaPagadas = _listaCreditos.Where(x=>x.Estado=="Cobrado").Sum(x => x.MontoCuotas);
            var sumascuotapendientes = _listaCreditos.Where(x => x.Estado == "Pendiente").Sum(x => x.MontoCuotas);
            var sumamoras = _listaCreditos.Sum(x => x.Mora);

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
                  new ReportParameter("sumapendientes","Q."+sumascuotapendientes.ToString() ),



            };
            rvreportecuotas.LocalReport.SetParameters(reportParameters);

        }
        private void CargarTabla()
        {

            rvreportecuotas.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reporte_Prestamos.CuotasReporte.rdlc";
            var rds1 = new ReportDataSource("cuotas", _listaCreditos);
            rvreportecuotas.LocalReport.DataSources.Clear();
            rvreportecuotas.LocalReport.DataSources.Add(rds1);

        }
    }
}
