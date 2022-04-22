using CapaDatos.Data;
using CapaDatos.Repository;
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
    public partial class detalleCaja : BaseContext
    {
        private  CajasRepository _cajasRepository = null;
        private Caja _caja = null;
        public detalleCaja(Caja cajaobtenida)
        {
            _caja = cajaobtenida;
            _cajasRepository = new CajasRepository(_context);
            InitializeComponent();
        }

        private void detalleCaja_Load(object sender, EventArgs e)
        {
            RefrescardgCajaActiva();
        }


        public void RefrescardgCajaActiva(bool loadNewContext = true)
        {

            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _cajasRepository = null;
                _cajasRepository = new CajasRepository(_context);
            }

            var obtenerDetalle = _cajasRepository.GetDetalleCaja(_caja.Id);
            BindingSource source = new BindingSource();
            source.DataSource = obtenerDetalle;
            dgvdetalleCaja.DataSource = typeof(List<>);
            dgvdetalleCaja.DataSource = source;
            dgvdetalleCaja.AutoResizeColumns();
            dgvdetalleCaja.Columns[1].Visible = false;
            dgvdetalleCaja.Columns[2].Visible = false;
            dgvdetalleCaja.Columns[3].Visible = false;
            //operaciones con las columnas y Labels
            var egresos = obtenerDetalle.Sum(a => a.Egreso);
            var efectivototal = obtenerDetalle.Sum(a => a.Efectivo);
            var chequestotal = obtenerDetalle.Sum(a => a.Cheques);
            var tarjetaDebitototal = obtenerDetalle.Sum(a => a.TarjetaDebito);
            var tarjetaCreditototal = obtenerDetalle.Sum(a => a.TarjetaCredito);
            var ingresos = (efectivototal + chequestotal + tarjetaCreditototal + tarjetaDebitototal);
              lbtotacerrar.Text = (ingresos - egresos).ToString();
              lbtotalinicio.Text = _caja.MontoApertura.ToString();



        }

    }
}
