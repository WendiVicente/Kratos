using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class Observaciones : BaseContext
    {
        string observaciones = "";
        PuntoDeVenta _pos = null;
        
        public Observaciones(string obs, PuntoDeVenta pos)
        {
            observaciones = obs;
            _pos = pos;
            InitializeComponent();
        }

        private void Observaciones_Load(object sender, EventArgs e)
        {
            if (observaciones.Length > 0)
            {
                txtObservaciones.Text = observaciones;
            }
        }

        private void pbGuardar_Click(object sender, EventArgs e)
        {
            _pos._observaciones = txtObservaciones.Text;
            Close();
        }

        private void Observaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
