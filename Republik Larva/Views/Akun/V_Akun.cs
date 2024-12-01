using System;
using System.Windows.Forms;
using Republik_Larva.Controller;
using Republik_Larva.Models;
using Republik_Larva.Views.Akun;

namespace Republik_Larva.Views
{
    public partial class V_Akun : UserControl
    {
        private C_Akun c_Akun;
        private DataAkun akun;
        private V_TambahAdmin tambahAdmin;
        private C_MainForm mainForm;

        public V_Akun(C_Akun controller, DataAkun akun)
        {
            InitializeComponent();
            c_Akun = controller;
            this.akun = akun;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Properties.Resources.closeHover;
        }
        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Properties.Resources.close;
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            c_Akun.logout();
        }
        private void btnLogout_MouseEnter(object sender, EventArgs e)
        {
            btnLogout.BackgroundImage = Properties.Resources.logoutHover;
        }
        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            btnLogout.BackgroundImage = Properties.Resources.logout;
        }
        private void V_Akun_Load(object sender, EventArgs e)
        {
            if (akun != null)
            {
                nama.Text = akun.nama_admin ?? "Nama tidak tersedia";
                username.Text = akun.username ?? "Username tidak tersedia";
            }
            else
            {
                nama.Text = "Data akun tidak ditemukan";
                username.Text = "Data akun tidak ditemukan";
            }
        }

        private void btnTambahAdmin_Click(object sender, EventArgs e)
        {
            c_Akun.tambahAdminView();
        }
        private void btnTambahAdmin_MouseEnter(object sender, EventArgs e)
        {
            btnTambahAdmin.BackgroundImage = Properties.Resources.tambahAdminBaruHover;
        }
        private void btnTambahAdmin_MouseLeave(object sender, EventArgs e)
        {
            btnTambahAdmin.BackgroundImage = Properties.Resources.tambahAdminBaru;
        }

        private void btnEditAdmin_Click(object sender, EventArgs e)
        {
            c_Akun.editAdminView();
        }
        private void btnEditAdmin_MouseEnter(object sender, EventArgs e)
        {
            btnEditAdmin.BackgroundImage = Properties.Resources.editDataAkunHover;
        }
        private void btnEditAdmin_MouseLeave(object sender, EventArgs e)
        {
            btnEditAdmin.BackgroundImage = Properties.Resources.editDataAkun;
        }
        private void btnLihatSemua_Click(object sender, EventArgs e)
        {
            c_Akun.AllAdminView();
        }
        private void btnLihatSemua_MouseLeave(object sender, EventArgs e)
        {
            btnLihatSemua.BackgroundImage = Properties.Resources.lihatSemuaAdmin;
        }
        private void btnLihatSemua_MouseEnter(object sender, EventArgs e)
        {
            btnLihatSemua.BackgroundImage = Properties.Resources.lihatSemuaAdminHover;
        }
    }
}
