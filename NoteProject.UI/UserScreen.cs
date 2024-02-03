using NoteProject.BLL.Services;
using NoteProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteProject.UI
{
    public partial class UserScreen : Form
    {
        int userID;
        NoteService noteService;
        Note note;
        public UserScreen(int userId)
        {
            InitializeComponent();
            userID = userId;
            noteService = new NoteService();
        }

        private void UserScreen_Load(object sender, EventArgs e)
        {
            List<Note> notes = noteService.GetAllByUserId(userID);
            lboxNotlar.DisplayMember = "Title";
            lboxNotlar.ValueMember = "Id";
            lboxNotlar.DataSource = notes;
            SetDefaultSettings(true);
        }

        private void lboxNotlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lboxNotlar.SelectedIndex > -1)
            {
                int noteId = (int)lboxNotlar.SelectedValue;
                note = noteService.GetByID(noteId);
                txtBaslik.Text = note.Title;
                txtIcerik.Text = note.Content;

                SetDefaultSettings(false);
            }
        }

        private void SetDefaultSettings(bool set)
        {
            if (set)
            {
                btnNotSil.Enabled = false;
                btnKaydet.Text = "Kaydet";
                txtBaslik.Clear();
                txtIcerik.Clear();
                note = null;
            }
            else
            {
                btnNotSil.Enabled = true;
                btnKaydet.Text = "Guncelle";

            }
        }

        private void btnYeniNot_Click(object sender, EventArgs e)
        {
            SetDefaultSettings(true);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (note is null)
            {
                note = new Note();
                note.UserID = userID;
                note.Title = txtBaslik.Text;
                note.Content = txtIcerik.Text;
                noteService.Add(note);
                lboxNotlar.DataSource = noteService.GetAllByUserId(userID);
                MessageBox.Show("Notunuz eklenmistir");
                SetDefaultSettings(true);
            }
            else
            {
                note.Title = txtBaslik.Text;
                note.Content = txtIcerik.Text;
                noteService.Update(note);
                MessageBox.Show("Notunuz guncellenmistir");
                lboxNotlar.DataSource = noteService.GetAllByUserId(userID);
                SetDefaultSettings(true);

            }
        }

        private void btnNotSil_Click(object sender, EventArgs e)
        {
            if (note is not null)
            {
                noteService.Delete(note);
                MessageBox.Show("Notunuz silinmistir");
                lboxNotlar.DataSource = noteService.GetAllByUserId(userID);
                SetDefaultSettings(true);

            }
            else
            {
                MessageBox.Show("Silinecek notu seciniz");
            }
        }

        private void linkSifreDegis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PasswordChangeScreen passwordChangeScreen = new PasswordChangeScreen(userID);
            this.Hide();
            passwordChangeScreen.ShowDialog();
            this.Show();
        }
    }
}
