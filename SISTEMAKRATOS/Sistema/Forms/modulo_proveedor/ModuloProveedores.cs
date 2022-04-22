using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Bancos;
using CapaDatos.Repository;
using CapaDatos.Repository.PersonalRepository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.ReportingServices.Diagnostics.Internal;
using sharedDatabase.Models.Proveedores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_proveedor
{
    public partial class ModuloProveedores : BaseContext
    {

        private ProveedoresRepository _proveedoresRepository = null;
        private SucursalesRepository _sucursalesRepository = null;
        private PropiedadesRepository _propiedadesRepository = null;
        private IList<ListarProveedores> proveedores = null;
        private IList<ListarProveedores> _listaproveedores = null;
        private List<ListarProveedores> ListadoProveedores= null;
        private bool MostrarMenu = true;
        private bool ProveedorNuevo = true;
        public Proveedor Proveedor = new Proveedor();

        public ModuloProveedores()
        {
            _proveedoresRepository = new ProveedoresRepository(_context);
            _sucursalesRepository = new SucursalesRepository(_context);
            _propiedadesRepository = new PropiedadesRepository(_context);
            InitializeComponent();
           

        }


        private void ModuloProveedores_Load(object sender, EventArgs e)
        {
            CargarSucursales();
            CargarFrecuencia();
            CargarBancos();
            CargarTipoProveedor();
            CargarRubro();
            CargarDGV();
        }

        private void CargarSucursales()
        {
            var sucursal = _sucursalesRepository.GetList();
            CbSucursal.DataSource = sucursal;
            CbSucursal.DisplayMember = "NombreSucursal";
            CbSucursal.ValueMember = "Id";
            CbSucursal.SelectedIndex = 0;
            CbSucursal.Invalidate();
        }
        private void CargarRubro()
        {
            var rubro = _propiedadesRepository.GetListRubros();
            CbRubro.DataSource = rubro;
            CbRubro.DisplayMember = "Descripcion";
            CbRubro.ValueMember = "Id";
            CbRubro.SelectedIndex = 0;
            CbRubro.Invalidate();
        }


        private void CargarFrecuencia()
        {
            var frecuencia = _propiedadesRepository.GetListFrecuencias();
            CbFrecuencia.DataSource = frecuencia;
            CbFrecuencia.DisplayMember = "Periodo";
            CbFrecuencia.ValueMember = "Id";
            CbFrecuencia.SelectedIndex = 0;
            CbFrecuencia.Invalidate();



        }
        private void CargarTipoProveedor()
        {
            var frecuencia = _propiedadesRepository.GetListTipoProveedores();
            CbTipoPrv.DataSource = frecuencia;
            CbTipoPrv.DisplayMember = "Descripcion";
            CbTipoPrv.ValueMember = "Id";
            CbTipoPrv.SelectedIndex = 0;
            CbTipoPrv.Invalidate();



        }
        private void CargarBancos()
        {
            var bancos = _propiedadesRepository.GetListBancos();
            CbBanco.DataSource = bancos;
            CbBanco.DisplayMember = "Entidad";
            CbBanco.ValueMember = "Id";
            CbBanco.SelectedIndex = 0;
            CbBanco.Invalidate();

        }

    
        private void BtnVolver_Click_1(object sender, EventArgs e)
        {

            if (Application.OpenForms["LayoutV2"] == null)
            {
                LayoutV2 layout = new LayoutV2(UsuarioLogeadoSistemas.User);
                layout.Show();
            }
            else
            {
                Application.OpenForms["LayoutV2"].Show();
                Application.OpenForms["LayoutV2"].Activate();
            }
         
            Close();
        }

     

        private void ModuloProveedores_FormClosing(object sender, FormClosedEventArgs e)
        {
              MenuPrincipal(this, false);
        }

        public void CargarDGV()
        {
            proveedores = _proveedoresRepository.GetListGenerales(0);
            BindingSource source = new BindingSource();
            source.DataSource = proveedores;
            DvgListaProveedors.DataSource = typeof(List<>);
            DvgListaProveedors.DataSource = source;
        }
        public void RefrescarDataGridProductos(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _proveedoresRepository = null;
                _proveedoresRepository = new ProveedoresRepository(_context);
            }
            BindingSource source = new BindingSource();
            ListadoProveedores = _proveedoresRepository.GetList(UsuarioLogeadoSistemas.User.SucursalId).ToList();
            source.DataSource = ListadoProveedores;
            DvgListaProveedors.DataSource = typeof(List<>);
            DvgListaProveedors.DataSource = source;
            DvgListaProveedors.ClearSelection();
        }
        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            RefrescarDataGridProductos(true);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {

            if (DvgListaProveedors.CurrentRow== null)
            {
                return;
            }

            var dialog = KryptonMessageBox.Show("¿Está seguro que desea eliminar el producto de la lista?", "Eliminar producto",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);

            if (dialog == DialogResult.Yes)
            {
                var productolista = (ListarProveedores)DvgListaProveedors.CurrentRow.DataBoundItem;
                var productoObtenido = _proveedoresRepository.Get(productolista.Id);
                productoObtenido.IsActive = true;
                _proveedoresRepository.Update(productoObtenido);
                RefrescarDataGridProductos(true);
            }
        }
        private Proveedor GetNewProv()
        {

            return new Proveedor()
            {
                Nombre = nombre.Text,
                Direccion = direccion.Text,
                Telefonos = telefono1.Text,
                IsActive = estado.Checked,
                Telefonos2 = telefono2.Text,
                SucursalId = int.Parse(CbSucursal.SelectedValue.ToString()),
                RubroId = int.Parse(CbRubro.SelectedValue.ToString()),// txtrubro.Text,
                FrecuenciaId = int.Parse(CbFrecuencia.SelectedValue.ToString()),
                BancoId = int.Parse(CbBanco.SelectedValue.ToString()),
                TipoProveedorId = int.Parse(CbTipoPrv.SelectedValue.ToString()),
                Nit = nit.Text,
                Ingreso = DateTime.Now,
                NoCuentaBancaria = txtcuenta.Text,


            };

        }
      

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nombre.Text) || string.IsNullOrEmpty(direccion.Text) ||
                string.IsNullOrEmpty(telefono1.Text))
            { KryptonMessageBox.Show("Campos Vacios, Todos son Obligatorios "); return; }

            var modeloProveedor = GetNewProv();
            if (!ModelState.IsValid(modeloProveedor)) { return; }
            _proveedoresRepository.Add(modeloProveedor);

            KryptonMessageBox.Show("Proveedor Guardado!");


            LimpiarContenido();
            RefrescarDataGridProductos(true);
        }

        private void LimpiarContenido()
        {

            nombre.Text = "";
            nit.Text="";
            txtcuenta.Text = "";
            telefono1.Text = "";
            telefono2.Text = "";
            direccion.Text = "";
            estado.Checked = false;
            txtcuenta.Text = "";
            kryptonCheckBox1.Checked = false;
            kryptonCheckBox2.Checked = false;
            kryptonCheckBox3.Checked = false;
            kryptonCheckBox4.Checked = false;
            kryptonCheckBox5.Checked = false;
            kryptonCheckBox6.Checked = false;
            kryptonCheckBox7.Checked = false;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            kryptonPage2.Visible = true;
            kryptonDockableNavigator1.SelectedPage = kryptonPage2;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (DvgListaProveedors.CurrentRow != null)
            {
                ProveedorNuevo = false;
                var fila = DvgListaProveedors.CurrentRow;
                ListarProveedores lista = (ListarProveedores)fila.DataBoundItem;
                kryptonPage2.Visible = true;
                kryptonDockableNavigator1.SelectedPage = kryptonPage2;
                Proveedor = _proveedoresRepository.Get(lista.Id);
                CargarTextBox();
                TxtBuscador.Text = "";
            }
            else
            {
                KryptonMessageBox.Show("No ha seleccionado ninguna fila del listado.", "Notificación");
            }
        }
        private void CargarTextBox()
        {
            try
            {

                txtnombre.Text = Proveedor.Nombre;
                if (Proveedor.RubroId > 0)
                {
                    CbRubro.SelectedValue = Proveedor.RubroId;
                }
                if (Proveedor.SucursalId > 0)
                {
                    CbSucursal.SelectedValue = Proveedor.SucursalId;
                }
                if (Proveedor.BancoId > 0)
                {
                    CbBanco.SelectedValue = Proveedor.BancoId;
                }
                if (Proveedor.FrecuenciaId > 0)
                {
                    CbFrecuencia.SelectedValue = Proveedor.FrecuenciaId;
                }
                if (Proveedor.TipoProveedorId > 0)
                {
                    CbTipoPrv.SelectedValue = Proveedor.TipoProveedorId;
                }
                txtnit.Text = Proveedor.Nit;
                txttel1.Text = Proveedor.Telefonos;
                txttel2.Text = Proveedor.Telefonos2;
                txttel3.Text = Proveedor.Celular;
                txtdireccion.Text = Proveedor.Direccion;
                txtcuenta.Text = Proveedor.NoCuentaBancaria;
                if (Proveedor.IsActive)
                {

                    checkEstado.Checked = true;
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
    }
   
}






