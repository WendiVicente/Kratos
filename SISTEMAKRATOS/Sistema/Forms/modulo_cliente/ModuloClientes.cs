using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.ListasPersonalizadas.Creditos;
using CapaDatos.Models.CuentaCobrar;
using Sistema.Reports.Reporte_Creditos;
using CapaDatos.Repository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using POS;
using sharedDatabase.Models;
using Sistema.Forms.modulo_Ccobrar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sharedDatabase.Models.Caja;
using CapaDatos.WebServiceSAT;
using CapaDatos.Models.DocumentoSAT;
using WebApi;
using Newtonsoft.Json;
using Sistema.Reports.Reporte_Facturacion;

namespace Sistema.Forms.modulo_cliente
{
    public partial class ModuloClientes : BaseContext
    {
        private Cliente _clienteUpdate = null;
        private CuentasCobrarRepository _cuentasCRepository = null;
        private TiposClienteRepository _tiposRepository = null;
        private IList<ListarClientes> listaClientestodos;
        private ClientesRepository _clientesRepository = null;
        private IList<Cliente> _clientesSinCuentas = null;
        private CuentaCB _cuenta = null;
        private readonly ProductosRepository _productosRepository = null;
        private readonly CajasRepository _cajasRepository = null;
        private readonly VentasRepository _ventasRepository = null;
        private List<ProductosReserva> _listaReservaproductos = new List<ProductosReserva>();
        private ProductosReservaRepository _productosRRepository = null;
        private readonly FacturasRepository _facturasRepository = null;
        private TokenSAT TokenObtenidoSat;
        private DocumentoCertificadoSAT DocCertificado = null;
        private readonly CertificadoSatRepository _certificadoSatRepository = null;
        private IList<ListarCuentasCBs> cuentaCBslista => _cuentasCRepository.GetCuentaCBslista();
        private decimal? sumatotal => cuentaCBslista.Sum(a => a.SaldoActual);

        #region FORMULARIO
        public ModuloClientes()
        {
            _certificadoSatRepository = new CertificadoSatRepository(_context);
            _facturasRepository = new FacturasRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            _cuentasCRepository = new CuentasCobrarRepository(_context);
            _tiposRepository = new TiposClienteRepository(_context);
            _clientesRepository = new ClientesRepository(_context);
            listaClientestodos = new List<ListarClientes>();
            _cajasRepository = new CajasRepository(_context);
            _ventasRepository = new VentasRepository(_context);
            _productosRRepository = new ProductosReservaRepository(_context);
           
            InitializeComponent();
      
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            MenuPrincipal(this);
        }

        private void ModuloClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuPrincipal(this, false);
        }

        public void CargarCodigoCliente()
        {
            var cliente = _clientesRepository.GetLastCliente(UsuarioLogeadoSistemas.User.SucursalId);
            txtcodigocliente.Text = ObtenerNumero(cliente, "CL-");
        }

        private string ObtenerNumero(string Solic, string CL)
        {
            string numero = "";
            if (Solic == null)
            {
                numero = CL + "001";
            }
            else if(Solic.Length>0)
            {
               
                int maxsol = Convert.ToInt32(Solic.Split('-')[1]) + 1;
                if (maxsol < 10)
                    numero = CL + "00" + maxsol;
                else if (maxsol < 100)
                    numero = CL + "0" + maxsol;
                else
                    numero = CL + maxsol;
            }
            return numero;
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
        private void cargarcodigo()
        {
            string tipocl = "CC-";
            string cuentanueva;
            do
            {
                cuentanueva = GenerateRandom(tipocl);
            }

            while (ExisteNpago(cuentanueva));

            lbnumerocuenta.Text = cuentanueva;
        }
        private void ModuloClientes_Load(object sender, EventArgs e)
        {
            RefrescarDataGridClientes();
            CargarComboClientes();
            cargarclienteCombo2();
            CargarTipos();
            CargarDGVHistorial();
            CargarCodigoCliente();
            txtfecha.Text = DateTime.Now.ToString();
            txtfecha2.Text = DateTime.Now.ToString();
            cargarclienteCombo();
            cargarclienteComboporcobrar();
            cargarclienteComboCobrar();
            cargarMovimientoCombo();
            CargarPago();
        }
        private void cargartextClienteporcobrar()
        {
            if (Comboclientecobrar.SelectedValue is Cliente) return;
            var clienteSeleccionado = int.Parse(Comboclientecobrar.SelectedValue.ToString());
            _clienteUpdate = _clientesRepository.Get(clienteSeleccionado);
            if (_clienteUpdate == null) return;
            txtdpi1.Text = _clienteUpdate.DPI;
            txttelefono1.Text = _clienteUpdate.Telefonos;
            txtnit1.Text = _clienteUpdate.Nit;
            txtnombre1.Text = _clienteUpdate.Nombres;
            txtapellidos1.Text = _clienteUpdate.Apellidos;
            cargarCuentaCliente(_clienteUpdate.Id);

        }
        private void cargarclienteComboporcobrar()
        {
            _clientesSinCuentas = _clientesRepository.GetClientesbyCredi();
            combocliente2.DataSource = _clientesSinCuentas;
            combocliente2.ValueMember = "Id";
            combocliente2.DisplayMember = "Nombres";
            combocliente2.SelectedIndex = 0;
        }
        private void cargarclienteCombo2()
        {
            _clientesSinCuentas = _clientesRepository.GetClientesbyCredi();
            combocliente.DataSource = _clientesSinCuentas;
            combocliente.ValueMember = "Id";
            combocliente.DisplayMember = "Nombres";
           // combocliente.SelectedIndex = 0;
        }

        public void TraerCorrelativo()
        {
            if (_cuentasCRepository.GetTalonariosByCuentacb(_cuenta.Id) == null)
            {
                txtiniciocorrel.Text = "1";
            }
            else
            {
                var talonariosobtenidos = _cuentasCRepository.GetTalonariosByCuentacb(_cuenta.Id);
                var talonariosActuales = talonariosobtenidos.Count() + 1;
                txtiniciocorrel.Text = talonariosActuales.ToString();

            }

            // return talonariosActuales;
        }
        private void cargarCuentaCliente(int cliente)
        {
            _cuenta = _cuentasCRepository.GetCcbyCliente(cliente);
            if (_cuenta == null) { return; }
            lbnumerocuenta.Text = _cuenta.NoCuenta;
            TraerCorrelativo();
        }
       
        #endregion

        #region LISTADO
        private void TxtBuscador_TextChanged(object sender, EventArgs e)
        {
            var filtro = listaClientestodos.Where(a => a.Nombres.Contains(TxtBuscador.Text) ||
                                                 (a.Nombres != null && a.Nombres.Contains(TxtBuscador.Text)) ||
                                                 (a.Apellidos != null && a.Apellidos.Contains(TxtBuscador.Text)) ||
                                                 (a.CodigoCliente != null && a.CodigoCliente.Contains(TxtBuscador.Text)) ||
                                                 (a.Nit != null && a.Nit.Contains(TxtBuscador.Text)));
            DgvListClientes.DataSource = filtro.ToList();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            NuevoCliente.Visible = true;
            NavCliente.SelectedPage = NuevoCliente;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            NuevoCliente.Visible = true;
            NavCliente.SelectedPage = NuevoCliente;
        }            
                
        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            RefrescarDataGridClientes();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (DgvListClientes.CurrentRow == null)
            {
                return;
            }

            var dialog = KryptonMessageBox.Show("¿Está seguro que desea eliminar el Cliente ?", "Eliminar cliente",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);

            if (dialog == DialogResult.Yes)
            {
                var cliente = (CapaDatos.ListasPersonalizadas.ListarClientes)DgvListClientes.CurrentRow.DataBoundItem;
                var GetCliente = _clientesRepository.Get(cliente.Codigo);
                GetCliente.IsActive = true;
                _clientesRepository.Update(GetCliente);
                RefrescarDataGridClientes(true);
            }
        }
        public void CargarTipos()
        {
            cbtipoCliente.DataSource = _clientesRepository.GetTipos();
            cbtipoCliente.DisplayMember = "TipoCliente";
            cbtipoCliente.ValueMember = "Id";
            cbtipoCliente.Invalidate();
        }
        private void CbClientesTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = CbClientesTipos.ComboBox.SelectedValue.ToString();
            int opc = !int.TryParse(valor, out var b) ? 0 : Convert.ToInt32(valor);
            RefrescarDataGridClientes(false, opc);
        }

        private void BtnChangeStado_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DgvListClientes.Rows)
            {
                var Id = int.Parse(row.Cells[0].Value.ToString());
                var clienteObtenido = _clientesRepository.Get(Id);

                bool estadoActual = Convert.ToBoolean(row.Cells[11].Value);

                if (estadoActual != clienteObtenido.IsActive)
                {
                    clienteObtenido.IsActive = estadoActual;
                    _clientesRepository.Update(clienteObtenido);
                }
                else
                {
                    _clientesRepository.Update(clienteObtenido);
                }
            }
        }

        public void RefrescarDataGridClientes(bool loadNewContext = true, int filtro = 0)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _clientesRepository = null;
                _clientesRepository = new ClientesRepository(_context);
            }
            BindingSource source = new BindingSource();
            listaClientestodos = _clientesRepository.GetList(filtro);
            source.DataSource = listaClientestodos;
            DgvListClientes.DataSource = typeof(List<>);
            DgvListClientes.DataSource = source;
            DgvListClientes.ClearSelection();
        }

        private void CargarComboClientes()
        {
            var tiposClientes = _tiposRepository.GettiposCliente();
            tiposClientes.Add(new ListaDeTiposCliente { Id = 0, TipoCliente = "Todos", Estado = "Activa" });
            var c = tiposClientes.OrderBy(a => a.Id).ToList();
            CbClientesTipos.ComboBox.DataSource = c.Where(x => x.Estado == "Activa").ToList();
            CbClientesTipos.ComboBox.DisplayMember = "TipoCliente";
            CbClientesTipos.ComboBox.ValueMember = "Id";
            CbClientesTipos.ComboBox.SelectedIndex = 0;
            CbClientesTipos.ComboBox.Invalidate();
        }
        private void cargartextCliente2()
        {
            if (combocliente2.SelectedValue is Cliente) return;
            var clienteSeleccionado = int.Parse(combocliente2.SelectedValue.ToString());
            var clienteOptenido = _clientesRepository.Get(clienteSeleccionado);
            if (clienteOptenido == null) return;
            txtdpi2.Text = clienteOptenido.DPI;
            txttelefono2.Text = clienteOptenido.Telefonos;
            txtnit2.Text = clienteOptenido.Nit;
            txtnombres2.Text = clienteOptenido.Nombres;
            txtapellidos2.Text = clienteOptenido.Apellidos;
            cargarCuentaCliente(clienteOptenido.Id);

        }
        private void cargartextCliente()
        {
            if (combocliente.SelectedValue is Cliente) return;
            var clienteSeleccionado = int.Parse(combocliente.SelectedValue.ToString());
            var clienteOptenido = _clientesRepository.Get(clienteSeleccionado);
            if (clienteOptenido == null) return;
            txtdpi.Text = clienteOptenido.DPI;
            txttelefono.Text = clienteOptenido.Telefonos;
            txtnit.Text = clienteOptenido.Nit;
            txtnombres.Text = clienteOptenido.Nombres;
            txtapellidos.Text = clienteOptenido.Apellidos;
            _clienteUpdate = clienteOptenido;

        }
        #endregion
        private void cargarclienteCombo()
        {
            var listaclientes = _clientesRepository.GetClientes();
            _clientesSinCuentas = listaclientes.Where(x => x.PermitirCredito == false).ToList();
            combocliente.DataSource = _clientesSinCuentas;
            combocliente.ValueMember = "Id";
            combocliente.DisplayMember = "Nombres";
            //combocliente.SelectedIndex = 0;
        }
        private void cargarclienteComboCobrar()
        {
            _clientesSinCuentas = _clientesRepository.GetClientesbyCredi();
            Comboclientecobrar.DataSource = _clientesSinCuentas;
            Comboclientecobrar.ValueMember = "Id";
            Comboclientecobrar.DisplayMember = "Nombres";
            Comboclientecobrar.SelectedIndex = 0;
        }
        private void combocliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargartextCliente();
        }

        private void btnguardarnp_Click(object sender, EventArgs e)
        {

         
        }
        private CuentaCB cuentaCBnueva()
        {
            return new CuentaCB()
            {
                Id = Guid.NewGuid(),
                NoCuenta = lbnumerocuenta.Text,
                FechaCreacion = DateTime.Now,
                SaldoActual = 0,
                ClienteId = int.Parse(combocliente.SelectedValue.ToString()),
                SucursalId = 1,

            };
        }
        private void updateCliente(Cliente clienteSelected)
        {
            clienteSelected.PermitirCredito = true;
            _clientesRepository.Update(clienteSelected);
        }
        private void CbClientesTipos_Click(object sender, EventArgs e)
        {
            var modelocuentaCB = cuentaCBnueva();
            if (!ModelState.IsValid(modelocuentaCB)) { return; }
            _cuentasCRepository.Add(modelocuentaCB);
            updateCliente(_clienteUpdate);
            // Close();
          
        }
     
        private void txtcodigocliente_TextChanged(object sender, EventArgs e)
        {

        }
        public Factura GetViewModel2()
        {

            return new Factura()
            {
                Id = Guid.NewGuid(),
                Nombre = txtnombres.Text,
                Direccion = _clienteUpdate.Direccion,
                NIT = txtnit.Text,
                FechaVenta = DateTime.Now,
                ClienteId = _clienteUpdate.Id,
                NoFactura = txtnodocumento1.Text,
                Vendedor = UsuarioLogeadoSistemas.User.Name,
                TipoPago = combopagos.SelectedItem.ToString(),
                UserId = UsuarioLogeadoSistemas.User.Id,

            };
        }
        public Cliente GetViewModel()
        {
            return new Cliente()
            {
                Nombres = kryptonTextBox1.Text,
                CodigoCliente = txtcodigocliente.Text,
                Apellidos = kryptonTextBox2.Text,
                Telefonos = kryptonTextBox3.Text,
                Nit = kryptonTextBox4.Text,
                Direccion = kryptonTextBox5.Text,
                Alias = kryptonTextBox6.Text,
                TiposId = int.Parse(cbtipoCliente.SelectedValue.ToString()),
                FechaCreacion = DateTime.Now,
                PermitirCredito = checkcredito.Checked,
                DPI = txtdpi.Text,
                SucursalId = 1
            };
        }
        public string GenerateRandom(string tipo)
        {
            Random randomGenerate = new System.Random();
            string nocuenta = tipo;
            var cadena = System.Convert.ToString(randomGenerate.Next(00000001, 99999999));
            var resulto = String.Concat(nocuenta, cadena);
            return resulto;//Substring(resulto.Length - 11, 11);  
        }
        private bool ExisteCuenta(string cadena)
        {
            var cuenta = _cuentasCRepository.GetCcbyNocuenta(cadena);
            if (cuenta == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private CuentaCB cuentaNueva()
        {
            return new CuentaCB()
            {
                Id = Guid.NewGuid(),
                FechaCreacion = DateTime.Now,
                SaldoActual = 0,
                SucursalId = 1
            };
        }
        private void CrearCuentabyCobrar(int idcliente)
        {
            string tipocuenta = "CC-";
            string numerocuenta;
            do
            {
                numerocuenta = GenerateRandom(tipocuenta);
            }
            while (ExisteCuenta(numerocuenta));

            var cuentatosend = cuentaNueva();
            cuentatosend.NoCuenta = numerocuenta;
            cuentatosend.ClienteId = idcliente;
            _cuentasCRepository.Add(cuentatosend);

            KryptonMessageBox.Show("Registro Guardado Correctamente");
           
        }
        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            var model = GetViewModel();

            if (ModelState.IsValid(model))
            {
                try
                {
                    var idclienteactual = _clientesRepository.Add(model);
                    if (checkcredito.Checked == true)
                        CrearCuentabyCobrar(idclienteactual);
                    else
                        KryptonMessageBox.Show("Registro guardado correctamente!");
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK);
                }
            }
            else
            {
                KryptonMessageBox.Show("Hay campos obligatorios sin llenar", "ERROR", MessageBoxButtons.OK);
            }
        }

        private void kryptonHeader5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DgvListClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void CargarDGVHistorial()
        {
            /// var historial = _cuentasCRepository.Getlistadepagoscreditos(idCCB);
            /// 

            BindingSource source = new BindingSource();
            source.DataSource = cuentaCBslista;
            dgvcuentas.DataSource = typeof(List<>);
            dgvcuentas.DataSource = source;
            dgvcuentas.AutoResizeColumns();
            dgvcuentas.Columns[0].Visible = false;
            lbtotal.Text = sumatotal.ToString();

        }
        private void cargarImpresion(Guid idcuenta, int inicio, int fin)
        {
            if (Application.OpenForms["TalonariosReporte"] == null)
            {

                TalonariosReporte TalonariosReporte = new TalonariosReporte(idcuenta, inicio, fin);

                TalonariosReporte.Show();
            }
            else
            {
                Application.OpenForms["TalonariosReporte"].Activate();
            }
        }
        private void bntimprimir_Click(object sender, EventArgs e)
        {
            int inicio = int.Parse(txtiniciocorrel.Text);
            cargarImpresion(_cuenta.Id, 1, inicio);
        }
        public void CrearTalonarios()
        {
            var inicio = int.Parse(txtiniciocorrel.Text);
            var fin = int.Parse(txtfincorrel.Text);
            for (int i = inicio; i <= fin; i++)
            {
                var nuevotalonario = GetnuevoTalonario();
                nuevotalonario.Correlativo = i;
                _cuentasCRepository.AddTalonarios(nuevotalonario);
            }

        }
        public Talonario GetnuevoTalonario()
        {
            return new Talonario()
            {
                Id = Guid.NewGuid(),
                FechaCreacion = DateTime.Now,
                CuentaCBId = _cuenta.Id,
                FechaCambio = DateTime.Now,
            };
        }
       
        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtfincorrel.Text)) { return; }
            CrearTalonarios();

            if (checkpdf.Checked == true)
            {
                int inicio = int.Parse(txtiniciocorrel.Text);
                int fin = int.Parse(txtfincorrel.Text);
                cargarImpresion(_cuenta.Id, inicio, fin);
            }
            else
            {
                Close();
              
            }
        }

        private void toolClientes_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void combocliente2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargartextCliente2();
        }
        private NotaPago NuevaNotapago()
        {
            return new NotaPago()
            {
                Id = Guid.NewGuid(),
                NoDocumento = txtnodocumento1.Text,
                Descripcion = txtconcepto1.Text,
                Monto = decimal.Parse(lbtotal.Text),
                FechaTransaccion = DateTime.Now,
                UserId = UsuarioLogeadoSistemas.User.Id,
                CuentaCBId = _cuenta.Id,
                MovimientoId = int.Parse(combomovimiento.SelectedValue.ToString()),
            };

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
        public ListarDetalleFacturas GetDetalleFactura()
        {
            return new ListarDetalleFacturas()
            {


            };

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
                if (item.DetalleColorTallaId != null)
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
        private DetalleCaja getdetalleCaja()
        {
            return new DetalleCaja()
            {
                Descripcion = combopagos.SelectedItem.ToString()
            };
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
        private bool generaFEL(Guid idfactura)
        {
            var factura = _facturasRepository.Get(idfactura);
            var clienteformado = Getmodelcliente();
            var listaDetallefactura = ConvertirToDetalleFactura(_listarPReservas);
            System.Net.ServicePointManager.SecurityProtocol =
                    System.Net.SecurityProtocolType.Tls12;
            TokenObtenidoSat = JsonConvert.DeserializeObject<TokenSAT>(TokenPOST.GetToken());
            var xmlValidado = ValidarXML.enviarxml(TokenObtenidoSat.Token, clienteformado, listaDetallefactura,factura.NoFactura);
            if (xmlValidado == null) { KryptonMessageBox.Show("Error en datos enviados a FEl, verifique Nit"); return false; }
            try
            {
                DocCertificado = JsonConvert.DeserializeObject<DocumentoCertificadoSAT>(xmlValidado);
                if (DocCertificado == null) { KryptonMessageBox.Show("Error en datos enviados a FEl, verifique Nit"); return false; }

                DocCertificado.FacturaId = idfactura;
                _certificadoSatRepository.add(DocCertificado);
                return true;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
            return false;

        }
        private void AperturaReporteFEL(Guid guidFacturaid)
        {
            if (Application.OpenForms["ReporteFactura"] == null)
            {
                ReporteFactura facturaFEL = new ReporteFactura(this, guidFacturaid, DocCertificado);
                facturaFEL.Show();

            }
            else
            {
                Application.OpenForms["ReporteFactura"].Activate();
            }
        }
        private void cargarReporte(NotaPago notpago, CuentaCB cuenta)
        {
            ReporteNotapago notapago = new ReporteNotapago(notpago, cuenta);
            notapago.Show();
        }
        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            try
            {
                var totaltosend = decimal.Parse(lbtotal.Text);
                if (totaltosend == 0)
                {
                    KryptonMessageBox.Show("No hay ninguna producto a pagar");
                    return;
                }

                if (_cajasRepository.GetCajaAperturada(1) == null)
                {
                    KryptonMessageBox.Show("No hay ninguna caja aperturada en esta sucursal");
                    return;
                }
                var notapago = NuevaNotapago();
                var encabezadoFactura = GetViewModel2();

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



                var cajaObtenida = _cajasRepository.GetCajaAperturada(1);

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

        private void Comboclientecobrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargartextClienteporcobrar();
        }
        private void cargarMovimientoCombo()
        {
            var tipomovimiento = _cuentasCRepository.GetlistaMovimientos();
            var filtromovi = tipomovimiento.Where(x => x.tipoMovimiento == "Pago").ToList();
            combomovimiento.DataSource = filtromovi;
            combomovimiento.ValueMember = "Id";
            combomovimiento.DisplayMember = "tipoMovimiento";
        }
        private void CargarPago()
        {
            combopagos.Items.Insert(0, "Efectivo");
            combopagos.Items.Insert(1, "Cheque");
            combopagos.Items.Insert(2, "Tarjeta de Crédito");
            combopagos.Items.Insert(3, "Tarjeta de Débito");
            combopagos.SelectedIndex = 0;

        }
    }
}
