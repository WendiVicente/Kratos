using CapaDatos.ListasPersonalizadas;
using CapaDatos.Repository;
using CapaDatos.Repository.SolicitudestoFacturar;
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

namespace Sistema.Forms.modulo_Caja
{
    public partial class CajaDesinerNew : Form
    {
        private CajaInicio _cajaIniciofrm = null;
        private CajasRepository _cajasRepository = null;
        private DetalleMonetarioRepository _detalleMonetarioRepository = null;
//private FacturasRepository _facturasRepository = null;
        //private DetallePagoRepository _detallePagoRepository = null;


        private Caja _cajaToclose = null;
        private RepositoryUsuarios _repositoryUsuarios = null;
        Layout _layoutpadre = null;
        // variables
        decimal totalVentasAcom;
        public CajaDesinerNew(CajaInicio cajaInicio, Caja cajaactiva, Layout layoutform)
        {
            _layoutpadre = layoutform;
            _cajaIniciofrm = cajaInicio;
            _cajaToclose = cajaactiva;
            //_cajasRepository = new CajasRepository(_context);
            //_detalleMonetarioRepository = new DetalleMonetarioRepository(_context);
            //_repositoryUsuarios = new RepositoryUsuarios(_context);
            //_facturasRepository = new FacturasRepository(_context);
            //_detallePagoRepository = new DetallePagoRepository(_context);

            InitializeComponent();
            CargarValores();
            // cargarUsuarios();
            cargarEncabezados();
            WindowState = FormWindowState.Maximized;
            cargarDGVcheques();
            cargarDGVTarjeta();
            cargarDGVOtrosingr();
        }

        private void CajaDesinerNew_Load(object sender, EventArgs e)
        {

        }

        private void cargarEncabezados()
        {
            lbusuariologeado.Text = UsuarioLogeadoSistemas.User.Name;
            lbfechaAper.Text = _cajaToclose.FechaApertura.ToString();
            lbfechaCierre.Text = DateTime.Now.ToString();
            cargarUsuariosCombo();
        }
        private void cargarUsuariosCombo()
        {
            cbusuariosRegis.DataSource = _repositoryUsuarios.GetlistaUsuarios();
            cbusuariosRegis.DisplayMember = "Name";
            cbusuariosRegis.ValueMember = "Id";
        }

        private void cargarDGVcheques()
        {
            //var obtenerDetalle = _detallePagoRepository.GetDetallePagos(_cajaToclose.Id, "Cheque");
            BindingSource source = new BindingSource();
            //source.DataSource = obtenerDetalle;
            dgvIngresosCheque.DataSource = typeof(List<>);
            dgvIngresosCheque.DataSource = source;
            dgvIngresosCheque.AutoResizeColumns();

        }
        private void cargarDGVTarjeta()
        {
            var obtenerDetalle = _cajasRepository.GetDetalleCaja(_cajaToclose.Id);
            var listaFiltroTarjetas = obtenerDetalle.Where(x => x.TarjetaCredito > 0 || x.TarjetaDebito > 0).ToList();
            BindingSource source = new BindingSource();
            source.DataSource = listaFiltroTarjetas;
            dgvIngresoTarjeta.DataSource = typeof(List<>);
            dgvIngresoTarjeta.DataSource = source;
            dgvIngresoTarjeta.AutoResizeColumns();

        }
        private void cargarDGVOtrosingr()
        {
            //var obtenerDetalle =  _detallePagoRepository.GetDetallePagos(_cajaToclose.Id, "Transferencia");
            //var obtenerDetalle2 = _detallePagoRepository.GetDetallePagos(_cajaToclose.Id, "Boleta Deposito");
            //IList<ListaDetallePago> listaFiltroTarjetas = new List<ListaDetallePago>();
            //if (obtenerDetalle.Count() > 0 && obtenerDetalle2.Count() > 0)
            //{
            //    listaFiltroTarjetas = obtenerDetalle.Concat(obtenerDetalle2).ToList();
            //}            
            //BindingSource source = new BindingSource();
            //source.DataSource = listaFiltroTarjetas;
            //dgvIngresoOtros.DataSource = typeof(List<>);
            //dgvIngresoOtros.DataSource = source;
            //dgvIngresoOtros.AutoResizeColumns();
        }

        private void txtdosc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtcien_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txtcincuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtveinte_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txtdiez_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtcinco_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txtmquetzal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtmcincuentac_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtmveinte_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtmdiez_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtmcinco_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtmcentavo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }



        private void txtdosc_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtdosc.Text))
            {
                var cantidad = int.Parse(txtdosc.Text);
                lb200.Text = OperacionMulti(200, cantidad).ToString("0.00");
            }
            else
            {
                lb200.Text = "0.00";

            }
            operacionSuma();
        }

        private void txtcien_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtcien.Text))
            {
                var cantidad = int.Parse(txtcien.Text);
                lb100.Text = OperacionMulti(100, cantidad).ToString("0.00");

            }
            else
            {
                lb100.Text = "0.00";

            }
            operacionSuma();
        }

        private void txtcincuenta_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtcincuenta.Text))
            {
                var cantidad = int.Parse(txtcincuenta.Text);
                lb50.Text = OperacionMulti(50, cantidad).ToString("0.00");
            }
            else
            {
                lb50.Text = "0.00";

            }
            operacionSuma();
        }

        private void txtveinte_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtveinte.Text))
            {
                var cantidad = int.Parse(txtveinte.Text);
                lb20.Text = OperacionMulti(20, cantidad).ToString("0.00");
            }
            else
            {
                lb20.Text = "0.00";

            }
            operacionSuma();

        }

        private void txtdiez_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtdiez.Text))
            {
                var cantidad = int.Parse(txtdiez.Text);
                lb10.Text = OperacionMulti(10, cantidad).ToString("0.00");
            }
            else
            {
                lb10.Text = "0.00";

            }
            operacionSuma();
        }

        private void txtcinco_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtcinco.Text))
            {
                var cantidad = int.Parse(txtcinco.Text);
                lb5.Text = OperacionMulti(5, cantidad).ToString("00.00");
            }
            else
            {
                lb5.Text = "0.00";

            }
            operacionSuma();
        }

        private void txtmquetzal_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmquetzal.Text))
            {
                var cantidad = int.Parse(txtmquetzal.Text);
                lb1.Text = OperacionMulti(1M, cantidad).ToString("00.00");
            }
            else
            {
                lb1.Text = "0.00";

            }

            operacionSuma();
        }

        private void txtmcincuentac_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmcincuentac.Text))
            {
                var cantidad = int.Parse(txtmcincuentac.Text);
                lb050.Text = OperacionMulti(0.50M, cantidad).ToString("00.00");
            }
            else
            {
                lb050.Text = "0.00";

            }
            operacionSuma();
        }

        private void txtmveinte_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmveinte.Text))
            {
                var cantidad = int.Parse(txtmveinte.Text);
                lb020.Text = OperacionMulti(0.20M, cantidad).ToString("00.00");
            }
            else
            {
                lb020.Text = "0.00";

            }
            operacionSuma();
        }

        private void txtmdiez_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmdiez.Text))
            {
                var cantidad = int.Parse(txtmdiez.Text);
                lb010.Text = OperacionMulti(0.10M, cantidad).ToString("00.00");
            }
            else
            {
                lb010.Text = "0.00";

            }
            operacionSuma();
        }

        private void txtmcinco_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmcinco.Text))
            {
                var cantidad = int.Parse(txtmcinco.Text);
                lb005.Text = OperacionMulti(0.05M, cantidad).ToString("00.00");
            }
            else
            {
                lb005.Text = "0.00";
            }
            operacionSuma();
        }



        private decimal OperacionMulti(decimal valor1, int cantidad)
        {


            return valor1 * cantidad;

        }
        decimal totalingresoEfectivo;
        decimal totalingresoAdd;
        private void operacionSuma()
        {
            //menor a mayor

            decimal lbv2 = decimal.Parse(lb005.Text);
            decimal lbv3 = decimal.Parse(lb010.Text);
            decimal lbv4 = decimal.Parse(lb020.Text);
            decimal lbv5 = decimal.Parse(lb050.Text);
            decimal lbv6 = decimal.Parse(lb1.Text);
            decimal lbv7 = decimal.Parse(lb5.Text);
            decimal lbv8 = decimal.Parse(lb10.Text);
            decimal lbv9 = decimal.Parse(lb20.Text);
            decimal lbv10 = decimal.Parse(lb50.Text);
            decimal lbv11 = decimal.Parse(lb100.Text);
            decimal lbv12 = decimal.Parse(lb200.Text);

            decimal lbv14 = decimal.Parse(txtcheque.Text);
            decimal lbv15 = decimal.Parse(txttcredito.Text);
            decimal lbv17 = decimal.Parse(txttransfer.Text);

            totalingresoEfectivo = lbv2 + lbv3 + lbv4 + lbv5 + lbv6 + lbv7 + lbv8 + lbv9 + lbv10 + lbv11 + lbv12;
            totalingresoAdd = lbv14 + lbv15 + lbv17;
            txtefectivoMon.Text = totalingresoEfectivo.ToString("Q." + "0.0");
            lbsumaingresoparci.Text = (totalingresoEfectivo + totalingresoAdd).ToString();

            operacionesBasic();
        }

        private void txtcheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as KryptonTextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }
        }

        private void txttcredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as KryptonTextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }
        }

        private void txttdebito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as KryptonTextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }

        private void txttransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as KryptonTextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }
        }

        private void txtcheque_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtcheque.Text))
            {

                operacionSuma();

            }

        }

        private void txttcredito_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txttcredito.Text))
            {

                operacionSuma();

            }


        }



        private void txttransfer_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txttransfer.Text))
            {

                operacionSuma();

            }


        }

        private void txtcheque_Click(object sender, EventArgs e)
        {
            txtcheque.Text = "";
        }

        private void txtcheque_EnabledChanged(object sender, EventArgs e)
        {
            txtcheque.Text = "";
        }
        private Caja GetViewModel(Caja caja)
        {
            caja.FechaCierre = DateTime.Now;
            caja.EstadoCaja = false;
            return caja;
        }
        public void CerrarCaja()
        {

            var cerrarCaja = GetViewModel(_cajaToclose);
            if (!ModelState.IsValid(cerrarCaja)) { return; }//validacion del modelo state


            if (operacionesBasic() > 0)
            {
                KryptonMessageBox.Show("EL CIERRE DE CAJA NO CUADRA, POR FAVOR VALIDAR");
                errorfalla.SetError(this.lboperacionIngreso, "Caja No cuadra");
                return;
            }
            else
            if (operacionesBasic() < 0)
            {
                KryptonMessageBox.Show("EL CIERRE DE CAJA NO CUADRA, POR FAVOR VALIDAR INGRESOS");

                errorfalla.SetError(this.lboperacionIngreso, "Caja No cuadra");
                return;
            }
            else if (operacionesBasic() == 0)
            {
                _cajasRepository.Update(cerrarCaja);
                guardarDesgloseCaja();
                _cajaIniciofrm.RefrescardgCajaActiva(true);
                _cajaIniciofrm.dgvDetalleCajaActiva.DataSource = null;
                KryptonMessageBox.Show("EL CIERRE  CUADRADO, OPERACION EXITOSA");
            }

        }

        public decimal operacionesBasic()
        {
            decimal operacionReciduo = (Convert.ToDecimal(lbsumaoperacionP.Text) - Convert.ToDecimal(lbsumaingresoparci.Text));
            validarError(operacionReciduo);
            lboperacionIngreso.Text = operacionReciduo.ToString();
            return operacionReciduo;
        }

        private void validarError(decimal valor)
        {
            if (valor > 0 || valor < 0)
            {
                errorfalla.SetError(this.lboperacionIngreso, "Caja No cuadra");
                errorcorrecto.Clear();
            }
            else
            {
                errorfalla.Clear();
                errorcorrecto.SetError(this.lboperacionIngreso, "Cuadre Perfecto");
            }

        }


        private void CargarValores()
        {
            try
            {
                var obtenerDetalle = _cajasRepository.GetDetalleCaja(_cajaToclose.Id);
                //operaciones con las columnas y Labels
                var egresos = obtenerDetalle.Sum(a => a.Egreso);
                var efectivototal = obtenerDetalle.Sum(a => a.Efectivo);
                var chequestotal = obtenerDetalle.Sum(a => a.Cheques);
                var tarjetaDebitototal = obtenerDetalle.Sum(a => a.TarjetaDebito);
                var tarjetaCreditototal = obtenerDetalle.Sum(a => a.TarjetaCredito);
                var transferencias = obtenerDetalle.Sum(a => a.Transferencias);
                var ingresos = (efectivototal + chequestotal + tarjetaCreditototal + tarjetaDebitototal);

                lbRcheque.Text = chequestotal < 1 ? "Q.0.00" : chequestotal.ToString("Q." + "0.00");
                lbRefectivo.Text = efectivototal.ToString("Q." + "0.00");
                lbRtcredito.Text = (tarjetaCreditototal + tarjetaDebitototal).ToString("Q." + "0.00");
                totalVentasAcom = ingresos - egresos;
                lbtotalVentasAcom.Text = totalVentasAcom.ToString("Q." + "0.00");
                //nuevas operaciones
                lbFondoInicial.Text = _cajaToclose.MontoApertura.ToString();
                lblPreliminar.Text = ingresos.ToString();
                lbsumaoperacionP.Text = ingresos.ToString();
                //proceso posterior





            }
            catch (Exception ex)
            {

                KryptonMessageBox.Show(ex.Message);
            }


        }
        private void operacionCuadre()
        {

        }
        private DetalleMonetario getModel()
        {
            var detallem = new DetalleMonetario()
            {
                CajaId = _cajaToclose.Id,

            };
            return detallem;
        }

        private List<DetalleMonetario> getdetalleMonetarios()
        {
            var lista = new List<DetalleMonetario>();

            var m2 = new DetalleMonetario() { CajaId = _cajaToclose.Id, Cantidad = int.Parse(txtdosc.Text), Moneda = 200, };
            var m3 = new DetalleMonetario() { CajaId = _cajaToclose.Id, Cantidad = int.Parse(txtcien.Text), Moneda = 100, };
            var m4 = new DetalleMonetario() { CajaId = _cajaToclose.Id, Cantidad = int.Parse(txtcincuenta.Text), Moneda = 50, };
            var m5 = new DetalleMonetario() { CajaId = _cajaToclose.Id, Cantidad = int.Parse(txtveinte.Text), Moneda = 20, };
            var m6 = new DetalleMonetario() { CajaId = _cajaToclose.Id, Cantidad = int.Parse(txtdiez.Text), Moneda = 10, };
            var m7 = new DetalleMonetario() { CajaId = _cajaToclose.Id, Cantidad = int.Parse(txtcinco.Text), Moneda = 5, };
            var m8 = new DetalleMonetario() { CajaId = _cajaToclose.Id, Cantidad = int.Parse(txtmquetzal.Text), Moneda = 1, };
            var m9 = new DetalleMonetario() { CajaId = _cajaToclose.Id, Cantidad = int.Parse(txtmcincuentac.Text), Moneda = 0.5m, };
            var m10 = new DetalleMonetario() { CajaId = _cajaToclose.Id, Cantidad = int.Parse(txtmveinte.Text), Moneda = 0.2M, };
            var m11 = new DetalleMonetario() { CajaId = _cajaToclose.Id, Cantidad = int.Parse(txtmdiez.Text), Moneda = 0.1M, };
            var m12 = new DetalleMonetario() { CajaId = _cajaToclose.Id, Cantidad = int.Parse(txtmcinco.Text), Moneda = 0.05M, };
            //var m14 = new DetalleMonetario() { CajaId = _cajaToclose.Id, Cantidad = int.Parse(txtcheque.Text), Moneda = 500, };
            //var m12 = new DetalleMonetario() { CajaId = _cajaToclose.Id, Cantidad = int.Parse(txtmcinco.Text), Moneda = 500, };
            //var m12 = new DetalleMonetario() { CajaId = _cajaToclose.Id, Cantidad = int.Parse(txtmcinco.Text), Moneda = 500, };

            lista.Add(m2);
            lista.Add(m3);
            lista.Add(m4);
            lista.Add(m5);
            lista.Add(m6);
            lista.Add(m7);
            lista.Add(m8);
            lista.Add(m9);
            lista.Add(m10);
            lista.Add(m11);
            lista.Add(m12);
            return lista;
        }

        private void cargarUsuarios()
        {

        }



        private void guardarDesgloseCaja()
        {
            var listadetalle = getdetalleMonetarios();
            foreach (var item in listadetalle)
            {
                _detalleMonetarioRepository.Add(item);
            }


        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            CerrarCaja();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void TraerDetalleCheque(ListaDetallePago filaSelected, DataGridView datag)
        //{
        //    // var filaActual = filaSelected;
        //    if (filaSelected.FacturaId != null)            
        //    {
        //        var traerlistadetalle = _facturasRepository.GetDetallebyFactura((Guid)filaSelected.FacturaId);
        //        cargarDGVTarjeta(datag, traerlistadetalle);
        //    }
            
        //}
        private void cargarDGVTarjeta(DataGridView grid, IList<ListarDetalleFacturas> listadetalles)
        {

            BindingSource source = new BindingSource();
            source.DataSource = listadetalles;
            grid.DataSource = typeof(List<>);
            grid.DataSource = source;
            grid.AutoResizeColumns();

        }
        private void dgvIngresosCheque_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //var filaselected = (ListaDetallePago)dgvIngresosCheque.CurrentRow.DataBoundItem;
            //TraerDetalleCheque(filaselected, dgvDetalleCheques);
        }

        private void dgvIngresoOtros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //var filaselected = (ListaDetallePago)dgvIngresoOtros.CurrentRow.DataBoundItem;
            //TraerDetalleCheque(filaselected, dgvDetalleOtrosIng);
        }

        private void dgvIngresoTarjeta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //var filaselected = (ListaDetallePago)dgvIngresoTarjeta.CurrentRow.DataBoundItem;
            //TraerDetalleCheque(filaselected, dgvDetalleTarjeta);
        }

        private void txtefectivoMon_TextChanged(object sender, EventArgs e)
        {
            txtEfectivoEncontrado.Text = txtefectivoMon.Text;
        }

        private void lbusuariologeado_Click(object sender, EventArgs e)
        {

        }
    }
}
