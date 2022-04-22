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
    public partial class ComprobantePago : BaseContext
    {
        private List<RegistroPagoCuota> _listaRegistrosPago = new List<RegistroPagoCuota>();

        private Prestamos _prestamos = null;
        private Cliente _cliente = null;
        private CobroCreditos _comprobante = null;
        public ComprobantePago(CobroCreditos formspadre , List<RegistroPagoCuota> lista, Prestamos prestamoset,Cliente cliente)
        {
            InitializeComponent();
            _listaRegistrosPago = lista;
            _prestamos = prestamoset;
            _cliente = cliente;
            _comprobante = formspadre;
        }

        private void ComprobantePago_Load(object sender, EventArgs e)
        {
            
            cargarlista();
            traerparametros();
            this.rvcomprobantepago.RefreshReport();
           
        }
        private void cargarlista()
        {
            var listaregistro = new List<RegistroPagoCuota>();
            foreach (var item in _listaRegistrosPago)
            {
                var nuevoRegistro = new RegistroPagoCuota()
                {
                    Id = item.Id,
                    Nopago = item.Nopago,
                    FechaPago = item.FechaPago,
                    Importe = item.Importe,
                    Mora = item.Mora,
                    PrestamosId = item.PrestamosId,
                    CuotasCreditoId = item.CuotasCredito.NoCuota,

                };
                listaregistro.Add(nuevoRegistro);

            }
            CargarTabla( listaregistro);

        }
        private void CargarTabla(List<RegistroPagoCuota> listaregistro)
        {

            rvcomprobantepago.LocalReport.ReportEmbeddedResource = "Sistema.Forms.modulo_Prestamos.ComprobantePago.rdlc";
            var rds1 = new ReportDataSource("registropago", listaregistro);
            rvcomprobantepago.LocalReport.DataSources.Clear();
            rvcomprobantepago.LocalReport.DataSources.Add(rds1);

        }
        private void traerparametros()
        {
            var sumascuota = _listaRegistrosPago.Sum(x => x.Importe);
            var sumamoras = _listaRegistrosPago.Sum(x => x.Mora);

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                new ReportParameter("codigo",_prestamos.NoDocumento ),
                 new ReportParameter("nombrecliente",_cliente.Nombres+" "+_cliente.Apellidos ),
                  new ReportParameter("periodopago", _prestamos.TipoCredito.Tipo ),
                  new ReportParameter("fechapretamo",_prestamos.FechaSolicitud.ToString("dd/MM/yyyy") ),
                  new ReportParameter("montosolicitado","Q."+_prestamos.Monto.ToString() ),
                 new ReportParameter("tasainteres",_prestamos.TasaInteres.ToString()+"%" ),
                 new ReportParameter("importefinal","Q"+_prestamos.ImporteFinanciado.ToString() ),
                 new ReportParameter("deudaactual","Q."+_prestamos.DeudaActual.ToString() ),
                 new ReportParameter("sumacuotas","Q."+sumascuota.ToString() ),
                 new ReportParameter("sumamora","Q."+sumamoras.ToString() ),


            };
            rvcomprobantepago.LocalReport.SetParameters(reportParameters);

        }
      

        private void ComprobantePago_FormClosing(object sender, FormClosingEventArgs e)
        {
            _comprobante._listaRegistrosPago.Clear();
        }
    }
}
