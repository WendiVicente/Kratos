using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.ProductosToFacturar;
using CapaDatos.Models.Cotizacion;
using CapaDatos.Models.Vales;
using CapaDatos.Repository;
using CapaDatos.Repository.SolicitudestoFacturar;
using CapaDatos.WebServiceSAT;
using Microsoft.Reporting.WinForms;
using sharedDatabase.Models;

namespace POS.Forms
{
    public partial class DocumentoPOS : BaseContext
    {
        private ProductosRepository _productosRepository = null;
        private SolicitudesRepository _solicitudesRepository = null;
        private CotizacionRepository _cotizacionesRepository = null;
        private ValesRepository _valesRepository = null;
        private ClientesRepository _clientesRepository = null;
        private RepositoryUsuarios _usuariosRepository = null;
        private EmisorFEL _emisor = null;
        public Cliente _cliente = null;

        private string _noDocumento = "";
        private int _idtipoDocumento = 0;

        //parametros
        private string _vendedor;
        private DateTime _fechaVenta;
        private string _Total;
        private string _Descuento;
        private decimal _TotalSinDescuento;
        private string _Porcentaje;
        private bool _mostrarImg;
        //private string _formaPago;
        //private string _Efectivo;
        //private string _Cambio;
        

        public DocumentoPOS(string noDocumento, int idTipoDocumento, bool Img)
        {
            _noDocumento = noDocumento;
            _idtipoDocumento = idTipoDocumento;
            _cliente = new Cliente();
            _emisor = new EmisorFEL(1);
            _mostrarImg = Img;
            _productosRepository = new ProductosRepository(_context);
            _solicitudesRepository = new SolicitudesRepository(_context);
            _cotizacionesRepository = new CotizacionRepository(_context);
            _valesRepository = new ValesRepository(_context);
            _clientesRepository = new ClientesRepository(_context);
            _usuariosRepository = new RepositoryUsuarios(_context);
            InitializeComponent();
        }

        private void CargarTabla()
        {
            IList<ListaDocumento> listaDocumentos = new List<ListaDocumento>();

            switch (_idtipoDocumento)
            {
                case 16:
                    listaDocumentos = CargarSolicitud(_noDocumento);
                    break;
                case 17:
                    listaDocumentos = CargarSolicitud(_noDocumento);
                    break;
                case 21:
                    listaDocumentos = CargarCotizacion(_noDocumento);
                    break;
                case 22:
                    listaDocumentos = CargarVale(_noDocumento);
                    break;
            }            

            rvDocumentoPOS.LocalReport.ReportEmbeddedResource = Reporte();
            var rds1 = new ReportDataSource("DataSetProductoDoc", listaDocumentos);
            rvDocumentoPOS.LocalReport.DataSources.Clear();
            rvDocumentoPOS.LocalReport.DataSources.Add(rds1);
        }


        private string Reporte()
        {
            string reporte = "POS.Forms.Complementos.DocumentoPOS.rdlc";
            if (_mostrarImg)
                reporte = "POS.Forms.Complementos.DocumentoPOSIMG.rdlc";
            return reporte;
        }

        private List<ListaDocumento> CargarSolicitud(string noDocumento)
        {
            List<ListaDocumento> listado = new List<ListaDocumento>();
            try
            {                
                ListaDocumento documento = new ListaDocumento();
                var solicitudes = _solicitudesRepository.GetSolicitudes(UsuarioLogeadoPOS.User.SucursalId);
                SolicitudToFacturar solicitud = null;
                if (solicitudes.Count() > 0)
                {
                    var sol = solicitudes.Where(x => x.NoSolicitud == noDocumento);
                    if(sol.Count() > 0)
                    {
                        solicitud = _solicitudesRepository.Get(sol.FirstOrDefault().Id);
                    }
                }

                if (solicitud != null)
                {
                    var usuario = _usuariosRepository.Get(solicitud.UserId);
                    _vendedor = usuario.Name;
                    _fechaVenta = solicitud.FechaVenta;
                    if (solicitud.ClienteId > 0)
                    {
                        _cliente = _clientesRepository.Get(solicitud.ClienteId);
                    }
                    else
                    {
                        _cliente = new Cliente
                        {
                            Nombres = solicitud.NombreCliente,
                            Direccion = solicitud.DireccionCliente,
                            Nit = solicitud.NitCliente
                        };
                    }
                    var detallesolicitudes = _solicitudesRepository.GetDetallebySolicitud(solicitud.Id);
                    decimal descuentoT = 0.00m;
                    foreach (SolicitudDetalle item in detallesolicitudes)
                    {
                        var producto = _productosRepository.Get((int)item.ProductoId);                      

                        decimal pDescuento = 0.00m;
                        if (item.Descuento > 0)
                        {
                            descuentoT += descuentoT;
                            pDescuento = item.Precio - (item.Descuento / item.Cantidad);
                        }
                        documento.Imagen = producto.Imagen;
                        documento.ProductoId = producto.Id;
                        documento.Descripcion = producto.Descripcion;
                        documento.Cantidad = item.Cantidad;
                        documento.Precio = producto.PrecioVenta;
                        documento.Rebaja = pDescuento;
                        documento.Descuento = pDescuento * item.Cantidad;
                        documento.Subtotal = item.SubTotal;
                        listado.Add(documento);
                        documento = new ListaDocumento();
                    }
                    CalcularParametros(listado);
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
            return listado;
        }

        private List<ListaDocumento> CargarCotizacion(string noDocumento)
        {
            List<ListaDocumento> listado = new List<ListaDocumento>();
            try
            {

                ListaDocumento documento = new ListaDocumento();
                var Cotizaciones = _cotizacionesRepository.GetListGenerales(UsuarioLogeadoPOS.User.SucursalId);
                Cotizacion Cotizacion = null;
                if (Cotizaciones.Count() > 0)
                {
                    var cot = Cotizaciones.Where(x => x.NoCotizacion == noDocumento);
                    if (cot.Count() > 0)
                    {
                        Cotizacion = _cotizacionesRepository.GetCotizacion(cot.FirstOrDefault().Id);
                    }
                }

                if (Cotizacion != null)
                {
                    var usuarios = _usuariosRepository.GetlistaUsuarios();
                    var usuario = usuarios.Where(x => x.Name == Cotizacion.NombreVendedor).FirstOrDefault();
                    _vendedor = usuario.Name;
                    _fechaVenta = Cotizacion.FechaRecepcion;
                    if (Cotizacion.ClienteId > 0)
                    {
                        _cliente = _clientesRepository.Get(Cotizacion.ClienteId);
                    }
                    else
                    {
                        _cliente = new Cliente
                        {
                            Nombres = Cotizacion.Nombre +" "+ Cotizacion.Apellido,
                            Direccion = Cotizacion.Direccion,
                            Nit = Cotizacion.Nit
                        };
                    }
                    var detalleCotizaciones = _cotizacionesRepository.GetDetalleCotizacionslista(Cotizacion.Id);
                    decimal descuentoT = 0.00m;
                    foreach (DetalleCotizacion item in detalleCotizaciones)
                    {
                        var producto = _productosRepository.Get((int)item.ProductoId);

                        decimal pDescuento = 0.00m;
                        if (item.Descuento > 0)
                        {
                            descuentoT += descuentoT;
                            pDescuento = item.Precio - (item.Descuento / item.Cantidad);
                        }
                        documento.Imagen = producto.Imagen;
                        documento.ProductoId = producto.Id;
                        documento.Descripcion = producto.Descripcion;
                        documento.Cantidad = item.Cantidad;
                        documento.Precio = producto.PrecioVenta;
                        documento.Rebaja = pDescuento;
                        documento.Descuento = pDescuento * item.Cantidad;
                        documento.Subtotal = item.PrecioTotal;
                        listado.Add(documento);
                        documento = new ListaDocumento();
                    }
                    CalcularParametros(listado);
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
            return listado;
        }

        private List<ListaDocumento> CargarVale(string noDocumento)
        {
            List<ListaDocumento> listado = new List<ListaDocumento>();
            try
            {

                ListaDocumento documento = new ListaDocumento();
                var Vales = _valesRepository.GetListaVales(UsuarioLogeadoPOS.User.SucursalId);
                AsignacionVale AsigVale = null;
                if (Vales.Count() > 0)
                {
                    var val = Vales.Where(x => x.NoVale == noDocumento);
                    if (val.Count() > 0)
                    {
                        var usuarios = _usuariosRepository.GetlistaUsuarios();
                        var usuario = usuarios.Where(x => x.Name == val.FirstOrDefault().Usuario).FirstOrDefault();
                        _vendedor = usuario.Name;
                        _fechaVenta = val.FirstOrDefault().FechaRecepcion;
                        AsigVale = _valesRepository.GetAsignacionVale(val.FirstOrDefault().Id).FirstOrDefault();
                    }
                }

                if (AsigVale != null)
                {
                    if (AsigVale.ClienteId > 0)
                    {
                        _cliente = _clientesRepository.Get((int)AsigVale.ClienteId);
                    }
                    else
                    {
                        _cliente = new Cliente
                        {
                            Nombres = AsigVale.Nombre + " " + AsigVale.Apellido,
                            Direccion = AsigVale.Direccion,
                            Nit = AsigVale.Nit
                        };
                    }
                    var detalleCotizaciones = _cotizacionesRepository.GetDetalleCotizacionslista(AsigVale.Id);
                    decimal descuentoT = 0.00m;
                    foreach (DetalleCotizacion item in detalleCotizaciones)
                    {
                        var producto = _productosRepository.Get((int)item.ProductoId);

                        decimal pDescuento = 0.00m;
                        if (item.Descuento > 0)
                        {
                            descuentoT += descuentoT;
                            pDescuento = item.Precio - (item.Descuento / item.Cantidad);
                        }
                        documento.Imagen = producto.Imagen;
                        documento.ProductoId = producto.Id;
                        documento.Descripcion = producto.Descripcion;
                        documento.Cantidad = item.Cantidad;
                        documento.Precio = producto.PrecioVenta;
                        documento.Rebaja = pDescuento;
                        documento.Descuento = pDescuento * item.Cantidad;
                        documento.Subtotal = item.PrecioTotal;
                        listado.Add(documento);
                        documento = new ListaDocumento();
                    }
                    CalcularParametros(listado);
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
            return listado;
        }

        private decimal CalcularDescuentos(List<ListaDocumento> listado)
        {
            decimal p1 = 0.00m;
            decimal p2 = 0.00m;
            decimal resultado = 0.00m;
            decimal descuento = 0.00m;
            foreach (var item in listado)
            {
                if (item.Rebaja > 0.01m)
                {
                    p1 = item.Precio;
                    p2 = item.Rebaja;
                    if (p1 > p2 && p2 >= 0.01m)
                    {
                        resultado = p1 - p2;
                        descuento += (resultado * item.Cantidad);
                    }
                }
                _TotalSinDescuento += (item.Precio * item.Cantidad);
            }
            return descuento;
        }

        private void CalcularParametros(List<ListaDocumento> listado)
        {
            decimal desc = decimal.Round(CalcularDescuentos(listado), 2);
            _Total = "Q " +listado.Sum(x => x.Subtotal);
            _Descuento = "Q "+desc;
            _Porcentaje = decimal.Round((desc * 100 / _TotalSinDescuento), 2) + "%";
        }

        public void cargarParametros()
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                 new ReportParameter("NombreCliente",_cliente.Nombres.Trim()),
                 new ReportParameter("DireccionCliente",_cliente.Direccion.Trim()),
                 new ReportParameter("NitCliente",_cliente.Nit.Trim()),
                 //new ReportParameter("NombreCliente","CF"),
                 //new ReportParameter("DireccionCliente","CF"),
                 //new ReportParameter("NitCliente","CF"),
                 new ReportParameter("NoDocumento",_noDocumento),
                 new ReportParameter("Nit",_emisor.EmisorFACT.nitemisor),
                 new ReportParameter("Vendedor",_vendedor),
                 new ReportParameter("FechaVenta",_fechaVenta.ToString()),
                 new ReportParameter("Total",_Total),
                 new ReportParameter("Descuento",_Descuento),
                 new ReportParameter("Porcentaje",_Porcentaje),

                 //new ReportParameter("FormaPago","asdf"),
                 //new ReportParameter("Total","asdf"),
                 //new ReportParameter("Efectivo","asdf"),
                 //new ReportParameter("Cambio","asdf"),
                 // new ReportParameter("estado",estadoActual),
            };
            rvDocumentoPOS.LocalReport.SetParameters(reportParameters);
        }

        private void DocumentoPOS_Load(object sender, EventArgs e)
        {
            CargarTabla();
            cargarParametros();
            this.rvDocumentoPOS.RefreshReport();
        }

        private string CargarImagen(byte[] img)
        {
            /**
             * *
             */
            return "";
        }
    }
}
