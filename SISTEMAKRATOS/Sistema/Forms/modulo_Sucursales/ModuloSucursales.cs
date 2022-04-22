using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Sucursales;
using CapaDatos.Repository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_Sucursales
{
    public partial class ModuloSucursales : BaseContext
    {
        private SucursalesRepository _sucursalesRepository = null;
        private bool sucunuevo = true;
        private ListarSucursales sucursales=null;
        public ModuloSucursales()
        {
            _sucursalesRepository = new SucursalesRepository(_context);
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            MenuPrincipal(this);
        }

        private void ModuloSucursales_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuPrincipal(this, false);
        }

        private void ModuloSucursales_Load(object sender, EventArgs e)
        {
            RefrescarDataGridSucursales();
        }

        public void RefrescarDataGridSucursales(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _sucursalesRepository = null;
                _sucursalesRepository = new SucursalesRepository(_context);
            }

            BindingSource source = new BindingSource();

            source.DataSource = _sucursalesRepository.GetList();
            DgvListSucursales.DataSource = typeof(List<>);
            DgvListSucursales.DataSource = source;
            DgvListSucursales.ClearSelection();


        }
        public Sucursal GetViewModel()
        {
            return new Sucursal()
            {

                NombreEncargado = txtencargado.Text,
                NombreSucursal = txtsucursal.Text,
                Telefono = txttelefono.Text,
                Direccion = txtdireccion.Text,
            };
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            PageGestion.Visible=true;
            kryptonNavigator1.SelectedPage = PageGestion;
        }

        private void CargarSucursales(ListarSucursales promo)
        {
            txtsucursal.Text = promo.NombreSucursal;
            txtencargado.Text=promo.NombreEncargado;
            txtdireccion.Text=promo.Direccion;
            txttelefono.Text=promo.Telefono;

        }
        private void BtnEditar_Click(object sender, EventArgs e)
          
        {
            if (DgvListSucursales.CurrentRow != null)
            {
                var fila = DgvListSucursales.CurrentRow;
                sucursales = (ListarSucursales)fila.DataBoundItem;
                CargarSucursales(sucursales);
                PageGestion.Visible = true;
                kryptonNavigator1.SelectedPage = PageGestion;
                sucunuevo = false;
            }
            else
            {
                KryptonMessageBox.Show("No ha seleccionado ninguna fila del listado.", "Notificación");
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            RefrescarDataGridSucursales(true);
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (DgvListSucursales.CurrentRow == null)
            {
                return;
            }

            var dialog = KryptonMessageBox.Show("¿Está seguro que desea eliminar la sucursal de la lista?", "Eliminar sucursal",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);
            // dale proba okoko

            if (dialog == DialogResult.Yes)
            {
                var productolista = (ListarSucursales)DgvListSucursales.CurrentRow.DataBoundItem;
                var productoObtenido = _sucursalesRepository.Get(productolista.Id);
                productoObtenido.IsActive = true;
                _sucursalesRepository.Update(productoObtenido);
                RefrescarDataGridSucursales(true);
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            var model = GetViewModel();

            if (ModelState.IsValid(model))
            {
                try
                {
                    _sucursalesRepository.Add(model);
                    Close();
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK);

                }
            }
            else
            {
                KryptonMessageBox.Show("Hay campos obligatorios sin llenar", "ERROR", MessageBoxButtons.OK);
            }
        }
    }
}
