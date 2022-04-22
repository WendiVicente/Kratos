using CapaDatos;
using CapaDatos.Models.Usuarios;
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
using System.Data.Entity;
using System.Data.SqlClient;

namespace Sistema
{
    public partial class LoginFORM : BaseContext
    {
        public LoginFORM()
        {
            InitializeComponent();
        }

        private void LoginFORM_Load(object sender, EventArgs e)
        {
            
            KryptonManager kryptonManager = new KryptonManager
            {
                GlobalPaletteMode = PaletteModeManager.SparkleOrange
            };

            if (Properties.Settings.Default.UserName != string.Empty)
            {
               correotxt.Text = Properties.Settings.Default.UserName;
               // contrasenatxt.Text = Properties.Settings.Default.PassUser;
                checkRemenber.Checked = true;
            }

        }

        // logearse
        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            var model = GetViewModel();
            guardaruser();

            if (!ModelState.IsValid(model))
            {
                KryptonMessageBox.Show("Asegúrense que los datos que ingrese esten correctos y completos. ", "ERROR", MessageBoxButtons.OK);
                return;
            }

            try
            {
                if (SignInStatus(model.Email, model.Password))
                {
                    /*
                         * Administrador
             Usuario Estandar
             Solo Venta
             Solo Caja
             Solo POS
             solo Administracion
                  * 
                  * */
                    var usermanagerr = new UserManager<User>(new UserStore<User>(_context));
                    var getUser = usermanagerr
                        .Find(model.Email, model.Password);
                    if(getUser.Privilegios== "solo Administracion" || getUser.Privilegios == "Administrador")
                    {
                        Program.SetMainForm(new LayoutV2(getUser));
                        Program.ShowMainForm();
                        Close();

                    }
                    else
                    {
                        KryptonMessageBox.Show("Su usuario  no cuenta con los privilegios para acceder a la administración");
                    }
                  
                }

                else
                {
                    KryptonMessageBox.Show("Login Incorrecto.");
                }

                
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show("Ha ocurrido un error interno.", ex.ToString());
            }


        }

        private void guardaruser()
        {
            if (checkRemenber.Checked)
            {
                Properties.Settings.Default.UserName = correotxt.Text;
               // Properties.Settings.Default.PassUser = contrasenatxt.Text;
                Properties.Settings.Default.Save();
            }
        }


        public bool SignInStatus(string username, string password)
        {
            var usermanagerr = new UserManager<User>(new UserStore<User>(_context));
            return usermanagerr.Find(username, password) != null;
        }

        private UserModelsLogin GetViewModel()
        {
            var usuario = new UserModelsLogin()
            {
                Email = correotxt.Text.Replace(" ", string.Empty),
                Password = contrasenatxt.Text.Replace(" ", string.Empty)
            };

            return usuario;
        }

        private void contrasenatxt_Enter(object sender, EventArgs e)
        {
            AcceptButton = kryptonButton1;
        }
    }
    public class UserModelsLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
