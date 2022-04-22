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

namespace Sistema.Forms.modulo_ventas
{
    public partial class VentasGenerales : BaseContext
    {
        FacturasRepository _facturasRepository = null;
        public int SucursalIdtoSearch = 0;
        public VentasGenerales()
        {
            _facturasRepository = new FacturasRepository(_context);
            InitializeComponent();
        }

        private void VentasGenerales_Load(object sender, EventArgs e)
        {
            lbMostrarSucursal.Text = "Todas";
            CargarListaVentas();
        }

        private void btnbuscarVenta_Click(object sender, EventArgs e)
        {
            BuscarVentaFecha childForm = new BuscarVentaFecha(listventagenerales,this);
            childForm.Show();
        }

        private void btnDetalleP_Click(object sender, EventArgs e)
        {
            if (listventagenerales.CurrentRow == null)
            {
                return;
            }

            var fact = (ListarVentas)listventagenerales.CurrentRow.DataBoundItem;
            DetalleVentas childForm = new DetalleVentas(fact);
            childForm.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarListaVentas(true);
        }

        private void btnBuscarSucursal_Click(object sender, EventArgs e)
        {
            BuscarSucursalGenerales childForm = new BuscarSucursalGenerales(this);
            childForm.Show();
        }


        public void CargarListaVentas(bool loadNewContext = true, int valor = 0) // 0 es por defecto
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _facturasRepository = null;
                _facturasRepository = new FacturasRepository(_context);
            }

            BindingSource source = new BindingSource();
            var ventas = _facturasRepository.GetListVentasHoy(valor);
            source.DataSource = ventas;
            listventagenerales.DataSource = typeof(List<>);
            listventagenerales.DataSource = source;

        }

        private void CargarLabelSucursal()
        {
            if (lbMostrarSucursal.Text == "0")
            {

            }
        }

    }
}
