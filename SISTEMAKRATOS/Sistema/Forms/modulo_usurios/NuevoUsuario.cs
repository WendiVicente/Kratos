using CapaDatos.Models.Usuarios;
using CapaDatos.Repository;
using CapaDatos.Security;
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
    public partial class NuevoUsuario : BaseContext
    {
        private readonly SucursalesRepository _sucursalesRepository = null;
        //private readonly ApplicationUserManager _userManager = null;
        //private IUserStore<User> _userStore = null;

        public NuevoUsuario()
        {
            //_userStore = new UserStore<User>(_context);
            _sucursalesRepository = new SucursalesRepository(_context);
            //_userManager = new ApplicationUserManager(_userStore);
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            CargarSucursales();
            base.OnLoad(e);
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
        

        private IdentityResult CrearUsuario(string name,string username, string password, int sucursal,string perfil)
        {
            var usermanagerr = new UserManager<User>(new UserStore<User>(_context));
            var user = new User() 
            {   
                UserName = username, 
                Name = name, 
                SucursalId = sucursal,
                Privilegios=perfil,

            };
            return usermanagerr.Create(user, password);
        }


        private void NuevoUser_Click(object sender, EventArgs e)
        {
            // TODO: Validar que no se repitan 2 usuarios con el correo

            var model = GetviewModel();

            if (ModelState.IsValid(model))
            {
                try
                {
                    CrearUsuario(model.Name, model.Email, model.Password, model.SucursalId,model.Privilegios);
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

        private void NuevoUsuario_Load(object sender, EventArgs e)
        {
            CargarSucursales();
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
    }
}
