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
    public partial class VentasHoy : BaseContext
    {
        private  FacturasRepository _facturasRepository = null;
        public VentasHoy()
        {
            _facturasRepository = new FacturasRepository(_context);
            InitializeComponent();
        }

        private void VentasHoy_Load(object sender, EventArgs e)
        {
            lbMostrarSucursal.Text = "Todas";
            CargarListaVentas();
        }

        private void btnBuscarSucursal_Click(object sender, EventArgs e)
        {
            BuscarSucursal childForm = new BuscarSucursal(this);
            childForm.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarListaVentas(true);
        }

        private void btnDetalleP_Click(object sender, EventArgs e)
        {
           
            if (listventashoy.CurrentRow == null)
            {
                return;
            }

            ListarVentas fact = (ListarVentas)listventashoy.CurrentRow.DataBoundItem;
            DetalleVentas childForm = new DetalleVentas(fact); 
            childForm.Show();

        }

        private void btnbuscarVenta_Click(object sender, EventArgs e)
        {

        }


        public  void CargarListaVentas(bool loadNewContext=true, int valor = 0) // 0 es por defecto
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
            listventashoy.DataSource = typeof(List<>);
            listventashoy.DataSource = source;

            //totalventashoyselect.Text = ventas.Sum(a => a.Total == 0m ? 0.00m : a.Total).ToString("0.00");
            totalventashoyselect.Text = ventas.Where(x=>x.Total!=null).Sum(a => a.Total).ToString();



        }






    }
}
