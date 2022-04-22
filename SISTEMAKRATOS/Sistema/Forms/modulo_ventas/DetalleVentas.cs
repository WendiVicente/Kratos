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

namespace Sistema.Forms.modulo_ventas
{
    public partial class DetalleVentas : BaseContext
    {
        private readonly FacturasRepository _facturasRepository = null;
        private ListarVentas _listadetallesVenta = null;
        private Guid _Id { get; set; }
        private List<ListaDetalleProductosVenta> detalle => _facturasRepository.GetListDetailleVenta(_Id);

        public DetalleVentas(ListarVentas detalleVenta)
        {
            _listadetallesVenta = detalleVenta;
            _facturasRepository = new FacturasRepository(_context);
            _Id = _listadetallesVenta.Id;
            InitializeComponent();
        }

        private void DetalleVentas_Load(object sender, EventArgs e)
        {
            CargarEncbezado();
            RefrescarDataGridDetalle();

        }

        private void CargarEncbezado()
        {
            txtnofactura.Text = _listadetallesVenta.NoFactura;
            txtnombre.Text = _listadetallesVenta.Nombre;
            txtdireccion.Text = _listadetallesVenta.Direccion;
            txtnit.Text = _listadetallesVenta.NIT;
            txttipopago.Text = _listadetallesVenta.TipoPago;
            txtvendedor.Text = _listadetallesVenta.Usuario;
            lbfechaventa.Text = _listadetallesVenta.FechaVenta.ToString();
          //  lbahorro.Text = _listadetallesVenta.Total.ToString();



        }

        private void RefrescarDataGridDetalle()
        {
            BindingSource source = new BindingSource(); 
            source.DataSource = detalle;
            listdetallesdeventa.DataSource = typeof(List<>);
            listdetallesdeventa.DataSource = source;
          
            cargarTotales();

        }
        private void cargarTotales()
        {
            lbsubtotal.Text = detalle.Sum(x => x.Subtotal).ToString();
            lbahorro.Text = detalle.Sum(x => x.Ahorro).ToString();
            lbtotalventa.Text = detalle.Sum(x => x.Total).ToString();
        }

        
    }
}
