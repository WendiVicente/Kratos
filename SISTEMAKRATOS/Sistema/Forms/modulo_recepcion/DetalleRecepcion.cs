using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Recepciones;
using CapaDatos.Repository;
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

namespace Sistema.Forms.modulo_recepcion
{
    public partial class DetalleRecepcion : BaseContext
    {
        private Compra _CompraObtenida = null;
        private ListarRecepciones _recepcionOtenida = null;
        private ProveedoresRepository _proveedoresRepository = null;
        private ComprasRepository _comprasRepository = null;
        private ProductosRepository _productosRepository = null;
        private RecepcionesRepository _recepcionesRepository = null;
        private readonly VerRecepciones _verRecepcionesForm=null;
        private CajasRepository _cajasRepository = null;
        private string UserIdlogeado = UsuarioLogeadoSistemas.User.Id;
        private int sucursalid = UsuarioLogeadoSistemas.User.SucursalId;
        private int EstadoRecepcion = 0;
       
        public DetalleRecepcion(Compra compra,ListarRecepciones listaRecep, VerRecepciones verRecepciones)
        {
            _cajasRepository = new CajasRepository(_context);
            _verRecepcionesForm = verRecepciones;
            _recepcionOtenida = listaRecep;
            _productosRepository = new ProductosRepository(_context);
            _proveedoresRepository = new ProveedoresRepository(_context);
            _comprasRepository = new ComprasRepository(_context);
            _recepcionesRepository = new RecepcionesRepository(_context);
            _CompraObtenida = compra;
            InitializeComponent();
        }

        private void DetalleRecepcion_Load(object sender, EventArgs e)
        {
            cargarDatos();
            CargarDg(true);
            SetWidthDatagrid();
           
        }


        private void cargarDatos()
        {
            lbcompraid.Text = _recepcionOtenida.SolicitudCompra.ToString();
            txtcomprobante.Text = _CompraObtenida.NoComprobante;
            lbfechasolicitud.Text = _CompraObtenida.FechaRecepcion.ToString();
            lbfechaestimada.Text = _CompraObtenida.FechaLimite.ToString();
            ObtenerProveedor();
            lbEstado.Text = _recepcionOtenida.EstadoRecepcion;


        }
        private void ObtenerProveedor()
        {
            var proveedor = _proveedoresRepository.Get(_CompraObtenida.ProveedorId);
            lbproveedor.Text = proveedor.Nombre;

        }

        private void CargarDg(bool loadNewContext = true)
        {

            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _comprasRepository = null;
                _comprasRepository = new ComprasRepository(_context);
            }

            BindingSource source = new BindingSource();
            var compras = _comprasRepository.GetListDetalleCompra(_CompraObtenida.Id);
            source.DataSource = compras;
            ListaProductSelect.DataSource = typeof(List<>);
            ListaProductSelect.DataSource = source;
            ListaProductSelect.Columns[0].Visible = false;
            var suma = compras.Sum(a => a.Total);
            lbtotal.Text = suma.ToString();
            //TotaldeCompra = suma;
        }

        private void txtcomprobante_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void SetWidthDatagrid()
        {
            DataGridViewColumn colDescripcion = ListaProductSelect.Columns[2];
            DataGridViewColumn colReferencia = ListaProductSelect.Columns[1];
            colDescripcion.Width = 200;
            colReferencia.Width = 150;
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (ListaProductSelect.Rows.Count == 0) { KryptonMessageBox.Show("Esta Recepción No tiene ningun producto"); return; }
            var estado = _recepcionOtenida.EstadoRecepcion;
            if (estado == "Cancelado") { KryptonMessageBox.Show("Recepcion con Estado Cancelado, no puede Validarse"); return; }
            if (estado == "Hecho" || estado == "Comprado") { KryptonMessageBox.Show("Esta Solicitud ya fue Comprada "); return; }

            if(estado =="Recepcion" || estado == "Preparado")
            {
                AplicarCambios();
            }
           
        }

        private void AplicarCambios()
        {
            EstadoRecepcion = ObtenerIdEstado("Hecho");
            var detallecompraslista = _comprasRepository.GetListDetalleCompra(_CompraObtenida.Id);
            try
            {
                foreach (var item in detallecompraslista)
                {
                    var producto = _productosRepository.GetProductByBarCode(item.Referencia, int.Parse(_CompraObtenida.SucursalId.ToString()));
                    decimal c1 = producto.Coste * producto.Stock;
                    decimal c2 = item.Precio * item.Cantidad;
                    int stocktotal = producto.Stock + item.Cantidad;
                    producto.Coste = (c1 + c2) / stocktotal;
                    producto.Stock = stocktotal;
                    _productosRepository.Update(producto, false);
                }

                // cambio de estados
                var recepcion = _recepcionesRepository.Get(_recepcionOtenida.SolicitudCompra, true);
                recepcion.EstadoRecepcionId = EstadoRecepcion; // estadoRecepcion = 7 que  Hecho compra finalizada
                _recepcionesRepository.Update(recepcion, true);
                var compras = _comprasRepository.Get(_CompraObtenida.Id);
                compras.Estado = true; // true es comprado 
                _comprasRepository.Update(compras);

                KryptonMessageBox.Show("Se Actualizo El inventario ");
                _verRecepcionesForm.RefrescarDataGridCompras(true);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private int ObtenerIdEstado(string EstadoBuscado)
        {
            var estadoRecepcion = _recepcionesRepository.ObtenerEstadoId(EstadoBuscado);
            var id = estadoRecepcion.Id;
            return id;
        }        

    }
}
