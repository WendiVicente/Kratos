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

namespace POS.Forms
{
    public partial class AgregarVale : BaseContext
    {
        private ValesRepository _valesRepository = null;
        private PuntoDeVenta _principal = null;
        private IList<ListarVales> listaVales = new List<ListarVales>();
        private List<ListarDetalleVales> listadetallesvale = new List<ListarDetalleVales>();
        public AgregarVale(PuntoDeVenta principal)
        {
           
            InitializeComponent();
            _principal = principal;
            _valesRepository = new ValesRepository(_context);
        }

        private void AgregarVale_Load(object sender, EventArgs e)
        {
            cargarDGV();

        }



        public void cargarDGV()
        {
             listaVales = _valesRepository.GetListaVales();
            BindingSource source = new BindingSource();
            source.DataSource = listaVales;
            dgvVales.DataSource = typeof(List<>);
            dgvVales.DataSource = source;
            dgvVales.AutoResizeColumns();
            dgvVales.Columns[0].Visible = false;
            //dgvVales.Columns[7].Visible = false;
            //dgvVales.Columns[8].Visible = false;
            //dgvVales.Columns[9].Visible = false;
            //dgvVales.Columns[10].Visible = false;


        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            var filter = listaVales.Where(a => a.Descripcion.Contains(txtbuscar.Text) ||
                (a.Sucursal != null && a.Sucursal.Contains(txtbuscar.Text)) ||
                (a.Tipo != null && a.Tipo.Contains(txtbuscar.Text)) 
                );
            dgvVales.DataSource = filter.ToList();
        }

     

        private void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            if (dgvVales.CurrentRow == null)
            {
                return;
            }

            var pedidos = (ListarVales)dgvVales.CurrentRow.DataBoundItem;


            if (_valesRepository.GetListDetalleVale(pedidos.Id) == null) { return; }
            listadetallesvale = _valesRepository.GetListDetalleVale(pedidos.Id);
            _principal.idPedido = pedidos.Id;

            _principal._listadetallesvales = listadetallesvale;
            _principal.cargarDGVDetalleFactura(_principal.GetValeToFacturaDetalle());
            _principal.nodocumento.Text = pedidos.NoVale;
            Close();
        }
    }
}
