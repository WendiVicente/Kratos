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

namespace Sistema.Forms.modulo_debitos
{
    public partial class SeleccionarVentaND : BaseContext
    {
        private NotaDebitoVista _notaDebitoVista = null;
        private FacturasRepository _facturasRepository = null;
    
        public SeleccionarVentaND(NotaDebitoVista vista)
        {
            _notaDebitoVista = vista;
            _facturasRepository = new FacturasRepository(_context);
            InitializeComponent();
            CargarListaVentas();
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaactual = (ListarVentas)dgvVentas.CurrentRow.DataBoundItem;
            if (filaactual != null)
            {
                if (Application.OpenForms["NotaDebitoFactura"] == null)
                {
                    NotaDebitoFactura notaDebitoFactura = new NotaDebitoFactura(filaactual, _notaDebitoVista);
                    ///pos.MdiParent = this;
                    notaDebitoFactura.Show();
                }
                else
                {
                    Application.OpenForms["NotaDebitoFactura"].Activate();
                }
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


    }
}
