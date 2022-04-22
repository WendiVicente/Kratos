using CapaDatos.Repository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models.Caja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_Caja
{
    public partial class IngresoExtra : BaseContext
    {
        private Caja _cajaobtenida = null;
        private CajasRepository _cajaRepository = null;
        private ModuloCaja _cajaForm = null;
        public IngresoExtra(Caja caja, ModuloCaja cajaInicio)
        {
            _cajaForm = cajaInicio;
            _cajaRepository = new CajasRepository(_context);
            _cajaobtenida = caja;
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            MontoAdicional();
        }

      

        private void MontoAdicional()
        {

            if (string.IsNullOrEmpty(txtmontoingreso.Text)) { return; }
            var detalleEnviar = ModeloCaja();
            if (!ModelState.IsValid(detalleEnviar)) { return; }
            detalleEnviar.CajaId = _cajaobtenida.Id;
            _cajaRepository.AddDetalleCaja(detalleEnviar, true);

            _cajaForm.RefrescardgCajaActiva();
            txtdescripcion.Text = "";
            txtmontoingreso.Text = "";


        }

        private DetalleCaja ModeloCaja()
        {

            return new DetalleCaja()
            {
                Efectivo = decimal.Parse(txtmontoingreso.Text),
                Descripcion = txtdescripcion.Text

            };
        }

        private void txtmontoingreso_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                 (e.KeyChar != '.'))
            {
                e.Handled = true;

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as KryptonTextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }
        }

        private void IngresoExtra_Load(object sender, EventArgs e)
        {

        }
    }
}
