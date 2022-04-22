using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Repository;
using CapaDatos.Repository.SolicitudestoFacturar;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models.Caja;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_Caja
{
    public partial class ModuloCaja : BaseContext
    {
        //valores actualizados 
        private SucursalesRepository _sucursalesRepository = null;
        private CajasRepository _cajasRepository = null;
        public int sucursalvalor = 0;
        public int estadoCaja = 0;
        private Caja _caja = null;
        private int Sucursalid = UsuarioLogeadoSistemas.User.SucursalId;
        private RepositoryUsuarios _repositoryUsuarios = null;
        private DetallePagoRepository _detallePagoRepository = null;
        decimal totalVentasAcom;
        private DetalleMonetarioRepository _detalleMonetarioRepository = null;
       
        public ModuloCaja()
        {
            _detallePagoRepository = new DetallePagoRepository(_context);
            _sucursalesRepository = new SucursalesRepository(_context);
            _cajasRepository = new CajasRepository(_context);
            _repositoryUsuarios = new RepositoryUsuarios(_context);
            _detalleMonetarioRepository = new DetalleMonetarioRepository(_context);
            InitializeComponent();

        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            MenuPrincipal(this);
        }
        private void CargarValores()
        {
            try
            {
                var obtenerDetalle = _cajasRepository.GetDetalleCaja(_caja.Id);
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
                lbFondoInicial.Text = _caja.MontoApertura.ToString();
                lblPreliminar.Text = ingresos.ToString();
                lbsumaoperacionP.Text = ingresos.ToString();
                //proceso posterior





            }
            catch (Exception ex)
            {

                KryptonMessageBox.Show(ex.Message);
            }


        }
        private void cargarDGVcheques()
        {
            var obtenerDetalle = _detallePagoRepository.GetDetallePagos(_caja.Id, "Cheque");
            BindingSource source = new BindingSource();
            source.DataSource = obtenerDetalle;
            DgvIngresosDetalle.DataSource = typeof(List<>);
            DgvIngresosDetalle.DataSource = source;
            DgvIngresosDetalle.AutoResizeColumns();

        }
        private void ModuloCaja_Load(object sender, EventArgs e)
        {
            _caja = _cajasRepository.GetCajaAperturada(Sucursalid, true);
            RefrescardgCajas();
            CajaActual();
            CargarComboxSucursal();
            CargarComboxEstado();
            cargarUsuariosCombo();
           
        }
        private void cargarEncabezados()
        {

            LbFechaAp.Text = _caja.FechaApertura.ToString();
            LbFechaCierre.Text = DateTime.Now.ToString();
            cargarUsuariosCombo();
        }
        private void cargarUsuariosCombo()
        {
            CbUsuariosReg.ComboBox.DataSource = _repositoryUsuarios.GetlistaUsuarios();
            CbUsuariosReg.ComboBox.DisplayMember = "Name";
            CbUsuariosReg.ComboBox.ValueMember = "Id";
        }
        private void ModuloCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuPrincipal(this, false);
        }

        #region VER CAJAS

        public void RefrescardgCajas(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _cajasRepository = null;
                _cajasRepository = new CajasRepository(_context);
            }
            var obtenercodcajaActiva = _cajasRepository.GetCajas(sucursalvalor, estadoCaja)
                                                       .OrderByDescending(x => x.FechaApertura);
            BindingSource source = new BindingSource();
            source.DataSource = obtenercodcajaActiva;
            DgvCajas.DataSource = typeof(List<>);
            DgvCajas.DataSource = source;
            DgvCajas.ClearSelection();
        }

        private void CargarComboxEstado()
        {
            CbEstado.ComboBox.Items.Insert(0, "Todos");
            CbEstado.ComboBox.Items.Insert(1, "Cerrado");
            CbEstado.ComboBox.Items.Insert(2, "Abierto");
            CbEstado.ComboBox.SelectedIndex = 0;
        }

        private void CargarComboxSucursal()
        {
            var sucursal = _sucursalesRepository.GetList();
            // agregar nuevo item a la lista
            sucursal.Add(new ListarSucursales { Id = 0, NombreSucursal = "Todas" });
            var s = sucursal.OrderBy(a => a.Id).ToList();
            CbSucursal.ComboBox.DataSource = s;
            CbSucursal.ComboBox.DisplayMember = "NombreSucursal";
            CbSucursal.ComboBox.ValueMember = "Id";
            CbSucursal.ComboBox.SelectedIndex = 0;
            CbSucursal.ComboBox.Invalidate();
        }

        private void CbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            var valorCombobox = CbEstado.ComboBox.SelectedIndex.ToString();
            estadoCaja = Convert.ToInt32(valorCombobox);
            RefrescardgCajas(true);
            LimpiarDetalleCaja();
        }

        private void CbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            var valorCombobox = CbSucursal.ComboBox.SelectedValue.ToString();
            int opc = !int.TryParse(valorCombobox, out _) ? 0 : Convert.ToInt32(valorCombobox);
            sucursalvalor = Convert.ToInt32(opc);
            RefrescardgCajas(true);
            LimpiarDetalleCaja();
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            RefrescardgCajas(true);
            LimpiarDetalleCaja();
        }

        private void DgvCajas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvCajas.CurrentRow != null)
            {
                var fila = DgvCajas.CurrentRow;
                ListarCaja listarCaja = (ListarCaja)fila.DataBoundItem;
                if (listarCaja.Id_Transaccion > 0)
                {
                    _caja = _cajasRepository.Get(listarCaja.Id_Transaccion);
                    RefrescardgCajaActiva(true);
                }                    
            }
        }

        public void RefrescardgCajaActiva(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _cajasRepository = null;
                _cajasRepository = new CajasRepository(_context);
            }

            var obtenerDetalle = _cajasRepository.GetDetalleCaja(_caja.Id);
            BindingSource source = new BindingSource();
            source.DataSource = obtenerDetalle;
            DgvDetalleCaja.DataSource = typeof(List<>);
            DgvDetalleCaja.DataSource = source;
            DgvDetalleCaja.ClearSelection();
            //operaciones con las columnas y Labels
            var egresos = obtenerDetalle.Sum(a => a.Egreso);
            var efectivototal = obtenerDetalle.Sum(a => a.Efectivo);
            var chequestotal = obtenerDetalle.Sum(a => a.Cheques);
            var tarjetaDebitototal = obtenerDetalle.Sum(a => a.TarjetaDebito);
            var tarjetaCreditototal = obtenerDetalle.Sum(a => a.TarjetaCredito);
            var ingresos = (efectivototal + chequestotal + tarjetaCreditototal + tarjetaDebitototal);
            lbtotacerrar.Text = (ingresos - egresos).ToString();
            lbtotalinicio.Text = _caja.MontoApertura.ToString();
        }

        private void LimpiarDetalleCaja()
        {
            DgvDetalleCaja.Rows.Clear();
            lbtotacerrar.Text = "0.00";
            lbtotalinicio.Text = "0.00";
        }

        #endregion

        #region CAJA ACTUAL

        public void CajaActual(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _cajasRepository = null;
                _cajasRepository = new CajasRepository(_context);
            }
            int SucursalId = UsuarioLogeadoSistemas.User.SucursalId;
            if (_cajasRepository.GetCajaAperturada(SucursalId, true) == null) { return; }
            var obtenercodcajaActiva = _cajasRepository.GetCajaAperturada(SucursalId, true);
            var codigoobtenido = obtenercodcajaActiva.Id;
            var obtenerDetalle = _cajasRepository.GetDetalleCaja(codigoobtenido);
            BindingSource source = new BindingSource();
            source.DataSource = obtenerDetalle;
            DgvCajaActual.DataSource = typeof(List<>);
            DgvCajaActual.DataSource = source;
            DgvCajaActual.ClearSelection();
            var egresos = obtenerDetalle.Sum(a => a.Egreso);
            var efectivototal = obtenerDetalle.Sum(a => a.Efectivo);
            var chequestotal = obtenerDetalle.Sum(a => a.Cheques);
            var tarjetaDebitototal = obtenerDetalle.Sum(a => a.TarjetaDebito);
            var tarjetaCreditototal = obtenerDetalle.Sum(a => a.TarjetaCredito);
            var ingresos = (efectivototal + chequestotal + tarjetaCreditototal + tarjetaDebitototal);
            LbCerrarCajaActual.Text = (ingresos - egresos).ToString();
            LbMontoIncialCA.Text = obtenercodcajaActiva.MontoApertura.ToString();
        }


        #endregion

        private void btnabrir_Click(object sender, EventArgs e)
        {
            var listaCajasAper = _cajasRepository.GetCajaAperturada(Sucursalid, true);



            if (Application.OpenForms["AperturarCaja"] == null)
            {

                if (listaCajasAper == null)
                {
                    AperturarCaja aperturarCaja = new AperturarCaja(this);
                    aperturarCaja.Show();
                }
                else
                { KryptonMessageBox.Show("ya tiene una caja aperturada "); }

            }

            else { Application.OpenForms["AperturarCaja"].Activate(); }
        }
        private void abrircancelacion()
        {
            if (Application.OpenForms["CierreCaja"] == null)
            {
                if (_cajasRepository.GetCajaAperturada(Sucursalid, true) == null) { KryptonMessageBox.Show("¿No tiene niguna Caja Aperturada?"); return; }

                

                               
                PageCierre.Visible = true;
                kryptonNavigator1.SelectedPage = PageCierre;

            }

            else { Application.OpenForms["CierreCaja"].Activate(); }
        }
        private void cargarDGVTarjeta()
        {
            var obtenerDetalle = _cajasRepository.GetDetalleCaja(_caja.Id);
            var listaFiltroTarjetas = obtenerDetalle.Where(x => x.TarjetaCredito > 0 || x.TarjetaDebito > 0).ToList();
            BindingSource source = new BindingSource();
            source.DataSource = listaFiltroTarjetas;
            DgvIngresosDetalle.DataSource = typeof(List<>);
            DgvIngresosDetalle.DataSource = source;
            DgvIngresosDetalle.AutoResizeColumns();

        }
        private void cargarDGVOtrosingr()
        {
            var obtenerDetalle = _detallePagoRepository.GetDetallePagos(_caja.Id, "Transferencia");
            var obtenerDetalle2 = _detallePagoRepository.GetDetallePagos(_caja.Id, "Boleta Deposito");
            IList<ListaDetallePago> listaFiltroTarjetas = new List<ListaDetallePago>();
            if (obtenerDetalle.Count() > 0 && obtenerDetalle2.Count() > 0)
            {
                listaFiltroTarjetas = obtenerDetalle.Concat(obtenerDetalle2).ToList();
            }
            BindingSource source = new BindingSource();
            source.DataSource = listaFiltroTarjetas;
            DgvIngresosDetalle.DataSource = typeof(List<>);
            DgvIngresosDetalle.DataSource = source;
            DgvIngresosDetalle.AutoResizeColumns();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            abrircancelacion();
            CargarValores();
            cargarDGVcheques();
            cargarDGVTarjeta();
            cargarDGVOtrosingr();
            cargarEncabezados();
        }

        private void btningresoadicional_Click(object sender, EventArgs e)
        {
            validarCaja();
        }
        private void validarCaja()
        {
            var listaCajasAper = _cajasRepository.GetCajaAperturada(Sucursalid, true);

            if (listaCajasAper != null)
            {
                IngresoExtra ingresoadd = new IngresoExtra(listaCajasAper, this);
                ingresoadd.Show();
            }
            else
            { KryptonMessageBox.Show("No hay Caja Aperturada"); }





        }

        private void btnegresosadicional_Click(object sender, EventArgs e)
        {
            var listaCajasAper = _cajasRepository.GetCajaAperturada(Sucursalid, true);

            if (listaCajasAper != null)
            {
                EgresoExtra egresoadd = new EgresoExtra(listaCajasAper, this);
                egresoadd.Show();
            }
            else
            { KryptonMessageBox.Show("No hay Caja Aperturada"); }
        }
        private Caja GetViewModel(Caja caja)
        {
            caja.FechaCierre = DateTime.Now;
            caja.EstadoCaja = false;
            return caja;
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
        private List<DetalleMonetario> getdetalleMonetarios()
        {
            var lista = new List<DetalleMonetario>();

            var m2 = new DetalleMonetario() { CajaId = _caja.Id, Cantidad = int.Parse(txtdosc.Text), Moneda = 200, };
            var m3 = new DetalleMonetario() { CajaId = _caja.Id, Cantidad = int.Parse(txtcien.Text), Moneda = 100, };
            var m4 = new DetalleMonetario() { CajaId = _caja.Id, Cantidad = int.Parse(txtcincuenta.Text), Moneda = 50, };
            var m5 = new DetalleMonetario() { CajaId = _caja.Id, Cantidad = int.Parse(txtveinte.Text), Moneda = 20, };
            var m6 = new DetalleMonetario() { CajaId = _caja.Id, Cantidad = int.Parse(txtdiez.Text), Moneda = 10, };
            var m7 = new DetalleMonetario() { CajaId = _caja.Id, Cantidad = int.Parse(txtcinco.Text), Moneda = 5, };
            var m8 = new DetalleMonetario() { CajaId = _caja.Id, Cantidad = int.Parse(txtmquetzal.Text), Moneda = 1, };
            var m9 = new DetalleMonetario() { CajaId = _caja.Id, Cantidad = int.Parse(txtmcincuentac.Text), Moneda = 0.5m, };
            var m10 = new DetalleMonetario() { CajaId = _caja.Id, Cantidad = int.Parse(txtmveinte.Text), Moneda = 0.2M, };
            var m11 = new DetalleMonetario() { CajaId = _caja.Id, Cantidad = int.Parse(txtmdiez.Text), Moneda = 0.1M, };
            var m12 = new DetalleMonetario() { CajaId = _caja.Id, Cantidad = int.Parse(txtmcinco.Text), Moneda = 0.05M, };
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
        public decimal operacionesBasic()
        {
            decimal operacionReciduo = (Convert.ToDecimal(lbsumaoperacionP.Text) - Convert.ToDecimal(lbsumaingresoparci.Text));
            validarError(operacionReciduo);
            lboperacionIngreso.Text = operacionReciduo.ToString();
            return operacionReciduo;
        }
        private void guardarDesgloseCaja()
        {
            var listadetalle = getdetalleMonetarios();
            foreach (var item in listadetalle)
            {
                _detalleMonetarioRepository.Add(item);
            }


        }
        public void CerrarCaja()
        {
            var obtenercodcajaActiva = _cajasRepository.GetCajaAperturada(Sucursalid, true);
            var cerrarCaja = GetViewModel(obtenercodcajaActiva);
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
                CajaActual(true);
                KryptonMessageBox.Show("EL CIERRE  CUADRADO, OPERACION EXITOSA");
            }

        }
        private void BtnCierreCaja_Click(object sender, EventArgs e)
        {
            CerrarCaja();
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
        private decimal OperacionMulti(decimal valor1, int cantidad)
        {


            return valor1 * cantidad;

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

        private void txtEfectivoEncontrado_TextChanged(object sender, EventArgs e)
        {
           // txtEfectivoEncontrado.Text = txtefectivoMon.Text;
        }

        private void txtefectivoMon_TextChanged(object sender, EventArgs e)
        {
            txtEfectivoEncontrado.Text = txtefectivoMon.Text;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            RefrescardgCajas();
        }
    }
}
