using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas.Devoluciones;
using CapaDatos.Repository.DevolucionesRepository;
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

namespace Sistema.Forms.modulo_devoluciones
{
    public partial class NotaCreditoVista : BaseContext
    {
        private  NotaCreditoRepository _notaCreditoRepository = null;
        public NotaCreditoVista()
        {
            InitializeComponent();
            CargarListaVentas();
        }

        private void btnnueva_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["TipoNotaCredito"] == null)
            {
                TipoNotaCredito tipoNotaCredito = new TipoNotaCredito(this);
                ///pos.MdiParent = this;
                tipoNotaCredito.Show();
            }
            else
            {
                Application.OpenForms["TipoNotaCredito"].Activate();
            }
        }


        public void CargarListaVentas(bool loadNewContext = true, int valor = 0) // 0 es por defecto
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _notaCreditoRepository = null;
                _notaCreditoRepository = new NotaCreditoRepository(_context);
            }

            BindingSource source = new BindingSource();
            var ventas = _notaCreditoRepository.GetlistaNotasCreditos();
            source.DataSource = ventas;
            dgvnotascredito.DataSource = typeof(List<>);
            dgvnotascredito.DataSource = source;
            dgvnotascredito.Columns[1].Visible = false;


        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnvalidar_Click(object sender, EventArgs e)
        {
            var fila = (ListarNotasCredito)dgvnotascredito.CurrentRow.DataBoundItem;
            if (fila == null) { return; }
            var notacreditotosend = _notaCreditoRepository.Get(fila.Id);

            if (notacreditotosend.Estado == false)
            {
                if (Application.OpenForms["Confirmar"] == null)
                {
                    Confirmar cconfirmar = new Confirmar(this, notacreditotosend);
                    ///pos.MdiParent = this;
                    cconfirmar.Show();
                }
                else
                {
                    Application.OpenForms["Confirmar"].Activate();
                }


            }
            else
            {
                KryptonMessageBox.Show("Esta nota de crédito ya fue cobrada, elija otra para continuar..");
            }
           
        }
    }
}
