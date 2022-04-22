using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.DocumentoSAT;
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
    public partial class SeleccionVenta : BaseContext
    {
        private FacturasRepository _facturasRepository = null;
        private NotaCreditoVista _notaCreditoVista = null;
        private CertificadoSatRepository _certificadoSatRepository = null;
        private List<DocumentoCertificadoSAT> _listaCertificadoFEl = null;
        public SeleccionVenta(NotaCreditoVista _vista)
        {
            _notaCreditoVista = _vista;
            _facturasRepository = new FacturasRepository(_context);
            _certificadoSatRepository = new CertificadoSatRepository(_context);
            InitializeComponent();
        }

        private void SeleccionVenta_Load(object sender, EventArgs e)
        {
            CargarListaVentas();
            cargarDocCertificados();
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
        private void cargarDocCertificados()
        {
            _listaCertificadoFEl = _certificadoSatRepository.GetlistaDoCertificadoSAT();
        }
        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaactual = (ListarVentas)dgvVentas.CurrentRow.DataBoundItem;
            if (filaactual == null) return;

            var certificado = _listaCertificadoFEl.FirstOrDefault(x => x.FacturaId == filaactual.Id);
            if (certificado == null)
            {
                if (Application.OpenForms["NotaCreditoPorDescuento"] == null)
                {
                    NotaCreditoPorDescuento notaCredito = new NotaCreditoPorDescuento(filaactual, _notaCreditoVista);

                    notaCredito.Show();
                }
                else
                {
                    Application.OpenForms["NotaCreditoPorDescuento"].Activate();
                }
            }
            else
            {
                if (Application.OpenForms["NotaCreditoFEL"] == null)
                {
                    NotaCreditoFEL notaCreditoFEL = new NotaCreditoFEL(certificado, filaactual, _notaCreditoVista);
                    notaCreditoFEL.Show();
                }
                else
                {
                    Application.OpenForms["NotaCreditoFEL"].Activate();
                }
            }
              
            




        }
    }
}
