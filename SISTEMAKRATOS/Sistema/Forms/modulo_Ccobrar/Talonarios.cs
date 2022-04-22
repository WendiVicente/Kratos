using CapaDatos.Models.CuentaCobrar;
using Sistema.Reports.Reporte_Creditos;
using CapaDatos.Repository;
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
{    public partial class Talonarios : BaseContext

    {
        private ClientesRepository _clientesRepository = null;
        private CuentasCobrarRepository _cuentasCRepository = null;
        private IList<Cliente> _clientesWithCuentas = null;
        private CuentaCB _cuenta = null;
        private Layout _layout = null;
        public Talonarios(Layout forms)
        {
            _layout = forms;
            _clientesRepository = new ClientesRepository(_context);
            _cuentasCRepository = new CuentasCobrarRepository(_context);
            InitializeComponent();
        }

        private void Talonarios_Load(object sender, EventArgs e)
        {
            txtfecha.Text = DateTime.Now.ToString();
            cargarclienteCombo();
            
        }
        private void cargarclienteCombo()
        {
            _clientesWithCuentas = _clientesRepository.GetClientesbyCredi();
            combocliente.DataSource = _clientesWithCuentas;
            combocliente.ValueMember = "Id";
            combocliente.DisplayMember = "Nombres";
            combocliente.SelectedIndex = 0;
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
            cargarCuentaCliente(clienteOptenido.Id);

        }

        private void cargarCuentaCliente(int cliente)
        {
            _cuenta = _cuentasCRepository.GetCcbyCliente(cliente);
            if (_cuenta == null) { return; }
            lbnumerocuenta.Text = _cuenta.NoCuenta;
            TraerCorrelativo();
        }

        public void  TraerCorrelativo()
        {
            if (_cuentasCRepository.GetTalonariosByCuentacb(_cuenta.Id) == null)
            {
                txtiniciocorrel.Text = "1";
            }
            else
            {
                var talonariosobtenidos = _cuentasCRepository.GetTalonariosByCuentacb(_cuenta.Id);
                var talonariosActuales = talonariosobtenidos.Count() + 1;
                txtiniciocorrel.Text = talonariosActuales.ToString();

            }
            
           // return talonariosActuales;
        }

        public void CrearTalonarios()
        {
            var inicio= int.Parse(txtiniciocorrel.Text);
            var fin = int.Parse(txtfincorrel.Text);
            for (int i = inicio; i <= fin; i++)
            {
                var nuevotalonario = GetnuevoTalonario();
                nuevotalonario.Correlativo = i;
                _cuentasCRepository.AddTalonarios(nuevotalonario);
            }

        }

        public Talonario GetnuevoTalonario()
        {
            return new Talonario()
            {
                Id = Guid.NewGuid(),
                FechaCreacion = DateTime.Now,
                CuentaCBId = _cuenta.Id,
                FechaCambio= DateTime.Now,
            };
        }

        private void combocliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargartextCliente();
          
        }

        private void btnguardarnp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtfincorrel.Text)) { return; }
            CrearTalonarios();
            
            if (checkpdf.Checked == true)
            {
                int inicio = int.Parse(txtiniciocorrel.Text);
                int fin = int.Parse(txtfincorrel.Text);
                cargarImpresion(_cuenta.Id,inicio,fin);
            }
            else
            {
                Close();
                cargarRetry();
            }
          
            
        }
        
        private void cargarRetry()
        {
            Talonarios talonario = new Talonarios(_layout);
            talonario.Show();
        }

        private void cargarImpresion(Guid idcuenta,int inicio,int fin)
        {
            if (Application.OpenForms["TalonariosReporte"] == null)
            {

                TalonariosReporte TalonariosReporte = new TalonariosReporte( idcuenta,  inicio,  fin);

                TalonariosReporte.Show();
            }
            else
            {
                Application.OpenForms["TalonariosReporte"].Activate();
            }
        }

        private void bntimprimir_Click(object sender, EventArgs e)
        {
            int inicio = int.Parse(txtiniciocorrel.Text);
            cargarImpresion(_cuenta.Id, 1, inicio);
        }
    }
}
