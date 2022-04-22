using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_facturacion
{
    public partial class AnularCert : Form
    {
        public AnularCert()
        {
            InitializeComponent();
        }

        private void AnularCert_Load(object sender, EventArgs e)
        {

           
            this.reportViewer1.RefreshReport();
        }
    }
}
