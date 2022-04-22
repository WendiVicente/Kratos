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

namespace Sistema.Forms.modulo_Caja
{
    public partial class FiltroEstado : BaseContext
    {
        private CajasRepository _cajaRepository = null;
        private readonly VerCajas _vercajas = null;
        public FiltroEstado(VerCajas verCajas)
        {
            _cajaRepository = new CajasRepository(_context);
            _vercajas = verCajas;
            InitializeComponent();
            CargarPago();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbestados.Items.Count <= 0) { return; }
            _vercajas.lbestado.Text = cbestados.Text;
            var valorCombobox = cbestados.SelectedIndex.ToString();
            _vercajas.estadoCaja = Convert.ToInt32(valorCombobox);
            _vercajas.RefrescardgCajas(true);
        }

        private void CargarPago()
        {
            cbestados.Items.Insert(0, "Todos");
            cbestados.Items.Insert(1, "Cerrado");
            cbestados.Items.Insert(2, "Abierto");
            cbestados.SelectedIndex = 0;

        }

    }
}
