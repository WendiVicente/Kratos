using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Repository;
using sharedDatabase.Models.Proveedores;
using Sistema.Reports.Reports_Proveedores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_proveedor
{
    public partial class VerProveedores : BaseContext
    {
        private ProveedoresRepository _proveedoresRepository = null;
        private SucursalesRepository _sucursalesRepository = null;
        public  string estadocliente;
        public bool allFechas;
        public bool prodActivo;
        public bool prodInactivo;
        public bool todosEstados;
        public int idsucursal;
        public DateTime fechaInicio => Convert.ToDateTime(dtpfechainicio.Value.ToLongDateString());
        public DateTime fechaFinal => Convert.ToDateTime(dtpfechafinal.Value.ToLongDateString());

        private IList<ListarProveedores> _listaproveedores = null;
        public VerProveedores()
        {

            _proveedoresRepository = new ProveedoresRepository(_context);
            _listaproveedores = new List<ListarProveedores>();
            _sucursalesRepository = new SucursalesRepository(_context);
            InitializeComponent();
        }
        private void VerProveedores_Load(object sender, EventArgs e)
        {
            // RefrescarDataGrid();
            ValoresDefault();
            CargarSucursales();
            
        }
        private void btnDetalle_Click(object sender, EventArgs e)
        {

        }
        private void ValoresDefault()
        {
            rbTodos.Checked = true;
            checkfechas.Checked = true;
          

        }


        public void RefrescarDataGrid(bool LoadNewContext = true)
        {
            

            BindingSource source = new BindingSource();
            source.DataSource = _listaproveedores;
            dgvProveedores.DataSource = typeof(List<>);
            dgvProveedores.DataSource = source;

        }
        public void CargarFiltros()
        {
             allFechas = checkfechas.Checked;
             prodActivo = rbActivos.Checked;
             prodInactivo = rbInactivos.Checked;
             todosEstados = rbTodos.Checked;
             idsucursal = int.Parse(cbsucursales.SelectedValue.ToString());
           

            CargarEstados();

            _listaproveedores = _proveedoresRepository.GetlistaProvs(idsucursal, allFechas, fechaInicio,
              fechaFinal.AddDays(1), prodActivo, prodInactivo, todosEstados);
            RefrescarDataGrid();
        }



        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtbuscarprod_TextChanged(object sender, EventArgs e)
        {
            var filtro = _listaproveedores.Where(a => a.Nombre.Contains(txtbuscarprod.Text) ||
          (a.Nombre != null && a.Nombre.Contains(txtbuscarprod.Text)) ||
           (a.Direccion != null && a.Direccion.Contains(txtbuscarprod.Text)) ||
            (a.Telefonos != null && a.Telefonos.Contains(txtbuscarprod.Text)) );
            dgvProveedores.DataSource = filtro.ToList();
        }

        private void btnVista_Click(object sender, EventArgs e)
        {
            CargarFiltros();
        }
        private void CargarSucursales()
        {
            var sucursal = _sucursalesRepository.GetList();

            // agregar nuevo item a la lista
            sucursal.Add(new ListarSucursales { Id = 0, NombreSucursal = "Todas" });
            var s = sucursal.OrderBy(a => a.Id).ToList();

            // mostrar datos en dgv
            cbsucursales.DataSource = s;
            cbsucursales.DisplayMember = "NombreSucursal";
            cbsucursales.ValueMember = "Id";
            //cbsucursales.Text = "Seleccione una Sucursal"; // esto no jalo? no me jalo
            cbsucursales.SelectedIndex = 0;
            cbsucursales.Invalidate();
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

        private void CargarEstados()
        {
            if (rbTodos.Checked == true) { estadocliente = "Todos"; };
            if (rbInactivos.Checked == true) { estadocliente = "Inactivos"; };
            if (rbActivos.Checked == true) { estadocliente = "Activos"; };
        }

        private void btnreporte_Click(object sender, EventArgs e)
        {
            ReporteProveedoresGeneral generalReporteProd = new ReporteProveedoresGeneral(_listaproveedores,this);
            generalReporteProd.Show();
        }

        private void btnestado_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvProveedores.Rows)
            {
                var Id = int.Parse(row.Cells[0].Value.ToString());
                var proveedorObtenido = _proveedoresRepository.Get(Id);

                bool estadoActual = Convert.ToBoolean(row.Cells[13].Value);

                if (estadoActual != proveedorObtenido.IsActive)
                {
                    proveedorObtenido.IsActive = estadoActual;
                    _proveedoresRepository.Update(proveedorObtenido);

                }
                else
                {

                    _proveedoresRepository.Update(proveedorObtenido);
                }
            }

        }
    }
}
