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
    public partial class OperacionesSinFactura : BaseContext
    {
        private readonly TransaccionRepository _transaccionRepository = null;
        private CuentasRepository _cuentasRepository = null;
        private IList<ListarCuentas> listadeCuentas = null;
        private List<CuentaBanco> ListaCuentaOrigen = null;
    
        private int Estadoid;
        
        private readonly VerTransacciones _vertransac = null;
        public OperacionesSinFactura(VerTransacciones forms)
        {
            _vertransac = forms;
            _cuentasRepository = new CuentasRepository(_context);
            _transaccionRepository = new TransaccionRepository(_context);
            listadeCuentas = new List<ListarCuentas>();
            ListaCuentaOrigen = new List<CuentaBanco>();
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        private void OperacionesSinFactura_Load(object sender, EventArgs e)
        {
            lbfecha.Text = DateTime.Now.ToString();
            txtnotrasacccion.Text = Guid.NewGuid().ToString();
            RefrescarDataGridCuentas(dgvlistaDecuenta);
            CargarCombotiposmovi();
            cargarEstado();
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
                TipoMovimientoId = int.Parse(comboTipoTransac.SelectedValue.ToString()),
                SucursalId = UsuarioLogeadoSistemas.User.SucursalId,
                UsuarioId = UsuarioLogeadoSistemas.User.Id,
            };
        }


        private void guardarTransact()
        {
            var cuentaDestino = (ListarCuentas)dgvlistaDecuenta.CurrentRow.DataBoundItem;
            var transaccion = GetTransacNueva();
            if (!ModelState.IsValid(transaccion)) { return; }
            transaccion.CuentaBancoId = cuentaDestino.Id;
            _transaccionRepository.Add(transaccion);
            KryptonMessageBox.Show("Registro guardado correctamente");
            _vertransac.RefrescarDataGridProductos();
            Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarTransact();
        }
        private void CargarCombotiposmovi()
        {
            var movimientos = _transaccionRepository.GetlistMovimientos();
            if (movimientos == null) { return; }

            var listaCredito = movimientos.Where(x => x.Movimiento == "Crédito").Concat(movimientos.Where(x=> x.Movimiento=="Débito")).ToList();
            comboTipoTransac.DataSource = listaCredito;
            comboTipoTransac.DisplayMember = "Movimiento";
            comboTipoTransac.ValueMember = "Id";
            comboTipoTransac.Invalidate();

        }


    }
}
