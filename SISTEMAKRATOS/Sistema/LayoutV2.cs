using CapaDatos.Models.Usuarios;
using POS;
using POS.Forms;
using Sistema.Forms.modulo_Bancos;
using Sistema.Forms.modulo_Caja;
using Sistema.Forms.modulo_cliente;
using Sistema.Forms.modulo_compras;
using Sistema.Forms.modulo_facturacion;
using Sistema.Forms.modulo_personal;
using Sistema.Forms.modulo_producto;
using Sistema.Forms.modulo_proveedor;
using Sistema.Forms.modulo_Sucursales;
using Sistema.Forms.modulo_usurios;
using Sistema.Reports;
using System;
using System.Windows.Forms;

namespace Sistema
{
    public partial class LayoutV2 : BaseContext
    {
        public LayoutV2(User user)
        {
            UsuarioLogeadoSistemas.User = user;
            InitializeComponent();
        }

        private void PbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ModuloClientes"] == null)
            {
                ModuloClientes clientes = new ModuloClientes();
                clientes.Show();
            }
            else
            {
                Application.OpenForms["ModuloClientes"].Activate();
            }
            Hide();
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["MenuProductos"] == null)
            {
                MenuProductos menuProductos = new MenuProductos();
                menuProductos.Show();
            }
            else
            {
                Application.OpenForms["MenuProductos"].Activate();
            }
            Hide();
        }

        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ModuloProveedores"] == null)
            {
                ModuloProveedores proveedores = new ModuloProveedores();
                proveedores.Show();
            }
            else
            {
                Application.OpenForms["ModuloProveedores"].Activate();
            }
            Hide();
        }

        private void BtnCaja_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ModuloCaja"] == null)
            {
                ModuloCaja caja = new ModuloCaja();
                caja.Show();
            }
            else
            {
                Application.OpenForms["ModuloCaja"].Activate();
            }
            Hide();
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ModuloUsuario"] == null)
            {
                ModuloUsuario usuario = new ModuloUsuario();
                usuario.Show();
            }
            else
            {
                Application.OpenForms["ModuloUsuario"].Activate();
            }
            Hide();
        }

        private void BtnPuntoDeVenta_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["LoginForm"] == null)
            {
                LoginForm pos = new LoginForm
                {
                    FormularioVolver = this
                };
                pos.Show();
            }
            else
            {
                Application.OpenForms["LoginForm"].Activate();
            }
            Hide();
        }

        private void BtnFacturacion_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["MonitorFacturacion"] == null)
            {
                MonitorFacturacion2 monitor = new MonitorFacturacion2(UsuarioLogeadoSistemas.User, this);
                monitor.Show();
            }
            else
            {
                Application.OpenForms["MonitorFacturacion"].Activate();
            }
            Hide();
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ModuloReportes"] == null)
            {
                ModuloReportes reportes = new ModuloReportes();
                reportes.Show();
            }
            else
            {
                Application.OpenForms["ModuloReportes"].Activate();
            }
            Hide();
        }

        private void BtnCompras_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ModuloCompras"] == null)
            {
                ModuloCompras compras = new ModuloCompras();
                compras.Show();
            }
            else
            {
                Application.OpenForms["ModuloCompras"].Activate();
            }
            Hide();
        }

        private void BtnPagosBancos_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ModuloPagoBancos"] == null)
            {
                ModuloPagoBancos pagoBancos = new ModuloPagoBancos();
                pagoBancos.Show();
            }
            else
            {
                Application.OpenForms["ModuloPagoBancos"].Activate();
            }
            Hide();
        }

        private void BtnPersonal_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ModuloPersonal"] == null)
            {
                ModuloPersonal personal = new ModuloPersonal();
                personal.Show();
            }
            else
            {
                Application.OpenForms["ModuloPersonal"].Activate();
            }
            Hide();
        }

        private void BtnSucursal_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ModuloSucursales"] == null)
            {
                ModuloSucursales sucursales = new ModuloSucursales();
                sucursales.Show();
            }
            else
            {
                Application.OpenForms["ModuloSucursales"].Activate();
            }
            Hide();
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
            Hide();
        }


    }
}
