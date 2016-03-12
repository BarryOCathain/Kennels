using System;
using System.Windows.Forms;
using Kennels.Windows;

namespace Kennels
{
    static class Program
    {
        public static MainMDIWindow MainWindow;

        public static User User;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginWindow lw = new LoginWindow();

            if (lw.ShowDialog() == DialogResult.OK)
            {
                User = lw.User;

                MainWindow = new MainMDIWindow();
                Application.Run(MainWindow);
            }
        }

        public static void AddChildForm(Form form)
        {
            
        }
    }
}
