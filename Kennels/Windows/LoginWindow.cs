using System;
using System.Windows.Forms;
using Kennels.Interfaces;
using Kennels.ViewModels;
using Kennels.Common;
using System.Drawing;

namespace Kennels.Windows
{
    public partial class LoginWindow : Form
    {
        public User User { get; set; }

        private ILogin login;
        public LoginWindow()
        {
            InitializeComponent();

            CommonUtilities.RecursiveLoopControls(this);

            login = new LoginViewModel();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                User = login.LoginUser(usernameTextBox.Text, passwordTextBox.Text);
                this.DialogResult = DialogResult.OK;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                loginButton_Click(sender, e);
        }
    }
}
