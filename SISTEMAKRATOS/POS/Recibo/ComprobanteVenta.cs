using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.CuentaCobrar;
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
    public partial class ComprobanteVenta : BaseContext
    {
        private Pago _pago = null;
        private Talonario _talonario = null;
        private CuentaCB cuentaCBs = null;
        private readonly ClientesRepository _clientesRepository = null;
        private List<ListarPReserva> _listaproductos = null;
        private List<ListarDetalleFacturas> listaDetalle = null;
        private readonly CuentasCobrarRepository _cuentasCobrarRepository = null;
        private readonly ProductosReservaRepository _productosReservaRepository = null;
        private string usuario = UsuarioLogeadoPOS.User.Name;
        public ComprobanteVenta(Pago pago,Talonario talonario, List<ListarDetalleFacturas> listadet)
        {
            _pago = pago;
            _talonario = talonario;
            _clientesRepository = new ClientesRepository(_context);
            _cuentasCobrarRepository = new CuentasCobrarRepository(_context);
            listaDetalle = listadet;

            InitializeComponent();
        }

        private void ComprobanteVenta_Load(object sender, EventArgs e)
        {
            //_listaproductos = _productosReservaRepository.GetListaPReservas(cuentaCBs.Id);
            traerparametros();
            CargarTabla();
            this.rvComprobante.RefreshReport();
        }

        private void traerparametros()
        {
            cuentaCBs= _cuentasCobrarRepository.Get(_talonario.CuentaCBId);
            var cliente = _clientesRepository.Get(cuentaCBs.ClienteId);

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                new ReportParameter("nombres",_talonario.Nombre ),
                new ReportParameter("correlativo",_talonario.Correlativo.ToString("00000") ),
                new ReportParameter("cuentaCB",cuentaCBs.NoCuenta),
                new ReportParameter("estado",_talonario.Estado==true? "Cambiada":"disponible" ),
                new ReportParameter("fecha",_talonario.FechaCambio.ToString() ),
                  new ReportParameter("vendedor",usuario ),
                new ReportParameter("clientenombre", cliente.Nombres+" "+ cliente.Apellidos),
               

                //new ReportParameter("cliente",item.CuentaCB.Cliente.Nombres ),
              



            };
            rvComprobante.LocalReport.SetParameters(reportParameters);

        }
        private void CargarTabla()
        {


            rvComprobante.LocalReport.ReportEmbeddedResource = "POS.Recibo.ComprobanteTalonario.rdlc";
            var rds1 = new ReportDataSource("detalles", listaDetalle);
            rvComprobante.LocalReport.DataSources.Clear();
            rvComprobante.LocalReport.DataSources.Add(rds1);




        }

    }
}
