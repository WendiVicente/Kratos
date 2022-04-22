using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Productos.Combos;
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

namespace Sistema.Reports.Reports_Combos
{
    public partial class ReporteCombos : BaseContext
    {

        private ProductosRepository _productosRepository = null;
        private SucursalesRepository _sucursalesRepository = null;
        
        private CombosRepository _combosRepository = null;
       // private List<ComboDetalleLista> listadata = null;

        DateTime fechaInicio, fechaFinal;


        public ReporteCombos()
        {
            _combosRepository = new CombosRepository(_context);
          //  _coloresRepository = new ColoresRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            _sucursalesRepository = new SucursalesRepository(_context);
            
            InitializeComponent();
        }

        private void ReporteCombos_Load(object sender, EventArgs e)
        {
            
            CargarSucursales();
            checkfechas.Checked = true;

            this.rvcombos.RefreshReport();
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
      //      cargarTextbox();
            this.rvcombos.RefreshReport();
        }

        private void CargarTabla()
        {
            fechaInicio = dtpfechafinal.Value;
            fechaFinal = dtpfechafinal.Value;
            var sucursalId = int.Parse(cbsucursales.SelectedValue.ToString());
            //var categoriaId = int.Parse(cbcategoria.SelectedValue.ToString());
            var orderByAscen = rbAscent.Checked;
            var orderByDescen = rbDescen.Checked;
            var allFechas = checkfechas.Checked;


            //  var listadeProductos = _productosRepository.GetListReportes(sucursalId, categoriaId, allFechas, fechaInicio, fechaFinal, orderByDescen, orderByAscen);//fechaInicio, fechaFinal.AddDays(1));
            // var searchByColor = listadeProductos.Where(x => x.IncluyeColor == "Sí").ToList();

            //con los valores obtenidos busco en tabla detallecolor el proudcto y le cambio el stock
            /*
            foreach (var item in listadeProductos.Where(x => x.IncluyeColor == "Sí"))
            {
                var producto = item;
                var productoObtenido = _coloresRepository.GetColor(item.Id);
                item.Stock = productoObtenido.Stock;
                // searchByColor.Remove(item);
                // searchByColor.Add(producto);

            }
            */
           // var otralista = _combosRepository.ListaDetalleCombos();

            var listadeCombos = _combosRepository.ListaReporte(sucursalId);
             var listaDetalle = _combosRepository.ListaDetalleCombos();

            var EncabezadoDetalle = listadeCombos.GroupJoin(listaDetalle,
                c => c.Id,
                d => d.ComboId,
                (combo, detalle) => new
                {
                    combo,
                    detalle
                }
                ).ToList();

            /* foreach(var combo in EncabezadoDetalle)
            {
                Console.WriteLine(combo.combo.Descripcion);
                foreach (var detalle in combo.detalle)
                {
                    Console.WriteLine("->" + detalle.Descripcion);
                }
                Console.WriteLine();
            }
            */


            

            /*

            var listadescripciones = new List<string>();

                foreach (var item in listadeCombos)
            {
                var detallecombos = _combosRepository.GetListDetalleCombo(item.IdCombo).First();
                var detallelistap = _combosRepository.GetListDetalleCombo(item.IdCombo);
                item.ComboId = detallecombos.ComboId;
                item.Cantidad = detallecombos.Cantidad;
                item.Referencia = detallecombos.Referencia;

                item.Descripciondetalle = detallecombos.Descripcion;

            }

                */
          //  rvcombos.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Combos.ReporteCombos.rdlc";
            rvcombos.LocalReport.ReportEmbeddedResource = "Sistema.Reports.Reports_Combos.ReporteCP.rdlc";
            var rds1 = new ReportDataSource("Encabezado", listadeCombos);
            var rds2 = new ReportDataSource("Detalle", listaDetalle);
            
            rvcombos.LocalReport.DataSources.Clear();
            rvcombos.LocalReport.DataSources.Add(rds1);
          //  rvcombos.LocalReport.DataSources.Clear();
            rvcombos.LocalReport.DataSources.Add(rds2);
        }
/*
        public void cargarTextbox()
        {
           
            //var listaenviar = _combosRepository.Getdetalle(1);
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                new ReportParameter("sucursal",cbsucursales.Text),
                //new ReportParameter("lista",listaenviar.ToString()),
                 new ReportParameter("fechainicio",fechaInicio.ToString()),
                  new ReportParameter("fechafinal",fechaFinal.ToString())
            };
            rvcombos.LocalReport.SetParameters(reportParameters);

        }
        */
       
    }
}
