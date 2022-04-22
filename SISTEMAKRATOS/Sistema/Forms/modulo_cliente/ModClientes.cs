using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_cliente
{
    public partial class ModClientes : BaseContext
    {
        public ModClientes()
        {
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["LayoutV2"] == null)
            {
                LayoutV2 layout = new LayoutV2(UsuarioLogeadoSistemas.User);
                layout.Show();
            }
            else
            {
                Application.OpenForms["LayoutV2"].Show();
                Application.OpenForms["LayoutV2"].Activate();
            }
            Close();
        }

        private void toolStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ModClientes_Load(object sender, EventArgs e)
        {

        }

        private void ModClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuPrincipal(this, false);
        }

        private void kryptonHeader5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
