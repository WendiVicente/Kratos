using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas.Prestamos;
using CapaDatos.Repository;
using CapaDatos.Repository.PrestamosRepository;
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
    public partial class ElegirPrestamo : BaseContext
    {
        private  PrestamoRepository _prestamoRepository = null;
        private CobroCreditos _cobroCreditos = null;
        private readonly ClientesRepository _clientesRepository = null;
        private IList<ListarPrestamos> Listaprestamos = null;
        public ElegirPrestamo(CobroCreditos forms)
        {
            _prestamoRepository = new PrestamoRepository(_context);
            _clientesRepository = new ClientesRepository(_context);
           
            InitializeComponent();
            _cobroCreditos = forms;
            CargarDGV();
        }



        private void btnselection_Click(object sender, EventArgs e)
        {
            if (dgvprestamos.CurrentRow != null)
            {
                RecargarFormulario();
                var prestamofila = (ListarPrestamos)dgvprestamos.CurrentRow.DataBoundItem;

                var clienteObtenido = _clientesRepository.Get(prestamofila.ClienteId);
                _cobroCreditos.clienteActual = clienteObtenido;
                _cobroCreditos.prestamoActual = prestamofila;
                _cobroCreditos.CargarPrestamo();
            }
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

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            var filtro = Listaprestamos.Where(a => a.NoDocumento.Contains(txtbuscar.Text) ||
        (a.Nombrescliente != null && a.Nombrescliente.Contains(txtbuscar.Text)) ||
         (a.Empleado != null && a.Empleado.Contains(txtbuscar.Text)) 
         );
            dgvprestamos.DataSource = filtro.ToList();
        }

        private void ElegirPrestamo_Load(object sender, EventArgs e)
        {

        }

        private void RecargarFormulario()
        {
            if (_cobroCreditos.prestamoActual != null)
            {
                
                _cobroCreditos.LimpiarDatos(true);
               
            }
        }
    }
}
