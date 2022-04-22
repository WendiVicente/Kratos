using CapaDatos;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Precios;
using CapaDatos.Models.Productos;
using CapaDatos.Repository;
using CapaDatos.Repository.PreciosRepository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models;
using Sistema.Forms.Extras;
using Sistema.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_producto
{
    public partial class NuevoProducto : BaseContext
    {
        private readonly ProductosRepository _productosRepository = null;
        private readonly TallasRepository _tallasRepository = null;
        private readonly TipoPrecioRepository _tipoPrecioRepository = null;
        private readonly ValidarExistenciaProducto _validarExistenciaProducto = null;
        private readonly ColoresRepository _coloresRepository = null;
        private readonly ClientesRepository _clientesRepository = null;
        private readonly TallasyColoresRepository _tallasyColoresRepository = null;
        private readonly ProveedoresRepository _proveedoresRepository = null;
        private readonly PreciosDetallePepsRepository _preciosDetallePepsRepository = null;
        public List<ColoresProducto> _listacolores = new List<ColoresProducto>();
        public List<DetalleTalla> _listaTallas = new List<DetalleTalla>();
        public List<DetalleColorTalla> _listaColorTallas = new List<DetalleColorTalla>();
        private List<ListarDetallePrecios> listaDetalles = null;
        private List<ListarDetallePrecios> lista1 = null, lista2 = null, lista3 = null, lista4 = null, lista5 = null;
        private DateTime fechaInicio => Convert.ToDateTime(dtpfechainicio.Value.ToLongDateString());
        private DateTime fechaFinal => Convert.ToDateTime(dtpfechafinal.Value.ToLongDateString());
        public int stockToValidar;
        double cantidadSemanas = 0;
        private Layout layout = null;
        byte[] filefoto = null;
        public NuevoProducto(Layout ll)
        {
            layout = ll;
               _validarExistenciaProducto = new ValidarExistenciaProducto(_context);
            _preciosDetallePepsRepository = new PreciosDetallePepsRepository(_context);
            _tallasyColoresRepository = new TallasyColoresRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            _tipoPrecioRepository = new TipoPrecioRepository(_context);
            _proveedoresRepository = new ProveedoresRepository(_context);
            _clientesRepository = new ClientesRepository(_context);
            _coloresRepository = new ColoresRepository(_context);
            _tallasRepository = new TallasRepository(_context);
            
            listaDetalles = new List<ListarDetallePrecios>();

             lista1 = new List<ListarDetallePrecios>();
             lista2 = new List<ListarDetallePrecios>();
             lista3 = new List<ListarDetallePrecios>();
             lista4 = new List<ListarDetallePrecios>();
             lista5 = new List<ListarDetallePrecios>();
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void NuevoProducto_Load(object sender, EventArgs e)
        {
            
            CargarCategorias();
            CargarCheckBoxes();
            OcultarMovimiento();
            OcultarAlertaStock();
            CargarEscala();
            CargarTipos();
            OcultarGrupos();
            Cargarproveedores();

        }

        public void CargarCategorias()
        {
            categoriaprod.DataSource = _productosRepository.GetCategoriasList();
            categoriaprod.DisplayMember = "Nombre";
            categoriaprod.ValueMember = "Id";
            categoriaprod.Invalidate();
        }
        private void Cargarproveedores()
        {
            try
            {
                cbproveedor.DataSource = _proveedoresRepository.GetList();
                cbproveedor.DisplayMember = "Nombre";
                cbproveedor.ValueMember = "Id";
                cbproveedor.Invalidate();
            }
            catch (Exception ex)
            {

                KryptonMessageBox.Show("no hay ningun proveedor,deberá ingresar uno", ex.Message);
            }
           
        }

        public void CargarCheckBoxes()
        {
            puedeservendido.Checked = true;
            puedesercmprado.Checked = true;
            controlarstock.Checked = true;
        }

  

        public Producto GetviewModel()
        {

           
            var producto = new Producto()
            {
                Descripcion = nomproductotxt.Text,

                CategoriaId = Convert.ToInt32(categoriaprod.SelectedValue.ToString()),
                ProveedorId= Convert.ToInt32(cbproveedor.SelectedValue.ToString()),
                PermitirVenta = puedeservendido.Checked, //
                PermitirCompra = puedesercmprado.Checked, //
                StockControl = controlarstock.Checked, //
                Ubicacion = ubicaciontxt.Text, //
                CodigoBarras = codigoreferencia.Text, //
                DescripcionCorta = txtdescripcorta.Text,
                Impuesto = 0.12M, //
                Coste = Convert.ToDecimal(costetxt.Text), //
                TieneEscalas = checkEscala.Checked,
                Stock = Convert.ToInt32(stockproducto.Text),
                Notas = notasinternas.Text, //
                FechaIngreso = DateTime.Now,
                FechaModificacion = DateTime.Now,
                SucursalId = UsuarioLogeadoSistemas.User.SucursalId,
                TieneColor = checkColor.Checked,
                TieneTalla = checktalla.Checked,
                stockMinimo = int.Parse(txtcantidadmin.Text),
                PeriodoMovimiento = cantidadSemanas.ToString("0"),
                Imagen = filefoto,
                UnidadMedida= txtunidadmedida.Text,
                Marca = txtmarca.Text,
                Numeral= txtnumeral.Text,

            };

                return producto;



        }

        private  PreciosDetallePeps GetmodelPreciosPeps()
        {
            var preciospeps = new PreciosDetallePeps()
            {
                //PrecioCuentaClave = txtpreciocuentaclave.Text == null ? 0.00m : decimal.Parse(txtpreciocuentaclave.Text),
                //PrecioEntidadGubernamental = txtpreciogobierno.Text == null ? 0.00m : decimal.Parse(txtpreciogobierno.Text),
                //PrecioMayorista = txtpreciomayorista.Text == null ? 0.00M : decimal.Parse(txtpreciomayorista.Text),
                //PrecioRevendedor = txtpreciorevendedor.Text == null ? 0.00M : decimal.Parse(txtpreciorevendedor.Text),
                //PrecioVenta = txtprecioventa.Text == null ? 0.00M : decimal.Parse(txtprecioventa.Text),
                Coste= costetxt.Text==null? 0.00M: decimal.Parse(txtprecioVar.Text),
                Cantidad= stockproducto.Text==null? 0: int.Parse(stockproducto.Text),
                FechaIngreso= DateTime.Now,
                //ProductoId=
            };
            return preciospeps;
        }

        private DetalleColor Getmodelo()
        {

            var DetalleColor = new DetalleColor()
            {
              //  Color = txtColor.Text,
                

            };
            return DetalleColor;
        }

       private TipoPrecio GetModelTipoPrecio()
        {
            var tipoprecio = new TipoPrecio()
            {
                Id = Guid.NewGuid(),
                FechaInicio = DateTime.Now,

            };
            return tipoprecio;
        }




        private void OcultarAlertaStock()
        {

            lbcantidadmin.Visible = false;
            txtcantidadmin.Visible = false;

        }

        private void OcultarMovimiento()
        {
            rbcuatro.Visible = false;
            rbochosem.Visible = false;
            rbpersonal.Visible = false;
            Ocultartiempos();
        }
        private void OcultarGrupos()
        {
            groupEscala.Visible = false;
            btnAddPrecio.Visible = false;
            
        }

        private void Ocultartiempos()
        {
            dtpfechafinal.Visible = false;
            dtpfechainicio.Visible = false;
            lbfechafinal.Visible = false;
            lbfechainicio.Visible = false;

        }
        private void VerTiempos()
        {
            dtpfechafinal.Visible = true;
            dtpfechainicio.Visible = true;
            lbfechafinal.Visible = true;
            lbfechainicio.Visible = true;

        }
        private void VerMovimiento()
        {
            rbcuatro.Visible = true;
            rbochosem.Visible = true;
            rbpersonal.Visible = true;
           
        }
       
       

        private void checkExistencia_CheckedChanged(object sender, EventArgs e)
        {
            if (checkExistencia.Checked == false)
            {

                OcultarAlertaStock();
            }
            else
            {

                lbcantidadmin.Visible = true;
                txtcantidadmin.Visible = true;
            }

        }

        private void checkmovimiento_CheckedChanged(object sender, EventArgs e)
        {
            if (checkmovimiento.Checked == false)
            {

                OcultarMovimiento();
            }
            else
            {

                VerMovimiento();
                ///CalcularTiempo();
            }
        }

        private void rbpersonal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbpersonal.Checked == false)
            {

                Ocultartiempos();
            }
            else
            {

                VerTiempos();
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            CalcularTiempo();
           if (checkColor.Checked == true && _listacolores.Any() == false)
            {
                KryptonMessageBox.Show("CheckBox esta seleccionado pero no ha elegido ningún color \n desmarque la casilla o añada colores", "ERROR", MessageBoxButtons.OK);
                return;
            }
            if (checktalla.Checked == true && _listaTallas.Any() == false)
            {
                KryptonMessageBox.Show("Tallas esta seleccionado pero no ha elegido ninguna Talla \n desmarque la casilla o añada colores", "ERROR", MessageBoxButtons.OK);
                return;
            }
            if (_validarExistenciaProducto.ValidarRegistro(codigoreferencia.Text, UsuarioLogeadoSistemas.User.SucursalId))
            {
                KryptonMessageBox.Show("Ya existe un producto con este código.", "ERROR", MessageBoxButtons.OK);
                return;
            }
            if (ValidarNullos() != "")
            {
                string msj = ValidarNullos();
                KryptonMessageBox.Show(msj);
                return;
            }

           
            try
            {
                var model = GetviewModel();
                if (!ModelState.IsValid(model)) return;

                if (rdcolorytalla.Checked == true)
                {
                    model.TieneColor = true;
                    model.TieneTalla = true;
                }
                if (checkEscala.Checked == false)
                {
                    model.PrecioVenta = Convert.ToDecimal(txtprecioventa.Text);
                    model.PrecioCuentaClave = Convert.ToDecimal(txtpreciocuentaclave.Text);
                    model.PrecioEntidadGubernamental = Convert.ToDecimal(txtpreciogobierno.Text);
                    model.PrecioMayorista = Convert.ToDecimal(txtpreciomayorista.Text);
                    model.PrecioRevendedor = Convert.ToDecimal(txtpreciorevendedor.Text);
                }

                    _productosRepository.Add(model);
            }
            catch (Exception ex )
            {

                KryptonMessageBox.Show("Valide los campos ingresados, no se aceptan nullos", ex.Message);
                return;
            }

            if (checkEscala.Checked == false)
            {
               
                try
                {
                    var preciosPeps = GetmodelPreciosPeps();
                    var productoObtenido = _productosRepository.GetProductByBarCode(codigoreferencia.Text, UsuarioLogeadoSistemas.User.SucursalId);
                    preciosPeps.ProductoId = productoObtenido.Id;

                    _preciosDetallePepsRepository.Add(preciosPeps);
                }
                catch (Exception ex)
                {

                    KryptonMessageBox.Show(ex.Message);
                }
               
            }


            GuardarTipoyDetalles();

            if (checkColor.Checked == true && _listacolores.Any()==true)
            {
                foreach (var item in _listacolores)
                {

                    var detalleModel = Getmodelo();
                if (!ModelState.IsValid(detalleModel)) return;
                if (_productosRepository.GetProductByBarCode(codigoreferencia.Text, UsuarioLogeadoSistemas.User.SucursalId) == null) return;

                var productoObtenido = _productosRepository.GetProductByBarCode(codigoreferencia.Text, UsuarioLogeadoSistemas.User.SucursalId);
                // añadiir codigo de proudcto y stock 
                    detalleModel.ProductoId = productoObtenido.Id;
                    detalleModel.Stock = item.cantidad;
                    detalleModel.Color = item.ColorDescripcion;
                    _coloresRepository.Add(detalleModel);
                }
                

            }
            if(checktalla.Checked=true && _listaTallas.Any() == true)
            {
                foreach ( var item in _listaTallas)
                {
                    if (_productosRepository.GetProductByBarCode(codigoreferencia.Text, UsuarioLogeadoSistemas.User.SucursalId) == null) return;
                    var productoObtenido = _productosRepository.GetProductByBarCode(codigoreferencia.Text, UsuarioLogeadoSistemas.User.SucursalId);
                    // añadiir codigo de proudcto y stock 
                    item.ProductoId = productoObtenido.Id;
                    _tallasRepository.Add(item);

                }

            }
            if (rdcolorytalla.Checked = true && _listaColorTallas.Any() == true)
            {

                foreach (var item in _listaColorTallas)
                {
                    if (_productosRepository.GetProductByBarCode(codigoreferencia.Text, UsuarioLogeadoSistemas.User.SucursalId) == null) return;
                    var productoObtenido = _productosRepository.GetProductByBarCode(codigoreferencia.Text, UsuarioLogeadoSistemas.User.SucursalId);
                    // añadiir codigo de proudcto
                    item.ProductoId = productoObtenido.Id;
                    _tallasyColoresRepository.Add(item);

                }

            }


            KryptonMessageBox.Show("Registro Guardado correctamente");
            LimpiarDatos();
            Close();
        }
     

        public void CalcularTiempo()
        {

            if (rbcuatro.Checked)
            {
                cantidadSemanas = 4;
            }
             if (rbochosem.Checked)
            {
                cantidadSemanas = 8;
            }
            
             if (rbpersonal.Checked)
            {
                cantidadSemanas = (fechaFinal- fechaInicio  ).TotalDays / 7;

            }
           

        }

        private void button1_Click(object sender, EventArgs e)
        {

            CalcularTiempo();
            KryptonMessageBox.Show(cantidadSemanas.ToString("0"));
        }

      
        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void btnAddPrecio_Click(object sender, EventArgs e)
        {
           if(string.IsNullOrEmpty(txtprecioVar.Text) || decimal.Parse(txtprecioVar.Text) <= 0)
            {
                KryptonMessageBox.Show("Debe ingresar un Precio valido para continuar");
                return;
            }
            if (cbTiposClientes.Text == "Minorista")
            {
                var Detalle1 = GetDetallePreciosModel();
                if (!comprobarEscala(Dgvunitario, Detalle1))
                {

                    lista1.Add(Detalle1);
                    RefrescarDetallePrecios(Dgvunitario, lista1);
                }
               

            }
            if (cbTiposClientes.Text == "Mayorista")
            {
                var Detalle2 = GetDetallePreciosModel();
                if (!comprobarEscala(dgvmayorista, Detalle2))
                {
                    lista2.Add(Detalle2);
                    RefrescarDetallePrecios(dgvmayorista, lista2);
                }
               
              
            }
            if (cbTiposClientes.Text == "Cuenta Clave")
            {
                var Detalle3 = GetDetallePreciosModel();
                if (!comprobarEscala(dgvcuentaclave, Detalle3))
                {
                    lista3.Add(Detalle3);
                    RefrescarDetallePrecios(dgvcuentaclave, lista3);
                }
               

            }
            if (cbTiposClientes.Text == "Revendedor")
            {
                var Detalle4 = GetDetallePreciosModel();
                 if (!comprobarEscala(dgvrevendedor, Detalle4))
                {
                    lista4.Add(Detalle4);
                    RefrescarDetallePrecios(dgvrevendedor, lista4);
                }
            }
            if (cbTiposClientes.Text == "Gubernamental")
            {
                var Detalle5 = GetDetallePreciosModel();
                if (!comprobarEscala(dgvgubernamental, Detalle5))
                {
                   
                    lista5.Add(Detalle5);
                    RefrescarDetallePrecios(dgvgubernamental, lista5);
                }
            }


        }

        private void CargarTipos()
        {
            var tipos = _clientesRepository.GetTipos();

            cbTiposClientes.DataSource = tipos;
            cbTiposClientes.DisplayMember = "TipoCliente";
            cbTiposClientes.ValueMember = "Id";
            //cbsucursales.Text = "Seleccione una Sucursal"; // esto no jalo? no me jalo
            cbTiposClientes.SelectedIndex = 0;
            cbTiposClientes.Invalidate();
        }
        private void CargarEscala()
        {
            cbEscala.Items.Insert(0, "E1");
            cbEscala.Items.Insert(1, "E2");
            cbEscala.Items.Insert(2, "E3");
            cbEscala.Items.Insert(3, "E4");
            cbEscala.SelectedIndex = 0;

        }


        private ListarDetallePrecios GetDetallePreciosModel()
        {

            var DetallePrecios = new ListarDetallePrecios()
            {
                Id= Guid.NewGuid(),
                Escala=cbEscala.Text,
                Precio= decimal.Parse(txtprecioVar.Text),
                Tipos= cbTiposClientes.Text, //
                TiposId= int.Parse(cbTiposClientes.SelectedValue.ToString()),
                RangoFinal = int.Parse(txtRangoFinal.Text),
                RangoInicio= int.Parse(txtRangoInic.Text),
                
            };
            return DetallePrecios;
        }



        public void RefrescarDetallePrecios(DataGridView data,List<ListarDetallePrecios> lista)
        {
           
            BindingSource source = new BindingSource();
           
            source.DataSource = lista;
            data.DataSource = typeof(List<>);
            data.DataSource = source;
            data.AutoResizeColumns();
            data.Columns[0].Visible = false;
            data.Columns[1].Visible = false;


        }

        private void cbEscala_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEscala.SelectedIndex == 0)
            {
                txtRangoInic.Text = "1";
                txtRangoFinal.Text = "11";

            }
            if (cbEscala.SelectedIndex == 1)
            {
                txtRangoInic.Text = "12";
                txtRangoFinal.Text = "49";

            }
            if (cbEscala.SelectedIndex == 2)
            {
                txtRangoInic.Text = "50";
                txtRangoFinal.Text = "1000";

            }
            if (cbEscala.SelectedIndex == 3)
            {
                txtRangoInic.Text = "1001";
                txtRangoFinal.Text = "10000";

            }


           
        }

        private void checkcolorPropertis()
        {
            if (string.IsNullOrEmpty(stockproducto.Text) || int.Parse(stockproducto.Text) <= 0)
            {


                if (ingreso == 0)
                {
                    KryptonMessageBox.Show("Por favor ingrese el stock, antes de continuar..");
                    ingreso += 1;
                    checkColor.Checked = false;

                    return;
                }
                checkColor.Checked = false;


            }
            ingreso = 0;


            if (_listacolores == null)
            {
                _listacolores = new List<ColoresProducto>();
            }




            if (checkColor.Checked == true)
            {
                
                if (Application.OpenForms["AgregarColor"] == null)
                {


                    AgregarColor agregarColor = new AgregarColor(this, _listacolores);
                    agregarColor.Show();


                }

                else { Application.OpenForms["AgregarColor"].Activate(); }

            }
            else
            {
                _listacolores.Clear();
            }
        }

        int ingreso;
        private void checktallaPropertis()
        {
            
            if (string.IsNullOrEmpty(stockproducto.Text) || int.Parse(stockproducto.Text) <= 0)
            {
               
               
                if (ingreso == 0)
                {
                    KryptonMessageBox.Show("Por favor ingrese el stock, antes de continuar..");
                    ingreso += 1;
                    checktalla.Checked = false;
                    
                    return;
                }
                checktalla.Checked = false;


            }
            ingreso = 0;

            if (_listaTallas == null)
            {
                _listaTallas = new List<DetalleTalla>();
            }
            if (checktalla.Checked == true)
            {
               
                if (Application.OpenForms["AgregarTalla"] == null)
                {


                    AgregarTalla agregarTalla = new AgregarTalla(this, _listaTallas);
                    agregarTalla.Show();


                }

                else { Application.OpenForms["AgregarTalla"].Activate(); }

            }
            else
            {
                _listaTallas.Clear();
            }
        }
        private void checkColoresTallas()
        {

            if (string.IsNullOrEmpty(stockproducto.Text) || int.Parse(stockproducto.Text) <= 0)
            {


                if (ingreso == 0)
                {
                    KryptonMessageBox.Show("Por favor ingrese el stock, antes de continuar..");
                    ingreso += 1;
                    rdcolorytalla.Checked = false;

                    return;
                }
                rdcolorytalla.Checked = false;


            }
            ingreso = 0;

            if (_listaColorTallas == null)
            {
                _listaColorTallas = new List<DetalleColorTalla>();
            }
            if (rdcolorytalla.Checked == true)
            {

                if (Application.OpenForms["AgregarColorTalla"] == null)
                {


                    AgregarColorTalla gregarColorTalla = new AgregarColorTalla(this, _listaColorTallas);
                    gregarColorTalla.Show();


                }

                else { Application.OpenForms["AgregarColorTalla"].Activate(); }

            }
            else
            {
                _listaColorTallas.Clear();
            }
        }

        private void stockproducto_TextChanged(object sender, EventArgs e)
       {
            if (!string.IsNullOrEmpty(stockproducto.Text))
            {
                stockToValidar = int.Parse(stockproducto.Text);
            }
            
        }

     

        private void lbLimpiar_Click(object sender, EventArgs e)
        {
            if (stockproducto.ReadOnly == false) return;

            var dialog = KryptonMessageBox.Show("¿Esta opción Eliminara la lista de colores o Tallas agregadas anteriormente?", "Limpiar datos",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            // dale proba okoko

            if (dialog == DialogResult.Yes)
            {
                if (checkColor.Checked == true)
                {
                    _listacolores.Clear();
                }
                if (checktalla.Checked == true)
                {
                    _listaTallas.Clear();
                }
                if (rdcolorytalla.Checked == true)
                {
                    _listaColorTallas.Clear();
                }

                checkColor.Checked = false;
                checktalla.Checked = false;
                rdcolorytalla.Checked = false;
                stockproducto.ReadOnly = false;

            }
            

        }

        private void rdcolorytalla_CheckedChanged(object sender, EventArgs e)
        {
            checkColoresTallas();
        }

        private void checkColor_CheckedChanged_1(object sender, EventArgs e)
        {
            
            checkcolorPropertis();
        }

        private void checktalla_CheckedChanged_1(object sender, EventArgs e)
        {
            checktallaPropertis();
        }

        private void stockproducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtcantidadmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void costetxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void costetxt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnfoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog imagen = new OpenFileDialog();
            imagen.Filter = "Archivos JPG (*.jpg)|*.jpg| Archivos png(*.png)|*.png";
            DialogResult filestream = imagen.ShowDialog();

            if (filestream == DialogResult.OK)
            {
                pBox.Image = Image.FromFile(imagen.FileName);

                filestreamImagen();
            }
           
        }

        private void filestreamImagen()
        {
            filefoto = null;
            MemoryStream memoryStream = new MemoryStream();
            pBox.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            memoryStream.GetBuffer();
            filefoto= memoryStream.GetBuffer();
           
        }

        private void costetxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void checkEscala_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscala.Checked == false)
            {
                groupEscala.Visible = false;
                groupPrecios.Visible = true;
                btnAddPrecio.Visible = false;
               
            }
            else
            {
                groupPrecios.Visible = false;
                groupEscala.Visible = true;
                btnAddPrecio.Visible = true;
              
            }

        }

        


        public bool comprobarEscala(DataGridView dataGrid,ListarDetallePrecios detallePrecio)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.Cells[3].Value.ToString() == detallePrecio.Escala)
                {
                    return true;
                }
            }

            return false;
        }


        private void GuardarTipoyDetalles()
        {
            try
            {
                DatagridToList();
                var listaEscalas = new List<ListarDetallePrecios>();
                var listaDetalle = new List<DetallePrecio>();
                listaEscalas = lista1.Concat(lista2).Concat(lista3).Concat(lista4).Concat(lista5).ToList();
                var encabezadoTipoprecio = GetModelTipoPrecio();
                if (!ModelState.IsValid(encabezadoTipoprecio)) return;
                var productoReciente = _productosRepository.GetProductByBarCode(codigoreferencia.Text, UsuarioLogeadoSistemas.User.SucursalId);
                encabezadoTipoprecio.ProductoId = productoReciente.Id;
                _tipoPrecioRepository.Add(encabezadoTipoprecio);
                foreach (var item in listaEscalas)
                {
                    DetallePrecio detallePrecio = new DetallePrecio();
                    detallePrecio.Id = Guid.NewGuid();
                    detallePrecio.TipoPrecioId = encabezadoTipoprecio.Id;
                    detallePrecio.Escala = item.Escala;
                    detallePrecio.Precio = item.Precio;
                    detallePrecio.RangoInicio = item.RangoInicio;
                    detallePrecio.RangoFinal = item.RangoFinal;
                    detallePrecio.TiposId = item.TiposId;
                    listaDetalle.Add(detallePrecio);
                }

                foreach (var detailPrecio in listaDetalle)
                {
                    _tipoPrecioRepository.AddDetallePrecio(detailPrecio);
                }
            }
            catch (Exception ex)
            {

                KryptonMessageBox.Show("Revise las escalas de precio y los valores ingresados", ex.Message);
            }
           

        }

        private void checkColor_Click(object sender, EventArgs e)
        {
            checkcolorPropertis();
        }

        private void checktalla_Click(object sender, EventArgs e)
        {
            checktallaPropertis();

        }

        private void LimpiarDatos()
        {
            NuevoProducto nuevoProducto = new NuevoProducto(layout);
            nuevoProducto.MdiParent = layout;
            nuevoProducto.Show();
        }

        private string ValidarNullos()
        {
            string msj="";
            if (categoriaprod.SelectedValue == null)
            {
                 msj = "Debe seleccionar una categoria";
            }else
            if( cbproveedor.SelectedValue == null)
            {
                 msj = "Debe seleccionar un proveedor";
            }else
            if (string.IsNullOrEmpty(codigoreferencia.Text))
            {
                 msj = "Debe ingresar un codigo de referencia";
            }
            //else
            //if (!Int32.TryParse(stockproducto.Text, out var n) || stockproducto.Text=="0")
            //{
                
            //     msj= "Debe ingresar una cantidad de stock valida";
            //}
            else
            if (!Int32.TryParse(txtcantidadmin.Text, out var a) || txtcantidadmin.Text == "0")
            {

                 msj = "Debe ingresar una cantidad minima valida";
            }else
            if (filefoto == null)
            {
                 msj = "Debe ingresar una imagen";
            }
            if (checkEscala.Checked == false)
            {
                if (string.IsNullOrEmpty(txtprecioventa.Text) || !Int32.TryParse(txtprecioventa.Text,out var numberStyles))
                {
                    msj = "Debe ingresar un precio de venta valido";
                }
            }
            return msj;
                
        }

        private void DatagridToList()
        {
            List<ListarDetallePrecios> listatemporal = new List<ListarDetallePrecios>();
            if (Dgvunitario.RowCount > 0)
            {
                listatemporal.Clear();
                 lista1 = dgvTolista(listatemporal, Dgvunitario);
               
            }
            if (dgvmayorista.RowCount > 0)
            {
                listatemporal.Clear();
                lista2 = dgvTolista(listatemporal, dgvmayorista);
            }
            if (dgvcuentaclave.RowCount > 0)
            {
                listatemporal.Clear();
                lista3 = dgvTolista(listatemporal, dgvcuentaclave);

            }
            if (dgvrevendedor.RowCount > 0)
            {
                listatemporal.Clear();
                lista4 = dgvTolista(listatemporal, dgvrevendedor);
            }
            if (dgvgubernamental.RowCount > 0)
            {
                listatemporal.Clear();
                lista5 = dgvTolista(listatemporal, dgvgubernamental);
            }
        }

        private List<ListarDetallePrecios> dgvTolista(List<ListarDetallePrecios> lista,DataGridView dataGrid)
        {
            int ContadorFilaActual = 0;
            foreach (DataGridViewRow rows in dataGrid.Rows)
            {
                var fila = (ListarDetallePrecios)dataGrid.Rows[ContadorFilaActual].DataBoundItem;
                lista.Add(fila);
                ContadorFilaActual++;
            }
            return lista;
        }




    }
}
