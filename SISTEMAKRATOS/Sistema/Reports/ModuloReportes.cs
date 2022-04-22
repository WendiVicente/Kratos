using CapaDatos.ListasPersonalizadas;
using CapaDatos.ListasPersonalizadas.VentasAcumuladas;
using CapaDatos.ListasPersonalizadas.Prestamos;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos.Repository;

namespace Sistema.Reports
{
    public partial class ModuloReportes : BaseContext
    {
        private SucursalesRepository _sucursalesRepository = null;
        private IList<ListarProductos> Productos = null;
        private ProductosRepository _productosRepository = null;
        private IList<ListarClientes> clientes = null;  //objeto vacio
        private ClientesRepository _clientesRepository = null;

        public ModuloReportes()
        {
            _clientesRepository = new ClientesRepository(_context);
            Productos = new List<ListarProductos>();
            _sucursalesRepository = new SucursalesRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            clientes = new List<ListarClientes>();
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            MenuPrincipal(this);
        }

        private void ModuloReportes_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuPrincipal(this, false);
        }

        private void ModuloReportes_Load(object sender, EventArgs e)
        {

            //this.reportClientes.RefreshReport();
            this.ReporteClientes.RefreshReport();
            this.ReporteProductos.RefreshReport();
            this.ReporteProveedores.RefreshReport();
            this.ReportePagos.RefreshReport();
            this.ReportePersonal.RefreshReport();
            this.ReportePrestamos.RefreshReport();
            this.ReporteCompras.RefreshReport();
            this.ReporteVentas.RefreshReport();
            this.ReporteCaja.RefreshReport();
        }

        private void ReporteClientes_Load(object sender, EventArgs e)
        {
            //CargarTabla();
            //cargarTextbox();           
        }

        private void CargarTablaClientes()
        {
         
            clientes = _clientesRepository.GetListTodos();
            //IList<ListadoVentasProducto> ventas = new List<ListadoVentasProducto>(); //objeto vacio
            //IList<ListarClientes> clientes = new List<ListarClientes>(); //objeto vacio
            ReporteCliente.LocalReport.ReportEmbeddedResource = "Sistema.Reports.ReporteClientes.rdlc";
            var rds1 = new ReportDataSource("listaclientesseleccionados", clientes);
            ReporteCliente.LocalReport.DataSources.Clear();
            ReporteCliente.LocalReport.DataSources.Add(rds1);
        }
        public void cargarTextboxClientes()
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                
                new ReportParameter("NombreCliente","Daniel"),
                new ReportParameter("DirecciónCliente",""),
                new ReportParameter("NitCliente","5932037"),
                new ReportParameter("usuario",UsuarioLogeadoSistemas.User.UserName),
                new ReportParameter("FechaVenta","05/11/2021"),

            };
            ReporteClientes.LocalReport.SetParameters(reportParameters);
        }

        private void CargarSucursales()
        {
            var sucursal = _sucursalesRepository.GetList();

            // agregar nuevo item a la lista
            sucursal.Add(new ListarSucursales { Id = 0, NombreSucursal = "Todas" });
            var s = sucursal.OrderBy(a => a.Id).ToList();

            // mostrar datos en dgv
            cbsucursales.DataSource = s;
            cbsucursales.DisplayMember = "NombreSucursal";
            cbsucursales.ValueMember = "Id";
            //cbsucursales.Text = "Seleccione una Sucursal"; // 
            cbsucursales.SelectedIndex = 0;
            cbsucursales.Invalidate();
        }
        private void BtnCliente_Click_1(object sender, EventArgs e)
        {
            CargarTablaClientes();
            //cargarTextboxClientes();
            this.ReporteCliente.RefreshReport();
        }

        private void ReporteProductos_Load(object sender, EventArgs e)
        {
            //CargarTabla();
            //cargarTextbox();


        }
        private void CargarTablaProductos()
        {
            Productos = _productosRepository.GetList(UsuarioLogeadoSistemas.User.SucursalId);
            ReporteProductos.LocalReport.ReportEmbeddedResource = "Sistema.Reports.ReporteProductos.rdlc";
            var rds1 = new ReportDataSource("DataSetProductos", Productos);
            ReporteProductos.LocalReport.DataSources.Clear();
            ReporteProductos.LocalReport.DataSources.Add(rds1);
        }
        public void cargarTextboxProductos()
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {

                new ReportParameter("EstadoActual","Activo"),
                new ReportParameter("Tipo","Libreria"),
                new ReportParameter("Sucursal","Central"),
                new ReportParameter("usuario",UsuarioLogeadoSistemas.User.UserName),
                new ReportParameter("FechaInicio","05/11/2021"),
                new ReportParameter("FechaFin","05/11/2021"),

            };
            ReporteProductos.LocalReport.SetParameters(reportParameters);
        }
        private void BtnProductos_Click(object sender, EventArgs e)
        {
           
            CargarTablaProductos();
            cargarTextboxProductos();
            this.ReporteProductos.RefreshReport();
        }


        private void ReporteProveedores_Load(object sender, EventArgs e)
            {
                //CargarTabla();
                //cargarTextbox();


            }
            private void CargarTablaProveedores()
            {
            ReporteProveedores.LocalReport.ReportEmbeddedResource = "Sistema.Reports.ReporteProveedores.rdlc";
            IList<ListarProveedores> Proveedor = new List<ListarProveedores>(); //objeto vacio
                var rds1 = new ReportDataSource("DataSetProveedores", Proveedor);
                ReporteProveedores.LocalReport.DataSources.Clear();
                ReporteProveedores.LocalReport.DataSources.Add(rds1);
            }
            public void cargarTextboxProveedores()
            {
                ReportParameterCollection reportParameters = new ReportParameterCollection
            {

                new ReportParameter("NombreProveedor","Dayanna"),
                new ReportParameter("DirecciónProveedor","11 calle av 25 zona 1"),
                new ReportParameter("NitProveedor","59327103"),
                new ReportParameter("Sucursal","Central"),
                new ReportParameter("usuario",UsuarioLogeadoSistemas.User.UserName),
                new ReportParameter("FechaInicio","05/11/2021"),
                new ReportParameter("FechaFin","05/11/2021"),

            };
                ReporteProveedores.LocalReport.SetParameters(reportParameters);
            }
        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            CargarTablaProveedores();
            cargarTextboxProveedores();
            this.ReporteProveedores.RefreshReport();

        }

        
        private void ReportePagos_Load(object sender, EventArgs e)
        {
            //CargarTabla();
            //cargarTextbox();


        }
        private void CargarTablaPagosBancos()
        {
            ReportePagos.LocalReport.ReportEmbeddedResource = "Sistema.Reports.ReportePagosBancos.rdlc";
            IList<ListarTransacciones> Bancos = new List<ListarTransacciones>(); //objeto vacio
            var rds1 = new ReportDataSource("DataSetBancos", Bancos);
            ReportePagos.LocalReport.DataSources.Clear();
            ReportePagos.LocalReport.DataSources.Add(rds1);
        }
        public void cargarTextboxPagosBancos()
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {

                new ReportParameter("Movimiento","Activo"),
                new ReportParameter("Estado","Activo"),
                new ReportParameter("Sucursal","Central"),
                new ReportParameter("usuario",UsuarioLogeadoSistemas.User.UserName),
                new ReportParameter("FechaInicio","05/11/2021"),
                new ReportParameter("FechaFin","05/11/2021"),

            };
            ReportePagos.LocalReport.SetParameters(reportParameters);
            }
        private void BtnPagos_Click_1(object sender, EventArgs e)
        {
            CargarTablaPagosBancos();
            cargarTextboxPagosBancos();
            this.ReportePagos.RefreshReport();
        }

       
        private void ReportePersonal_Load(object sender, EventArgs e)
        {
            //CargarTabla();
            //cargarTextbox();


        }
        private void CargarTablaPersonal()
        {
            ReportePersonal.LocalReport.ReportEmbeddedResource = "Sistema.Reports.ReportePersonal.rdlc";
            IList<ListarPersonal> salario = new List<ListarPersonal>(); //objeto vacio   
            var rds1 = new ReportDataSource("DataSetSalario", salario);
            ReportePersonal.LocalReport.DataSources.Clear();
            ReportePersonal.LocalReport.DataSources.Add(rds1);
        }
        public void cargarTextboxPersonal()
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {

                new ReportParameter("NombrePersonal",""),
                new ReportParameter("DirecciónPersonal","11av"),
                new ReportParameter("NitPersonal","59327103"),
                new ReportParameter("usuario",UsuarioLogeadoSistemas.User.UserName),
                new ReportParameter("FechaInicio","05/11/2021"),
                new ReportParameter("FechaFin","05/11/2021"),

            };
            ReportePersonal.LocalReport.SetParameters(reportParameters);
        }

        private void BtnSalario_Click_1(object sender, EventArgs e)
        {
            CargarTablaPersonal();
            cargarTextboxPersonal();
            this.ReportePersonal.RefreshReport();

        }
        private void ReporteCompras_Load(object sender, EventArgs e)
        {
            //CargarTabla();
            //cargarTextbox();


        }
        private void CargarTablaCompras()
        {
            ReporteCompras.LocalReport.ReportEmbeddedResource = "Sistema.Reports.ReporteCompras.rdlc";
            IList<ListarCompras> Compra = new List<ListarCompras>(); //objeto vacio
            var rds1 = new ReportDataSource("DataSetCompras", Compra);
            ReporteCompras.LocalReport.DataSources.Clear();
            ReporteCompras.LocalReport.DataSources.Add(rds1);
        }
        public void cargarTextboxCompras()
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {

                new ReportParameter("NombreVendedor","Dayanna"),
                new ReportParameter("Sucursal","Central"),
                new ReportParameter("usuario",UsuarioLogeadoSistemas.User.UserName),
                new ReportParameter("FechaInicio","05/11/2021"),
                new ReportParameter("FechaFin","05/11/2021"),

            };

            ReporteCompras.LocalReport.SetParameters(reportParameters);
        }
       

        private void BtnCompras_Click(object sender, EventArgs e)
        {
            CargarTablaCompras();
            cargarTextboxCompras();
            this.ReporteCompras.RefreshReport();

        }
        private void ReporteVentas_Load(object sender, EventArgs e)
        {
            //CargarTabla();
            //cargarTextbox();


        }
        private void CargarTablaVentas()
        {
            ReporteVentas.LocalReport.ReportEmbeddedResource = "Sistema.Reports.ReporteVentas.rdlc";
            IList<ListadoVentasProducto> Ventas = new List<ListadoVentasProducto>(); //objeto vacio
            var rds1 = new ReportDataSource("DataSetVentas", Ventas);
            ReporteVentas.LocalReport.DataSources.Clear();
            ReporteVentas.LocalReport.DataSources.Add(rds1);
        }
        public void cargarTextboxVentas()
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {

                new ReportParameter("NombreVendedor","Dayanna"),
                new ReportParameter("Sucursal","Central"),
                new ReportParameter("usuario",UsuarioLogeadoSistemas.User.UserName),
                new ReportParameter("FechaInicio","05/11/2021"),
                new ReportParameter("FechaFin","05/11/2021"),

            };
            ReporteVentas.LocalReport.SetParameters(reportParameters);
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            CargarTablaVentas();
            cargarTextboxVentas();
            this.ReporteVentas.RefreshReport();
        }
        private void ReportePrestamos_Load(object sender, EventArgs e)
        {
            //CargarTabla();
            //cargarTextbox();


        }
        private void CargarTablaPrestamos()
        {
            ReportePrestamos.LocalReport.ReportEmbeddedResource = "Sistema.Reports.ReportePrestamos.rdlc";
            IList<ListarPrestamos> Prestamos = new List<ListarPrestamos>(); //objeto vacio
            var rds1 = new ReportDataSource("DataSetPrestamo", Prestamos);
            ReportePrestamos.LocalReport.DataSources.Clear();
            ReportePrestamos.LocalReport.DataSources.Add(rds1);
        }
        public void cargarTextboxPrestamos()
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {

                new ReportParameter("Amortización","Dayanna"),
                new ReportParameter("PeriodoTime","15 dias"),
                new ReportParameter("EstadoPrestamo","59327103"),
                new ReportParameter("NombreCliente","Dayanna"),
                new ReportParameter("NitCliente","CF"),
                new ReportParameter("Sucursal","Central"),
                new ReportParameter("usuario",UsuarioLogeadoSistemas.User.UserName),
                new ReportParameter("FechaInicio","05/11/2021"),
                new ReportParameter("FechaFin","05/11/2021"),

            };
            ReportePrestamos.LocalReport.SetParameters(reportParameters);
        }
        private void BtnPrestamo_Click(object sender, EventArgs e)
        {
            CargarTablaPrestamos();
            cargarTextboxPrestamos();
            this.ReportePrestamos.RefreshReport();

        }
        private void ReporteCaja_Load(object sender, EventArgs e)
        {
            //CargarTabla();
            //cargarTextbox();


        }
        private void CargarTablaCaja()
        {
            ReporteCaja.LocalReport.ReportEmbeddedResource = "Sistema.Reports.ReporteCaja.rdlc";
            IList<ListarCajaDetalles> Caja = new List<ListarCajaDetalles>(); //objeto vacio
            var rds1 = new ReportDataSource("DataSetCaja", Caja);
            ReporteCaja.LocalReport.DataSources.Clear();
            ReporteCaja.LocalReport.DataSources.Add(rds1);
        }
        public void cargarTextboxCaja()
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {

                new ReportParameter("NombreVendedor","Dayanna"),
                new ReportParameter("Sucursal","Central"),
                new ReportParameter("usuario",UsuarioLogeadoSistemas.User.UserName),
                new ReportParameter("FechaInicio","05/11/2021"),
                new ReportParameter("FechaFin","05/11/2021"),

            };
            ReporteProveedores.LocalReport.SetParameters(reportParameters);
        }
       
        private void BtnCaja_Click(object sender, EventArgs e)
        {
            CargarTablaCaja();
            cargarTextboxCaja();
            this.ReporteCaja.RefreshReport();

        }
    }   
}