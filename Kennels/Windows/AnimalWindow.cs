using Kennels.Interfaces;
using Kennels.ViewModels;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kennels.Windows
{
    public partial class AnimalWindow : Form
    {
        private Animal _animal;
        private IAnimal animal;
        private INote note;
        private bool _updating = false;

        public AnimalWindow(Animal contextAnimal = null)
        {
            InitializeComponent();

            animal = new AnimalViewModel(new KennelsModelContainer());
            note = new NoteViewModel(new KennelsModelContainer());

            includeDeletedNotesCheckBox.CheckedChanged += 
                new EventHandler((sender, eventArgs) => RefreshNotes(includeDeletedNotesCheckBox.Checked));

            _animal = contextAnimal;

            if (_animal != null)
            {
                LoadAnimal(_animal);
            }
        }

        private void LoadAnimal(Animal animal)
        {
            if (animal.GetType() == typeof(Dog) || animal.GetType() == typeof(Bird))
            {

            }

        }

        private void addEditImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog _fileDialog = new OpenFileDialog();
            _fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            _fileDialog.Filter = "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|" +
                "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";

            if (_fileDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.animalPictureBox.Image = GetImageFromFile(_fileDialog.FileName);
            }
        }

        private Image GetImageFromFile(string filename)
        {
            return Image.FromFile(filename);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AnimalWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_updating)
            {
                if (MessageBox.Show("If you close this window you will lose all changes.\n\nDo you wish to continue?",
                    "Cancel Update?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void addNoteButton_Click(object sender, EventArgs e)
        {
            if (_animal != null)
            {
                if (new NoteWindow(_animal).ShowDialog() == DialogResult.OK)
                {
                    RefreshNotes(includeDeletedNotesCheckBox.Checked);
                }
            }
        }

        private void RefreshNotes(bool includeDeleted)
        {
            if (includeDeleted)
                notesDataGridView.DataSource = note.GetAllNotesByAnimal(_animal);
            else
                notesDataGridView.DataSource = note.GetAllActiveNotesByAnimal(_animal);
        }

        private void changeOwnerButton_Click(object sender, EventArgs e)
        {

        }
    }
}
