using CapaDatos.ListasPersonalizadas;
using CapaDatos.ListasPersonalizadas.Prestamos;
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
    public partial class ReporteCuotasbyprestamo : BaseContext
    {
        private Prestamos _prestamos = new Prestamos();
        private IList<ListarCuotas> _listaCreditos = new List<ListarCuotas>();
        private Cliente _cliente = new Cliente();
        public ReporteCuotasbyprestamo(Prestamos prestamos,IList<ListarCuotas> listarCuotas, Cliente cliente)
        {
            InitializeComponent();
            _listaCreditos = listarCuotas;
            _prestamos = prestamos;
            _cliente = cliente;

        }

        private void ReporteCuotasbyprestamo_Load(object sender, EventArgs e)
        {
            CargarTabla();
            traerparametros();

            this.rvcuotasbyprestamo.RefreshReport();
        }

        
        private void traerparametros()
        {
            var sumascuota = _listaCreditos.Sum(x => x.MontoCuotas);
            var sumaamorti = _listaCreditos.Sum(x => x.Mora);

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                new ReportParameter("codigo",_prestamos.NoDocumento ),
                 new ReportParameter("nombrecliente",_cliente.Nombres+" "+_cliente.Apellidos ),
                  new ReportParameter("periodopago", _prestamos.TipoCredito.Tipo ),
                   new ReportParameter("fechapretamo",_prestamos.FechaSolicitud.ToString("dd/MM/yyyy") ),
                    new ReportParameter("montosolicitado","Q."+_prestamos.Monto.ToString() ),
                     new ReportParameter("tasainteres",_prestamos.TasaInteres.ToString()+"%" ),
                      new ReportParameter("importefinal","Q"+_prestamos.ImporteFinanciado.ToString() ),
                      new ReportParameter("sumacuotas",sumascuota.ToString() ),
                       new ReportParameter("sumamoras",sumaamorti.ToString() ),


            };
            rvcuotasbyprestamo.LocalReport.SetParameters(reportParameters);

        }
        private void CargarTabla()
        {

            rvcuotasbyprestamo.LocalReport.ReportEmbeddedResource = "Sistema.Forms.modulo_Prestamos.ReporteCuotasbyPrestamo.rdlc";
            var rds1 = new ReportDataSource("cuotas", _listaCreditos);
            rvcuotasbyprestamo.LocalReport.DataSources.Clear();
            rvcuotasbyprestamo.LocalReport.DataSources.Add(rds1);

        }
    }
}
