using POS.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    static class Program
    {

        static ApplicationContext MainContext = new ApplicationContext();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MDIParent1());
            SetMainForm(new LoginForm());
            Application.Run(MainContext);
        }

        public static void SetMainForm(Form MainForm)
        {
            MainContext.MainForm = MainForm;
        }

        public static void ShowMainForm()
        {
            MainContext.MainForm.Show();
        }
    }
}
