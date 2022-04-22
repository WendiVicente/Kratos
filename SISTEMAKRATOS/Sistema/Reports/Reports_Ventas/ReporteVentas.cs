using CapaDatos.ListasPersonalizadas;
using CapaDatos.ListasPersonalizadas.VentasAcumuladas;
using CapaDatos.Repository;
using Microsoft.Reporting.WinForms;
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

namespace Sistema.Reports.Reports_Ventas
{
    public partial class ReporteVentas : BaseContext
    {
        private readonly ProductosRepository _productoRepository = null;
        private readonly FacturasRepository _facturasRepository = null;
        private readonly CategoriaProdRepository _categoriaProdRepository = null;

        DateTime FechaInicio;
        DateTime FechaFin;
        

        public ReporteVentas()
        {
            _productoRepository = new ProductosRepository(_context);
            _facturasRepository = new FacturasRepository(_context);
            _categoriaProdRepository = new CategoriaProdRepository(_context);
            InitializeComponent();
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {

            cargarcombocategoria();
        }

        private void cargarcombocategoria()
        {
            var listacategoria = _categoriaProdRepository.GetListcategoria();

            listacategoria.Add(new ListarCategoriaProd { Id = 0, Categoria = "Todas" });
            var s = listacategoria.OrderBy(a => a.Id).ToList();

            cbCategoria.DataSource = listacategoria;
            cbCategoria.ValueMember = "Id";
            cbCategoria.DisplayMember = "Categoria";
            cbCategoria.SelectedValue = 0;

        }

        private IList<DetalleFactura> listdetalleFac = null;
        private void CargarTabla()
        {
            FechaInicio = dtpFechaInicio.Value.Date + new TimeSpan(0, 0, 0);
            FechaFin = dtpFechaFinal.Value.Date + new TimeSpan(23, 59, 59);
            var listadoDetalleObtenido = new List<ListarDetalleFacturas>();
            listdetalleFac = new List<DetalleFactura>();
            var listaventastosee = new List<ListadoVentasProducto>();
            var listadoFacturaEncabezado = _facturasRepository.GetFacturastoReporte(FechaInicio, FechaFin, chktodasf.Checked);
            if(listadoFacturaEncabezado!= null)
            {
                foreach (var item1 in listadoFacturaEncabezado)
                {
                    var detalleVenta = _facturasRepository.getdetallelista(item1.Id,Convert.ToInt32(cbCategoria.SelectedValue.ToString()));
                    if (detalleVenta!=null){
                        foreach (var item in detalleVenta)
                        {
                            listdetalleFac.Add(item);
                        }
                    }                   
                }
            }

            if (listdetalleFac != null)
            {               
                foreach (var item in listdetalleFac)
                {
                    var detalle = new ListadoVentasProducto();
                    Producto producto = new Producto();
                    if (item.ProductoId != null)
                    {

                        producto = _productoRepository.Get(detalle.ProductoId);

                        detalle.Categoria = item.Producto.Categoria.Nombre;
                        //detalle.Cliente = item.Factura.Cliente.Nombres;
                        detalle.Descripcion = item.ProductoId == null ? item.Combo.Descripcion : item.Producto.Descripcion;
                        detalle.ProductoId = item.ProductoId == null ? 0 : (int)item.ProductoId;
                        detalle.comboid = item.ProductoId == null ? (Guid)item.ComboId : Guid.Empty;
                        detalle.Subtotal = item.PrecioTotal;
                        detalle.UnidadesVendidas = item.Cantidad;
                        detalle.Utilidad = _productoRepository.Get(detalle.ProductoId).Utilidad * item.Cantidad;
                        detalle.CostoVenta = _productoRepository.Get(detalle.ProductoId).Coste * item.Cantidad;
                        detalle.UnidadMedida = _productoRepository.Get(detalle.ProductoId).UnidadMedida;

                        if (listaventastosee.Where(x => x.ProductoId == detalle.ProductoId).FirstOrDefault() == null)
                        {
                            listaventastosee.Add(detalle);
                        }
                        else
                        {
                            foreach (var detalletoUpdate in listaventastosee.Where(x => x.ProductoId == detalle.ProductoId))
                            {
                                detalletoUpdate.UnidadesVendidas += item.Cantidad;
                                detalletoUpdate.Subtotal += item.PrecioTotal;
                            }
                        }
                    }
                }
            }
            string reporte = "";
            if (checkUtilidades.Checked)
            {
                foreach (var item in listaventastosee)
                {
                    var prod = _productoRepository.Get(item.ProductoId);
                    decimal ventaSinIVA = item.Subtotal - (item.Subtotal * 0.12m);
                    decimal totalCosto = prod.Coste * item.UnidadesVendidas;
                    item.Subtotal = decimal.Round(ventaSinIVA, 3);
                    item.Utilidad = decimal.Round((ventaSinIVA - totalCosto), 3);
                    item.CostoVenta = decimal.Round(totalCosto, 3);
                    item.Porcentaje = decimal.Round(((item.Utilidad * 100) / item.Subtotal), 2);
                }
                reporte = "Sistema.Reports.Reports_Ventas.ReporteUtilidad.rdlc";
            }
            else
            {
                foreach (var item in listaventastosee)
                {
                    var prod = _productoRepository.Get(item.ProductoId);
                    decimal ventaIVA = item.Subtotal;
                    decimal totalCosto = prod.Coste * item.UnidadesVendidas;
                    item.Subtotal = decimal.Round(ventaIVA, 3);
                    item.Utilidad = decimal.Round((ventaIVA - totalCosto), 3);
                    item.CostoVenta = decimal.Round(totalCosto, 3);
                    item.Porcentaje = decimal.Round(((item.Utilidad * 100) / item.Subtotal), 2);
                }
                reporte = "Sistema.Reports.Reports_Ventas.ReporteVentas.rdlc";
            }

            

            listaventastosee = listaventastosee.OrderBy(x => x.Categoria).ToList();
            rvVentas.LocalReport.ReportEmbeddedResource = reporte;
            var rds1 = new ReportDataSource("DataSetVentas", listaventastosee);
            rvVentas.LocalReport.DataSources.Clear();
            rvVentas.LocalReport.DataSources.Add(rds1);

        }
        public void cargarTextbox()
        {
            string fechainicio = FechaInicio.Day + "/" + FechaInicio.Month + "/" + FechaInicio.Year;
            string fechafin = FechaFin.Day + "/" + FechaFin.Month + "/" + FechaFin.Year;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {

                 new ReportParameter("usuario",UsuarioLogeadoSistemas.User.Name),
                 new ReportParameter("nombreVendedor",UsuarioLogeadoSistemas.User.UserName),
                 new ReportParameter("sucursal",UsuarioLogeadoSistemas.User.Sucursal.NombreSucursal),
                 new ReportParameter("FechaInicio",fechainicio),
                 new ReportParameter("FechaFin",fechafin),
                // new ReportParameter("estado",estadoActual),

            };
            rvVentas.LocalReport.SetParameters(reportParameters);

        }

        private void btnGeneraReporte_Click(object sender, EventArgs e)
        {
            CargarTabla();
            cargarTextbox();
            rvVentas.RefreshReport();
        }

        private List<ListaProductosCategoria> ListadoProducto(List<ListadoVentasProducto> listadoVentas)
        {
            List<ListaProductosCategoria> PorCategoria = new List<ListaProductosCategoria>();
            List<ListadoVentasProducto> listado = new List<ListadoVentasProducto>();
            ListaProductosCategoria prodcategoria = new ListaProductosCategoria();
            var Categorias = _categoriaProdRepository.GetListcategoria();

            foreach (var item in Categorias)
            {
                string categoria = item.Categoria;
                listado = listadoVentas.Where(x => x.Categoria == item.Categoria).ToList();
                prodcategoria = new ListaProductosCategoria
                {
                    CategoriaProducto = categoria,
                    listadoVentas = listado
                };
                PorCategoria.Add(prodcategoria);

            }
            return PorCategoria;
        }



    }
}

