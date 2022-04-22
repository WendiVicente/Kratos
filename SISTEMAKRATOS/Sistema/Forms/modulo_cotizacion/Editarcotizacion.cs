using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Cotizacion;
using CapaDatos.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_cotizacion
{
    public partial class Editarcotizacion : BaseContext
    {
        private CotizacionRepository _cotizacionRepository = null;
        private ClientesRepository _clientesRepository = null;
        private ListarCotizaciones _cotizacion = null;
        private Cotizacion _cotizacionOrigen = null;
        public Editarcotizacion(ListarCotizaciones cotizacion)
        {
            _cotizacion = cotizacion;
            _cotizacionRepository = new CotizacionRepository(_context);
            _clientesRepository = new ClientesRepository(_context);
            InitializeComponent();
        }

        private void DetalleCotizacion_Load(object sender, EventArgs e)
        {
            cargarDatos();
            _cotizacionOrigen = _cotizacionRepository.GetCotizacion(_cotizacion.Id);
            cargarTxtCliente();
            cargarDGV();
        }

        private void cargarDatos()
        {
            lbnoVale.Text = _cotizacion.Id.ToString();
            lbfecha.Text = _cotizacion.FechaRecepcion.ToString();
            lbfechalimite.Text = _cotizacion.FechaLimite.ToString();
            txtMonto.Text = _cotizacion.Total.ToString();

        }

        private void cargarTxtCliente()
        {



            var clienteOptenido = _clientesRepository.Get(_cotizacionOrigen.ClienteId);
            if (clienteOptenido == null) return;

            txtcodigoclient.Text = clienteOptenido.CodigoCliente;
            lbtel.Text = clienteOptenido.Telefonos;
            lbnit.Text = clienteOptenido.Nit;
            lbdirec.Text = clienteOptenido.Direccion;


        }
        public void cargarDGV()
        {
            var listadetalle = _cotizacionRepository.GetListDetalleCotiz(_cotizacion.Id);
            BindingSource source = new BindingSource();
            source.DataSource = listadetalle;
            dgvCotizacion.DataSource = typeof(List<>);
            dgvCotizacion.DataSource = source;
            dgvCotizacion.AutoResizeColumns();
            dgvCotizacion.Columns[0].Visible = false;
            dgvCotizacion.Columns[1].Visible = false;
            dgvCotizacion.Columns[2].Visible = false;
            dgvCotizacion.Columns[3].Visible = false;
            dgvCotizacion.Columns[10].Visible = false;
            dgvCotizacion.Columns[11].Visible = false;
            dgvCotizacion.Columns[12].Visible = false;



        }

    }
}
