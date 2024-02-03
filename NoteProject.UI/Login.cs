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
    public partial class Login : Form
    {
        UserService userService;
        public Login()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            userService = new UserService();

            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Alanlar bos gecilemez!");
                return;
            }

            User user = userService.GetByUserName(txtKullaniciAdi.Text);
            if (user == null)
            {
                MessageBox.Show("Bu isimde bir kullanici bulunamadi. Lutfen kaydolunuz!");
                return;
            }

            if (user.Password != txtSifre.Text)
            {
                MessageBox.Show("Sifreniz yanlis!");
                return;
            }
            if (!user.IsActive)
            {
                MessageBox.Show("Hesabiniz onaylanmamistir. Lutfen admin ile iletisime geciniz!");
                return;
            }

            switch (user.UserType)
            {
                case Domain.Enums.UserType.Admin:
                    AdminScreen adminScreen = new AdminScreen();
                    this.Hide();
                    adminScreen.ShowDialog();
                    this.Show();
                    return;
                case Domain.Enums.UserType.Standart:
                    UserScreen userScreen = new UserScreen(user.ID);
                    this.Hide();
                    userScreen.ShowDialog();
                    this.Show();
                    return;
            }

        }

        private void linkKayit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignInScreen signInScreen = new SignInScreen();
            this.Hide();
            signInScreen.ShowDialog();
            this.Show();
        }
    }
}
