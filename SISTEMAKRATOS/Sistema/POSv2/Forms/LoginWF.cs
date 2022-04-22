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

namespace POSv2.Forms
{
    public partial class LoginWF : Form
    {
        public LoginWF()
        {
            InitializeComponent();
        }

        private void LoginWF_Load(object sender, EventArgs e)
        {
            KryptonManager kryptonManager = new KryptonManager
            {
                GlobalPaletteMode = PaletteModeManager.SparkleOrange
            };

        }
        private void btnloggin_Click(object sender, EventArgs e)
        {
            var model = GetViewModel();

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


                    Program.SetMainForm(new MDIParent1(getUser));//daledale
                    Program.ShowMainForm();
                    Close();
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
