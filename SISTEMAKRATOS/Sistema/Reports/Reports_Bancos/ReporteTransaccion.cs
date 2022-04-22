using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Transacciones;
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

namespace Sistema.Reports.Reports_Bancos
{
    public partial class ReporteTransaccion : BaseContext
    {
        private SucursalesRepository _sucursalesRepository = null;
        private TransaccionRepository _transaccionRepository = null;
        
        private DateTime fechaInicio => Convert.ToDateTime(dtpfechainicio.Value.ToLongDateString());
        private DateTime fechaFinal => Convert.ToDateTime(dtpfechafinal.Value.ToLongDateString());
        public ReporteTransaccion()
        {
            _sucursalesRepository = new SucursalesRepository(_context);
            _transaccionRepository = new TransaccionRepository(_context);
            InitializeComponent();
        }

        private void ReporteTransaccion_Load(object sender, EventArgs e)
        {
            CargarSucursales();
            CargarEstados();
            CargarTiposMovi();
        }

        private void CargarSucursales()
        {
            var sucursal = _sucursalesRepository.GetList();
            sucursal.Add(new ListarSucursales { Id = 0, NombreSucursal = "Todas" });
            var s = sucursal.OrderBy(a => a.Id).ToList();
            cbsucursales.DataSource = s;
            cbsucursales.DisplayMember = "NombreSucursal";
            cbsucursales.ValueMember = "Id";
            cbsucursales.SelectedIndex = 0;
            cbsucursales.Invalidate();
        }
        private void CargarTiposMovi()
        {
            var tipoMovimientos = _transaccionRepository.GetlistMovimientos();
            tipoMovimientos.Add(new TipoMovimiento { Id = 0,  Movimiento = "Todas" });
            var s = tipoMovimientos.OrderBy(a => a.Id).ToList();
            comboTiposmovi.DataSource = s;
            comboTiposmovi.DisplayMember = "Movimiento";
            comboTiposmovi.ValueMember = "Id";
            comboTiposmovi.SelectedIndex = 0;
            comboTiposmovi.Invalidate();
        }
        private void CargarEstados()
        {
            var estadosTransac = _transaccionRepository.GetlistEstadosT();
            estadosTransac.Add(new EstadosTransac { Id = 0, Estado = "Todas" });
            var s = estadosTransac.OrderBy(a => a.Id).ToList();
            comboEstadosT.DataSource = s;
            comboEstadosT.DisplayMember = "Estado";
            comboEstadosT.ValueMember = "Id";
            comboEstadosT.SelectedIndex = 0;
            comboEstadosT.Invalidate();
        }
        



        private void checkfechas_CheckedChanged_1(object sender, EventArgs e)
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

        private void btngenerar_Click(object sender, EventArgs e)
        {
            CargarTabla();
            cargarTextbox();

            this.rvtransac.RefreshReport();
        }


        private void CargarTabla()
        {
            var tiposmovi = int.Parse(comboTiposmovi.SelectedValue.ToString()); //
            var allFechas = checkfechas.Checked;
            // checkbox de usuariios inactivos o activos
            var idsucursal = int.Parse(cbsucursales.SelectedValue.ToString());
            var idestadoT = int.Parse(comboEstadosT.SelectedValue.ToString());
           
            var listadeTransact= _transaccionRepository.GetlistaTransacReporte(idsucursal, tiposmovi, allFechas, fechaInicio,
                fechaFinal.AddDays(1), idestadoT);
                rvtransac.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Bancos.ReporteTransaccion.rdlc";
                var rds1 = new ReportDataSource("listatransaccion", listadeTransact);
            rvtransac.LocalReport.DataSources.Clear();
            rvtransac.LocalReport.DataSources.Add(rds1);
        }

    public void cargarTextbox()
    {
        ReportParameterCollection reportParameters = new ReportParameterCollection
            {
             
                 new ReportParameter("fechainicio",fechaInicio.ToString()),
                  new ReportParameter("fechafinal",fechaFinal.ToString()),
                   new ReportParameter("sucursal",cbsucursales.Text),
                    new ReportParameter("movimiento",comboTiposmovi.Text),
                     new ReportParameter("estado",comboEstadosT.Text),

            };
            rvtransac.LocalReport.SetParameters(reportParameters);

    }

}
}
