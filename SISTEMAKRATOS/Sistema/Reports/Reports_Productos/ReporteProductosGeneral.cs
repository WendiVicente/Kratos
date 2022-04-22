using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Repository;
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
    public partial class ReporteProductosGeneral : BaseContext
    {
        private SucursalesRepository _sucursalesRepository = null;
        private ProductosRepository _productosRepository = null;
        private CategoriaProdRepository _categoriaProdRepository = null;
        private  string estadocliente;

        private DateTime fechaInicio => Convert.ToDateTime(dtpfechainicio.Value.ToLongDateString());
        private DateTime fechaFinal => Convert.ToDateTime(dtpfechafinal.Value.ToLongDateString());
        private IList<ListarProductos> listaproducTodos = null;
        public ReporteProductosGeneral()
        {
            _sucursalesRepository = new SucursalesRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            _categoriaProdRepository = new CategoriaProdRepository(_context);
            InitializeComponent();
        }

        private void ReporteProductosGeneral_Load(object sender, EventArgs e)
        {
          //  FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
           
            CargarSucursales();
            CargarCategoria();
            ValoresDefault();
        }

        private void ValoresDefault()
        {
            rbTodos.Checked = true;
            checkfechas.Checked = true;
            rbAmbasExiste.Checked = true;

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            CargarFiltros();
        }
        public void CargarFiltros()
        {
            var allFechas = checkfechas.Checked;  
            var prodActivo = rbActivos.Checked;
            var prodInactivo = rbInactivos.Checked;
            var todosEstados = rbTodos.Checked;
            var idsucursal = int.Parse(cbsucursales.SelectedValue.ToString());
            var idCategoria = int.Parse(cbcategoria.SelectedValue.ToString());
            var orderByUltimoMov = cbMovimiento.Checked;
            var orderByExistencia = cbporExistencia.Checked;
            var includeBajas = rbBajas.Checked;
            var includeAltas = rbAltas.Checked;
            var includeTodas = rbAmbasExiste.Checked;

            CargarEstados();

             listaproducTodos = _productosRepository.GetListReportes(idsucursal, allFechas, fechaInicio,
               fechaFinal.AddDays(1), prodActivo, prodInactivo, todosEstados, idCategoria, orderByUltimoMov, orderByExistencia);
            RefrescarDataGrid();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            var filter = listaproducTodos.Where(a => a.Categoria != null &&
          a.Categoria.Contains(txtbuscar.Text) ||
          (a.Descripcion != null && a.Descripcion.Contains(txtbuscar.Text)) ||
          (a.CodigoReferencia != null && a.CodigoReferencia.Contains(txtbuscar.Text)) ||
          (a.Sucursal != null && a.Sucursal.Contains(txtbuscar.Text))

          );
            dgvLista.DataSource = filter.ToList();
        }

        private void CargarCategoria()
        {
            var categoria = _categoriaProdRepository.GetListcategoria();

            // agregar nuevo item a la lista
            categoria.Add(new ListarCategoriaProd { Id = 0, Categoria = "Todas" });
            var s = categoria.OrderBy(a => a.Id).ToList();
            // mostrar datos en dgv
            cbcategoria.DataSource = s;
            cbcategoria.DisplayMember = "Categoria";
            cbcategoria.ValueMember = "Id";
            cbcategoria.Text = "Seleccione una Categoria"; // esto no jalo? no me jalo
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
        public void RefrescarDataGrid(bool loadNewContext = true)
        {
            BindingSource source = new BindingSource();
            // var clientes = _clientesRepository.GetList(filtroid);
            source.DataSource = listaproducTodos;
            dgvLista.DataSource = typeof(List<>);
            dgvLista.DataSource = source;
            dgvLista.AutoResizeColumns();
            dgvLista.Columns[0].Visible = false;
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
        private void CargarEstados()
        {
            if (rbTodos.Checked == true) { estadocliente = "Todos"; };
            if (rbInactivos.Checked == true) { estadocliente = "Inactivos"; };
            if (rbActivos.Checked == true) { estadocliente = "Activos"; };
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            GeneralReporteProd generalReporteProd = new GeneralReporteProd(listaproducTodos);
            generalReporteProd.Show();
        }

    }
}
