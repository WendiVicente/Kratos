using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Recepciones;
using CapaDatos.Repository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models.Caja;
using sharedDatabase.Models.Compras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_compras
{
    public partial class EditarSolicitud : BaseContext
    {
        private Compra _CompraObtenida = null;
        private ProveedoresRepository _proveedoresRepository = null;
        private ComprasRepository _comprasRepository = null;
        private ProductosRepository _productosRepository = null;
        private RecepcionesRepository _recepcionesRepository =null;
        private readonly VerCompras _verCompras = null;
        private readonly CajasRepository _cajasRepository = null;
        private int sucursallogeada = UsuarioLogeadoSistemas.User.SucursalId;
        public int sucursalId = 0;
        private int EstadoRecepcion = 0;
        private int codDetalle = 0;
       // private int codcol = 1;
      // private int descripcol = 2;
        private int coste = 3;
        private int cantidadcol = 4;
        private int impuestocol = 5;
        private int baseimponilblecol = 6;
        private int subtotalcol = 7;
        private int idproductocol = 8;
        
        public List<CompraDetalleList> detalleListsObtenida = null;
        public EditarSolicitud(Compra compra, VerCompras compras)
        {
            _verCompras = compras;
               _productosRepository = new ProductosRepository(_context);
            _proveedoresRepository = new ProveedoresRepository(_context);
            _comprasRepository = new ComprasRepository(_context);
            _recepcionesRepository = new RecepcionesRepository(_context);
            _cajasRepository = new CajasRepository(_context);
            _CompraObtenida = compra;
            //this.lbcomprobante.Text = compra.NoComprobante;
            InitializeComponent();
            cargarDatos();
            CargarProveedor();
            CargarDg(true);
            CargarPueba();

        }


        public ProductosRepository AccesoProductoRepository()
        {
            _context = null;
            _context = new Context();
            _productosRepository = null;
            _productosRepository = new ProductosRepository(_context);
          //  _recepcionesRepository = new RecepcionesRepository(_context);

            return _productosRepository;
        }

        private void cargarDatos()
        {
            sucursalId =int.Parse(_CompraObtenida.SucursalId.ToString());
            txtcomprobante.Text = _CompraObtenida.NoComprobante;
            lbFechasolicitud.Text = _CompraObtenida.FechaRecepcion.ToString();
            dtpEntrega.Value = _CompraObtenida.FechaLimite;
            
            if (_CompraObtenida.Estado) 
            { 
                lbestado.Text = "Comprado"; 
            }else { lbestado.Text = "Petición"; }




        }


        private void CargarProveedor()
        {

            cbproveedor.DataSource = _proveedoresRepository.GetList();
            cbproveedor.DisplayMember = "Nombre";
            cbproveedor.ValueMember = "Id";
            cbproveedor.SelectedValue = _CompraObtenida.ProveedorId;
            cbproveedor.Invalidate();


        }

       
       


        private void EditarSolicitud_Load(object sender, EventArgs e)
        {

        }

        //cambios en Compra
        public Compra GetCompraModel(Compra compra)
        {

            compra.ProveedorId = int.Parse(cbproveedor.SelectedValue.ToString());
            compra.NoComprobante = txtcomprobante.Text;
            compra.FechaLimite = dtpEntrega.Value;
            // compra.Estado = 
            return compra;
        }
        private DetalleCaja getModeldetalleCaja()
        {
            return new DetalleCaja()
            {
                // CajaId = CajasAperturadas.Id,
                Descripcion = "Monto Egresado Compras",
                //Egreso = TotaldeCompra,
                //CajaId = sucursalid,


            };

        }





        // cambios en detalles



        private void  ActualizarDetalles()
        {


          
            foreach (DataGridViewRow item in ListaProductSelect.Rows) 
            {
                if (item == null)
                {
                    continue;
                }
               
                if (_comprasRepository.Getdetalle(int.Parse(item.Cells[codDetalle].Value.ToString())) != null)
                {

                    var compras = _comprasRepository.Getdetalle(int.Parse(item.Cells[codDetalle].Value.ToString()));
                    compras.ProductoId = int.Parse(item.Cells[idproductocol].Value.ToString());
                    compras.Precio = decimal.Parse(item.Cells[coste].Value.ToString());
                    compras.Cantidad = int.Parse(item.Cells[cantidadcol].Value.ToString());
                    compras.PrecioTotal = decimal.Parse(item.Cells[subtotalcol].Value.ToString());
                    compras.Impuesto = decimal.Parse(item.Cells[impuestocol].Value.ToString());
                    compras.BaseImponible = decimal.Parse(item.Cells[baseimponilblecol].Value.ToString());
                    _comprasRepository.UpdateDetalleCompra(compras, true);
                   
                }
                else
                {
                    DetalleCompra nuevodetalle = new DetalleCompra()
                    {
                        CompraId = _CompraObtenida.Id,
                        ProductoId = int.Parse(item.Cells[idproductocol].Value.ToString()),
                        Cantidad = int.Parse(item.Cells[cantidadcol].Value.ToString()),
                        Precio = decimal.Parse(item.Cells[coste].Value.ToString()),
                        PrecioTotal = decimal.Parse(item.Cells[subtotalcol].Value.ToString()),
                        Impuesto = decimal.Parse(item.Cells[impuestocol].Value.ToString()),
                        BaseImponible = decimal.Parse(item.Cells[baseimponilblecol].Value.ToString()),
                        


                };
                    _comprasRepository.Add(nuevodetalle);

                }

            }
            

        }



            private void ActualizarCambios()
        {
            try
            {
                if(_recepcionesRepository.Get(_CompraObtenida.Id) != null)
                {
                    var ValidarEstadoRecepcion = _recepcionesRepository.Get(_CompraObtenida.Id);

                    if (ValidarEstadoRecepcion.EstadoRecepcionId == ObtenerIdEstado("Hecho"))
                    {
                        KryptonMessageBox.Show("La Recepcion de Esta Solicitud ya afecto el inventario!\n" +
                                                "Deberá crear una nueva solicitud!");
                        return;
                    }
                }
                // bloque de detalle caja
                //if (_CompraObtenida.Estado)
                //{
                //    var cajaObtenida = validarAperturaCaja();
                //    if (cajaObtenida == 0)
                //    {// valido existencia de idcaja en bd
                //        KryptonMessageBox.Show("No hay ninguna caja aperturada " +
                //                               ",\n deberá aperturar una nueva caja"); return;
                //    }

                //    //valido la existencia de compraid en detalle caja
                //    if (_cajasRepository.GetDetalleCajaEditar(cajaObtenida, _CompraObtenida.Id) == null)
                //    {// valido existencia de idcaja en bd
                //        KryptonMessageBox.Show("La caja Origen de esta Solicitud " +
                //                               " ya fue cerrada,\n deberá crear una nueva Solicidad"); return;
                //    }

                //    var detalleObtenido = _cajasRepository.GetDetalleCajaEditar(cajaObtenida, _CompraObtenida.Id, true);
                //    detalleObtenido.Egreso = decimal.Parse(lbtotal.Text);
                //    _cajasRepository.UpdateDetalleCaja(detalleObtenido);
                //}
               


                
                var editarCompra = _comprasRepository.Get(_CompraObtenida.Id);
                var encabezadoCompra = GetCompraModel(editarCompra); // encabezado
                if (!ModelState.IsValid(encabezadoCompra)) { return; }
            

                ActualizarDetalles();
                _comprasRepository.Update(encabezadoCompra);
                _verCompras.RefrescarDataGridCompras(true);

                KryptonMessageBox.Show("Registro actualizado correctamente");

                   Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       

        private void btnagregarproducto_Click_1(object sender, EventArgs e)
        {
            AgregarMasProductos childForm = new AgregarMasProductos(this);

            childForm.Show();
        }
        private void btnguardar_Click(object sender, EventArgs e)
        {
            ActualizarCambios();
        }

        
        public void CargarDg(bool loadNewContext = true)
        {
            
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _comprasRepository = null;
                _comprasRepository = new ComprasRepository(_context);
            }

            BindingSource source = new BindingSource();
             detalleListsObtenida = _comprasRepository.GetListDetalleCompra(_CompraObtenida.Id);
            source.DataSource = detalleListsObtenida;
            ListaProductSelect.DataSource = typeof(List<>);
            ListaProductSelect.DataSource = source;
            ListaProductSelect.AutoResizeColumns();
            ListaProductSelect.Columns[codDetalle].Visible = false;
            ListaProductSelect.Columns[idproductocol].Visible = false;
            var suma = detalleListsObtenida.Sum(a => a.Total);
            lbtotal.Text = suma.ToString();
            
           
        }
        //---------------------
        public void CargarPueba()
        {

            BindingSource source = new BindingSource();
            source.DataSource = detalleListsObtenida;
            ListaProductSelect.DataSource = typeof(List<>);
            ListaProductSelect.DataSource = source;
            ListaProductSelect.AutoResizeColumns();
            ListaProductSelect.Columns[codDetalle].Visible = false;
            ListaProductSelect.Columns[idproductocol].Visible = false;
            //ListaProductSelect.Rows[1].Selected = true;


        }
        

        private void btnvalidar_Click(object sender, EventArgs e)
        {
            var totaldeCompra = decimal.Parse(lbtotal.Text);
            var estadoAcambiar = "Preparado";
            if (_CompraObtenida.Estado == true) { KryptonMessageBox.Show("Esta Solicitud ya esta en Recepcion,");return; }
            var estadoObtenido = _recepcionesRepository.ObtenerEstadoId(estadoAcambiar);

                EstadoRecepcion = estadoObtenido.Id;
                var RecepcionCompra = GetmodelRecepcion();// recepcion
                var detalleEnviar = getModeldetalleCaja(); //obtengo mi modelo de detalle caja

            if (!ModelState.IsValid(RecepcionCompra)) return;
            if (!ModelState.IsValid(detalleEnviar)) { return; }// valido modelo utilizado

            if (validarAperturaCaja()==0)
            {
                KryptonMessageBox.Show("La Caja  ya no esta abierta, debera crear otra solicitud");
                return;
            }

            _recepcionesRepository.AddRecepcion(RecepcionCompra);
                 var compraObtenida = _comprasRepository.Get(_CompraObtenida.Id);
                     compraObtenida.Estado = true;
                     _comprasRepository.Update(compraObtenida); //actualizacion

            
                
                var CajasAperturadas = validarAperturaCaja(); // validar caja
                detalleEnviar.CajaId = CajasAperturadas;
                detalleEnviar.Egreso = totaldeCompra;
                detalleEnviar.CompraId = _CompraObtenida.Id;
                _cajasRepository.AddDetalleCaja(detalleEnviar);
            



            // cambio de estado y cierre 
            EstadoRecepcion = 0;
            _verCompras.RefrescarDataGridCompras(true);
            Close();
        }

        public Recepcion GetmodelRecepcion()
        {
            return new Recepcion()
            {

                CompraId = _CompraObtenida.Id,
                SucursalId = _CompraObtenida.SucursalId.Value,
                EstadoRecepcionId = EstadoRecepcion


            };
        }
        private int ObtenerIdEstado(string EstadoBuscado)
        {
            var estadoRecepcion = _recepcionesRepository.ObtenerEstadoId(EstadoBuscado);
            var id = estadoRecepcion.Id;
            return id;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }



        public void ActualizarLabelTotal()
        {
            decimal actualizarTotal = 0.00M;
            decimal impuesto = 1.12M;

            foreach (DataGridViewRow fila in ListaProductSelect.Rows)
            {
                if (fila.Cells[subtotalcol].Value != null)
                    actualizarTotal += (decimal)fila.Cells[subtotalcol].Value;
            }
            lbbaseimponible.Text = actualizarTotal.ToString();
            decimal subtotal = actualizarTotal / impuesto;
            lbbaseimponible.Text = subtotal.ToString("0.00");
            lbimpuesto.Text = (actualizarTotal - subtotal).ToString("0.00");
            var suma = detalleListsObtenida.Sum(a => a.Total);
            lbtotal.Text = suma.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ListaProductSelect_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
           


        }

        private void ListaProductSelect_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ActualizarLabelTotal();
        }

        private void btnaddmore_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(ListaProductSelect.CurrentRow.Index.ToString());
            if (ListaProductSelect.CurrentRow is null)
            {
               
                KryptonMessageBox.Show("No tiene ningún producto seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            List<string> ProductoSelected = new List<string>();

            foreach (DataGridViewCell item in ListaProductSelect.CurrentRow.Cells)
            {

                ProductoSelected.Add(item.Value.ToString());

            }

            // var prueba = ListaProductSelect.CurrentRow.Cells; // probemos a ver si no cae null o vacio a ver que pedo

            var agregarMasProductos = new CantidadEditar(ProductoSelected, ListaProductSelect.CurrentRow.Cells, this); // current row en espanol => fila actual
            agregarMasProductos.Show();
        }

        private void eliminarFila()
        {
            if (ListaProductSelect.CurrentRow == null)
            {
                return;
            }

            var dialog = KryptonMessageBox.Show("¿Éste Producto sera Eliminado de la Solicitud,Desea continuar?", "Eliminar producto",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);


            if (dialog == DialogResult.Yes)
            {
                var rowSeleccionada = (CompraDetalleList)ListaProductSelect.CurrentRow.DataBoundItem;
                var codigoFila = rowSeleccionada.Id;
                if (codigoFila != 0)
                {
                    detalleListsObtenida.RemoveAll(x => x.Id == codigoFila);
                    _comprasRepository.DeleteProductoDetalle(_comprasRepository.Getdetalle(codigoFila));

                }
                else
                {
                    detalleListsObtenida.RemoveAll(x => x.Id == codigoFila);
                }

                CargarPueba();



            }
        }

        private void ListaProductSelect_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
           
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if(_recepcionesRepository.Get(_CompraObtenida.Id) != null)
                {
                    var ValidarEstadoRecepcion = _recepcionesRepository.Get(_CompraObtenida.Id);

                    if (ValidarEstadoRecepcion.EstadoRecepcionId == ObtenerIdEstado("Hecho"))
                    {
                        KryptonMessageBox.Show("La Recepcion de Esta Solicitud ya afecto el inventario!\n" +
                                                "Deberá crear una nueva solicitud!");
                        return;
                    }
                }
            eliminarFila();
            ActualizarLabelTotal();
        }

        private int validarAperturaCaja()
        {
           
            if (_cajasRepository.GetCajaAperturada(int.Parse(_CompraObtenida.SucursalId.ToString())) != null) {
                var cajaobten = _cajasRepository.GetCajaAperturada(int.Parse(_CompraObtenida.SucursalId.ToString()));
                return cajaobten.Id;

              
            }
            else { return 0; }



        }

        private void ListaProductSelect_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
    }
