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
    public partial class TipoNotaCredito : BaseContext
    {
        private NotaCreditoVista _notaCreditoVista = null;
        public TipoNotaCredito(NotaCreditoVista vista)
        {
            _notaCreditoVista = vista;
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (radioporArticulos.Checked == true)
            {
                if (Application.OpenForms["ElegirFacturaDetalle"] == null)
                {
                    ElegirFacturaDetalle ncporProductos = new ElegirFacturaDetalle(_notaCreditoVista);
                    ///pos.MdiParent = this;
                    ncporProductos.Show();
                    Close();
                }
                else
                {
                    Application.OpenForms["ElegirFacturaDetalle"].Activate();
                }
            }
            if (radiopordescuento.Checked == true)
            {
                if (Application.OpenForms["SeleccionVenta"] == null)
                {
                    SeleccionVenta seleccionVenta = new SeleccionVenta(_notaCreditoVista);
                    ///pos.MdiParent = this;
                    seleccionVenta.Show();
                    Close();
                }
                else
                {
                    Application.OpenForms["SeleccionVenta"].Activate();
                }
            }
        }
    }
}
