using CapaDatos.ListasPersonalizadas;
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

namespace Sistema.Forms.modulo_promos
{
    public partial class NuevaSolicitud : BaseContext
    {
        private ProductosRepository _productosRepository = null;
        private ClientesRepository _clientesRepository = null;
        private int sucursalId = UsuarioLogeadoSistemas.User.SucursalId;
        private IList<ListarProductos> listaproductos = null;
        private IList<ListarClientes> listaclientes = null;
        public NuevaSolicitud()
        {
            _clientesRepository = new ClientesRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            listaproductos = new List<ListarProductos>();
            listaclientes = new List<ListarClientes>();
            InitializeComponent();
        }

        private void NuevaSolicitud_Load(object sender, EventArgs e)
        {
            CargarDgvproductos();
            CargarDgvClientes();
        }


        public void CargarDgvproductos()
        {
            listaproductos = _productosRepository.GetList(sucursalId);
            BindingSource source = new BindingSource();
            source.DataSource = listaproductos;
            dgvproductos.DataSource = typeof(List<>);
            dgvproductos.DataSource = source;
            //dgvproductos.AutoResizeColumns();

        }
        public void CargarDgvClientes()
        {
            listaclientes = _clientesRepository.GetList();
            BindingSource source = new BindingSource();
            source.DataSource = listaclientes;
            dgvclientes.DataSource = typeof(List<>);
            dgvclientes.DataSource = source;
            //dgvclientes.AutoResizeColumns();

        }

        private void txtbuscarproducto_TextChanged(object sender, EventArgs e)
        {
           

            var filter = listaproductos.Where(a => a.Descripcion.Contains(txtbuscarproducto.Text) ||
            (a.CodigoReferencia != null && a.CodigoReferencia.Contains(txtbuscarproducto.Text)) ||
            (a.Categoria != null && a.Categoria.Contains(txtbuscarproducto.Text)) ||
            (a.Notas != null && a.Notas.Contains(txtbuscarproducto.Text)));
            dgvproductos.DataSource = filter.ToList();
        }

        private void txtbuscarcliente_TextChanged(object sender, EventArgs e)
        {
            var filter = listaclientes.Where(a => a.Nombres.Contains(txtbuscarcliente.Text) ||
           (a.Apellidos != null && a.Nit.Contains(txtbuscarcliente.Text)) ||
           (a.Categoria != null && a.Categoria.Contains(txtbuscarcliente.Text)) ||
           (a.CodigoCliente != null && a.CodigoCliente.Contains(txtbuscarcliente.Text)));
            dgvclientes.DataSource = filter.ToList();
        }
    }
}
