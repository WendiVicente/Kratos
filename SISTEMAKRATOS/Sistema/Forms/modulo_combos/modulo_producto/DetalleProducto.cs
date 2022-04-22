using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Precios;
using CapaDatos.Models.Productos;
using CapaDatos.Repository;
using CapaDatos.Repository.PreciosRepository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models;
using Sistema.Forms.Extras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_producto
{
    public partial class DetalleProducto : BaseContext
    {
        private ProductosRepository _productosRepository = null;
        private readonly ProveedoresRepository _proveedoresRepository = null;
        private readonly ClientesRepository _clientesRepository = null;
        private ColoresRepository _detalleColor = null;
        private readonly TipoPrecioRepository _tipoPrecioRepository = null;
        private readonly TiposClienteRepository _tiposClienteRepository = null;
        private TallasRepository _tallasRepository = null;
        private TallasyColoresRepository _tallasyColoresRepository = null;
        private PreciosDetallePepsRepository _detallePreciosRepository = null;
        // variables

        public int stockstockToValidar = 0;
        int ingreso;
        byte[] filefoto = null;
        public Producto _producto = null;
        //listas
        private List<ListarDetallePrecios> lista1 = null, lista2 = null, lista3 = null, lista4 = null, lista5 = null;
        private readonly ListaProductos _listaProductos;
        //colores tallas y ambos

        public List<DetalleColor> _listacolores = new List<DetalleColor>();
        public List<DetalleColor> _listacoloresProd = new List<DetalleColor>();
        public List<DetalleTalla> _listaTallas = new List<DetalleTalla>();
        public List<DetalleTalla> _listaTallasProd = new List<DetalleTalla>();
        public List<DetalleColorTalla> _listaColorTallas = new List<DetalleColorTalla>();
        public int _idProducto = 0;

        public DetalleProducto(Producto producto, ListaProductos listaProductos)
        {
            _listaProductos = listaProductos;
            _producto = producto;
            _detalleColor = new ColoresRepository(_context);

            _productosRepository = new ProductosRepository(_context);
            _tipoPrecioRepository = new TipoPrecioRepository(_context);
            _clientesRepository = new ClientesRepository(_context);
            _proveedoresRepository = new ProveedoresRepository(_context);
            _tiposClienteRepository = new TiposClienteRepository(_context);
            _tallasyColoresRepository = new TallasyColoresRepository(_context); //
            _tallasRepository = new TallasRepository(_context);
            _detalleColor = new ColoresRepository(_context);
            _detallePreciosRepository = new PreciosDetallePepsRepository(_context);

            lista1 = new List<ListarDetallePrecios>();
            lista2 = new List<ListarDetallePrecios>();
            lista3 = new List<ListarDetallePrecios>();
            lista4 = new List<ListarDetallePrecios>();
            lista5 = new List<ListarDetallePrecios>();
            InitializeComponent();
            cargarcombos();
        }

        public void CargarTextBoxs()
        {
            try
            {
                _idProducto = _producto.Id;
                txtnombredelprod.Text = _producto.Descripcion;
                puedeservendido.Checked = _producto.PermitirVenta;
                puedesercmprado.Checked = _producto.PermitirCompra;
                controlarstock.Checked = _producto.StockControl;
                checkColor.Checked = _producto.TieneColor;
                ubicaciontxt.Text = _producto.Ubicacion;
                codigoreferencia.Text = _producto.CodigoBarras;
                precioventatxt.Text = _producto.PrecioVenta.ToString();
                costetxt.Text = _producto.Coste.ToString();
                stockproducto.Text = _producto.Stock.ToString();
                notasinternas.Text = _producto.Notas;
                labelFechaingreso.Text = _producto.FechaIngreso.ToString();
                txtmayorista.Text = _producto.PrecioMayorista.ToString();
                txtcuentaclave.Text = _producto.PrecioCuentaClave.ToString();
                txtentidad.Text = _producto.PrecioEntidadGubernamental.ToString();
                txtrevendedor.Text = _producto.PrecioRevendedor.ToString();
                stockstockToValidar = _producto.Stock;
                if (_producto.TieneEscalas)
                {
                    checkEscala.Checked = true;
                    OcultarGrupos();
                }
                TraerEscalasPrecios();
                if (_producto.TieneColor==true && _producto.TieneTalla==false)
                {
                    TraerColor();
                }
                else if(_producto.TieneColor==false && _producto.TieneTalla == true)
                {
                    TraerTalla();
                }
                else if(_producto.TieneColor==true && _producto.TieneTalla == true)
                {
                    TraerTallayColor();
                }

            }
            catch (Exception ex)
            {

                KryptonMessageBox.Show(ex.Message);
            }
        }
        public void TraerColor()
        {
            if (_detalleColor.GetColor(_producto.Id) != null)
            {
                var productodetalleColor = _detalleColor.GetProductoListaColor(_producto.Id);
                stockproducto.Text = productodetalleColor.Sum(x => x.Stock).ToString() ;
                _listacolores = productodetalleColor;
            }
        }
        public void TraerTalla()
        {
            if (_tallasRepository.GetTallaListaProducto(_producto.Id) != null)
            {
                var productodetalleTalla = _tallasRepository.GetTallaListaProducto(_producto.Id);
                stockproducto.Text = productodetalleTalla.Sum(x => x.Stock).ToString();
                _listaTallas = productodetalleTalla;
            }
        }
        public void TraerTallayColor()
        {
            if (_tallasyColoresRepository.GetTallaColorListaProducto(_producto.Id) != null)
            {
                var listatallaycolorbyproduc = _tallasyColoresRepository.GetTallaColorListaProducto(_producto.Id);
                stockproducto.Text = listatallaycolorbyproduc.Sum(x => x.Stock).ToString();
                _listaColorTallas = listatallaycolorbyproduc;
            }
        }



        private void TraerEscalasPrecios()
        {
            if (_producto.TieneEscalas != false)
            {
                var tipo = _tipoPrecioRepository.Get(_producto.Id);
                if (tipo != null)
                {
                    var detalleprecioslista = _tipoPrecioRepository.GetDetallePrecioListar(tipo.Id, 0);
                    if (detalleprecioslista != null)
                    {
                        foreach (var item in detalleprecioslista)
                        {
                            var tipoObtendio = _tiposClienteRepository.GetTipo(item.TiposId);
                            if (tipoObtendio.TipoCliente == "Mayorista") 
                            {
                                lista1.Add(item);
                            }
                            if (tipoObtendio.TipoCliente == "Minorista")
                            {
                                lista2.Add(item);
                            }
                            if(tipoObtendio.TipoCliente=="Cuenta Clave")
                            {
                                lista3.Add(item);
                            }
                            if (tipoObtendio.TipoCliente == "Revendedor")
                            {
                                lista4.Add(item);
                            }
                            if (tipoObtendio.TipoCliente == "Gubernamental")
                            {
                                lista5.Add(item);
                            }
                        }

                        cargarDGVPrecios(lista1, dgvmayorista);
                        cargarDGVPrecios(lista2, Dgvunitario);
                        cargarDGVPrecios(lista3, dgvcuentaclave);
                        cargarDGVPrecios(lista4, dgvrevendedor);
                        cargarDGVPrecios(lista5, dgvgubernamental);

                    }


                }

            }

        }
        private void cargarDGVPrecios(List<ListarDetallePrecios> lista, DataGridView datag)
        {
                BindingSource source = new BindingSource();

                source.DataSource = lista;
            datag.DataSource = typeof(List<>);
            datag.DataSource = source;
            datag.AutoResizeColumns();
            //datag.Columns[0].Visible = false;
            // datag.Columns[1].Visible = false;

        }


        private void cargarcombos()
        {
          
            OcultarMovimiento();
            OcultarAlertaStock();
            CargarEscala();
            CargarTipos();
            //OcultarGrupos();
            Cargarproveedores();
        }



        private void cargarCategoria()
        {

            categoriaprod.DataSource = _productosRepository.GetCategoriasList();
            categoriaprod.DisplayMember = "Nombre";
            categoriaprod.ValueMember = "Id";
            categoriaprod.SelectedValue = _producto.CategoriaId;
            categoriaprod.Invalidate();


        }
        private void cargarImg()
        {
            if (_producto.Imagen == null) { return; }
            byte[] imageData = _producto.Imagen;
            MemoryStream mStream = new MemoryStream(imageData);
            pBox.Image = Image.FromStream(mStream);
        }

        private void DetalleProducto_Load(object sender, EventArgs e)
        {
            CargarTextBoxs();
            cargarCategoria();
            Ocultarcolor();
            cargarImg();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var producto = _productosRepository.Get(_producto.Id);

                var GetProducto = GetModelProducto(producto);


                var detalleColor = _detalleColor.GetProductoListaColor(producto.Id);
                if (detalleColor.Count > 0) 
                {
                    foreach (DetalleColor dc in detalleColor)
                    {
                        _detalleColor.DeleteDetalleColor(dc);
                    }
                }
                if (_listacoloresProd.Count > 0)
                {
                    foreach (DetalleColor dc in _listacoloresProd)
                    {
                        _detalleColor.Add(dc);
                    }
                }


                var detalleTalla = _tallasRepository.GetTallaListaProducto(producto.Id);
                if (detalleTalla.Count > 0)
                {
                    foreach (DetalleTalla dt in detalleTalla)
                    {
                        _tallasRepository.DeleteDetalleTalla(dt);
                    }
                }
                if (_listaTallasProd.Count > 0)
                {
                    foreach (DetalleTalla dt in _listaTallasProd)
                    {
                        _tallasRepository.Add(dt);
                    }
                }

                //List<ListarDetallePrecios> listado = CargarPrecios();
                //var detallePrecios = _detallePreciosRepository.GetPreciosPeps(producto.Id);
                //if (listado.Count > 0)
                //{
                //    foreach (ListarDetallePrecios ldp in listado)
                //    {
                //        PreciosDetallePeps dd = new PreciosDetallePeps();
                //        dd.ProductoId = producto.Id;
                //        dd.Cantidad = Convert.ToInt32(stockproducto.Text);
                //        dd.PrecioVenta = ldp.Precio;
                //        _detallePreciosRepository.Add(dd);

                //    }
                //}

                if (!ModelState.IsValid(GetProducto)) return;
                _productosRepository.Update(GetProducto);
                _listaProductos.RefrescarDataGridProductos(true);

                Close();
            }
            catch (Exception ex)
            {

                KryptonMessageBox.Show(ex.Message);
            }
           
            /*
            if (checkColor.Checked == false)
            {
                GetProducto.Stock = int.Parse(stockproducto.Text);

            }

            if(producto.TieneColor == true) //si producto obtenido tiene color 
            {
                var detallecolor = _detalleColor.GetColor(_producto.Id);
                if (checkColor.Checked == true)  // si esta con check unicamente es actaulizacion 
                {
                    
                    var GetDetalle = GetModelColor(detallecolor);

                    if (!ModelState.IsValid(GetDetalle)) return;
                 
                    _detalleColor.Update(GetDetalle);

                }
                else // si no tiene check eliminara el registro en detallecolors
                {
                   
                    _detalleColor.DeleteDetalleColor(detallecolor);
                    GetProducto.TieneColor = false;
                   // _productosRepository.Update(GetProducto);
                }


            }
            else
            {
               
                if (checkColor.Checked == true)  // si esta con check unicamente es actaulizacion 
                {
                    // detallecolor = _detalleColor.GetColor(_producto.Id);
                    var GetDetalle = Getmodelo();

                    if (!ModelState.IsValid(GetDetalle)) return;
                    
                    _detalleColor.Add(GetDetalle);
                    GetProducto.TieneColor = true;
                    GetProducto.Stock = 0;

                }
            }
            */
           

               

        }

        public Producto GetModelProducto(Producto producto)
        {

            producto.CodigoBarras = codigoreferencia.Text;
            producto.CategoriaId = Convert.ToInt32(categoriaprod.SelectedValue.ToString());
            producto.Descripcion = txtnombredelprod.Text;
            producto.PermitirVenta = puedeservendido.Checked;
            producto.PermitirCompra = puedesercmprado.Checked;
            producto.StockControl = controlarstock.Checked;
            producto.Ubicacion = ubicaciontxt.Text;
            producto.PrecioVenta = Convert.ToDecimal(precioventatxt.Text);
            producto.Coste = Convert.ToDecimal(costetxt.Text);
            producto.Stock = Convert.ToInt32(stockproducto.Text);
            producto.Notas = notasinternas.Text;
            producto.PrecioRevendedor = Convert.ToDecimal(txtrevendedor.Text);
            producto.PrecioMayorista = Convert.ToDecimal(txtmayorista.Text);
            producto.PrecioEntidadGubernamental = Convert.ToDecimal(txtentidad.Text);
            producto.PrecioCuentaClave = Convert.ToDecimal(txtcuentaclave.Text);
            producto.FechaModificacion = DateTime.Now;
            producto.Imagen = filefoto;
            return producto;
        }

        private  DetalleColor GetModelColor(DetalleColor detallecolor)
        {
           // detallecolor.ProductoId = _producto.Id;
            detallecolor.Stock = int.Parse(stockproducto.Text);
            //detallecolor.Color = txtColor.Text;
            
            return detallecolor;
        }

        private DetalleColor Getmodelo()
        {

            var DetalleColor = new DetalleColor()
            {
                ProductoId = _producto.Id,
                //Color = txtColor.Text,
                Stock = int.Parse(stockproducto.Text),

            };
            return DetalleColor;
        }

        private void checkColor_CheckStateChanged(object sender, EventArgs e)
        {

           
                if (checkColor.Checked == false)
                {

                    Ocultarcolor();
                }
                else
                {

                    //lbColor.Visible = true;
                    //txtColor.Visible = true;
                }
         }

        private void Ocultarcolor()
            {
                //lbColor.Visible = false;
                //txtColor.Visible = false;
                //txtColor.Text = "";

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
            filefoto = memoryStream.GetBuffer();

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




        private void CargarTipos()
        {
            var tipos = _clientesRepository.GetTipos();

            cbTiposClientes.DataSource = tipos;
            cbTiposClientes.DisplayMember = "TipoCliente";
            cbTiposClientes.ValueMember = "Id";
            //cbsucursales.Text = "Seleccione una Sucursal"; 
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
                Id = Guid.NewGuid(),
                Escala = cbEscala.Text,
                Precio = decimal.Parse(txtprecioVar.Text),
                Tipos = cbTiposClientes.Text, //
                TiposId = int.Parse(cbTiposClientes.SelectedValue.ToString()),
                RangoFinal = int.Parse(txtRangoFinal.Text),
                RangoInicio = int.Parse(txtRangoInic.Text),

            };
            return DetallePrecios;
        }



        public void RefrescarDetallePrecios(DataGridView data, List<ListarDetallePrecios> lista)
        {

            BindingSource source = new BindingSource();

            source.DataSource = lista;
            data.DataSource = typeof(List<>);
            data.DataSource = source;
            data.AutoResizeColumns();
            data.Columns[0].Visible = false;
            data.Columns[1].Visible = false;

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
                _listacolores = new List<DetalleColor>();
            }
            if (checkColor.Checked == true)
            {

                if (Application.OpenForms["AgregarColorEdit"] == null)
                {
                    _listacolores = _detalleColor.GetProductoListaColor(_producto.Id);
                    AgregarColorEdit agregarColor = new AgregarColorEdit(this, _listacolores);
                    agregarColor.Show();
                }
                else { Application.OpenForms["AgregarColorEdit"].Activate(); }
            }
            else
            {
                _listacolores.Clear();
            }
        }


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
                    _listaTallas = _tallasRepository.GetTallaListaProducto(_producto.Id);
                    AgregarTallaEdit agregarTalla = new AgregarTallaEdit(this, _listaTallas);
                    agregarTalla.Show();
                }
                else { Application.OpenForms["AgregarTalla"].Activate(); }
            }
            else
            {
                _listaTallas.Clear();
            }
        }

        private void checkColor_CheckedChanged(object sender, EventArgs e)
        {
            checkcolorPropertis();
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

        private void lbLimpiar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checktalla_CheckedChanged(object sender, EventArgs e)
        {
            checktallaPropertis();
        }

        private void rdcolorytalla_CheckedChanged(object sender, EventArgs e)
        {

        }

        public bool comprobarEscala(DataGridView dataGrid, ListarDetallePrecios detallePrecio)
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

        private void btnAddPrecio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtprecioVar.Text) || decimal.Parse(txtprecioVar.Text) <= 0)
            {
                KryptonMessageBox.Show("Debe ingresar un Precio valido para continuar");
                return;
            }
            if (cbTiposClientes.Text == "Minorista")
            {
                var Detalle1 = GetDetallePreciosModel();
                if (!comprobarEscala(Dgvunitario, Detalle1))
                {

                    lista2.Add(Detalle1);
                    RefrescarDetallePrecios(Dgvunitario, lista2);
                }


            }
            if (cbTiposClientes.Text == "Mayorista")
            {
                var Detalle2 = GetDetallePreciosModel();
                if (!comprobarEscala(dgvmayorista, Detalle2))
                {
                    lista1.Add(Detalle2);
                    RefrescarDetallePrecios(dgvmayorista, lista1);
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

        public List<ListarDetallePrecios> CargarPrecios() {
            List<ListarDetallePrecios> listado = new List<ListarDetallePrecios>();
            ListarDetallePrecios ldp = null;
            //MAYORISTA
            foreach (DataGridViewRow dc in dgvmayorista.Rows)
            {
                ldp = new ListarDetallePrecios();
                ldp.TipoPrecioId = (System.Guid)dc.Cells[1].Value;
                ldp.Tipos = (string)dc.Cells[2].Value;
                ldp.Escala = (string)dc.Cells[3].Value;
                ldp.RangoInicio = (int)dc.Cells[4].Value;
                ldp.RangoFinal = (int)dc.Cells[5].Value;
                ldp.Precio = (decimal)dc.Cells[6].Value;
                ldp.TiposId = (int)dc.Cells[7].Value;
                listado.Add(ldp);
            }
            //MINORISTA
            foreach (DataGridViewRow dc in dgvcuentaclave.Rows)
            {
                ldp = new ListarDetallePrecios();
                ldp.TipoPrecioId = (System.Guid)dc.Cells[1].Value;
                ldp.Tipos = (string)dc.Cells[2].Value;
                ldp.Escala = (string)dc.Cells[3].Value;
                ldp.RangoInicio = (int)dc.Cells[4].Value;
                ldp.RangoFinal = (int)dc.Cells[5].Value;
                ldp.Precio = (decimal)dc.Cells[6].Value;
                ldp.TiposId = (int)dc.Cells[7].Value;
                listado.Add(ldp);
            }
            //CUENTA CLAVE
            foreach (DataGridViewRow dc in dgvcuentaclave.Rows)
            {
                ldp = new ListarDetallePrecios();
                ldp.TipoPrecioId = (System.Guid)dc.Cells[1].Value;
                ldp.Tipos = (string)dc.Cells[2].Value;
                ldp.Escala = (string)dc.Cells[3].Value;
                ldp.RangoInicio = (int)dc.Cells[4].Value;
                ldp.RangoFinal = (int)dc.Cells[5].Value;
                ldp.Precio = (decimal)dc.Cells[6].Value;
                ldp.TiposId = (int)dc.Cells[7].Value;
                listado.Add(ldp);
            }
            //REVENDEDOR
            foreach (DataGridViewRow dc in dgvrevendedor.Rows)
            {
                ldp = new ListarDetallePrecios();
                ldp.TipoPrecioId = (System.Guid)dc.Cells[1].Value;
                ldp.Tipos = (string)dc.Cells[2].Value;
                ldp.Escala = (string)dc.Cells[3].Value;
                ldp.RangoInicio = (int)dc.Cells[4].Value;
                ldp.RangoFinal = (int)dc.Cells[5].Value;
                ldp.Precio = (decimal)dc.Cells[6].Value;
                ldp.TiposId = (int)dc.Cells[7].Value;
                listado.Add(ldp);
            }
            //GUBERNAMENTAL
            foreach (DataGridViewRow dc in dgvgubernamental.Rows)
            {
                ldp = new ListarDetallePrecios();
                ldp.TipoPrecioId = (System.Guid)dc.Cells[1].Value;
                ldp.Tipos = (string)dc.Cells[2].Value;
                ldp.Escala = (string)dc.Cells[3].Value;
                ldp.RangoInicio = (int)dc.Cells[4].Value;
                ldp.RangoFinal = (int)dc.Cells[5].Value;
                ldp.Precio = (decimal)dc.Cells[6].Value;
                ldp.TiposId = (int)dc.Cells[7].Value;
                listado.Add(ldp);
            }
            return listado;
        }

    }

}
