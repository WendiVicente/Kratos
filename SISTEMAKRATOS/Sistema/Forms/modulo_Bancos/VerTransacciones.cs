using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Transacciones;
using CapaDatos.Repository;
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
    public partial class VerTransacciones : BaseContext
    {
        private TransaccionRepository _transaccionRepository = null;
        private CuentasRepository _cuentasRepository = null;

        public VerTransacciones()
        {
            _cuentasRepository = new CuentasRepository(_context);
            _transaccionRepository = new TransaccionRepository(_context);
            InitializeComponent();
        }

        private void Transacciones_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            RefrescarDataGridProductos();
        }


        public void RefrescarDataGridProductos(bool loadNewContext = true)
        {
            BindingSource source = new BindingSource();
            var transacciones = _transaccionRepository.GetListaTransacciones(0,0);
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

        private void checkTodas_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Rows in dgvlistaTransacc.Rows)
            {
                bool acciones = Convert.ToBoolean(Rows.Cells[12].Value);
                if (!acciones)
                {
                    Rows.Cells[12].Value = true;
                }
                else
                {
                    Rows.Cells[12].Value = false;
                }
            }
        }

        private void bntES_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["OperacionesSinFactura"] == null)
            {
                OperacionesSinFactura NuevaCuenta = new OperacionesSinFactura(this);
                // NuevaCuenta.MdiChildren = this;
                NuevaCuenta.MaximizeBox = true;
                NuevaCuenta.Show();
            }

            else
            { Application.OpenForms["OperacionesSinFactura"].Activate(); }
        }
    }
}
