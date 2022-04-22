using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.ListasPersonalizadas.Devoluciones;
using CapaDatos.ListasPersonalizadas.VentasAcumuladas;
using CapaDatos.Models.Cotizacion;
using CapaDatos.Models.DocumentoSAT;
using CapaDatos.Models.Pedidos;
using CapaDatos.Models.ProductosToFacturar;
using CapaDatos.Models.Usuarios;
using CapaDatos.Models.Vales;
using CapaDatos.Repository;
using CapaDatos.Repository.DevolucionesRepository;
using CapaDatos.Repository.SolicitudestoFacturar;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace POS.Forms.Facturacion
{
    public partial class MonitorFacturacion : BaseContext
    {
        #region VARIABLES
        private List<AnulacionCertificado> _listaAnular = null;
        private NotaDebitoRepository _notaDebitoRepository = null;
        private CertificadoSatRepository _certificadoSatRepository = null;
        private List<DocumentoCertificadoSAT> _listaDocumentos = null;
        private readonly ProductosRepository _productosRepository = null;
        private readonly ClientesRepository _clientesRepository = null;
        private readonly SolicitudesRepository _solicitudesRepository = null;
        private readonly CotizacionRepository _cotizacionRepository = null;
        private readonly ValesRepository _valesRepository = null;
        private readonly ColoresRepository _coloresRepository = null;
        private readonly TallasRepository _tallasRepository = null;

        private readonly DetalleProductoRepository _detalleProductoRepository = null;

        private List<ListarAcumuladasEncabezado> solicitudes = null;
        private IList<ListarCotizaciones> cotizaciones = null;
        private IList<ListarVales> vales = null;
        private List<ListaFacturacion> _listadoMonitor = null;


        private PuntoDeVenta _pos = null;

        #endregion

        #region FORMULARIO

        public MonitorFacturacion(PuntoDeVenta pos)
        {
            _notaDebitoRepository = new NotaDebitoRepository(_context);
            _certificadoSatRepository = new CertificadoSatRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            _clientesRepository = new ClientesRepository(_context);
            _solicitudesRepository = new SolicitudesRepository(_context);
            _cotizacionRepository = new CotizacionRepository(_context);
            _valesRepository = new ValesRepository(_context);
            _coloresRepository = new ColoresRepository(_context);
            _tallasRepository = new TallasRepository(_context);
            solicitudes = new List<ListarAcumuladasEncabezado>();
            cotizaciones = new List<ListarCotizaciones>();
            vales = new List<ListarVales>();
            _listadoMonitor = new List<ListaFacturacion>();
            _pos = pos;
            this.StartPosition = pos.StartPosition;
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            RegresarFormulario();
        }

        private void MonitorFacturacion_Load(object sender, EventArgs e)
        {            
            //_listaDocumentos = _certificadoSatRepository.GetlistaDoCertificadoSAT();
            //_listaAnular = _certificadoSatRepository.GetListaAnulaciones();
            CargarInformacion(_listadoMonitor);
        }

        private void MonitorFacturacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegresarFormulario(false);
        }

        private void RegresarFormulario(bool cerrar = true)
        {
            //if (Formulario != null)
            //{
            //    Formulario.Show();
            //    Formulario.Activate();
            //}
            //if (cerrar)
            //{
            //    Close();
            //}
        }

        #endregion

        #region FACTURAR

        public void CargarInformacion(List<ListaFacturacion> listado)
        {
            //para el tipo de documento
            //16 -> contado
            //17 -> credito
            //21 -> cotizacion
            //22 -> vale
            CargarSolicitudesContado(listado);
            //CargarSolicitudesCredito(listado);
            CargarCotizaciones(listado);
            CargarVales(listado);
            CargaDGV(listado);
        }

        private void CargarSolicitudesContado(List<ListaFacturacion> listado)
        {
           ListaFacturacion documento = new ListaFacturacion();
            var solicitudes = new SolicitudesRepository(_context).GetSolicitudes(UsuarioLogeadoPOS.User.SucursalId);
            if (solicitudes.Count() > 0)
            {
                solicitudes = solicitudes.Where(x => x._State == false).ToList();
            }
            var filter = solicitudes.Where(x => x.NoSolicitud.Contains("VCN")).ToList();
            foreach (var item in filter)
            {
                documento.IdDocumento = item.Id;
                documento.IdTipoDocumento = 16;
                documento.Documento = item.NoSolicitud;
                documento.Fecha = item.FechaVenta;

                if (item.ClienteId <= 0)
                {
                    documento.Nit = item.NitCliente;
                    documento.Nombre = item.NombreCliente;
                }
                else
                {
                    ObtenerCliente(item.ClienteId, documento);
                }
                documento.Vendedor = item.Vendedor;
                documento.Valor = "Q " + ObtenerTotalSol(item.Id);
                documento.Facturar = false;
               documento.Temporales = item.Temporales;
                listado.Add(documento);
                documento = new ListaFacturacion();
            }
        }

        private void CargarSolicitudesCredito(List<ListaFacturacion> listado)
        {
            //para el tipo de documento
            //16 -> contado
            //17 -> credito
            //21 -> cotizacion
            //22 -> vale
            ListaFacturacion documento = new ListaFacturacion();
            solicitudes = _solicitudesRepository.GetSolicitudes(UsuarioLogeadoPOS.User.SucursalId);
            if (solicitudes.Count() > 0)
            {
                solicitudes = solicitudes.Where(x => x.Estado != "Facturado").ToList();
            }
            //var filter2 = solicitudes.Where(x => x.NoSolicitud.Contains("VCR")).ToList();
            foreach (var item in solicitudes)
            {
                documento.IdDocumento = item.Id;
                documento.IdTipoDocumento = 17;
                documento.Documento = item.NoSolicitud;
                documento.Fecha = item.FechaVenta;
                //if (item.ClienteId <= 0)
                //{
                //    documento.Nit = item.NitCliente;
                //    documento.Nombre = item.NombreCliente;
                //}
                //else
                //{
                //    ObtenerCliente(item.ClienteId, documento);
                //}
                documento.Vendedor = item.Vendedor;
                documento.Valor = "Q " + ObtenerTotalSol(item.Id);
                documento.Facturar = false;
               documento.Temporales = item.Temporales;
                listado.Add(documento);
                documento = new ListaFacturacion();
            }
        }

        private void CargarCotizaciones(List<ListaFacturacion> listado)
        {
            ListaFacturacion documento = new ListaFacturacion();
            cotizaciones = _cotizacionRepository.GetListGenerales(0);
            if (cotizaciones.Count > 0)
            {
                cotizaciones = _cotizacionRepository.GetListGenerales(0).Where(x => x.Estado != "Comprado").ToList();
            }
            foreach (var item in cotizaciones)
            {
                documento.IdDocumento = item.Id;
                documento.IdTipoDocumento = 21;
                documento.Documento = item.NoCotizacion;
                documento.Fecha = item.FechaRecepcion;
                if (item.ClienteId <= 0)
                {
                    documento.Nit = item.Nit;
                    documento.Nombre = item.Nombre + " " + item.Apellido;
                }
                else
                {
                    ObtenerCliente(item.ClienteId, documento);
                }

                documento.Vendedor = item.NombreVendedor;
                documento.Valor = "Q " + ObtenerTotalCot(item.Id);
                documento.Facturar = false;
                documento.Temporales = false;
                listado.Add(documento);
                documento = new ListaFacturacion();
            }
        }

        private void CargarVales(List<ListaFacturacion> listado)
        {
            ListaFacturacion documento = new ListaFacturacion();
            vales = _valesRepository.GetListaVales(UsuarioLogeadoPOS.User.SucursalId);
            if (vales.Count() > 0)
            {
                vales = vales.Where(x => x.Estado != true).ToList();
            }
            foreach (var item in vales)
            {
                var asigvale = _valesRepository.GetAsignacionVale(item.Id);
                foreach (var detalleval in asigvale)
                {
                    documento.IdDocumento = item.Id;
                    documento.IdTipoDocumento = 22;
                    documento.Documento = item.NoVale;
                    documento.Fecha = item.FechaRecepcion;

                    if (detalleval.ClienteId == null)
                    {
                        documento.Nit = asigvale.ElementAt(0).Nit;
                        documento.Nombre = asigvale.ElementAt(0).Nombre;
                    }
                    else
                    {
                        ObtenerCliente((int)detalleval.ClienteId, documento);
                    }
                    documento.Vendedor = item.Usuario;
                    documento.Valor = "Q " + ObtenerTotalVal(detalleval.Id);
                    documento.Temporales = false;
                    listado.Add(documento);
                    documento = new ListaFacturacion();
                }
            }
        }

        public decimal ObtenerTotalSol(Guid id)
        {
            decimal Total = 0.00m;
            try
            {
                var solicitudes = _solicitudesRepository.GetDetallebySolicitud(id);
                if (solicitudes.Count > 0)
                {
                    Total = solicitudes.Sum(x => x.PrecioTotal);
                }
            }
            catch
            {
                MessageBox.Show("No pudo obtener valor Total del documento.", "Advertencia");
                Total = 0.00m;
            }
            return Total;
        }

        public decimal ObtenerTotalCot(Guid id)
        {
            decimal Total = 0.00m;
            try
            {
                var detallecotizaciones = _cotizacionRepository.GetDetalleCotizacionslista(id);
                if (detallecotizaciones.Count > 0)
                {
                    Total = detallecotizaciones.Sum(x => x.PrecioTotal);
                }
            }
            catch
            {
                MessageBox.Show("No pudo obtener valor Total del documento.", "Advertencia");
                Total = 0.00m;
            }
            return Total;
        }

        public decimal ObtenerTotalVal(Guid id)
        {
            decimal Total = 0.00m;
            try
            {
                var vales = _valesRepository.GetListadoDetalleVales(id);
                if (vales.Count > 0)
                {
                    Total = vales.Sum(x => x.precio);
                }
            }
            catch
            {
                MessageBox.Show("No pudo obtener valor Total del documento.", "Advertencia");
                Total = 0.00m;
            }
            return Total;
        }

        private void ObtenerCliente(int idcliente, ListaFacturacion documento)
        {
            var cliente = _clientesRepository.Get(idcliente);
            if (cliente != null)
            {
                documento.ClienteId = cliente.Id;
                documento.Nombre = cliente.Nombres + " " + cliente.Apellidos;
                documento.Nit = cliente.Nit;
            }
        }

        private void CargaDGV(List<ListaFacturacion> listado)
        {
            DgvEncabezadosDoc.DataSource = typeof(List<>);
            DgvEncabezadosDoc.DataSource = listado;
            DgvEncabezadosDoc.Columns[0].Visible = false;
            DgvEncabezadosDoc.Columns[1].Visible = false;
            DgvEncabezadosDoc.Columns[9].Visible = false;
            DgvEncabezadosDoc.Columns[10].Visible = false;
            DgvEncabezadosDoc.ClearSelection();
        }

        private void BuscarFecha(DateTime inicio, DateTime final)
        {
            DateTime _inicio = inicio.Date + new TimeSpan(0, 0, 0);
            DateTime _final = final.Date + new TimeSpan(23, 59, 59);
            var filter = _listadoMonitor.Where(x => x.Fecha >= _inicio && x.Fecha <= _final);
            if (filter.Count() > 0)
            {
                CargaDGV(filter.ToList());
            }
            else
            {
                CargaDGV(filter.ToList());
                MessageBox.Show("No existen documentos en el rango " +
                    "\nde fecha establecido.", "Notificación");
            }
        }

        private void TxtBuscador_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscador.Text.Length > 0)
            {
                string buscador = TxtBuscador.Text;
                var filter = _listadoMonitor.Where(x => x.Nit.Contains(buscador) && x.Nit != null ||
                x.Documento.Contains(buscador.ToUpper()) || x.Documento.Contains(buscador) ||
                x.Nombre.Contains(buscador.ToUpper()) || x.Nombre.Contains(buscador) ||
                x.Vendedor.Contains(buscador.ToUpper()) || x.Vendedor.Contains(buscador));

                if (filter.Count() > 0)
                {
                    CargaDGV(filter.ToList());
                }
                else
                {
                    CargaDGV(_listadoMonitor);
                }
            }
        }

        public void BtnActualizar_Click(object sender, EventArgs e)
        {

            //solicitudes = new List<ListarAcumuladasEncabezado>();
            //cotizaciones = new List<ListarCotizaciones>();
            //vales = new List<ListarVales>();
            _listadoMonitor.Clear();
            //txtTotalPedidos.Text = "0.00";
            //CargarInformacion(_listadoMonitor);
            LimpiarGridListadoDetalle();
            MonitorFacturacion_Load(null, null);
            MessageBox.Show("Listado Actualizado.", "Notificación");
        }

        public void LimpiarGridListadoDetalle()
        {
            int count = 0;
            foreach (DataGridViewRow row in DgvDetalleDoc.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    count++;
                }
            }

            for (int i = 0; i < count; i++)
            {
                DgvDetalleDoc.Rows.RemoveAt(0);
            }
        }

        private void BtnOrdenar_Click(object sender, EventArgs e)
        {
            var filter = _listadoMonitor.OrderByDescending(x => x.Fecha);
            CargaDGV(filter.ToList());
        }

        public void CargarDocumento(int doc, Guid id)
        {
            LimpiarGridListado();
            switch (doc)
            {
                case 16:
                    CargarSolicitud(doc, id);
                    break;
                case 17:
                    CargarSolicitud(doc, id);
                    break;
                case 21:
                    CargarCotizacion(doc, id);
                    break;
                case 22:
                    CargarVale(doc, id);
                    break;
            }
        }

        private void LimpiarGridListado()
        {
            int count = 0;
            foreach (DataGridViewRow row in DgvDetalleDoc.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    count++;
                }
            }

            for (int i = 0; i < count; i++)
            {
                DgvDetalleDoc.Rows.RemoveAt(0);
            }
        }

        private void CargarSolicitud(int doc, Guid id)
        {
            try
            {
                var solicitud = _solicitudesRepository.Get(id);
                if (solicitud != null)
                {
                    var detallesolicitudes = _solicitudesRepository.GetDetallebySolicitud(solicitud.Id);
                    foreach (SolicitudDetalle item in detallesolicitudes)
                    {
                        var producto = _productosRepository.Get((int)item.ProductoId);
                        DgvDetalleDoc.Rows.Add(new DataGridViewRow());
                        int indice = DgvDetalleDoc.Rows.Count - 1;
                        var data = DgvDetalleDoc.Rows[indice];

                        decimal pDescuento = 0.00m;
                        if (item.Descuento >= 1)
                        {
                            pDescuento = item.Precio - (item.Descuento / item.Cantidad);
                        }

                        data.Cells[0].Value = producto.Id;
                        data.Cells[1].Value = producto.Descripcion;
                        data.Cells[2].Value = item.Cantidad;
                        data.Cells[3].Value = producto.PrecioVenta;
                        data.Cells[4].Value = pDescuento;
                        data.Cells[5].Value = item.PrecioTotal;
                    }
                }
                else
                {
                    MessageBox.Show("¡No se pudo obtener la venta!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡No se pudo obtener la venta! \n" + ex.Message);
            }
        }

        private void CargarCotizacion(int doc, Guid id)
        {
            try
            {
                var cotizacion = _cotizacionRepository.GetCotizacion(id);
                if (cotizacion != null)
                {
                    var detallecotizaciones = _cotizacionRepository.GetDetalleCotizacionslista(cotizacion.Id);
                    foreach (DetalleCotizacion item in detallecotizaciones)
                    {
                        var producto = _productosRepository.Get((int)item.ProductoId);
                        DgvDetalleDoc.Rows.Add(new DataGridViewRow());
                        int indice = DgvDetalleDoc.Rows.Count - 1;
                        var data = DgvDetalleDoc.Rows[indice];

                        decimal pDescuento = 0.00m;
                        //if (item.Descuento >= 1)
                        //{
                        //    pDescuento = item.Precio - (item.Descuento / item.Cantidad);
                        //}

                        data.Cells[0].Value = producto.Id;
                        data.Cells[1].Value = producto.Descripcion;
                        data.Cells[2].Value = item.Cantidad;
                        data.Cells[3].Value = producto.PrecioVenta;
                        data.Cells[4].Value = pDescuento;
                        data.Cells[5].Value = item.PrecioTotal;
                    }
                }
                else
                {
                    MessageBox.Show("¡No se pudo obtener la cotización!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡No se pudo obtener la cotización! \n" + ex.Message);
            }
        }

        private void CargarVale(int doc, Guid id)
        {
            try
            {
                var vale = _valesRepository.GetVale(id);
                if (vale != null)
                {

                    var asigVale = _valesRepository.GetAsignacionVale(vale.Id).FirstOrDefault();
                    if (asigVale != null)
                    {
                        var detallevale = _valesRepository.GetListadoDetalleVales(asigVale.Id);
                        decimal descuentoT = 0.00m;
                        foreach (DetalleVale item in detallevale)
                        {
                            var producto = _productosRepository.Get((int)item.ProductoId);
                            DgvDetalleDoc.Rows.Add(new DataGridViewRow());
                            int indice = DgvDetalleDoc.Rows.Count - 1;
                            var data = DgvDetalleDoc.Rows[indice];

                            decimal pDescuento = 0.00m;
                            //if (item.Descuento >= 1)
                            //{
                            //    descuentoT += item.Descuento;
                            //    pDescuento = item.precio - (item.Descuento / item.Cantidad);
                            //}

                            data.Cells[0].Value = producto.Id;
                            data.Cells[1].Value = producto.Descripcion;
                            data.Cells[2].Value = item.Cantidad;
                            data.Cells[3].Value = producto.PrecioVenta;
                            data.Cells[4].Value = pDescuento;
                            //data.Cells[5].Value = item.PrecioTotal;
                        }
                    }
                    else
                    {
                        MessageBox.Show("¡No se pudo obtener el detalle del vale!");
                    }
                }
                else
                {
                    MessageBox.Show("¡No se pudo obtener el detalle del vale!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡No se pudo obtener el vale! \n" + ex.Message);
            }
        }

        private void BtnAgregarProd_Click(object sender, EventArgs e)
        {
            var fila = DgvEncabezadosDoc.CurrentRow;
            if (fila != null)
            {

                //if (Application.OpenForms["PuntoDeVenta"] == null)
                //{
                //    _pos = new PuntoDeVenta(UsuarioLogeadoPOS.User);
                //}
                //else
                //{
                //    Application.OpenForms["PuntoDeVenta"].Activate();
                //}

                //var f = (ListaFacturacion)fila.DataBoundItem;
                //_pos.CargarDocumento(f.IdTipoDocumento, f.IdDocumento);
                //_pos.Show();
            }
        }

        private void CalcularTotal()
        {
            decimal Total = 0.00m;
            foreach (DataGridViewRow row in DgvEncabezadosDoc.Rows)
            {
                bool Facturar = Convert.ToBoolean(row.Cells[8].Value);
                if (Facturar)
                {
                    string[] valor = row.Cells[7].Value.ToString().Split(' ');
                    Total += Convert.ToDecimal(valor[1]);
                }
            }
            txtTotalPedidos.Text = Total.ToString();
        }

        private void CalcularLineas()
        {
            int Contador = 0;
            foreach (DataGridViewRow row in DgvEncabezadosDoc.Rows)
            {
                bool Facturar = Convert.ToBoolean(row.Cells[8].Value);
                if (Facturar)
                {
                    int tipo = Convert.ToInt32(row.Cells[1].Value);
                    switch (tipo)
                    {
                        case 16:
                        case 17:
                            var solicitudes = _solicitudesRepository.GetDetallebySolicitud((Guid)row.Cells[0].Value);
                            Contador += solicitudes.Count();
                            break;
                        case 21:
                            var cotizaciones = _cotizacionRepository.GetDetalleCotizacionslista((Guid)row.Cells[0].Value);
                            Contador += cotizaciones.Count();
                            break;
                        case 22:
                            var asigVale = _valesRepository.GetAsignacionVale((Guid)row.Cells[0].Value);
                            var vales = _valesRepository.GetListadoDetalleVales((Guid)asigVale.FirstOrDefault().Id).ToList();
                            Contador += vales.Count();
                            break;
                    }
                }
            }
            txtLineasItems.Text = Contador.ToString();
        }

        private void BtnFacturar_Click(object sender, EventArgs e)
        {
            CobrarPedido();
        }

        private void CobrarPedido()
        {
            int contador = 0;
            ListaFacturacion documento = new ListaFacturacion();
            foreach (DataGridViewRow row in DgvEncabezadosDoc.Rows)
            {
                bool Facturar = Convert.ToBoolean(row.Cells[8].Value);
                if (Facturar)
                {
                    documento = (ListaFacturacion)row.DataBoundItem;
                    contador++;
                }
            }
            if (contador > 1)
            {
                MessageBox.Show("Hay mas de un docummento seleccionado.\nDebe seleccionar unicamente uno.", "Notificación");
            }
            else if (contador == 0)
            {
                MessageBox.Show("No hay ningún documento seleccionado.", "Notificación");
            }
            else
            {
                List<ListaFacturacion> listado = new List<ListaFacturacion>();
                listado.Add(documento);
                EvaluarExistenciasParaCobro(listado);
            }
        }

        private void CobrarPedidos()
        {
            int contador = 0;
            ListaFacturacion documento = new ListaFacturacion();
            foreach (DataGridViewRow row in DgvEncabezadosDoc.Rows)
            {
                bool Facturar = Convert.ToBoolean(row.Cells[8].Value);
                if (Facturar)
                {
                    documento = (ListaFacturacion)row.DataBoundItem;
                    contador++;
                }
            }
            if (contador > 1)
            {
                MessageBox.Show("Hay mas de un docummento seleccionado.\nDebe seleccionar unicamente uno.", "Notificación");
            }
            else if (contador == 0)
            {
                MessageBox.Show("No hay ningún documento seleccionado.", "Notificación");
            }
            else
            {
                List<ListaFacturacion> listado = new List<ListaFacturacion>();
                listado.Add(documento);
                EvaluarExistenciasParaCobro(listado);
            }
        }

        private void Cobro(List<ListaFacturacion> listado)
        {
            if (Application.OpenForms["Cobro"] == null)
            {
                Cobro sel = new Cobro(listado, this, _pos);
                sel.Show();
            }
            else
            {
                Application.OpenForms["Cobro"].Activate();
            }
        }

        public void ActualizarInformacion()
        {
            solicitudes = new List<ListarAcumuladasEncabezado>();
            cotizaciones = new List<ListarCotizaciones>();
            vales = new List<ListarVales>();
            _listadoMonitor = new List<ListaFacturacion>();
            CargaDGV(_listadoMonitor);
            txtLineasItems.Text = "0";
            txtTotalPedidos.Text = "0.00";
            InitializeComponent();
        }

        private void DgvEncabezadosDoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var cell = DgvEncabezadosDoc.CurrentCell;
            if (cell != null)
            {
                if (cell.ColumnIndex == 8)
                {
                    if (Convert.ToBoolean(cell.Value))
                    {
                        cell.Value = false;
                        CalcularTotal();
                        CalcularLineas();
                    }
                    else
                    {
                        cell.Value = true;
                        CalcularTotal();
                        CalcularLineas();
                    }
                }
            }
        }

        private void BtnFacturarVarios_Click(object sender, EventArgs e)
        {
            CobrarPedidos();
        }

        private List<DetalleProducto> ExistenciasDetalle(List<ListaFacturacion> listado)
        {
            List<DetalleProducto> detalleSinExistencias = new List<DetalleProducto>();
            foreach (var fact in listado)
            {
                if (fact.Temporales)
                {
                    var _listaDetalles = _detalleProductoRepository.GetListNoDocumento(fact.Documento);

                    if (_listaDetalles.Count() > 0)
                    {
                        foreach (DetalleProducto item in _listaDetalles)
                        {
                            switch (item.TipoDetalle)
                            {
                                case "Color":
                                    var color = _coloresRepository.GetDetalleColor(item.DetalleId);
                                    if (color != null)
                                    {
                                        if (color.Stock < item.Cantidad)
                                        {
                                            detalleSinExistencias.Add(item);
                                        }
                                    }
                                    break;
                                case "Talla":
                                    var talla = _tallasRepository.GetDetalleTalla(item.DetalleId);
                                    if (talla != null)
                                    {
                                        if (talla.Stock < item.Cantidad)
                                        {
                                            detalleSinExistencias.Add(item);
                                        }
                                    }
                                    break;
                                //case "Tomo":
                                //    var tomo = _tomoEdicionRepository.GetDetalleTE(item.DetalleId);
                                //    if (tomo != null)
                                //    {
                                //        if (tomo.Stock < item.Cantidad)
                                //        {
                                //            detalleSinExistencias.Add(item);
                                //        }
                                //    }
                                //    break;
                                //case "Edicion":
                                //    var edicion = _tomoEdicionRepository.GetDetalleTE(item.DetalleId);
                                //    if (edicion != null)
                                //    {
                                //        if (edicion.Stock < item.Cantidad)
                                //        {
                                //            detalleSinExistencias.Add(item);
                                //        }
                                //    }
                                  // break;
                            }
                        }
                    }
                }
            }
            return detalleSinExistencias;
        }

        private List<Producto> ValidarStock(List<ListaFacturacion> listado)
        {
            List<Producto> productosSinExistencias = new List<Producto>();
            foreach (var fact in listado)
            {
                if (fact.Temporales)
                {
                    switch (fact.IdTipoDocumento)
                    {
                        case 16:
                        case 17:
                            var detallesSolicitud = _solicitudesRepository.GetDetallebySolicitud((Guid)fact.IdDocumento);
                            foreach (var item in detallesSolicitud)
                            {
                                var producto = _productosRepository.Get((int)item.ProductoId);
                                if (producto.Stock < item.Cantidad)
                                {
                                    productosSinExistencias.Add(producto);
                                }
                            }
                            break;
                        case 21:
                            var detallescotizacion = _cotizacionRepository.GetListDetalleCotiz((Guid)fact.IdDocumento);
                            foreach (var item in detallescotizacion)
                            {
                                var producto = _productosRepository.Get((int)item.ProductoId);
                                if (producto.Stock < item.Cantidad)
                                {
                                    productosSinExistencias.Add(producto);
                                }
                            }
                            break;
                        case 22:
                            var asigvale = _valesRepository.GetAsignacionVale((Guid)fact.IdDocumento).FirstOrDefault();
                            var detallesVale = _valesRepository.GetListadoDetalleVales(asigvale.Id);
                            foreach (var item in detallesVale)
                            {
                                var producto = _productosRepository.Get((int)item.ProductoId);
                                if (producto.Stock < item.Cantidad)
                                {
                                    productosSinExistencias.Add(producto);
                                }
                            }
                            break;
                    }
                }
            }
            return productosSinExistencias;
        }

        private void EvaluarExistenciasParaCobro(List<ListaFacturacion> listado)
        {
            List<Producto> productos = ValidarStock(listado);
            List<DetalleProducto> detalles = ExistenciasDetalle(listado);
            if (productos.Count() == 0 && detalles.Count() == 0)
            {
                Cobro(listado);
            }
            else
            {
                string mensaje = "No hay existencias suficientes de los productos:";
                string listDetalles = "";
                if (detalles.Count() > 0)
                {
                    foreach (var detalleProducto in detalles)
                    {
                        var prod = _productosRepository.Get(detalleProducto.ProductoId);
                        listDetalles = listDetalles + "\n" + prod.Descripcion + " - " + detalleProducto.TipoDetalle + ": " + detalleProducto.Detalle;
                    }
                }
                else if (productos.Count() > 0)
                {
                    foreach (var producto in productos)
                    {
                        listDetalles += listDetalles + "\n" + producto.Descripcion;
                    }
                }

                mensaje += listDetalles;


                MessageBox.Show(mensaje, "Notificación");
            }
        }

        private void MostrarDetalle()
        {
            Int32 selectedCellCount =
            DgvEncabezadosDoc.GetCellCount(DataGridViewElementStates.Selected);
            var fila = DgvEncabezadosDoc.CurrentRow;
            if (selectedCellCount > 0 && fila != null)
            {
                ListaFacturacion documento = (ListaFacturacion)fila.DataBoundItem;
                lbNoDocumento.Visible = true;
                lbNoDocumento.Text = "No. " + documento.Documento;
                CargarDocumento(documento.IdTipoDocumento, documento.IdDocumento);
            }
            else
            {
                lbNoDocumento.Visible = false;
                MessageBox.Show("Debe seleccionar un documento", "Notificación");
            }
        }

        private void DgvEncabezadosDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarDetalle();
        }

        private void BtnBuscarFecha_Click(object sender, EventArgs e)
        {
            BuscarFecha(dtpFechaInicio.Value, dtpFechaFinal.Value);
        }

        #endregion

    }
}
