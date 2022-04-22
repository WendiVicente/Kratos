using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Personal;
using CapaDatos.Repository;
using CapaDatos.Repository.PersonalRepository;
using ComponentFactory.Krypton.Toolkit;
using Sistema.Reports.Reports_Personal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_personal
{
    public partial class VerPersonal : BaseContext
    {

         private IList<ListarPersonal> _listaPersonal = null;
        private PersonalRepository _personalRepository = null;
        private SucursalesRepository _sucursalesRepository = null;
        public List<Personal> _personalTochange = null;
        public DateTime fechaInicio => Convert.ToDateTime(dtpfechainicio.Value.ToLongDateString());
        public DateTime fechaFinal => Convert.ToDateTime(dtpfechafinal.Value.ToLongDateString());
        public string estadocliente;
        public bool allFechas;
        public bool prodActivo;
        public bool prodInactivo;
        public bool todosEstados;
        public int idsucursal;
        public VerPersonal()
        {
            _personalTochange = new List<Personal>();
                _listaPersonal = new List<ListarPersonal>();
            _personalRepository = new PersonalRepository(_context);
            _sucursalesRepository = new SucursalesRepository(_context);
            InitializeComponent();
        }

        private void VerPersonal_Load(object sender, EventArgs e)
        {
            RefrescarDataGrid();
            CargarSucursales();
            checkfechas.Checked = true;
            rbTodos.Checked = true;

        }


        public void RefrescarDataGrid(bool LoadNewContext = true)
        {
           //  _listaPersonal = _personalRepository.GetListaPersonal();

            BindingSource source = new BindingSource();
            source.DataSource = _listaPersonal;
            dgvPersonal.DataSource = typeof(List<>);
            dgvPersonal.DataSource = source;

        }

        private void txtbuscarprod_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPersonal.Rows)
            {
                var Id = int.Parse(row.Cells[0].Value.ToString());
                var personalObtenido = _personalRepository.Get(Id);

                bool estadoActual = Convert.ToBoolean(row.Cells[16].Value);

                if (estadoActual != personalObtenido.IsActive)
                {
                    personalObtenido.IsActive = estadoActual;
                    _personalRepository.Update(personalObtenido);

                }
                else
                {

                    _personalRepository.Update(personalObtenido);
                }
           }
        }

        private void SeleccionAcciones(DataGridView datatgrid, IList<Personal> personaltoChange)
        {


            if (datatgrid.RowCount <= 0) { return; }
            int filasSeleccion = 0;
            foreach (DataGridViewRow Rows in datatgrid.Rows)
            {
                var filasTotales = int.Parse(datatgrid.RowCount.ToString());


                bool acciones = Convert.ToBoolean(Rows.Cells[17].Value);
                if (!acciones)
                {
                    filasSeleccion += 1;
                }
                else
                {
                    var Id = int.Parse(Rows.Cells[0].Value.ToString());
                    var personalObtenido = _personalRepository.Get(Id);

                    personaltoChange.Add(personalObtenido);
                }


                if (filasTotales == filasSeleccion)
                {
                    KryptonMessageBox.Show("Debera tener seleccionada  la columna 'Acciones'\n "
                        + "Selecione un Producto, dando click en la columna Acciones\n"
                        );

                    return;
                }

            }
            abrirForms();


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

        private void btnreporte_Click(object sender, EventArgs e)
        {
            ReportePersonal reporte = new ReportePersonal(_listaPersonal, this);
            reporte.Show();
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

        public void CargarFiltros()
        {
            allFechas = checkfechas.Checked;
            prodActivo = rbActivos.Checked;
            prodInactivo = rbInactivos.Checked;
            todosEstados = rbTodos.Checked;
            idsucursal = int.Parse(cbsucursales.SelectedValue.ToString());


            CargarEstados();

            _listaPersonal = _personalRepository.GetListaPersonal(idsucursal, allFechas, fechaInicio,
              fechaFinal.AddDays(1), prodActivo, prodInactivo, todosEstados);
            RefrescarDataGrid();
        }

        private void btnVista_Click_1(object sender, EventArgs e)
        {
            CargarFiltros();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            var filtro = _listaPersonal.Where(a => a.Nombres.Contains(txtbuscar.Text) ||
        (a.Nombres != null && a.Nombres.Contains(txtbuscar.Text)) ||
         (a.Apellidos != null && a.Apellidos.Contains(txtbuscar.Text)) ||
          (a.Direccion != null && a.Direccion.Contains(txtbuscar.Text)));
            dgvPersonal.DataSource = filtro.ToList();

        }

        private void btntraslado_Click(object sender, EventArgs e)
        {

            SeleccionAcciones(dgvPersonal, _personalTochange);

           


        }

        private void abrirForms()
        {
            //TrasladarPersonal reporte = new TrasladarPersonal(_personalTochange, this);
            //reporte.Show();
        }
    }
}
