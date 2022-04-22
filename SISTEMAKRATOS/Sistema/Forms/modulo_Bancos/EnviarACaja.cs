using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Bancos;
using CapaDatos.Models.Transacciones;
using CapaDatos.Repository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models.Caja;
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
    public partial class EnviarACaja : BaseContext
    {
        private CajasRepository _cajaRepository = null;
        private TransaccionRepository _transaccionRepository = null;
        private CuentasRepository _cuentasRepository = null;
        private int idsucursallog = UsuarioLogeadoSistemas.User.SucursalId;
        private int Estadoid;
        private int TipoMoviId;
        private readonly ModuloPagoBancos _vertransac = null;
        public EnviarACaja(ModuloPagoBancos forms)
        {
            _vertransac = forms;
               _cajaRepository = new CajasRepository(_context);
            _transaccionRepository = new TransaccionRepository(_context);
           
            _cuentasRepository = new CuentasRepository(_context);
            InitializeComponent();
        }

        private void EnviarACaja_Load(object sender, EventArgs e)
        {
            lbfecha.Text = DateTime.Now.ToString();
            txtnotrasacccion.Text = Guid.NewGuid().ToString();
           
            RefrescarDataGridCajas(idsucursallog);
            RefrescarDataGridCuentas();
            CargarCombotiposmovi();
            cargarEstado();
            WindowState = FormWindowState.Maximized;
        }


        public void RefrescarDataGridCajas(int idsucursal)
        {


            BindingSource source = new BindingSource();
            var listaCajas = _cajaRepository.GetCajaAperturada(idsucursal);
            source.DataSource = listaCajas;
            dgvlistaCaja.DataSource = typeof(List<>);
            dgvlistaCaja.DataSource = source;
            dgvlistaCaja.AutoResizeColumns();
            dgvlistaCaja.Columns[0].Visible = false;
            dgvlistaCaja.Columns[6].Visible = false;
            dgvlistaCaja.Columns[7].Visible = false;

        }

        public void RefrescarDataGridCuentas()
        {


            BindingSource source = new BindingSource();
            var cuentaslista = _cuentasRepository.GetListarCuentas();
            source.DataSource = cuentaslista;
            dgvlistaCuenta.DataSource = typeof(List<>);
            dgvlistaCuenta.DataSource = source;
            dgvlistaCuenta.AutoResizeColumns();
            for (int i = 0; i < 14; i++)
            {
                dgvlistaCuenta.Columns[i].Visible = false;
            }

            dgvlistaCuenta.Columns[1].Visible = true;
            dgvlistaCuenta.Columns[2].Visible = true;

        }

       
        private void CargarCombotiposmovi()
        {
            var movimientos = _transaccionRepository.GetlistMovimientos();
            if (movimientos == null) { return; }
            if (movimientos.Where(x => x.Movimiento == "Cuenta a Caja").FirstOrDefault() == null) { return; }

            var tipomovfiltro = movimientos.Where(x => x.Movimiento == "Cuenta a Caja").FirstOrDefault();
            txttiposmovi.Text = tipomovfiltro.Movimiento;
            TipoMoviId = tipomovfiltro.Id;

        }

        private void cargarEstado()
        {
            var estadolista = _transaccionRepository.GetlistEstadosT();

            if (estadolista == null) { return; }
            if (estadolista.Where(x => x.Estado == "Pendiente").FirstOrDefault() == null) { return; }

            var estadofiltro = estadolista.Where(x => x.Estado == "Pendiente").FirstOrDefault();
            txtEstado.Text = estadofiltro.Estado;
            Estadoid = estadofiltro.Id;

        }
        private Transaccion GetTransacNueva()
        {
            return new Transaccion()
            {
                Id = Guid.Parse(txtnotrasacccion.Text),
                FechaSolicitud = DateTime.Now,
                Monto = decimal.Parse(txtmontoCaja.Text),
                EstadosTransacId = Estadoid,
                Observaciones = txtobservaciones.Text,
                TipoMovimientoId = TipoMoviId,
                SucursalId = UsuarioLogeadoSistemas.User.SucursalId,
                UsuarioId= UsuarioLogeadoSistemas.User.Id,
            };
        }
        private void guardarTransact()
        {
            ValidarFilaSelected();
            if (dgvlistaCaja.CurrentRow == null) { return; }
            var cajaOrigen = (Caja)dgvlistaCaja.CurrentRow.DataBoundItem;
            var cuentaDestino = (ListarCuentas)dgvlistaCuenta.CurrentRow.DataBoundItem;
            var transaccion = GetTransacNueva();
            if (!ModelState.IsValid(transaccion)) { return; }
            transaccion.CajaId = cajaOrigen.Id;
            transaccion.CuentaBancoId = cuentaDestino.Id;
            _transaccionRepository.Add(transaccion);
            KryptonMessageBox.Show("Registro guardado correctamente");
        }


        private void ValidarFilaSelected()
        {
            if (dgvlistaCaja.CurrentRow == null)
            {
                KryptonMessageBox.Show("Debe seleccinar una Caja Destino");
                return;
            }
            if (dgvlistaCuenta.CurrentRow == null)
            {
                KryptonMessageBox.Show("Debe seleccinar una Cuenta Origen");
                return;
            }
        }





        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarTransact();
            _vertransac.RefrescarDataGridProductos();
            Close();
        }

        private void txtbuscarCuenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbuscarCaja_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
