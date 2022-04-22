using CapaDatos.ListasPersonalizadas.Creditos;
using CapaDatos.Models.CuentaCobrar;
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

namespace Sistema.Reports.Reporte_Creditos
{
    public partial class TalonariosReporte : BaseContext
    {
         private CuentasCobrarRepository _cuentasCRepository = null;
        private Guid _cuentaid;
        private CuentaCB _cuenta;
        private int iniciocorrel, fincorrel;
        public TalonariosReporte(Guid idcuenta, int inicio, int fin)
        {

            _cuentasCRepository = new CuentasCobrarRepository(_context);
            _cuentaid = idcuenta;
            iniciocorrel = inicio;
            fincorrel = fin;

            InitializeComponent();
        }

        private void TalonariosReporte_Load(object sender, EventArgs e)
        {
            TraerListaTalonarios();
          
        }

        private void TraerListaTalonarios()
        {/*
            var listatalonarios = _cuentasCRepository.GetTalonariosByCuentacb(_cuentaid);
            var filtroTalonarios = listatalonarios.Where(x => x.Correlativo >= iniciocorrel && x.Correlativo <= fincorrel).ToList();
             _cuenta = _cuentasCRepository.Get(_cuentaid);
         */
            var listatalonarios = _cuentasCRepository.GetlistByCuentacb(_cuentaid,iniciocorrel,fincorrel);


            CargarTabla(listatalonarios);
            traerparametros();
            this.rvtalonarios.RefreshReport();
        }
        private void traerparametros()
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                new ReportParameter("responsable",UsuarioLogeadoSistemas.User.Name ),
                //new ReportParameter("cliente",item.CuentaCB.Cliente.Nombres ),
              



            };
            rvtalonarios.LocalReport.SetParameters(reportParameters);
            
        }
        private void CargarTabla(IList<ListarTalonarios> lista)
        {


            lista = lista.OrderBy(x => x.Correlativo).ToList();
            rvtalonarios.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reporte_Creditos.TalonariosReporte.rdlc";
            var rds1 = new ReportDataSource("listartalonarios", lista);
            rvtalonarios.LocalReport.DataSources.Clear();
            rvtalonarios.LocalReport.DataSources.Add(rds1);




        }



    }
}
