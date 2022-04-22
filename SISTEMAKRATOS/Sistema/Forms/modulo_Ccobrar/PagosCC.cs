using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.CuentaCobrar;
using CapaDatos.WebServiceSAT;
using CapaDatos.Repository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models;
using Sistema.Reports.Reporte_Creditos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApi;
using sharedDatabase.Models.Caja;
using Newtonsoft.Json;
using CapaDatos.Models.DocumentoSAT;
using Sistema.Reports.Reporte_Facturacion;

namespace Sistema.Forms.modulo_Ccobrar
{
    public partial class PagosCC : BaseContext
    {
        private ClientesRepository _clientesRepository = null;
        private CuentasCobrarRepository _cuentasCRepository = null;
        private ProductosReservaRepository _productosRRepository = null;
        private readonly CertificadoSatRepository _certificadoSatRepository = null;
        private readonly VentasRepository _ventasRepository = null;
        private readonly ProductosRepository _productosRepository = null;
        private readonly CajasRepository _cajasRepository = null;
        private List<ProductosReserva> _listaReservaproductos = new List<ProductosReserva>();
        private readonly FacturasRepository _facturasRepository = null;
        private int sucursalId = UsuarioLogeadoSistemas.User.SucursalId;
        private TokenSAT TokenObtenidoSat;
        private DocumentoCertificadoSAT DocCertificado = null;
        private IList<Cliente> _clientesWithCuentas = null;
        private CuentaCB _cuenta = null;
        private Cliente clienteOptenido = null;
        public PagosCC()
        {
            
            _cajasRepository = new CajasRepository(_context);
            _cuentasCRepository = new CuentasCobrarRepository(_context);
            _productosRRepository = new ProductosReservaRepository(_context);
            _facturasRepository = new FacturasRepository(_context);
            _certificadoSatRepository = new CertificadoSatRepository(_context);
            _ventasRepository = new VentasRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            InitializeComponent();
        }

        private void Pagos_Load(object sender, EventArgs e)
        {

            cargarclienteCombo();
            cargarMovimientoCombo();
            CargarPago();
            txtfecha.Text = DateTime.Now.ToString();
            cargarcodigo();
        }
        private void CargarPago()
        {
            combopagos.Items.Insert(0, "Efectivo");
            combopagos.Items.Insert(1, "Cheque");
            combopagos.Items.Insert(2, "Tarjeta de Crédito");
            combopagos.Items.Insert(3, "Tarjeta de Débito");
            combopagos.SelectedIndex = 0;

        }
        private void cargarclienteCombo()
        {
            _clientesWithCuentas = _clientesRepository.GetClientesbyCredi();
            combocliente.DataSource = _clientesWithCuentas;
            combocliente.ValueMember = "Id";
            combocliente.DisplayMember = "Nombres";
            combocliente.SelectedIndex = 0;
        }
        private void cargarMovimientoCombo()
        {
            var tipomovimiento = _cuentasCRepository.GetlistaMovimientos();
            var filtromovi = tipomovimiento.Where(x => x.tipoMovimiento == "Pago").ToList();
            combomovimiento.DataSource = filtromovi;
            combomovimiento.ValueMember = "Id";
            combomovimiento.DisplayMember = "tipoMovimiento";
        }
        private void cargartextCliente()
        {
            if (combocliente.SelectedValue is Cliente) return;
            var clienteSeleccionado = int.Parse(combocliente.SelectedValue.ToString());
             clienteOptenido = _clientesRepository.Get(clienteSeleccionado);
            if (clienteOptenido == null) return;
            txtdpi.Text = clienteOptenido.DPI;
            txttelefono.Text = clienteOptenido.Telefonos;
            txtnit.Text = clienteOptenido.Nit;
            txtnombres.Text = clienteOptenido.Nombres;
            txtapellidos.Text = clienteOptenido.Apellidos;
            cargarCuentaCliente(clienteOptenido.Id);
           
        }

        private void cargarCuentaCliente(int cliente)
        {
            _cuenta = _cuentasCRepository.GetCcbyCliente(cliente);
            if (_cuenta == null) { return; }
            lbnumerocuenta.Text = _cuenta.NoCuenta;
            lbsaldoActual.Text = _cuenta.SaldoActual.ToString();
            CargarDGVHistorial(_cuenta.Id);
            cargarDGVReseva();
        }
        private void CargarDGVHistorial(Guid idCCB)
        {
            var historial = _cuentasCRepository.Getlistadepagoscreditos(idCCB);
            BindingSource source = new BindingSource();
            source.DataSource = historial;
            dgvNocredi.DataSource = typeof(List<>);
            dgvNocredi.DataSource = source;
            dgvNocredi.AutoResizeColumns();
            dgvNocredi.Columns[0].Visible = false;


        }

        public Factura GetViewModel()
        {

            return new Factura()
            {
                Id = Guid.NewGuid(),
                Nombre = txtnombres.Text,
                Direccion = clienteOptenido.Direccion,
                NIT = txtnit.Text,
                FechaVenta = DateTime.Now,
                ClienteId = clienteOptenido.Id,
                NoFactura = txtnodocumento.Text,
                Vendedor = UsuarioLogeadoSistemas.User.Name,
                TipoPago = combopagos.SelectedItem.ToString(),
                UserId = UsuarioLogeadoSistemas.User.Id,

            };
        }
        private DetalleCaja getdetalleCaja()
        {
            return new DetalleCaja()
            {
                Descripcion = combopagos.SelectedItem.ToString()
            };
        }


        private NotaPago NuevaNotapago()
        {
            return new NotaPago()
            {
                Id = Guid.NewGuid(),
                NoDocumento = txtnodocumento.Text,
                Descripcion = txtconcepto.Text,
                Monto = decimal.Parse(lbtotal.Text),
                FechaTransaccion = DateTime.Now,
                UserId = UsuarioLogeadoSistemas.User.Id,
                CuentaCBId = _cuenta.Id,
                MovimientoId = int.Parse(combomovimiento.SelectedValue.ToString()),
            };

        }


        private void combocliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargartextCliente();
        }

        private void txtdpibuscar_TextChanged(object sender, EventArgs e)
        {
            var filtro = _clientesWithCuentas.Where(a => a.DPI.Contains(txtdpibuscar.Text) ||
         (a.DPI != null && a.DPI.Contains(txtdpibuscar.Text)) 
          
          );
           var objetocliente= filtro.FirstOrDefault();
            txtnombres.Text = objetocliente.Nombres;
            txtapellidos.Text = objetocliente.Apellidos;

        }

        public string GenerateRandom(string tipo)
        {
            Random randomGenerate = new System.Random();
            string nocuenta = tipo;
            var cadena = System.Convert.ToString(randomGenerate.Next(00000001, 99999999));
            var resulto = String.Concat(nocuenta, cadena);
            return resulto;


        }
        private void cargarcodigo()
        {
            string tipocl = "NP-";
            string notabypago;
            do
            {
                notabypago = GenerateRandom(tipocl);
            }

            while (ExisteNpago(notabypago));

            txtnodocumento.Text = notabypago;
        }
        private bool ExisteNpago(string cadena)
        {
            var notapago = _cuentasCRepository.GetNotapago(cadena);
            if (notapago == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txtpago_TextChanged(object sender, EventArgs e)
        {
          
            
        }

        private void txtpago_KeyPress(object sender, KeyPressEventArgs e)
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

        

        private void btnguardarnp_Click(object sender, EventArgs e)
        {
            try
            {
                var totaltosend = decimal.Parse(lbtotal.Text);
                if (totaltosend == 0)
                {
                    KryptonMessageBox.Show("No hay ninguna producto a pagar");
                    return;
                }
               
                if (_cajasRepository.GetCajaAperturada(sucursalId) == null)
                {
                    KryptonMessageBox.Show("No hay ninguna caja aperturada en esta sucursal");
                    return;
                }
                var notapago = NuevaNotapago();
                var encabezadoFactura = GetViewModel();

                if (!ModelState.IsValid(encabezadoFactura)) { return; }
                if (!ModelState.IsValid(notapago)) { return; }

                var guidfactura = encabezadoFactura.Id;
                _cuentasCRepository.AddNotaPago(notapago);
                _cuenta.SaldoActual -= notapago.Monto;
                _cuentasCRepository.Update(_cuenta);
                _ventasRepository.Add(encabezadoFactura);
                CargarlistaReserva(dgvproductosReserva, 15);
                var detalleFactura = ConvertirToDetalleFactura(_listarPReservas);
                ActualizarProductosReserva();
                
               
               
                var cajaObtenida = _cajasRepository.GetCajaAperturada(sucursalId);

                var detalleCaja = getdetalleCaja(); //obtener caja detalle
                if (!ModelState.IsValid(detalleCaja)) { return; }

                detalleCaja.CajaId = cajaObtenida.Id;
                detalleCaja.FacturaId = guidfactura;
                if (combopagos.SelectedIndex == 0) { detalleCaja.Efectivo = decimal.Parse(lbtotal.Text); }
                if (combopagos.SelectedIndex == 1) { detalleCaja.Cheques = decimal.Parse(lbtotal.Text); }
                if (combopagos.SelectedIndex == 2) { detalleCaja.TarjetaCredito = decimal.Parse(lbtotal.Text); }
                if (combopagos.SelectedIndex == 3) { detalleCaja.TarjetaDebito = decimal.Parse(lbtotal.Text); }
                _cajasRepository.AddDetalleCaja(detalleCaja);

                foreach (var item in detalleFactura)
                {

                    var producto = _productosRepository.Get(item.ProductoId);
                    var detalle = NuevoDetalleFactura(producto, item, guidfactura);
                    _facturasRepository.Add(detalle, true);


                }

                KryptonMessageBox.Show("Registro guardado correctamente!");

                if (checkFactura.Checked)
                {
                    if (generaFEL(guidfactura))
                    {
                        AperturaReporteFEL(guidfactura);
                    }
                    else
                    {
                        KryptonMessageBox.Show("Error en Creacion de FEL, ser creara Recibo!");
                        cargarReporte(notapago, _cuenta);
                    }
                   
                }
                else
                {
                    cargarReporte(notapago, _cuenta);
                }
                Close();


            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
                
            }

           






            


        }

        private void AperturaReporteFEL(Guid guidFacturaid)
        {
            //if (Application.OpenForms["ReporteFactura"] == null)
            //{
            //    ReporteFactura facturaFEL = new ReporteFactura(this, guidFacturaid, DocCertificado);
            //    facturaFEL.Show();

            //}
            //else
            //{
            //    Application.OpenForms["ReporteFactura"].Activate();
            //}
        }

        private void cargarReporte(NotaPago notpago, CuentaCB cuenta)
        {
            ReporteNotapago notapago = new ReporteNotapago(notpago, cuenta);
            notapago.Show();
        }

        private DetalleFactura NuevoDetalleFactura(Producto producto, ListarDetalleFacturas item, Guid idfact)
        {
            var detalle = new DetalleFactura()
            {
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



        private void cargarDGVReseva()
        {

             var listaReservaproductos = _productosRRepository.GetListaPReservas(_cuenta.Id,false);
            BindingSource source = new BindingSource();
            source.DataSource = listaReservaproductos;
            dgvproductosReserva.DataSource = typeof(List<>);
            dgvproductosReserva.DataSource = source;
            dgvproductosReserva.AutoResizeColumns();
            dgvproductosReserva.Columns[0].Visible = false;
            dgvproductosReserva.Columns[7].Visible = false;
            dgvproductosReserva.Columns[8].Visible = false;
            dgvproductosReserva.Columns[9].Visible = false;
            dgvproductosReserva.Columns[10].Visible = false;
            dgvproductosReserva.Columns[11].Visible = false;
            dgvproductosReserva.Columns[12].Visible = false;
            dgvproductosReserva.Columns[13].Visible = false;


        }

        private void dgvproductosReserva_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int acciones = 15;
            SeleccionarFila(dgvproductosReserva, acciones);
            sumarFilas(dgvproductosReserva, acciones);
        }

        private void SeleccionarFila(DataGridView datagrid, int acciones)
        {
            bool estadoActual = Convert.ToBoolean(datagrid.CurrentRow.Cells[acciones].Value);
            if (estadoActual)
            {
                datagrid.CurrentRow.Cells[acciones].Value = false;
            }
            else
            {
                datagrid.CurrentRow.Cells[acciones].Value = true;

            }

        }

        private void sumarFilas(DataGridView data,int colacciones)
        {
            if (data.RowCount <= 0) { return; }
            int filasSeleccion = 0;
            decimal total = 0;
            foreach (DataGridViewRow Rows in data.Rows)
            {
                var filasTotales = int.Parse(data.RowCount.ToString());


                bool acciones = Convert.ToBoolean(Rows.Cells[colacciones].Value);
                if (!acciones)
                {
                    filasSeleccion += 1;
                }
                else
                {
                   // var filaactual = (ListarPReserva)data.CurrentRow.DataBoundItem;
                    total += decimal.Parse(Rows.Cells[6].Value.ToString());
                    lbtotal.Text = total.ToString();
                  //  _listaReservaproductos.Add(filaactual);

                }

            }
        }

        private List<ListarPReserva> _listarPReservas = new List<ListarPReserva>();
        private void CargarlistaReserva(DataGridView data, int colacciones)
        {
            if (data.RowCount <= 0) { return; }
            int filasSeleccion = 0;
            int contadorfila = 0;
            foreach (DataGridViewRow Rows in data.Rows)
            {
                var filasTotales = int.Parse(data.RowCount.ToString());


                bool acciones = Convert.ToBoolean(Rows.Cells[colacciones].Value);
                if (!acciones)
                {
                    filasSeleccion += 1;
                }
                else
               
                {
                    // var filaactual =Guid.Parse(Rows.Cells[0].Value.ToString());
                    var filaactual = (ListarPReserva)dgvproductosReserva.Rows[contadorfila].DataBoundItem;
                    var reserva = _productosRRepository.Get(filaactual.Id);
                    _listaReservaproductos.Add(reserva);
                    _listarPReservas.Add(filaactual);
                }
                contadorfila++;
            }
        }
        private List<ListarDetalleFacturas> ConvertirToDetalleFactura(List<ListarPReserva> listaproductos)
        {
            var lista = new List<ListarDetalleFacturas>();
            foreach (var item in listaproductos)
            {
                if (listaproductos == null) { continue; }
                var detalleFactura = GetDetalleFactura();
                if (item.DetalleColorId != null)
                {
                    detalleFactura.DetalleColorId = (int)item.DetalleColorId;
                }
                if (item.DetalleTallaId != null)
                {
                    detalleFactura.DetalleTallaId = (int)item.DetalleTallaId;
                }
                if (item.DetalleColorTallaId!= null)
                {
                    detalleFactura.TallayColorId = (int)item.DetalleColorTallaId;
                }
                if (item.ComboId != null)
                {
                    detalleFactura.ComboId = (Guid)item.ComboId;
                }
                if (item.ProductoId != null)
                {
                    detalleFactura.ProductoId = (int)item.ProductoId;

                }
                
                detalleFactura.Descripcion = item.Descripcion;
                detalleFactura.Cantidad = item.Cantidad;
                detalleFactura.Precio = item.Precio;
                detalleFactura.Descuento = 0;
                detalleFactura.PrecioTotal = item.Total;
                detalleFactura.SubTotal = detalleFactura.PrecioTotal;
               
                lista.Add(detalleFactura);
            }
            return lista;
        }

        public ListarDetalleFacturas GetDetalleFactura()
        {
            return new ListarDetalleFacturas()
            {


            };

        }

        private void lbtotal_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lbtotal.Text) || lbtotal.Text == "." || lbtotal.Text == "0") { return; }
            if (lbtotal.Text == "0") { txtnuevosaldo.Text = ""; }
            var saldoActual = decimal.Parse(lbsaldoActual.Text);
            var montoingresado = decimal.Parse(lbtotal.Text);
            txtnuevosaldo.Text = (saldoActual - montoingresado).ToString();
        }



        private void ActualizarProductosReserva()
        {
            foreach (var item in _listaReservaproductos)
            {
                if (_productosRRepository.Get(item.Id) == null)
                {
                    continue;
                }
                var obtenido = _productosRRepository.Get(item.Id);

                obtenido.IsActive = true;
                _productosRRepository.Update(obtenido);
            }

        }

        private bool generaFEL(Guid idfactura)
        {
          //  var clienteformado = Getmodelcliente();
          //  var listaDetallefactura = ConvertirToDetalleFactura(_listarPReservas);
          //  System.Net.ServicePointManager.SecurityProtocol =
          //          System.Net.SecurityProtocolType.Tls12;
          ////  TokenObtenidoSat = JsonConvert.DeserializeObject<TokenSAT>(TokenPOST.GetToken());
          //  var xmlValidado = ValidarXML.enviarxml(TokenObtenidoSat.Token, clienteformado, listaDetallefactura);
          //  if (xmlValidado == null) { KryptonMessageBox.Show("Error en datos enviados a FEl, verifique Nit");return false; }
          //  try
          //  {
          //      DocCertificado = JsonConvert.DeserializeObject<DocumentoCertificadoSAT>(xmlValidado);
          //      if (DocCertificado == null) {KryptonMessageBox.Show("Error en datos enviados a FEl, verifique Nit");return false;  }

          //      DocCertificado.FacturaId = idfactura;
          //      _certificadoSatRepository.add(DocCertificado);
          //      return true;
          //  }
          //  catch (Exception ex)
          //  {
          //      KryptonMessageBox.Show(ex.Message);
          //  }
            return false;

        }
        private RESPONSE Getmodelcliente()
        {
            return new RESPONSE
            {
                NOMBRE = txtnombres.Text,
                NIT = txtnit.Text,
                DEPARTAMENTO = "Guatemala",
                MUNICIPIO = "Guatemala",
                PAIS = "GT"
            };
        }


    }
}
