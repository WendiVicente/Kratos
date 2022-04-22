using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Productos;
using CapaDatos.Models.Vales;
using CapaDatos.Repository;
using CapaDatos.Repository.PreciosRepository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_vales
{
    public partial class NuevoVale : BaseContext
    {
        private ProductosRepository _productosRepository = null;
        private ValesRepository _valesRepository = null;
        private ClientesRepository _clientesRepository = null;
        private CombosRepository _combosRepository = null;
        private TipoPrecioRepository _tipoPrecioRepository = null;
        private TallasRepository _tallasRepository = null;
        private ColoresRepository _coloresRepository = null;
        private TallasyColoresRepository _tallasyColoresRepository = null;
        private Cliente _clienteActual = null;

        private int codDetalle = 0, comboidcol = 1,  productidCol=2,  preciocol = 7,cantidadcol = 8, subtotalcol = 9;
        private int coloridCol = 10, tallaidCol = 11;

        private int colAcciones = 14;
        int colAccionesProd = 28;
        int cuentaclacol = 10;
        int gubernacol = 9;
        int reventacol = 11;
        int minoristacol = 8;
        int mayoristacol = 7;
        
        //columnas del dgv talla y color
        int IDTyCcol = 0;
        int productIDTyCcol = 1;
        int stockTyCcol = 2;
        int colorTyCcol = 3;
        int tallaTyCcol = 3;
        int colAccionesTyC = 5;

        private IList<ListarProductos> listaProductos = null;
        private IList<ListarProductos> listaProdRebaja = null;
        private IList<ListarCombos> combos = null;
        private List<ListarDetalleVales> _listaDetalleToVale = null;
        private ListarVales _vale = null;
        private List<Producto> ListaFilasenDGV = null;
        private List<Producto> ListaFilaRebajas = null;
        private List<Cliente> clienteslist = new List<Cliente>();
        private List<int> Novaleslist = new List<int>();


        public NuevoVale(ListarVales valeRecibido)
        {
            _vale = valeRecibido;
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            _tipoPrecioRepository = new TipoPrecioRepository(_context);
            _clientesRepository = new ClientesRepository(_context);
            _combosRepository = new CombosRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            _valesRepository = new ValesRepository(_context);
            _tallasRepository = new TallasRepository(_context);
            _coloresRepository = new ColoresRepository(_context);
            listaProductos = new List<ListarProductos>();
            listaProdRebaja = new List<ListarProductos>();
            _listaDetalleToVale = new List<ListarDetalleVales>();
            _tallasyColoresRepository = new TallasyColoresRepository(_context);
            // _listaDetallefromCombo = new List<ListarDetalleVales>();
            // InitializeComponent();

        }
       

        private void NuevoVale_Load(object sender, EventArgs e)
        {
            ListaFilasenDGV = new List<Producto>();
            ListaFilaRebajas = new List<Producto>();
            lbdocorigen.Text = _vale.Id.ToString();
            lbtipoPrecio.Text = _vale.Tipo;
            TraerAsignacion();
            RefrescarDataGridProductos();
            CargarDgvCombos();
           
        } 


        private void TraerAsignacion()
        {
            var Asignacionlist = _valesRepository.GetAsignacionVale(_vale.Id);
            if (Asignacionlist == null) { return; }
          

            foreach (var item in Asignacionlist)
            {
                if (item.ClienteId != null)
                {
                    var clienteobtenido = _clientesRepository.Get((int)item.ClienteId);
                    clienteslist.Add(clienteobtenido);
                }
                if (item.NoVale != 0)
                {
                    Novaleslist.Add(item.NoVale);
                }
               
            }

            cargarClientesVale(clienteslist, Novaleslist);
        }

        private void cargarClientesVale(List<Cliente> listaclientes, List<int>numbervale)
        {
            if (listaclientes.Count>0)
            {
                comboClientes.DataSource = listaclientes;
                comboClientes.ValueMember = "Id";
                comboClientes.DisplayMember = "Nombres";
            }
            if (numbervale.Count > 0)
            {
                comboClientes.DataSource = numbervale;
            }
        }
        private void cargarAsignacionTextbox(int id)
        {
            if (clienteslist.Count > 0)
            {
                var valeobtenido = _valesRepository.GetAsinacionPorCliente(id, _vale.Id);
                if (valeobtenido == null) { return; }
                lbnoVale.Text = valeobtenido.Id.ToString();
                lbfecha.Text = valeobtenido.FechaAsignacion.ToString();
                txtfechacambio.Text = valeobtenido.FechaCambio.ToString();
                txtestado.Text = valeobtenido.Estado;
                txtMonto.Text = valeobtenido.Monto.ToString();
                txtreciduo.Text = valeobtenido.Reciduo.ToString();
            }
            else if(Novaleslist.Count>0)
            {
               
                    var valeobtenido = _valesRepository.GetAsinacionPorNumero(id, _vale.Id);
                if (valeobtenido == null) { return; }
                lbnoVale.Text = valeobtenido.Id.ToString();
                lbfecha.Text = valeobtenido.FechaAsignacion.ToString();
                txtfechacambio.Text = valeobtenido.FechaCambio.ToString();
                txtestado.Text = valeobtenido.Estado;
                txtMonto.Text = valeobtenido.Monto.ToString();
                txtreciduo.Text = valeobtenido.Reciduo.ToString();
                txtnombre.Text = valeobtenido.Nombre;
                txtapellido.Text = valeobtenido.Apellido;
                txtnit.Text = valeobtenido.Nit;
                txttelefono.Text = valeobtenido.Telefono;


            }
            
            


        }
        private void cargarTxtenBlanco()
        {
            
            cargarAsignacionTextbox(int.Parse(comboClientes.SelectedValue.ToString()));
        }

        private void cargarTxtCliente()
        {
            if (comboClientes.SelectedValue is Cliente) return;
            var clienteSeleccionado = int.Parse(comboClientes.SelectedValue.ToString());
            var clienteOptenido = _clientesRepository.Get(clienteSeleccionado); 
            if (clienteOptenido == null) return;
            _clienteActual = clienteOptenido;
            txtcodigoclient.Text = clienteOptenido.CodigoCliente;
            txttelefono.Text = clienteOptenido.Telefonos;
            txtnit.Text = clienteOptenido.Nit;
            lbdirec.Text = clienteOptenido.Direccion;
            txtnombre.Text = clienteOptenido.Nombres;
            txtapellido.Text = clienteOptenido.Apellidos;
            cargarAsignacionTextbox(clienteOptenido.Id);

        }
        private void comboclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clienteslist.Count > 0)
            {
                cargarTxtCliente();
            }
            if (Novaleslist.Count > 0)
            {
                cargarTxtenBlanco();
            }

            dgvPedido.DataSource = null;
           // dgvToDiscount.DataSource = null;
            ListaFilasenDGV.Clear();
            ListaFilaRebajas.Clear();
            _listaDetalleToVale.Clear();
            //_listaDetallefromCombo.Clear();
    }



        //  public void RefrescarDataGridProductos(DataGridView datagridview, IList<ListarProductos> lista, bool loadNewContext = true)
        public void RefrescarDataGridProductos( bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _productosRepository = null;
                _productosRepository = new ProductosRepository(_context);
            }
            BindingSource source = new BindingSource();
            listaProductos = _productosRepository.GetList(UsuarioLogeadoSistemas.User.SucursalId);
            source.DataSource = listaProductos;
            dgvProductos.DataSource = typeof(List<>);
            dgvProductos.DataSource = source;

            for (int i = 0; i < 28; i++)
            {
                dgvProductos.Columns[i].Visible = false;
            }
            dgvProductos.Columns[1].Visible = true;
            dgvProductos.Columns[3].Visible = true;
            dgvProductos.Columns[27].Visible = false;
            dgvProductos.Columns[28].Visible = true;

            //dgvProductos.AutoResizeColumns();
        }

        public void CargarDgvCombos(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _combosRepository = null;
                _combosRepository = new CombosRepository(_context);
            }

            BindingSource source = new BindingSource();
            combos = _combosRepository.GetListarCombos(UsuarioLogeadoSistemas.User.SucursalId);
            source.DataSource = combos;
            dgvCombos.DataSource = typeof(List<>);

            dgvCombos.DataSource = source;
            dgvCombos.AutoResizeColumns();
            for (int i = 0; i < 15; i++)
            {
                dgvCombos.Columns[i].Visible = false;
            }
            dgvCombos.Columns[2].Visible = true;
            dgvCombos.Columns[3].Visible = true;
            dgvCombos.Columns[4].Visible = true;
            dgvCombos.Columns[6].Visible = true;
            dgvCombos.Columns[colAcciones].Visible = true;

        }


        private void CheckedAll( )
        {
            foreach (DataGridViewRow Rows in dgvProductos.Rows)
            {
                bool acciones = Convert.ToBoolean(Rows.Cells[28].Value);
                if (!acciones)
                {
                    Rows.Cells[28].Value = true;
                }
                else
                {
                    Rows.Cells[28].Value = false;
                }
            }

        }
        private void CheckedCombos()
        {
            foreach (DataGridViewRow Rows in dgvCombos.Rows)
            {
                bool acciones = Convert.ToBoolean(Rows.Cells[colAcciones].Value);
                if (!acciones)
                {
                    Rows.Cells[colAcciones].Value = true;
                }
                else
                {
                    Rows.Cells[colAcciones].Value = false;
                }
            }

        }


       

     

       private void AgregarlistaToDgv(DataGridView datagrid, List<ListarDetalleVales> listaT, List<Producto> listaProducto)
      
        {

            foreach (var item in listaProducto)
            {

                var detalleVales = GetlistaDetalle();
                detalleVales.ProductoId = item.Id;
                detalleVales.Descripcion = item.Descripcion;
                detalleVales.ValesId = Guid.Parse(lbnoVale.Text);
                detalleVales.Cantidad = 1;
                detalleVales.Color = comboColores.Text;
                detalleVales.Talla = combotallas.Text;
                if (comboColores.Items.Count > 0)
                {
                    detalleVales.DetalleColorId = int.Parse(comboColores.SelectedValue.ToString());
                }
                if (combotallas.Items.Count > 0)
                {
                    detalleVales.DetalleTallaId = int.Parse(combotallas.SelectedValue.ToString());
                }
               
                
                if (item.TieneEscalas == false)
                { 
                    if(_vale.Tipo== "Mayorista")
                    {
                        detalleVales.Precio = item.PrecioMayorista;
                       
                    }
                    if(_vale.Tipo== "Minorista")
                    {
                        detalleVales.Precio = item.PrecioVenta;
                        
                    }
                    if (_vale.Tipo == "Cuenta Clave")
                    {
                        detalleVales.Precio = item.PrecioCuentaClave;
                        
                    }
                    if (_vale.Tipo == "Revendedor")
                    {
                        detalleVales.Precio = item.PrecioRevendedor;
                        
                    }
                    if (_vale.Tipo == "Gubernamental")
                    {
                        detalleVales.Precio = item.PrecioEntidadGubernamental;
                       
                    }
                    detalleVales.Total = detalleVales.Precio * detalleVales.Cantidad;
                }
                else
                {
                    var TipoPrecio = _tipoPrecioRepository.Get(item.Id);
                    var detallePrecios = _tipoPrecioRepository.GetDetallePrecio(TipoPrecio.Id, _vale.TipoPrecio);
                    if (detallePrecios == null) { return; }
                    foreach (var objeto in detallePrecios)
                    {
                        if (detalleVales.Cantidad >= objeto.RangoInicio && detalleVales.Cantidad <= objeto.RangoFinal)
                        {
                            detalleVales.Precio = objeto.Precio;
                            detalleVales.Total = detalleVales.Precio * detalleVales.Cantidad;
                        }
                    }

                }
                
               

                //if (!comprobarProducto(datagrid, detalleVales))
                //{
                //   // if (!verficarMontodisponible(detalleVales)) { KryptonMessageBox.Show("No cuenta con suficiente Disponibilidad "); }
                //  //  else
                //  //  {
                        listaT.Add(detalleVales);
                //    //}
                      
                  
                    
                //}
                //else
                //{
                //    KryptonMessageBox.Show("El producto: " + detalleVales.Descripcion + " \n ya se encuentra añadido");
                    
                //}

                
            }
            cargarlistaProductosSelected(datagrid, listaT);
        }
      

       


        private ListarDetalleVales GetlistaDetalle()
        {
            return new ListarDetalleVales()
            {

            };
        }
       

        private void limpiarSeleccion(DataGridView datagrid,int numerocol)
        {

            foreach (DataGridViewRow Rows in datagrid.Rows)
            {
                bool acciones = Convert.ToBoolean(Rows.Cells[numerocol].Value);
                if (acciones)
                {
                    Rows.Cells[numerocol].Value = false;
                }
            }
        }
        private void cargarlistaProductosSelected(DataGridView datagrid, List<ListarDetalleVales> lista)
        {

            BindingSource recurso = new BindingSource();
            recurso.DataSource = lista;
            datagrid.DataSource = typeof(List<>);
            datagrid.DataSource = recurso;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].Visible = false;
            datagrid.Columns[2].Visible = false;
            datagrid.Columns[3].Visible = false;
            datagrid.Columns[10].Visible = false;
            datagrid.Columns[11].Visible = false;
            datagrid.Columns[12].Visible = false;
        }
        private void ActualizarMonto()
        {
            decimal actualizarTotal = 0.00M;
            decimal montodisponible = decimal.Parse(txtMonto.Text);

            foreach (DataGridViewRow fila in dgvPedido.Rows)
            {
                if (fila.Cells[subtotalcol].Value != null)
                    actualizarTotal += (decimal)fila.Cells[subtotalcol].Value;
            }

            if (actualizarTotal > montodisponible) { KryptonMessageBox.Show("No cuenta con suficiente monto disponible"); return; }
            decimal subtotal = montodisponible - actualizarTotal;
            txtreciduo.Text = subtotal.ToString("0.00");
            lbtotal1.Text = actualizarTotal.ToString();

        }


      
        public bool comprobarProducto(DataGridView dataGrid, ListarDetalleVales detalle)
        {
            
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (int.Parse(row.Cells[2].Value.ToString()) == detalle.ProductoId)
                {
                    return true;
                }
              
                
            }

            return false;
        }

        private void CargarComboToVale()
        {

            if (dgvCombos.RowCount <= 0) { return; }
            int filasSeleccion = 0;

            var listaDetalleVale = new List<ListarDetalleVales>();

            foreach (DataGridViewRow Rows in dgvCombos.Rows)
            {
                var filasTotales = int.Parse(dgvCombos.RowCount.ToString());


                bool acciones = Convert.ToBoolean(Rows.Cells[colAcciones].Value);
                if (!acciones)
                {
                    filasSeleccion += 1;
                }
                else
                {
                    var detalleVale = GetlistaDetalle();
                    detalleVale.ComboId = Guid.Parse(Rows.Cells[1].Value.ToString());
                    detalleVale.Descripcion = Rows.Cells[3].Value.ToString();
                    detalleVale.ValesId = Guid.Parse(lbnoVale.Text);
                    detalleVale.Cantidad = 1;
                    
                        if (_vale.Tipo == "Mayorista")
                        {
                        detalleVale.Precio = Convert.ToDecimal(Rows.Cells[mayoristacol].Value.ToString());
                        }
                        if (_vale.Tipo == "Minorista")
                        {
                        detalleVale.Precio = Convert.ToDecimal(Rows.Cells[minoristacol].Value.ToString());
                        }
                        if (_vale.Tipo == "Cuenta Clave")
                        {
                        detalleVale.Precio = Convert.ToDecimal(Rows.Cells[cuentaclacol].Value.ToString());
                        }
                        if (_vale.Tipo == "Revendedor")
                        {
                        detalleVale.Precio = Convert.ToDecimal(Rows.Cells[reventacol].Value.ToString());
                    
                        }
                        if (_vale.Tipo == "Gubernamental")
                        {
                        detalleVale.Precio = Convert.ToDecimal(Rows.Cells[gubernacol].Value.ToString());
                      
                        }

                    detalleVale.Total = detalleVale.Cantidad * detalleVale.Precio;
                    _listaDetalleToVale.Add(detalleVale);

                }


                if (filasTotales == filasSeleccion)
                {
                    KryptonMessageBox.Show("Debera tener seleccionada  la columna 'Acciones'\n "
                        + "Selecione un Producto, dando click en la columna Acciones\n"
                        );

                    return;
                }

            }
            cargarlistaProductosSelected(dgvPedido, _listaDetalleToVale);

        }
        private void SeleccionAcciones(DataGridView data, List<Producto> Productolista)
        {


            if (data.RowCount <= 0) { return; }
            int filasSeleccion = 0;
            foreach (DataGridViewRow Rows in data.Rows)
            {
                var filasTotales = int.Parse(data.RowCount.ToString());


                bool acciones = Convert.ToBoolean(Rows.Cells[28].Value);
                if (!acciones)
                {
                    filasSeleccion += 1;
                }
                else
                {
                    var Id = int.Parse(Rows.Cells[0].Value.ToString());
                    var productoObtenido = _productosRepository.Get(Id);
                    if(productoObtenido.TieneColor==false && productoObtenido.TieneTalla == false || productoObtenido.TieneColor == true || productoObtenido.TieneTalla == true)
                    {
                        Productolista.Add(productoObtenido);
                    }
                   
                }


                if (filasTotales == filasSeleccion)
                {
                    KryptonMessageBox.Show("Debera tener seleccionada  la columna 'Acciones'\n "
                        + "Selecione un Producto, dando click en la columna Acciones\n");

                    return;
                }

            }


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

        private void btnAddVale_Click(object sender, EventArgs e)
        {
            if(txtestado.Text!= "Asignado") { KryptonMessageBox.Show("Vale ya cambiado, no se puede añadir productos");return; }

            SeleccionAcciones(dgvProductos, ListaFilasenDGV);
            AgregarlistaToDgv(dgvPedido,_listaDetalleToVale, ListaFilasenDGV);
            ListaFilasenDGV.Clear();
            limpiarSeleccion(dgvProductos,colAccionesProd);

        }

        private void btnAddRebaja_Click(object sender, EventArgs e)
        {
            if (txtestado.Text != "Asignado") { KryptonMessageBox.Show("Vale ya cambiado, no se puede añadir productos"); return; }

            CargarComboToVale();
            //ListaFilaRebajas.Clear();
            limpiarSeleccion(dgvCombos,colAcciones);
            ActualizarMonto();




        }

        private void checkTodas_CheckedChanged(object sender, EventArgs e)
        {
            CheckedAll();
        }

        private void checktodasReb_CheckedChanged(object sender, EventArgs e)
        {
            CheckedCombos();

        }
        private void txtbuscarp_TextChanged(object sender, EventArgs e)
        {
            var filter = listaProductos.Where(a => a.Descripcion.Contains(txtbuscarp.Text) ||
                (a.CodigoReferencia != null && a.CodigoReferencia.Contains(txtbuscarp.Text)) ||
                (a.Categoria != null && a.Categoria.Contains(txtbuscarp.Text)) ||
                (a.Notas != null && a.Notas.Contains(txtbuscarp.Text)));
            dgvProductos.DataSource = filter.ToList();
        }

       
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var montoinicial = decimal.Parse(txtMonto.Text);
            var totalmonto = decimal.Parse(lbtotal1.Text);
            if (totalmonto > montoinicial) { KryptonMessageBox.Show("Total es mayor al monto asignado en el vale"); return; }
            if (montoinicial >= totalmonto)
            {
                GuardarVales();
            }
           
        }
        private void GuardarVales()
        {
            if (txtestado.Text == "Cobrado") { KryptonMessageBox.Show("Vale ya cambiado anteriormente, Estado Cobrado"); return; }
            if (dgvPedido.RowCount == 0) { KryptonMessageBox.Show("Debe tener un producto para Facturar"); return; }
            var detalleVales = GetDatosDetalleVales();
            if (!ModelState.IsValid(detalleVales)) { return; }
            foreach (var item in detalleVales)
            {
                if (item.ProductoId == 0)
                {
                    item.ProductoId = null;
                    var combob = _combosRepository.Get((Guid)item.ComboId);
                    if (combob.Stock <= 0) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }
                    if (combob.Stock < item.Cantidad) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }
                    combob.Stock -= item.Cantidad;
                    _combosRepository.Update(combob, true);
                }
                else
                {
                    item.ComboId = null;
                    var producto = _productosRepository.Get((int)item.ProductoId);
                    if (producto.Stock <= 0) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }
                    if (producto.Stock < item.Cantidad) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }

                    producto.Stock -= item.Cantidad;
                    _productosRepository.Update(producto, true);
                    if (item.DetalleColorId != 0)
                    {
                        var detalleObtenido = _coloresRepository.GetDetalleColor((int)item.DetalleColorId);
                        if (detalleObtenido.Stock < item.Cantidad) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }
                        detalleObtenido.Stock -= item.Cantidad;
                        _coloresRepository.Update(detalleObtenido);
                    }
                    if (item.DetalleTallaId != 0)
                    {
                        var detalleObtenidotalla = _tallasRepository.GetDetalleTalla((int)item.DetalleTallaId);
                        if (detalleObtenidotalla.Stock < item.Cantidad) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }
                        detalleObtenidotalla.Stock -= item.Cantidad;
                        _tallasRepository.Update(detalleObtenidotalla);
                    }
                    if (item.DetalleColorTallaId != 0)
                    {
                        var detallecolortallaobten = _tallasyColoresRepository.GetColorTalla((int)item.DetalleColorTallaId);
                        if (detallecolortallaobten.Stock < item.Cantidad) { KryptonMessageBox.Show("No hay suficiente en Stock para continuar"); return; }
                        detallecolortallaobten.Stock -= item.Cantidad;
                        _tallasyColoresRepository.Update(detallecolortallaobten);
                    }

                }

                if (item.DetalleColorId == 0)
                {
                    item.DetalleColorId = null;
                    //item.DetalleColorTallaId = null;
                }
                if (item.DetalleTallaId == 0)
                {
                    item.DetalleTallaId = null;
                }
                if (item.DetalleColorTallaId == 0)
                {
                    item.DetalleColorTallaId = null;
                }
                
                _valesRepository.AddDetalle(item);
            }
            UpdateAsignacion();
            KryptonMessageBox.Show("Registro Guardado correctamente! ");
            cargarnuevamente();
            Close();

        }

        private void UpdateAsignacion()
        {
            AsignacionVale valeoptenido = null ;
            if (clienteslist.Count > 0)
            {
                valeoptenido = _valesRepository.GetAsinacionPorCliente(int.Parse(comboClientes.SelectedValue.ToString()), _vale.Id);
            }
            else if (Novaleslist.Count > 0)
            {
                valeoptenido = _valesRepository.GetAsinacionPorNumero(int.Parse(comboClientes.SelectedValue.ToString()), _vale.Id);
            }
            var AsignacionUpdate= GetAsignacionUpdate(valeoptenido);
            if (!ModelState.IsValid(AsignacionUpdate)) { return; }

            AsignacionUpdate.Estado = "Cobrado";
            _valesRepository.UpdateAsignacion(AsignacionUpdate);
            

        }


        public AsignacionVale GetAsignacionUpdate(AsignacionVale asignacion)
        {

            asignacion.Reciduo = decimal.Parse(txtreciduo.Text);
            asignacion.FechaCambio = DateTime.Now;
            asignacion.Nombre = txtnombre.Text;
            asignacion.Apellido = txtapellido.Text;
            asignacion.Nit = txtnit.Text;
            asignacion.Telefono = txttelefono.Text;


            return asignacion;
        }

      

       


        public List<DetalleVale> GetDatosDetalleVales()
        {
            var List = new List<DetalleVale>();

            foreach (DataGridViewRow item in dgvPedido.Rows)
            {
                if (item == null)
                {
                    continue;
                }

                DetalleVale detallevale = new DetalleVale
                {
                    Id = Guid.NewGuid(),
                    ProductoId = int.Parse(item.Cells[productidCol].Value.ToString()),
                    Cantidad = int.Parse(item.Cells[cantidadcol].Value.ToString()),
                    AsignacionValeId= Guid.Parse(lbnoVale.Text),
                    ComboId= Guid.Parse(item.Cells[3].Value.ToString()),
                    precio= decimal.Parse(item.Cells[preciocol].Value.ToString()),
                    DetalleTallaId= int.Parse(item.Cells[tallaidCol].Value.ToString()),
                    DetalleColorId = int.Parse(item.Cells[coloridCol].Value.ToString()),
                    DetalleColorTallaId= int.Parse(item.Cells[12].Value.ToString()),
                };

                List.Add(detallevale);
            }

            return List;

        }


        
     
        private void dgvToVales_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {


            BuscarEscalaPrecios();



        }
        private void BuscarEscalaPrecios()
        {
            var codigoProducto = Convert.ToInt32( dgvPedido.CurrentRow.Cells[productidCol].Value);
            if (codigoProducto != 0)
            {
                var productoObtenido = _productosRepository.Get(codigoProducto);
                if (productoObtenido.TieneEscalas)
                {
                    var cantidad = Convert.ToInt32(dgvPedido.CurrentRow.Cells[cantidadcol].Value);
                    var TipoPrecio = _tipoPrecioRepository.Get(codigoProducto);
                    var detallePrecios = _tipoPrecioRepository.GetDetallePrecio(TipoPrecio.Id, _vale.TipoPrecio);
                    if (detallePrecios == null) { return; }
                    foreach (var item in detallePrecios)
                    {
                        if (cantidad >= item.RangoInicio && cantidad <= item.RangoFinal)
                        {
                           
                            dgvPedido.CurrentRow.Cells[preciocol].Value = item.Precio;
                            dgvPedido.CurrentRow.Cells[subtotalcol].Value =
                           Convert.ToDecimal(dgvPedido.CurrentRow.Cells[preciocol].Value) * Convert.ToDecimal(dgvPedido.CurrentRow.Cells[cantidadcol].Value);
                        }
                    }

                }
               

                 
                 dgvPedido.CurrentRow.Cells[subtotalcol].Value =
                Convert.ToDecimal(dgvPedido.CurrentRow.Cells[preciocol].Value) * Convert.ToDecimal(dgvPedido.CurrentRow.Cells[cantidadcol].Value);
            }
            dgvPedido.CurrentRow.Cells[subtotalcol].Value =
                Convert.ToDecimal(dgvPedido.CurrentRow.Cells[preciocol].Value) * Convert.ToDecimal(dgvPedido.CurrentRow.Cells[cantidadcol].Value);

            ActualizarMonto();

        }

        private void dgvToVales_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ActualizarMonto();
        }

        private void dgvToVales_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            ActualizarMonto();
        }

        private void dgvToVales_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
           
            //ActualizarMonto();
        }

        private void dgvCombos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarFila(dgvCombos, colAcciones);
            var comboActual = (ListarCombos)dgvCombos.CurrentRow.DataBoundItem;
            CargarDg(comboActual.IdCombo);
           
        }
        public void CargarDg(Guid idcombo)
        {


            BindingSource source = new BindingSource();
            var detalleListsObtenida = _combosRepository.GetListDetalleCombo(idcombo);
            source.DataSource = detalleListsObtenida;
            dgvDetalleCombo.DataSource = typeof(List<>);
            dgvDetalleCombo.DataSource = source;
            dgvDetalleCombo.Columns[codDetalle].Visible = false;
            dgvDetalleCombo.Columns[comboidcol].Visible = false;
            dgvDetalleCombo.Columns[2].Visible = false;
            dgvDetalleCombo.Columns[3].Visible = false;
            dgvDetalleCombo.Columns[6].Visible = false;
            dgvDetalleCombo.Columns[8].Visible = false;
            dgvDetalleCombo.AutoResizeColumns();


        }
        public void CargarDgvColoresTallas(int idprod)
        {


            BindingSource source = new BindingSource();
            var detalleListsObtenida = _tallasRepository.GetTallaListaProducto(idprod);
            if (detalleListsObtenida == null)
            {
                return;
               // detalleListsObtenida = _coloresRepository.GetColor(idprod);
            }
            source.DataSource = detalleListsObtenida;
            dgvDetalleCombo.DataSource = typeof(List<>);
            dgvDetalleCombo.DataSource = source;
          
            dgvDetalleCombo.AutoResizeColumns();


        }


        private void dgvCombos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtbuscarcombo_TextChanged(object sender, EventArgs e)
        {
            var filter = combos.Where(a => a.Descripcion.Contains(txtbuscarcombo.Text) ||
             (a.CodigoBarras != null && a.CodigoBarras.Contains(txtbuscarcombo.Text))
             );
            dgvCombos.DataSource = filter.ToList();

        }

        private void dgvtallascolores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarfila(dgvtallascolores, colAccionesTyC);
        }
        private void seleccionarfila(DataGridView data, int numberCol)
        {
            bool estadoActual = Convert.ToBoolean(data.CurrentRow.Cells[numberCol].Value);
            if (estadoActual)
            {
                data.CurrentRow.Cells[numberCol].Value = false;
            }
            else
            {
                data.CurrentRow.Cells[numberCol].Value = true;

            }
        }

        private void btnaddTallasycolores_Click(object sender, EventArgs e)
        {
            if (txtestado.Text != "Asignado") { KryptonMessageBox.Show("Vale ya cambiado, no se puede añadir productos"); return; }
            CargarSizeAndColorsToCombo();
            limpiarSeleccion(dgvtallascolores, 5);
            limpiarSeleccion(dgvProductos, 28);
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            SeleccionarFila(dgvProductos, colAccionesProd);
            var FilaActual = (ListarProductos)dgvProductos.CurrentRow.DataBoundItem;
            LlenarTextBox(FilaActual);
            var productoBuscar = _productosRepository.Get(FilaActual.Id);
            if (productoBuscar.TieneColor == true && productoBuscar.TieneTalla == true)
            {

                CargarDGVcolortalla(productoBuscar.Id);
                btnAddVale.Enabled = false;
            }
            else
            {
                btnAddVale.Enabled = true;
                dgvtallascolores.DataSource = null;
            }
        }

        public void CargarDGVcolortalla(int idproducto)
        {


            BindingSource source = new BindingSource();
            var detalleListsObtenida = _tallasyColoresRepository.GetListaDetalleColorTallas(idproducto);
            source.DataSource = detalleListsObtenida;
            dgvtallascolores.DataSource = typeof(List<>);
            dgvtallascolores.DataSource = source;
            dgvtallascolores.AutoResizeColumns();
            dgvtallascolores.Columns[0].Visible = false;
            dgvtallascolores.Columns[1].Visible = false;

        }
        private void cargarnuevamente()
        {
            NuevoVale nuevo = new NuevoVale(_vale);
            nuevo.Show();
        }

       
        public void LlenarTextBox(ListarProductos filaActual)
        {
           
            var productoObtenido = _productosRepository.Get(filaActual.Id);
            if (productoObtenido.TieneColor==true && productoObtenido.TieneTalla==false)
            {
                var listadeColoresProductos = _coloresRepository.GetProductoListaColor(productoObtenido.Id);
                cargarComboColores(listadeColoresProductos);
               
            }
            else
            {
                comboColores.DataSource = null;
              
            }
            if (productoObtenido.TieneColor == false && productoObtenido.TieneTalla == true)
            {
                var listadeTallaProductos = _tallasRepository.GetTallaListaProducto(productoObtenido.Id);
                cargarComboTallas(listadeTallaProductos);
                
            }
            else
            {
                combotallas.DataSource = null;
               
            }
            if (productoObtenido.TieneColor == true && productoObtenido.TieneTalla == true)
            {
                combotallas.DataSource = null;
                comboColores.DataSource = null;
            }
        }
        private void cargarComboColores(List<DetalleColor> detalleColors)
        {
            comboColores.DataSource = detalleColors;
            comboColores.ValueMember = "Id";
            comboColores.DisplayMember = "Color";
            comboColores.SelectedIndex = 0;
        }
        private void cargarComboTallas(List<DetalleTalla> listaTallas)
        {
            combotallas.DataSource = listaTallas;
            combotallas.ValueMember = "Id";
            combotallas.DisplayMember = "Talla";
            combotallas.SelectedIndex = 0;
        }
        private void CargarSizeAndColorsToCombo()
        {

            if (dgvtallascolores.RowCount <= 0) { return; }
            int filasSeleccion = 0;


            foreach (DataGridViewRow Rows in dgvtallascolores.Rows)
            {
                var filasTotales = int.Parse(dgvtallascolores.RowCount.ToString());


                bool acciones = Convert.ToBoolean(Rows.Cells[colAccionesTyC].Value);
                if (!acciones)
                {
                    filasSeleccion += 1;

                }
                else
                {
                    var detalleVale = GetlistaDetalle();

                    detalleVale.ProductoId = int.Parse(Rows.Cells[productIDTyCcol].Value.ToString());
                    var productoobtenido = _productosRepository.Get(detalleVale.ProductoId);
                    detalleVale.Cantidad = 1;
                    detalleVale.Descripcion = productoobtenido.Descripcion;
                    detalleVale.Color = Rows.Cells[colorTyCcol].Value.ToString();
                    detalleVale.Talla = Rows.Cells[tallaTyCcol].Value.ToString();
                    detalleVale.TallayColorId = int.Parse(Rows.Cells[IDTyCcol].Value.ToString());
                    detalleVale.ValesId = Guid.Parse(lbnoVale.Text);
                    if (productoobtenido.TieneEscalas == false)
                    {
                        if (_vale.Tipo == "Mayorista")
                        {
                            detalleVale.Precio = productoobtenido.PrecioMayorista;

                        }
                        if (_vale.Tipo == "Minorista")
                        {
                            detalleVale.Precio = productoobtenido.PrecioVenta;

                        }
                        if (_vale.Tipo == "Cuenta Clave")
                        {
                            detalleVale.Precio = productoobtenido.PrecioCuentaClave;

                        }
                        if (_vale.Tipo == "Revendedor")
                        {
                            detalleVale.Precio = productoobtenido.PrecioRevendedor;

                        }
                        if (_vale.Tipo == "Gubernamental")
                        {
                            detalleVale.Precio = productoobtenido.PrecioEntidadGubernamental;

                        }
                        detalleVale.Total = detalleVale.Precio * detalleVale.Cantidad;
                    }
                    else
                    {
                        var TipoPrecio = _tipoPrecioRepository.Get(productoobtenido.Id);
                        var detallePrecios = _tipoPrecioRepository.GetDetallePrecio(TipoPrecio.Id, _vale.TipoPrecio);
                        if (detallePrecios == null) { return; }
                        foreach (var objeto in detallePrecios)
                        {
                            if (detalleVale.Cantidad >= objeto.RangoInicio && detalleVale.Cantidad <= objeto.RangoFinal)
                            {
                                detalleVale.Precio = objeto.Precio;
                                detalleVale.Total = detalleVale.Precio * detalleVale.Cantidad;
                            }
                        }
                    }

                    _listaDetalleToVale.Add(detalleVale);

                }


                if (filasTotales == filasSeleccion)
                {
                    KryptonMessageBox.Show("Debera tener seleccionada  la columna 'Acciones'\n "
                        + "Selecione un Producto, dando click en la columna Acciones\n"
                        );

                    return;
                }

            }
            cargarlistaProductosSelected(dgvPedido, _listaDetalleToVale);

        }


    }
}
