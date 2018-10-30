using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AccountManager
{
    public partial class NotesForm : Form
    {
        // Account instance managed by the form.
        private Account _theAccount;

        public NotesForm(Account acc)
        {
            InitializeComponent();

            // Set the Account object for this form.
            _theAccount = acc;

            // Set the caption on the form.
            this.Text = string.Format("Notes for account: {0}", _theAccount.Name);

            // Display the Notes keys in the combo box.
            KeysComboBox.DataSource = _theAccount.Notes.AllKeys;
        }

        private void KeysComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Redisplay the notes.
            DisplayNotes(); 
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Get the selected key in the combo box.
            string key = (string)KeysComboBox.SelectedValue;
            
            // Get the text entered by the user.
            string noteValue = NoteTextBox.Text;

            // Add the note text to the selected key.
            _theAccount.Notes.Add(key, noteValue);

            // Redisplay the notes.
            DisplayNotes();
            NoteTextBox.Clear();
            NoteTextBox.Focus();
        }

        private void DisplayNotes()
        {
            // Get the selected key in the combo box.
            string key = (string)KeysComboBox.SelectedValue;

            // Get the note values for the selected key.
            string[] noteValues = _theAccount.Notes.GetValues(key);
 
            // Bind the list box to the note values.
            NotesListBox.DataSource = noteValues;
        }
    }
}