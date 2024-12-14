using Republik_Larva.Controller;
using System;
using System.Windows.Forms;

namespace Republik_Larva.Views.Akun
{
    public partial class V_EditAdmin : UserControl
    {
        private C_Akun c_Akun;
        private int adminId; 

        public V_EditAdmin(C_Akun controller, int adminId)
        {
            InitializeComponent();
            c_Akun = controller;
            this.adminId = adminId;

            var adminData = c_Akun.GetAdminById(adminId);

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

            c_Akun.EditAdmin(adminId, namaAdmin, password, konfirmPassword);

            c_Akun.balikAkun();
        }

        private void btnSimpan_MouseEnter(object sender, EventArgs e)
        {
            btnSimpan.BackgroundImage = Properties.Resources.simpanHover;
        }

        private void btnSimpan_MouseLeave(object sender, EventArgs e)
        {
            btnSimpan.BackgroundImage = Properties.Resources.simpan;
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            password.PasswordChar = '*';
        }

        private void konfirmPassword_TextChanged(object sender, EventArgs e)
        {
            konfirmPassword.PasswordChar = '*';
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            c_Akun.balikAkun();
        }

        private void btnKembali_MouseLeave(object sender, EventArgs e)
        {
            btnKembali.BackgroundImage = Properties.Resources.kembali;
        }

        private void btnKembali_MouseEnter(object sender, EventArgs e)
        {
            btnKembali.BackgroundImage = Properties.Resources.kembaliHover;
        }
    }
}
