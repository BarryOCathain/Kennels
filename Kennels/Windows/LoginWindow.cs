using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kennels.Interfaces;
using Kennels.ViewModels;

namespace Kennels.Windows
{
    public partial class LoginWindow : Form
    {
        ILogin login;
        public LoginWindow()
        {
            InitializeComponent();

            login = new LoginViewModel();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                login.LoginUser(usernameTextBox.Text, passwordTextBox.Text);
                this.DialogResult = DialogResult.OK;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }
    }
}
