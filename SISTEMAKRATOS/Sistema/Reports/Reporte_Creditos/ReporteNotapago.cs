using CapaDatos.Models.CuentaCobrar;
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

namespace Sistema.Reports.Reporte_Creditos
{
    public partial class ReporteNotapago : BaseContext
    {
        private NotaPago _notapago = null;
        private CuentaCB _cuentaCB = null;
        public ReporteNotapago(NotaPago nota, CuentaCB pago)
        {
            _notapago = nota;
            _cuentaCB = pago;
            InitializeComponent();
        }

        private void ReporteNotapago_Load(object sender, EventArgs e)
        {
            Cargarparametros();
            this.rvNotapago.RefreshReport();
        }

        private void Cargarparametros()
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                new ReportParameter("nodocumento",_notapago.NoDocumento ),
                  new ReportParameter("concepto",_notapago.Descripcion ),
                    new ReportParameter("fechacreacion",_notapago.FechaTransaccion.ToString() ),
                      new ReportParameter("cliente",_cuentaCB.Cliente.Nombres ),
                        new ReportParameter("nocuenta",_cuentaCB.NoCuenta ),
                          new ReportParameter("descripcion","Pago" ),
                            new ReportParameter("monto",_notapago.Monto.ToString() ),
                            new ReportParameter("vendedor",_notapago.UserId ),


            };
            rvNotapago.LocalReport.SetParameters(reportParameters);
        }

    }
}
