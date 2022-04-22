using CapaDatos.ListasPersonalizadas.Creditos;
using CapaDatos.Models.CuentaCobrar;
using CapaDatos.Repository;
using CapaDatos.Validation;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms.Complementos
{
    public partial class CuentaPorCobrar : BaseContext
    {

        private ClientesRepository _clientesRepository = null;
        private CuentasCobrarRepository _cuentasCRepository = null;
        private IList<Cliente> _clientesSinCuentas = null;
        private IList<ListarCuentasCBs> cuentaCBslista = null; 
        private Cliente _clienteUpdate = null;
        private PuntoDeVenta _pos = null;
        public CuentaPorCobrar( PuntoDeVenta pos)
        {
            _clientesRepository = new ClientesRepository(_context);
            _cuentasCRepository = new CuentasCobrarRepository(_context);
            _pos = pos;
            InitializeComponent();
        }

        private void CuentaPorCobrar_Load(object sender, EventArgs e)
        {
            cargarclienteCombo();
            cargarcodigo();
            CargarDGVHistorial();
        }

        private void cargarclienteCombo()
        {
            var listaclientes = _clientesRepository.GetClientes();
            _clientesSinCuentas = listaclientes.Where(x => x.PermitirCredito == false).ToList();
            cbCliente.DataSource = _clientesSinCuentas;
            cbCliente.ValueMember = "Id";
            cbCliente.DisplayMember = "Nombres";
        }

        private string cargarcodigo()
        {
            string tipocl = "CC-";
            string cuentanueva;
            do
            {
                cuentanueva = GenerateRandom(tipocl);
            }

            while (ExisteNpago(cuentanueva));

            return cuentanueva;
        }

        public string GenerateRandom(string tipo)
        {
            Random randomGenerate = new System.Random();
            string nocuenta = tipo;
            var cadena = System.Convert.ToString(randomGenerate.Next(00000001, 99999999));
            var resulto = String.Concat(nocuenta, cadena);
            return resulto;
        }

        private bool ExisteNpago(string cadena)
        {
            var notapago = _cuentasCRepository.GetNotapago(cadena);
            if (notapago == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void cargartextCliente()
        {
            if (!(cbCliente.SelectedValue is Cliente))
            {
                var clienteSeleccionado = int.Parse(cbCliente.SelectedValue.ToString());
                var clienteObtenido = _clientesRepository.Get(clienteSeleccionado);
                if (clienteObtenido != null)
                {
                    txtdpi.Text = clienteObtenido.DPI;
                    txttelefono.Text = clienteObtenido.Telefonos;
                    txtnit.Text = clienteObtenido.Nit;
                    txtnombres.Text = clienteObtenido.Nombres;
                    txtapellidos.Text = clienteObtenido.Apellidos;
                    _clienteUpdate = clienteObtenido;
                }
            }    
        }
        private void CargarDGVHistorial()
        {
            cuentaCBslista = _cuentasCRepository.GetCuentaCBslista();
            BindingSource source = new BindingSource();
            source.DataSource = cuentaCBslista;
            dgvCuentasPorCobrar.DataSource = typeof(List<>);
            dgvCuentasPorCobrar.DataSource = source;
            dgvCuentasPorCobrar.AutoResizeColumns();
            dgvCuentasPorCobrar.Columns[0].Visible = false;
            dgvCuentasPorCobrar.Columns[4].DisplayIndex = 2;
            dgvCuentasPorCobrar.Columns[5].DisplayIndex = 3;
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargartextCliente();
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            var filtro = cuentaCBslista.Where(a => a.Cliente.Contains(txtBuscador.Text) ||
          (a.Apellido != null && a.Apellido.Contains(txtBuscador.Text)) ||
           (a.NoCuenta != null && a.NoCuenta.Contains(txtBuscador.Text))
           );
           dgvCuentasPorCobrar.DataSource = filtro.ToList();
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            var modelocuentaCB = cuentaCBnueva();
            if (!ModelState.IsValid(modelocuentaCB)) { return; }
            _cuentasCRepository.Add(modelocuentaCB);
            updateCliente(_clienteUpdate);
            CuentaPorCobrar_Load(null, null);
        }

        private CuentaCB cuentaCBnueva()
        {
            return new CuentaCB()
            {
                Id = Guid.NewGuid(),
                NoCuenta = cargarcodigo(),
                FechaCreacion = DateTime.Now,
                SaldoActual = 0,
                ClienteId = int.Parse(cbCliente.SelectedValue.ToString()),
                SucursalId = UsuarioLogeadoPOS.User.SucursalId,
            };
        }

        private void updateCliente(Cliente clienteSelected)
        {
            clienteSelected.PermitirCredito = true;
            _clientesRepository.Update(clienteSelected);
        }

        private void dgvCuentasPorCobrar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var fila = dgvCuentasPorCobrar.CurrentRow;
            var cuenta = (ListarCuentasCBs)fila.DataBoundItem;
            CuentaCB cuentacb = _cuentasCRepository.Get(cuenta.Id);
            _pos.AsignarCuentaxCobrar(cuentacb);
            Close();
        }
    }
}
