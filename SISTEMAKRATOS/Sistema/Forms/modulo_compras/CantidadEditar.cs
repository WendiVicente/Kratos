using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_compras
{
    public partial class CantidadEditar : BaseContext
    {
        private readonly EditarSolicitud _editarSolicitud = null;
        private DataGridViewCellCollection _dataGridView;
        private List<String> _productoobtenido;
        private decimal impuestoaplicar = 1.12M;
       // private int IdDetalle = 0;
       // private int codcol = 1;
        private int descripcol = 2;
        private int preciocol = 3;
        private int cantidadcol = 4;
        private int impuestocol = 5;
        private int baseimponilblecol = 6;
        private int subtotalcol = 7;
       // private int idcol = 8;
        public CantidadEditar(List<String> productoSeleccionado, DataGridViewCellCollection dataGridView, EditarSolicitud solicitud)
        {
            _dataGridView = dataGridView;
            _productoobtenido = productoSeleccionado;
            _editarSolicitud = solicitud;
            InitializeComponent();
        }

        private void AumentarCantidad_Load(object sender, EventArgs e)
        {
            txtproducto.Text = _productoobtenido[descripcol];
            txtcantidad.Text = _productoobtenido[cantidadcol];
        }

        private void btnenviar_Click(object sender, EventArgs e)
        {

            var cantidad = int.Parse(txtcantidad.Text);
            if (cantidad > 0)
            {
                _dataGridView[cantidadcol].Value = cantidad;
                _dataGridView[subtotalcol].Value = Convert.ToDecimal(_dataGridView[preciocol].Value) * Convert.ToDecimal(_dataGridView[cantidadcol].Value);
                var baseimponible = ((Convert.ToDecimal(_dataGridView[subtotalcol].Value) / impuestoaplicar)).ToString("0.00");
                _dataGridView[baseimponilblecol].Value = decimal.Parse(baseimponible);
                var impuestoaplica = (Convert.ToDecimal(_dataGridView[subtotalcol].Value) - Convert.ToDecimal(_dataGridView[baseimponilblecol].Value)).ToString("0.00");
                _dataGridView[impuestocol].Value = decimal.Parse(impuestoaplica);
            }

            _editarSolicitud.ActualizarLabelTotal();
        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
