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
    public partial class EnviarACuenta : BaseContext
    {
        private CajasRepository _cajaRepository = null;
        private TransaccionRepository _transaccionRepository = null;
        private SucursalesRepository _sucursalesRepository = null;
        private CuentasRepository _cuentasRepository = null;
        private int idsucursallog = UsuarioLogeadoSistemas.User.SucursalId;
        private int Estadoid;
        private int TipoMoviId;
        private List<CuentaBanco> ListaCuentaDestino = null;
        private readonly ModuloPagoBancos _vertransac = null;

        public EnviarACuenta(ModuloPagoBancos form)
        {
            _vertransac = form;
            _cajaRepository = new CajasRepository(_context);
            _transaccionRepository = new TransaccionRepository(_context);
            _sucursalesRepository = new SucursalesRepository(_context);
            _cuentasRepository = new CuentasRepository(_context);
            ListaCuentaDestino = new List<CuentaBanco>();
            InitializeComponent();
        }

        private void NuevaTransaccion_Load(object sender, EventArgs e)
        {
            lbfecha.Text = DateTime.Now.ToString();
            txtnotrasacccion.Text = Guid.NewGuid().ToString();
            CargarCombox();
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
            dgvlistacajas.DataSource = typeof(List<>);
            dgvlistacajas.DataSource = source;
            dgvlistacajas.AutoResizeColumns();
            dgvlistacajas.Columns[0].Visible = false;
            dgvlistacajas.Columns[6].Visible = false;
            dgvlistacajas.Columns[7].Visible = false;

        }

        public void RefrescarDataGridCuentas()
        {


            BindingSource source = new BindingSource();
            var cuentaslista = _cuentasRepository.GetListarCuentas();
            source.DataSource = cuentaslista;
            dgvlistacuentas.DataSource = typeof(List<>);
            dgvlistacuentas.DataSource = source;
            dgvlistacuentas.AutoResizeColumns();
            for (int i = 0; i < 14; i++)
            {
                dgvlistacuentas.Columns[i].Visible = false;
            }
           
            dgvlistacuentas.Columns[1].Visible = true;
            dgvlistacuentas.Columns[2].Visible = true;

        }

        private void CargarCombox()
        {
            var sucursal = _sucursalesRepository.GetList();

            // agregar nuevo item a la lista
            sucursal.Add(new ListarSucursales { Id = 0, NombreSucursal = "Todas" });
            var s = sucursal.OrderBy(a => a.Id).ToList();

            // mostrar datos en dgv
            comboSucursal.DataSource = s;
            comboSucursal.DisplayMember = "NombreSucursal";
            comboSucursal.ValueMember = "Id";
            comboSucursal.Text = "Seleccione una Sucursal"; // esto no jalo? no me jalo
            comboSucursal.SelectedIndex = 0;
            comboSucursal.Invalidate();
        }
        private void CargarCombotiposmovi()
        {
            var movimientos = _transaccionRepository.GetlistMovimientos();
            if (movimientos == null) { return; }
            if (movimientos.Where(x => x.Movimiento == "Caja a Cuenta").FirstOrDefault() == null) { return; }

            var tipomovfiltro = movimientos.Where(x => x.Movimiento == "Caja a Cuenta").FirstOrDefault();
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
                UsuarioId = UsuarioLogeadoSistemas.User.Id,
            };
        }

        
        private void guardarTransact()
        {
            ValidarFilaSelected();
            var cajaOrigen = (Caja)dgvlistacajas.CurrentRow.DataBoundItem;
            var cuentaDestino = (ListarCuentas)dgvlistacuentas.CurrentRow.DataBoundItem;
            var transaccion = GetTransacNueva();
            if (!ModelState.IsValid(transaccion)) { return; }
            transaccion.CajaId = cajaOrigen.Id;
            transaccion.CuentaBancoId = cuentaDestino.Id;
            _transaccionRepository.Add(transaccion);
            KryptonMessageBox.Show("Registro guardado correctamente");
        }

        private void ValidarFilaSelected()
        {
            if (dgvlistacajas.CurrentRow == null)
            {
                KryptonMessageBox.Show("Debe seleccinar una Caja origen");
                return;
            }
            if (dgvlistacuentas.CurrentRow == null)
            {
                KryptonMessageBox.Show("Debe seleccinar una Cuenta Destino");
                return;
            }
        }

        



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarTransact();
            _vertransac.RefrescarDataGridProductos();
            Close();
        }

        private void txtbuscarcaja_TextChanged(object sender, EventArgs e)
        {
            /*
             
            var filtro = ListaCuentaDestino.Where(a => a.Sucursal.Contains(txtbuscarCuenta.Text) ||
          (a.EstadoCaja != null && a.EstadoCaja.Contains(txtbuscarCuenta.Text))
           );
            dgvlistacuentas.DataSource = filtro.ToList();
             */

        }

        private void txtbuscarCuenta_TextChanged(object sender, EventArgs e)
        {/*
            var filtro = ListaCuentaDestino.Where(a => a.NumeroCuenta.Contains(txtbuscarCuenta.Text) ||
          (a.NumeroCuenta != null && a.NombreCuenta.Contains(txtbuscarCuenta.Text))
           );
            dgvlistacuentas.DataSource = filtro.ToList();*/
        }

        private void dgvlistacajas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var cajaOrigen = (Caja)dgvlistacajas.CurrentRow.DataBoundItem;
            txtmontoCaja.Text = cajaOrigen.MontoApertura.ToString();
        }
    }
}
