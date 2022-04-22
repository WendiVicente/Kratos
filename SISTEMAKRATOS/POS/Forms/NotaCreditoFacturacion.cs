using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas.Devoluciones;
using CapaDatos.Repository.DevolucionesRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class NotaCreditoFacturacion : BaseContext
    {
        private NotaCreditoRepository _notaCreditoRepository = null;
        private Pago _pago = null;
        public NotaCreditoFacturacion(Pago forms)
        {
            InitializeComponent();
            _pago = forms;
            CargarListaVentas();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            var filaselected = (ListarNotasCredito)dgvnotascredito.CurrentRow.DataBoundItem;
            if (filaselected == null) { return; }
            var notacredito = _notaCreditoRepository.Get(filaselected.Id);
            _pago._notacredito = notacredito;
            _pago.cargarNcredito();

        }
        public void CargarListaVentas(bool loadNewContext = true, int valor = 0) // 0 es por defecto
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _notaCreditoRepository = null;
                _notaCreditoRepository = new NotaCreditoRepository(_context);
            }

            BindingSource source = new BindingSource();
            var ncreditos = _notaCreditoRepository.GetlistaNotasCreditos();
            var listafiltrada = ncreditos.Where(x => x.Estado == "En Espera").ToList();
            source.DataSource = listafiltrada;
            dgvnotascredito.DataSource = typeof(List<>);
            dgvnotascredito.DataSource = source;
           // dgvnotascredito.Columns[1].Visible = false;


        }
    }
}
