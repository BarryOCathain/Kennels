using System.Windows.Forms;
using Kennels.Interfaces;
using Kennels.ViewModels;
using System;

namespace Kennels.Windows
{
    public partial class NoteWindow : Form
    {
        private INote note;

        private Animal _animal;

        public NoteWindow(Animal animal)
        {
            InitializeComponent();

            note = new NoteViewModel(new KennelsModelContainer());

            _animal = animal;
        }

        private void AddNote(string content, User user, Animal animal)
        {
            try
            {
                note.AddNote(content, user, animal);
                this.DialogResult = DialogResult.OK;
                Close();
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

        private void addNoteButton_Click(object sender, EventArgs e)
        {
            AddNote(contentTextBox.Text, Program.User, _animal);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NoteWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(contentTextBox.Text))
            {
                if (MessageBox.Show("If you close this window you will lose all changes.\n\nDo you wish to close this window?", 
                    "Discard Note?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
