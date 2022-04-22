using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models;
using CapaDatos.Repository;
using CapaDatos.Repository.PreciosRepository;
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

namespace Sistema.Reports.Reports_Compras
{
    public partial class ReporteCompras : BaseContext
    {

        private ComprasRepository _comprasRepository = null;
        private ProductosRepository _productosRepository = null;
        private PreciosDetallePepsRepository _preciosDetallePepsRepository = null;



        private DateTime fechaInicio => Convert.ToDateTime(dtpfechainicio.Value.ToLongDateString());
        private DateTime fechaFinal => Convert.ToDateTime(dtpfechafinal.Value.ToLongDateString());

        public ReporteCompras()
        {
            _comprasRepository = new ComprasRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            _preciosDetallePepsRepository = new PreciosDetallePepsRepository(_context);


            InitializeComponent();
        }

        private void ReporteCompras_Load(object sender, EventArgs e)
        {

            // this.vistareporte.RefreshReport();
            if (rbbydetalle.Checked == true)
            {
                CargarListAllDetalle();
            }
            else if (rbEncabezado.Checked == true)
            {
                Cargar();
            }
         
        }

        private void Cargar()
        {
            BindingSource source = new BindingSource();
            var Productos = _comprasRepository.GetListGenerales(UsuarioLogeadoSistemas.User.SucursalId);
            source.DataSource = Productos;
            dgvcompras.DataSource = typeof(List<>);
            dgvcompras.DataSource = source;
            dgvcompras.AutoResizeColumns();


        }
        private void CargarListAllDetalle()
        {
            BindingSource source = new BindingSource();
            var Productos = _comprasRepository.GetListAllDetalle();
            source.DataSource = Productos;
            dgvcompras.DataSource = typeof(List<>);
            dgvcompras.DataSource = source;
            dgvcompras.AutoResizeColumns();


        }

        private void rbEncabezado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbbydetalle.Checked == true)
            {
                CargarListAllDetalle();
            }
            else if (rbEncabezado.Checked == true)
            {
                Cargar();
            }
            if (rbbydetalle.Checked == false)
            {
                lbHistorial.Visible = false;
                dgvDetalleprecios.Visible = false;
            }

        }

        private void rbbydetalle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbbydetalle.Checked == true)
            {
                CargarListAllDetalle();
            }
            else if (rbEncabezado.Checked == true)
            {
                Cargar();
            }
            
            if (rbbydetalle.Checked == false)
            {
                lbHistorial.Visible = false;
                dgvDetalleprecios.Visible = false;
            }
                

        }

        private void dgvcompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rbEncabezado.Checked == true)
            {
                var filaselected = (ListarCompras)dgvcompras.CurrentRow.DataBoundItem;

            }
            if (rbbydetalle.Checked == true) 
            {
                var filaselected = (CompraDetalleList)dgvcompras.CurrentRow.DataBoundItem;
                lbHistorial.Visible = true;
                dgvDetalleprecios.Visible = true;
                cargarPeps(filaselected.productoId);
            }
           

        }

        private void cargarPeps(int IDproducto)
        {
            //dgvDetalleprecios
            var detallePeps = _preciosDetallePepsRepository.GetListaPreciosPeps(IDproducto);

            BindingSource source = new BindingSource();
            source.DataSource = detallePeps;
            dgvDetalleprecios.DataSource = typeof(List<>);
            dgvDetalleprecios.DataSource = source;
            dgvDetalleprecios.AutoResizeColumns();

            dgvDetalleprecios.Columns["Id"].Visible = false;
            dgvDetalleprecios.Columns["FechaIngreso"].DisplayIndex = 2;
            dgvDetalleprecios.Columns["Coste"].DisplayIndex = 3;


        }

        private void checkfechas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbbydetalle.Checked == false)
            {
                lbHistorial.Visible = false;
                dgvDetalleprecios.Visible = false;
            }
        }
    }
}
