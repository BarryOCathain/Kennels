using Kennels.Interfaces;
using Kennels.ViewModels;
using System;
using System.Windows.Forms;

namespace Kennels.Windows
{
    public partial class PaymentTypeWindow : Form
    {
        private IPaymentType paymentType;

        public PaymentTypeWindow()
        {
            InitializeComponent();

            paymentType = new PaymentTypeViewModel(new KennelsModelContainer());
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (paymentType.GetPaymentTypeByName(paymentTypeTextBox.Text.ToUpper()) != null)
                MessageBox.Show(string.Format("Payment Type {0} already exists.", paymentTypeTextBox.Text.ToUpper()));
            else
            {
                try
                {
                    paymentType.AddPaymentType(paymentTypeTextBox.Text.ToUpper(), Program.User);

                    closeButton_Click(sender, null);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void paymentTypeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                saveButton_Click(sender, e);
        }
    }
}
