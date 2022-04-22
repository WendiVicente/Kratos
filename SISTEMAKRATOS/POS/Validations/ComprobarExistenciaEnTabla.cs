using CapaDatos.ListasPersonalizadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Validations
{
    public class ComprobarExistenciaEnTabla
    {
        private readonly DataGridView _dataGridView = null;

        public ComprobarExistenciaEnTabla (DataGridView dataGridView)
        {
            _dataGridView = dataGridView ;
        }

        public bool ComprobarProductoRepetidoFila(ListarProductos producto)
        {

            foreach (DataGridViewRow row in _dataGridView.Rows)
            {
                if (row.Cells[0].Value.ToString() == producto.CodigoReferencia)
                {
                    return true;
                }
            }

            return false;

        }



    }
}
