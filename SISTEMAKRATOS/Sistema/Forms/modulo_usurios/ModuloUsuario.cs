using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Usuarios;
using CapaDatos.Repository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_usurios
{
    public partial class ModuloUsuario : BaseContext
    {
        private readonly SucursalesRepository _sucursalesRepository = null;
        private readonly RepositoryUsuarios _usuariosRepository = null;
        int _token = 0;
        public ModuloUsuario()
        {
            _sucursalesRepository = new SucursalesRepository(_context);
            _usuariosRepository = new RepositoryUsuarios(_context);
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            MenuPrincipal(this);
        }
        private void CargarSucursales()
        {
            sucursaleslista.DataSource = _sucursalesRepository.GetList();
            sucursaleslista.DisplayMember = "NombreSucursal";
            sucursaleslista.ValueMember = "Id";
            sucursaleslista.Invalidate();
            //combo permisos
            cbpermisos.SelectedIndex = 0;
        }
        private void ModuloUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuPrincipal(this, false);
        }

        private void ModuloUsuario_Load(object sender, EventArgs e)
        {
            CargarSucursales();
            cargarDatagrid();
        }
        private void cargarDatagrid()
        {

            var listausuarios = _usuariosRepository.GetListarUsuarios();
            BindingSource recurso = new BindingSource();

            recurso.DataSource = listausuarios;
            dgvusuarios.DataSource = typeof(List<>);
            dgvusuarios.DataSource = recurso;
            dgvusuarios.AutoResizeColumns();
            // _listaCombos = lista;


        }
        private IdentityResult CrearUsuario(string name, string username, string password, int sucursal, string perfil)
        {
            try
            {
                var usermanagerr = new UserManager<User>(new UserStore<User>(_context));
                var user = new User()
                {
                    UserName = username,
                    Name = name,
                    SucursalId = sucursal,
                    Privilegios = perfil,
                    IsDeleted = false
                };
                return usermanagerr.Create(user, password);
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
                return null;
            }

        }
        public UserModels GetviewModel()
        {
            var usuario = new UserModels()
            {
                Email = correousuario.Text,
                Name = Nombrestrab.Text,
                SucursalId = Convert.ToInt32(sucursaleslista.SelectedValue.ToString()),
                Password = contrasena.Text,
                ConfirmPassword = confirmarcontrasena.Text,
                Privilegios = cbpermisos.Text,
               
            };

            return usuario;
        }
        private void BtnGuadar_Click(object sender, EventArgs e)
        {
            var model = GetviewModel();

            if (model.Password.Length < 6)
            {
                KryptonMessageBox.Show("La contrasesña es muy corta.", "Notificación", MessageBoxButtons.OK);
                return;
            }

            if (ModelState.IsValid(model))
            {
                try
                {
                    CrearUsuario(model.Name, model.Email, model.Password, model.SucursalId, model.Privilegios);
                
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
        public class UserModels
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            public string Name { get; set; }

            [Required]
            [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos {2} dígitos.")]
            public string Password { get; set; }

            [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "*La contraseña de confirmación no es igual a la ingresada.")]
            public string ConfirmPassword { get; set; }

            public int SucursalId { get; set; }
            public string Privilegios { get; set; }
           // public int Token { get; set; }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvusuarios.CurrentRow == null)
            {
                return;
            }

            var dialog = KryptonMessageBox.Show("¿Está seguro que desea eliminar el usuario de la lista?", "Eliminar usuario",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);
            // dale proba okoko

            if (dialog == DialogResult.Yes)
            {
                var usuarioselected = (ListarUsuarios)dgvusuarios.CurrentRow.DataBoundItem;
                var userobtenido = _usuariosRepository.Get(usuarioselected.Id);
                userobtenido.IsDeleted = true;
                _usuariosRepository.Update(userobtenido);
                cargarDatagrid();

            }
        }
    }
}
