﻿using NoteProject.BLL.Services;
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
    public partial class AdminScreen : Form
    {
        UserService userService;
        public AdminScreen()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void AdminScreen_Load(object sender, EventArgs e)
        {
            List<User> users = userService.GetAllStandartUsers();
            FillListView(users);
        }

        public void FillListView(List<User> users)
        {
            listView1.Items.Clear();
            foreach (User user in users)
            {
                string activeStatus = user.IsActive ? "Aktif" : "Pasif";
                string[] datas = { user.FirtsName, user.LastName, user.UserName, activeStatus };
                ListViewItem lvi = new ListViewItem(datas);
                lvi.Tag = user.ID;

                listView1.Items.Add(lvi);
            }
        }

        private void btnDurum_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                int userId = (int)listView1.FocusedItem.Tag;
                userService.ChangeActiveStatus(userId);
                MessageBox.Show("Kullanici durumu degisti");

                List<User> users = userService.GetAllStandartUsers();
                FillListView(users);
            }
        }
    }
}
