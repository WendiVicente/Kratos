using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas.Prestamos;
using CapaDatos.Repository.PrestamosRepository;
using Sistema.Reports.Reporte_Prestamos;
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
    public partial class VerPrestamos : BaseContext
    {
        private PrestamoRepository _prestamoRepository = null;
        private IList<ListarPrestamos> Listaprestamos = null;
        public VerPrestamos()
        {
            _prestamoRepository = new PrestamoRepository(_context);
            InitializeComponent();
          
        }

        private void VerPrestamos_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            CargarDGV();
        }
        public void CargarDGV(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _prestamoRepository = null;
                _prestamoRepository = new PrestamoRepository(_context);
            }

            BindingSource source = new BindingSource();
            Listaprestamos = _prestamoRepository.GetListarPrestamos();
            source.DataSource = Listaprestamos;
            dgvprestamos.DataSource = typeof(List<>);
            dgvprestamos.DataSource = source;
            dgvprestamos.AutoResizeColumns();
        }

        private void btnbuscar_TextChanged(object sender, EventArgs e)
        {
            var filtro = Listaprestamos.Where(a => a.NoDocumento.Contains(btnbuscar.Text) ||
      (a.Nombrescliente != null && a.Nombrescliente.Contains(btnbuscar.Text)) ||
       (a.Empleado != null && a.Empleado.Contains(btnbuscar.Text))
       );
            dgvprestamos.DataSource = filtro.ToList();
        }

        private void btnCuotas_Click(object sender, EventArgs e)
        {
            if (dgvprestamos.CurrentRow == null) return;
            var prestamofila = (ListarPrestamos)dgvprestamos.CurrentRow.DataBoundItem;
            if (Application.OpenForms["CuotasReporte"] == null)
            {

                CuotasReporte cuotasReporte = new CuotasReporte(prestamofila);

                cuotasReporte.Show();
            }
            else
            {
                Application.OpenForms["CuotasReporte"].Activate();
            }
        }

        private void btnverPagos_Click(object sender, EventArgs e)
        {
            if (dgvprestamos.CurrentRow == null) return;
            var prestamofila = (ListarPrestamos)dgvprestamos.CurrentRow.DataBoundItem;
            if (Application.OpenForms["PagosReporte"] == null)
            {

                PagosReporte pagosReporte = new PagosReporte(prestamofila);

                pagosReporte.Show();
            }
            else
            {
                Application.OpenForms["PagosReporte"].Activate();
            }
        }

        private void btnReportePrestamos_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["PrestamosReportes"] == null)
            {

                PrestamosReportes prestamosReportes = new PrestamosReportes();

                prestamosReportes.Show();
            }
            else
            {
                Application.OpenForms["PrestamosReportes"].Activate();
            }
        }
    }
}
