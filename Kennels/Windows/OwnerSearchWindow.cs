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
    public partial class OwnerSearchWindow : Form
    {
        private IOwner owner;

        public OwnerSearchWindow()
        {
            InitializeComponent();

            this.MdiParent = Program.MainWindow;

            owner = new OwnerViewModel(new KennelsModelContainer());

            firstNameTextBox.TextChanged += (sender, eventArgs) => SearchOwners(firstNameTextBox.Text, surnameTextBox.Text);

            surnameTextBox.TextChanged += (sender, eventArgs) => SearchOwners(firstNameTextBox.Text, surnameTextBox.Text);
        }

        private void SearchOwners(string firstName, string surname)
        {
            switch (string.IsNullOrEmpty(firstName))
            {
                case false:
                    switch (string.IsNullOrEmpty(surname))
                    {
                        case false:
                            ownerSearchDataGridView.DataSource = owner.GetOwnersByFirstNameAndSurname(firstName, surname);
                            break;
                        case true:
                            ownerSearchDataGridView.DataSource = owner.GetOwnersByFirstName(firstName);
                            break;
                    }
                    break;
                case true:
                    switch (string.IsNullOrEmpty(surname))
                    {
                        case false:
                            ownerSearchDataGridView.DataSource = owner.GetOwnersBySurname(surname);
                            break;
                        case true:
                            ownerSearchDataGridView.DataSource = null;
                            break;
                    }
                    break;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
