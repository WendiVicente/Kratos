using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Productos;
using CapaDatos.Models.Recepciones;
using CapaDatos.Repository;
using CapaDatos.Repository.PreciosRepository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using POS;
using POS.Validations;
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
    public partial class SolicitudCompra : BaseContext
    {
        private ProveedoresRepository  _proveedoresRepository = null;
        private ProductosRepository _productosRepository = null;
        private ComprasRepository _comprasRepository = null;
        private RecepcionesRepository _recepcionesRepository = null;
        private PreciosDetallePepsRepository _preciosDetallePepsRepository = null;
        private CajasRepository _cajasRepository = null;
        private int sucursalid = UsuarioLogeadoSistemas.User.SucursalId;
        private string UsuarioLogeado = UsuarioLogeadoSistemas.User.Name;
        private IList<ListarProductos> _listaProductos = null;
        private decimal impuestoaplicar = 1.12M;
        private bool EstadoCompra = false;
       // private int EstadoRecepcion = 0;
        private int codcol = 0;
        private int descripcol = 1;
        private int costocol = 2;
        private int cantidadcol = 3;
        private int impuestocol = 4;
        private int baseimponilblecol = 5;
        private int subtotalcol = 6;
        private int idcol = 7;
        private decimal TotaldeCompra = 0.00M;
        public SolicitudCompra()
        {
            _cajasRepository = new CajasRepository(_context);
            _recepcionesRepository = new RecepcionesRepository(_context);
            _comprasRepository = new ComprasRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            _proveedoresRepository = new ProveedoresRepository(_context);
            _preciosDetallePepsRepository = new PreciosDetallePepsRepository(_context);
            InitializeComponent();
            ListaProductSelect.Columns[costocol].ReadOnly = false;
        }

        public ProductosRepository AccesoProductoRepository()
        {
            _context = null;
            _context = new Context();
            _productosRepository = null;
            _productosRepository = new ProductosRepository(_context);

            return _productosRepository;
        }

        private void SolicitudCompra_Load(object sender, EventArgs e)
        {
            cargarproveedores();
            Cargarfecha();
            _listaProductos = ProductosLoad();
          
        }
        private IList<ListarProductos> ProductosLoad()
        {
            var productosbd = _productosRepository.GetList(sucursalid);
            return productosbd;
        }
        private void cargarproveedores()
        {
            if (_proveedoresRepository.GetList() == null) return;
            cbproveedor.DataSource = _proveedoresRepository.GetList();
            if (cbproveedor.DataSource == null) { return; }
            cbproveedor.DisplayMember = "Nombre";
            cbproveedor.ValueMember = "Id";
          
            cbproveedor.Invalidate();
        }

        private void Cargarfecha()
        {
            lbsolicitud.Text = DateTime.Now.ToString() ;
        }

      
        public void CargarDataGridView(ListarProductos productoCapturado, bool comprobacion)
        {
            
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(ListaProductSelect);




            if (comprobacion)
            {
                foreach (DataGridViewRow r in ListaProductSelect.Rows)
                {
                    int cantidad = Convert.ToInt32(r.Cells[cantidadcol].Value);

                    if (r.Cells[codcol].Value.ToString() == productoCapturado.CodigoReferencia)
                    {

                            cantidad++;
                            r.Cells[cantidadcol].Value = cantidad;
                            r.Cells[subtotalcol].Value = Convert.ToDecimal(r.Cells[costocol].Value) * Convert.ToDecimal(r.Cells[cantidadcol].Value);
                        var baseimponible = ((Convert.ToDecimal(r.Cells[subtotalcol].Value) / impuestoaplicar)).ToString("0.00");
                        r.Cells[baseimponilblecol].Value = decimal.Parse(baseimponible);
                        var impuestoaplica = (Convert.ToDecimal(r.Cells[subtotalcol].Value) - Convert.ToDecimal(r.Cells[baseimponilblecol].Value)).ToString("0.00");
                        r.Cells[impuestocol].Value = decimal.Parse(impuestoaplica);
                        return;

                    }
                }
            }

            row.Cells[idcol].Value = productoCapturado.Id;
            row.Cells[codcol].Value = productoCapturado.CodigoReferencia;
            row.Cells[descripcol].Value = productoCapturado.Descripcion;
            row.Cells[costocol].Value = productoCapturado.Coste;
            row.Cells[cantidadcol].Value = 1;
            row.Cells[impuestocol].Value = impuestoaplicar;
            row.Cells[subtotalcol].Value = Convert.ToDecimal(row.Cells[cantidadcol].Value) * Convert.ToDecimal(row.Cells[costocol].Value);
            var baseimponib = ((Convert.ToDecimal(row.Cells[subtotalcol].Value) / impuestoaplicar)).ToString("0.00");
            row.Cells[baseimponilblecol].Value = decimal.Parse(baseimponib);
            var impuestoapli = (Convert.ToDecimal(row.Cells[subtotalcol].Value) - Convert.ToDecimal(row.Cells[baseimponilblecol].Value)).ToString("0.00");
            row.Cells[impuestocol].Value = decimal.Parse(impuestoapli);


            ListaProductSelect.Rows.Add(row);
            ListaProductSelect.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public List<CompraDetalleList> GetDatosDetallecompra()
        {
            var List = new List<CompraDetalleList>();

            foreach (DataGridViewRow item in ListaProductSelect.Rows)
            {
                if (item == null)
                {
                    continue;
                }

                CompraDetalleList compraDetalleU = new CompraDetalleList
                {
                    Id = int.Parse(item.Cells[idcol].Value.ToString()),
                    Referencia = item.Cells[codcol].Value.ToString(),
                    Descripcion = item.Cells[descripcol].Value.ToString(),
                    Precio = decimal.Parse(item.Cells[costocol].Value.ToString()),
                    Cantidad = int.Parse(item.Cells[cantidadcol].Value.ToString()),
                    BaseImponible= decimal.Parse(item.Cells[baseimponilblecol].Value.ToString()),
                    Impuesto = decimal.Parse(item.Cells[impuestocol].Value.ToString()),
                    Total = decimal.Parse(item.Cells[subtotalcol].Value.ToString())

                };

                List.Add(compraDetalleU);
            }

            return List;

        }

        private List<PreciosDetallePeps> GetprecioPeps(List<CompraDetalleList> listacostos)
        {
            var listapeps = new List<PreciosDetallePeps>();
           
            foreach (var item in listacostos)
            {
                var objpeps = new PreciosDetallePeps();
                objpeps.ProductoId = item.Id;
                objpeps.Coste = item.Precio;
                objpeps.FechaIngreso = DateTime.Now;
                objpeps.Cantidad = item.Cantidad;
                listapeps.Add(objpeps);

            }

            return listapeps;
        }

      
        private void GuardarCompra()
        {
            TotaldeCompra = decimal.Parse(lbtotal.Text);

            try
            {
                var encabezadoCompra = GetCompra(); // encabezado
                var detalleCompra = GetDatosDetallecompra();// detalle de compra
                var RecepcionCompra = GetmodelRecepcion();// recepcion
               // var detalleEnviar = getModeldetalleCaja();
                var pepsprecios = GetprecioPeps(detalleCompra);
                if (!ModelState.IsValid(encabezadoCompra)) return;
                if (!ModelState.IsValid(detalleCompra)) return;
                if (!ModelState.IsValid(RecepcionCompra)) return;
              //  if (!ModelState.IsValid(detalleEnviar)) { return; }
                if (!ModelState.IsValid(pepsprecios)) { return; }
                // bloque de caja  validacion si se presiono el boton confirmar
                // Confirmar envia detalle a caja abierta
                //if (EstadoCompra)
                //{
                //    if (_cajasRepository.GetCajaAperturada(sucursalid) == null)
                //    { KryptonMessageBox.Show("No hay ninguna Caja Aperturada para esta sucursal");
                //        return; 
                //    }
                //}             



                var idGuidCompra = encabezadoCompra.Id; // obtengo el guid de compra
                var idestadoobtenido = ObtenerIdEstado("Preparado");
                RecepcionCompra.EstadoRecepcionId = idestadoobtenido;
                _comprasRepository.AddEncabezado(encabezadoCompra);
                 RecepcionCompra.CompraId = encabezadoCompra.Id; //captura el guid del encabezado

                if (EstadoCompra) { 
                    _recepcionesRepository.AddRecepcion(RecepcionCompra);
                   // var CajasAperturadas = _cajasRepository.GetCajaAperturada(sucursalid); // validar caja
                   // detalleEnviar.CajaId = CajasAperturadas.Id;
                   // detalleEnviar.Egreso = TotaldeCompra;
                   // detalleEnviar.CompraId = idGuidCompra;
                   // _cajasRepository.AddDetalleCaja(detalleEnviar, true);
                }
               

                    foreach (var item in detalleCompra)
                {
                   var producto = _productosRepository.Get(item.Id);
                    var detalle = new DetalleCompra()
                    {
                        CompraId=encabezadoCompra.Id,
                        ProductoId = producto.Id,
                        Cantidad = item.Cantidad,
                        Precio = item.Precio,
                       BaseImponible= item.BaseImponible,
                       Impuesto = item.Impuesto,
                        PrecioTotal = item.Total
                    };


                    _comprasRepository.Add(detalle);
                    _context.SaveChanges();
                }

                foreach (var item in pepsprecios)
                {
                    _preciosDetallePepsRepository.Add(item);
                }





                KryptonMessageBox.Show("Compra Registrada con exito");
              //  EstadoRecepcion = 0;
                EstadoCompra = false;
                LimpiarCampos();
                Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public Compra GetCompra()
        {
            return new Compra()
            {
                
                Id = Guid.NewGuid(),
                SucursalId = sucursalid,
                ProveedorId = int.Parse(cbproveedor.SelectedValue.ToString()),
                NombreVendedor = UsuarioLogeado,
                NoComprobante = txtcomprobante.Text,
                FechaRecepcion = DateTime.Now,
                FechaLimite = dtpEntrega.Value,
                Estado = EstadoCompra
                
                
        };
        }


        public Recepcion GetmodelRecepcion()
        {
            return new Recepcion()
            {

               // Id = Guid.NewGuid(),
                SucursalId = sucursalid,
             //   EstadoRecepcionId=EstadoRecepcion
                

        };
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
        private PreciosDetallePeps GetmodelPreciosPeps()
        {
            var preciospeps = new PreciosDetallePeps()
            {
                
                //Coste = costetxt.Text == null ? 0.00M : decimal.Parse(txtprecioVar.Text),
                //Cantidad = stockproducto.Text == null ? 0 : int.Parse(stockproducto.Text),
                //FechaIngreso = DateTime.Now,
                
            };
            return preciospeps;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (ListaProductSelect.Rows.Count == 0)
            {
                KryptonMessageBox.Show("Debe ingresar productos");
                return;
            }
           
            EstadoCompra = false;
            GuardarCompra();
            
        }

        private void btnConfirmarPed_Click(object sender, EventArgs e)
        {
            if (ListaProductSelect.Rows.Count == 0)
            {
                KryptonMessageBox.Show("Debe ingresar productos");
                return;
            }
           
            EstadoCompra = true;
            //EstadoRecepcion = 8;
            GuardarCompra();
        }

        public void ActualizarLabelTotal()
        {
            decimal actualizarTotal = 0.00M;
            decimal impuesto = 1.12M;
            
            foreach(DataGridViewRow fila in ListaProductSelect.Rows)
            {
                if (fila.Cells[subtotalcol].Value != null)
                    actualizarTotal += (decimal)fila.Cells[subtotalcol].Value;
            }
            lbtotal.Text = actualizarTotal.ToString();
             decimal subtotal = actualizarTotal / impuesto;
            lbsubt.Text = subtotal.ToString("0.00");
            lbimpuesto.Text = (actualizarTotal - subtotal).ToString("0.00");


        }

        private void ListaProductSelect_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ActualizarLabelTotal();
        }

        private void ListaProductSelect_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ActualizarLabelTotal();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnagregarproducto_Click_1(object sender, EventArgs e)
        {
           
           // AddProductoComp childForm = new AddProductoComp(this);

           // childForm.Show();
        }
        private void LimpiarCampos()
        {
            txtcomprobante.Text = "";
            lbimpuesto.Text = "";
            lbsolicitud.Text = "";
            lbsubt.Text = "";
            lbtotal.Text = "";
            ListaProductSelect.DataSource = null;
        }

        private void btnCantidad_Click(object sender, EventArgs e)
        {
            

            if (ListaProductSelect.CurrentRow is null)
            {
                KryptonMessageBox.Show("No hay ningún producto seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            List<string> ProductoSelected = new List<string>();

            foreach (DataGridViewCell item in ListaProductSelect.CurrentRow.Cells)
            {

                ProductoSelected.Add(item.Value.ToString());

            }

            // var prueba = ListaProductSelect.CurrentRow.Cells; // probemos a ver si no cae null o vacio a ver que pedo

            //var cantidadcambio = new CambiarCantidad(ProductoSelected, ListaProductSelect.CurrentRow.Cells, this); // current row en espanol => fila actual
            //cantidadcambio.Show();
        }

        private int ObtenerIdEstado(string EstadoBuscado)
        {
            var estadoRecepcion = _recepcionesRepository.ObtenerEstadoId(EstadoBuscado);
            var id = estadoRecepcion.Id;
            return id;
        }

        private void txtbuscar_KeyUp(object sender, KeyEventArgs e)
        {
            //int ab= 0;
            //string codigoReferencia = txtbuscar.Text.Trim();
            //if (codigoReferencia.Length > 0 && codigoReferencia != null)
            //{
            //    ab = Convert.ToInt32(codigoReferencia);
            //}

            //var sproducto = _listaProductos.Where(x => x.Id == ab).FirstOrDefault();
            //// var comprobarEnTabla = new ComprobarExistenciaEnTabla(ListaProductSelect);

            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (sproducto == null) return;


            //    // var detallefactura = GetDetalleFactura();

            //          var comprobarEnTabla = new ComprobarExistenciaEnTabla(ListaProductSelect);
            //    CargarDataGridView(sproducto, comprobarEnTabla.ComprobarProductoRepetidoFila(sproducto));


            //}

            var codigoReferencia = txtbuscar.Text.Trim();
            var sproducto = _listaProductos.Where(x => x.CodigoReferencia == codigoReferencia).FirstOrDefault();
            // var comprobarEnTabla = new ComprobarExistenciaEnTabla(ListaProductSelect);

            if (e.KeyCode == Keys.Enter)
            {
                if (sproducto == null) return;


                // var detallefactura = GetDetalleFactura();

                var comprobarEnTabla = new ComprobarExistenciaEnTabla(ListaProductSelect);
                CargarDataGridView(sproducto, comprobarEnTabla.ComprobarProductoRepetidoFila(sproducto));


            }

        }
        private void OperacionPorFila()
        {
            try
            {
                decimal impuestod = 1.12M;
                var filaActual = (CompraDetalleList)ListaProductSelect.CurrentRow.DataBoundItem;
                var subtotal = filaActual.Cantidad * filaActual.Precio;
                var baseimponib = subtotal / impuestod;
                var impuestoaplica = subtotal - baseimponib;
                filaActual.BaseImponible = baseimponib;
                filaActual.Total = impuestoaplica;
            }
            catch (Exception es)
            {

                KryptonMessageBox.Show(es.Message);
            }
          
            



            /*
             * var baseimponib = ((Convert.ToDecimal(row.Cells[subtotalcol].Value) / impuestoaplicar)).ToString("0.00");
            row.Cells[baseimponilblecol].Value = decimal.Parse(baseimponib);
            var impuestoapli = (Convert.ToDecimal(row.Cells[subtotalcol].Value) - Convert.ToDecimal(row.Cells[baseimponilblecol].Value)).ToString("0.00");
            row.Cells[impuestocol].Value = decimal.Parse(impuestoapli); 
             * 
             * */




        }
        private void txtbuscar_Enter(object sender, EventArgs e)
        {

        }

        private void ListaProductSelect_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int cantidad = 0;
            decimal precio = 0.00m;
            decimal precioTotal = 0.00M;
            try

            {
                // if (ListaProductSelect.Columns[e.ColumnIndex].Index == preciocol)
                //  {
                    cantidad = int.Parse(ListaProductSelect.Rows[e.RowIndex].Cells[cantidadcol].Value.ToString());
                    precio = decimal.Parse(ListaProductSelect.Rows[e.RowIndex].Cells[costocol].Value.ToString());
                    precioTotal = cantidad * precio;
                    var baseimponib = ((Convert.ToDecimal(ListaProductSelect.Rows[e.RowIndex].Cells[subtotalcol].Value) / impuestoaplicar)).ToString("0.00");
                    ListaProductSelect.Rows[e.RowIndex].Cells[baseimponilblecol].Value = decimal.Parse(baseimponib);
                    var impuestoapli = (Convert.ToDecimal(ListaProductSelect.Rows[e.RowIndex].Cells[subtotalcol].Value) - Convert.ToDecimal(ListaProductSelect.Rows[e.RowIndex].Cells[baseimponilblecol].Value)).ToString("0.00");
                    ListaProductSelect.Rows[e.RowIndex].Cells[impuestocol].Value = decimal.Parse(impuestoapli);



                    ListaProductSelect.Rows[e.RowIndex].Cells[subtotalcol].Value = precioTotal;
                ActualizarLabelTotal();
              //  }
            }
            catch (Exception ex)
            {

                KryptonMessageBox.Show(ex.Message);
            }
          

           // OperacionPorFila();
        }
    }
}
