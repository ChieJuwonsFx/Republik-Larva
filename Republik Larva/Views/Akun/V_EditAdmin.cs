using Republik_Larva.Controller;
using Republik_Larva.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Republik_Larva.Views.Akun
{
    public partial class V_EditAdmin : UserControl
    {
        private C_Akun c_Akun;
        private DataAkun adminData;

        public V_EditAdmin(C_Akun controller, DataAkun dataAdmin)
        {
            InitializeComponent();
            c_Akun = controller;
            adminData = dataAdmin;

            if (adminData != null)
            {
                namaAdmin.Text = adminData.nama_admin;
                username.Text = adminData.username;
                password.Text = adminData.password; 
                konfirmPassword.Text = adminData.password;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            string namaAdmin = this.namaAdmin.Text.Trim();
            string password = this.password.Text.Trim();
            string konfirmPassword = this.konfirmPassword.Text.Trim();

            c_Akun.editAdmin(adminData.admin_id, namaAdmin, password, konfirmPassword);
            c_Akun.balikAkun();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            password.PasswordChar = '*';
        }
        private void konfirmPassword_TextChanged(object sender, EventArgs e)
        {
            konfirmPassword.PasswordChar = '*';
        }
    }
}

