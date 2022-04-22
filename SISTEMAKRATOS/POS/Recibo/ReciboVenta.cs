using CapaDatos.ListasPersonalizadas;
using CapaDatos.Repository;
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
    public partial class ReciboVenta : BaseContext
    {
       
        private readonly FacturasRepository _facturasRepository = null;
        private Guid facturaID;
        private IList<ListarDetalleFacturas> listadetalles = null;
        private Pago pagoForms = null;
        private string empleado = "";
        public ReciboVenta(Guid idfact, string userName)
        {
            empleado = userName;
            facturaID = idfact;
            listadetalles = new List<ListarDetalleFacturas>();
            InitializeComponent();
            _facturasRepository = new FacturasRepository(_context);
        }

        private void ReciboVenta_Load(object sender, EventArgs e)
        {
            CargarTabla();
            traerparametros();
            this.rvRecibo.RefreshReport();
           // pagoForms.Close();
        }

        private void CargarTabla()
        {
            listadetalles = _facturasRepository.GetDetallebyFactura(facturaID);
           
            rvRecibo.LocalReport.ReportEmbeddedResource = "POS.Recibo.ReciboVenta.rdlc";
            var rds1 = new ReportDataSource("detalleFactura", listadetalles);
            rvRecibo.LocalReport.DataSources.Clear();
            rvRecibo.LocalReport.DataSources.Add(rds1);




        }
        private void traerparametros()
        {
            var encabezadoFactura= _facturasRepository.Get(facturaID);

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                new ReportParameter("fecha",encabezadoFactura.FechaVenta.ToString() ),
                new ReportParameter("comprobante",encabezadoFactura.NoFactura ),
                new ReportParameter("nombrecliente",encabezadoFactura.Nombre ),
                new ReportParameter("nitcliente",encabezadoFactura.NIT ),
                 new ReportParameter("direccioncliente",encabezadoFactura.Direccion ),
                new ReportParameter("empleado",empleado ),
              



            };
            rvRecibo.LocalReport.SetParameters(reportParameters);

        }
    }
}
