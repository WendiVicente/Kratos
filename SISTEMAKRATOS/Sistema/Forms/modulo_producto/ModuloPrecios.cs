using CapaDatos.ListasPersonalizadas;
using CapaDatos.Repository;
using CapaDatos.Repository.PreciosRepository;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_producto
{
    public partial class ModuloPrecios : BaseContext
    {
        private readonly TipoPrecioRepository _tipoPrecioRepository = null;
        readonly Form FormularioVolver;
        Producto _producto;

        public ModuloPrecios(Form form, Producto producto)
        {
            _tipoPrecioRepository = new TipoPrecioRepository(_context);
            FormularioVolver = form;
            _producto = producto;
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms[FormularioVolver.Name] == null)
            {
                FormularioVolver.Show();
            }
            else
            {
                Application.OpenForms[FormularioVolver.Name].Activate();
            }
            Close();
        }

        private void ModuloPrecios_Load(object sender, EventArgs e)
        {
            CargarPrecios();
        }


        public void CargarPrecios()
        {
            if (_producto != null)
            {
                TxtCodigoBarras.Text = _producto.CodigoBarras;
                TxtDescripcion.Text = _producto.Descripcion;
                txtprecioventa.Text = _producto.PrecioVenta.ToString();
                txtpreciomayorista.Text = _producto.PrecioMayorista.ToString();
                txtpreciocuentaclave.Text = _producto.PrecioCuentaClave.ToString();
                txtpreciocuentaclave.Text = _producto.PrecioEntidadGubernamental.ToString();
                txtpreciorevendedor.Text = _producto.PrecioRevendedor.ToString();

                if (_producto.TieneEscalas)
                {
                    TraerEscalasPrecios(_producto.Id);
                }
            }            
        }

        private void TraerEscalasPrecios(int ProductoId)
        {
            var tipo = _tipoPrecioRepository.Get(ProductoId);
            if (tipo != null)
            {
                var _listaDetallePrecios = _tipoPrecioRepository.GetDetallePrecioListar(tipo.Id, 0);
                CargarDataGridPrecios(_listaDetallePrecios);
            }
        }

        private void CargarDataGridPrecios(List<ListarDetallePrecios> listaPrecios)
        {
            BindingSource source = new BindingSource();
            source.DataSource = listaPrecios;
            DgvEscalasProducto.DataSource = typeof(List<>);
            DgvEscalasProducto.DataSource = source;
            DgvEscalasProducto.ClearSelection();
        }        


        private void TxtDecimal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TxtDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as KryptonTextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }
        }

        private void DgvEscalasProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
