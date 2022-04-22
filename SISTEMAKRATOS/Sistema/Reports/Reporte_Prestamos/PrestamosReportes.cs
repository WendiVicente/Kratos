using CapaDatos.ListasPersonalizadas.Prestamos;
using CapaDatos.Models.Prestamos;
using CapaDatos.Repository;
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
    public partial class PrestamosReportes : BaseContext
    {
        private ClientesRepository _clientesRepository = null;
        private PrestamoRepository _prestamoRepository = null;
        private TipoCreditoRepository _tipoCreditoRepository = null;
        private MetodoAmortizacionRepository _amortizacionRepository = null;
        private IList<ListarPrestamos> _listaPrestamos = null;
        private string estadoprestamo;
        private DateTime fechaInicio => Convert.ToDateTime(dtpfechainicio.Value.ToLongDateString());
        private DateTime fechaFinal => Convert.ToDateTime(dtpfechafinal.Value.ToLongDateString());
        public PrestamosReportes()
        {
            _clientesRepository = new ClientesRepository(_context);
            _prestamoRepository = new PrestamoRepository(_context);
            _tipoCreditoRepository = new TipoCreditoRepository(_context);
            _amortizacionRepository = new MetodoAmortizacionRepository(_context);
            InitializeComponent();
        }

        private void PrestamosReportes_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarTiposcredito();
            CargarAmoritizacion();
           
        }


        private void CargarClientes()
        {
            var clienteslista = _clientesRepository.GetClientes();
            clienteslista.Add(new Cliente { Id = 0, Nombres = "Todos" });
            var lista = clienteslista.OrderBy(a => a.Id).ToList();

            comboclientes.DataSource = lista;
            comboclientes.DisplayMember = "Nombres";
            comboclientes.ValueMember = "Id";
            comboclientes.Text = "Seleccione un cliente"; 
            comboclientes.SelectedIndex = 0;
            comboclientes.Invalidate();
        }

        private void CargarTiposcredito()
        {
            var tiposcredito = _tipoCreditoRepository.GetListaTipoCreditos();

            // agregar nuevo item a la lista
            tiposcredito.Add(new TipoCredito { Id = 0, Tipo = "Todas" });
            var s = tiposcredito.OrderBy(a => a.Id).ToList();

            cbtipos.DataSource = s;
            cbtipos.DisplayMember = "Tipo";
            cbtipos.ValueMember = "Id";
            cbtipos.Text = "Seleccione una Tipo";
            cbtipos.SelectedIndex = 0;
            cbtipos.Invalidate();

        }

        private void CargarAmoritizacion()
        {
            var tiposamortizacion = _amortizacionRepository.GetListaMetodos();

            // agregar nuevo item a la lista
            tiposamortizacion.Add(new MetodoAmortizacion { Id = 0,Metodo = "Todas" });
            var s = tiposamortizacion.OrderBy(a => a.Id).ToList();

            comboamortizacion.DataSource = s;
            comboamortizacion.DisplayMember = "Metodo";
            comboamortizacion.ValueMember = "Id";
            comboamortizacion.Text = "Seleccione un método";
            comboamortizacion.SelectedIndex = 0;
            comboamortizacion.Invalidate();

        }

        private void checkfechas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkfechas.Checked == false)
            {
                dtpfechainicio.Enabled = true;
                dtpfechafinal.Enabled = true;
            }
            else
            {
                dtpfechainicio.Enabled = false;
                dtpfechafinal.Enabled = false;
            }
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void CargarEstados()
        {
            if (rbTodos.Checked == true) { estadoprestamo = "Todos"; };
            if (radioendeuda.Checked == true) { estadoprestamo = "En Deuda"; };
            if (radioFiniquito.Checked == true) { estadoprestamo = "Finiquitado"; };
        }

        private void btngenerarreporte_Click(object sender, EventArgs e)
        {
            CargarTabla();
            cargarTextbox();
            this.rvPrestamosGenerales.RefreshReport();
        }
        private void CargarTabla()
        {
           

            var orderByAscen = rbAscent.Checked;
            var orderByDescen = rbDescen.Checked;
            var allFechas = checkfechas.Checked;
            // checkbox de usuariios inactivos o activos
            var enDeuda = radioendeuda.Checked;
            var enFiniquito = radioFiniquito.Checked;
            var todos = rbTodos.Checked;
            var idamortizacion = int.Parse(comboamortizacion.SelectedValue.ToString());
            var idtipocredito = int.Parse(cbtipos.SelectedValue.ToString());
            var idcliente = int.Parse(comboclientes.SelectedValue.ToString());
            CargarEstados();

             _listaPrestamos = _prestamoRepository.GetlistaReporte(idcliente, idtipocredito, idamortizacion, allFechas, fechaInicio,
                fechaFinal.AddDays(1), orderByDescen, orderByAscen, enDeuda, enFiniquito, todos);
                rvPrestamosGenerales.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reporte_Prestamos.PrestamosReporte.rdlc";
                var rds1 = new ReportDataSource("listaprestamos", _listaPrestamos);
                rvPrestamosGenerales.LocalReport.DataSources.Clear();
                rvPrestamosGenerales.LocalReport.DataSources.Add(rds1);
        }
        public void cargarTextbox()
        {
            var sumadeudas = _listaPrestamos.Sum(x => x.DeudaActual);
            var sumaimporte = _listaPrestamos.Sum(x => x.ImporteFinanciado);
            var sumamontosolic = _listaPrestamos.Sum(x => x.Monto);
            var gananciatotal = sumaimporte - sumamontosolic;
            var empleado = UsuarioLogeadoSistemas.User.Name;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                new ReportParameter("amortizacion",comboamortizacion.Text),
                new ReportParameter("periodotime",cbtipos.Text),
                 new ReportParameter("estadoprestamo",estadoprestamo),
                  new ReportParameter("fechainicio",fechaInicio.ToString()),
                   new ReportParameter("fechafinal",fechaFinal.ToString()),
                  new ReportParameter("sumadeudas","Q."+sumadeudas.ToString()),
                  new ReportParameter("sumaimportes","Q."+sumaimporte.ToString()),
                  new ReportParameter("sumamontosolicitado","Q."+sumamontosolic.ToString()),
                  new ReportParameter("gananciafinal","Q."+gananciatotal.ToString()),
                  new ReportParameter("empleado",empleado),

            };
            rvPrestamosGenerales.LocalReport.SetParameters(reportParameters);

        }




    }
}
