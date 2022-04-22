using CapaDatos.ListasPersonalizadas.Creditos;
using CapaDatos.Models.CuentaCobrar;
using CapaDatos.Repository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
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

namespace Sistema.Forms.modulo_Ccobrar
{
    public partial class CrearCuenta : BaseContext
    {
        private ClientesRepository _clientesRepository = null;
        private CuentasCobrarRepository _cuentasCRepository = null;
        private IList<Cliente> _clientesSinCuentas = null;
        private IList<ListarCuentasCBs> cuentaCBslista => _cuentasCRepository.GetCuentaCBslista();
        private decimal? sumatotal => cuentaCBslista.Sum(a => a.SaldoActual);
        private Cliente _clienteUpdate = null;
        private Layout _layout = null;
        public CrearCuenta(Layout forms)
        {
            _layout = forms;
            _clientesRepository = new ClientesRepository(_context);
            _cuentasCRepository = new CuentasCobrarRepository(_context);
            InitializeComponent();
        }

        private void CrearCuenta_Load(object sender, EventArgs e)
        {
            cargarclienteCombo();
            
            txtfecha.Text = DateTime.Now.ToString();
            cargarcodigo();
            CargarDGVHistorial();
        }
        private void cargarclienteCombo()
        {
            var listaclientes = _clientesRepository.GetClientes();
            _clientesSinCuentas = listaclientes.Where(x => x.PermitirCredito == false).ToList();
            combocliente.DataSource = _clientesSinCuentas;
            combocliente.ValueMember = "Id";
            combocliente.DisplayMember = "Nombres";
            //combocliente.SelectedIndex = 0;
        }

        private void cargartextCliente()
        {
            if (combocliente.SelectedValue is Cliente) return;
            var clienteSeleccionado = int.Parse(combocliente.SelectedValue.ToString());
            var clienteOptenido = _clientesRepository.Get(clienteSeleccionado);
            if (clienteOptenido == null) return;
            txtdpi.Text = clienteOptenido.DPI;
            txttelefono.Text = clienteOptenido.Telefonos;
            txtnit.Text = clienteOptenido.Nit;
            txtnombres.Text = clienteOptenido.Nombres;
            txtapellidos.Text = clienteOptenido.Apellidos;
            _clienteUpdate = clienteOptenido;

        }
        private void CargarDGVHistorial()
        {
            /// var historial = _cuentasCRepository.Getlistadepagoscreditos(idCCB);
            /// 
            
            BindingSource source = new BindingSource();
            source.DataSource = cuentaCBslista;
            dgvcuentas.DataSource = typeof(List<>);
            dgvcuentas.DataSource = source;
            dgvcuentas.AutoResizeColumns();
            dgvcuentas.Columns[0].Visible = false;
            lbtotal.Text = sumatotal.ToString();

        }
        private void updateCliente(Cliente clienteSelected)
        {
            clienteSelected.PermitirCredito = true;
            _clientesRepository.Update(clienteSelected);
        }

        private CuentaCB cuentaCBnueva()
        {
            if (combocliente.SelectedValue == null)
            {
                KryptonMessageBox.Show("Error en creacion de cuenta, hay un valor invalido.");
                return null;
            }
            else
            {
                return new CuentaCB()
                {
                    Id = Guid.NewGuid(),
                    NoCuenta = lbnumerocuenta.Text,
                    FechaCreacion = DateTime.Now,
                    SaldoActual = 0,
                    ClienteId = int.Parse(combocliente.SelectedValue.ToString()),
                    SucursalId = UsuarioLogeadoSistemas.User.SucursalId,
                };
            }  
        }

        private void cargarcodigo()
        {
            string tipocl = "CC-";
            string cuentanueva;
            do
            {
                cuentanueva = GenerateRandom(tipocl);
            }

            while (ExisteNpago(cuentanueva));

            lbnumerocuenta.Text = cuentanueva;
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
        public string GenerateRandom(string tipo)
        {
            Random randomGenerate = new System.Random();
            string nocuenta = tipo;
            var cadena = System.Convert.ToString(randomGenerate.Next(00000001, 99999999));
            var resulto = String.Concat(nocuenta, cadena);
            return resulto;


        }

        private void combocliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargartextCliente();
        }

        private void btnguardarnp_Click(object sender, EventArgs e)
        {
            var modelocuentaCB = cuentaCBnueva();
            if (!ModelState.IsValid(modelocuentaCB)) { return; }
            _cuentasCRepository.Add(modelocuentaCB);
            updateCliente(_clienteUpdate);
           // Close();
            cargarRetry();
        }


        private void cargarRetry()
        {
            CrearCuenta rearCuenta = new CrearCuenta(_layout);
            rearCuenta.Show();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            var filtro = cuentaCBslista.Where(a => a.Cliente.Contains(txtbuscar.Text) ||
          (a.Apellido != null && a.Apellido.Contains(txtbuscar.Text)) ||
           (a.NoCuenta != null && a.NoCuenta.Contains(txtbuscar.Text)) 
           );
            dgvcuentas.DataSource = filtro.ToList();
        }
    }
}
