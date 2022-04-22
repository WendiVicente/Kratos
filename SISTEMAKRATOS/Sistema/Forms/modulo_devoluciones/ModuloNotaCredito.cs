using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Devoluciones;
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

namespace Sistema.Forms.modulo_devoluciones
{
    public partial class ModuloNotaCredito : BaseContext
    {
        private FacturasRepository _facturasRepository = null;
        private List<DetalleNotaCredito> _listaDetalleNotaCredito = null;
        private ListarVentas _ventaSelected = null;

        public ModuloNotaCredito()
        {
            _facturasRepository = new FacturasRepository(_context);
            InitializeComponent();
        }

        private void ModuloNotaCredito_Load(object sender, EventArgs e)
        {
            CargarListaVentas();
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
            DgvVentas.DataSource = typeof(List<>);
            DgvVentas.DataSource = source;
            DgvVentas.ClearSelection();
        }

        private void DgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_listaDetalleNotaCredito != null) { _listaDetalleNotaCredito.Clear(); }
            _ventaSelected = (ListarVentas)DgvVentas.CurrentRow.DataBoundItem;
            if (_ventaSelected != null)
            {
                RefrescarDataGridDetalle(_ventaSelected);
            }
        }

        private void RefrescarDataGridDetalle(ListarVentas venta)
        {
            var detalle = _facturasRepository.GetDetallebyFactura(venta.Id);
            BindingSource source = new BindingSource();
            source.DataSource = detalle;
            DgvDetalleFactura.DataSource = typeof(List<>);
            DgvDetalleFactura.DataSource = source;
            DgvDetalleFactura.ClearSelection();
        }
    }
}
