using Republik_Larva.Controller;
using System;
using System.Windows.Forms;

namespace Republik_Larva.Views.Akun
{
    public partial class V_TambahAdmin : UserControl
    {
        private C_Akun c_Akun;

        public V_TambahAdmin(C_Akun controller)
        {
            InitializeComponent();
            c_Akun = controller;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            string namaAdmin = lblNamaAdmin.Text.Trim();
            string username = lblUsername.Text.Trim();
            string password = lblPassword.Text.Trim();
            string konfirmPassword = lblKonfirmPassword.Text.Trim();

            bool isSuccess = c_Akun.tambahAdmin(namaAdmin, username, password, konfirmPassword);

            if (isSuccess)
            {
                c_Akun.show_message_box("Admin berhasil ditambahkan.");
                lblNamaAdmin.Clear();
                lblUsername.Clear();
                lblPassword.Clear();
                lblKonfirmPassword.Clear();
            }
            else
            {
                c_Akun.show_message_box("Gagal menambahkan admin. Coba lagi.");
            }
        }

        private void btnSimpan_MouseEnter(object sender, EventArgs e)
        {
            btnSimpan.BackgroundImage = Properties.Resources.simpanHover;
        }

        private void btnSimpan_MouseLeave(object sender, EventArgs e)
        {
            btnSimpan.BackgroundImage = Properties.Resources.simpan;
        }
        private void lblPassword_TextChanged(object sender, EventArgs e)
        {
            lblPassword.PasswordChar = '*';
        }
        private void lblKonfirmPassword_TextChanged(object sender, EventArgs e)
        {
            lblKonfirmPassword.PasswordChar = '*';
        }
    }
}
