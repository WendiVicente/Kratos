using CapaDatos.ListasPersonalizadas;
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

namespace Sistema.Reports.Reports_Productos
{
    public partial class ReporteProducto : BaseContext
    {
        private ProductosRepository _productosRepository = null;
        private SucursalesRepository _sucursalesRepository = null;
        private ColoresRepository _coloresRepository = null;

        DateTime fechaInicio, fechaFinal;
       

        public ReporteProducto()
        {
            _coloresRepository = new ColoresRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            _sucursalesRepository = new SucursalesRepository(_context);
            InitializeComponent();
        }

        private void ReporteProducto_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarSucursales();
            checkfechas.Checked = true;

            this.rvproductos.RefreshReport();
        }

        public void CargarCategorias()
        {
             var categoria = _productosRepository.GetCategoriasList();
            if (categoria == null) return;

            categoria.Add(new Categoria { Id = 0, Nombre = "Todas" });
            var s = categoria.OrderBy(a => a.Id).ToList();

            cbcategoria.DataSource = s;
            cbcategoria.DisplayMember = "Nombre";
            cbcategoria.ValueMember = "Id";
           // cbsucursales.Text = "Seleccione una categoria"; // esto no jalo? no me jalo
            cbcategoria.SelectedIndex = 0;
            cbcategoria.Invalidate();
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
            //cbsucursales.Text = "Seleccione una Sucursal"; // esto no jalo? no me jalo
            cbsucursales.SelectedIndex = 0;
            cbsucursales.Invalidate();
        }

        private void checkfechas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkfechas.Checked == false)
            {
                dtpfechainicio.Enabled = true;
                dtpfechafinal.Enabled = true;
            }
            else
            {
                dtpfechainicio.Enabled = false;
                dtpfechafinal.Enabled = false;
            }
        }

        private void btngenerar_Click(object sender, EventArgs e)
        {

            CargarTabla();
            cargarTextbox();
            this.rvproductos.RefreshReport();
        }

        private void CargarTabla()
        {
             fechaInicio = dtpfechafinal.Value;
             fechaFinal = dtpfechafinal.Value;
            var sucursalId = int.Parse(cbsucursales.SelectedValue.ToString());
            var categoriaId = int.Parse(cbcategoria.SelectedValue.ToString());
            var orderByAscen = rbAscent.Checked;
            var orderByDescen = rbDescen.Checked;
            var allFechas = checkfechas.Checked;


            var listadeProductos = _productosRepository.GetList(0);//GetListReportes(sucursalId,categoriaId,allFechas,fechaInicio,fechaFinal,orderByDescen,orderByAscen);//fechaInicio, fechaFinal.AddDays(1));
           // var searchByColor = listadeProductos.Where(x => x.IncluyeColor == "Sí").ToList();
            
            //con los valores obtenidos busco en tabla detallecolor el proudcto y le cambio el stock

            foreach(var item in listadeProductos.Where(x => x.IncluyeColor == "Sí"))
            {
                var producto = item;
                var productoObtenido = _coloresRepository.GetColor(item.Id);
                item.Stock = productoObtenido.Stock;
               // searchByColor.Remove(item);
               // searchByColor.Add(producto);
               
            }
            

            rvproductos.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Productos.ReporteProducto.rdlc";
            var rds1 = new ReportDataSource("listaproductos", listadeProductos);
            rvproductos.LocalReport.DataSources.Clear();
            rvproductos.LocalReport.DataSources.Add(rds1);
        }

        public void cargarTextbox()
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                new ReportParameter("sucursal",cbsucursales.Text),
                new ReportParameter("categoria",cbcategoria.Text),
                 new ReportParameter("fechainicio",fechaInicio.ToString()),
                  new ReportParameter("fechafinal",fechaFinal.ToString())
            };
            rvproductos.LocalReport.SetParameters(reportParameters);

        }


    }
}
