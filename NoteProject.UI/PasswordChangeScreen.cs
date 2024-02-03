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
    public partial class PasswordChangeScreen : Form
    {
        int userID;
        UserService userService;
        public PasswordChangeScreen(int userId)
        {
            InitializeComponent();
            userID = userId;
            userService = new UserService();
        }

        private void btnSifreDegis_Click(object sender, EventArgs e)
        {
            User user = userService.GetByUserId(userID);

            string password = user.Password;
            if (txtEskiSifre.Text == password)
            {
                if (txtYeniSifre.Text.Length >= 6)
                {
                    if (txtYeniSifre.Text == txtYeniSifreTekrar.Text)
                    {
                        user.Password = txtYeniSifre.Text;
                        userService.Update(user);
                        MessageBox.Show("Yeni sifreniz basarili bir sekilde kaydedildi !");
                        this.Close();
                    }
                    else
                        MessageBox.Show("Girdiginiz sifreler uyusmuyor !");
                }
                else
                    MessageBox.Show("Sifreniz en az 6 karakterden olusmalidir !");
            }
            else
                MessageBox.Show("Eski sifreniz hatali !");
        }
    }
}
