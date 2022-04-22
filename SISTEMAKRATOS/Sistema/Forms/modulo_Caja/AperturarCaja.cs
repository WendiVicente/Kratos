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
    public partial class AperturarCaja : BaseContext
    {
        private readonly CajasRepository _cajasRepository = null;
        private string usuarioId = UsuarioLogeadoSistemas.User.Id;
        private int sucursalId = UsuarioLogeadoSistemas.User.SucursalId;
        private readonly ModuloCaja _FormCaja = null;
         
        public AperturarCaja(ModuloCaja cajaInicio)
        {
            _FormCaja = cajaInicio;
            _cajasRepository = new CajasRepository(_context);
            InitializeComponent();
        }

        private void txtmonto_KeyDown(object sender, KeyEventArgs e)
        {/*
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
            */
        }

        private void txtmonto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnAperturar_Click(object sender, EventArgs e)
        {
            var Caja = _cajasRepository.GetCajaAperturada(sucursalId, true);


            if (Caja == null)
            {
                IniciarCaja();
                _FormCaja.RefrescardgCajaActiva(false);
               

            }
            else { KryptonMessageBox.Show("Ya tiene una caja aperturada.No se puede abrir otra"); }
        }

        public Caja GetViewModel()
        {
            return new Caja()
            {
                FechaApertura = DateTime.Now,
                //UsuarioId = usuarioId,
                MontoApertura = decimal.Parse(txtmonto.Text),
                SucursalId = sucursalId,
                EstadoCaja = true
            };
        }

        private DetalleCaja getdetalleCaja()
        {
            // var CajasAperturadas = _cajasRepository.GetCajaAper(true);

            return new DetalleCaja()
            {
                //  CajaId = CajasAperturadas.Id,
                Descripcion = "monto de Apertura",
                Efectivo = decimal.Parse(txtmonto.Text)

            };

        }

        private void IniciarCaja()
        {



            DialogResult dialog = KryptonMessageBox.Show("¿Está seguro que desea aperturar caja?",
              "Aperturar Nueva Caja",
              MessageBoxButtons.YesNoCancel,
              MessageBoxIcon.Question,
              MessageBoxDefaultButton.Button2);

            if (dialog == DialogResult.Yes)
            {

                var model = GetViewModel();
                var detalleCajamodel = getdetalleCaja();

                if (!ModelState.IsValid(model)) { return; }
                if (!ModelState.IsValid(detalleCajamodel)) { return; }

                _cajasRepository.Add(model);

                var cajaObtenida = _cajasRepository.GetCajaAperturada(sucursalId, true);

                detalleCajamodel.CajaId = cajaObtenida.Id;
                _cajasRepository.AddDetalleCaja(detalleCajamodel);


            }
        }

        private void kryptonPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AperturarCaja_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
