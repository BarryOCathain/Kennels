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
            if (paymentType.GetPaymentTypeByName(paymentTypeTextBox.Text) != null)
                MessageBox.Show("Payment Type {0} already exists.", paymentTypeTextBox.Text);
            else
            { }
                //paymentType.AddPaymentType(paymentTypeTextBox.Text, )
        }
    }
}
