using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
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
            SetMainForm(new LoginFORM());
            Application.Run(MainContext);
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Layout());*/
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
