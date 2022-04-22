using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Pedidos;
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

namespace Sistema.Forms.modulo_Pedidos
{
    public partial class DetallesVista : BaseContext
    {
        private PedidoRepository _pedidoRepository = null;
        private ClientesRepository _clientesRepository = null;
        private ListarPedidos _pedido = null;
        private Pedido PedidoOrigen = null;
        public DetallesVista(ListarPedidos pedido)
        {
            _pedido = pedido;
            _pedidoRepository = new PedidoRepository(_context);
            _clientesRepository = new ClientesRepository(_context);
            InitializeComponent();
        }

        private void DetallesVista_Load(object sender, EventArgs e)
        {
            cargarDatos();
            PedidoOrigen = _pedidoRepository.GetPedido(_pedido.Id);
            cargarTxtCliente();
            cargarDGV();
        }
        private void cargarDatos()
        {
            lbnoVale.Text = _pedido.Id.ToString();
            lbfecha.Text = _pedido.FechaRecepcion.ToString();
            lbfechalimite.Text = _pedido.FechaLimite.ToString();
            txtMonto.Text = _pedido.Total.ToString();

        }
        private void cargarTxtCliente()
        {
          

           
            var clienteOptenido = _clientesRepository.Get(PedidoOrigen.ClienteId);
            if (clienteOptenido == null) return;

            txtcodigoclient.Text = clienteOptenido.CodigoCliente;
            lbtel.Text = clienteOptenido.Telefonos;
            lbnit.Text = clienteOptenido.Nit;
            lbdirec.Text = clienteOptenido.Direccion;


        }

        public void cargarDGV()
        {
            var listadetalle= _pedidoRepository.GetListDetallePedido(_pedido.Id);
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
