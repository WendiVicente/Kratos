using CapaDatos.Models.Usuarios;
using ComponentFactory.Krypton.Toolkit;
using POS.Forms;
using Sistema.Forms.modulo_Bancos;
using Sistema.Forms.modulo_Caja;
using Sistema.Forms.modulo_Ccobrar;
using Sistema.Forms.modulo_cliente;
using Sistema.Forms.modulo_combos;
using Sistema.Forms.modulo_compras;
using Sistema.Forms.modulo_cotizacion;
using Sistema.Forms.modulo_debitos;
using Sistema.Forms.modulo_devoluciones;
using Sistema.Forms.modulo_facturacion;
using Sistema.Forms.modulo_Pedidos;
using Sistema.Forms.modulo_personal;
using Sistema.Forms.modulo_Prestamos;
using Sistema.Forms.modulo_producto;
using Sistema.Forms.modulo_promos;
using Sistema.Forms.modulo_proveedor;
using Sistema.Forms.modulo_recepcion;
using Sistema.Forms.modulo_RRHH;
using Sistema.Forms.modulo_Sucursales;
using Sistema.Forms.modulo_usurios;
using Sistema.Forms.modulo_vales;
using Sistema.Forms.modulo_ventas;
using Sistema.Reports.Reporte_RRHH;
using Sistema.Reports.Reports_Bancos;
using Sistema.Reports.Reports_Caja;
using Sistema.Reports.Reports_Clientes;
using Sistema.Reports.Reports_Combos;
using Sistema.Reports.Reports_Compras;
using Sistema.Reports.Reports_Productos;
using Sistema.Reports.Reports_Ventas;
using System;
using System.Windows.Forms;

namespace Sistema
{
    public partial class Layout : BaseContext
    {
        private int childFormNumber = 0;
        public Layout(User user)
        {
            UsuarioLogeadoSistemas.User = user;
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void Layout_Load(object sender, EventArgs e)
        {
            KryptonManager kryptonManager = new KryptonManager
            {
                GlobalPaletteMode = PaletteModeManager.SparkleOrange
            };

            if(UsuarioLogeadoSistemas.User == null) { 
                KryptonMessageBox.Show("Login incorrecto, No puede acceder.");
                Close();
                return;
            }


            toolStripLabel1.Text = UsuarioLogeadoSistemas.User.Name;
            toolStripLabel4.Text = UsuarioLogeadoSistemas.User.Sucursal.NombreSucursal;
            //clientesToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;

        }

        private void verClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.modulo_cliente.ListarClientesDgv childForm = new Forms.modulo_cliente.ListarClientesDgv();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void printPreviewToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoCliente childForm = new NuevoCliente();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //NuevoProducto childForm = new NuevoProducto(this);
            //childForm.MdiParent = this;
            //childForm.Show();
        }

        private void verProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if (Application.OpenForms["ModuloProducto"] == null)
            {
                ModuloProducto modulo = new ModuloProducto();
                modulo.Show();
            }

            else { Application.OpenForms["ModuloProducto"].Activate(); }            
        }

        private void nuevaSucursalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevaSucursal childForm = new NuevaSucursal();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void verSucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaSucursales childForm = new ListaSucursales();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void nuevoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoUsuario childForm = new NuevoUsuario();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void verUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["VerUsuarios"] == null)
            {


                VerUsuarios VerUsuariosss = new VerUsuarios();
                VerUsuariosss.MdiParent = this;
                VerUsuariosss.Show();
            }

            else { Application.OpenForms["VerUsuarios"].Activate(); }

        }

        private void ventasHoyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentasHoy childForm = new VentasHoy();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void todasLasVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentasGenerales childForm = new VentasGenerales();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void nuevaCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SolicitudCompra childForm = new SolicitudCompra();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void verComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerCompras verCompras = new VerCompras();
            verCompras.MdiParent = this;
            verCompras.Show();
        }

        private void listarSolicitudesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerRecepciones recepciones = new VerRecepciones();
            recepciones.MdiParent = this;
            recepciones.Show();
        }

        private void nuevaRecepcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecepcionCompra recepcionCompra = new RecepcionCompra();
            recepcionCompra.MdiParent = this;
            recepcionCompra.Show();
        }

        private void aperturarCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void verCajasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerCajas caja = new VerCajas();
            caja.MdiParent = this;
            caja.Show();
        }

        private void cajaActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CajaInicio caja = new CajaInicio();
            //caja.MdiParent = this;
            //caja.Show();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cajasAperturadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteCajaAbierta cajaactual = new ReporteCajaAbierta();
            cajaactual.Show();
        }

        private void nuevoComboToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            //este if sirve para abrir un nuevo formulario
            //valida si el formulario que se va a abrir es nulo, si lo es entonces lo crea
            //Aplication 
            if (Application.OpenForms["NuevoCombo"] == null)
            {             
               
                //NuevoCombo nuevocombo = new NuevoCombo(this);
                //nuevocombo.MdiParent = this;
                //nuevocombo.Show();
            }
            //sino lo activa
            else { Application.OpenForms["NuevoCombo"].Activate(); }


        }

        private void verCombosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //VerCombos combos = new VerCombos();
            //combos.Show();

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //este if sirve para abrir un nuevo formulario
            //valida si el formulario que se va a abrir es nulo, si lo es entonces lo crea
            //Aplication 
            if (Application.OpenForms["NuevoCombo"] == null)
            {

                //NuevoCombo nuevocombo = new NuevoCombo(this);
                //nuevocombo.MdiParent = this;
                //nuevocombo.Show();
            }
            //sino lo activa
            else { Application.OpenForms["NuevoCombo"].Activate(); }

        }

        private void buscarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListarClientesDgv busqueda = new ListarClientesDgv();
            busqueda.MdiParent = this;
            busqueda.Show();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

       

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracionCliente configuracionCliente = new ConfiguracionCliente();
            configuracionCliente.MdiParent = this;
            configuracionCliente.Show();

        }

        private void buscarComboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //VerCombos combos = new VerCombos();
            //combos.MdiParent = this;
            //combos.Show();
        }

        private void reporteGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteGeneralClientes reporteclientes = new ReporteGeneralClientes();
            reporteclientes.MdiParent = this;
            reporteclientes.Show();
        }

        private void reportePorClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (Application.OpenForms["ListarClientesDgv"] == null)
            {
                ListarClientesDgv busqueda = new ListarClientesDgv();
                busqueda.MdiParent = this;
                busqueda.Show();
            }

            else { Application.OpenForms["ListarClientesDgv"].Activate(); }


        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            if (Application.OpenForms["ReporteProductosGeneral"] == null)
            {
                ReporteProductosGeneral reporteProducto = new ReporteProductosGeneral();
                reporteProducto.MdiParent = this;
                reporteProducto.Show();
            }

            else { Application.OpenForms["ReporteProductosGeneral"].Activate(); }


        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["CategoriaProducto"] == null)
            {
                CategoriaProducto nuevacate = new CategoriaProducto();
                       nuevacate.Show();
            }

            else { Application.OpenForms["CategoriaProducto"].Activate(); }
        }

        private void nuevoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
          

            if (Application.OpenForms["NuevoProveedor"] == null)
            {


                NuevoProveedor proveedor = new NuevoProveedor();
                proveedor.MdiParent = this;
                proveedor.Show();


            }

            else { Application.OpenForms["NuevoProveedor"].Activate(); }



        }

        private void listarProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["VerProveedores"] == null)
            {


                VerProveedores proveedor = new VerProveedores();
                proveedor.MdiParent = this;
                proveedor.Show();



            }

            else { Application.OpenForms["VerProveedores"].Activate(); }




        }

        private void combosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteCombos combos = new ReporteCombos();
            combos.MdiParent = this;
            combos.Show();
        }

        private void personaSalariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevoPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["NuevaPersona"] == null)
            {


                NuevaPersona persona = new NuevaPersona();
                persona.MdiParent = this;
                persona.MaximizeBox = true;
                persona.Show();



            }

            else { Application.OpenForms["NuevaPersona"].Activate(); }

        }

        private void verPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["VerPersonal"] == null)
            {
                VerPersonal verPersonal = new VerPersonal();
                verPersonal.MdiParent = this;
                verPersonal.Show();
                  
            }
            else
            {
                Application.OpenForms["VerPersonal"].Activate();
            }
        }
        private void configuraciónToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["ConfiguracionProveedor"] == null)
            {

                ConfiguracionProveedor configuracion = new ConfiguracionProveedor();
                 configuracion.MdiParent = this;
                configuracion.Show();
            }

            else { Application.OpenForms["ConfiguracionProveedor"].Activate(); }

        }

        private void configuraciónToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ConfiguracionPersonal"] == null)
            {

                ConfiguracionPersonal configuracion = new ConfiguracionPersonal();
                configuracion.MdiParent = this;
                configuracion.Show();
            }

            else { Application.OpenForms["ConfiguracionPersonal"].Activate(); }
        }

        private void cotizaciónPromocionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["NuevaPromo"] == null)
            {

                NuevaSolicitud configuracion = new NuevaSolicitud();
                configuracion.MdiParent = this;
                configuracion.Show();
            }

            else { Application.OpenForms["NuevaPromo"].Activate(); }

        }

        private void controlHorarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["RecursosHumanos"] == null)
            {
                RecursosHumanos recursos = new RecursosHumanos();
                recursos.MdiParent = this;
                recursos.MaximizeBox = true;
                recursos.Show();
            }

            else { Application.OpenForms["RecursosHumanos"].Activate(); }

        }

        private void horarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void llegadasTardeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ReporteLlegadasTarde"] == null)
            {
                ReporteLlegadasTarde recursos = new ReporteLlegadasTarde();
                recursos.MdiParent = this;
                recursos.MaximizeBox = true;
                recursos.Show();
            }

            else { Application.OpenForms["ReporteLlegadasTarde"].Activate(); }
        }

        private void horasExtraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ReporteHorasExtra"] == null)
            {
                ReporteHorasExtra recursos = new ReporteHorasExtra();
                recursos.MdiParent = this;
                recursos.MaximizeBox = true;
                recursos.Show();
            }

            else { Application.OpenForms["ReporteHorasExtra"].Activate(); }

        }

        private void ausenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ReporteAusencias"] == null)
            {
                ReporteAusencias recursos = new ReporteAusencias();
                recursos.MdiParent = this;
                recursos.MaximizeBox = true;
                recursos.Show();
            }

            else { Application.OpenForms["ReporteAusencias"].Activate(); }

        }

        private void nuevaPromociónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Promos"] == null)
            {
                Promos recursos = new Promos();
                recursos.MdiParent = this;
                recursos.MaximizeBox = true;
                recursos.Show();
            }

            else { Application.OpenForms["Promos"].Activate(); }
        }

        private void nuevaCuentaDeBancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["NuevaCuentaBanco"] == null)
            {
                NuevaCuentaBanco NuevaCuenta = new NuevaCuentaBanco();
                NuevaCuenta.MdiParent = this;
                NuevaCuenta.MaximizeBox = true;
                NuevaCuenta.Show();
            }

            else { Application.OpenForms["NuevaCuentaBanco"].Activate(); }

        }

        private void verCuentasDeBancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["VerCuentas"] == null)
            {
                VerCuentas NuevaCuenta = new VerCuentas();
                NuevaCuenta.MdiParent = this;
                NuevaCuenta.MaximizeBox = true;
                NuevaCuenta.Show();
            }

            else { Application.OpenForms["VerCuentas"].Activate(); }
        }

        private void verTransaccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["VerTransacciones"] == null)
            {
                //VerTransacciones NuevaCuenta = new VerTransacciones();
                //NuevaCuenta.MdiParent = this;
                //NuevaCuenta.MaximizeBox = true;
                //NuevaCuenta.Show();
            }

            else { Application.OpenForms["VerTransacciones"].Activate(); }

        }

        private void listaDeRechazosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Rechazadas"] == null)
            {
                Rechazadas rechazos = new Rechazadas();
                rechazos.MdiParent = this;
                rechazos.MaximizeBox = true;
                rechazos.Show();
            }
            else
            {
                Application.OpenForms["Rechazadas"].Activate();
            }
        }

        private void realizarEgresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["IngresosEgresos"] == null)
            {
                IngresosEgresos IngresosE = new IngresosEgresos();
                IngresosE.MdiParent = this;
                IngresosE.MaximizeBox = true;
                IngresosE.Show();
            }
            else
            {
                Application.OpenForms["IngresosEgresos"].Activate();
            }

        }

        private void reportesToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ReporteTransaccion"] == null)
            {
                ReporteTransaccion IngresosE = new ReporteTransaccion();
                IngresosE.MdiParent = this;
                IngresosE.MaximizeBox = true;
                IngresosE.Show();
            }
            else
            {
                Application.OpenForms["ReporteTransaccion"].Activate();
            }

        }

        private void nuevoValeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ValeInicio"] == null)
            {
                ValeInicio vale = new ValeInicio();
                vale.MdiParent = this;
                vale.Show();
            }
            else
            {
                Application.OpenForms["ValeInicio"].Activate();
            }
        }

        private void listarValesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["VerVales"] == null)
            {
                VerVales vale = new VerVales();
                vale.MdiParent = this;
                vale.Show();
            }
            else
            {
                Application.OpenForms["VerVales"].Activate();
            }

        }

        private void nuevaCotizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["NuevaCotizacion"] == null)
            {
                NuevaCotizacion vale = new NuevaCotizacion(this);
                vale.MdiParent = this;
                vale.Show();
            }
            else
            {
                Application.OpenForms["NuevaCotizacion"].Activate();
            }

        }

        private void cobrarValeToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
        }

        private void verCotizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["VerCotizaciones"] == null)
            {
                VerCotizaciones vale = new VerCotizaciones();
                vale.MdiParent = this;
                vale.Show();
            }
            else
            {
                Application.OpenForms["VerCotizaciones"].Activate();
            }

        }

        private void nuevoPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["NuevoPedido"] == null)
            {
                NuevoPedido vale = new NuevoPedido(this);
                vale.MdiParent = this;
                vale.Show();
            }
            else
            {
                Application.OpenForms["NuevoPedido"].Activate();
            }
        }

        private void verPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["VerPedidos"] == null)
            {
                VerPedidos vale = new VerPedidos();
                vale.MdiParent = this;
                vale.Show();
            }
            else
            {
                Application.OpenForms["VerPedidos"].Activate();
            }
        }

        private void verPromocionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["VerPromos"] == null)
            {
                VerPromos vale = new VerPromos();
                vale.MdiParent = this;
                vale.Show();
            }
            else
            {
                Application.OpenForms["VerPromos"].Activate();
            }

        }

        private void cuentasPorCobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void talonariosDeRecibosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void nuevaCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["CrearCuenta"] == null)
            {
                CrearCuenta crearCuenta = new CrearCuenta(this);
                crearCuenta.MdiParent = this;
                crearCuenta.Show();
            }
            else
            {
                Application.OpenForms["CrearCuenta"].Activate();
            }
        }

        private void pagoDeCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["PagosCC"] == null)
            {
                PagosCC vale = new PagosCC();
                vale.MdiParent = this;
                vale.Show();
            }
            else
            {
                Application.OpenForms["PagosCC"].Activate();
            }
        }

        private void talonariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Talonarios"] == null)
            {
                Talonarios vale = new Talonarios(this);
                vale.MdiParent = this;
                vale.Show();
            }
            else
            {
                Application.OpenForms["Talonarios"].Activate();
            }
        }

        private void anularFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["AnularFEL"] == null)
            {
                AnularFEL vale = new AnularFEL(this);
                vale.MdiParent = this;
                vale.Show();
            }
            else
            {
                Application.OpenForms["AnularFEL"].Activate();
            }
        }

        private void pOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["LoginForm"] == null)
            {
                LoginForm pos = new LoginForm();
                pos.MdiParent = this;
                pos.Show();
            }
            else
            {
                Application.OpenForms["LoginForm"].Activate();
            }
        }

        private void verAnulacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ListarAnulaciones"] == null)
            {
                //ListarAnulaciones pListarAnulacionesos = new ListarAnulaciones();
                //pListarAnulacionesos.MdiParent = this;
                //pListarAnulacionesos.Show();
            }
            else
            {
                Application.OpenForms["ListarAnulaciones"].Activate();
            }
        }

        private void verCertificacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["verCertificadosFel"] == null)
            {
                //verCertificadosFel verCertificados = new verCertificadosFel();
                //verCertificados.MdiParent = this;
                //verCertificados.Show();
            }
            else
            {
                Application.OpenForms["verCertificadosFel"].Activate();
            }
        }

        private void solicitarPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["VerPrestamos"] == null)
            {
                VerPrestamos verrPrestamos = new VerPrestamos();
                verrPrestamos.MdiParent = this;
                verrPrestamos.Show();
            }
            else
            {
                Application.OpenForms["VerPrestamos"].Activate();
            }
        }

        private void validarPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["RegistroDesembolso"] == null)
            {
                RegistroDesembolso registroDesembolso = new RegistroDesembolso();
                registroDesembolso.MdiParent = this;
                registroDesembolso.Show();
            }
            else
            {
                Application.OpenForms["RegistroDesembolso"].Activate();
            }

        }

        private void cobrarPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["CobroCreditos"] == null)
            {
                CobroCreditos cobrocreditos = new CobroCreditos(this);
                cobrocreditos.MdiParent = this;
                cobrocreditos.Show();
            }
            else
            {
                Application.OpenForms["CobroCreditos"].Activate();
            }
        }

        private void notaDeCréditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["NotaCreditoVista"] == null)
            {
                NotaCreditoVista notaCreditoVista = new NotaCreditoVista();
                notaCreditoVista.MdiParent = this;
                notaCreditoVista.Show();
            }
            else
            {
                Application.OpenForms["NotaCreditoVista"].Activate();
            }
        }

        private void notasDeDébitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["NotaDebitoVista"] == null)
            {
                NotaDebitoVista notaDebitoVista = new NotaDebitoVista();
                notaDebitoVista.MdiParent = this;
                notaDebitoVista.Show();
            }
            else
            {
                Application.OpenForms["NotaDebitoVista"].Activate();
            }
        }

        private void reportesToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ReporteCompras"] == null)
            {
                ReporteCompras reporteCompras = new ReporteCompras();
                reporteCompras.MdiParent = this;
                reporteCompras.Show();
            }
            else
            {
                Application.OpenForms["ReporteCompras"].Activate();
            }
        }

        private void importarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Importar_data"] == null)
            {
                //Importar_data data = new Importar_data();
                //data.Show();
            }
            else
            { Application.OpenForms["Importar_data"].Activate(); }
        }

        private void reportesToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ReporteVentas"] == null)
            {
                ReporteVentas reporteVentas = new ReporteVentas();
                reporteVentas.MdiParent = this;
                reporteVentas.Show();
            }
            else
            {
                Application.OpenForms["ReporteVentas"].Activate();
            }
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ModuloCombos"] == null)
            {
                ModuloCombos combos = new ModuloCombos();
                combos.Show();
            }
            else
            {
                Application.OpenForms["ModuloCombos"].Activate();
            }
        }

        private void promocionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ModuloPromos"] == null)
            {
                ModuloPromos promos = new ModuloPromos();
                promos.Show();
            }
            else
            {
                Application.OpenForms["ModuloPromos"].Activate();
            }
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void configuracionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ModuloConfiguracion"] == null)
            {
                ModuloConfiguracion config = new ModuloConfiguracion();
                config.Show();
            }
            else
            {
                Application.OpenForms["ModuloConfiguracion"].Activate();
            }
        }

        private void plantillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Plantilla"] == null)
            {
                Plantilla pp = new Plantilla();
                pp.Show();
            }
            else
            {
                Application.OpenForms["Plantilla"].Activate();
            }
        }

        private void configuraciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
