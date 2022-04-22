using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Bancos;
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
    public partial class ValidarTransacciones : BaseContext
    {
        private ModuloPagoBancos _verTransacciones = null;
        private ListarTransacciones _Transaccion = null;
        private TransaccionRepository _transaccionRepository = null;
        private Transaccion _transaccionOrigen = null;
        private CuentasRepository _cuentasRepository = null;
        private CajasRepository _cajasRepository = null;
        private string estadoActual;
        private string aprobada = "Aprobada";
        private string denegada = "Denegada";
        private string cancelada = "Cancelada";
        private string pendiente = "Pendiente";
        public ValidarTransacciones(ModuloPagoBancos forms, ListarTransacciones transac)
        {
            _transaccionRepository = new TransaccionRepository(_context);
            _cuentasRepository = new CuentasRepository(_context);
            _cajasRepository = new CajasRepository(_context);
            _verTransacciones = forms;
            _Transaccion = transac;
            _transaccionOrigen = _transaccionRepository.Get(_Transaccion.Id);
            InitializeComponent();
        }

        private void ValidarTransacciones_Load(object sender, EventArgs e)
        {
            cargarTxt();
        }


        private void cargarTxt()
        {
            txtsucursal.Text = _Transaccion.Sucursal;
            txtfecha.Text = _Transaccion.FechaSolicitud.ToString();
            txtmonto.Text = _Transaccion.Monto.ToString();
            txtnotransac.Text = _Transaccion.Id.ToString();
            txtobservaciones.Text = _Transaccion.Observaciones;
            txtestadoactual.Text = _Transaccion.Estado;
            txttipomovi.Text = _Transaccion.TipoMovimiento;
            txtcuentadestino.Text = _Transaccion.CuentaDestino;
            txtcuentaorigen.Text = _Transaccion.CuentaOrigen;
            txtcaja.Text = _Transaccion.CajaId.ToString();
            txtempleado.Text = _Transaccion.Solicitante;

        }




        private void btnpermitir_Click(object sender, EventArgs e)
        {
            if (validar() == 0)
            {
                MsjValidacion();
            }
           
        }

       

        public void PermitirValidacion()
        {
            if (_Transaccion.TipoMovimiento == "Cuenta a Cuenta")
            {
                CuentaACuenta();
            }
            if (_Transaccion.TipoMovimiento == "Cuenta a Caja")
            {
                CuentaACaja();
            }
            if (_Transaccion.TipoMovimiento == "Caja a Cuenta")
            {
                CajaACuenta();
            }
            if(_Transaccion.TipoMovimiento=="Crédito" || _Transaccion.TipoMovimiento == "Débito")
            {
                OperacionesSinFactura();
            }
          
        }

        private void CuentaACuenta()
        {

            var cuentaOrigen = _cuentasRepository.Get(Guid.Parse(_transaccionOrigen.CuentaOrigenId.ToString()));
            var cuentaDestino = _cuentasRepository.Get(Guid.Parse(_transaccionOrigen.CuentaBancoId.ToString()));

           if(_transaccionOrigen.Monto < cuentaOrigen.MontoInicial)
            {
                cuentaOrigen.MontoInicial -= _transaccionOrigen.Monto;
                cuentaDestino.MontoInicial += _transaccionOrigen.Monto;
                _cuentasRepository.Update(cuentaOrigen);
                _cuentasRepository.Update(cuentaDestino);
                estadoActual = aprobada;
                UpdateTransaccion();
            }
            else
            {
                KryptonMessageBox.Show("Transacción no valida, \n No cuenta con suficientes fondos para realizar la transacción");
                estadoActual = cancelada;
                UpdateTransaccion();
                return;
            }

        }


        private void CuentaACaja()
        {

            var caja = _cajasRepository.Get(int.Parse(_transaccionOrigen.CajaId.ToString()));
            var cuenta = _cuentasRepository.Get(Guid.Parse(_transaccionOrigen.CuentaBancoId.ToString()));

            if (cuenta.MontoInicial >_transaccionOrigen.Monto)
            {
                cuenta.MontoInicial -= _transaccionOrigen.Monto;
                caja.MontoApertura += _transaccionOrigen.Monto;
                
                _cuentasRepository.Update(cuenta);
                _cajasRepository.Update(caja);
                estadoActual = aprobada;
                UpdateTransaccion();

            }
            else
            {
                KryptonMessageBox.Show("Transacción no valida, \n No cuenta con suficientes fondos para realizar la transacción");
                estadoActual = cancelada;
                UpdateTransaccion();
                return;
            }

        }
        private void CajaACuenta()
        {

            var cajaDestino = _cajasRepository.Get(int.Parse(_transaccionOrigen.CajaId.ToString()));
            var cuentaDestino = _cuentasRepository.Get(Guid.Parse(_transaccionOrigen.CuentaBancoId.ToString()));

            if (  _transaccionOrigen.Monto < cajaDestino.MontoApertura)
            {

                cuentaDestino.MontoInicial += _transaccionOrigen.Monto;
                cajaDestino.MontoApertura -= _transaccionOrigen.Monto;

                _cuentasRepository.Update(cuentaDestino);
                _cajasRepository.Update(cajaDestino);
                estadoActual =aprobada;
                UpdateTransaccion();
            }
            else
            {
                KryptonMessageBox.Show("Transacción no valida, \n No cuenta con suficientes fondos para realizar la transacción");
                estadoActual = cancelada;
                UpdateTransaccion();
                return;
            }

        }

        private void OperacionesSinFactura()
        {
            var cuentaDestino = _cuentasRepository.Get(Guid.Parse(_transaccionOrigen.CuentaBancoId.ToString()));
            if (_Transaccion.TipoMovimiento == "Crédito")
            {
                cuentaDestino.MontoInicial += _Transaccion.Monto;
                _cuentasRepository.Update(cuentaDestino);
                estadoActual = aprobada;
                UpdateTransaccion();
            }
            if (_Transaccion.TipoMovimiento == "Débito")
            {
                if (cuentaDestino.MontoInicial > _Transaccion.Monto)
                {
                    cuentaDestino.MontoInicial -= _Transaccion.Monto;
                    _cuentasRepository.Update(cuentaDestino);
                    estadoActual = aprobada;
                    UpdateTransaccion();
                }
                else
                {
                    KryptonMessageBox.Show("Transacción no valida, \n No cuenta con suficientes fondos para realizar la transacción");
                    estadoActual = cancelada;
                    UpdateTransaccion();
                    return;
                }

            }

        }




        private void UpdateTransaccion()
        {
             
            _transaccionOrigen.Responsable = UsuarioLogeadoSistemas.User.Name;
            var nuevoEstado = _transaccionRepository.GetEstadosTransac(estadoActual);
            _transaccionOrigen.EstadosTransacId=nuevoEstado.Id;
            _transaccionRepository.Update(_transaccionOrigen);
            _verTransacciones.RefrescarDataGridProductos();
            Close();

        }
        







        private void MsjValidacion()
        {
            
            var dialog = KryptonMessageBox.Show("¿Desea Validar Transacción, esta afectara la base de datos ?", "Desea continuar",
             MessageBoxButtons.YesNoCancel,
             MessageBoxIcon.Question,
             //Message.Create.Text
             MessageBoxDefaultButton.Button2);
            // dale proba okoko

            if (dialog == DialogResult.Yes)
            {
                if (Application.OpenForms["ValidarUsuario"] == null)
                {
                    ValidarUsuario validacion = new ValidarUsuario(this);

                    validacion.Show();
                }

                else { Application.OpenForms["ValidarUsuario"].Activate(); }



            }


        }
        private int validar()
        {

            // var nuevoEstado = _transaccionRepository.GetEstadosTransac(estadoActual);
            if (_Transaccion.Estado == aprobada)
            {
                KryptonMessageBox.Show("Esta transaccion ya esta Aprobada, debera Crear una nueva");
                return 1;
            }
            if (_Transaccion.Estado == denegada)
            {
                KryptonMessageBox.Show("Esta transaccion esta Denegada, debera Crear una nueva");
                return 2;
            }
            if (_Transaccion.Estado == cancelada)
            {
                KryptonMessageBox.Show("Esta transaccion esta Cancelada, debera Crear una nueva");
                return 3;
            }
            if (_Transaccion.Estado == pendiente)
            {

            }
            return 0;

        }

        private void btndenegar_Click(object sender, EventArgs e)
        {
            var traerEstado = validar();
            if (traerEstado == 0)
            {
                var dialog = KryptonMessageBox.Show("¿Desea Denegar esta Transacción,  ?", " continuar?",
           MessageBoxButtons.YesNoCancel,
           MessageBoxIcon.Question,
           //Message.Create.Text
           MessageBoxDefaultButton.Button2);
                // dale proba okoko

                if (dialog == DialogResult.Yes)
                {

                    estadoActual = denegada;
                    UpdateTransaccion();
                }

            }
           
        }
    }
}
