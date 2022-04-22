using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.ListasPersonalizadas.VentasAcumuladas;
using CapaDatos.Models.CuentaCobrar;
using CapaDatos.Models.DocumentoSAT;
using CapaDatos.Models.ProductosToFacturar;
using CapaDatos.Repository;
using CapaDatos.Repository.DevolucionesRepository;
using CapaDatos.Repository.SolicitudestoFacturar;
using CapaDatos.Validation;
using CapaDatos.WebServiceSAT;
using ComponentFactory.Krypton.Toolkit;
using Newtonsoft.Json;
using POS.Recibo;
using POS.Validations;
using sharedDatabase.Models;
using sharedDatabase.Models.Caja;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Mapping;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApi;

namespace POS.Forms
{
    public partial class Pago : BaseContext
    {
        private readonly ClientesRepository _clientesRepository = null;
        private readonly PrincipalV2 _formPadre = null;
        private readonly VentasRepository _ventasRepository = null;
        private readonly ProductosRepository _productosRepository = null;
        private readonly FacturasRepository _facturasRepository = null;
        private readonly ProductosTempRepository _productosTempRepository = null;
        private readonly CajasRepository _cajasRepository = null;
        private readonly CertificadoSatRepository _certificadoSatRepository = null;
        private readonly CuentasCobrarRepository _cuentasCobrarRepository = null;
        private readonly ProductosReservaRepository _productosReservaRepository = null;
        private readonly SolicitudesRepository _solicitudesRepository = null;

        private readonly NotaCreditoRepository _notaCreditoRepository = null;
        public List<ListarAcumuladasEncabezado> _ventaacumuladaSelected = null;
        public NotaCredito _notacredito = null;
        private ColoresRepository _coloresRepository = null;
        private TallasRepository _tallasRepository = null;
        private TallasyColoresRepository _tallasyColoresRepository = null;
        private CombosRepository _combosRpepository = null;
        private int sucursalId = UsuarioLogeadoPOS.User.SucursalId;
        public List<ListarDetalleFacturas> listaDetalleFacturas = null;
        private DocumentoCertificadoSAT DocCertificado = null;
        public List<RESPONSE> clienteResponse = null;
        private int idclientetosend;
        public Guid guidFacturaid;
        private TokenSAT TokenObtenidoSat;
        public Pago(PrincipalV2 formPadre, List<ListarDetalleFacturas> detalleFacturalista, List<ListarAcumuladasEncabezado> ventaAcumulada)
        {
            _formPadre = formPadre;
            _ventaacumuladaSelected = ventaAcumulada;
            _facturasRepository = new FacturasRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            _ventasRepository = new VentasRepository(_context);
            _clientesRepository = new ClientesRepository(_context);
            _cajasRepository = new CajasRepository(_context);
            _certificadoSatRepository = new CertificadoSatRepository(_context);
            _productosReservaRepository = new ProductosReservaRepository(_context);
            _notaCreditoRepository = new NotaCreditoRepository(_context);
            _solicitudesRepository = new SolicitudesRepository(_context);
            InitializeComponent();
            listaDetalleFacturas = detalleFacturalista;
            _coloresRepository = new ColoresRepository(_context);
            _tallasRepository = new TallasRepository(_context);
            _tallasyColoresRepository = new TallasyColoresRepository(_context);
            _combosRpepository = new CombosRepository(_context);
            _cuentasCobrarRepository = new CuentasCobrarRepository(_context);
            _productosTempRepository = new ProductosTempRepository(_context);
            TokenObtenidoSat = new TokenSAT();
        }

        public void cargarNcredito()
        {
            if (_notacredito != null)
            {
                txtnotacredito.Text = _notacredito.NoDocumento;
                lbncreditomonto.Text = "Q." + _notacredito.MontoDisponible.ToString() + " " + "Saldo a Favor";

                if (!string.IsNullOrEmpty(txtmonto.Text))
                {
                    var saldoTofavor = decimal.Parse(txtmonto.Text) + _notacredito.MontoDisponible;
                    txttotalingreso.Text = saldoTofavor.ToString();
                    txtcambio.Text = (saldoTofavor - decimal.Parse(ltotalapargar.Text)).ToString();
                }


            }
        }
        private void Pago_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarLabels();
            CargarPago();
            groupCredito.Visible = false;
            groupCC.Visible = false;
            checkFEL.Visible = true;
            grupmontos.Visible = false;
            ltotalapargar.Text = obtenerTotal();
           // TokenObtenidoSat = JsonConvert.DeserializeObject<TokenSAT>(TokenPOST.GetToken());
            Crearcorrelativo();

        }

        private string obtenerTotal()
        {
            String total = "";
            decimal cantidad = 0;


            if (listaDetalleFacturas.Count() > 0)
            {
                foreach (var item in listaDetalleFacturas)
                {
                    decimal tmp1 = item.Precio;
                    int tmp2 = item.Cantidad;
                    if (item.Descuento > 0)
                    {
                        tmp1 -= item.Descuento;
                    }
                    cantidad = cantidad + (tmp1 * tmp2);
                }
                
            }

            total = cantidad.ToString();
            return total;
        }
        private void Crearcorrelativo()
        {
            string tipo = "CR-";
            string numerocorrel;
            do
            {
                numerocorrel = GenerarNumeroAleatorios.GenerateRandom(tipo);
            }

            while (ExisteNoCotizacion(numerocorrel));
            txtcorrelativo.Text = numerocorrel;


        }
        private bool ExisteNoCotizacion(string cadena)
        {
            var factunumero = _ventasRepository.GetbyNoCorrelativo(cadena);
            if (factunumero == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // usa PascalCase
        private void CargarClientes()
        {
            if (_clientesRepository.GetClientes() == null) { return; }
            comboxclientes.DataSource = _clientesRepository.GetClientes();
            comboxclientes.DisplayMember = "Nombres";
            comboxclientes.ValueMember = "Id";

        }

        private void CargarLabels()
        {
            txtmonto.Text = "0.00";
            txttotalingreso.Text = "0.00";
            if (txtmonto.Text == "0.00") { txtcambio.Text = "0.00"; txtcambio.BackColor = Color.White; }
        }

        private void CargarPago()
        {
            comboxpagos.Items.Insert(0, "Efectivo");
            comboxpagos.Items.Insert(1, "Cheque");
            comboxpagos.Items.Insert(2, "Tarjeta de Crédito");
            comboxpagos.Items.Insert(3, "Tarjeta de Débito");
            comboxpagos.Items.Insert(4, "Cuentas por Cobrar");
            comboxpagos.Items.Insert(5, "Transferencia");
            comboxpagos.SelectedIndex = 0;

        }

        public Factura GetViewModel()
        {

            return new Factura()
            {
                Id = Guid.NewGuid(),
                Nombre = txtnombre.Text,
                Direccion = txtdireccion.Text,
                NIT = txtnit.Text,
                FechaVenta = DateTime.Now,
                ClienteId = idclientetosend,
                NoFactura = txtcorrelativo.Text,
                Vendedor = UsuarioLogeadoPOS.User.Name,

                TipoPago = comboxpagos.SelectedItem.ToString(),
                UserId = UsuarioLogeadoPOS.User.Id,

            };
        }
        private NotaCredito updateNotacredito(NotaCredito notacredito)
        {
            var totalfactura = listaDetalleFacturas.Sum(x => x.PrecioTotal);
            var reciduo = notacredito.MontoDisponible - totalfactura;
            if (notacredito.MontoDisponible >= totalfactura)
            {
                notacredito.MontoDisponible = reciduo;
            }
            if (notacredito.MontoDisponible < totalfactura)
            {
                notacredito.MontoDisponible = 0;
                //notacredito.Estado = true;
            }
            if (reciduo <= 0)
            {
                notacredito.Estado = true;
            }

            notacredito.FechaAceptacion = DateTime.Now;
            return notacredito;
        }
        private DetalleCaja getdetalleCaja()
        {
            return new DetalleCaja()
            {
                Descripcion = comboxpagos.SelectedItem.ToString()
            };
        }

        private void GuardarCambios()
        {
            var montoTotalaPagar = decimal.Parse(ltotalapargar.Text);
            if (string.IsNullOrEmpty(txtnombre.Text))
            {
                error1.SetError(txtnombre, "Ingrese un nombre o CF");
               // KryptonMessageBox.Show("Datos obligatorios");
                return;

            }
            if (string.IsNullOrEmpty(txtnit.Text))
            {
                error2.SetError(txtnit, "Ingrese un nit o CF");
                return;
            }


            if (checkMontosdiv.Checked == true)
            {
                decimal montoMontos = decimal.Parse(txtmontoMonto.Text);
                if (montoMontos < montoTotalaPagar)
                {
                    KryptonMessageBox.Show("Monto ingresado es menor al Total a Pagar..");
                    return;
                }else if (montoMontos > montoTotalaPagar)
                {
                    KryptonMessageBox.Show("La sumatoria es mayor a lo pagado por favor validar montos..");
                    return;
                }

            }
            else
            {
                if (string.IsNullOrEmpty(txtmonto.Text)) return;

                if (comboxclientes.SelectedValue == null) return;

                var montoIngresado = decimal.Parse(txttotalingreso.Text);

                if (montoIngresado < montoTotalaPagar)
                {
                    KryptonMessageBox.Show("Monto ingresado es menor al Total a Pagar..");
                    return;
                }
             
            }

            try
            {
                if (_cajasRepository.GetCajaAperturada(sucursalId) == null)
                {
                    KryptonMessageBox.Show("No hay ninguna caja aperturada en esta sucursal");
                    return;
                }
                var cajaObtenida = _cajasRepository.GetCajaAperturada(sucursalId);
                var detalleFactura = listaDetalleFacturas; // los datos del detalle de los productos

                var listaErrores = new List<String>();
                var cadenadeError = "";
                foreach (var item in detalleFactura)
                {
                    if (!_formPadre.ValidarExistencias(item, false))
                    {
                        cadenadeError += "No hay suficiente stock del producto:"
                                 + item.Descripcion + " " + item.Color + " " + item.Talla + " " + "Revise existencias!\n";
                        listaErrores.Add(cadenadeError);
                        continue;
                    }

                }

                if (listaErrores.Count > 0) { KryptonMessageBox.Show(cadenadeError); return; }

                if (comboxpagos.SelectedIndex != 4)
                {
                    var modelFactura = GetViewModel(); // los datos del encabezado
                    if (modelFactura.ClienteId == 0) { modelFactura.ClienteId = null; }
                    if (!ModelState.IsValid(modelFactura)) { return; }

                    var detalleCaja = getdetalleCaja(); //obtener caja detalle
                    if (!ModelState.IsValid(detalleCaja)) { return; }
                    guidFacturaid = modelFactura.Id;

                    if (checkFEL.Checked == true)
                    {
                        modelFactura.TieneFel = true;//
                    }

                    _ventasRepository.Add(modelFactura);

                    if (cajaObtenida == null)
                    { return; }
                        detalleCaja.CajaId = cajaObtenida.Id;
                    detalleCaja.FacturaId = guidFacturaid;

                    if (checkMontosdiv.Checked == true)
                    {
                        detalleCaja.Efectivo = txtefectivoMonto.Text.Trim() == "" ? 0.00M : decimal.Parse(txtefectivoMonto.Text);
                        detalleCaja.Cheques = txtchequeMonto.Text.Trim() == "" ? 0.00M : decimal.Parse(txtchequeMonto.Text);
                        detalleCaja.TarjetaCredito = txtcreditoMonto.Text.Trim() == "" ? 0.00M : decimal.Parse(txtcreditoMonto.Text);
                        detalleCaja.TarjetaDebito = txtdebitoMonto.Text.Trim() == "" ? 0.00M : decimal.Parse(txtdebitoMonto.Text);
                        detalleCaja.Transferencia = txttrasnferMonto.Text.Trim() == "" ? 0.00M : decimal.Parse(txttrasnferMonto.Text);

                    }
                    else
                    {
                        if (comboxpagos.SelectedIndex == 0) { detalleCaja.Efectivo = decimal.Parse(ltotalapargar.Text); }
                        if (comboxpagos.SelectedIndex == 1) { detalleCaja.Cheques = decimal.Parse(ltotalapargar.Text); }
                        if (comboxpagos.SelectedIndex == 2) { detalleCaja.TarjetaCredito = decimal.Parse(ltotalapargar.Text); }
                        if (comboxpagos.SelectedIndex == 3) { detalleCaja.TarjetaDebito = decimal.Parse(ltotalapargar.Text); }
                        if (comboxpagos.SelectedIndex == 5) { detalleCaja.Transferencia = decimal.Parse(ltotalapargar.Text); }
                    }
                  



                    _cajasRepository.AddDetalleCaja(detalleCaja);
                    foreach (var item in detalleFactura)
                    {
                        if (_formPadre.ValidarExistencias(item, true))
                        {
                            var producto = _productosRepository.Get(item.ProductoId);
                            var detalle = NuevoDetalleFactura(producto, item, guidFacturaid);
                            _facturasRepository.Add(detalle, true);

                        }
                    }
                    guardarNotaCredito();
                    ActualizarVentaPendiente();
                    KryptonMessageBox.Show("Venta Registrada con exito");
                    //_formPadre._listaDetalleFacturas.Clear();
                    if (_formPadre._listaDetalleFacturas.Count > 0)
                    {
                        _formPadre.cargarDGVDetalleFactura(_formPadre._listaDetalleFacturas);
                        _formPadre.AccesoProductoRepository();
                        abrirRecibo();
                        if (checkFEL.Checked == true)
                        {
                            AperturaReporteFEl();
                        }
                        _formPadre.CargarBD();
                        _formPadre.ventaAcumuladaSelected = null;
                    }
                    else
                    {
                        KryptonMessageBox.Show("¡Lista de Detalle ya se ha vaciado!");
                    }

                    }
                else
                {

                    if (IsvalidTalonario == true)
                    {
                        AgregarItemstoCuenta(detalleFactura);
                        GuardarTransaccion();
                        noTalonario.Nombre = txtnombre.Text;
                        noTalonario.FechaCambio = DateTime.Now;
                        noTalonario.Estado = true;
                        _cuentasCobrarRepository.UpdateTalonario(noTalonario);
                        AbrirComprobante(noTalonario, detalleFactura);
                        //Close();

                    }
                    else
                    {
                        KryptonMessageBox.Show("Talonario no valido,debe validar uno nuevo!");
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private DetalleFactura NuevoDetalleFactura(Producto producto, ListarDetalleFacturas item, Guid idfact)
        {
            var detalle = new DetalleFactura() {
                FacturaId = idfact,
                Cantidad = item.Cantidad,
                Precio = item.Precio,
                Descuento = item.Descuento,
                SubTotal = (item.Cantidad * item.Precio),
                PrecioTotal = (item.Cantidad * item.Precio) - item.Descuento,
            };

            if (item.ProductoId != 0)
            {
                detalle.ProductoId = producto.Id;
            }
            if (item.DetalleColorId != 0)
            {
                detalle.DetalleColorId = item.DetalleColorId;
            }
            if (item.DetalleTallaId != 0)
            {
                detalle.DetalleTallaId = item.DetalleTallaId;
            }
            if (item.TallayColorId != 0)
            {
                detalle.DetalleColorTallaId = item.TallayColorId;
            }
            if (item.ProductoId == 0)
            {
                detalle.ComboId = item.ComboId;
            }

            return detalle;
        }
        private TemporalProductos NuevoProductosTemp(Producto producto, ListarDetalleFacturas item)
        {
            var temporalP = new TemporalProductos()
            {
                //FacturaId = idfact,
                Cantidad = item.Cantidad,
                Precio = item.Precio,
                Descuento = item.Descuento,
                SubTotal = (item.Cantidad * item.Precio),
                PrecioTotal = (item.Cantidad * item.Precio) - item.Descuento,
            };

            if (item.ProductoId != 0)
            {
                temporalP.ProductoId = producto.Id;
            }
            if (item.DetalleColorId != 0)
            {
                temporalP.DetalleColorId = item.DetalleColorId;
            }
            if (item.DetalleTallaId != 0)
            {
                temporalP.DetalleTallaId = item.DetalleTallaId;
            }
            if (item.TallayColorId != 0)
            {
                temporalP.DetalleColorTallaId = item.TallayColorId;
            }
            if (item.ProductoId == 0)
            {
                temporalP.ComboId = item.ComboId;
            }

            return temporalP;
        }


        private void txtmonto_TextChanged(object sender, EventArgs e)
        {
            cargarSaldos();


        }

        private void cargarSaldos()
        {
            if (string.IsNullOrEmpty(txtmonto.Text))
            {
                txtcambio.Text = "0.00";
                txtcambio.BackColor = Color.White;
                return;
            }

            decimal montoIngresado = decimal.Parse(txtmonto.Text.ToString());
            if (_notacredito != null)
            {
                montoIngresado += _notacredito.Monto;
            }
            txttotalingreso.Text = montoIngresado.ToString();
            var pagoTotal = decimal.Parse(ltotalapargar.Text.ToString());
            var validarVuelto = montoIngresado - pagoTotal;
            txtcambio.Text = validarVuelto.ToString();

            if (validarVuelto < 0) txtcambio.BackColor = Color.Red;
            if (validarVuelto >= 0) txtcambio.BackColor = Color.White;
        }
        private void txtmonto_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnpagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtnit.Text))
                {
                    error1.SetError(txtnombre, "Ingrese un nombre o CF");
                    // KryptonMessageBox.Show("Datos obligatorios");
                    return;
                }
                if (Convert.ToDecimal(txtmonto.Text.ToString()) < Convert.ToDecimal(ltotalapargar.Text.ToString()))
                {
                    KryptonMessageBox.Show("Debe ingresar un monto válido");
                    // KryptonMessageBox.Show("Datos obligatorios");
                    return;
                }
                error1.Clear();
                error2.Clear();
                if (checkbStorageFact.Checked == true)
                {
                    var dialog = KryptonMessageBox.Show("Esta seguro de no emitir factura en esta venta?", "Continuar",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                    if (dialog == DialogResult.Yes)
                    {
                        var detalleFactura = listaDetalleFacturas; // los datos del detalle de los productos
                        foreach (var item in detalleFactura)
                        {
                            if (_formPadre.ValidarExistencias(item, false))
                            {
                                if (item.ProductoId > 0)
                                {
                                    var producto = _productosRepository.Get(item.ProductoId);
                                    var producTemps = NuevoProductosTemp(producto, item);
                                    _productosTempRepository.Add(producTemps, true);
                                }
                                else
                                {
                                    KryptonMessageBox.Show("Un producto no pudo añadirse a la lista.");
                                }

                            }
                        }
                        ActualizarVentaPendiente();
                        KryptonMessageBox.Show("Venta Guardada correctamente");
                        _formPadre.CargarBD();
                        _formPadre.ventaAcumuladaSelected = null;
                        Close();

                    }


                }
                else
                {
                    GuardarCambios();
                }

                var lista = listaDetalleFacturas;
                TemporalProductos productoLista = null;
                if (lista.Count > 0)
                {
                    Context db = new Context();
                    foreach (var item in lista)
                    {
                        _formPadre.eliminarDGVDetalleFactura(item.ProductoId);
                        productoLista = db.TemporalProductos.Find(item.ProductoId);
                        if (productoLista != null)
                        {
                            productoLista.IsActive = true;
                            db.SaveChanges();
                        }
                    }
                }
                _formPadre.resetValues();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Ha ocurrido un problema interno, por favor revise la informacion ingresada.");
                return;
            }
        }

        private void abrirRecibo()
        {

            //if (checkFEL.Checked == false)
            //{
            //    if (Application.OpenForms["ReciboVenta"] == null)
            //    {
            //        ReciboVenta reciboVenta = new ReciboVenta(this, guidFacturaid);

            //        reciboVenta.Show();
            //    }
            //    else
            //    {
            //        Application.OpenForms["ReciboVenta"].Activate();
            //    }
            //}


        }
        private void AbrirComprobante(Talonario talonario, List<ListarDetalleFacturas> detalleFacturaslista)
        {


            if (Application.OpenForms["ComprobanteVenta"] == null)
            {
                ComprobanteVenta reciboVenta = new ComprobanteVenta(this, talonario, detalleFacturaslista);

                reciboVenta.Show();
            }
            else
            {
                Application.OpenForms["ComprobanteVenta"].Activate();
            }



        }
        private void ActualizarVentaPendiente()
        {
            //var ventapendiente = _solicitudesRepository.Get(_ventaacumuladaSelected.Id);
            if (_ventaacumuladaSelected != null)
            {
                foreach (var item in _ventaacumuladaSelected)
                {
                    if (_solicitudesRepository.Get(item.Id) != null)
                    {
                        var ventapendiente = _solicitudesRepository.Get(item.Id);
                        ventapendiente.Estado = true;
                        try
                        {
                            _solicitudesRepository.Update(ventapendiente);
                        }
                        catch (Exception ex)
                        {

                            KryptonMessageBox.Show(ex.Message);
                        }

                    }
                }
               
            }

            
           
        }
        private void comboxclientes_SelectedIndexChanged(object sender, EventArgs e)
        {

            cargarTxtCliente();
        }

        private void cargarTxtCliente()
        {
            if (comboxclientes.SelectedValue is Cliente) return;
            var clienteSeleccionado = int.Parse(comboxclientes.SelectedValue.ToString());
            var clienteOptenido = _clientesRepository.Get(clienteSeleccionado);
            if (clienteOptenido == null) return;
            txtdireccion.Text = clienteOptenido.Direccion;
            txtnit.Text = clienteOptenido.Nit;
            txtnombre.Text = clienteOptenido.Nombres;
            txtdireccion.Text = clienteOptenido.Direccion;
            idclientetosend = clienteOptenido.Id;


        }




        private void txtmonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }


        }
        private RESPONSE clientesx = null;
        private void btnbuscarnitSAT_Click(object sender, EventArgs e)
        {
            //if(ValidaClienteSat.GetClientbyNit(TokenObtenidoSat.Token, txtnitSat.Text.Trim()) == null){ return; }
            var clienteobtenidoSAT = ValidaClienteSat.GetClientbyNit(TokenObtenidoSat.Token, txtnitSat.Text.Trim());
            if (clienteobtenidoSAT == null) { return; }
            Root clienteSAT = JsonConvert.DeserializeObject<Root>(clienteobtenidoSAT);


            // clienteResponse = new List<RESPONSE>();
            foreach (var item in clienteSAT.RESPONSE)
            {
                txtnit.Text = item.NIT;
                txtnombre.Text = item.NOMBRE;
                var direcc = item.DEPARTAMENTO + ", " + item.MUNICIPIO + ", " + item.PAIS;
                txtdireccion.Text = direcc;

                clientesx = new RESPONSE
                {
                    NOMBRE = item.NOMBRE,
                    NIT = item.NIT,
                    DEPARTAMENTO = item.DEPARTAMENTO,
                    Direccion = item.Direccion,
                    MUNICIPIO = item.MUNICIPIO,
                    PAIS = item.PAIS,
                };

            }
            idclientetosend = 0;


        }

        private void generaFEL()
        {
            //var clienteformado = Getmodelcliente();
            //var listaDetallefactura = _facturasRepository.GetDetallebyFactura(guidFacturaid);
            //var xmlValidado = ValidarXML.enviarxml(TokenObtenidoSat.Token, clienteformado, listaDetallefactura);

            //DocCertificado = JsonConvert.DeserializeObject<DocumentoCertificadoSAT>(xmlValidado);
            //if (DocCertificado == null) { return; }
            //try
            //{
            //    DocCertificado.FacturaId = guidFacturaid;
            //    _certificadoSatRepository.add(DocCertificado);
            //}
            //catch (Exception ex)
            //{
            //    KryptonMessageBox.Show(ex.Message);
            //}


        }
        private RESPONSE Getmodelcliente()
        {
            return new RESPONSE
            {
                NOMBRE = txtnombre.Text,
                NIT = txtnit.Text,
                DEPARTAMENTO = "Guatemala",
                MUNICIPIO = "Guatemala",
                PAIS = "GT"
            };
        }

        private void AperturaReporteFEl()
        {
            //generaFEL();

            //if (DocCertificado != null)
            //{
            //    if (checkFEL.Checked == true)
            //    {
            //        if (Application.OpenForms["ReporteReciboCliente"] == null)
            //        {
            //            ReporteReciboCliente facturaFEL = new ReporteReciboCliente(this, guidFacturaid, DocCertificado);

            //            facturaFEL.Show();
            //        }
            //        else
            //        {
            //            Application.OpenForms["ReporteReciboCliente"].Activate();
            //        }
            //    }
            //}
            //else 
            //{
            //    KryptonMessageBox.Show("Ha ocurrio un error interno al generar FEL.");
            //}

        }

        private void comboxpagos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboxpagos.SelectedIndex == 4)
            {
                groupCredito.Visible = true;
                checkFEL.Visible = false;
            }
            else
            {
                groupCredito.Visible = false;
                txtnocuenta.Text = null;
                lbclienteS.Text = null;
                lbnocuenta.Text = null;
                groupCC.Visible = false;
                checkFEL.Visible = true;
            }
        }


        private CuentaCB cuentaObtenida = null;
        private Talonario noTalonario = null;
        private bool IsvalidTalonario = false;
        private void btnbuscarN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtnocuenta.Text) || string.IsNullOrEmpty(txtnotalonario.Text)) { KryptonMessageBox.Show("Ambos Campos Son necesarios"); return; }


            if (_cuentasCobrarRepository.GetCcbyNocuenta(txtnocuenta.Text) == null) { return; }

            cuentaObtenida = _cuentasCobrarRepository.GetCcbyNocuenta(txtnocuenta.Text);



            if (_cuentasCobrarRepository.GetTalonariosByCuentacb(cuentaObtenida.Id) == null) { KryptonMessageBox.Show("Cuenta no tiene talonarios creados valide los talonarios "); return; }
            var listaTalonarios = _cuentasCobrarRepository.GetTalonariosByCuentacb(cuentaObtenida.Id);
            noTalonario = listaTalonarios.FirstOrDefault(x => x.Correlativo == int.Parse(txtnotalonario.Text));
            if (noTalonario == null)
            {
                KryptonMessageBox.Show("Talonario no Encontrado! ");
                return;
            }
            if (noTalonario.Estado == true)
            {
                KryptonMessageBox.Show("Talonario ya cambiado, debe solicitar un nuevo talonario");
                IsvalidTalonario = false;
                return;
            }
            else
            {

                if (cuentaObtenida.IsActive == false)
                {
                    groupCC.Visible = true;
                    var clienteCuenta = _clientesRepository.Get(cuentaObtenida.ClienteId);
                    if (clienteCuenta == null) { return; }
                    lbnocuenta.Text = cuentaObtenida.NoCuenta;
                    lbclienteS.Text = clienteCuenta.Nombres + " " + clienteCuenta.Apellidos;
                    IsvalidTalonario = true;
                }
                else { KryptonMessageBox.Show("Cuenta Se encuentra inactiva, No se puede utilizar, debera cambiar el estado "); return; }
            }
        }


        private void AgregarItemstoCuenta(List<ListarDetalleFacturas> listaDetallef)
        {
            if (cuentaObtenida != null)
            {
                var listaProductosReserva = new List<ProductosReserva>();
                try
                {

                    cuentaObtenida.SaldoActual += decimal.Parse(ltotalapargar.Text);

                    foreach (var item in listaDetallef)
                    {
                        var reservaProductos = new ProductosReserva();
                        reservaProductos.Id = Guid.NewGuid();
                        if (item.ProductoId != 0)
                        { reservaProductos.ProductoId = item.ProductoId;
                        }
                        else
                        {
                            reservaProductos.ComboId = item.ComboId;
                        }
                        reservaProductos.Cantidad = item.Cantidad;
                        reservaProductos.Precio = item.Precio;
                        reservaProductos.Total = item.PrecioTotal;
                        reservaProductos.CuentaCBId = cuentaObtenida.Id;
                        if (item.DetalleColorId != 0 && item.DetalleTallaId == 0) { reservaProductos.DetalleColorId = item.DetalleColorId; }
                        if (item.DetalleTallaId != 0 && item.DetalleColorId == 0) { reservaProductos.DetalleTallaId = item.DetalleTallaId; }
                        if (item.TallayColorId != 0) { reservaProductos.DetalleColorTallaId = item.TallayColorId; }
                        listaProductosReserva.Add(reservaProductos);


                    }





                }
                catch (Exception e)
                {
                    KryptonMessageBox.Show(e.Message);
                }

                try
                {



                    if (listaProductosReserva.Count != 0)
                    {
                        _cuentasCobrarRepository.Update(cuentaObtenida);

                        foreach (var item in listaDetallef)
                        {
                            _formPadre.ValidarExistencias(item, true);

                        }

                        foreach (var item in listaProductosReserva)
                        {
                            _productosReservaRepository.Add(item);

                        }

                    }

                }
                catch (Exception e)
                {
                    KryptonMessageBox.Show(e.Message);
                }




            }





        }



        private void GuardarTransaccion()
        {
            var listamovimientos = _cuentasCobrarRepository.GetlistaMovimientos();
            var idmovimiento = listamovimientos.FirstOrDefault(x => x.tipoMovimiento == "Credito");
            var notapago = new NotaPago();
            notapago.Id = Guid.NewGuid();
            notapago.FechaTransaccion = DateTime.Now;
            notapago.NoDocumento = txtcorrelativo.Text;
            notapago.MovimientoId = idmovimiento.Id;
            notapago.UserId = UsuarioLogeadoPOS.User.Id;
            notapago.Monto = decimal.Parse(ltotalapargar.Text);
            notapago.CuentaCBId = cuentaObtenida.Id;
            _cuentasCobrarRepository.AddNotaPago(notapago);
        }

        private void btnNotaCredito_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["NotaCreditoFacturacion"] == null)
            {
                NotaCreditoFacturacion nCreditoFacturacion = new NotaCreditoFacturacion(this);

                nCreditoFacturacion.Show();
            }
            else
            {
                Application.OpenForms["NotaCreditoFacturacion"].Activate();
            }

        }

        private void btnlimpiarNcredito_Click(object sender, EventArgs e)
        {
            _notacredito = null;
            txtnotacredito.Text = null;
            lbncreditomonto.Text = null;
            //txtSaldoaFavor.Text = "0.00";
        }
        private void guardarNotaCredito()
        {
            if (_notacredito != null)
            {
                var notaCredito = updateNotacredito(_notacredito);
                _notaCreditoRepository.UpdateNotaCredito(notaCredito);
            }

        }

        private void txtSaldoaFavor_TextChanged(object sender, EventArgs e)
        {
            cargarSaldos();
        }

        private void txttotalingreso_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtefectivoMonto_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtefectivoMonto.Text))
            {

                operacionSuma();

            }
        }

        private void txtchequeMonto_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtchequeMonto.Text))
            {

                operacionSuma();

            }
        }

        private void txtcreditoMonto_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtcreditoMonto.Text))
            {

                operacionSuma();

            }
        }

        private void txtdebitoMonto_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtdebitoMonto.Text))
            {

                operacionSuma();

            }

        }

        private void txttrasnferMonto_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txttrasnferMonto.Text))
            {

                operacionSuma();

            }

        }
        private void operacionSuma()
        {

            decimal lbv14 = txtefectivoMonto.Text.Trim() == "" ? 0.00M : decimal.Parse(txtefectivoMonto.Text);
            decimal lbv15 = txtchequeMonto.Text.Trim() == "" ? 0.00M : decimal.Parse(txtchequeMonto.Text);
            decimal lbv16 = txtcreditoMonto.Text.Trim() == "" ? 0.00M : decimal.Parse(txtcreditoMonto.Text);
            decimal lbv17 = txtdebitoMonto.Text.Trim() == "" ? 0.00M : decimal.Parse(txtdebitoMonto.Text);
            decimal lbv18 = txttrasnferMonto.Text.Trim() == "" ? 0.00M : decimal.Parse(txttrasnferMonto.Text);
            var totalToshow = lbv14 + lbv15 + lbv16 + lbv17 + lbv18;
            txtmontoMonto.Text = totalToshow.ToString("0.0");
            var totalfact = decimal.Parse(ltotalapargar.Text);

            txtcambioMontos.Text = (totalToshow - totalfact).ToString();
       
            
        }

        private void txtefectivoMonto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtchequeMonto_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtchequeMonto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtcreditoMonto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txttrasnferMonto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtdebitoMonto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void checkMontosdiv_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMontosdiv.Checked == true)
            {
                grupmontos.Visible = true;
            }
            else
            {
                grupmontos.Visible = false;
            }
        }

        private void txtnitSat_KeyPress(object sender, KeyPressEventArgs e)
        {           
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            
        }

        private void txtnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
