using CapaDatos.Data;
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

namespace Sistema.Forms.modulo_debitos
{
    public partial class NotaDebitoVista : BaseContext
    {
        private NotaDebitoRepository _notaDebitoRepository = null;
        public NotaDebitoVista()
        {
            _notaDebitoRepository = new NotaDebitoRepository(_context);
            InitializeComponent();
        }

        private void NotaDebitoVista_Load(object sender, EventArgs e)
        {
            CargarListaVentas();
        }
        public void CargarListaVentas(bool loadNewContext = true, int valor = 0) // 0 es por defecto
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _notaDebitoRepository = null;
                _notaDebitoRepository = new NotaDebitoRepository(_context);
            }

            BindingSource source = new BindingSource();
            var ventas = _notaDebitoRepository.GetlistaNotasDebito();
            source.DataSource = ventas;
            dgvnotasdebito.DataSource = typeof(List<>);
            dgvnotasdebito.DataSource = source;
            dgvnotasdebito.Columns[1].Visible = false;


        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnnueva_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["SeleccionarVentaND"] == null)
            {
                SeleccionarVentaND seleccionarVentaND = new SeleccionarVentaND(this);
                ///pos.MdiParent = this;
                seleccionarVentaND.Show();
            }
            else
            {
                Application.OpenForms["SeleccionarVentaND"].Activate();
            }

        }

        private void btnvalidar_Click(object sender, EventArgs e)
        {

        }
    }
}
