using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Bancos;
using CapaDatos.Repository;
using CapaDatos.Repository.PersonalRepository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_Bancos
{
    public partial class ModuloPagoBancos : BaseContext
    {
        CuentasRepository _cuentasRepository = null;
        PropiedadesRepository _propiedadesRepository = null;
        private TransaccionRepository _transaccionRepository = null;

        public Form FormularioVolver;
        public ModuloPagoBancos()
        {
            _transaccionRepository = new TransaccionRepository(_context);
            _cuentasRepository = new CuentasRepository(_context);
            _propiedadesRepository = new PropiedadesRepository(_context);
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            MenuPrincipal(this);
        }

        private void ModuloPagoBancos_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuPrincipal(this, false);
        }
        private CuentaBanco GetCuentaNueva()
        {
            return new CuentaBanco()
            {
                Id = Guid.NewGuid(),
                NombreCuenta = txtnombrecuenta.Text,
                NumeroCuenta = txtnumerocuenta.Text,
                TipoCuenta = txttipocuenta.Text,
                Diaria = checkdiaria.Checked,
                Semanal = checksemanal.Checked,
                Mensual = checkmensual.Checked,
                Anual = checkanual.Checked,
                BancaId = int.Parse(comboBanco.SelectedValue.ToString()),
                Empresa = txtempresa.Text,
                MontoInicial = decimal.Parse(txtmontoinicial.Text),
                 Moneda= int.Parse(ComboMoneda.SelectedValue.ToString()),

            };

        }
        private bool ValidarCuenta()
        {
            var cuentaobtenida = _cuentasRepository.GetNoCuenta(txtnumerocuenta.Text);
            if (cuentaobtenida != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnguardar_Click(object sender, EventArgs e)
        {
            var cuentatosave = GetCuentaNueva();

            if (!ModelState.IsValid(cuentatosave)) { return; }

            if (ValidarCuenta())
            {
                KryptonMessageBox.Show("El número de cuenta ya está almacenado \n debe ingresar uno nuevo!");
            }
            else
            {
                _cuentasRepository.Add(cuentatosave);
                KryptonMessageBox.Show("Registro Guardado con éxito!");
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            txtempresa.Text = "";
            txtnombrecuenta.Text = "";
            txttipocuenta.Text = "";
            txtmontoinicial.Text = "";
            txtnumerocuenta.Text = "";
            checkanual.Checked = false;
            checkdiaria.Checked = false;    
            checkmensual.Checked = false;
            checksemanal.Checked= false;
        }
        public void RefrescarDataGridProductos(bool loadNewContext = true)
        {
            BindingSource source = new BindingSource();
            var transacciones = _transaccionRepository.GetListaTransacciones(0, 0);
            /*
            foreach (var item in transacciones)
            {
                var cuentaOrigenObtenida = _cuentasRepository.Get(Guid.Parse(item.CuentaOrigen));
                if (cuentaOrigenObtenida != null)
                {
                    item.CuentaOrigen = cuentaOrigenObtenida.NumeroCuenta;
                }

            }*/

            source.DataSource = transacciones;
            dgvlistaTransacc.DataSource = typeof(List<>);
            dgvlistaTransacc.DataSource = source;
            dgvlistaTransacc.AutoResizeColumns();
        }
        public void RefrescarDataGridCuentas(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _cuentasRepository = null;
                _cuentasRepository = new CuentasRepository(_context);
            }


            BindingSource source = new BindingSource();
            var clientes = _cuentasRepository.GetListarCuentas();
            source.DataSource = clientes;
            dgvlistaCuentas.DataSource = typeof(List<>);
            dgvlistaCuentas.DataSource = source;
            dgvlistaCuentas.Columns[13].ReadOnly = false;
            dgvlistaCuentas.AutoResizeColumns();
        }

        private void ModuloPagoBancos_Load(object sender, EventArgs e)
        {
            txtfechaactual.Text = DateTime.Now.ToString();
            CargarBancos();
            CargarTipocambio();
            RefrescarDataGridCuentas();
            RefrescarDataGridTransacciones();
        }
        public void RefrescarDataGridTransacciones(bool loadNewContext = true)
        {
            BindingSource source = new BindingSource();
            var transacciones = _transaccionRepository.GetListaTransacciones(0, 0);
            /*
            foreach (var item in transacciones)
            {
                var cuentaOrigenObtenida = _cuentasRepository.Get(Guid.Parse(item.CuentaOrigen));
                if (cuentaOrigenObtenida != null)
                {
                    item.CuentaOrigen = cuentaOrigenObtenida.NumeroCuenta;
                }

            }*/

            source.DataSource = transacciones;
            dgvlistaTransacc.DataSource = typeof(List<>);
            dgvlistaTransacc.DataSource = source;
            dgvlistaTransacc.AutoResizeColumns();
        }
        private void CargarBancos()
        {
            var bancos = _propiedadesRepository.GetListBancos();
            comboBanco.DataSource = bancos;
            comboBanco.DisplayMember = "Entidad";
            comboBanco.ValueMember = "Id";
            comboBanco.SelectedIndex = 0;
            comboBanco.Invalidate();
        }
        private void CargarTipocambio()
        {
            string[] tipos = {
                "Dolares", "Quetzales", "Euros"
            };

            var listatipos = new List<string>(tipos);

            foreach (var item in listatipos)
            {
                ComboMoneda.Items.Add(item);
            }
            ComboMoneda.SelectedIndex = 0;
        }

        private void btnChanceState_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvlistaCuentas.Rows)
            {
                var Id = Guid.Parse(row.Cells[0].Value.ToString());
                var cuentaObtenido = _cuentasRepository.Get(Id);

                string estadoActual = row.Cells[12].Value.ToString();

                if (estadoActual == "Activo")
                {
                    cuentaObtenido.IsActive = false;
                    _cuentasRepository.Update(cuentaObtenido);

                }

                else if (estadoActual == "Inactivo")
                {
                    cuentaObtenido.IsActive = true;

                    _cuentasRepository.Update(cuentaObtenido);
                }
            }

            RefrescarDataGridCuentas(true);
        }

        private void btnoperaciones_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["CuentaACuenta"] == null)
            {
                CuentaACuenta NuevaCuenta = new CuentaACuenta(this);
                // NuevaCuenta.MdiChildren = this;
                NuevaCuenta.MaximizeBox = true;
                NuevaCuenta.Show();
            }

            else { Application.OpenForms["CuentaACuenta"].Activate(); }
        }

        private void btncuantatocaja_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["EnviarACaja"] == null)
            {
                EnviarACaja NuevaCuenta = new EnviarACaja(this);
                // NuevaCuenta.MdiChildren = this;
                NuevaCuenta.MaximizeBox = true;
                NuevaCuenta.Show();
            }

            else
            { Application.OpenForms["EnviarACaja"].Activate(); }
        }

        private void btnNuevaTransac_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["NuevaTransaccion"] == null)
            {
                EnviarACuenta NuevaCuenta = new EnviarACuenta(this);
                // NuevaCuenta.MdiChildren = this;
                NuevaCuenta.MaximizeBox = true;
                NuevaCuenta.Show();
            }

            else { Application.OpenForms["NuevaTransaccion"].Activate(); }
        }

        private void btnacciones_Click(object sender, EventArgs e)
        {
            if (dgvlistaTransacc.CurrentRow == null)
            {
                KryptonMessageBox.Show("Debe seleccinar una Caja Destino");
                return;
            }

            var transaccionSelected = (ListarTransacciones)dgvlistaTransacc.CurrentRow.DataBoundItem;

            if (Application.OpenForms["ValidarTransacciones"] == null)
            {
                ValidarTransacciones NuevaCuenta = new ValidarTransacciones(this, transaccionSelected);
                // NuevaCuenta.MdiChildren = this;
                NuevaCuenta.MaximizeBox = true;
                NuevaCuenta.Show();
            }

            else
            { Application.OpenForms["ValidarTransacciones"].Activate(); }
        }
    }
}
