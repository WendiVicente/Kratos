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
    public partial class ElegirFacturaDetalle : BaseContext
    {
        private FacturasRepository _facturasRepository = null;
        private ListarVentas _ventaSelected = null;
        private NotaCreditoVista _notaCreditoVista = null;
        //private List<ListaDetalleProductosVenta> detalle => _facturasRepository.GetListDetailleVenta(_Id);
        public ElegirFacturaDetalle(NotaCreditoVista _vista)
        {
            _facturasRepository = new FacturasRepository(_context);
            InitializeComponent();
            CargarListaVentas();
            _notaCreditoVista = _vista;
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_listaDetalleNotaCredito != null) { _listaDetalleNotaCredito.Clear(); }
            _ventaSelected = (ListarVentas)dgvVentas.CurrentRow.DataBoundItem;
            if (_ventaSelected != null)
            {
                RefrescarDataGridDetalle(_ventaSelected);
            }
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
            dgvVentas.DataSource = typeof(List<>);
            dgvVentas.DataSource = source;

        }
        private void RefrescarDataGridDetalle(ListarVentas venta)
        {
            var detalle = _facturasRepository.GetDetallebyFactura(venta.Id);
            BindingSource source = new BindingSource();
            source.DataSource = detalle;
            dgvdetalleFactura.DataSource = typeof(List<>);
            dgvdetalleFactura.DataSource = source;

           

        }

        private void NCporProductos_Load(object sender, EventArgs e)
        {

        }

        private void dgvdetalleFactura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarFila(dgvdetalleFactura, 17);
            CreaListaDetallebyFactura(dgvdetalleFactura, 17);
        }
        private void SeleccionarFila(DataGridView datagrid, int acciones)
        {
            bool estadoActual = Convert.ToBoolean(datagrid.CurrentRow.Cells[acciones].Value);
            if (estadoActual)
            {
                datagrid.CurrentRow.Cells[acciones].Value = false;
            }
            else
            {
                datagrid.CurrentRow.Cells[acciones].Value = true;

            }

        }

        private List<DetalleNotaCredito> _listaDetalleNotaCredito = null;
        private void CreaListaDetallebyFactura(DataGridView data, int colacciones)
        {
            if (data.RowCount <= 0) { return; }
            int filasSeleccion = 0;
            int contadorfila = 0;
            decimal total = 0;
            _listaDetalleNotaCredito = new List<DetalleNotaCredito>();
            foreach (DataGridViewRow Rows in data.Rows)
            {
                var filasTotales = int.Parse(data.RowCount.ToString());


                bool acciones = Convert.ToBoolean(Rows.Cells[colacciones].Value);
                if (!acciones)
                {
                    filasSeleccion += 1;
                }
                else

                {
                    total += decimal.Parse(Rows.Cells[8].Value.ToString());
                    lbtotal.Text = "Q."+total.ToString();
                    var filaactual = (ListarDetalleFacturas)dgvdetalleFactura.Rows[contadorfila].DataBoundItem;
                    var detallenotacredito = GetDetalleNCNew(filaactual);
                    _listaDetalleNotaCredito.Add(detallenotacredito);
                   
                }
                contadorfila++;
            }
        }


        public DetalleNotaCredito GetDetalleNCNew(ListarDetalleFacturas detallefactura)
        {
            return new DetalleNotaCredito()
            {
                Descripcion=detallefactura.Descripcion,
                Cantidad=detallefactura.Cantidad,
                Precio=detallefactura.Precio,
                Descuento=detallefactura.Descuento,
                SubTotal=detallefactura.SubTotal,
                PrecioTotal=detallefactura.PrecioTotal,
                ProductoId=detallefactura.ProductoId,
                ComboId=detallefactura.ComboId,
                DetalleColorId=detallefactura.DetalleColorId,
                DetalleTallaId=detallefactura.DetalleTallaId,
                TallayColorId=detallefactura.TallayColorId,

            };
        }
        private void btnguardar_Click(object sender, EventArgs e)
        {
            var filaactual = (ListarVentas)dgvVentas.CurrentRow.DataBoundItem;
            if (filaactual != null)
            {
                if(_listaDetalleNotaCredito!=null || _listaDetalleNotaCredito.Count != 0)
                {
                    if (Application.OpenForms["NotaCreditoPorItem"] == null)
                    {
                        NotaCreditoPorItem notaCreditoPorItem = new NotaCreditoPorItem(filaactual, _listaDetalleNotaCredito, _notaCreditoVista);
                        notaCreditoPorItem.Show();

                    }
                    else
                    {
                        Application.OpenForms["NotaCreditoPorItem"].Activate();
                    }
                }
               
            }

        }

    }
}
