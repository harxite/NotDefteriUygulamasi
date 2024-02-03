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
    public partial class SignInScreen : Form
    {
        UserService userService;
        public SignInScreen()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtAd.Text) || string.IsNullOrEmpty(txtSoyad.Text) || string.IsNullOrEmpty(txtKullaniciAdi.Text) || string.IsNullOrEmpty(txtSifre.Text) || string.IsNullOrEmpty(txtSifreTekrar.Text))
            {
                MessageBox.Show("Alanlar bos gecilemez!");
                return;
            }

            if(txtSifre.Text != txtSifreTekrar.Text)
            {
                MessageBox.Show("Sifreler uyusmuyor !");
                return;
            }

            bool userCheck = userService.CheckUser(txtKullaniciAdi.Text);

            if (userCheck)
            {
                MessageBox.Show("Ayni kullanici adi ile baska bir kullanici mevcuttur !");
                return;
            }

            User user = new User();
            user.FirtsName = txtAd.Text;
            user.LastName = txtSoyad.Text;  
            user.UserName = txtKullaniciAdi.Text;
            user.Password = txtSifre.Text;

            userService.AddStandartUser(user);
            MessageBox.Show("Kayit basarili !");
            this.Close();
        }
    }
}
