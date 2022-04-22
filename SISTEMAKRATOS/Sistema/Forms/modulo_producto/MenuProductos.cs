using Sistema.Forms.modulo_combos;
using System;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_producto
{
    public partial class MenuProductos : BaseContext
    {
        private bool MostrarMenu = true;

        public MenuProductos()
        {
            InitializeComponent();
        }

        private void BtnPromociones_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ModuloPromos"] == null)
            {
                ModuloPromos promos = new ModuloPromos();
                promos.Show();
            }
            else
            {
                Application.OpenForms["ModuloPromos"].Activate();
            }
            MostrarMenu = false;
            Close();
        }

        private void BtnVales_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ModuloVales"] == null)
            {
                ModuloVales Vales = new ModuloVales();
                Vales.Show();
            }
            else
            {
                Application.OpenForms["ModuloVales"].Activate();
            }
            MostrarMenu = false;
            Close();
        }

        private void BtnCotizaciones_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ModuloCotizacion"] == null)
            {
                ModuloCotizacion cotizaciones = new ModuloCotizacion();
                cotizaciones.Show();
            }
            else
            {
                Application.OpenForms["ModuloCotizacion"].Activate();
            }
            MostrarMenu = false;
            Close();
        }

        private void BtnCombos_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ModuloCombos"] == null)
            {
                ModuloCombos combos = new ModuloCombos();
                combos.Show();
            }
            else
            {
                Application.OpenForms["ModuloCombos"].Activate();
            }
            MostrarMenu = false;
            Close();
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ModuloProducto"] == null)
            {
                ModuloProducto modulo = new ModuloProducto();
                modulo.Show();
            }
            else 
            { 
                Application.OpenForms["ModuloProducto"].Activate(); 
            }
            MostrarMenu = false;
            Close();
        }

        private void BtnPedidos_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ModuloPedidos"] == null)
            {
                ModuloPedidos pedidos = new ModuloPedidos();
                pedidos.Show();
            }
            else
            {
                Application.OpenForms["ModuloPedidos"].Activate();
            }
            MostrarMenu = false;
            Close();
        }

        private void PbConfig_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ModuloConfiguracion"] == null)
            {
                ModuloConfiguracion config = new ModuloConfiguracion();
                config.Show();
            }
            else
            {
                Application.OpenForms["ModuloConfiguracion"].Activate();
            }
            MostrarMenu = false;
            Close();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            MenuPrincipal(this);
        }

        private void MenuProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MostrarMenu)
                MenuPrincipal(this, false);
        }
    }
}
