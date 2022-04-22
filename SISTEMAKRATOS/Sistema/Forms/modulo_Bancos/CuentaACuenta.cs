using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Bancos;
using CapaDatos.Models.Transacciones;
using CapaDatos.Repository;
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
    public partial class CuentaACuenta : BaseContext
    {
        private readonly TransaccionRepository _transaccionRepository = null;
        private CuentasRepository _cuentasRepository = null;
        private IList<ListarCuentas> listadeCuentas = null;
        private List<CuentaBanco> ListaCuentaOrigen = null;
        private List<CuentaBanco> ListaCuentaDestino = null;
        private int Estadoid;
        private int TipoMoviId;
        private readonly ModuloPagoBancos _vertransac = null;
       
        private string pendiente = "Pendiente";
        public CuentaACuenta(ModuloPagoBancos forms)
        {
            _vertransac = forms;
            _cuentasRepository = new CuentasRepository(_context);
               _transaccionRepository = new TransaccionRepository(_context);
            listadeCuentas = new List<ListarCuentas>();
            ListaCuentaOrigen = new List<CuentaBanco>();
            ListaCuentaDestino = new List<CuentaBanco>();
            InitializeComponent();
        }

        private void CuentaACuenta_Load(object sender, EventArgs e)
        {
            lbfecha.Text = DateTime.Now.ToString();
            txtnotrasacccion.Text = Guid.NewGuid().ToString();
            CargarCombotiposmovi();
            RefrescarDataGridCuentas(dgvlistaAcuenta);
            RefrescarDataGridCuentas(dgvlistaDecuenta);
            cargarEstado();
        }
        private void CargarCombotiposmovi()
        {
            var movimientos = _transaccionRepository.GetlistMovimientos();
            if (movimientos == null) { return; }
            if (movimientos.Where(x => x.Movimiento == "Cuenta a Cuenta").FirstOrDefault() == null) { return; }

            var tipomovfiltro = movimientos.Where(x => x.Movimiento == "Cuenta a Cuenta").FirstOrDefault();
            txttiposmovi.Text = tipomovfiltro.Movimiento;
            TipoMoviId = tipomovfiltro.Id;

        }
        public void RefrescarDataGridCuentas(DataGridView datagrid)
        {


            BindingSource source = new BindingSource();
             listadeCuentas = _cuentasRepository.GetListarCuentas();
            source.DataSource = listadeCuentas;
            datagrid.DataSource = typeof(List<>);
            datagrid.DataSource = source;
            datagrid.AutoResizeColumns();
            for (int i = 0; i < 13; i++)
            {
                datagrid.Columns[i].Visible = false;
            }

            datagrid.Columns[1].Visible = true;
            datagrid.Columns[2].Visible = true;
          //  datagrid.Columns[13].Visible = true;

        }

        private void cargarEstado()
        {
            var estadolista = _transaccionRepository.GetlistEstadosT();

            if(estadolista == null) { return; }
            if(estadolista.Where(x => x.Estado == pendiente).FirstOrDefault() == null) { return; }

            var estadofiltro= estadolista.Where(x => x.Estado == pendiente).FirstOrDefault();
            txtEstado.Text = estadofiltro.Estado;
            Estadoid = estadofiltro.Id;

        }

        private Transaccion GetTransacNueva()
        {
            return new Transaccion()
            {
                Id=Guid.Parse(txtnotrasacccion.Text),
                FechaSolicitud= DateTime.Now,
                Monto= decimal.Parse(txtmontoCaja.Text),
                EstadosTransacId= Estadoid,
                Observaciones= txtobservaciones.Text,
                TipoMovimientoId= TipoMoviId,
                SucursalId= UsuarioLogeadoSistemas.User.SucursalId,
                UsuarioId= UsuarioLogeadoSistemas.User.Id,
            };
        }

        private void guardarTransact()
        {
            ValidarFilaSelected();
            var cuentaOrigen = (ListarCuentas)dgvlistaDecuenta.CurrentRow.DataBoundItem;
            var cuentaDestino = (ListarCuentas)dgvlistaAcuenta.CurrentRow.DataBoundItem;


            var transaccion = GetTransacNueva();

            if (!ModelState.IsValid(transaccion)) { return; }

          
            transaccion.CuentaOrigenId = cuentaOrigen.Id;
            transaccion.CuentaBancoId = cuentaDestino.Id;


            _transaccionRepository.Add(transaccion);
            KryptonMessageBox.Show("Registro guardado correctamente");


            _vertransac.RefrescarDataGridCuentas();
            Close();

        }

        private void ValidarFilaSelected()
        {
            if (dgvlistaDecuenta.CurrentRow == null)
            {
                KryptonMessageBox.Show("Debe seleccinar una Cuenta origen");
                return;
            }
            if (dgvlistaAcuenta.CurrentRow == null)
            {
                KryptonMessageBox.Show("Debe seleccinar una Cuenta Destino");
                return;
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
         
            guardarTransact();
        }



        private void txtbuscarcuentaorigen_TextChanged(object sender, EventArgs e)
        {
            var filtro = listadeCuentas.Where(a => a.NumeroCuenta.Contains(txtbuscarcuentaorigen.Text) ||
           (a.NombreCuenta != null && a.NombreCuenta.Contains(txtbuscarcuentaorigen.Text)) 
            );
            dgvlistaDecuenta.DataSource = filtro.ToList();
        }

        private void txtbuscarCuenta_TextChanged(object sender, EventArgs e)
        {
            var filtro = listadeCuentas.Where(a => a.NumeroCuenta.Contains(txtbuscarcuentaorigen.Text) ||
            (a.NombreCuenta != null && a.NombreCuenta.Contains(txtbuscarcuentaorigen.Text))
             );
            dgvlistaAcuenta.DataSource = filtro.ToList();
        }

        
    }
}
