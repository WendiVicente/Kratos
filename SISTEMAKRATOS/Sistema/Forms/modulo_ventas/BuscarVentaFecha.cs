using CapaDatos.Data;
using CapaDatos.Repository;
using ComponentFactory.Krypton.Toolkit;
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
    public partial class BuscarVentaFecha : BaseContext
    {
        private  FacturasRepository _facturasRepository = null;
        private readonly KryptonDataGridView _listarVentas = null;
        private readonly VentasGenerales _ventasGenerales = null;
        public BuscarVentaFecha(KryptonDataGridView datagrid, VentasGenerales ventasForm)
        {
            _listarVentas = datagrid;
            _ventasGenerales = ventasForm;
            _facturasRepository = new FacturasRepository(_context);
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            CargarListaVentasG(true);
        }


        private void CargarListaVentasG(bool loadNewContext =true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _facturasRepository = null;
                _facturasRepository = new FacturasRepository(_context);
            }
            var sucursalId = _ventasGenerales.SucursalIdtoSearch;
            var fechaInicio = DateTime.Parse(dtpFechaInicio.Value.ToShortDateString());
            var fechaFinal = DateTime.Parse(dtpFechaFinal.Value.ToShortDateString());

            BindingSource source = new BindingSource();
            var ventas = _facturasRepository.GetFacturasPorFecha(fechaInicio, fechaFinal.AddDays(1), sucursalId);
            source.DataSource = ventas;
            _listarVentas.DataSource = typeof(List<>);
            _listarVentas.DataSource = source;
        }
    }
}
