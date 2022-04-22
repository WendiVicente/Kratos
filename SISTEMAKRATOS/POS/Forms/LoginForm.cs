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
using POS.Forms.Facturacion;

namespace POS.Forms
{
    public partial class LoginForm : BaseContext
    {
        public Form FormularioVolver;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnloggin_Click(object sender, EventArgs e)
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
                    // re buscar, corregir esto, es repetitivo, solo es para hacelro rapido
                    // no repetir codigo
                    var usermanagerr = new UserManager<User>(new UserStore<User>(_context));
                    var getUser = usermanagerr
                        .Find(model.Email, model.Password);

                    // ya no porque ya no es estatica.
                    //UsuarioLogeado.Name = getUser.Name;
                    //UsuarioLogeado.SucursalId = getUser.SucursalId;

                    /*
                    Program.SetMainForm(new MDIParent1(getUser));//daledale
                    Program.ShowMainForm();
                    Close();*/
                    /*
                        * Administrador
            Usuario Estandar
            Solo Venta
            Solo Caja
            Solo POS
            solo Administracion
                 * 
                 * */


                    if (getUser.Privilegios == "Solo Venta" || getUser.Privilegios == "Administrador" || getUser.Privilegios == "Solo Caja" || getUser.Privilegios == "Solo POS")
                    {
                        Program.SetMainForm(new PuntoDeVenta(getUser, FormularioVolver));
                        Program.ShowMainForm();
                        Close();
                    }
                    else
                    {
                        KryptonMessageBox.Show("Su usuario  no cuenta con los privilegios para acceder al POS");
                        Close();
                    }
                }

                else
                {
                    KryptonMessageBox.Show("Login Incorrecto.");
                }


            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Ha ocurrido un error interno.", ex.ToString());
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            KryptonManager kryptonManager = new KryptonManager
            {
                GlobalPaletteMode = PaletteModeManager.SparkleOrange
            };
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                correotxt.Text = Properties.Settings.Default.UserName;
                checkRemenber.Checked = true;
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

        private void checkRemenber_CheckedChanged(object sender, EventArgs e)
        {

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

        private void btnloggin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this.AcceptButton = Enter;
        }

        private void contrasenatxt_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnloggin;
            //btnloggin_Click(sender, e);
        }

        private void contrasenatxt_TextChanged(object sender, EventArgs e)
        {

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
