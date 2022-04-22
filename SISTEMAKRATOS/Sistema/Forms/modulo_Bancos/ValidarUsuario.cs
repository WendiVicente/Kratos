using CapaDatos.Models.Usuarios;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_Bancos
{
    public partial class ValidarUsuario : BaseContext
    {
        private ValidarTransacciones _Validar = null;
        public ValidarUsuario(ValidarTransacciones forms)
        {
            _Validar = forms;
            InitializeComponent();
        }

        private void ValidarUsuario_Load(object sender, EventArgs e)
        {
            CargarUser();
        }

        private void CargarUser()
        {
            txtuser.Text = UsuarioLogeadoSistemas.User.UserName;

        }

        private void ValidarContraseña()
        {
            var model = GetViewModel();

            if (SignInStatus(model.Email, model.Password))
            {
                
                var usermanagerr = new UserManager<User>(new UserStore<User>(_context));
                var getUser = usermanagerr
                    .Find(model.Email, model.Password);

                _Validar.PermitirValidacion();
                Close();
               
            }
            else
            {
                KryptonMessageBox.Show("Login Incorrecto.");
                
            } 

        }


        private UserModelsLogin GetViewModel()
        {
            var usuario = new UserModelsLogin()
            {
                Email = txtuser.Text,
                Password = txtpassw.Text.Replace(" ", string.Empty)
            };

            return usuario;
        }


        public bool SignInStatus(string username, string password)
        {
            var usermanagerr = new UserManager<User>(new UserStore<User>(_context));
            return usermanagerr.Find(username, password) != null;
        }


        private void GuardarCambios() 
        {



        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            ValidarContraseña();
        }
    }
}
