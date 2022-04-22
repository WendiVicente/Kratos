using CapaDatos.ListasPersonalizadas;
using CapaDatos.Repository;
using CapaDatos.Repository.PersonalRepository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
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
    public partial class NuevoProveedor : BaseContext
    {
        private ProveedoresRepository _proveedoresRepository = null;
        private SucursalesRepository _sucursalesRepository = null;
        private PropiedadesRepository _propiedadesRepository = null;
        public NuevoProveedor()
        {
            _proveedoresRepository = new ProveedoresRepository(_context);
            _sucursalesRepository = new SucursalesRepository(_context);
            _propiedadesRepository = new PropiedadesRepository(_context);
            InitializeComponent();
        }

        private void NuevoProveedor_Load(object sender, EventArgs e)
        {
            CargarSucursales();
            CargarFrecuencia();
            CargarBancos();
            CargarTipoProveedor();
            CargarRubro();
        }


        private Proveedor GetNewProv()
        {

            return new Proveedor()
            {
                Nombre = txtEntidad.Text,
                Direccion= txtdirecc.Text,
                Telefonos = txttelefono.Text,
                IsActive= checkEstado.Checked,
                Telefonos2 = txttelefono2.Text,
                SucursalId= int.Parse(comboSucursal.SelectedValue.ToString()),
                RubroId = int.Parse(comboRubro.SelectedValue.ToString()),// txtrubro.Text,
                FrecuenciaId = int.Parse(comboFrecuencia.SelectedValue.ToString()),
                BancoId = int.Parse(comboBancos.SelectedValue.ToString()),
                TipoProveedorId= int.Parse(comboTiposprov.SelectedValue.ToString()),
                Observaciones = txtobservacion.Text,
                Nit = txtnit.Text,
                Ingreso = DateTime.Now,
                NoCuentaBancaria= txtcuenta.Text,
                Correo = txtemail.Text,
                Celular2 = txtcel2.Text,
                Celular = txtcel1.Text,
               
                


            };

        }
       
        private void GuardarProveedor()
        {
            if (string.IsNullOrEmpty(txtEntidad.Text) || string.IsNullOrEmpty(txtdirecc.Text) ||
                 string.IsNullOrEmpty(txttelefono.Text))
            { KryptonMessageBox.Show("Campos Vacios, Todos son Obligatorios "); return; }
           
            var modeloProveedor = GetNewProv();
           if (!ModelState.IsValid(modeloProveedor)) { return; }
           _proveedoresRepository.Add(modeloProveedor);

            KryptonMessageBox.Show("Proveedor Guardado!");


        }

        private void btnguardarprove_Click(object sender, EventArgs e)
        {
            GuardarProveedor();
        }

        private void CargarSucursales()
        {
            var sucursal = _sucursalesRepository.GetList();
            comboSucursal.DataSource = sucursal;
            comboSucursal.DisplayMember = "NombreSucursal";
            comboSucursal.ValueMember = "Id";
            comboSucursal.SelectedIndex = 0;
            comboSucursal.Invalidate();
        }
        private void CargarRubro()
        {
            var rubro = _propiedadesRepository.GetListRubros();
            comboRubro.DataSource = rubro;
            comboRubro.DisplayMember = "Descripcion";
            comboRubro.ValueMember = "Id";
            comboRubro.SelectedIndex = 0;
            comboRubro.Invalidate();
        }


        private void CargarFrecuencia()
        {
            var frecuencia = _propiedadesRepository.GetListFrecuencias();
            comboFrecuencia.DataSource = frecuencia;
            comboFrecuencia.DisplayMember = "Periodo";
            comboFrecuencia.ValueMember = "Id";
            comboFrecuencia.SelectedIndex = 0;
            comboFrecuencia.Invalidate();

           
            
        }
        private void CargarTipoProveedor()
        {
            var frecuencia = _propiedadesRepository.GetListTipoProveedores();
            comboTiposprov.DataSource = frecuencia;
            comboTiposprov.DisplayMember = "Descripcion";
            comboTiposprov.ValueMember = "Id";
            comboTiposprov.SelectedIndex = 0;
            comboTiposprov.Invalidate();

            

        }
        private void CargarBancos()
        {
            var bancos= _propiedadesRepository.GetListBancos();
            comboBancos.DataSource = bancos;
            comboBancos.DisplayMember = "Entidad";
            comboBancos.ValueMember = "Id";
            comboBancos.SelectedIndex = 0;
            comboBancos.Invalidate();

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonLabel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBancos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtdirecc_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
