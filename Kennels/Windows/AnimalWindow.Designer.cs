namespace Kennels.Windows
{
    partial class AnimalWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.animalGroupBox = new System.Windows.Forms.GroupBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.animalNameTextBox = new System.Windows.Forms.TextBox();
            this.ageLabel = new System.Windows.Forms.Label();
            this.deletedLabel = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.deletedCheckBox = new System.Windows.Forms.CheckBox();
            this.isMaleCheckBox = new System.Windows.Forms.CheckBox();
            this.isMaleLabel = new System.Windows.Forms.Label();
            this.ownerGroupBox = new System.Windows.Forms.GroupBox();
            this.notesGroupBox = new System.Windows.Forms.GroupBox();
            this.notesDataGridView = new System.Windows.Forms.DataGridView();
            this.addNoteButton = new System.Windows.Forms.Button();
            this.changeImageButton = new System.Windows.Forms.Button();
            this.changeOwnerButton = new System.Windows.Forms.Button();
            this.deleteNoteButton = new System.Windows.Forms.Button();
            this.includeDeletedNotesCheckBox = new System.Windows.Forms.CheckBox();
            this.ownerFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.ownerFirstNameLabel = new System.Windows.Forms.Label();
            this.ownerSurnameTextBox = new System.Windows.Forms.TextBox();
            this.ownerSurnameLabel = new System.Windows.Forms.Label();
            this.ownerNumberTextBox = new System.Windows.Forms.TextBox();
            this.ownerNumberLabel = new System.Windows.Forms.Label();
            this.ownerAddress1TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ownerPostcodeTextBox = new System.Windows.Forms.TextBox();
            this.ownerPostcodeLabel = new System.Windows.Forms.Label();
            this.addAnimalButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.animalBreedLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.animalPictureBox = new System.Windows.Forms.PictureBox();
            this.animalGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.ownerGroupBox.SuspendLayout();
            this.notesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // animalGroupBox
            // 
            this.animalGroupBox.Controls.Add(this.comboBox1);
            this.animalGroupBox.Controls.Add(this.animalBreedLabel);
            this.animalGroupBox.Controls.Add(this.isMaleCheckBox);
            this.animalGroupBox.Controls.Add(this.isMaleLabel);
            this.animalGroupBox.Controls.Add(this.deletedCheckBox);
            this.animalGroupBox.Controls.Add(this.numericUpDown1);
            this.animalGroupBox.Controls.Add(this.deletedLabel);
            this.animalGroupBox.Controls.Add(this.ageLabel);
            this.animalGroupBox.Controls.Add(this.animalNameTextBox);
            this.animalGroupBox.Controls.Add(this.nameLabel);
            this.animalGroupBox.Location = new System.Drawing.Point(12, 12);
            this.animalGroupBox.Name = "animalGroupBox";
            this.animalGroupBox.Size = new System.Drawing.Size(175, 122);
            this.animalGroupBox.TabIndex = 0;
            this.animalGroupBox.TabStop = false;
            this.animalGroupBox.Text = "Animal Details";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(7, 20);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // animalNameTextBox
            // 
            this.animalNameTextBox.Location = new System.Drawing.Point(69, 17);
            this.animalNameTextBox.Name = "animalNameTextBox";
            this.animalNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.animalNameTextBox.TabIndex = 1;
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point(7, 72);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(29, 13);
            this.ageLabel.TabIndex = 2;
            this.ageLabel.Text = "Age:";
            // 
            // deletedLabel
            // 
            this.deletedLabel.AutoSize = true;
            this.deletedLabel.Location = new System.Drawing.Point(101, 100);
            this.deletedLabel.Name = "deletedLabel";
            this.deletedLabel.Size = new System.Drawing.Size(47, 13);
            this.deletedLabel.TabIndex = 4;
            this.deletedLabel.Text = "Deleted:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(69, 70);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(100, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // deletedCheckBox
            // 
            this.deletedCheckBox.AutoSize = true;
            this.deletedCheckBox.Location = new System.Drawing.Point(154, 100);
            this.deletedCheckBox.Name = "deletedCheckBox";
            this.deletedCheckBox.Size = new System.Drawing.Size(15, 14);
            this.deletedCheckBox.TabIndex = 6;
            this.deletedCheckBox.UseVisualStyleBackColor = true;
            // 
            // isMaleCheckBox
            // 
            this.isMaleCheckBox.AutoSize = true;
            this.isMaleCheckBox.Location = new System.Drawing.Point(60, 100);
            this.isMaleCheckBox.Name = "isMaleCheckBox";
            this.isMaleCheckBox.Size = new System.Drawing.Size(15, 14);
            this.isMaleCheckBox.TabIndex = 8;
            this.isMaleCheckBox.UseVisualStyleBackColor = true;
            // 
            // isMaleLabel
            // 
            this.isMaleLabel.AutoSize = true;
            this.isMaleLabel.Location = new System.Drawing.Point(7, 100);
            this.isMaleLabel.Name = "isMaleLabel";
            this.isMaleLabel.Size = new System.Drawing.Size(33, 13);
            this.isMaleLabel.TabIndex = 7;
            this.isMaleLabel.Text = "Male:";
            // 
            // ownerGroupBox
            // 
            this.ownerGroupBox.Controls.Add(this.ownerPostcodeTextBox);
            this.ownerGroupBox.Controls.Add(this.ownerPostcodeLabel);
            this.ownerGroupBox.Controls.Add(this.ownerAddress1TextBox);
            this.ownerGroupBox.Controls.Add(this.label4);
            this.ownerGroupBox.Controls.Add(this.ownerNumberTextBox);
            this.ownerGroupBox.Controls.Add(this.ownerNumberLabel);
            this.ownerGroupBox.Controls.Add(this.ownerSurnameTextBox);
            this.ownerGroupBox.Controls.Add(this.ownerSurnameLabel);
            this.ownerGroupBox.Controls.Add(this.ownerFirstNameTextBox);
            this.ownerGroupBox.Controls.Add(this.ownerFirstNameLabel);
            this.ownerGroupBox.Location = new System.Drawing.Point(12, 140);
            this.ownerGroupBox.Name = "ownerGroupBox";
            this.ownerGroupBox.Size = new System.Drawing.Size(175, 156);
            this.ownerGroupBox.TabIndex = 2;
            this.ownerGroupBox.TabStop = false;
            this.ownerGroupBox.Text = "Owner Details";
            // 
            // notesGroupBox
            // 
            this.notesGroupBox.Controls.Add(this.includeDeletedNotesCheckBox);
            this.notesGroupBox.Controls.Add(this.deleteNoteButton);
            this.notesGroupBox.Controls.Add(this.addNoteButton);
            this.notesGroupBox.Controls.Add(this.notesDataGridView);
            this.notesGroupBox.Location = new System.Drawing.Point(12, 331);
            this.notesGroupBox.Name = "notesGroupBox";
            this.notesGroupBox.Size = new System.Drawing.Size(497, 224);
            this.notesGroupBox.TabIndex = 3;
            this.notesGroupBox.TabStop = false;
            this.notesGroupBox.Text = "Notes";
            // 
            // notesDataGridView
            // 
            this.notesDataGridView.AllowUserToAddRows = false;
            this.notesDataGridView.AllowUserToDeleteRows = false;
            this.notesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.notesDataGridView.Location = new System.Drawing.Point(6, 33);
            this.notesDataGridView.Name = "notesDataGridView";
            this.notesDataGridView.ReadOnly = true;
            this.notesDataGridView.Size = new System.Drawing.Size(485, 156);
            this.notesDataGridView.TabIndex = 0;
            // 
            // addNoteButton
            // 
            this.addNoteButton.Location = new System.Drawing.Point(6, 195);
            this.addNoteButton.Name = "addNoteButton";
            this.addNoteButton.Size = new System.Drawing.Size(75, 23);
            this.addNoteButton.TabIndex = 1;
            this.addNoteButton.Text = "Add Note";
            this.addNoteButton.UseVisualStyleBackColor = true;
            this.addNoteButton.Click += new System.EventHandler(this.addNoteButton_Click);
            // 
            // changeImageButton
            // 
            this.changeImageButton.Location = new System.Drawing.Point(100, 302);
            this.changeImageButton.Name = "changeImageButton";
            this.changeImageButton.Size = new System.Drawing.Size(87, 23);
            this.changeImageButton.TabIndex = 2;
            this.changeImageButton.Text = "Change Image";
            this.changeImageButton.UseVisualStyleBackColor = true;
            this.changeImageButton.Click += new System.EventHandler(this.addEditImageButton_Click);
            // 
            // changeOwnerButton
            // 
            this.changeOwnerButton.Location = new System.Drawing.Point(12, 302);
            this.changeOwnerButton.Name = "changeOwnerButton";
            this.changeOwnerButton.Size = new System.Drawing.Size(91, 23);
            this.changeOwnerButton.TabIndex = 2;
            this.changeOwnerButton.Text = "Change Owner";
            this.changeOwnerButton.UseVisualStyleBackColor = true;
            this.changeOwnerButton.Click += new System.EventHandler(this.changeOwnerButton_Click);
            // 
            // deleteNoteButton
            // 
            this.deleteNoteButton.Location = new System.Drawing.Point(416, 195);
            this.deleteNoteButton.Name = "deleteNoteButton";
            this.deleteNoteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteNoteButton.TabIndex = 2;
            this.deleteNoteButton.Text = "Delete Note";
            this.deleteNoteButton.UseVisualStyleBackColor = true;
            // 
            // includeDeletedNotesCheckBox
            // 
            this.includeDeletedNotesCheckBox.AutoSize = true;
            this.includeDeletedNotesCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.includeDeletedNotesCheckBox.Location = new System.Drawing.Point(359, 10);
            this.includeDeletedNotesCheckBox.Name = "includeDeletedNotesCheckBox";
            this.includeDeletedNotesCheckBox.Size = new System.Drawing.Size(132, 17);
            this.includeDeletedNotesCheckBox.TabIndex = 3;
            this.includeDeletedNotesCheckBox.Text = "Include Deleted Notes";
            this.includeDeletedNotesCheckBox.UseVisualStyleBackColor = true;
            // 
            // ownerFirstNameTextBox
            // 
            this.ownerFirstNameTextBox.Location = new System.Drawing.Point(69, 19);
            this.ownerFirstNameTextBox.Name = "ownerFirstNameTextBox";
            this.ownerFirstNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.ownerFirstNameTextBox.TabIndex = 10;
            // 
            // ownerFirstNameLabel
            // 
            this.ownerFirstNameLabel.AutoSize = true;
            this.ownerFirstNameLabel.Location = new System.Drawing.Point(7, 22);
            this.ownerFirstNameLabel.Name = "ownerFirstNameLabel";
            this.ownerFirstNameLabel.Size = new System.Drawing.Size(60, 13);
            this.ownerFirstNameLabel.TabIndex = 9;
            this.ownerFirstNameLabel.Text = "First Name:";
            // 
            // ownerSurnameTextBox
            // 
            this.ownerSurnameTextBox.Location = new System.Drawing.Point(69, 45);
            this.ownerSurnameTextBox.Name = "ownerSurnameTextBox";
            this.ownerSurnameTextBox.Size = new System.Drawing.Size(100, 20);
            this.ownerSurnameTextBox.TabIndex = 12;
            // 
            // ownerSurnameLabel
            // 
            this.ownerSurnameLabel.AutoSize = true;
            this.ownerSurnameLabel.Location = new System.Drawing.Point(7, 48);
            this.ownerSurnameLabel.Name = "ownerSurnameLabel";
            this.ownerSurnameLabel.Size = new System.Drawing.Size(52, 13);
            this.ownerSurnameLabel.TabIndex = 11;
            this.ownerSurnameLabel.Text = "Surname:";
            // 
            // ownerNumberTextBox
            // 
            this.ownerNumberTextBox.Location = new System.Drawing.Point(69, 71);
            this.ownerNumberTextBox.Name = "ownerNumberTextBox";
            this.ownerNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.ownerNumberTextBox.TabIndex = 14;
            // 
            // ownerNumberLabel
            // 
            this.ownerNumberLabel.AutoSize = true;
            this.ownerNumberLabel.Location = new System.Drawing.Point(7, 74);
            this.ownerNumberLabel.Name = "ownerNumberLabel";
            this.ownerNumberLabel.Size = new System.Drawing.Size(47, 13);
            this.ownerNumberLabel.TabIndex = 13;
            this.ownerNumberLabel.Text = "Number:";
            // 
            // ownerAddress1TextBox
            // 
            this.ownerAddress1TextBox.Location = new System.Drawing.Point(69, 97);
            this.ownerAddress1TextBox.Name = "ownerAddress1TextBox";
            this.ownerAddress1TextBox.Size = new System.Drawing.Size(100, 20);
            this.ownerAddress1TextBox.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Address 1:";
            // 
            // ownerPostcodeTextBox
            // 
            this.ownerPostcodeTextBox.Location = new System.Drawing.Point(69, 123);
            this.ownerPostcodeTextBox.Name = "ownerPostcodeTextBox";
            this.ownerPostcodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.ownerPostcodeTextBox.TabIndex = 18;
            // 
            // ownerPostcodeLabel
            // 
            this.ownerPostcodeLabel.AutoSize = true;
            this.ownerPostcodeLabel.Location = new System.Drawing.Point(7, 126);
            this.ownerPostcodeLabel.Name = "ownerPostcodeLabel";
            this.ownerPostcodeLabel.Size = new System.Drawing.Size(55, 13);
            this.ownerPostcodeLabel.TabIndex = 17;
            this.ownerPostcodeLabel.Text = "Postcode:";
            // 
            // addAnimalButton
            // 
            this.addAnimalButton.Location = new System.Drawing.Point(12, 561);
            this.addAnimalButton.Name = "addAnimalButton";
            this.addAnimalButton.Size = new System.Drawing.Size(75, 23);
            this.addAnimalButton.TabIndex = 4;
            this.addAnimalButton.Text = "Add Animal";
            this.addAnimalButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(434, 561);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // animalBreedLabel
            // 
            this.animalBreedLabel.AutoSize = true;
            this.animalBreedLabel.Location = new System.Drawing.Point(7, 46);
            this.animalBreedLabel.Name = "animalBreedLabel";
            this.animalBreedLabel.Size = new System.Drawing.Size(38, 13);
            this.animalBreedLabel.TabIndex = 9;
            this.animalBreedLabel.Text = "Breed:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(69, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // animalPictureBox
            // 
            this.animalPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.animalPictureBox.Image = global::Kennels.Properties.Resources.NoImage;
            this.animalPictureBox.InitialImage = global::Kennels.Properties.Resources.NoImage;
            this.animalPictureBox.Location = new System.Drawing.Point(193, 12);
            this.animalPictureBox.Name = "animalPictureBox";
            this.animalPictureBox.Size = new System.Drawing.Size(316, 313);
            this.animalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.animalPictureBox.TabIndex = 1;
            this.animalPictureBox.TabStop = false;
            // 
            // AnimalWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 593);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.addAnimalButton);
            this.Controls.Add(this.changeOwnerButton);
            this.Controls.Add(this.changeImageButton);
            this.Controls.Add(this.notesGroupBox);
            this.Controls.Add(this.ownerGroupBox);
            this.Controls.Add(this.animalPictureBox);
            this.Controls.Add(this.animalGroupBox);
            this.Name = "AnimalWindow";
            this.Text = "Add / Edit Animal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnimalWindow_FormClosing);
            this.animalGroupBox.ResumeLayout(false);
            this.animalGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ownerGroupBox.ResumeLayout(false);
            this.ownerGroupBox.PerformLayout();
            this.notesGroupBox.ResumeLayout(false);
            this.notesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox animalGroupBox;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label deletedLabel;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.TextBox animalNameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.CheckBox deletedCheckBox;
        private System.Windows.Forms.CheckBox isMaleCheckBox;
        private System.Windows.Forms.Label isMaleLabel;
        private System.Windows.Forms.PictureBox animalPictureBox;
        private System.Windows.Forms.GroupBox ownerGroupBox;
        private System.Windows.Forms.TextBox ownerPostcodeTextBox;
        private System.Windows.Forms.Label ownerPostcodeLabel;
        private System.Windows.Forms.TextBox ownerAddress1TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ownerNumberTextBox;
        private System.Windows.Forms.Label ownerNumberLabel;
        private System.Windows.Forms.TextBox ownerSurnameTextBox;
        private System.Windows.Forms.Label ownerSurnameLabel;
        private System.Windows.Forms.TextBox ownerFirstNameTextBox;
        private System.Windows.Forms.Label ownerFirstNameLabel;
        private System.Windows.Forms.GroupBox notesGroupBox;
        private System.Windows.Forms.CheckBox includeDeletedNotesCheckBox;
        private System.Windows.Forms.Button deleteNoteButton;
        private System.Windows.Forms.Button addNoteButton;
        private System.Windows.Forms.DataGridView notesDataGridView;
        private System.Windows.Forms.Button changeImageButton;
        private System.Windows.Forms.Button changeOwnerButton;
        private System.Windows.Forms.Button addAnimalButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label animalBreedLabel;
    }
}